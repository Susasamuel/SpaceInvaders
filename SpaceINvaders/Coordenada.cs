using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceINvaders
{
    public class Coordenada
    {
        public readonly int Xmin = 1;
        public readonly int Ymin = 4;
        public readonly int Xmax = 117;
        public readonly int Ymax = 26;

        private int _X { get; set; }
        private int _Y { get; set; }


        public int X
        {
            get => _X;
            set
            {
                if (value < Xmin) return;
                if (value > Xmax) return;
                _X = value;
            }
        }
        public int Y
        {
            get => _Y;
            set
            {
                if (value < Ymin) return;
                if (value > Ymax) return;
                _Y = value;
            }
        }
        public Coordenada(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
