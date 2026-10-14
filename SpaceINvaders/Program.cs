namespace SpaceINvaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;            
            Menu menu = new Menu(45, 10, ConsoleColor.White);
            Juego juego = new Juego();
            juego.PantallaInicio();
            menu.Pintar();
            ConsoleKeyInfo op = Console.ReadKey();
            menu.ProcesarOpcion(op);
            
        }
    }
}
