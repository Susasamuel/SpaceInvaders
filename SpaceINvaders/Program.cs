namespace SpaceINvaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Escenario EscenarioJuego = new Escenario (0, 0, ConsoleColor.White);
            NaveFila1 nave1 = new NaveFila1(10,5);
            NaveFila2 nave2 = new NaveFila2(10,9);
            NaveFila3 nave3 = new NaveFila3(10,12);

            Defensor[] Defensores =
            {
                new Defensor(11, 22, ConsoleColor.DarkYellow),
                new Defensor(102, 22, ConsoleColor.Magenta)
            };

            void PintarDefensores()
            {
                foreach (var Defensor in Defensores)
                {
                    Defensor.Pintar();
                }
            }

            EscenarioJuego.Pintar();    
            nave1.Pintar();
            nave2.Pintar();
            nave3.Pintar();
            PintarDefensores();
            Console.ReadKey();

            ConsoleKey op = ConsoleKey.None;
            do
            {
                if (Console.KeyAvailable)
                {
                    op = Console.ReadKey(true).Key;
                }
                else { op = ConsoleKey.None; }

                if (op == ConsoleKey.A) 
                {
                    Defensores[0].Mover(Direccion.Izquierda);
                }
                if (op == ConsoleKey.D)
                {
                    Defensores[0].Mover(Direccion.Derecha);
                }
                if (op == ConsoleKey.W)
                {
                    //DISPARA
                    Task.Run(() => Console.Beep(1200, 25)); 
                }

                if (op == ConsoleKey.LeftArrow)
                {
                    Defensores[1].Mover(Direccion.Izquierda);
                }
                if (op == ConsoleKey.RightArrow)
                {
                    Defensores[1].Mover(Direccion.Derecha);
                }
                if (op == ConsoleKey.UpArrow)
                {
                    //DISPARA
                    Task.Run(() => Console.Beep(1200, 25));
                }
            }
            while (op != ConsoleKey.Escape);
        }
    }
}
