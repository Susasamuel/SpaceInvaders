using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    public class Defensor:ObjetoMovil
    {
        public Bala[] balas;        
        public Defensor(int xi, int yi, ConsoleColor color) : base(xi, yi, color)
        {
            Forma = new string[] {
                "  /\\ ",
                " /==\\",
                "|====|",
                "~~  ~~"
            };

            balas = new Bala[1];            
            balas[0] = new Bala(xi, yi, ConsoleColor.Yellow);
        }
        public void Disparar()
        {
            if (balas != null && balas.Length > 0)
            {
                if (balas[0].Activa)
                {
                    //esp.leds &= (byte)~bitLedVerde;
                    //esp.leds |= bitLedRojo;
                }

                else
                {
                    balas[0].Posicion.X = Posicion.X + (getAncho() / 2);
                    balas[0].Posicion.Y = Posicion.Y - 1;
                    balas[0].Activa = true;
                    balas[0].Pintar();
                    //esp.leds &= (byte)~bitLedRojo;
                    //esp.leds |= bitLedVerde;
                }
            }
        }        
    }
}
