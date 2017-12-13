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
using Microsoft.Reporting.WinForms;

namespace Asada
{
    /// <summary>
    /// Interaction logic for ReportePrevistas.xaml
    /// </summary>
    public partial class ReportePrevistas : Window
    {
        private bool _isReportViewerLoaded;

        public ReportePrevistas()
        {
            InitializeComponent();
            this._reportViewer.Load += _reportViewer_Load;
        }

        private void _reportViewer_Load(object sender, EventArgs e)
        {
            if (_isReportViewerLoaded)
            {
                return;
            }

            Microsoft.Reporting.WinForms.ReportDataSource dataSource = new ReportDataSource("DataSet1", new ASADAEntidades().PrevistaVistas.ToList());

            this._reportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this._reportViewer.LocalReport.DataSources.Clear();
            this._reportViewer.LocalReport.DataSources.Add(dataSource);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "Asada.ReportePrevistaVista.rdlc";
            this._reportViewer.RefreshReport();
            this._isReportViewerLoaded = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.lblSINPE.Content = Asada.Properties.Settings.Default.SINPE.ToString();
        }
    }
}
