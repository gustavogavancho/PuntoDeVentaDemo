using PuntoDeVentaDemo.COMMON.Entidades;

namespace PuntoDeVentaDemo.COMMON.Interfaces
{
    /// <summary>
    /// Proporciona los métodos relacionados a los usuarios
    /// </summary>
    public interface IUsuarioManager : IGenericManager<usuario>
    {
        /// <summary>
        /// Verificar si las credenciales son válidas para el usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <param name="password">Contraseña de usuario</param>
        /// <returns>Si las credenciales son correctas regresa el usuario completo, de otro modo regresa null</returns>
        usuario Login(string nombreUsuario, string password);
    }
}
