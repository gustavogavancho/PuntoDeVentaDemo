using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using PuntoDeVentaDemo.COMMON.Validadores;
using PuntoDeVentaDemo.DAL.XAMPP.MySQL;
//using PuntoDeVentaDemo.DAL.MSSqlLocal.SQLServer;

namespace PuntoDeVentaDemo.Test
{
    [TestClass]
    public class UnitTestDAL
    {
        #region Variables

        IGenericRepository<producto> _productosRepository;
        IGenericRepository<usuario> _usuarioRepository;
        IGenericRepository<venta> _ventaRepository;
        IGenericRepository<productovendido> _productoVendidoRepository;
        Random _r;

        #endregion

        #region Constructor
        public UnitTestDAL()
        {
            _r = new Random();
            _productosRepository = new GenericRepository<producto>(new ProductoValidator());
            _usuarioRepository = new GenericRepository<usuario>(new UsuarioValidator(), false);
            _ventaRepository = new GenericRepository<venta>(new VentaValidator());
            _productoVendidoRepository = new GenericRepository<productovendido>(new ProductoVendidoValidator());
        }

        #endregion

        #region Métodos
        private venta CreaVentaDePrueba(string vendedor)
        {
            return new venta()
            {
                Cliente = "Cliente De Prueba",
                FechaHora = DateTime.Now,
                NombreDeUsuario = vendedor,
            };
        }

        private usuario CreaUsuarioDePrueba()
        {
            return new usuario()
            {
                NombreDeUsuario = "PruebaUser",
                Apellidos = "User",
                Nombres = "Prueba",
                Password = "12345",
            };
        }

        private producto CrearProductoDePrueba()
        {
            return new producto()
            {
                Costo = _r.Next(1, 100),
                Nombre = "Producto de prueba" + _r.Next(),
            };
        }

        #endregion

        #region TestMethods

        [TestMethod]
        public void TestProductos()
        {
            //Creamos un producto de prueba
            producto p = CrearProductoDePrueba();

            //Obtenemos la cantidad de productos actuales en la base de datos
            int cantidadProductos = _productosRepository.Read.Count();

            //Insertamos el producto de prueba
            Assert.IsTrue(_productosRepository.Create(p), _productosRepository.Error);

            //Verificamos que la cantidad de productos se incremento en uno despues de ingresar el producto
            Assert.AreEqual(cantidadProductos + 1, _productosRepository.Read.Count(), "No se inserto el registro");

            //Obtengo el último Id
            int ultimoId = _productosRepository.Read.Max(j => j.IdProducto);

            //Obtengo el último registros en base al Id obtenido
            producto modificado = _productosRepository.SearchById(ultimoId.ToString());

            //Modifico el nombre
            modificado.Nombre = "Modificado";

            //Mando a actualizar
            Assert.IsTrue(_productosRepository.Update(modificado), _productosRepository.Error);

            //Obtengo el producto modificado
            producto modificado2 = _productosRepository.SearchById(ultimoId.ToString());

            //Verifico que se modifico realmente
            Assert.AreEqual("Modificado", modificado2.Nombre, "Realmente no se actualizo el producto");

            //Mando a eliminar el registro
            Assert.IsTrue(_productosRepository.Delete(ultimoId.ToString()), _productosRepository.Error);

            //Verifico que realmente se elimino, comprobando que no se afecto el numero de registros totales
            Assert.AreEqual(cantidadProductos, _productosRepository.Read.Count(), "No se elimino el producto");
        }

        [TestMethod]
        public void TestUsuario()
        {
            usuario u = CreaUsuarioDePrueba();
            int cantidad = _usuarioRepository.Read.Count();
            Assert.IsTrue(_usuarioRepository.Create(u), _usuarioRepository.Error);
            Assert.AreEqual(cantidad + 1, _usuarioRepository.Read.Count(), "No se inserto en registro");
            usuario aModificar = _usuarioRepository.Query(p => p.NombreDeUsuario == "PruebaUser").SingleOrDefault();
            aModificar.Nombres = "Modificado";
            Assert.IsTrue(_usuarioRepository.Update(aModificar), _usuarioRepository.Error);
            usuario modificado = _usuarioRepository.Query(p => p.NombreDeUsuario == "PruebaUser").SingleOrDefault();
            Assert.AreEqual("Modificado", modificado.Nombres, "El nombre no fue modificado");
            Assert.IsTrue(_usuarioRepository.Delete("PruebaUser"), _usuarioRepository.Error);
            Assert.AreEqual(cantidad, _usuarioRepository.Read.Count(), "No se elimino el registro");
        }

        [TestMethod]
        public void TestVenta()
        {
            usuario usuarioDePrueba = CreaUsuarioDePrueba();
            Assert.IsTrue(_usuarioRepository.Create(usuarioDePrueba), _usuarioRepository.Error);
            venta venta = CreaVentaDePrueba(usuarioDePrueba.NombreDeUsuario);
            Assert.IsTrue(_ventaRepository.Create(venta), _ventaRepository.Error);
            int idUltimaVenta = _ventaRepository.Read.Max(v => v.IdVenta);
            List<producto> productosDePrueba = new List<producto>();
            int cantidadProductosVendidos = _productoVendidoRepository.Read.Count();
            for (int i = 0; i < 10; i++)
            {
                Assert.IsTrue(_productosRepository.Create(CrearProductoDePrueba()), _productosRepository.Error);
                int idProducto = _productosRepository.Read.Max(p => p.IdProducto);
                producto ultimo = _productosRepository.SearchById(idProducto.ToString());
                productosDePrueba.Add(ultimo);
                productovendido vendido = new productovendido()
                {
                    Cantidad = _r.Next(1, 10),
                    Costo = ultimo.Costo,
                    IdProducto = ultimo.IdProducto,
                    IdVenta = idUltimaVenta,
                };
                Assert.IsTrue(_productoVendidoRepository.Create(vendido), _productoVendidoRepository.Error);
            }
            int cantidadActual = _productosRepository.Read.Count();
            Assert.AreEqual(cantidadProductosVendidos + 10, cantidadActual, "No se insertaron los 10 registros");
            venta ventaAModificar = _ventaRepository.SearchById(idUltimaVenta.ToString());
            ventaAModificar.Cliente = "Modificado";
            Assert.IsTrue(_ventaRepository.Update(ventaAModificar), _ventaRepository.Error);
            List<productovendido> vendidos = _productoVendidoRepository.Query(p => p.IdVenta == idUltimaVenta).ToList();
            foreach (var item in vendidos)
            {
                Assert.IsTrue(_productoVendidoRepository.Delete(item.IdProductoVendido.ToString()), _productoVendidoRepository.Error);
            }
            Assert.AreEqual(cantidadProductosVendidos, _productoVendidoRepository.Read.Count(), "No se eliminaron los productos vendidos");
            Assert.IsTrue(_ventaRepository.Delete(idUltimaVenta.ToString()), _ventaRepository.Error);
            foreach (var item in productosDePrueba)
            {
                Assert.IsTrue(_productosRepository.Delete(item.IdProducto.ToString()), _productosRepository.Error);
            }
            Assert.IsTrue(_usuarioRepository.Delete(usuarioDePrueba.NombreDeUsuario), _usuarioRepository.Error);
        }

        #endregion
    }
}
