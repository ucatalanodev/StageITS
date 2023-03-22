namespace MusicStore
{
    public class Solo : Artist
    {
        //CONSTRUCTOR
        public Solo(int soid, int arid, string gen, string anam, string aori, string web, string soc, bool isb, bool isa) : base(arid, anam, aori, web, soc, isb, isa)
        {
            SoloID = soid;
            ArtistID = arid;
            Gender = gen;
        }

        //PROPERTIES
        public int SoloID { get; set; }
        public int ArtistID { get; set; }
        public string Gender { get; set; }
    }
}