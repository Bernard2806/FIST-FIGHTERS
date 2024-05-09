using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Clases___3_4
{
    internal class Program
    {
        private static string[] MenuAcciones = new string[] {
            "Rendirse",
            "Atacar",
            "Cambiar Color",
            "Recargar Mana",
            "Incrementar Defensa/Fuerza (-70 de Mana)",
            "Invetario",
            "Debug Mode"
        };

        private static string[] ConditionalMenu = new string[] {
            "Si",
            "No",
        };

        private static string[] MenuDebugText = new string[] {
            "Cambiar Color",
            "Recibir Daño",
            "Generar Pociones"
        };

        private static string[] PotionCreateMenu = new string[] {
            "Vida",
            "Mana"
        };
        static void Main(string[] args)
        {

            //Creacion de los Personajes
            Personaje Enemigo = new Personaje("Enemigo");
            Personaje Jugador = new Personaje("Jugador");

            do
            {
                bool Option = StartMenu();

                CrearPersonaje(Jugador, Option);
                CrearPersonaje(Enemigo, Option);

                ResultadoBatalla(Jugador, Enemigo);
                VamoAJugar(Jugador, Enemigo);

                Console.ReadKey();
            } while (true);
        }
        static void CrearPersonaje(Personaje personaje, bool Selection)
        {
            if (Selection)
            {
                personaje.Color = GenerateRandomHexColor();
                personaje.Vida = 100;
                personaje.Mana = 100;
                personaje.Defensa = GenerateEstRandom();
                personaje.Fuerza = GenerateEstRandom();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Ingrese el Nombre del {personaje.Nombre}:");
                personaje.Nombre = Console.ReadLine();
                Console.WriteLine($"Ingrese el Color (hexadecimal) de {personaje.Nombre}:");
                personaje.Color = Console.ReadLine();
                Console.WriteLine($"Ingrese la Vida de {personaje.Nombre}:");
                personaje.Vida = int.Parse(Console.ReadLine());
                Console.WriteLine($"Ingrese la Defensa de {personaje.Nombre}:");
                personaje.Defensa = int.Parse(Console.ReadLine());
                Console.WriteLine($"Ingrese la Fuerza de {personaje.Nombre}:");
                personaje.Fuerza = int.Parse(Console.ReadLine());
                Console.WriteLine($"Ingrese el Mana de {personaje.Nombre}:");
                personaje.Mana = int.Parse(Console.ReadLine());
            }
            personaje.inventario = null;
            personaje.ManaMax = personaje.Mana;
            personaje.VidaMax = personaje.Vida;
        }
        static void VamoAJugar(Personaje Jugador, Personaje Enemigo)
        {
            while (Jugador.Vida > 0 && Enemigo.Vida > 0)
            {
                Acciones(Jugador, Enemigo, MostrarMenu(MenuAcciones, "Seleccione la Accion a realizar:"));
                Acciones(Enemigo, Jugador);
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
            int SeguirJugando = MostrarMenu(ConditionalMenu, "¿Desea volver a jugar?");
            if (SeguirJugando != 0) Environment.Exit(0);
        }
        static void ResultadoBatalla(Personaje p1, Personaje p2)
        {
            Console.Clear();
            EstadisticasPersonaje(p1);
            Console.WriteLine();
            EstadisticasPersonaje(p2);
            Console.ReadKey();
            Console.Clear();
        }
        static void Acciones(Personaje p1, Personaje p2, int sel = 23)
        {
            Console.Clear();
            switch (sel)
            {
                case 0:
                    Console.WriteLine($"[{p1.Nombre}]: Se ha rendido.");
                    p1.Vida = 0;
                    Console.ReadKey();
                    break;
                case 1:
                    if (p1.Atacar(p2))
                    {
                        Console.WriteLine($"[{p1.Nombre}]: Su Ataque Fue Efectivo.");
                    }
                    else
                    {
                        Console.WriteLine($"[{p1.Nombre}]: Su Ataque Fue Inefectivo.");
                    }
                    break;
                case 2:
                    Console.WriteLine($"[{p1.Nombre}]: Cambio de Color ({p1.Color}).");
                    p1.CambiarColor(GenerateRandomHexColor());
                    break;
                case 3:
                    Console.WriteLine($"[{p1.Nombre}]: Recargo Mana (+10).");
                    p1.RecargarMana();
                    break;
                case 4:
                    Console.WriteLine($"[{p1.Nombre}]: Incremento su Defensa a {p1.Defensa} y Fuerza a {p1.Fuerza}.");
                    p1.AumentarEstadisticas();
                    break;
                case 5:
                    if (p1.inventario.items != null)
                    {
                        int ObjID = MostrarMenu(MostrarInventario(p1.inventario, true), "Seleccione el Objeto a Utilizar:");
                    }
                    else
                    {
                        Console.WriteLine($"[{p1.Nombre}]: No tiene niguna poción.");
                    }
                    break;
                case 6:
                    MenuDebug(p1, p2);
                    break;
                default:
                    Acciones(p1, p2, GenerateEstRandom(1, 5));
                    break;
            }
            Console.ReadKey();
        }
        static void EstadisticasPersonaje(Personaje personaje)
        {
            Console.WriteLine($"Estadisticas del {personaje.Nombre}");
            Console.WriteLine($"Vida: {personaje.Vida.ToString()} / {personaje.VidaMax.ToString()}");
            Console.WriteLine($"Mana: {personaje.Mana.ToString()} / {personaje.ManaMax.ToString()}");
            Console.WriteLine($"Defensa: {personaje.Defensa.ToString()}");
            Console.WriteLine($"Fuerza: {personaje.Fuerza.ToString()}");
            Console.WriteLine($"Color: {personaje.Color}");
            if (personaje.inventario != null) {
                Console.Clear();
                MostrarInventario(personaje.inventario);
                Console.ReadKey();
            }
        }
        static void MenuDebug(Personaje personaje, Personaje enemigo)
        {
            int Selecion = MostrarMenu(MenuDebugText, "//// Menu Debug ////");
            Console.Clear();
            switch (Selecion)
            {
                case 0:
                    Console.WriteLine("Ingrese el Color del Personaje:");
                    string Color = Console.ReadLine();
                    personaje.CambiarColor(Color);
                    personaje.Mana++;
                    break;
                case 1:
                    Console.WriteLine("Ingrese el daño a recibir");
                    int Daño = int.Parse(Console.ReadLine());
                    personaje.RecibirDaño(Daño);
                    break;
                case 2:
                    bool TipoP = 0 == MostrarMenu(PotionCreateMenu, "Seleccione el tipo de Poción:");
                    bool Player = 0 == MostrarMenu(new string[] {personaje.Nombre, enemigo.Nombre}, "Seleccione el Personaje el cual va a recibir la Poción:");
                    
                    if (Player)
                    {
                        personaje.inventario.AgregarItem(CrearPocion(TipoP));
                        Console.WriteLine($"[{personaje.Nombre}]: Recibio una Poción.");
                    }
                    else
                    {
                        enemigo.inventario.AgregarItem(CrearPocion(TipoP));
                        Console.WriteLine($"[{enemigo.Nombre}]: Recibio una Poción.");
                    }
                    break;
                default:
                    break;
            }
            return;
        }
        static bool StartMenu()
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
            bool Condicion = (0 == MostrarMenu(ConditionalMenu, "Deseas Generar las Estadisticas Aleatoriamente"));
            return Condicion;
        }
        // Metodos de Generacion Random
        static Random random = new Random();
        static int GenerateEstRandom(int min = 1, int max = 100)
        {
            max++;
            return random.Next(min, max);
        }
        static string GenerateRandomHexColor()
        {
            byte[] colorBytes = new byte[3];
            random.NextBytes(colorBytes);
            return $"#{colorBytes[0]:X2}{colorBytes[1]:X2}{colorBytes[2]:X2}";
        }

        static PocionBase CrearPocion(bool tipo)
        {
            Console.WriteLine("Ingrese el Minimo a curar de la pocion:");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Maximo a curar de la pocion:");
            int max = int.Parse(Console.ReadLine());

            if (tipo)
            {
                PocionVida pocionVida = new PocionVida(min, max);
                return pocionVida;
            }
            else
            {
                PocionMana pocionMana = new PocionMana(min, max);
                return pocionMana;
            }
        }

        static string[] MostrarInventario(Inventario inv, bool Devolver = false) {
            if (Devolver)
            {
                int x = inv.items.Count;
                string[] DesItem = new string[x];
                x = 0;
                foreach (Item item in inv.items)
                {
                    DesItem[x] = item.Descripcion;
                    x++;
                }
                return DesItem;
            }
            else {
                Console.WriteLine("Inventario:");
                foreach (Item item in inv.items)
                {
                    Console.WriteLine($"> {item.Descripcion}");
                }
            }
            return null;
            
        }

        // Funcion de otro repositiorio de mi persona

        static int MostrarMenu(string[] Opciones, string InitalText = "Seleccione una opción del menu:")
        {
            bool loop = true;
            int counter = 0;
            ConsoleKeyInfo Tecla;

            Console.CursorVisible = false; // Con esto hacemos que el cursor no se muestre en consola

            while (loop)
            {
                Console.Clear();
                Console.WriteLine(InitalText + System.Environment.NewLine);
                string SeleccionActual = string.Empty;
                int Destacado = 0;

                Array.ForEach(Opciones, element =>
                {
                    if (Destacado == counter)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(" > " + element + " < ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        SeleccionActual = element;
                    }
                    else
                    {
                        Console.WriteLine(element);
                    }
                    Destacado++;
                });

                Tecla = Console.ReadKey(true);
                if (Tecla.Key == ConsoleKey.Enter)
                {
                    loop = false;
                    break;
                }
                switch (Tecla.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (counter < Opciones.Length - 1) counter++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (counter > 0) counter--;
                        break;
                    default:
                        break;
                }
            }
            return counter;
        }

    }
}
