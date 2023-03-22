namespace MusicStore
{
    public class Private : Customer
    {
        //CONSTRUCTOR
        public Private(int prid, int cuid, string fnam, string lnam, int age, string tcod, string cnam, string cadd, string pnum, string ema, bool isb) : base(cuid, cnam, cadd, pnum, ema, isb)
        {
            PrivateID = prid;
            CustomerID = cuid;
            FirstName = fnam;
            LastName = lnam;
            Age = age;
            TaxCode = tcod;
        }

        //PROPERTIES
        public int PrivateID { get; set; }
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Taxc { get; }
        public string TaxCode { get; set; }
        public string Fnam { get; }
        public string Lnam { get; }
    }
}