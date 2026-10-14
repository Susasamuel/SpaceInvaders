using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    public class Bala : ObjetoMovil
    {
        public bool Activa { get; set; } = false;
        public Bala(int xi, int yi, ConsoleColor color) : base(xi, yi, color)
        {
            Forma = new string[] {
                "^",
                "|"
            };
        }
        public void AsignarPosicion(int Xn, int Yn)
        {
            
            this.Posicion.X = Xn;
            this.Posicion.Y = Yn;
        }

    }
}
