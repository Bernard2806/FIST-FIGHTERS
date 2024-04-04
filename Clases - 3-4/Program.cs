using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases___3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Personaje Jugador = new Personaje();
            Console.WriteLine("Ingrese la Altura de su Personaje:");
            Jugador.Altura = int.Parse(Console.ReadLine());
            Jugador.Color = "#FFFFFF";
            Jugador.Vida = 100;
            Jugador.Mana = 100;
            Jugador.Defensa = EstRandom();
            Jugador.Fuerza = EstRandom();
            Console.Clear();
            Console.WriteLine("Estadisticas del Jugador:");
            Console.WriteLine("Altura: " + Jugador.Altura);
            Console.WriteLine("Vida: " + Jugador.Vida);
            Console.WriteLine("Mana: " + Jugador.Mana);
            Console.WriteLine("Defensa: " + Jugador.Defensa);
            Console.WriteLine("Fuerz: " + Jugador.Fuerza);
            Console.ReadLine();
        }

        static int EstRandom() {
            int RandomNumber = new Random().Next(1, 100);
            return RandomNumber;
        }

    }
}
