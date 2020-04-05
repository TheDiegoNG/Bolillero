using System;
using BolilleroBiblioteca;
using System.Collections.Generic;

namespace BolilleroConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Bolillero bolillero = new Bolillero();

            Console.Write("Ingrese la cantidad de bolillas que tiene el bolillero:");
            bolillero.cantBolillas = Convert.ToInt32(Console.ReadLine());

            bolillero.llenarBolillero();

            Console.Write("Ingrese la cantidad de bolillas en una Jugada");
            bolillero.lengJugada = Convert.ToInt32(Console.ReadLine());

            List<int> jugada = bolillero.sacarJugada();

            Console.WriteLine("Jugada:");

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(jugada[i]);
            }

            bolillero.regresarBolillasSacadas();

            Console.WriteLine("Bolilla:");

            Console.WriteLine(bolillero.sacarBolilla());

            bolillero.regresarBolillasSacadas();

            Console.Write("Ingrese la cantidad de veces a jugar:");
            int vecesAJugar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cantidad de veces que la jugada salió: {0}", bolillero.jugarNVeces(jugada, vecesAJugar));

            bolillero.regresarBolillasSacadas();

            for (int i = 0; i < bolillero.bolillasLista.Count; i++)
            {
                Console.WriteLine(bolillero.bolillasLista[i]);
            }

        }
    }
}
