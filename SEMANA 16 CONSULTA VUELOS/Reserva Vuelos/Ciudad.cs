using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaVuelo
{
    public class Ciudad
    {
        public string Nombre { get; set; }
        public List<Arista> Aristas { get; set; }

        public Ciudad(string nombre)
        {
            Nombre = nombre;
            Aristas = new List<Arista>();
        }
    }
}
