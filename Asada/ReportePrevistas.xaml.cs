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

            this._reportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            AccionesPrevistas previstas = new AccionesPrevistas();

            Microsoft.Reporting.WinForms.ReportDataSource dataSource = new ReportDataSource("DataSet1", previstas.listar());
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

            this._reportViewer.LocalReport.DataSources.Clear();
            this._reportViewer.LocalReport.DataSources.Add(dataSource);

            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "Asada.Report1.rdlc";

            _reportViewer.RefreshReport();
            _isReportViewerLoaded = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
