using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Diagnostics;

namespace Asada
{
    /// <summary>
    /// Interaction logic for ASADAS.xaml
    /// </summary>
    public partial class ASADAS : Window
    {
        //Implemnetación de las clases de lógica
        private Abonados abonados = new Abonados();
        private Previstas previstas = new Previstas();
        private Sectores sectores = new Sectores();
        private Tarifas tarifas = new Tarifas();
        private Usuarios usuarios = new Usuarios();
        private Reportes reportes = new Reportes();

        public ASADAS()
        {
            InitializeComponent();
        }

        //Detiene la aplicación cuando cierra este formulario
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
        //Visualiza el formulario de usuarios
        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            this.usuarios.Show();
        }
        //Visualiza el formulario de abonados
        private void btnAbonados_Click(object sender, RoutedEventArgs e)
        {
            this.abonados.Show();
        }
        //Visualiza el formulario de previstas
        private void btnPrevistas_Click(object sender, RoutedEventArgs e)
        {
            this.previstas.Show();
        }
        //Visualiza el formulario de tarifas
        private void btnTarifas_Click(object sender, RoutedEventArgs e)
        {
            this.tarifas.Show();
        }
        //Visualiza el formulario de sectores
        private void btnSectores_Click(object sender, RoutedEventArgs e)
        {
            this.sectores.Show();
        }
        //Visualiza los reportes
        private void BtnReportes_Click(object sender, RoutedEventArgs e)
        {
            this.reportes.Show();
        }
        //Muestra el manual de usuario,por medio de un link
        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://drive.google.com/file/d/15gOUqmPpvVmJrT0smUW_mjpllH-CbyZK/view?usp=sharing");
        }
    }
}
