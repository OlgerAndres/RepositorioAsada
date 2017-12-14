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
        //Implementación de las clases de lógica
        private IServiciosSectores sectores = new AccionesSectores();
        private Sector actualSector = null;

        public Sectores()
        {
            InitializeComponent();
        }
        //Método de visualizar los sectores
        private void cargarSectores()
        {
            this.DgSectores.ItemsSource = this.sectores.listar();
        }
        //Método de habilitar los botones del formulario
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

        //Método de limpiar los campos del formulario
        private void limpiarCampos() {
            this.txtSector.Clear();
        }

        //Botón de agregar una nuevo sector
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
                MessageBox.Show("Sector agregado", "Información", MessageBoxButton.OK);
                this.cargarSectores();
                this.txtSector.Clear();

            }catch(Exception ex){


                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Modifica un sector existente
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sectores.actualizar(this.actualSector.Id, this.txtSector.Text);
                MessageBox.Show("Sector actualizado", "Información", MessageBoxButton.OK);
                this.cargarSectores();
                this.limpiarCampos();
                this.habilitarCampos(true);
            }catch(Exception ex){


                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Botón de eliminar un sector existente
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sectores.borrar(this.actualSector.Id);
                MessageBox.Show("Sector eliminado", "Información", MessageBoxButton.OK);
                this.cargarSectores();
                this.limpiarCampos();
                this.habilitarCampos(true);
            }catch(Exception ex){


                MessageBox.Show("Error,intentelo de nuevo. (" + ex.GetBaseException().Message + ")", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Método para cerrar la ventana del formulario,además de limpiar los campos y habilitar los botones
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.limpiarCampos();
            this.habilitarCampos(true);
            this.Hide();
        }
        //Evento del datagrid para seleccionar un sector
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
        //Botón de cancelar acciones
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.habilitarCampos(true);
            limpiarCampos();
        }
        //Prepara el formulario,cada vez que se carga
        private void prepararFormulario()
        {
            this.cargarSectores();
        }
        //Muestra el  datagrid del formulario, cuando se abre la ventana
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible)
            {
                this.prepararFormulario();
            }
        }
    }
}

