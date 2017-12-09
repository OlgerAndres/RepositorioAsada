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
        private Sector actualSector = null;

        public Sectores()
        {
            InitializeComponent();
        }

        private void cargarSectores()
        {
            this.DgSectores.ItemsSource = this.sectores.listar();
        }

        private void habilitarCampos(bool bandera)
        {
            this.DgSectores.IsEnabled = bandera;
            this.btnAgregar.IsEnabled = bandera;
            this.btnModificar.IsEnabled = !bandera;
            this.btnEliminar.IsEnabled = !bandera;

            this.btnCancelar.Visibility = (bandera) ?
                System.Windows.Visibility.Hidden :
                System.Windows.Visibility.Visible;
        }

        private void limpiarCampos() {
            this.txtSector.Clear();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
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

            }catch(Exception ex){


                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sectores.actualizar(this.actualSector.Id, this.txtSector.Text);
                MessageBox.Show("Sector actualizado");
                this.cargarSectores();
                this.limpiarCampos();
                this.habilitarCampos(true);
            }catch(Exception ex){


                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sectores.borrar(this.actualSector.Id);
                MessageBox.Show("Sector eliminado");
                this.cargarSectores();
                this.limpiarCampos();
                this.habilitarCampos(true);
            }catch(Exception ex){


                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.limpiarCampos();
            this.habilitarCampos(true);
            this.Hide();
        }

        private void DgSectores_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.actualSector = this.DgSectores.CurrentItem as Sector;
            if (null == this.actualSector)
            {
                return;
            }
            this.actualSector = this.DgSectores.CurrentItem as Sector;
            this.txtSector.Text = this.actualSector.Descripcion;
            this.habilitarCampos(false);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.habilitarCampos(true);
            limpiarCampos();
        }

        private void prepararFormulario()
        {
            this.cargarSectores();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible)
            {
                this.prepararFormulario();
            }
        }
    }
}

