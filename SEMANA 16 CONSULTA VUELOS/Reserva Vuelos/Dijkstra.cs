using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaVuelo
{
    public class Dijkstra
    {
        public class ResultadoRuta
        {
            public Ciudad Ciudad { get; set; }
            public decimal Distancia { get; set; }
            public decimal Valor { get; set; }
        }
        public static List<ResultadoRuta> EncontrarRutaMasCorta(Grafo grafo, string origenNombre, string destinoNombre, Func<Arista, decimal> selectorPeso)
        {
            var origen = grafo.ObtenerCiudad(origenNombre);
            var destino = grafo.ObtenerCiudad(destinoNombre);

            var distancias = new Dictionary<Ciudad, decimal>();
            var previo = new Dictionary<Ciudad, (Ciudad ciudad, Arista arista)>();
            var noVisitados = new List<Ciudad>();

            // Inicializar
            foreach (var ciudad in grafo.ObtenerCiudades())
            {
                distancias[ciudad] = decimal.MaxValue;
                previo[ciudad] = (null, null);
                noVisitados.Add(ciudad);
            }
            distancias[origen] = 0;

            while (noVisitados.Count > 0)
            {
                noVisitados.Sort((x, y) => distancias[x].CompareTo(distancias[y]));
                var actual = noVisitados[0];
                noVisitados.RemoveAt(0);

                if (actual == destino)
                    break;

                foreach (var arista in actual.Aristas)
                {
                    var vecino = arista.Destino;
                    if (noVisitados.Contains(vecino))
                    {
                        decimal peso = selectorPeso(arista);
                        decimal distanciaAlternativa = distancias[actual] + peso;
                        if (distanciaAlternativa < distancias[vecino])
                        {
                            distancias[vecino] = distanciaAlternativa;
                            previo[vecino] = (actual, arista);
                        }
                    }
                }
            }

            // Reconstruir la ruta
            var ruta = new List<ResultadoRuta>();
            var ciudadActual = destino;
            while (ciudadActual != null && previo[ciudadActual].ciudad != null)
            {
                var arista = previo[ciudadActual].arista;
                ruta.Insert(0, new ResultadoRuta
                {
                    Ciudad = ciudadActual,
                    Distancia = arista.Distancia,
                    Valor = arista.Valor
                });
                ciudadActual = previo[ciudadActual].ciudad;
            }

            // Agregar la ciudad de origen (sin valores porque es el inicio)
            ruta.Insert(0, new ResultadoRuta { Ciudad = origen, Distancia = 0, Valor = 0 });

            return ruta;
        }
    }
}
