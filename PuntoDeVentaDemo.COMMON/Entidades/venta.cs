using System;

namespace PuntoDeVentaDemo.COMMON.Entidades
{
    public class venta : BaseDTO
    {
        #region Propiedades
        public int IdVenta { get; set; }
        public DateTime FechaHora { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Cliente { get; set; }

        #endregion
    }
}
