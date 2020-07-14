namespace PuntoDeVentaDemo.COMMON.Modelos
{
    /// <summary>
    /// Modelo de datos para la interfaz de usuario
    /// </summary>
    public class VentasPorMesModel
    {
        #region Propiedades
        public int Id { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public decimal Cantidad { get; set; }

        #endregion
    }
}
