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
    /// Interaction logic for NuevaVentaUserControl.xaml
    /// </summary>
    public partial class NuevaVentaUserControl : UserControl
    {
        IProductoManager _productoManager;
        IVentaManager _ventaManager;
        IProductoVendidoManager _productoVendidoManager;
        usuario _vendedor;
        List<productovendido> _productos;
        public NuevaVentaUserControl()
        {
            InitializeComponent();
            _productoManager = Tools.Tools.FactoryManager.ProductoManager();
            _ventaManager = Tools.Tools.FactoryManager.VentaManager();
            _productoVendidoManager = Tools.Tools.FactoryManager.ProductVendidoManager();
            _vendedor = Tools.Tools.Usuario;
            CmbProducto.ItemsSource = _productoManager.ObtenerTodo;
            _productos = new List<productovendido>();
            ActualizarTabla();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (_productos.Count() > 0)
            {
                venta venta = new venta()
                {
                    Cliente = TxtCliente.Text,
                    FechaHora = DateTime.Now,
                    NombreDeUsuario = _vendedor.NombreDeUsuario,
                };
                if (_ventaManager.Insertar(venta))
                {
                    int idVenta = _ventaManager.ObtenerTodo.Max(v => v.IdVenta);
                    foreach (var item in _productos)
                    {
                        item.IdVenta = idVenta;
                        _productoVendidoManager.Insertar(item);
                    }
                    MessageBox.Show("Venta realizada...Gracias por su compra!!!", "Tienda", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("No se han agregado productos a la venta", "Tienda", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BtnAgregarArticulo_Click(object sender, RoutedEventArgs e)
        {
            producto elemento = CmbProducto.SelectedItem as producto;
            if (elemento != null)
            {
                _productos.Add(new productovendido()
                {
                    Cantidad = int.Parse(TxtCantidad.Text),
                    Costo = elemento.Costo,
                    IdProducto = elemento.IdProducto
                });
                ActualizarTabla();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado producto a vender", "Tienda", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ActualizarTabla()
        {
            DtgDatos.ItemsSource = null;
            DtgDatos.ItemsSource = _productos;
            LblTotal.Content = _productos.Sum(p => p.Cantidad * p.Costo);
        }

        private void BtnEliminarArticulo_Click(object sender, RoutedEventArgs e)
        {
            productovendido elemento = DtgDatos.SelectedItem as productovendido;
            if (elemento !=  null)
            {
                _productos.Remove(elemento);
                ActualizarTabla();
            }
            else
            {
                MessageBox.Show("No se ha selecciona producto", "Tienda", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
