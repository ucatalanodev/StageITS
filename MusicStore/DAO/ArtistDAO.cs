using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MusicStore.DAO
{
    public class ArtistDAO
    {
        //CONNECTION

        const string CONNECTION_STRING = @"Data Source=DESKTOP-URBANO;Initial Catalog=MusicStore;Trusted_connection=true;";


        #region METHODS (get, insert, update, delete)
        public static List<Artist> GetArtistList()
        {
            List<Artist> res = new List<Artist>();
            var connection = new SqlConnection(CONNECTION_STRING);

            try
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Artist";
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Artist artist = new Artist(
                                dr.GetInt64("artist_id"),
                                dr.GetString("artist_name"),
                                dr.GetString("artist_origin"),
                                dr.GetString("website"),
                                dr.GetString("social"),
                                dr.GetBoolean("is_band"),
                                dr.GetBoolean("is_active")
                                );

                            res.Add(artist);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ArtistList -  Message: {ex.Message} - Stack: {ex.StackTrace}");
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
        public static long InsertArtist(string anam, string aori, string web, string soc, bool isb, bool isa)
        {
            long res = -1;
            var connection = new SqlConnection(CONNECTION_STRING);

            try
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Artist VALUES ( @artist_name, @artist_origin, @website, @social, @is_band, @is_active );" +
                        "SELECT CONVERT(bigint, SCOPE_IDENTITY());";

                    cmd.Parameters.AddWithValue("@artist_name", anam);
                    cmd.Parameters.AddWithValue("@artist_origin", aori);
                    cmd.Parameters.AddWithValue("@website", web);
                    cmd.Parameters.AddWithValue("@social", soc);
                    cmd.Parameters.AddWithValue("@is_band", isb);
                    cmd.Parameters.AddWithValue("@is_active", isa);

                    cmd.CommandType = CommandType.Text;

                    res = (long)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error InsertArtist Message: {ex.Message} - Stack: {ex.StackTrace}");
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
        public static bool UpdateArtist(long arid, string anam, string aori, string web, string soc, bool isb, bool isa)
        {
            bool res = false;
            var connection = new SqlConnection(CONNECTION_STRING);

            try
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Artist SET " +
                        " artist_name  = @artist_name, " +
                        " artist_origin  = @artist_origin, " +
                        " website  = @website, " +
                        " social  = @social, " +
                        " is_band  = @is_band, " +
                        " is_active  = @is_active " +
                        "WHERE artist_id = @artist_id";

                    cmd.Parameters.AddWithValue("@artist_id", arid);
                    cmd.Parameters.AddWithValue("@artist_name", anam);
                    cmd.Parameters.AddWithValue("@artist_origin", aori);
                    cmd.Parameters.AddWithValue("@website", web);
                    cmd.Parameters.AddWithValue("@social", soc);
                    cmd.Parameters.AddWithValue("@is_band", isb);
                    cmd.Parameters.AddWithValue("@is_active", isa);

                    cmd.CommandType = System.Data.CommandType.Text;

                    return res = cmd.ExecuteNonQuery() == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error UpdateArtist Message: {ex.Message} - Stack: {ex.StackTrace}");
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
        public static bool DeleteArtist(long arid)
        {
            bool res = false;
            var connection = new System.Data.SqlClient.SqlConnection(CONNECTION_STRING);

            try
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Artist WHERE artist_id = @artist_id";

                    cmd.Parameters.AddWithValue("@artist_id", arid);

                    cmd.CommandType = System.Data.CommandType.Text;

                    res = cmd.ExecuteNonQuery() == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error DeleteArtist Message: {ex.Message} - Stack: {ex.StackTrace}");
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
