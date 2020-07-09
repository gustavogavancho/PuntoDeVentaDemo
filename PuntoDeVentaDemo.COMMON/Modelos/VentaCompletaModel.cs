using PuntoDeVentaDemo.COMMON.Entidades;
using System.Collections.Generic;

namespace PuntoDeVentaDemo.COMMON.Modelos
{
    public class VentaCompletaModel
    {
        public venta Venta { get; set; }
        public usuario Vendedor { get; set; }
        public List<ProductoVendidoCompletoModel> ProductosVendidos { get; set; }
        public decimal TotalDeVenta { get; set; }
    }
}
