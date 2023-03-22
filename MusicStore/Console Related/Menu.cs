using MusicStore.Entities;

namespace MusicStore.ConsoleRelated
{
    public class Menu
    {
        //INSTANCES

        public Album album = new();
        public Artist artist = new();
        public Purchase purchase = new();


        //MENUS

        #region Main Menu
        public void Start()
        {
            string menu =
                  "1 - Album Data \n"
                + "2 - Artist Data\n"
                + "3 - Order Data\n"
                + "x - Quit\n";

            string cmd = "";

            while (cmd.ToLower() != "x")
            {
                Console.WriteLine("");
                Color.Magenta(" ========== MUSIC STORE - DB ==========\n");
                Color.Yellow(menu);
                Console.WriteLine("Input a command");
                cmd = Console.ReadLine().ToLower();

                switch (cmd)
                {
                    case "1":
                        MenuAlbum();
                        break;

                    case "2":
                        MenuArtist();
                        break;

                    case "3":
                        MenuOrder();
                        break;

                    case "x":
                        Color.Green("Thank you for using this program. Have a nice day.");
                        Environment.Exit(-1);
                        break;

                    default:
                        Console.WriteLine("Input is not an available option or it is not valid. Please, try again.\n");
                        Start();
                        break;
                }
            }
        }
        #endregion

        #region Submenus
        public void MenuAlbum()
        {
            string menu =
                  "1 - Album list\n"
                + "2 - Add album\n"
                + "3 - Edit album\n"
                + "4 - Delete album\n"
                + "x - Exit\n";

            string cmd = "";

            while (cmd.ToLower() != "x")
            {
                Console.WriteLine("");
                Color.Magenta(" ========== MUSIC STORE - ALBUM ==========\n");
                Color.Yellow(menu);
                Console.WriteLine("Input a command");
                cmd = Console.ReadLine().ToLower();
                Console.WriteLine("");

                switch (cmd)
                {
                    case "1":
                        Color.Magenta("=== ALBUM LIST ===\n");
                        ShowAlbumList();
                        break;

                    case "2":
                        Color.Magenta("=== ADD ALBUM ===\n");
                        AddAlbum();
                        break;

                    case "3":
                        Color.Magenta("=== EDIT ALBUM ===\n");
                        EditAlbum();
                        break;

                    case "4":
                        Color.Magenta("=== DELETE ALBUM ===\n");
                        RemoveAlbum();
                        break;

                    case "x":
                        Start();
                        break;

                    default:
                        Console.WriteLine("Input is not an available option or it is not valid. Please, try again.\n");
                        MenuAlbum();
                        continue;
                }
            }
        }
        public void MenuArtist()
        {
            string menu =
                  "1 - Artist list\n"
                + "2 - Add artist\n"
                + "3 - Edit artist\n"
                + "4 - Delete artist\n"
                + "x - Exit\n";

            string cmd = "";

            while (cmd.ToLower() != "x")
            {
                Console.WriteLine("");
                Color.Magenta(" ========== MUSIC STORE - ARTIST ==========\n");
                Color.Yellow(menu);
                Console.WriteLine("Input a command");
                cmd = Console.ReadLine().ToLower();
                Console.WriteLine("");

                switch (cmd)
                {
                    case "1":
                        Color.Magenta("=== ARTIST LIST ===\n");
                        ShowArtistList();
                        break;

                    case "2":
                        Color.Magenta("=== ADD ARTIST ===\n");
                        AddArtist();
                        break;

                    case "3":
                        Color.Magenta("=== EDIT ARTIST ===\n");
                        EditArtist();
                        break;

                    case "4":
                        Color.Magenta("=== DELETE ARTIST ===\n");
                        RemoveArtist();
                        break;

                    case "x":
                        Console.WriteLine("Thank you for using our program. Have a nice day.\n");
                        Start();
                        continue;

                    default:
                        Console.WriteLine("Input is not an available option or it is not valid. Please, try again.\n");
                        MenuArtist();
                        continue;
                }
            }
        }
        public void MenuOrder()
        {
            string menu =
                  "1 - Order list\n"
                + "x - Exit\n";

            string cmd = "";

            while (cmd.ToLower() != "x")
            {
                Console.WriteLine("");
                Color.Magenta(" ========== MUSIC STORE - ORDER ==========\n");
                Console.WriteLine(menu);
                Console.WriteLine("Input a command");
                cmd = Console.ReadLine().ToLower();
                Console.WriteLine("");

                switch (cmd)
                {
                    case "1":
                        Color.Magenta("=== ARTIST LIST ===\n");
                        ShowOrderList();
                        break;

                    case "x":
                        Console.WriteLine("Thank you for using our program. Have a nice day.\n");
                        Start();
                        continue;

                    default:
                        Console.WriteLine("Input is not an available option or it is not valid. Please, try again.\n");
                        MenuOrder();
                        continue;
                }
            }
        }
        #endregion


        //METHODS

        #region Album Methods
        public void ShowAlbumList()
        {
            foreach (var album in album.GetAlbums())
            {
                Color.Cyan(album.AlbumInfo());
                Console.WriteLine();
            }
        }
        public void AddAlbum()
        {
            Console.WriteLine("Insert artist ID: ");
            long artistid = Int64.Parse(Console.ReadLine());
            Console.WriteLine("Insert album title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Insert album genre: ");
            string genre = Console.ReadLine();
            Console.WriteLine("Insert album publication year: ");
            string publication = Console.ReadLine();
            Console.WriteLine("Insert album record label: ");
            string label = Console.ReadLine();
            Console.WriteLine("Insert album price ($): ");
            double price = Double.Parse(Console.ReadLine());

            long result = album.AddAlbum(artistid, title, genre, publication, label, price);

            if (result > 0)
            {
                Color.Green("Entry successfully registered.");
            }
            else
            {
                Color.Red("Error, please try again.");
            }
        }
        public void EditAlbum()
        {
            var albumList = this.album.GetAlbums();

            foreach (var item in albumList)
            {
                Color.Cyan(item.AlbumInfo());
                Console.WriteLine();
            }

            Console.WriteLine("Select album ID: ");
            long albumid = Int64.Parse(Console.ReadLine());

            //LINQ
            Album album = albumList.FirstOrDefault(alb => alb.AlbumID == albumid);
            Color.Cyan(album.AlbumInfo());

            Console.WriteLine($"Edit artist ID ({album.ArtistID}): ");
            long artistid = Int64.Parse(Console.ReadLine());
            Console.WriteLine($"Edit album title ({album.AlbumTitle}): ");
            string title = Console.ReadLine();
            Console.WriteLine($"Edit genre ({album.Genre}): ");
            string genre = Console.ReadLine();
            Console.WriteLine($"Edit publication year: ({album.PublYear}): ");
            string publication = Console.ReadLine();
            Console.WriteLine($"Edit record label: ({album.RecordLabel}): ");
            string label = Console.ReadLine();
            Console.WriteLine($"Edit price: ({album.Price}): ");
            double price = Double.Parse(Console.ReadLine());

            bool result = album.UpdateAlbum(albumid, artistid, title, genre, publication, label, price);

            if (result == true)
            {
                Color.Green($"Album ID: {albumid} - Update successfully executed");
            }
            else
            {
                Color.Red("Error, please try again");
            }
        }
        public void RemoveAlbum()
        {
            var albumList = album.GetAlbums();

            foreach (var item in albumList)
            {
                Color.Cyan(item.AlbumInfo());
                Console.WriteLine();
            }

            Console.WriteLine("Select album ID: ");
            long albumid = Int64.Parse(Console.ReadLine());

            bool result = album.DeleteAlbum(albumid);

            if (result == true)
            {
                Color.Green($"Album ID: {albumid} - Entry successfully deleted.");
            }
            else
            {
                Color.Red("Error, please try again");
            }
        }
        #endregion

        #region Artist Methods
        public void ShowArtistList()
        {
            foreach (var artist in artist.GetArtists())
            {
                Color.Cyan(artist.ArtistInfo());
                Console.WriteLine();
            }
        }
        public void AddArtist()
        {
            bool band = false;
            bool active = false;

            Console.WriteLine("Insert artist name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Insert country of origin: ");
            string origin = Console.ReadLine();
            Console.WriteLine("Insert artist website (if any): ");
            string website = Console.ReadLine();
            Console.WriteLine("Insert artist instagram page (if any): ");
            string social = Console.ReadLine();
            Console.WriteLine("Is the artist a band? (Y/N): ");
            string isband = Console.ReadLine();
            Console.WriteLine("Is the artist still active? (Y/N): ");
            string isactive = Console.ReadLine();

            if (isband == "Y" || isband == "y")
            {
                band = true;
            }
            else if (isband == "N" || isband == "n")
            {
                band = false;
            }

            if (isactive == "Y" || isactive == "y")
            {
                active = true;
            }
            else if (isactive == "N" || isactive == "n")
            {
                active = false;
            }

            long risultato = artist.AddArtist(name, origin, website, social, band, active);

            if (risultato > 0)
            {
                Color.Green("Entry successfully registered.");
            }
            else
            {
                Color.Red("Error, please try again.");
            }
        }
        public void EditArtist()
        {
            bool band = false;
            bool active = false;

            var artistList = this.artist.GetArtists();

            foreach (var item in artistList)
            {
                Color.Cyan(item.ArtistInfo());
                Console.WriteLine();
            }

            Console.WriteLine("Select artist ID: ");
            long artistid = Int64.Parse(Console.ReadLine());

            //LINQ
            Artist artist = artistList.Find(art => art.ArtistID == artistid);
            Color.Cyan(artist.ArtistInfo());

            Console.WriteLine("Update artist name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Update country of origin: ");
            string origin = Console.ReadLine();
            Console.WriteLine("Update artist website (if any): ");
            string website = Console.ReadLine();
            Console.WriteLine("Update artist instagram page (if any): ");
            string social = Console.ReadLine();
            Console.WriteLine("Update artist type: is this artist a band or a solo? (B/S): ");
            string isband = Console.ReadLine();
            Console.WriteLine("Update artist activity status: is this artist still active? (Y/N): ");
            string isactive = Console.ReadLine();

            if (isband.ToLower() == "b")
            {
                band = true;
            }
            else if (isband.ToLower() == "s")
            {
                band = false;
            }

            if (isactive.ToLower() == "y")
            {
                active = true;
            }
            else if (isactive.ToLower() == "n")
            {
                active = false;
            }

            bool result = artist.UpdateArtist(artistid, name, origin, website, social, band, active);

            if (result == true)
            {
                Color.Green($"Artist ID: {artistid} - Update successfully executed");
            }
            else
            {
                Color.Red("Error, please try again");
            }
        }
        public void RemoveArtist()
        {
            var artistList = artist.GetArtists();

            foreach (var item in artistList)
            {
                Color.Cyan(item.ArtistInfo());
                Console.WriteLine();
            }

            Console.WriteLine("Select artist ID: ");
            long artistid = Int64.Parse(Console.ReadLine());

            bool result = artist.DeleteArtist(artistid);

            if (result == true)
            {
                Color.Green($"Artist ID: {artistid} - Entry successfully deleted.");
            }
            else
            {
                Color.Red("Error, please try again");
            }
        }
        #endregion

        #region Purchase Methods
        public void ShowOrderList()
        {
            foreach (var purchase in purchase.GetOrders())
            {
                Color.Cyan(purchase.OrderInfo());
                Console.WriteLine();
            }
        }
        #endregion
    }
}
