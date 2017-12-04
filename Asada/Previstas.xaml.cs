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
            this.cmbAbonado.DisplayMemberPath ="Nombre";
            this.cmbAbonado.SelectedValuePath = "Id";
            this.cmbAbonado.ItemsSource = this.abonado.listar();
        }

        private void cargarSectores() {
            this.cmbSector.DisplayMemberPath = "Descripcion";
            this.cmbSector.SelectedValuePath = "Id";
            this.cmbSector.ItemsSource = this.sector.listar();

            this.cmbSector.DataContext = this.sector.listar();
            this.cmbSector.DisplayMemberPath = "Descripcion";
            this.cmbSector.SelectedValuePath = "Id";
        }

        private void cargarTarifas() {
            this.cmbTarifa.DisplayMemberPath = "Descripcion";
            this.cmbTarifa.SelectedValuePath = "Id";
            this.cmbTarifa.ItemsSource = this.tarifa.listar();

            this.cmbTarifa.DataContext = this.tarifa.listar();
            this.cmbTarifa.DisplayMemberPath = "Precio";
            this.cmbTarifa.SelectedValuePath = "Id";
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            this.prevista.agregar(Convert.ToInt32(this.cmbAbonado.SelectedValue),Convert.ToInt32(this.cmbTarifa.SelectedValue),Convert.ToInt32(this.cmbSector.SelectedValue),this.txtDireccion.Text,this.txtFolio.Text);
            this.cargarAbonados();
            this.limpiar();
            //this.prevista.agregar(this.cmbAbonado.SelectedValuePath, this.cmbTarifa.SelectedValuePath, this.cmbSector.SelectedValuePath, this.txtDireccion.Text, this.txtFolio.Text);
            this.cargarAbonados();
            this.cargarPrevistas();
            this.cargarSectores();
            this.cargarTarifas();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Prevista prevista = this.DgPrevistas.SelectedItem as Prevista;
            this.prevista.borrar(prevista.Id);
            MessageBox.Show("Prevista eliminada");
            this.cargarPrevistas();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Prevista prevista = this.DgPrevistas.CurrentItem as Prevista;
            this.prevista.actualizar(prevista.Id, prevista.IdAbonado, prevista.IdTarifa, prevista.IdSector, prevista.Direccion,  prevista.FolioReal);
            this.cargarAbonados();
            this.limpiar();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cargarAbonados();
            cargarSectores();
            cargarTarifas();
        }

        private void limpiar()
        {
            txtDireccion.Clear();
            txtFolio.Clear();
        }

        private void setPrevistasObj(Prevista objInformacion)
        {
            this.cmbAbonado.SelectedValue = Convert.ToString(objInformacion.IdAbonado);
            this.cmbTarifa.SelectedValue = Convert.ToString(objInformacion.IdTarifa);
            this.cmbSector.SelectedValue = Convert.ToString(objInformacion.IdSector);
            this.txtDireccion.Text = objInformacion.Direccion;
            this.txtFolio.Text = objInformacion.FolioReal;
            cargarPrevistas();
            cargarSectores();
            cargarTarifas();
        }

        private void dgAbonados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgPrevistas.SelectedIndex != -1)
            {
                Prevista objPrevistasSelect = this.DgPrevistas.SelectedItem as Prevista;
                setPrevistasObj(objPrevistasSelect);
            }
            else
            {
                MessageBox.Show("Selecciona la prevista que deseas mostrar");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}

