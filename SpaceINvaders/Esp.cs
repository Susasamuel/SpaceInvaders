using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace SpaceINvaders
{
    public class ESP
    {
        private SerialPort sp { get; set; }

        public ESP(string PortName)
        {
            sp = new SerialPort(PortName, 115200);
            sp.Open();
        }

        ~ESP()
        {
            sp.Close();
        }

        private byte _leds;

        public byte leds
        {
            get
            {
                return _leds;
            }
            set
            {
                _leds = value;
                byte[] datOut = new byte[] { 0x2, 0x20, value, 0x3 };
                sp.Write(datOut, 0, datOut.Length);
                Thread.Sleep(10);
                byte[] datIn = new byte[3];
                sp.Read(datIn, 0, datIn.Length);
            }
        }

        public byte Switches
        {
            get
            {
                byte[] datOut = new byte[] { 0x2, 0x10, 0x3 };
                sp.Write(datOut, 0, datOut.Length);
                Thread.Sleep(10);
                byte[] datIn = new byte[3];
                sp.Read(datIn, 0, datIn.Length);

                return datIn[1];
            }
        }
    }
}
