namespace MusicStore
{
    public class Band : Artist
    {
        //CONSTRUCTOR
        public Band(int baid, int arid, int mem, int fyea, string anam, string aori, string web, string soc, bool isb, bool isa) : base(arid, anam, aori, web, soc, isb, isa)
        {
            BandID = baid;
            ArtistID = arid;
            Members = mem;
            FormYear = fyea;
        }

        //PROPERTIES
        public int BandID { get; set; }
        public int ArtistID { get; set; }
        public int Members { get; set; }
        public int FormYear { get; set; }
    }
}