namespace PuntoDeVentaDemo.COMMON.Interfaces
{
    /// <summary>
    /// Proporciona métodos estandarizados para el acceso a las conexiones de la base de datos
    /// </summary>
    public interface IDB
    {
        #region Propiedades
        string Error { get; }
        bool Comando(string command);
        object Consulta(string consulta);

        #endregion
    }
}
