namespace PuntoDeVentaDemo.COMMON.Entidades
{
    public class usuario : BaseDTO
    {
        #region Propiedades
        public string NombreDeUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Password { get; set; }

        #endregion
    }
}