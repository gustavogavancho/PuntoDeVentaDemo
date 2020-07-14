namespace PuntoDeVentaDemo.Tools
{
    /// <summary>
    /// Clase que almacena una propiedad para hacer la conexión a la base de datos
    /// </summary>
    public class ConnectionString
    {
        public static string MySQL { get; set; } = null;
        public static string SQLServer { get; set; } = null;
    }
}
