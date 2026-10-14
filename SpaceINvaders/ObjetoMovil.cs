using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    public class ObjetoMovil:ObjetoGrafico
    {
        public ObjetoMovil(int Xi, int Yi, ConsoleColor Color) : base(Xi, Yi, Color)
        {
        }
        public int getAncho() { return Forma[0].Length; }
        private int Velocidad = 1;
        public void Borrar()
        {
            Console.ForegroundColor = Console.BackgroundColor;
            _Pintar();
        }
        public void Mover(Direccion direccion)
        {
            Borrar();         
            if (direccion == Direccion.Derecha)
            {
                if (Posicion.X + getAncho() < Posicion.Xmax)
                {
                    Posicion.X += Velocidad;
                }
                else
                {
                    //LED
                }
            }
            else if (direccion == Direccion.Izquierda)
            {
                if (Posicion.X > Posicion.Xmin)
                {
                    Posicion.X -= Velocidad;
                }
                else
                {
                    //LED
                }
            }                             
            Pintar();
        }        
    }
}
