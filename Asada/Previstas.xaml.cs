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
        }

        private void cargarTarifas() { 
        
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

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
        }
    }
}

