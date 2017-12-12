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
    /// Lógica de interacción para ReportePrevistas.xaml
    /// </summary>
    public partial class ReportePrevistas : Window
    {

        private IServiciosPrevistas previstas = new AccionesPrevistas();




        public ReportePrevistas()
        {
            InitializeComponent();
        }

        private void CrystalReportsViewer_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource previstaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("previstaViewSource")));
            // Cargar datos estableciendo la propiedad CollectionViewSource.Source:
            // previstaViewSource.Source = [origen de datos genérico]
        }


        //private void cargarPrevistas()
        //{
        //    this.previstaDataGrid.ItemsSource = this.previstas.listar();
        //}

    }
}
