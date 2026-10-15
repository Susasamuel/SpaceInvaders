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
        public int getAlto() { return Forma.Length; }
        protected int Velocidad = 1;
        public void Borrar()
        {
            Console.ForegroundColor = Console.BackgroundColor;
            _Pintar();
        }
        public void Mover(Direccion direccion, ESP esp, byte bitLedVerde, byte bitLedAmarillo)
        {
                    
            if (direccion == Direccion.Derecha)
            {
                Borrar();
                if (Posicion.X + getAncho() < Posicion.Xmax)
                {
                    Posicion.X += Velocidad;
                    esp.leds &= (byte)~bitLedVerde;
                    esp.leds |= bitLedAmarillo;
                }                
            }
            else if (direccion == Direccion.Izquierda)
            {
                Borrar();
                if (Posicion.X > Posicion.Xmin)
                {
                    Posicion.X -= Velocidad;
                    esp.leds &= (byte)~bitLedAmarillo;
                    esp.leds |= bitLedVerde;
                }               
            }                             
            Pintar();
        }        
    }
}
