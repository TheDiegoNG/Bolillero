using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolilleroBiblioteca
{
    public class Simulacion
    {
        public DateTime FechaHora { get; private set; }

        public TimeSpan Duracion => DateTime.Now - FechaHora;
        public Simulacion()
        {
            ResetearCronometro();
        }
        public void ResetearCronometro() => FechaHora = DateTime.Now;
        public int simularSinHilos(Bolillero bolillero, List<int> jugada, int cantSimulaciones) 
            => bolillero.jugarNVeces(jugada, cantSimulaciones);

        public int simularConHilos(Bolillero bolillero, List<int> jugada, int cantidadSimulaciones, int cantidadHilos)
        {
            Task<int>[] tareas = new Task<int>[cantidadHilos];
                  
            for (int i = 0; i < cantidadHilos; i++)
            {
                Bolillero clon = (Bolillero)bolillero.Clone();
                tareas[i] = new Task<int>(() => clon.jugarNVeces(jugada, cantidadSimulaciones / cantidadHilos));
            }

            Array.ForEach(tareas, t => t.Start());

            Task<int>.WaitAll(tareas);

            return tareas.Sum(t => t.Result);
        }
    }
}
