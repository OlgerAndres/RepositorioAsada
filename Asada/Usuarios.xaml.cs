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
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
        //Implementación de las clases de lógica
        private IServiciosUsuarios usuarios = new AccionesUsuarios();
        private string claveVisible = null;

        public Usuarios()
        {
            InitializeComponent();
        }
        //Método de visualizar los usuarios
        private void cargarUsuarios()
        {
            this.dgUsuarios.ItemsSource = this.usuarios.listar();
        }

        //Modifica un usuario existente
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuario = this.dgUsuarios.CurrentItem as Usuario;
                string clave = (string.IsNullOrEmpty(this.claveVisible)) ? usuario.Clave : this.claveVisible;
                this.usuarios.actualizar(usuario.Id, usuario.Nombre, clave);
                MessageBox.Show("Usuario actualizado", "Información", MessageBoxButton.OK);
                this.cargarUsuarios();
            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Botón de eliminar un usuario existente
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuario = this.dgUsuarios.SelectedItem as Usuario;
                this.usuarios.borrar(usuario.Id);
                MessageBox.Show("Usuario eliminado", "Información", MessageBoxButton.OK);
                this.cargarUsuarios();
            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Botón de agregar una nuevo usuario
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtUsuario.Text) || string.IsNullOrEmpty(this.txtClave.Password))
                {
                    MessageBox.Show("Nombre y clave son requeridos.");
                    return;
                }
                this.usuarios.agregar(this.txtUsuario.Text, this.txtClave.Password);
                MessageBox.Show("Usuario agregado","Información",MessageBoxButton.OK);
                this.cargarUsuarios();

            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Método para cerrar la ventana del formulario
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        //Método de encriptar la clave cuando se digita
        private void ClaveVisible_LostFocus(object sender, RoutedEventArgs e)
        {
            this.claveVisible = ((PasswordBox)sender).Password;
            if (string.IsNullOrEmpty(this.claveVisible))
            {
                ((PasswordBox)sender).Password = "**************";
            }
        }
        //Muestra la clave encriptada en el formulario
        private void ClaveVisible_GotFocus(object sender, RoutedEventArgs e)
        {
            ((PasswordBox)sender).Password = string.Empty;
        }
        //Evento del datagrid para seleccionar la clave del usuario
        private void dgUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.claveVisible = string.Empty;
        }

        //Prepara el formulario,cada vez que se carga
        private void prepararFormulario()
        {
            this.cargarUsuarios();
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
