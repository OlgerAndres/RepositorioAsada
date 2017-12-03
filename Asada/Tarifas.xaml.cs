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
        private IServiciosTarifas tarifa = new AccionesTarifas();

        public Tarifas()
        {
            InitializeComponent();
        }

        private void cargarTarifas()
        {
            this.DgTarifas.SelectedItem = this.tarifa.listar();
        }

        private void ComboTarifas()
        {

            this.cmbTipo.DisplayMemberPath = "Descripcion";
            this.cmbTipo.SelectedValuePath = "Id";
            this.cmbTipo.ItemsSource = this.tarifa.listar();
        }

        private void DgSectores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgTarifas.SelectedIndex != -1)
            {

                Tarifa objTarifaSelect = this.DgTarifas.SelectedItem as Tarifa;
                setTarifaObj(objTarifaSelect);


            }

            else
            {
                MessageBox.Show("Selecciona la tarifa que deseas mostrar");
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //this.tarifa.agregar(Convert.ToInt32(this.cmbTipo.SelectedValue),Decimal.Parse(txtPrecio.Text));
            this.cargarTarifas();
            this.limpiar();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Tarifa tarifa = this.DgTarifas.CurrentItem as Tarifa;
            this.tarifa.actualizar(tarifa.Id, tarifa.Descripcion, tarifa.Precio);
            this.cargarTarifas();
        }


        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.cargarTarifas();
        }

        private void limpiar()
        {
            txtPrecio.Clear();
         
        }

        private void setTarifaObj(Tarifa objInformacion)
        {
            this.cmbTipo.SelectedValue = Convert.ToString(objInformacion.Descripcion);
            
            this.txtPrecio.Text = Convert.ToString(objInformacion.Precio);

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Tarifa tarifa = this.DgTarifas.SelectedItem as Tarifa;
            this.tarifa.borrar(tarifa.Id);
            MessageBox.Show("Tarifa eliminada");
            this.cargarTarifas();
        }

    }
}
