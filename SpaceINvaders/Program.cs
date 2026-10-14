namespace SpaceINvaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Menu menu = new Menu(45, 10, ConsoleColor.White);
            menu.Pintar();
            ConsoleKeyInfo op = Console.ReadKey();
            menu.ProcesarOpcion(op);
            
        }
    }
}
