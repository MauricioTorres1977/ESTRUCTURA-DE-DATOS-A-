using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservaVuelo
{
    public partial class Form1 : Form
    {
        private AdministradorVuelo administradorVuelo;

        public Form1()
        {
            InitializeComponent();
            administradorVuelo = new AdministradorVuelo();
            CargarVuelosEnInterfaz();
        }

        private void CargarVuelosEnInterfaz()
        {
            lstVuelos.Items.Clear();
            var vuelos = administradorVuelo.ObtenerVuelos();
            foreach (var vuelo in vuelos)
            {
                lstVuelos.Items.Add($"{vuelo.Origen} - {vuelo.Destino}, {vuelo.Distancia} km, ${vuelo.Valor}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            administradorVuelo = new AdministradorVuelo();
            var ciudades = administradorVuelo.ObtenerGrafo().ObtenerCiudades();

            foreach (var ciudad in ciudades)
            {
                cbOrigen.Items.Add(ciudad.Nombre);
                cbDestino.Items.Add(ciudad.Nombre);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string origen = txtorigen.Text;
            string destino = txtDestino.Text;
            int distancia = int.Parse(txtDistancia.Text);
            decimal valor = decimal.Parse(txtValor.Text);

            Vuelos nuevoVuelo = new Vuelos(origen, destino, distancia, valor);
            administradorVuelo.AgregarVuelo(nuevoVuelo);
            CargarVuelosEnInterfaz();
        }

        private void lstVuelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVuelos.FocusedItem == null) return;
            int indiceSeleccionado = lstVuelos.FocusedItem.Index;

            if (indiceSeleccionado != -1)
            {
                LblIndice.Text = indiceSeleccionado.ToString();
                var vueloSeleccionado = administradorVuelo.ObtenerVuelos().ElementAt(indiceSeleccionado);
                txtorigen.Text = vueloSeleccionado.Origen;
                txtDestino.Text = vueloSeleccionado.Destino;
                txtDistancia.Text = vueloSeleccionado.Distancia.ToString();
                txtValor.Text = vueloSeleccionado.Valor.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Editar
            int indiceSeleccionado = Convert.ToInt32(LblIndice.Text);

            if (indiceSeleccionado != -1)
            {
                string origen = txtorigen.Text;
                string destino = txtDestino.Text;
                int distancia = int.Parse(txtDistancia.Text);
                decimal valor = decimal.Parse(txtValor.Text);

                Vuelos vueloActualizado = new Vuelos(origen, destino, distancia, valor);
                administradorVuelo.ActualizarVuelo(indiceSeleccionado, vueloActualizado);

                CargarVuelosEnInterfaz();
                MessageBox.Show("Vuelo actualizado correctamente");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un vuelo para actualizar.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = Convert.ToInt32(LblIndice.Text);

            if (indiceSeleccionado != -1)
            {
                administradorVuelo.EliminarVuelo(indiceSeleccionado);

                CargarVuelosEnInterfaz();
                MessageBox.Show("Vuelo eliminado correctamente");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un vuelo para eliminar.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string origen = cbOrigen.SelectedItem.ToString();
            string destino = cbDestino.SelectedItem.ToString();

            // Elegir si se quiere optimizar por distancia o valor
            // oPCION distancia
            var ruta = Dijkstra.EncontrarRutaMasCorta(
                administradorVuelo.ObtenerGrafo(),
                origen,
                destino,
                arista => arista.Distancia
            );

            lstRutas.Items.Clear();
            decimal totalDistancia = 0;
            decimal totalValor = 0;

            foreach (var resultado in ruta)
            {
                lstRutas.Items.Add($"Ciudad: {resultado.Ciudad.Nombre}, Distancia: {resultado.Distancia} km, Valor: ${resultado.Valor}");
                totalDistancia += resultado.Distancia;
                totalValor += resultado.Valor;
            }

            // Mostrar el total
            lstRutas.Items.Add($"Total Distancia: {totalDistancia} km, Total Valor: ${totalValor}");

        }
    }
}
