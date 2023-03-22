using MusicStore.ConsoleRelated;
using MusicStore.DAO;

namespace MusicStore
{
    public class Purchase
    {
        #region CONSTRUCTORS
        public Purchase(long puid, long alid, long cuid, string pamo, double totp)
        {
            PurchaseID = puid;
            AlbumID = alid;
            CustomerID = cuid;
            PurchasedAmount = pamo;
            TotalPaid = totp;
        }
        public Purchase() { }
        #endregion


        #region PROPERTIES
        public long PurchaseID { get; set; }
        public long AlbumID { get; set; }
        public long CustomerID { get; set; }
        public string PurchasedAmount { get; set; }
        public double TotalPaid { get; set; }
        #endregion


        #region METHODS
        public List<Purchase> GetOrders()
        {
            return PurchaseDAO.GetOrderList();
        }
        public string OrderInfo()
        {
            string h = $"*** ORDER - {PurchaseID} *** \n";
            Color.Blue(h);

            return $"Album ID: {AlbumID}\n"
                + $"Customer ID: {CustomerID}\n"
                + $"Amount of article purchased: {PurchasedAmount}\n"
                + $"Total sum paid: {TotalPaid}\n";
        }
        #endregion
    }
}