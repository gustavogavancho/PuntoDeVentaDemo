using PuntoDeVentaDemo.COMMON.Entidades;

namespace PuntoDeVentaDemo.COMMON.Modelos
{
    public class ProductoVendidoCompletoModel
    {
        #region Propiedades
        public productovendido Productovendido { get; set; }
        public producto Producto { get; set; }
        public decimal Total { get; set; }

        #endregion
    }
}
