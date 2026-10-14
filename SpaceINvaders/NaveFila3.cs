using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    internal class NaveFila3 : Enemigo
    {
        public NaveFila3(int xi, int yi) : base(xi, yi, ConsoleColor.Blue, 3)
        {
            Forma = new string[]
            {

                " ▄█▄ ",
                "██▄██",
                " ▀ ▀ "
            };
        }
    }
}
