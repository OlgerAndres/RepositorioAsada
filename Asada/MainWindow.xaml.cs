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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Logica;
using Datos;

namespace Asada
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IServiciosUsuarios usuarios = new AccionesUsuarios();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try{
                Usuario usuario = null;
                if (this.usuarios.iniciarSession(this.txtUsuario.Text, this.txtClave.Password, out usuario))
                {
                    ASADAS asadas = new ASADAS();
                    asadas.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo iniciar sesion [Verifique usuario/clave]");
                }
        }catch(Exception){
            MessageBox.Show("Error,intentelo de nuevo", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }
            }
    
        }
    
}
