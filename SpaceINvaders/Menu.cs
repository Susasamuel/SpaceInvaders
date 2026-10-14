using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    public class Menu : ObjetoGrafico
    {
        private Juego juego { get; set; }

        public Menu (int xi, int yi, ConsoleColor color) : base(xi, yi, color)
        {
            Forma = new string[]
            {"=== SPACE INVADERS ===",
             "             ",
             "     1. JUGAR",
             "             ",
             "     2. AYUDA",
             "             ",
             "     3. SALIR " 
            };
            juego = new Juego();
        }
        public void ProcesarOpcion(ConsoleKeyInfo op)
        {
            switch (op.KeyChar)
            {
                case '1':
                    juego.Iniciar();
                    break;
                case '2':
                    MenuAyuda();
                    Console.ReadKey();
                    juego.Iniciar();
                    break;
            }
        }
        public void MenuAyuda()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==================================================================================================");
            Console.WriteLine("                                  CONTROLES FÍSICOS (ESP)");
            Console.WriteLine("==================================================================================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   DEFENSOR 1: Switches Izquierda / Derecha | Switch Disparo ");
            Console.WriteLine("   DEFENSOR 2: Switches Izquierda / Derecha | Switch Disparo ");
            Console.WriteLine("   SALIR     : Pulsador de Salida");
            Console.WriteLine("==================================================================================================");
            Console.ForegroundColor = ConsoleColor.Yellow;        
            Console.WriteLine("                                  [ TABLA DE NAVES Y PUNTAJE ]                                    ");
            Console.WriteLine("==================================================================================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("   • Fila Superior (NaveFila3) : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("3 Puntos");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("   • Fila Media    (NaveFila2) : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("2 Puntos");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("   • Fila Inferior (NaveFila1) : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1 Punto");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================================================================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  ");
            Console.WriteLine("                                 PULZA CUALQUIER TECLA PARA INICIAR                               ");
        }

    }
}
