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
    /// Lógica de interacción para Abonados.xaml
    /// </summary>
    public partial class Abonados : Window
    {
        //Implementación de las clases de lógica
        private IServiciosAbonados abonados = new AccionesAbonados();
        private Abonado abonadoActual = null;

        public Abonados()
        {
            InitializeComponent();
        }
        //Método de habilitar los botones del formulario
        private void habilitarCampos(bool bandera)
        {
            this.dgAbonados.IsEnabled = bandera;
            this.btnAgregar.IsEnabled = bandera;
            this.btnModificar.IsEnabled = !bandera;
            this.btnEliminar.IsEnabled = !bandera;

            this.btnCancelar.Visibility = (bandera) ?
                System.Windows.Visibility.Hidden :
                System.Windows.Visibility.Visible;
        }
        //Método para visualizar los abonados
        private void cargarAbonados()
        {
            this.dgAbonados.ItemsSource = this.abonados.listar();
        }

        //Botón de agregar un nuevo abonado
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtPrimerApellido.Text) || string.IsNullOrEmpty(txtCedula.Text) || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(txtCelular.Text) || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(txtNumeroAbonado.Text))
                {
                    MessageBox.Show("Campos vacios");
                    return;
                }
                this.abonados.agregar(this.txtNombre.Text, this.txtPrimerApellido.Text, this.txtSegundoApellido.Text, this.txtCedula.Text, this.txtTelefono.Text, this.txtCelular.Text, this.txtDireccion.Text, this.txtCorreo.Text, this.txtNumeroAbonado.Text, this.chbAfiliado.IsChecked.Value);
                MessageBox.Show("Abonado agregado", "Información", MessageBoxButton.OK);
                this.cargarAbonados();
                this.limpiarCampos();
            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Método de limpiar los campos del formulario
        private void limpiarCampos()
        {
            this.txtNombre.Clear();
            this.txtPrimerApellido.Clear();
            this.txtSegundoApellido.Clear();
            this.txtCedula.Clear();
            this.txtTelefono.Clear();
            this.txtCelular.Clear();
            this.txtDireccion.Clear();
            this.txtCorreo.Clear();
            this.txtNumeroAbonado.Clear();
            this.lblCantidadValor.Content =""; 
        }
        //Botón para modificar un abonado
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.abonados.actualizar(this.abonadoActual.Id, this.txtNombre.Text, this.txtPrimerApellido.Text, this.txtSegundoApellido.Text, this.txtCedula.Text, this.txtTelefono.Text, this.txtCelular.Text, this.txtDireccion.Text, this.txtCorreo.Text, this.txtNumeroAbonado.Text, this.chbAfiliado.IsChecked.Value);
                MessageBox.Show("Abonado actualizado", "Información", MessageBoxButton.OK);
                this.cargarAbonados();
                this.limpiarCampos();
                this.habilitarCampos(true);

            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Método de eliminar un abonado
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                this.abonados.borrar(this.abonadoActual.Id);
                MessageBox.Show("Abonado eliminado", "Información", MessageBoxButton.OK);
                this.cargarAbonados();
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
            this.limpiarCampos();
            this.habilitarCampos(true);
            this.Hide();
        }
        //Evento del datagrid para seleccionar un abonado
        private void dgAbonados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.abonadoActual = this.dgAbonados.CurrentItem as Abonado;
            if (null == this.abonadoActual)
            {
                return;
            }
            this.txtNombre.Text = this.abonadoActual.Nombre;
            this.txtPrimerApellido.Text = this.abonadoActual.PrimerApellido;
            this.txtSegundoApellido.Text = this.abonadoActual.SegundoApellido;
            this.txtCedula.Text = this.abonadoActual.Cedula;
            this.txtTelefono.Text = this.abonadoActual.Telefono;
            this.txtCelular.Text = this.abonadoActual.Celular;
            this.txtDireccion.Text = this.abonadoActual.Direccion;
            this.txtCorreo.Text = this.abonadoActual.Correo;
            this.txtNumeroAbonado.Text = this.abonadoActual.NumeroAbonado;
            this.chbAfiliado.IsChecked = this.abonadoActual.Afiliado;
            this.lblCantidadValor.Content = (new AccionesPrevistas()).cantidadPrevistasPorIdAbonado(this.abonadoActual.Id);
            this.habilitarCampos(false);
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
            this.cargarAbonados();
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

