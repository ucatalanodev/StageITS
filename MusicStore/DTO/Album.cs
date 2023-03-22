using MusicStore.ConsoleRelated;
using MusicStore.DAO;

namespace MusicStore.Entities
{
    public class Album
    {
        #region CONSTRUCTORS
        public Album(long alid, long arid, string atit, string gen, string pyea, string rlab, double pri)
        {
            AlbumID = alid;
            ArtistID = arid;
            AlbumTitle = atit;
            Genre = gen;
            PublYear = pyea;
            RecordLabel = rlab;
            Price = pri;
        }
        public Album() { }
        #endregion


        #region PROPERTIES
        public long AlbumID { get; set; }
        public long ArtistID { get; set; }
        public string AlbumTitle { get; set; }
        public string Genre { get; set; }
        public string PublYear { get; set; }
        public string RecordLabel { get; set; }
        public double Price { get; set; }
        #endregion


        #region METHODS
        public List<Album> GetAlbums()
        {
            return AlbumDAO.GetAlbumList();
        }
        public long AddAlbum(long arid, string atit, string gen, string pyea, string rlab, double pri)
        {
            return AlbumDAO.InsertAlbum(arid, atit, gen, pyea, rlab, pri);
        }
        public bool UpdateAlbum(long alid, long arid, string atit, string gen, string pyea, string rlab, double pri)
        {
            return AlbumDAO.UpdateAlbum(alid, arid, atit, gen, pyea, rlab, pri);
        }
        public bool DeleteAlbum(long alid)
        {
            return AlbumDAO.DeleteAlbum(alid);
        }
        public string AlbumInfo()
        {
            string h = $"*** ALBUM - {AlbumID} *** \n";
            Color.Blue(h);

            return $"Artist ID: {ArtistID}\n"
                + $"Album title: {AlbumTitle}\n"
                + $"Genre: {Genre}\n"
                + $"Publication year: {PublYear}\n"
                + $"Record label: {RecordLabel}\n"
                + $"Album price: {Price}";
        }
        #endregion
    }
}