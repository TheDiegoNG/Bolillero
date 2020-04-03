using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolilleroBiblioteca

{
    public class Bolillero
    {

        public List<int> bolillasLista { get; set; }

        Random numRand = new Random();

        public Bolillero()
        {

        }

        public void regresarBolillasSacadas()
        {

        }

        public bool verificarJugada()
        {
            return false;
        }
        public List<int> sacarJugada()
        {
            List<int> Jugada = new List<int>();
            for (int i = 0; i < 7; i++)
            {
                Jugada[1] = sacarBolilla();
            }
            return Jugada;
        }
        public int sacarBolilla()
        {
            int bolilla = bolillasLista[numRand.Next(40)];
            bolillasLista.Remove(bolilla);
            return bolilla;
        }

        public int jugarNVeces(List<int> jugada, int cantVeces)
        {
            return 0;
        }
    }
}
