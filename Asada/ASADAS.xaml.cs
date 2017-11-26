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

namespace Asada
{
    /// <summary>
    /// Interaction logic for ASADAS.xaml
    /// </summary>
    public partial class ASADAS : Window
    {
        private Abonados abonados = new Abonados();
        private Previstas previstas = new Previstas();
        private Sectores sectores = new Sectores();
        private Tarifas tarifas = new Tarifas();
        private Usuarios usuarios = new Usuarios();

        public ASADAS()
        {
            InitializeComponent();
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            this.abonados.Close();
            this.previstas.Close();
            this.sectores.Close();
            this.tarifas.Close();
            this.usuarios.Close();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            this.usuarios.Show();
        }

        private void btnAbonados_Click(object sender, RoutedEventArgs e)
        {
            this.abonados.Show();
      
        }

        private void btnPrevistas_Click(object sender, RoutedEventArgs e)
        {
            this.previstas.Show();
        }

        private void btnTarifas_Click(object sender, RoutedEventArgs e)
        {
            this.tarifas.Show();
        }

        private void btnSectores_Click(object sender, RoutedEventArgs e)
        {
            this.sectores.Show();
        }
    }
}
