using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PuntoDeVentaDemo.BIZ
{
    public class ProductoVendidoManager : GenericManager<productovendido>, IProductoVendidoManager
    {
        public ProductoVendidoManager(IGenericRepository<productovendido> repositorio) : base(repositorio)
        {
        }

        public IEnumerable<productovendido> ProductosDeUnaVenta(int idVenta)
        {
            return _repositorio.Query(p => p.IdVenta == idVenta);
        }

        public int TotalDeProductosVendidos(int idProducto)
        {
            return _repositorio.Query(p => p.IdProducto == idProducto).Sum(v => v.Cantidad);
        }
    }
}
