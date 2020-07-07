using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using System;
using System.Collections.Generic;

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
    }
}
