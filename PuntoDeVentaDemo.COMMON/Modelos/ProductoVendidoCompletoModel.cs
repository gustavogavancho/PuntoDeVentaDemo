using PuntoDeVentaDemo.COMMON.Entidades;

namespace PuntoDeVentaDemo.COMMON.Modelos
{
    /// <summary>
    /// Modelo de datos para la interfaz de usuario
    /// </summary>
    public class ProductoVendidoCompletoModel
    {
        #region Propiedades
        public productovendido Productovendido { get; set; }
        public producto Producto { get; set; }
        public decimal Total { get; set; }

        #endregion
    }
}
