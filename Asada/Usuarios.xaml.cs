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

namespace Asada
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
        private IServiciosUsuarios usuarios = new AccionesUsuarios();

        public Usuarios()
        {
            InitializeComponent();
            this.cargarUsuarios();
        }

        private void cargarUsuarios()
        {
            this.dgUsuarios.ItemsSource = this.usuarios.listar();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            this.usuarios.agregar(this.txtUsuario.Text, this.txtClave.Password);
            this.cargarUsuarios();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
