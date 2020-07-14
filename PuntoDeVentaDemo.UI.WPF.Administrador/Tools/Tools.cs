using PuntoDeVentaDemo.BIZ;
using PuntoDeVentaDemo.COMMON.Entidades;

namespace PuntoDeVentaDemo.UI.WPF.Administrador.Tools
{
    /// <summary>
    /// Asigna que tipo de instancia para la base de datos utilizara la UI (SQLServer o MySql)
    /// </summary>
    public static class Tools
    {
        #region Propiedades

        /// <summary>
        /// Selecciona el tipo instancia de base de datos
        /// </summary>
        public static Factory FactoryManager = new Factory("MySql");

        /// <summary>
        /// Selecciona el usuarioo a loggear o loggeado en el programa
        /// </summary>
        public static usuario Usuario { get; internal set; }

        #endregion
    }
}
