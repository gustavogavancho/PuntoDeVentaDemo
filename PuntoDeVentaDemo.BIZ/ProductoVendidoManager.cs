using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PuntoDeVentaDemo.BIZ
{
    public class ProductoVendidoManager : GenericManager<productovendido>, IProductoVendidoManager
    {
        #region Constructor
        public ProductoVendidoManager(IGenericRepository<productovendido> repositorio) : base(repositorio)
        {
        }

        #endregion

        #region Métodos
        public IEnumerable<productovendido> ProductosDeUnaVenta(int idVenta)
        {
            return _repositorio.Query(p => p.IdVenta == idVenta);
        }

        public int TotalDeProductosVendidos(int idProducto)
        {
            return _repositorio.Query(p => p.IdProducto == idProducto).Sum(v => v.Cantidad);
        }

        #endregion
    }
}
