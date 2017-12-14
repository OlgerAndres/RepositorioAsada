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
using Microsoft.Reporting.WinForms;


namespace Asada
{
    /// <summary>
    /// Lógica de interacción para ReporteAbonados.xaml
    /// </summary>
    public partial class ReporteAbonados : Window
    {
        private bool _isReportViewerLoaded;
        //Inicializa el reporte de abonados
        public ReporteAbonados()
        {
            InitializeComponent();
            this._reportViewer2.Load += _reportViewer2_Load;
        }
        //Método para cargar  el reporte desde una lista de abonados
        private void _reportViewer2_Load(object sender, EventArgs e)
        {

            if (_isReportViewerLoaded)
            {
                return;
            }

            this._reportViewer2.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            AccionesAbonados abonado = new AccionesAbonados();


            Microsoft.Reporting.WinForms.ReportDataSource dataSource = new ReportDataSource("DataSet1", abonado.listar());
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

            this._reportViewer2.LocalReport.DataSources.Clear();
            this._reportViewer2.LocalReport.DataSources.Add(dataSource);

            this._reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer2.LocalReport.ReportEmbeddedResource = "Asada.ReporteAbonados.rdlc";

            _reportViewer2.RefreshReport();
            _isReportViewerLoaded = true;

        }


        //Método de cerrar la ventana y ocultarla
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

    }
}
