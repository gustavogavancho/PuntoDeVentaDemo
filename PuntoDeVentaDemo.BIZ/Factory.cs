using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using PuntoDeVentaDemo.COMMON.Validadores;

namespace PuntoDeVentaDemo.BIZ
{
    /// <summary>
    /// Proporciona la creación de objetos según el parámetro de base de datos que uno indique (SQL Server o MySql)
    /// </summary>
    public class Factory
    {
        #region Variable

        /// <summary>
        /// Variable de seleccion de origen
        /// </summary>
        string _origen;

        #endregion

        #region Constructor

        /// <summary>
        /// Construuye un objeto de la clase y asigna el origen según lo requiera (SQL Server o MySql)
        /// </summary>
        /// <param name="origen"></param>
        public Factory(string origen)
        {
            _origen = origen;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Crea una instancia de Usuario Manager según el origien seleccioando
        /// </summary>
        /// <returns>Instancia de usuario manager</returns>
        public IUsuarioManager UsuarioManager()
        {
            switch (_origen)
            {
                case "MySql":
                    return new UsuarioManager(new DAL.XAMPP.MySQL.GenericRepository<usuario>(new UsuarioValidator(), false));
                case "MSSQL":
                    return new UsuarioManager(new DAL.MSSqlLocal.SQLServer.GenericRepository<usuario>(new UsuarioValidator(), false));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Crea una instancia de Producto Manager según el origen seleccionado
        /// </summary>
        /// <returns>Instancia de producto manager</returns>
        public IProductoManager ProductoManager()
        {
            switch (_origen)
            {
                case "MySql":
                    return new ProductoManager(new DAL.XAMPP.MySQL.GenericRepository<producto>(new ProductoValidator()));
                case "MSSQL":
                    return new ProductoManager(new DAL.MSSqlLocal.SQLServer.GenericRepository<producto>(new ProductoValidator()));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Crea una instancia de Venta Manager según el origen seleccionado
        /// </summary>
        /// <returns>Instancia de venta manager</returns>
        public IVentaManager VentaManager()
        {
            switch (_origen)
            {
                case "MySql":
                    return new VentaManager(new DAL.XAMPP.MySQL.GenericRepository<venta>(new VentaValidator()), ProductVendidoManager(), UsuarioManager(), ProductoManager());
                case "MSSQL":
                    return new VentaManager(new DAL.MSSqlLocal.SQLServer.GenericRepository<venta>(new VentaValidator()), ProductVendidoManager(), UsuarioManager(), ProductoManager());
                default:
                    return null;
            }
        }

        /// <summary>
        /// Crea una instancia de ProductoVendido Manager según el origen seleccionado
        /// </summary>
        /// <returns>Instancia de Producto Manager</returns>
        public IProductoVendidoManager ProductVendidoManager()
        {
            switch (_origen)
            {
                case "MySql":
                    return new ProductoVendidoManager(new DAL.XAMPP.MySQL.GenericRepository<productovendido>(new ProductoVendidoValidator()));
                case "MSSQL":
                    return new ProductoVendidoManager(new DAL.MSSqlLocal.SQLServer.GenericRepository<productovendido>(new ProductoVendidoValidator()));
                default:
                    return null;
            }
        }

        #endregion
    }
}