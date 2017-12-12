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
        private IServiciosPrevistas previstas = new AccionesPrevistas();
        private IServiciosAbonados abonados = new AccionesAbonados();
        private IServiciosSectores sectores = new AccionesSectores();
        private IServiciosTarifas tarifas = new AccionesTarifas();
        private Prevista actualPrevista=null;

        private ReportePrevistas rpt = new ReportePrevistas();

        public Previstas()
        {
            InitializeComponent();
        }

        private void cargarPrevistas() {
            this.DgPrevistas.ItemsSource = this.previstas.listar();
        }

        private void habilitarCampos(bool bandera)
        {
            this.DgPrevistas.IsEnabled = bandera;
            this.btnAgregar.IsEnabled = bandera;
            this.btnModificar.IsEnabled = !bandera;
            this.btnEliminar.IsEnabled = !bandera;

            this.btnCancelar.Visibility = (bandera) ?
                System.Windows.Visibility.Hidden :
                System.Windows.Visibility.Visible;
        }

        private void cargarAbonados()
        {
            this.cmbAbonado.ItemsSource = this.abonados.listar();
            this.cmbAbonado.DisplayMemberPath = "NombreCompleto";
            this.cmbAbonado.SelectedValuePath = "Id";
            
        }

        private void cargarSectores() {

            this.cmbSector.ItemsSource = this.sectores.listar();
            this.cmbSector.DisplayMemberPath = "Descripcion";
            this.cmbSector.SelectedValuePath = "Id";
        

        }

        private void cargarTarifas() {
            this.cmbTarifa.ItemsSource = this.tarifas.listar();
            this.cmbTarifa.DisplayMemberPath = "Descripcion";
            this.cmbTarifa.SelectedValuePath = "Id";
              
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtDireccion.Text) || string.IsNullOrEmpty(this.txtFolio.Text))
                {
                    MessageBox.Show("Campos vacios");
                    return;
                }
                this.previstas.agregar(Convert.ToInt32(this.cmbAbonado.SelectedValue), Convert.ToInt32(this.cmbTarifa.SelectedValue), Convert.ToInt32(this.cmbSector.SelectedValue),this.txtDireccion.Text,this.txtFolio.Text);
                MessageBox.Show("Prevista agregada");
                this.cargarPrevistas();
                this.limpiarCampos();
            }
            catch (Exception ex) {
               
               
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.previstas.borrar(this.actualPrevista.Id);
                MessageBox.Show("Prevista eliminada");
                this.cargarPrevistas();
                this.limpiarCampos();
                this.habilitarCampos(true);
            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.previstas.actualizar(this.actualPrevista.Id, Convert.ToInt32(cmbAbonado.SelectedValue), Convert.ToInt32(cmbTarifa.SelectedValue), Convert.ToInt32(cmbSector.SelectedValue), this.txtDireccion.Text, this.txtFolio.Text);
                MessageBox.Show("Prevista actualizada");
                this.cargarPrevistas();
                this.limpiarCampos();
                this.habilitarCampos(true);
            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void limpiarCampos()
        {
            txtDireccion.Clear();
            txtFolio.Clear();
            this.cmbAbonado.SelectedIndex = -1;
            this.cmbTarifa.SelectedIndex = -1;
            this.cmbSector.SelectedIndex = -1;
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
            if (null == this.actualPrevista)
            {
                return;
            }
            this.actualPrevista = this.DgPrevistas.CurrentItem as Prevista;
            this.cmbAbonado.SelectedValue = Convert.ToInt32(this.actualPrevista.IdAbonado);
            this.cmbTarifa.SelectedValue = Convert.ToInt32(this.actualPrevista.IdTarifa);
            this.cmbSector.SelectedValue = Convert.ToInt32(this.actualPrevista.IdSector);
            this.txtDireccion.Text = this.actualPrevista.Direccion;
            this.txtFolio.Text = this.actualPrevista.FolioReal;
            this.habilitarCampos(false);
           
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.habilitarCampos(true);
            limpiarCampos();
        }

        private void prepararFormulario()
        {
            this.cargarPrevistas();
            this.cargarAbonados();
            this.cargarSectores();
            this.cargarTarifas();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible)
            {
                this.prepararFormulario();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            //ReportePrevistas rpt = new Asada.ReportePrevistas();
            this.rpt.Show();

        }
    }
}

