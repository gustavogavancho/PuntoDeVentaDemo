using System;

namespace PuntoDeVentaDemo.COMMON.Entidades
{
    public class venta : BaseDTO
    {
        public int IdVenta { get; set; }
        public DateTimeOffset FechaHora { get; set; }
        public string NombreDeUsuario { get; set; }
    }
}
