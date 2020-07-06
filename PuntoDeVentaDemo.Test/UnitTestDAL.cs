using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using PuntoDeVentaDemo.COMMON.Validadores;
using PuntoDeVentaDemo.DAL.XAMPP.MySQL;

namespace PuntoDeVentaDemo.Test
{
    [TestClass]
    public class UnitTestDAL
    {
        IGenericRepository<producto> productosRepository;
        Random r;

        public UnitTestDAL()
        {
            r = new Random();
            productosRepository = new GenericRepository<producto>(new ProductoValidator());
        }


        [TestMethod]
        public void TestMethodProductos()
        {
            //Creamos un producto de prueba
            producto p = CrearProductoDePrueba();

            //Obtenemos la cantidad de productos actuales en la base de datos
            int cantidadProductos = productosRepository.Read.Count();

            //Insertamos el producto de prueba
            Assert.IsTrue(productosRepository.Create(p), productosRepository.Error);

            //Verificamos que la cantidad de productos se incremento en uno despues de ingresar el producto
            Assert.AreEqual(cantidadProductos + 1, productosRepository.Read.Count(), "No se inserto el registro");
            
            //Obtengo el último Id
            int ultimoId = productosRepository.Read.Max(j => j.IdProducto);
            
            //Obtengo el último registros en base al Id obtenido
            producto modificado = productosRepository.SearchById(ultimoId.ToString());

            //Modifico el nombre
            modificado.Nombre = "Modificado";

            //Mando a actualizar
            Assert.IsTrue(productosRepository.Update(modificado), productosRepository.Error);

            //Obtengo el producto modificado
            producto modificado2 = productosRepository.SearchById(ultimoId.ToString());

            //Verifico que se modifico realmente
            Assert.AreEqual("Modificado", modificado2.Nombre, "Realmente no se actualizo el producto");

            //Mando a eliminar el registro
            Assert.IsTrue(productosRepository.Delete(ultimoId.ToString()), productosRepository.Error);

            //Verifico que realmente se elimino, comprobando que no se afecto el numero de registros totales
            Assert.AreEqual(cantidadProductos, productosRepository.Read.Count(), "No se elimino el producto");
        }

        private producto CrearProductoDePrueba()
        {
            return new producto()
            {
                Costo = r.Next(1, 100),
                Nombre = "Producto de prueba" + r.Next(),
            };
        }
    }
}
