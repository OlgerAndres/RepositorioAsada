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
        private Prevista actualPrevista=null;


        public Previstas()
        {
            InitializeComponent();
            this.cargarPrevistas();
            this.cargarAbonados();
            this.cargarSectores();
            this.cargarTarifas();
          
        }

        private void cargarPrevistas() {
            this.DgPrevistas.ItemsSource = this.prevista.listar();
        }

        private void habilitarCampos(bool bandera)
        {
            this.DgPrevistas.IsEnabled = bandera;
            this.btnAgregar.IsEnabled = bandera;
            this.btnModificar.IsEnabled = !bandera;
            this.btnEliminar.IsEnabled = !bandera;
        }

        private void cargarAbonados()
        {
            this.cmbAbonado.DisplayMemberPath ="Nombre";
            this.cmbAbonado.SelectedValuePath = "Id";
            this.cmbAbonado.ItemsSource = this.abonado.listar();
        }

        private void cargarSectores() {
            this.cmbSector.DisplayMemberPath = "Descripcion";
            this.cmbSector.SelectedValuePath = "Id";
            this.cmbSector.ItemsSource = this.sector.listar();

        }

        private void cargarTarifas() {
            this.cmbTarifa.DisplayMemberPath = "Descripcion";
            this.cmbTarifa.SelectedValuePath = "Id";
            this.cmbTarifa.ItemsSource = this.tarifa.listar();   
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if ( string.IsNullOrEmpty(this.txtDireccion.Text) || string.IsNullOrEmpty(this.txtFolio.Text))
            {
                MessageBox.Show("Campos vacios");
                return;
            } 
            this.prevista.agregar(Convert.ToInt32(cmbAbonado.SelectedValue),Convert.ToInt32(cmbTarifa.SelectedValue),Convert.ToInt32(cmbSector.SelectedValue),this.txtDireccion.Text,this.txtFolio.Text);
            MessageBox.Show("Prevista agregada");
            this.cargarPrevistas();
            this.limpiarCampos();
         
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.prevista.borrar(this.actualPrevista.Id);
            MessageBox.Show("Prevista eliminada");
            this.cargarPrevistas();
            this.limpiarCampos();
            this.habilitarCampos(true);
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            this.prevista.actualizar(this.actualPrevista.Id,Convert.ToInt32(cmbAbonado.SelectedValue),Convert.ToInt32(cmbTarifa.SelectedValue),Convert.ToInt32(cmbSector.SelectedValue),this.txtDireccion.Text,this.txtFolio.Text);
            MessageBox.Show("Prevista actualizada");
            this.cargarAbonados();
            this.limpiarCampos();
            this.habilitarCampos(true);
        }

      
        private void limpiarCampos()
        {
            txtDireccion.Clear();
            txtFolio.Clear();
            

        }


   
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.limpiarCampos();
            this.habilitarCampos(true);
            this.Hide();
        }

        private void DgPrevistas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.actualPrevista = this.DgPrevistas.CurrentItem as Prevista;
            this.cmbAbonado.SelectedValue = Convert.ToInt32(this.actualPrevista.IdAbonado);
            this.cmbTarifa.SelectedValue = Convert.ToInt32(this.actualPrevista.IdTarifa);
            this.cmbSector.SelectedValue = Convert.ToInt32(this.actualPrevista.IdSector);
            this.txtDireccion.Text = this.actualPrevista.Direccion;
            this.txtFolio.Text = this.actualPrevista.FolioReal;
            this.habilitarCampos(false);
        }
    }
}

