using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using PuntoDeVentaDemo.COMMON.Validadores;

namespace PuntoDeVentaDemo.BIZ
{
    public class Factory
    {
        string _origen;

        public Factory(string origen)
        {
            _origen = origen;
        }

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

        public IProductoManager ProductoManager()
        {
            switch (_origen)
            {
                case "MySql":
                    return new ProductoManager(new DAL.XAMPP.MySQL.GenericRepository<producto>(new ProductoValidator(), false));
                case "MSSQL":
                    return new ProductoManager(new DAL.MSSqlLocal.SQLServer.GenericRepository<producto>(new ProductoValidator(), false));
                default:
                    return null;
            }
        }

        public IVentaManager VentaManager()
        {
            switch (_origen)
            {
                case "MySql":
                    return new VentaManager(new DAL.XAMPP.MySQL.GenericRepository<venta>(new VentaValidator(), false));
                case "MSSQL":
                    return new VentaManager(new DAL.MSSqlLocal.SQLServer.GenericRepository<venta>(new VentaValidator(), false));
                default:
                    return null;
            }
        }

        public IProductoVendidoManager ProductVendidoManager()
        {
            switch (_origen)
            {
                case "MySql":
                    return new ProductoVendidoManager(new DAL.XAMPP.MySQL.GenericRepository<productovendido>(new ProductoVendidoValidator(), false));
                case "MSSQL":
                    return new ProductoVendidoManager(new DAL.MSSqlLocal.SQLServer.GenericRepository<productovendido>(new ProductoVendidoValidator(), false));
                default:
                    return null;
            }
        }
    }
}