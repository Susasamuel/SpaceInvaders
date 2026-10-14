using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    internal class NaveFila2 : Enemigo
    {
        public NaveFila2(int xi, int yi) : base(xi, yi, ConsoleColor.Green, 2)
        {
            Forma = new string[]
            {

                "▀▄█▄▀",
                "█████",
                " ▀ ▀ "
            };
        }
    }
}