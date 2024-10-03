using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaVuelo
{
    public class Grafo
    {
        private Dictionary<string, Ciudad> _ciudades;

        public Grafo()
        {
            _ciudades = new Dictionary<string, Ciudad>();
        }

        public void AgregarRuta(string origenNombre, string destinoNombre, int distancia, decimal valor)
        {
            Ciudad origen = ObtenerOCrearCiudad(origenNombre);
            Ciudad destino = ObtenerOCrearCiudad(destinoNombre);

            Arista arista = new Arista(destino, distancia, valor);
            origen.Aristas.Add(arista);
        }

        private Ciudad ObtenerOCrearCiudad(string nombreCiudad)
        {
            if (!_ciudades.ContainsKey(nombreCiudad))
            {
                _ciudades[nombreCiudad] = new Ciudad(nombreCiudad);
            }
            return _ciudades[nombreCiudad];
        }

        public Ciudad ObtenerCiudad(string nombreCiudad)
        {
            _ciudades.TryGetValue(nombreCiudad, out Ciudad ciudad);
            return ciudad;
        }

        public IEnumerable<Ciudad> ObtenerCiudades()
        {
            return _ciudades.Values;
        }
    }
}
