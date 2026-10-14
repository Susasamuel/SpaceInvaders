using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    public class Enemigo : ObjetoMovil
    {
        public int Puntos { get; set; }
        public bool Vivo { get; set; } = true;
        public Enemigo(int xi, int yi, ConsoleColor color, int Puntos) : base(xi, yi, color)
        {
            this.Puntos = Puntos;
        }
        protected int getAlto()
        {
            return Forma.Length;
        }
        protected int getAncho() { return Forma[0].Length; }
        public bool Morir(int X, int Y)
        {
            if (Vivo && X >= Posicion.X && X < Posicion.X + getAncho() && Y >= Posicion.Y && Y < Posicion.Y + getAlto())
            {
                Borrar();
                Vivo = false;
                return true;
            }
            return false;
        }

    }
}            