using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaVuelo
{
    public class Arista
    {
        public Ciudad Destino { get; set; }
        public int Distancia { get; set; }
        public decimal Valor { get; set; }

        public Arista(Ciudad destino, int distancia, decimal valor)
        {
            Destino = destino;
            Distancia = distancia;
            Valor = valor;
        }
    }
}
