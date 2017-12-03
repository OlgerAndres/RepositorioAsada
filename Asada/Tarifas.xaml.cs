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

        private void cargarPrevistas()
        {
            this.DgTarifas.SelectedItem = this.tarifa.listar();
        }

        private void cargarTarifas()
        {

            this.cmbTipo.DisplayMemberPath = "Descripcion";
            this.cmbTipo.SelectedValuePath = "Id";
            this.cmbTipo.ItemsSource = this.tarifa.listar();
        }

        private void DgSectores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //this.tarifa.agregar(Convert.ToInt32(this.cmbTipo.SelectedValue),Convert.ToDecimal(txtPrecio.Text).ToString);
            this.cargarTarifas();
            this.limpiar();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

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

    }
}
