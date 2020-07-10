using PuntoDeVentaDemo.COMMON.Entidades;
using System.Collections.Generic;

namespace PuntoDeVentaDemo.COMMON.Interfaces
{
    /// <summary>
    /// Proporcionar los métodos relacionados a los productos
    /// </summary>
    public interface IProductoManager: IGenericManager<producto>
    {
        #region Métodos

        /// <summary>
        /// Método para buscar productos por nombres de la entidad producto
        /// </summary>
        /// <param name="criterio">Nombre a buscar</param>
        /// <returns>Lista de productos que cumplen el criterio de búsqueda</returns>
        IEnumerable<producto> BuscarProductosPorNombre(string criterio);

        /// <summary>
        /// Método para buscar un producto por el nombre exacto
        /// </summary>
        /// <param name="nombre">Nombre exacto a buscar</param>
        /// <returns>Producto que cumple con el criterio exacto de la búsqueda</returns>
        producto BuscarProductoPorNombreExacto(string nombre);

        #endregion

    }
}