using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    public class Defensor:ObjetoGrafico
    {
        public Defensor(int xi, int yi, ConsoleColor color) : base(xi, yi, color)
        {
            Forma = new string[] {
                "  /\\ ",
                " /==\\",
                "|====|",
                "~~  ~~"
            };
        }
    }
}
