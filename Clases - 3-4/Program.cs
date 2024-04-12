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
        static PocionBase pocion = null;
        static void Main(string[] args)
        {

            //Creacion de los Personajes
            Personaje Enemigo = new Personaje("Enemigo");
            Personaje Jugador = new Personaje("Jugador");

            do
            {
                bool Option = Menu();
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
            else {
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
            personaje.ManaMax = personaje.Mana;
            personaje.VidaMax = personaje.Vida;
        }
        static void VamoAJugar(Personaje Jugador, Personaje Enemigo)
        {
            while (Jugador.Vida > 0 && Enemigo.Vida > 0){
                int x = MenuAcciones();
                Acciones(Jugador, Enemigo, x);
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
            Console.WriteLine("Desea volver a Jugar:");
            Console.WriteLine("[1] - Si");
            Console.WriteLine("[2] - No");
            int SeguirJugando = int.Parse(Console.ReadLine());
            if (SeguirJugando != 1) Environment.Exit(0);
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
                    if (pocion != null)
                    {
                        Console.WriteLine($"[{p1.Nombre}]: Utilizo una Pocion");
                        if (pocion.Usar(p1))
                        {
                            pocion = null; // Se borra la pocion
                        }
                        else
                        {
                            Console.WriteLine($"[{p1.Nombre}]: La Pocion no fue Utilizada el Mana o la Vida ya estan al maximo");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No tienes ninguna Pocion");
                    }
                    break;
                case 6:
                    MenuDebug(p1);
                    break;
                default:
                    Acciones(p1, p2, GenerateEstRandom(1, 4));
                    break;
            }
            Console.ReadKey();
        }
        static int MenuAcciones()
        {
            Console.Clear();
            Console.WriteLine("Acciones:");
            Console.WriteLine("[0] - Rendirse");
            Console.WriteLine("[1] - Atacar");
            Console.WriteLine("[2] - Cambiar Color");
            Console.WriteLine("[3] - Recargar Mana");
            Console.WriteLine("[4] - Incrementar Defensa/Fuerza (-70 de Mana)");
            Console.WriteLine("[5] - Usar una Pocion");
            Console.WriteLine("[6] - Debug Mode");
            return int.Parse(Console.ReadLine());
        }
        static void EstadisticasPersonaje(Personaje personaje)
        {
            Console.WriteLine($"Estadisticas del {personaje.Nombre}");
            Console.WriteLine($"Vida: {personaje.Vida.ToString()} / {personaje.VidaMax.ToString()}");
            Console.WriteLine($"Mana: {personaje.Mana.ToString()} / {personaje.ManaMax.ToString()}");
            Console.WriteLine($"Defensa: {personaje.Defensa.ToString()}");
            Console.WriteLine($"Fuerza: {personaje.Fuerza.ToString()}");
            Console.WriteLine($"Color: {personaje.Color}");
        }
        static void MenuDebug(Personaje personaje) {
            Console.Clear();
            Console.WriteLine("//// Menu Debug ////");
            Console.WriteLine("[1] - Cambiar Color");
            Console.WriteLine("[2] - Recibir Daño");
            Console.WriteLine("[3] - Generar Pociones");
            int Selecion = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (Selecion) {
                case 1:
                    Console.WriteLine("Ingrese el Color del Personaje:");
                    string Color = Console.ReadLine();
                    personaje.CambiarColor(Color);
                    personaje.Mana++;
                    break;
                case 2:
                    Console.WriteLine("Ingrese el daño a recibir");
                    int Daño = int.Parse(Console.ReadLine());
                    personaje.RecibirDaño(Daño);
                    break;
                case 3:
                    Console.WriteLine("Ingrese el tipo de la Pocion (Vida / Mana)");
                    bool TipoP = Console.ReadLine().ToLower() == "vida";
                    pocion = CrearPocion(TipoP);
                    break;
                default:
                    break;
            }
            return;
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
        static Random random = new Random();
        static int GenerateEstRandom(int min = 1, int max = 100)
        {
            max++;
            return random.Next(min, max);
        }
        static string GenerateRandomHexColor(){
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
                PocionVida pocionVida = new PocionVida (min, max);
                return pocionVida;
            }
            else
            {
                PocionMana pocionMana = new PocionMana (min, max);
                return pocionMana;
            }
        }


    }
}
