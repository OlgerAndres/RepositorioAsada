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
        private IServiciosSectores sectores = new AccionesSectores();

        public Sectores()
        {
            InitializeComponent();
        }

        private void cargarSectores()
        {
            this.DgSectores.ItemsSource = this.sectores.listar();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSector.Text))
            {
                MessageBox.Show("Sector es requerido.");
                return;
            }
            this.sectores.agregar(this.txtSector.Text);
            MessageBox.Show("Sector agregado");
            this.cargarSectores();
            this.txtSector.Clear();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.cargarSectores();
        }

        private void DgSectores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgSectores.SelectedIndex != -1)
            {

                Sector sector = this.DgSectores.SelectedItem as Sector;
                this.txtSector.Text = sector.Descripcion;
            }
            else
            {
                MessageBox.Show("Selecciona el sector que deseas mostrar");
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Sector sector = this.DgSectores.CurrentItem as Sector;
            this.sectores.actualizar(sector.Id, this.txtSector.Text);
            MessageBox.Show("Sector actualizado");
            this.cargarSectores();
            this.txtSector.Clear();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Sector sector = this.DgSectores.SelectedItem as Sector;
            this.sectores.borrar(sector.Id);
            MessageBox.Show("Sector eliminado");
            this.cargarSectores();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}

