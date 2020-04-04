using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolilleroBiblioteca

{
    public class Bolillero
    {

        public List<int> bolillasLista { get; set; }

        public int cantBolillas { get; set; }

        Random numRand = new Random();

        public Bolillero()
        {
            bolillasLista = new List<int>();
        }

        public void llenarBolillero()
        {
            bolillasLista.Clear();
            for (int i = 0; i < cantBolillas; i++)
            {
                bolillasLista.Add(i);
            }
        }

        public bool verificarJugada(List<int> jugada, List<int> jugada2)
        {
            if (jugada.SequenceEqual(jugada2))
            {
                return true;
            }
            return false;
        }
        public List<int> sacarJugada()
        {
            List<int> Jugada = new List<int>();
            for (int i = 0; i < 7; i++)
            {
                Jugada.Add(sacarBolilla());
            }
            return Jugada;
        }
        public int sacarBolilla()
        {
            int bolilla = bolillasLista[numRand.Next(bolillasLista.Count)];
            bolillasLista.Remove(bolilla);
            return bolilla;
        }

        public int jugarNVeces(List<int> jugada, int cantVeces)
        {
            int vecesJugada = 0;
            List<int> cadenaNum = new List<int>();
            for (int i = 0; i < cantVeces; i++)
            {
                cadenaNum = sacarJugada();
                if (verificarJugada(jugada, cadenaNum))
                {
                    vecesJugada++;
                }
                llenarBolillero();
            }
            return vecesJugada;
        }
    }
}
