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
        //Implementación de las clases de lógica
        private IServiciosTarifas tarifas = new AccionesTarifas();
        private Tarifa tarifaActual = null;

        public Tarifas()
        {
            InitializeComponent();
        }
        //Método de visualizar las tarifas
        private void cargarTarifas()
        {
            this.DgTarifas.ItemsSource = this.tarifas.listar(); 
        }

        //Método de limpiar los campos del formulario
        private void limpiarCampos()
        {
            this.txtDescripcion.Clear();
            this.txtPrecio.Clear();
        }

        //Método de habilitar los botones del formulario
        private void habilitarCampos(bool bandera)
        {
            this.DgTarifas.IsEnabled = bandera;
            this.btnAgregar.IsEnabled = bandera;
            this.btnModificar.IsEnabled = !bandera;
            this.btnEliminar.IsEnabled = !bandera;

            this.btnCancelar.Visibility = (bandera) ?
                System.Windows.Visibility.Hidden :
                System.Windows.Visibility.Visible;
        }
        //Botón de agregar una nueva tarifa
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtDescripcion.Text) || string.IsNullOrEmpty(this.txtPrecio.Text))
                {
                    MessageBox.Show("Tarifa y precio son requeridos.");
                    return;
                }
                this.tarifas.agregar(this.txtDescripcion.Text, decimal.Parse(this.txtPrecio.Text));
                MessageBox.Show("Tarifa agregada","Información",MessageBoxButton.OK);
                this.cargarTarifas();
                this.limpiarCampos();

            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Modifica una tarifa existente
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.tarifas.actualizar(this.tarifaActual.Id, this.txtDescripcion.Text, decimal.Parse(this.txtPrecio.Text));
                MessageBox.Show("Tarifa actualizada", "Información", MessageBoxButton.OK);
                this.cargarTarifas();
                this.limpiarCampos();
                this.habilitarCampos(true);
            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Evento del datagrid para seleccionar una tarifa
        private void DgTarifas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.tarifaActual = this.DgTarifas.CurrentItem as Tarifa;
            if (null == this.tarifaActual)
            {
                return;
            }
                this.tarifaActual = this.DgTarifas.CurrentItem as Tarifa;
                this.txtDescripcion.Text = this.tarifaActual.Descripcion;
                this.txtPrecio.Text = this.tarifaActual.Precio.ToString();
                this.habilitarCampos(false);
           
        }
        //Botón de eliminar una tarifa existente
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.tarifas.borrar(this.tarifaActual.Id);
                MessageBox.Show("Tarifa eliminada", "Información", MessageBoxButton.OK);
                this.cargarTarifas();
                this.limpiarCampos();
                this.habilitarCampos(true);
            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Método para cerrar la ventana del formulario,además de limpiar los campos y habilitar los botones
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            limpiarCampos();
            this.habilitarCampos(true);
            this.Hide();
        }
        //Botón de cancelar acciones
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.habilitarCampos(true);
            limpiarCampos();
           
        }
        //Prepara el formulario,cada vez que se carga
        private void prepararFormulario()
        {
            this.cargarTarifas();
        }
        //Muestra el  datagrid del formulario, cuando se abre la ventana
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible)
            {
                this.prepararFormulario();
            }
        }
    }
}
