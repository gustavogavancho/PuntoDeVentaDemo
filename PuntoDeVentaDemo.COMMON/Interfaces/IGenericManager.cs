using PuntoDeVentaDemo.COMMON.Entidades;
using System.Collections;
using System.Collections.Generic;

namespace PuntoDeVentaDemo.COMMON.Interfaces
{
    /// <summary>
    /// Proporciona métodos estandarizados para el acceso a tablas; Cada manager creado debe implementar de esta Interfase
    /// </summary>
    /// <typeparam name="T">Tipo de entidad de la cual se implementa el Manager</typeparam>
    public interface IGenericManager<T> where T: BaseDTO
    {
        /// <summary>
        /// Proporciona el error relacionado después de alguna operación
        /// </summary>
        string Error { get; }

        /// <summary>
        /// Insertar una entidad en la tabla
        /// </summary>
        /// <param name="entidad">Entidad a insertar</param>
        /// <returns>Confirmación de la Inserción</returns>
        bool Insertar(T entidad);

        /// <summary>
        /// Obtiene todos los registros de la tabla
        /// </summary>
        IEnumerable<T> ObtenerTodo { get; }

        /// <summary>
        /// Actualiza un registro en la tabla en base a su propiedad Id
        /// </summary>
        /// <param name="entidad">Entidad ya modificada, el Id debe existir en la tabla</param>
        /// <returns>Confirmación de actualización</returns>
        bool Actualizar(T entidad);

        /// <summary>
        /// Eliminar una entidad en base al Id proporcionado
        /// </summary>
        /// <param name="id">Id de la entidad a eliminar</param>
        /// <returns>Confirmación de eliminación</returns>
        bool Eliminar(string id);

        /// <summary>
        /// Obtiene un elemento de acuerdo a su Id
        /// </summary>
        /// <param name="id">Id del elemento a obtener</param>
        /// <returns>La entidad completa correspondiente al Id proporcionado</returns>
        T BuscarPorId(string id);
    }
}