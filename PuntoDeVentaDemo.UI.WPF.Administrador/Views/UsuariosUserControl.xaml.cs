using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PuntoDeVentaDemo.UI.WPF.Administrador.Views
{
    /// <summary>
    /// Interaction logic for UsuariosUserControl.xaml
    /// </summary>
    public partial class UsuariosUserControl : UserControl
    {
        IUsuarioManager _usuarioManager;
        bool _esNuevo;
        public UsuariosUserControl()
        {
            InitializeComponent();
            _usuarioManager = Tools.Tools.FactoryManager.UsuarioManager();
            HabilitarCajas(false);
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            this.DataContext = new usuario();
            DtgDatos.ItemsSource = null;
            DtgDatos.ItemsSource = _usuarioManager.ObtenerTodo;
        }

        private void HabilitarCajas(bool isEnable)
        {
            ContenedorCampos.IsEnabled = isEnable;
            BtnNuevo.IsEnabled = !isEnable;
            BtnEditar.IsEnabled = !isEnable;
            BtnGuardar.IsEnabled = isEnable;
            BtnEliminar.IsEnabled = !isEnable;
            BtnCancelar.IsEnabled = isEnable;
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            _esNuevo = true;
            this.DataContext = new usuario();
            HabilitarCajas(true);
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (_esNuevo)
            {
                if (_usuarioManager.Insertar(this.DataContext as usuario))
                {
                    MessageBox.Show("Usuario insertado", "Tienda", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show(_usuarioManager.Error, "Tienda", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (_usuarioManager.Actualizar(this.DataContext as usuario))
                {
                    MessageBox.Show("Usuario actualizado", "Tienda", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show(_usuarioManager.Error, "Tienda", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            _esNuevo = true;
            this.DataContext = new usuario();
            HabilitarCajas(false);
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            usuario usr = DtgDatos.SelectedItem as usuario;
            if (usr != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar al usuario " + usr.Nombres + "?", "Tienda", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (_usuarioManager.Eliminar(usr.NombreDeUsuario))
                    {
                        MessageBox.Show("Usuario eliminado correctamente", "Tienda", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTabla();
                    }
                    else
                    {
                        MessageBox.Show(_usuarioManager.Error, "Tienda", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar un usuario", "Tienda", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            usuario usr = DtgDatos.SelectedItem as usuario;
            if (usr != null)
            {
                this.DataContext = usr;
                _esNuevo = false;
                HabilitarCajas(true);
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar un usuario", "Tienda", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
