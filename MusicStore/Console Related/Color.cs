namespace MusicStore.ConsoleRelated
{
    public class Color
    {
        public static void Red(string menu)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(menu);
            Console.ResetColor();
        }

        public static void Green(string menu)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(menu);
            Console.ResetColor();
        }

        public static void Blue(string menu)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(menu);
            Console.ResetColor();
        }

        public static void Cyan(string menu)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(menu);
            Console.ResetColor();
        }

        public static void Magenta(string menu)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu);
            Console.ResetColor();
        }

        public static void Yellow(string menu)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(menu);
            Console.ResetColor();
        }
    }
}