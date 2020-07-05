using PuntoDeVentaDemo.COMMON.Entidades;
using System.Collections.Generic;

namespace PuntoDeVentaDemo.COMMON.Interfaces
{
    /// <summary>
    /// Proporcionar los métodos relacionados a los productos
    /// </summary>
    public interface IProductoManager: IGenericManager<producto>
    {
        IEnumerable<producto> BuscarProductosPorNombre(string criterio);

        producto BuscarProductoPorNombreExacto(string nombre);
    }
}