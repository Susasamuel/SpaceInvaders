using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    public class Enemigo:ObjetoMovil
    {
        public Enemigo(int xi, int yi, ConsoleColor color) : base(xi, yi, color)
        {
            Forma = new string[] {
                " \\ / ",
                "(o o)", 
                " \\_/ "
        };
        }
    }
}
