using PuntoDeVentaDemo.COMMON.Entidades;
using System.Collections.Generic;

namespace PuntoDeVentaDemo.COMMON.Interfaces
{
    /// <summary>
    /// Proporciona los métodos relacionados a los productos vendidos en las ventas
    /// </summary>
    public interface IProductoVendidoManager : IGenericManager<productovendido>
    {
        /// <summary>
        /// Obtiene los productos contenidos en una venta
        /// </summary>
        /// <param name="idVenta">Id de la venta</param>
        /// <returns>Conjunto de productos contenidos en una venta</returns>
        IEnumerable<productovendido> ProductosDeUnaVenta(int idVenta);
    }
}