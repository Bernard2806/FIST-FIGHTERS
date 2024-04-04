using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases___3_4
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            //Creacion de los Personajes
            Personaje Enemigo = new Personaje("Enemigo");
            Personaje Jugador = new Personaje("Jugador");
            do
            {
                if (Menu())
                {
                    CrearPersonajeRandom(Jugador);
                    CrearPersonajeRandom(Enemigo);
                }
                else
                {
                    CrearPersonaje(Jugador);
                    CrearPersonaje(Enemigo);
                }

                ResultadoBatalla(Jugador, Enemigo);
                VamoAJugar(Jugador, Enemigo);
                Console.ReadKey();
            } while (true);
        }
        static void CrearPersonaje(Personaje personaje)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el Nombre del " + personaje.Nombre + ":");
            personaje.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Color (hexadecimal) de "+ personaje.Nombre + ":");
            personaje.Color = Console.ReadLine();
            Console.WriteLine("Ingrese la Vida de " + personaje.Nombre + ":");
            personaje.Vida = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Defensa de " + personaje.Nombre + ":");
            personaje.Defensa = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Fuerza de " + personaje.Nombre + ":");
            personaje.Fuerza = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Mana de " + personaje.Nombre + ":");
            personaje.Mana = int.Parse(Console.ReadLine());
        }
        static void VamoAJugar(Personaje Jugador, Personaje Enemigo)
        {
            while (Jugador.Vida > 0 && Enemigo.Vida > 0){
                int x = MenuAcciones();
                Acciones(Jugador, Enemigo, x);
                Acciones(Enemigo, Jugador, 5);
                ResultadoBatalla(Jugador, Enemigo);
            }
            if (Jugador.Vida > 0)
            {
                Console.WriteLine("El Jugador Gano");
            }
            else
            {
                Console.WriteLine("El Enemigo Gano");
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Desea volver a Jugar:");
            Console.WriteLine("[1] - Si");
            Console.WriteLine("[2] - No");
            int zzz = int.Parse(Console.ReadLine());
            if (zzz != 1) Environment.Exit(0);
        }
        static void ResultadoBatalla(Personaje p1, Personaje p2)
        {
            Console.Clear();
            Console.WriteLine("Estadisticas del " + p1.Nombre);
            EstadisticasPersonaje(p1);
            Console.WriteLine();
            Console.WriteLine("Estadisticas del " + p2.Nombre);
            EstadisticasPersonaje(p2);
            Console.ReadKey();
            Console.Clear();
        }
        static void Acciones(Personaje p1, Personaje p2, int sel)
        {
            Console.Clear();
            switch (sel)
            {
                case 0:
                    Console.WriteLine("[" + p1.Nombre + "]: Se ha rendido");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case 1:
                    if (p1.Atacar(p2))
                    {
                        Console.WriteLine("[" + p1.Nombre + "]: " + "Ataque Efectivo");
                    }
                    else
                    {
                        Console.WriteLine("[" + p1.Nombre + "]: " + "Ataque Inefectivo");
                    }
                    break;
                case 2:
                    Console.WriteLine("El " + p1.Nombre + " a Cambiado de Color");
                    p1.CambiarColor(GenerateRandomHexColor());
                    break;
                case 3:
                    Console.WriteLine("["+p1.Nombre+"]: Recargo Mana");
                    p1.RecargarMana();
                    break;
                case 4:
                    Console.WriteLine("[" + p1.Nombre + "]: Incremento la Defensa");
                    p1.IncrementarDefensayFuerza();
                    break;
                default:
                    Acciones(p1, p2, EstRandom(1, 4));
                    break;
            }
            Console.ReadKey();
        }
        static int MenuAcciones()
        {
            Console.Clear();
            Console.WriteLine("Acciones:");
            Console.WriteLine("[0] - Irse de las mil Batallas");
            Console.WriteLine("[1] - Atacar");
            Console.WriteLine("[2] - Cambiar Color");
            Console.WriteLine("[3] - Recargar Mana");
            Console.WriteLine("[4] - Incrementar Defensa/Fuerza (-70 de Mana)");
            return int.Parse(Console.ReadLine());
        }
        static void CrearPersonajeRandom(Personaje personaje)
        {
            personaje.Color = GenerateRandomHexColor();
            personaje.Vida = 100;
            personaje.Mana = 100;
            personaje.Defensa = EstRandom();
            personaje.Fuerza = EstRandom();
        }
        static void EstadisticasPersonaje(Personaje personaje)
        {
            Console.WriteLine("Vida: " + personaje.Vida);
            Console.WriteLine("Mana: " + personaje.Mana);
            Console.WriteLine("Defensa: " + personaje.Defensa);
            Console.WriteLine("Fuerza: " + personaje.Fuerza);
            Console.WriteLine("Color: " + personaje.Color);
        }

        static bool Menu()
        {
            Console.Clear();
            string ASCIIMenu = @"
 _______ _________ _______ _________   _______ _________ _______          _________ _______  _______  _______ 
(  ____ \\__   __/(  ____ \\__   __/  (  ____ \\__   __/(  ____ \|\     /|\__   __/(  ____ \(  ____ )(  ____ \
| (    \/   ) (   | (    \/   ) (     | (    \/   ) (   | (    \/| )   ( |   ) (   | (    \/| (    )|| (    \/
| (__       | |   | (_____    | |     | (__       | |   | |      | (___) |   | |   | (__    | (____)|| (_____ 
|  __)      | |   (_____  )   | |     |  __)      | |   | | ____ |  ___  |   | |   |  __)   |     __)(_____  )
| (         | |         ) |   | |     | (         | |   | | \_  )| (   ) |   | |   | (      | (\ (         ) |
| )      ___) (___/\____) |   | |     | )      ___) (___| (___) || )   ( |   | |   | (____/\| ) \ \__/\____) |
|/       \_______/\_______)   )_(     |/       \_______/(_______)|/     \|   )_(   (_______/|/   \__/\_______)
                                                                                                              
";
            Console.WriteLine(ASCIIMenu);
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Deseas Generar las Estadisticas Aleatoriamente");
            Console.WriteLine("[1] - Si");
            Console.WriteLine("[2] - No");
            bool Condicion = 1 == int.Parse(Console.ReadLine());
            return Condicion;
        }
        // Metodos de Generacion Random
        static Random random = new Random(); // Esto desbugea
        static int EstRandom(int min = 1, int max = 100)
        {
            return random.Next(min, max);
        }
        static string GenerateRandomHexColor(){
            byte[] colorBytes = new byte[3];
            random.NextBytes(colorBytes);
            return $"#{colorBytes[0]:X2}{colorBytes[1]:X2}{colorBytes[2]:X2}";
        }

    }
}
