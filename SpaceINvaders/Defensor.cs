using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    public class Defensor:ObjetoMovil
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
        Bala[] balas =
           {
                new Bala (10, 3,ConsoleColor.Yellow)
            };
        public void Disparar()
        {
            balas[0].Posicion.X = Posicion.X + 2;
            balas[0].Posicion.Y = Posicion.Y - 2;

            balas[0].Mover(Direccion.Arriba);
            for (int i = 0; balas[0].Posicion.Y > Posicion.Ymin; i++)
            {
                balas[0].Borrar();
                balas[0].Posicion.Y -= Velocidad;
                Thread.Sleep(50);
                balas[0].Pintar();


            }
            balas[0].Borrar();
        }        
    }
}
