using System.IO.Ports;
using System;
using System.Threading;

namespace SpaceINvaders
{
    public class ESP
    {
        private SerialPort sp;
        public bool Conectado { get; private set; }

        public ESP(string PortName)
        {
            try
            {
                sp = new SerialPort(PortName, 115200);
               
                sp.ReadTimeout = 100;
                sp.WriteTimeout = 100;

                if (!sp.IsOpen)
                {
                    sp.Open();
                    Conectado = true;
                }
            }
            catch (Exception ex)
            {
                Conectado = false;
                Console.WriteLine($"[ESP Error] No se pudo abrir {PortName}: {ex.Message}");
            }
        }

        ~ESP()
        {
            if (sp != null && sp.IsOpen)
            {
                sp.Close();
            }
        }

        private byte _leds;

        public byte leds
        {
            get => _leds;
            set
            {
                _leds = value;
                if (Conectado && sp.IsOpen)
                {
                    try
                    {
                        byte[] datOut = new byte[] { 0x2, 0x20, value, 0x3 };
                        sp.Write(datOut, 0, datOut.Length);

                        Thread.Sleep(5); // Reducido para menor latencia

                        if (sp.BytesToRead >= 3)
                        {
                            byte[] datIn = new byte[3];
                            sp.Read(datIn, 0, datIn.Length);
                        }
                    }
                    catch (Exception) { /* Ignorar timeouts temporales */ }
                }
            }
        }

        public byte Switches
        {
            get
            {
                if (!Conectado || !sp.IsOpen) return 0;

                try
                {
                    // Limpiamos el buffer de entrada antes de pedir nuevos datos
                    sp.DiscardInBuffer();

                    byte[] datOut = new byte[] { 0x2, 0x10, 0x3 };
                    sp.Write(datOut, 0, datOut.Length);

                    Thread.Sleep(10);

                    // Leemos solo si la ESP32 devolvió datos
                    if (sp.BytesToRead >= 3)
                    {
                        byte[] datIn = new byte[3];
                        sp.Read(datIn, 0, datIn.Length);
                        return datIn[1]; // Retorna el byte del estado de los switches
                    }
                }
                catch (TimeoutException)
                {
                    // La ESP no respondió a tiempo
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ESP Error] {ex.Message}");
                }

                return 0; // Si falla, retorna 0 (ningún switch presionado)
            }
        }
    }
}