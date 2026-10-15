using SpaceINvaders;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

public class Juego
{
    private Escenario EscenarioJuego;
    private NaveFila1[] NavesFila1;
    private NaveFila2[] NavesFila2;
    private NaveFila3[] NavesFila3;
    private Defensor[] Defensores;
    private Direccion direccionEnemigos;   
    public Juego()
    {
        EscenarioJuego = new Escenario(0, 0, ConsoleColor.White);

        NavesFila1 = new NaveFila1[] {
            new NaveFila1(10, 5), new NaveFila1(17, 5), new NaveFila1(24, 5),
            new NaveFila1(31, 5), new NaveFila1(38, 5)
        };

        NavesFila2 = new NaveFila2[] {
            new NaveFila2(10, 9), new NaveFila2(17, 9), new NaveFila2(24, 9),
            new NaveFila2(31, 9), new NaveFila2(38, 9)
        };

        NavesFila3 = new NaveFila3[] {
            new NaveFila3(10, 12), new NaveFila3(17, 12), new NaveFila3(24, 12),
            new NaveFila3(31, 12), new NaveFila3(38, 12)
        };

        Defensores = new Defensor[] {
            new Defensor(11, 22, ConsoleColor.DarkYellow),
            new Defensor(102, 22, ConsoleColor.Magenta)
        };

        direccionEnemigos = Direccion.Derecha;
    }
    public void PantallaInicio()
    {           
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(
            @"
         ██████╗ ██████╗  █████╗  ██████╗███████╗    ██╗███╗   ██╗██╗   ██╗█████╗ ██████╗ ███████╗██████╗ ███████╗
         ██╔════╝ ██╔══██╗██╔══██╗██╔════╝██╔════╝    ██║████╗  ██║██║   ██║██╔══██╗██╔══██╗██╔════╝██╔══██╗██╔════╝
         ███████╗ ██████╔╝███████║██║     █████╗      ██║██╔██╗ ██║██║   ██║███████║██║  ██║█████╗  ██████╔╝███████╗
         ╚════██║ ██╔═══╝ ██╔══██║██║     ██╔══╝      ██║██║╚██╗██║╚██╗ ██╔╝██╔══██║██║  ██║██╔══╝  ██╔══██╗╚════██║
         ██████╔╝ ██║     ██║  ██║╚██████╗███████╗    ██║██║ ╚████║ ╚████╔╝ ██║  ██║██████╔╝███████╗██║  ██║██████╔╝
         ╚═════╝  ╚═╝     ╚═╝  ╚═╝ ╚═════╝╚══════╝    ╚═╝╚═╝  ╚═══╝  ╚═══╝  ╚═╝  ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝╚═════╝ "
        );
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("         ===========================================================================================================");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("                             EDICIÓN ESPECIAL - 2 JUGADORES (ESP32)                               ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("         ===========================================================================================================");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("  ");
        Console.WriteLine("                                 PULZA CUALQUIER TECLA PARA INICIAR                               ");
        Console.ReadKey();
        Console.Clear();
    }

    private void MoverBalas()
    {
        foreach (Defensor def in Defensores)
        {
            if (def != null && def.balas != null)
            {
                foreach (Bala bala in def.balas)
                {
                    if (bala != null && bala.Activa)
                    {
                        bala.Borrar();
                        bala.Posicion.Y--;

                        if (bala.Posicion.Y <= 4)
                        {
                            bala.Activa = false; 
                        }
                        else
                        {
                            bala.Pintar();
                        }
                    }
                }
            }
        }
    }

    public void Iniciar()
    {
        EscenarioJuego.Pintar();
        PintarDefensores();

        ConsoleKey op = ConsoleKey.None;  
        do
        {
            if (Console.KeyAvailable)
            {
                op = Console.ReadKey(true).Key;
            }
            else
            {
                op = ConsoleKey.None;
            }

            if (op == ConsoleKey.E) {}

            if (op == ConsoleKey.A) { Defensores[0].Mover(Direccion.Izquierda); }
            if (op == ConsoleKey.D) { Defensores[0].Mover(Direccion.Derecha); }
            if (op == ConsoleKey.W) { Defensores[0].Disparar(); Task.Run(() => Console.Beep(1200, 25));}

            if (op == ConsoleKey.LeftArrow) { Defensores[1].Mover(Direccion.Izquierda); }
            if (op == ConsoleKey.RightArrow) { Defensores[1].Mover(Direccion.Derecha); }
            if (op == ConsoleKey.UpArrow) { Defensores[1].Disparar(); Task.Run(() => Console.Beep(1200, 25));}

            MoverBalas();
            VerificarColisiones();
            MovimientoEnemigos(); 
            
        } while (op != ConsoleKey.Escape && !Perder() && !Ganar());
        Console.Clear();
        if (Ganar())
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("¡FELICIDADES, DESTRUISTE TODAS LAS NAVES!");
        }
        else if (Perder())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("¡GAME OVER! LAS NAVES LLEGARON A LA TIERRA.");
        }
        Console.ReadKey();
    }
    
    private void PintarDefensores()
    {
        foreach (var defensor in Defensores)
        {
            defensor.Pintar();
        }
    }

    private void MovimientoEnemigos()
    {
        int bordeIzquierdo = 999;
        int bordeDerecho = 0;

        for (int i = 0; i < NavesFila1.Length; i++)
        {
            if (NavesFila1[i] != null)
            {
                bordeIzquierdo = Math.Min(bordeIzquierdo, NavesFila1[i].Posicion.X);
                bordeDerecho = Math.Max(bordeDerecho, NavesFila1[i].Posicion.X);
            }
            if (NavesFila2[i] != null)
            {
                bordeIzquierdo = Math.Min(bordeIzquierdo, NavesFila2[i].Posicion.X);
                bordeDerecho = Math.Max(bordeDerecho, NavesFila2[i].Posicion.X);
            }
            if (NavesFila3[i] != null)
            {
                bordeIzquierdo = Math.Min(bordeIzquierdo, NavesFila3[i].Posicion.X);
                bordeDerecho = Math.Max(bordeDerecho, NavesFila3[i].Posicion.X);
            }
        }

        if (bordeIzquierdo == 999) return;

        bool tocaronBorde = false;

        if (direccionEnemigos == Direccion.Derecha && bordeDerecho >= Defensores[0].Posicion.Xmax - 5)
        {
            direccionEnemigos = Direccion.Izquierda;
            tocaronBorde = true;
        }
        else if (direccionEnemigos == Direccion.Izquierda && bordeIzquierdo <= Defensores[0].Posicion.Xmin + 5)
        {
            direccionEnemigos = Direccion.Derecha;
            tocaronBorde = true;
        }

        for (int i = 0; i < NavesFila1.Length; i++)
        {
            if (tocaronBorde)
            {
                if (NavesFila1[i] != null) { NavesFila1[i].Borrar(); NavesFila1[i].Posicion.Y += 2; }
                if (NavesFila2[i] != null) { NavesFila2[i].Borrar(); NavesFila2[i].Posicion.Y += 2; }
                if (NavesFila3[i] != null) { NavesFila3[i].Borrar(); NavesFila3[i].Posicion.Y += 2; }
            }
            else
            {
                if (NavesFila1[i] != null) NavesFila1[i].Mover(direccionEnemigos);
                if (NavesFila2[i] != null) NavesFila2[i].Mover(direccionEnemigos);
                if (NavesFila3[i] != null) NavesFila3[i].Mover(direccionEnemigos);
            }
        }

        Thread.Sleep(30);

        for (int i = 0; i < NavesFila1.Length; i++)
        {
            if (NavesFila1[i] != null) NavesFila1[i].Pintar();
            if (NavesFila2[i] != null) NavesFila2[i].Pintar();
            if (NavesFila3[i] != null) NavesFila3[i].Pintar();
        }

        PintarDefensores();
    }

    private void VerificarColisiones()
    {
        foreach (var def in Defensores)
        {
            if (def == null || def.balas == null) continue;
            foreach (var bala in def.balas)
            {
                if (bala != null && bala.Activa)
                {  
                    for (int i = 0; i < NavesFila1.Length; i++)
                    {
                        if (NavesFila1[i] != null)
                        {
                            if (bala.Posicion.Y == NavesFila1[i].Posicion.Y &&
                                bala.Posicion.X >= NavesFila1[i].Posicion.X &&
                                bala.Posicion.X <= NavesFila1[i].Posicion.X + 4)
                            {
                                NavesFila1[i].Borrar(); 
                                NavesFila1[i] = null;   
                                bala.Activa = false;    
                                bala.Borrar();         
                                Task.Run(() => Console.Beep(800, 20)); 
                            }
                        }
                    }
                    for (int i = 0; i < NavesFila2.Length; i++)
                    {
                        if (NavesFila2[i] != null)
                        {
                            if (bala.Posicion.Y == NavesFila2[i].Posicion.Y &&
                                bala.Posicion.X >= NavesFila2[i].Posicion.X &&
                                bala.Posicion.X <= NavesFila2[i].Posicion.X + 4)
                            {
                                NavesFila2[i].Borrar();
                                NavesFila2[i] = null;
                                bala.Activa = false;
                                bala.Borrar();
                                Task.Run(() => Console.Beep(800, 20));
                            }
                        }
                    }
                    for (int i = 0; i < NavesFila3.Length; i++)
                    {
                        if (NavesFila3[i] != null)
                        {
                            if (bala.Posicion.Y == NavesFila3[i].Posicion.Y &&
                                bala.Posicion.X >= NavesFila3[i].Posicion.X &&
                                bala.Posicion.X <= NavesFila3[i].Posicion.X + 4)
                            {
                                NavesFila3[i].Borrar();
                                NavesFila3[i] = null;
                                bala.Activa = false;
                                bala.Borrar();
                                Task.Run(() => Console.Beep(800, 20));
                            }
                        }
                    }
                }
            }
        }
    }
    private bool Perder()
    {
        foreach (var nave in NavesFila1)
        {
            if (nave != null && nave.Posicion.Y >= Defensores[0].Posicion.Y)
            {
                return true;
            }
        }
        foreach (var nave in NavesFila2)
        {
            if (nave != null && nave.Posicion.Y >= Defensores[0].Posicion.Y)
            {
                return true;
            }
        }
        foreach (var nave in NavesFila3)
        {
            if (nave != null && nave.Posicion.Y >= Defensores[0].Posicion.Y)
            {
                return true;
            }
        }
        return false;
    }
    private bool Ganar()
    {
        foreach (var nave in NavesFila1)
        {
            if (nave != null)
            {
                return false; 
            }
        }
        foreach (var nave in NavesFila2)
        {
            if (nave != null)
            {
                return false;
            }
        }
        foreach (var nave in NavesFila3)
        {
            if (nave != null)
            {
                return false;
            }
        }
        return true;
    }


}