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

            int simResto = cantidadSimulaciones % cantidadHilos;
            int simulacionesPorHilo = Convert.ToInt32(cantidadSimulaciones / cantidadHilos);

            Bolillero clonResto = (Bolillero)bolillero.Clone();
            tareas[0] = Task.Run(() => clonResto.jugarNVeces(jugada, simulacionesPorHilo + simResto));

            for (int i = 1; i < cantidadHilos; i++)
            {
                Bolillero clon = (Bolillero)bolillero.Clone();
                tareas[i] = Task.Run(() => clon.jugarNVeces(jugada, simulacionesPorHilo));
            }

            Task<int>.WaitAll(tareas);

            return tareas.Sum(t => t.Result);
        }
    }
}
