namespace PuntoDeVentaDemo.COMMON.Modelos
{
    /// <summary>
    /// Modelo de datos para la interfaz de usuario
    /// </summary>
    public class VentasDeProductosModel
    {
        #region Propiedades

        public int Id { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }

        #endregion
    }
}
