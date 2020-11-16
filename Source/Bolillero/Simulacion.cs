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
        public List<Bolillero> Bolilleros { get; set; }
        public int simularSinHilos(Bolillero bolillero, List<int> jugada, int cantSimulaciones) 
            => bolillero.jugarNVeces(jugada, cantSimulaciones);

        public int simularConHilos(Bolillero bolillero, List<int> jugada, int cantidadSimulaciones, int cantidadHilos)
        {
            Task<int>[] tareas = new Task<int>[cantidadHilos];
            var restos = new byte[cantidadHilos];
            int simResto = cantidadSimulaciones % cantidadHilos;
            int simulacionesPorHilo = Convert.ToInt32(cantidadSimulaciones / cantidadHilos);

            for (int i = 0; i < simResto; i++)
            {
                restos[i] = 1;
            }

            for (int i = simResto; i < cantidadHilos; i++)
            {
                restos[i] = 0;
            }

            for (int i = 0; i < cantidadHilos; i++)
            {
                Bolillero clon = (Bolillero)bolillero.Clone();
                Console.WriteLine($"{i}");
                tareas[i] = Task.Run(() => clon.jugarNVeces(jugada, simulacionesPorHilo + restos[i]));
            }

            Task<int>.WaitAll(tareas);

            return tareas.Sum(t => t.Result);
        }

        public async Task<int> simularConHilosAsync(Bolillero bolillero, List<int> jugada, int cantidadSimulaciones, int cantidadHilos)
        {
            Task<int>[] tareas = new Task<int>[cantidadHilos];
            var restos = new byte[cantidadHilos];
            int simResto = cantidadSimulaciones % cantidadHilos;
            int simulacionesPorHilo = Convert.ToInt32(cantidadSimulaciones / cantidadHilos);

            for (int i = 0; i < simResto; i++)
            {
                restos[i] = 1;
            }

            for (int i = simResto; i < cantidadHilos; i++)
            {
                restos[i] = 0;
            }

            for (int i = 0; i < cantidadHilos; i++)
            {
                Bolillero clon = (Bolillero)bolillero.Clone();
                tareas[i] = Task.Run(() => clon.jugarNVeces(jugada, simulacionesPorHilo + restos[i]));
            }

            await Task.WhenAll(tareas);

            return tareas.Sum(t => t.Result);
        }
        public async Task<int> simularParallelAsync(Bolillero bolillero, List<int> jugada, int cantidadSimulaciones, int cantidadHilos)
        {
            
            Task<int>[] tareas = new Task<int>[cantidadHilos];
            var resultados = new int[cantidadHilos];
            var restos = new byte[cantidadHilos];
            int simResto = cantidadSimulaciones % cantidadHilos;
            int simulacionesPorHilo = Convert.ToInt32(cantidadSimulaciones / cantidadHilos);

            for (int i = 0; i < simResto; i++)
            {
                restos[i] = 1;
            }

            for (int i = simResto; i < cantidadHilos; i++)
            {
                restos[i] = 0;
            }
                
            await Task.Run(() =>
                Parallel.For(0,
                    cantidadHilos,
                    i =>
                        {
                            Bolillero clon = (Bolillero)bolillero.Clone();
                            resultados[i] = clon.jugarNVeces(jugada, simulacionesPorHilo + restos[i]);
                        }
                    )
                );
            
            return resultados.Sum();
        }

    }
}
