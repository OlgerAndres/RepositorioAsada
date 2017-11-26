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
        private IServiciosAbonados abonados = new AccionesAbonados();

        public Abonados()
        {
            InitializeComponent();
        }

        private void cargarAbonados()
        {
            //this.dgAbonados.CurrentColumn.GetCellContent(0)= false;
            this.dgAbonados.ItemsSource = this.abonados.listar();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            this.abonados.agregar(this.txtNombre.Text,this.txtPrimerApellido.Text,this.txtSegundoApellido.Text,this.txtCedula.Text,this.txtTelefono.Text,this.txtCelular.Text,this.txtDireccion.Text,this.txtCorreo.Text,this.txtNumeroAbonado.Text,this.chbAfiliado.IsEnabled);
            this.cargarAbonados();
            this.limpiar();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Abonado abonado = this.dgAbonados.SelectedItem as Abonado;
            this.abonados.borrar(abonado.Id);
            MessageBox.Show("Usuario eliminado");
            this.cargarAbonados();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Abonado abonado = this.dgAbonados.CurrentItem as Abonado;
            this.abonados.actualizar(abonado.Id,abonado.Nombre,abonado.PrimerApellido,abonado.SegundoApellido,abonado.Cedula,abonado.Telefono,abonado.Celular,abonado.Direccion,abonado.Correo,abonado.NumeroAbonado,abonado.Afiliado);
            this.cargarAbonados();
            this.limpiar();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        private void limpiar()
        {
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
            txtCelular.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            txtNumeroAbonado.Clear();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           
            cargarAbonados();
        }

        private void dgAbonados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //txtPrimerApellido.Text = Convert.ToString(dgAbonados.CurrentRow.Cells["Primer apellido"].Value);
            //txtSegundoApellido.Text = Convert.ToString(dgAbonados.CurrentRow.Cells["Segundo apellido"].Value);
          

               }

        private void btnSalir_Click_1(object sender, RoutedEventArgs e)
        {

            this.Hide();
        }


    }
}
