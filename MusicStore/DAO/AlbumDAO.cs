using MusicStore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MusicStore.DAO
{
    public class AlbumDAO
    {
        //CONNECTION

        const string CONNECTION_STRING = @"Data Source=DESKTOP-URBANO;Initial Catalog=MusicStore;Trusted_connection=true;";


        #region METHODS (get, insert, update, delete)
        public static List<Album> GetAlbumList()
        {
            List<Album> res = new List<Album>();
            var connection = new SqlConnection(CONNECTION_STRING);

            try
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Album";
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Album album = new Album(
                                dr.GetInt64("album_id"),
                                dr.GetInt64("artist_id"),
                                dr.GetString("album_title"),
                                dr.GetString("genre"),
                                dr.GetString("publ_year"),
                                dr.GetString("record_label"),
                                dr.GetDouble("price")
                                );

                            res.Add(album);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error AlbumList -  Message: {ex.Message} - Stack: {ex.StackTrace}");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                    connection = null;
                }
            }
            return res;
        }
        public static long InsertAlbum(long arid, string atit, string gen, string pyea, string rlab, double pri)
        {
            long res = -1;
            var connection = new SqlConnection(CONNECTION_STRING);

            try
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Album VALUES ( @artist_id, @album_title, @genre, @publ_year, @record_label, @price );" +
                        "SELECT CONVERT(bigint, SCOPE_IDENTITY())" +
                        $"WHERE @artist_id like {arid}";

                    cmd.Parameters.AddWithValue("@artist_id", arid);
                    cmd.Parameters.AddWithValue("@album_title", atit);
                    cmd.Parameters.AddWithValue("@genre", gen);
                    cmd.Parameters.AddWithValue("@publ_year", pyea);
                    cmd.Parameters.AddWithValue("@record_label", rlab);
                    cmd.Parameters.AddWithValue("@price", pri);

                    cmd.CommandType = CommandType.Text;

                    res = (long)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error InsertAlbum Message: {ex.Message} - Stack: {ex.StackTrace}");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                    connection = null;
                }
            }
            return res;

        }
        public static bool UpdateAlbum(long alid, long arid, string atit, string gen, string pyea, string rlab, double pri)
        {
            bool res = false;
            var connection = new SqlConnection(CONNECTION_STRING);

            try
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Album SET " +
                        " artist_id  = @artist_id, " +
                        " album_title  = @album_title, " +
                        " genre  = @genre, " +
                        " publ_year  = @publ_year, " +
                        " record_label  = @record_label, " +
                        " price = @price " +
                        "WHERE album_id = @album_id";

                    cmd.Parameters.AddWithValue("@album_id", alid);
                    cmd.Parameters.AddWithValue("@artist_id", arid);
                    cmd.Parameters.AddWithValue("@album_title", atit);
                    cmd.Parameters.AddWithValue("@genre", gen);
                    cmd.Parameters.AddWithValue("@publ_year", pyea);
                    cmd.Parameters.AddWithValue("@record_label", rlab);
                    cmd.Parameters.AddWithValue("@price", pri);

                    cmd.CommandType = CommandType.Text;

                    return res = cmd.ExecuteNonQuery() == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error UpdateAlbum Message: {ex.Message} - Stack: {ex.StackTrace}");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                    connection = null;
                }
            }
            return res;
        }
        public static bool DeleteAlbum(long alid)
        {
            bool res = false;
            var connection = new System.Data.SqlClient.SqlConnection(CONNECTION_STRING);

            try
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Album WHERE album_id = @album_id";

                    cmd.Parameters.AddWithValue("@album_id", alid);

                    cmd.CommandType = System.Data.CommandType.Text;

                    res = cmd.ExecuteNonQuery() == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error DeleteAlbum Message: {ex.Message} - Stack: {ex.StackTrace}");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                    connection = null;
                }
            }
            return res;
        }
        #endregion
    }
}
