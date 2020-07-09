using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using PuntoDeVentaDemo.COMMON.Modelos;
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
    /// Interaction logic for HomeUserControl.xaml
    /// </summary>
    public partial class HomeUserControl : UserControl
    {
        IProductoVendidoManager _productoVendidoManager;
        IProductoManager _productoManager;
        IVentaManager _ventaManager;
        public HomeUserControl()
        {
            InitializeComponent();
            _productoVendidoManager = Tools.Tools.FactoryManager.ProductVendidoManager();
            _productoManager = Tools.Tools.FactoryManager.ProductoManager();
            _ventaManager = Tools.Tools.FactoryManager.VentaManager();

            List<VentasDeProductosModel> productos = new List<VentasDeProductosModel>();
            int i = 1;
            foreach (var item in _productoManager.ObtenerTodo)
            {
                productos.Add(new VentasDeProductosModel() 
                {
                    Id = i++,
                    Producto = item.Nombre,
                    Cantidad = _productoVendidoManager.TotalDeProductosVendidos(item.IdProducto),
                });
            }

            Grafica(productos);

            i = 1;
            List<VentasPorMesModel> ventas = new List<VentasPorMesModel>();
            List<venta> todasLasVentas = _ventaManager.ObtenerTodo.ToList();
            venta primeraVenta = todasLasVentas.OrderBy(v => v.FechaHora).First();
            venta ultimaVenta = todasLasVentas.OrderByDescending(v => v.FechaHora).First();
            int anio = primeraVenta.FechaHora.Year;
            int mes = primeraVenta.FechaHora.Month;

            List<VentaCompletaModel> ventasCompletas = _ventaManager.VentasEnIntervalo(primeraVenta.FechaHora, ultimaVenta.FechaHora).ToList();

            while (anio <= ultimaVenta.FechaHora.Year)
            {
                while (mes <= 12)
                {
                    if (anio == ultimaVenta.FechaHora.Year && mes > ultimaVenta.FechaHora.Month)
                    {
                        break;
                    }
                    ventas.Add(new VentasPorMesModel()
                    {
                        Id = i++,
                        Anio = anio,
                        Mes = mes,
                        Cantidad = ventasCompletas.Where(v => v.Venta.FechaHora.Year == anio && v.Venta.FechaHora.Month == mes).Sum(x => x.TotalDeVenta),
                    });
                    mes++;
                    if (mes == 13)
                    {
                        mes = 1;
                        break;
                    }
                }
                anio++;
            }
            Grafica(ventas);
        }

        private void Grafica(List<VentasPorMesModel> ventas)
        {
            DtgVentas.ItemsSource = ventas;
            PlotModel model = new PlotModel();
            LinearAxis ejeX = new LinearAxis();
            ejeX.Position = AxisPosition.Bottom;
            LinearAxis ejeY = new LinearAxis();
            ejeY.Position = AxisPosition.Left;
            model.Axes.Add(ejeX);
            model.Axes.Add(ejeY);
            model.Title = "Ventas por mes";
            LineSeries line = new LineSeries();
            foreach (var item in ventas)
            {
                line.Points.Add(new DataPoint(item.Id,(double)item.Cantidad));
            }
            line.Title = "Monto $";
            model.Series.Add(line);
            PlotVentas.Model = model;
        }

        private void Grafica(List<VentasDeProductosModel> productos)
        {
            DtgProductos.ItemsSource = productos;
            PlotModel model = new PlotModel();
            LinearAxis ejeX = new LinearAxis();
            ejeX.Position = AxisPosition.Bottom;
            LinearAxis ejeY = new LinearAxis();
            ejeY.Position = AxisPosition.Left;
            model.Axes.Add(ejeX);
            model.Axes.Add(ejeY);
            model.Title = "Productos Vendidos";
            LineSeries line = new LineSeries();
            foreach (var item in productos)
            {
                line.Points.Add(new DataPoint(item.Id, item.Cantidad));
            }

            model.Series.Add(line);
            PlotProducto.Model = model;
        }
    }
}
