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
        public void Borrar()
        {
            Console.ForegroundColor = Console.BackgroundColor;
            _Pintar();
        }
        public void Mover(Direccion direccion)
        {
            Borrar();
            switch (direccion)
            {
                case Direccion.Arriba: Posicion.Y--; break;
                case Direccion.Abajo: Posicion.Y++; break;
                case Direccion.Derecha: Posicion.X++; break;
                case Direccion.Izquierda: Posicion.X--; break;
            }
            Pintar();
        }
    }
}
