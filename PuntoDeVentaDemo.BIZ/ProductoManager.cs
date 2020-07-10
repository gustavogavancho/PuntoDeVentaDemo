using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PuntoDeVentaDemo.BIZ
{
    public class ProductoManager : GenericManager<producto>, IProductoManager
    {
        #region Constructor

        public ProductoManager(IGenericRepository<producto> repositorio) : base(repositorio)
        {
        }

        #endregion

        #region Métodos
        public producto BuscarProductoPorNombreExacto(string nombre)
        {
            return _repositorio.Query(x => x.Nombre == nombre).SingleOrDefault();
        }

        public IEnumerable<producto> BuscarProductosPorNombre(string criterio)
        {
            return _repositorio.Query(x => x.Nombre.ToLower().Contains(criterio.ToLower()));
        }

        #endregion
    }
}