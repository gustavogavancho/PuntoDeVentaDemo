using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using PuntoDeVentaDemo.COMMON.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PuntoDeVentaDemo.BIZ
{
    public class VentaManager : GenericManager<venta>, IVentaManager
    {
        IProductoVendidoManager _productoVendidoManager;
        IUsuarioManager _usuarioManager;
        IProductoManager _productoManager;

        public VentaManager(IGenericRepository<venta> repositorio, IProductoVendidoManager productoVendidoManager, IUsuarioManager usuarioManager, IProductoManager productoManager) : base(repositorio)
        {
            _productoVendidoManager = productoVendidoManager;
            _usuarioManager = usuarioManager;
            _productoManager = productoManager;
        }

        public IEnumerable<VentaCompletaModel> VentasDeClienteEnIntervalor(string nombreCliente, DateTime inicio, DateTime fin)
        {
            DateTime rInicio = new DateTime(inicio.Year, inicio.Month, inicio.Day, 0, 0, 0);
            DateTime rFin = new DateTime(fin.Year, fin.Month, fin.Day, 0, 0, 0).AddDays(1);
            return CompletaVentas(_repositorio.Query(v => v.FechaHora >= rInicio && v.FechaHora <= rFin && v.Cliente == nombreCliente));
        }

        public IEnumerable<VentaCompletaModel> VentasEnIntervalo(DateTime inicio, DateTime fin)
        {
            DateTime rInicio = new DateTime(inicio.Year, inicio.Month, inicio.Day, 0,0,0);
            DateTime rFin = new DateTime(fin.Year, fin.Month, fin.Day, 0, 0, 0).AddDays(1);
            var ventas = _repositorio.Query(v => v.FechaHora >= rInicio && v.FechaHora <= rFin);
            return CompletaVentas(ventas);
        }

        private IEnumerable<VentaCompletaModel> CompletaVentas(IEnumerable<venta> ventas)
        {
            List<VentaCompletaModel> datos = new List<VentaCompletaModel>();
            foreach (var item in ventas)
            {
                VentaCompletaModel dato = new VentaCompletaModel();
                dato.Venta = item;
                dato.ProductosVendidos = CompletaProductos(_productoVendidoManager.ProductosDeUnaVenta(item.IdVenta));
                dato.TotalDeVenta = dato.ProductosVendidos.Sum(p => p.Total);
                dato.Vendedor = _usuarioManager.BuscarPorId(item.NombreDeUsuario);
                datos.Add(dato);
            }
            return datos;
        }

        private List<ProductoVendidoCompletoModel> CompletaProductos(IEnumerable<productovendido> productos)
        {
            List<ProductoVendidoCompletoModel> datos = new List<ProductoVendidoCompletoModel>();
            foreach (var item in productos)
            {
                ProductoVendidoCompletoModel dato = new ProductoVendidoCompletoModel();
                dato.Producto = _productoManager.BuscarPorId(item.IdProducto.ToString());
                dato.Productovendido = item;
                dato.Total = item.Cantidad * item.Costo;
                datos.Add(dato);
            }
            return datos;
        }
    }
}