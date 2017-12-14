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

namespace Asada
{
    /// <summary>
    /// Lógica de interacción para Reportes.xaml
    /// </summary>
    public partial class Reportes : Window
    {
        //Implementación de las  clases de lógica
        private ReportePrevistas reportePrevistas = new ReportePrevistas();
        private ReporteAbonados reporteAbonados = new ReporteAbonados();

        public Reportes()
        {
            InitializeComponent();
        }
        //Método de cerrar la ventana y la mantiene oculta
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        //Botón para visualizar reporte por previstas
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.reportePrevistas.Show();
        }
        //Botón para visualizar reporte por abonados
        private void btnAbonados_Click(object sender, RoutedEventArgs e)
        {
            this.reporteAbonados.Show();
        }
    }
}
