using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MusicStore.DAO
{
    public class PurchaseDAO
    {
        //CONNECTION

        const string CONNECTION_STRING = @"Data Source=DESKTOP-URBANO;Initial Catalog=MusicStore;Trusted_connection=true;";


        #region METHODS (get)
        public static List<Purchase> GetOrderList()
        {
            List<Purchase> res = new List<Purchase>();
            var connection = new SqlConnection(CONNECTION_STRING);

            try
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Purchase";
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Purchase purchase = new Purchase(
                                dr.GetInt64("purchase_id"),
                                dr.GetInt64("album_id"),
                                dr.GetInt64("customer_id"),
                                dr.GetString("purchased_amount"),
                                dr.GetDouble("total_paid")
                                );

                            res.Add(purchase);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error OrderList -  Message: {ex.Message} - Stack: {ex.StackTrace}");
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
