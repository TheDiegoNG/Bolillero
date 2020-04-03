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
            for (int i = 0; i < 40; i++)
            {
                bolillero.bolillasLista.Add(i);
            }

            List<int> jugada = bolillero.sacarJugada();

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(jugada[i]);
            }


        }
    }
}
