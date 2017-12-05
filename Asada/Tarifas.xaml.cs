using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logica;
using Datos;

namespace Asada
{
    /// <summary>
    /// Interaction logic for Tarifas.xaml
    /// </summary>
    public partial class Tarifas : Window
    {
        private IServiciosTarifas tarifas = new AccionesTarifas();
        private Tarifa tarifaActual = null;

        public Tarifas()
        {
            InitializeComponent();
            this.cargarTarifas();
        }

        private void cargarTarifas()
        {
            this.DgTarifas.ItemsSource = this.tarifas.listar(); 
        }

        private void limpiarCampos()
        {
            this.txtDescripcion.Clear();
            this.txtPrecio.Clear();
        }

        private void habilitarCampos(bool bandera)
        {
            this.DgTarifas.IsEnabled = bandera;
            this.btnAgregar.IsEnabled = bandera;
            this.btnModificar.IsEnabled = !bandera;
            this.btnEliminar.IsEnabled = !bandera;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text) || string.IsNullOrEmpty(this.txtPrecio.Text))
            {
                MessageBox.Show("Tarifa y precio son requeridos.");
                return;
            }
            this.tarifas.agregar(this.txtDescripcion.Text, decimal.Parse(this.txtPrecio.Text));
            MessageBox.Show("Tarifa agregada");
            this.cargarTarifas();
            this.limpiarCampos();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {   
            this.tarifas.actualizar(this.tarifaActual.Id, this.txtDescripcion.Text, decimal.Parse(this.txtPrecio.Text));
            MessageBox.Show("Tarifa actualizada");
            this.cargarTarifas();
            this.limpiarCampos();
            this.habilitarCampos(true);
        }

        private void DgTarifas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.tarifaActual = this.DgTarifas.CurrentItem as Tarifa;
            this.txtDescripcion.Text = this.tarifaActual.Descripcion;
            this.txtPrecio.Text = this.tarifaActual.Precio.ToString();
            this.habilitarCampos(false);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.tarifas.borrar(this.tarifaActual.Id);
            MessageBox.Show("Tarifa eliminada");
            this.cargarTarifas();
            this.limpiarCampos();
            this.habilitarCampos(true);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            limpiarCampos();
            this.habilitarCampos(true);
            this.Hide();
        }
    }
}
