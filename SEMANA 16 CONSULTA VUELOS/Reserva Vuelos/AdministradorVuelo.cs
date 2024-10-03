using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaVuelo
{
    public class AdministradorVuelo
    {
        private readonly string _csvArchivo = @"C:\tmp\vuelos.csv";
        private LinkedList<Vuelos> _vuelos;
        private Grafo _grafo;
        public AdministradorVuelo()
        {
            _vuelos = new LinkedList<Vuelos>();
            _grafo = new Grafo();
            CargarVuelos();
        }
        // Crear o añadir vuelo
        public void AgregarVuelo(Vuelos vuelo)
        {
            _vuelos.AddLast(vuelo);
            GuardarDatos();
        }
        private void CargarVuelos()
        {
            _vuelos.Clear();
            if (File.Exists(_csvArchivo))
            {
                var lineas = File.ReadAllLines(_csvArchivo);
                foreach (var linea in lineas)
                {
                    var datos = linea.Split(',');
                    var vuelo = new Vuelos(datos[0], datos[1], int.Parse(datos[2]), decimal.Parse(datos[3]));
                    _vuelos.AddLast(vuelo);
                    _grafo.AgregarRuta(datos[0], datos[1], int.Parse(datos[2]), decimal.Parse(datos[3]));
                }

            }
        }
        public Grafo ObtenerGrafo()
        {
            return _grafo;
        }

        // Guardar la lista de vuelos en el CSV
        private void GuardarDatos()
        {
            var lineas = new List<string>();
            foreach (var vuelo in _vuelos)
            {
                lineas.Add($"{vuelo.Origen},{vuelo.Destino},{vuelo.Distancia},{vuelo.Valor}");
            }
            File.WriteAllLines(_csvArchivo, lineas);
        }
        // Obtener todos los vuelos
        public LinkedList<Vuelos> ObtenerVuelos()
        {
            return _vuelos;
        }
        // Eliminar vuelo por índice
        public void EliminarVuelo(int index)
        {
            var nodo = _vuelos.First;
            for (int i = 0; i < index && nodo != null; i++)
            {
                nodo = nodo.Next;
            }
            if (nodo != null)
            {
                _vuelos.Remove(nodo);
                GuardarDatos();
            }
        }
        // Actualizar vuelo (en base al índice)
        public void ActualizarVuelo(int index, Vuelos vueloActualizado)
        {
            var nodo = _vuelos.First;
            for (int i = 0; i < index && nodo != null; i++)
            {
                nodo = nodo.Next;
            }
            if (nodo != null)
            {
                nodo.Value = vueloActualizado;
                GuardarDatos();
            }
        }
    }
}
