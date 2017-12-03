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
    /// Lógica de interacción para Previstas.xaml
    /// </summary>
    public partial class Previstas : Window
    {
        private IServiciosPrevistas prevista = new AccionesPrevistas();
        private IServiciosAbonados abonado = new AccionesAbonados();
        private IServiciosSectores sector = new AccionesSectores();
        private IServiciosTarifas tarifa = new AccionesTarifas();

        public Previstas()
        {
            InitializeComponent();
        }


        private void cargarPrevistas() {
            this.DgPrevistas.SelectedItem = this.prevista.listar();
        }

        private void cargarAbonados()
        {

            this.cmbAbonado.DataContext = this.abonado.listar();
            this.cmbAbonado.DisplayMemberPath = "NOMBRE";
            this.cmbAbonado.SelectedValuePath = "Id";
        }

        private void cargarSectores() {

            this.cmbSector.DataContext = this.sector.listar();
            this.cmbSector.DisplayMemberPath = "Descripcion";
            this.cmbSector.SelectedValuePath = "Id";

        }

        private void cargarTarifas() {

            this.cmbTarifa.DataContext = this.tarifa.listar();
            this.cmbTarifa.DisplayMemberPath = "Precio";
            this.cmbTarifa.SelectedValuePath = "Id";

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

            //this.prevista.agregar(this.cmbAbonado.SelectedValuePath, this.cmbTarifa.SelectedValuePath, this.cmbSector.SelectedValuePath, this.txtDireccion.Text, this.txtFolio.Text);
            this.cargarAbonados();
            this.cargarPrevistas();
            this.cargarSectores();
            this.cargarTarifas();



            

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cargarAbonados();
            cargarPrevistas();
            cargarSectores();
            cargarTarifas();
        }
    }
}

