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
           
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
         
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

      

    
        private void setAbonadosObj(Abonado objInformacion) {
            this.txtNombre.Text = objInformacion.Nombre;
            this.txtPrimerApellido.Text = objInformacion.PrimerApellido;
            this.txtSegundoApellido.Text = objInformacion.SegundoApellido;
            this.txtCedula.Text = Convert.ToString(objInformacion.Cedula);
            this.txtTelefono.Text = Convert.ToString(objInformacion.Telefono);
            this.txtCelular.Text = Convert.ToString(objInformacion.Celular);
            txtDireccion.Text = objInformacion.Direccion;
            txtCorreo.Text = objInformacion.Correo;
            txtNumeroAbonado.Text = Convert.ToString(objInformacion.NumeroAbonado);
            chbAfiliado.IsChecked = Convert.ToBoolean(objInformacion.Afiliado);
            
         

        }      

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
            Hide();
        }


        private void dgAbonados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
if (dgAbonados.SelectedIndex != -1)
            {

                Abonado objAbonadosSelect = this.dgAbonados.SelectedItem as Abonado;
                setAbonadosObj(objAbonadosSelect);

            }

            else {
                MessageBox.Show("Selecciona el abonado que deseas mostrar");
            
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
          Abonado abonado = this.dgAbonados.SelectedItem as Abonado;
            this.abonados.borrar(abonado.Id);
            MessageBox.Show("Usuario eliminado");
            this.cargarAbonados();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Abonado abonado = this.dgAbonados.CurrentItem as Abonado;
            this.abonados.actualizar(abonado.Id, abonado.Nombre, abonado.PrimerApellido, abonado.SegundoApellido, abonado.Cedula, abonado.Telefono, abonado.Celular, abonado.Direccion, abonado.Correo, abonado.NumeroAbonado, abonado.Afiliado);
            this.cargarAbonados();
            this.limpiar();
        }
        }



    }

