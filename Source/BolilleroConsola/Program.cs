using System;
using BolilleroBiblioteca;
using System.Collections.Generic;

namespace BolilleroConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulacion simulacion = new Simulacion();
            Console.Write("Ingrese la cantidad de bolillas que tiene el bolillero:");
            int cantBolillas = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese la cantidad de bolillas en una Jugada: ");
            int lengJugada = Convert.ToInt32(Console.ReadLine());

            Bolillero bolillero = new Bolillero(cantBolillas, lengJugada);
          
            bolillero.llenarBolillero();

            List<int> jugada = bolillero.sacarJugada();

            Console.WriteLine("Jugada:");

            for (int i = 0; i < lengJugada; i++)
            {
                Console.WriteLine(jugada[i]);
            }

            bolillero.regresarBolillasSacadas();

            Console.WriteLine("Bolilla:");

            Console.WriteLine(bolillero.sacarBolilla());

            bolillero.regresarBolillasSacadas();

            //Console.Write("Ingrese la cantidad de veces a jugar:");
            //int vecesAJugar = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Cantidad de veces que la jugada salió: {0}", bolillero.jugarNVeces(jugada, vecesAJugar));

            //bolillero.regresarBolillasSacadas();

            //for (int i = 0; i < bolillero.bolillasLista.Count; i++)
            //{
            //    Console.WriteLine(bolillero.bolillasLista[i]);
            //}
            List<int> jugada2 = new List<int>();

            Console.Write("Ingrese su jugada:");
            for (int i = 0; i < lengJugada; i++)
            {
                jugada2.Add(Convert.ToInt32(Console.ReadLine()));
            }

            Console.Write("Ingrese la cantidad de simulaciones: ");
            int cantSimulaciones = Convert.ToInt32(Console.ReadLine());

            simulacion.ResetearCronometro();
            int resultSinHilos = simulacion.simularSinHilos(bolillero, jugada2, cantSimulaciones);
            var duracionSinHilos = simulacion.Duracion;

            Console.Write("Ingrese la cantidad de hilos: ");
            int cantHilos = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese la cantidad de simulaciones: ");
            int cantSimulacionesHilos = Convert.ToInt32(Console.ReadLine());

            simulacion.ResetearCronometro();
            int resultConHilos = simulacion.simularConHilos(bolillero, jugada2, cantSimulacionesHilos, cantHilos);
            var duracionConHilos = simulacion.Duracion;

            Console.WriteLine($"La simulación sin hilo lo obtuvo en {duracionSinHilos}, y acertó {resultSinHilos}");
            Console.WriteLine($"La simulación con hilo lo obtuvo en {duracionConHilos}, y acertó {resultConHilos}");
        }
    }
}
