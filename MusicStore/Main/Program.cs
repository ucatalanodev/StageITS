using MusicStore.ConsoleRelated;

namespace MusicStore.Main;
class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new();

        Color.Magenta("==================== WELCOME TO MUSIC STORE ====================");
        menu.Start();
    }
}