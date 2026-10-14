using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    public class ObjetoGrafico
    {
        protected Coordenada Posicion { get; set; }
        protected string[] Forma { get; set; }
        protected ConsoleColor Color { get; set; }
        protected Direccion direccion {  get; set; }
        public ObjetoGrafico(int Xi, int Yi, ConsoleColor Color)
        {
            Posicion = new Coordenada(Xi, Yi);
            Forma = new string[0];
            this.Color = Color;
        }
        public void Pintar()
        {
            Console.ForegroundColor = Color;
            _Pintar();
        }
        protected void _Pintar()
        {
            for (int i = 0; i < Forma.Length; i++)
            {
                Console.SetCursorPosition(Posicion.X, Posicion.Y + i);
                Console.Write(Forma[i]);
            }
        }
    }
}
