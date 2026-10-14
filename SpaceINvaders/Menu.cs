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
                    break;
            }
        }
    }
}
