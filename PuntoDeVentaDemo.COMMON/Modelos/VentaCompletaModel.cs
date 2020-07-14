using PuntoDeVentaDemo.COMMON.Entidades;
using System.Collections.Generic;

namespace PuntoDeVentaDemo.COMMON.Modelos
{
    /// <summary>
    /// Modelo de datos para la interfaz de usuario
    /// </summary>
    public class VentaCompletaModel
    {
        #region Propiedades
        public venta Venta { get; set; }
        public usuario Vendedor { get; set; }
        public List<ProductoVendidoCompletoModel> ProductosVendidos { get; set; }
        public decimal TotalDeVenta { get; set; }

        #endregion
    }
}
