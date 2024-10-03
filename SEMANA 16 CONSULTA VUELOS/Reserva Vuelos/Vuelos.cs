using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaVuelo
{
    public class Vuelos
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int Distancia { get; set; }
        public decimal Valor { get; set; }

        public Vuelos(string origen, string destino, int distancia, decimal valor)
        {
            Origen = origen;
            Destino = destino;
            Distancia = distancia;
            Valor = valor;
        }
        public int MyProperty { get; set; }
    }
}
