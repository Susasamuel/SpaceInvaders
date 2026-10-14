using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    internal class NaveFila1 : Enemigo
    {
        public NaveFila1(int xi, int yi) : base(xi, yi, ConsoleColor.Yellow, 1) 
        {
            Forma = new string[] 
            {

                " ▄█▄ ",
                "█████",
                "▀▄ ▄▀"
            };
        }
    }
}
