using Microsoft.Reporting.WinForms;
using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PuntoDeVentaDemo.UI.WPF.Administrador.Views
{
    /// <summary>
    /// Interaction logic for ProductosUserControl.xaml
    /// </summary>
    public partial class ProductosUserControl : UserControl
    {
        IProductoManager _productoManager;
        bool _esNuevo;
        public ProductosUserControl()
        {
            InitializeComponent();
            _productoManager = Tools.Tools.FactoryManager.ProductoManager();
            HabilitarCajas(false);
            ActualizarTabla();
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
            this.DataContext = new producto();
            HabilitarCajas(true);
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (_esNuevo)
            {
                if (_productoManager.Insertar(this.DataContext as producto))
                {
                    MessageBox.Show("Producto insertado", "Tienda", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show(_productoManager.Error, "Tienda", MessageBoxButton.OK, MessageBoxImage.Error); 
                }
            }
            else
            {
                if (_productoManager.Actualizar(this.DataContext as producto))
                {
                    MessageBox.Show("Producto actualizado", "Tienda", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show(_productoManager.Error, "Tienda", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            _esNuevo = true;
            this.DataContext = new producto();
            HabilitarCajas(false);
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            producto prod = DtgDatos.SelectedItem as producto;
            if (prod != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar al producto " + prod.Nombre + "?", "Tienda", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (_productoManager.Eliminar(prod.IdProducto.ToString()))
                    {
                        MessageBox.Show("Producto eliminado correctamente", "Tienda", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTabla();
                    }
                    else
                    {
                        MessageBox.Show(_productoManager.Error, "Tienda", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar un producto", "Tienda", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ActualizarTabla()
        {
            this.DataContext = new producto();
            DtgDatos.ItemsSource = null;
            DtgDatos.ItemsSource = _productoManager.ObtenerTodo;
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            producto prod = DtgDatos.SelectedItem as producto;
            if (prod != null)
            {
                this.DataContext = prod;
                _esNuevo = false;
                HabilitarCajas(true);
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar un producto", "Tienda", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            List<ReportDataSource> datos = new List<ReportDataSource>();
            ReportDataSource productos = new ReportDataSource();
            productos.Name = "Productos";
            productos.Value = _productoManager.ObtenerTodo;
            datos.Add(productos);
            Reporteador ventana = new Reporteador("PuntoDeVentaDemo.UI.WPF.Administrador.Reportes.ListadoProductos.rdlc", datos);
            ventana.Show();
        }
    }
}
