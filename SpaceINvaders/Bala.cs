using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    public class Bala : ObjetoGrafico
    {   
        public Bala(int xi, int yi, ConsoleColor color) : base(xi, yi, color)
        {
            Forma = new string[] {
                "^",
                "|"
            };
        }

    }
}
