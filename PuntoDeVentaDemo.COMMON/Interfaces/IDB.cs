namespace PuntoDeVentaDemo.COMMON.Interfaces
{
    /// <summary>
    /// Proporciona métodos estandarizados para el acceso a las conexiones de la base de datos
    /// </summary>
    public interface IDB
    {
        #region Propiedades
        /// <summary>
        /// Mensaje de error
        /// </summary>
        string Error { get; }

        #endregion

        #region Metodos

        /// <summary>
        /// Verifica si la consuta NonSQL es válida y la ejecuta
        /// </summary>
        /// <param name="command">Consulta Nonsql a validar</param>
        /// <returns>Confirmación de validez</returns>
        bool Comando(string command);

        /// <summary>
        /// Verifica si la consulta SQL es válida y la ejecuta
        /// </summary>
        /// <param name="consulta">Consula sql a validar</param>
        /// <returns>Confirmación de validez</returns>
        object Consulta(string consulta);
        #endregion
    }
}
