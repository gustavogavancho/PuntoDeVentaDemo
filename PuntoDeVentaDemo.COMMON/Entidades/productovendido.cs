namespace PuntoDeVentaDemo.COMMON.Entidades
{
    public class productovendido : BaseDTO
    {
        #region Propiedades
        public int IdProductoVendido { get; set; }
        public int IdVenta { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }

        #endregion
    }
}