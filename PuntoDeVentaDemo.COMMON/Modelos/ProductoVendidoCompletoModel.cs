using PuntoDeVentaDemo.COMMON.Entidades;

namespace PuntoDeVentaDemo.COMMON.Modelos
{
    public class ProductoVendidoCompletoModel
    {
        public productovendido  Productovendido { get; set; }
        public producto Producto { get; set; }
        public decimal Total { get; set; }
    }
}
