namespace MusicStore
{
    public class Customer
    {
        //CONSTRUCTOR
        public Customer(int cuid, string cnam, string cadd, string pnum, string ema, bool isb)
        {
            CustomerID = cuid;
            CustomerName = cnam;
            CustomerAddress = cadd;
            PhoneNumber = pnum;
            Email = ema;
            IsBusiness = isb;
        }

        //PROPERTIES
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsBusiness { get; set; }
    }
}