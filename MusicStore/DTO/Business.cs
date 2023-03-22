namespace MusicStore
{
    public class Business : Customer
    {
        //CONSTRUCTOR
        public Business(string vnum, int cuid, string cnam, string cadd, string pnum, string ema, bool isb) : base(cuid, cnam, cadd, pnum, ema, isb)
        {
            VatNumber = vnum;
        }

        //PROPERTIES
        public int BusinessID { get; set; }
        public int CustomerID { get; set; }
        public string VatNumber { get; set; }
    }
}