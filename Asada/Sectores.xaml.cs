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
    /// Interaction logic for Sectores.xaml
    /// </summary>
    public partial class Sectores : Window
    {
        private IServiciosSectores sector = new AccionesSectores();
        public Sectores()
        {
            InitializeComponent();
        }

        private void cargarSectores()
        {
            this.DgSectores.ItemsSource = sector.listar();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            this.sector.agregar(this.txtSector.Text);
            this.cargarSectores();
            txtSector.Clear();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Sector sector = this.DgSectores.CurrentItem as Sector;
            this.sector.actualizar(sector.Id, sector.Descripcion);
            this.cargarSectores();
            txtSector.Clear();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Sector sector = this.DgSectores.SelectedItem as Sector;
            this.sector.borrar(sector.Id);
            MessageBox.Show("Sector eliminado");
            this.cargarSectores();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cargarSectores();
        }
    }
}
