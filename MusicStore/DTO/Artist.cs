using MusicStore.ConsoleRelated;
using MusicStore.DAO;

namespace MusicStore
{
    public class Artist
    {
        #region CONSTRUCTORS
        public Artist(long arid, string anam, string aori, string web, string soc, bool isb, bool isa)
        {
            ArtistID = arid;
            ArtistName = anam;
            ArtistOrigin = aori;
            Website = web;
            Social = soc;
            IsBand = isb;
            IsActive = isa;
        }
        public Artist() { }
        #endregion


        #region PROPERTIES
        public long ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string ArtistOrigin { get; set; }
        public string? Website { get; set; }
        public string? Social { get; set; }
        public bool IsBand { get; set; }
        public bool IsActive { get; set; }
        #endregion


        #region METHODS
        public List<Artist> GetArtists()
        {
            return ArtistDAO.GetArtistList();
        }
        public long AddArtist(string anam, string aori, string web, string soc, bool isb, bool isa)
        {
            return ArtistDAO.InsertArtist(anam, aori, web, soc, isb, isa);
        }
        public bool UpdateArtist(long arid, string anam, string aori, string web, string soc, bool isb, bool isa)
        {
            return ArtistDAO.UpdateArtist(arid, anam, aori, web, soc, isb, isa);
        }
        public bool DeleteArtist(long arid)
        {
            return ArtistDAO.DeleteArtist(arid);
        }
        public string ArtistInfo()
        {
            string h = $"*** ARTIST - {ArtistID} *** \n";
            Color.Blue(h);

            return $"Artist name: {ArtistName}\n"
                + $"Country of origin: {ArtistOrigin}\n"
                + $"Website: {Website}\n"
                + $"Instagram: {Social}\n"
                + $"Is it a band?: {IsBand}\n"
                + $"Still active?: {IsActive}";
        }
        #endregion
    }
}