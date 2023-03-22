namespace MusicStore
{
    public class Song
    {
        public Song(int soid, int alid, string snam, string sdur)
        {
            SongID = soid;
            AlbumID = alid;
            SongName = snam;
            SongDuration = sdur;
        }

        //PROPERTIES
        public int SongID { get; set; }
        public int AlbumID { get; set; }
        public string SongName { get; set; }
        public string SongDuration { get; set; }
    }
}