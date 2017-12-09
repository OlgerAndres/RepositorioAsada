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
        private IServiciosUsuarios usuarios = new AccionesUsuarios();
        private string claveVisible = null;

        public Usuarios()
        {
            InitializeComponent();
            this.cargarUsuarios();
        }

        private void cargarUsuarios()
        {
            this.dgUsuarios.ItemsSource = this.usuarios.listar();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuario = this.dgUsuarios.CurrentItem as Usuario;
                string clave = (string.IsNullOrEmpty(this.claveVisible)) ? usuario.Clave : this.claveVisible;
                this.usuarios.actualizar(usuario.Id, usuario.Nombre, clave);
                MessageBox.Show("Usuario actualizado");
                this.cargarUsuarios();
            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuario = this.dgUsuarios.SelectedItem as Usuario;
                this.usuarios.borrar(usuario.Id);
                MessageBox.Show("Usuario eliminado");
                this.cargarUsuarios();
            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

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
                MessageBox.Show("Usuario agragado");
                this.cargarUsuarios();

            }catch(Exception ex){
                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void ClaveVisible_LostFocus(object sender, RoutedEventArgs e)
        {
            this.claveVisible = ((PasswordBox)sender).Password;
            if (string.IsNullOrEmpty(this.claveVisible))
            {
                ((PasswordBox)sender).Password = "**************";
            }
        }

        private void ClaveVisible_GotFocus(object sender, RoutedEventArgs e)
        {
            ((PasswordBox)sender).Password = string.Empty;
        }

        private void dgUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.claveVisible = string.Empty;
        }
    }
}
