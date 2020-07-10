using PuntoDeVentaDemo.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PuntoDeVentaDemo.COMMON.Interfaces
{
    /// <summary>
    /// Proporciona los métodos básicos (CRUD) de acceso a una table de base datos
    /// </summary>
    /// <typeparam name="T">Es un tipo de entidad (Clase) a la que se refiere una tabla</typeparam>
    public interface IGenericRepository<T> where T:BaseDTO
    {
        #region Propiedades

        /// <summary>
        /// Proporciona información sobre el error ocurrido en alguna de las operaciones
        /// </summary>
        string Error { get; }

        /// <summary>
        /// Obtiene todos los registros de la tabla
        /// </summary>
        IEnumerable<T> Read { get; }

        #endregion

        #region Métodos
        /// <summary>
        /// Inserta una entidad en la tabla
        /// </summary>
        /// <param name="entidad">Entidad a insertar</param>
        /// <returns>Confirmación de la Inserción</returns>
        bool Create(T entidad);

        /// <summary>
        /// Actualiza un registro en la table en base a la propiedad Id
        /// </summary>
        /// <param name="entidad">Entidad ya modificada, el Id debe existir en la tabla para modificarse</param>
        /// <returns>Confirmación de la actualización</returns>
        bool Update(T entidad);

        /// <summary>
        /// Elimina una entidad en la base de datos de acuerdo al Id relacionado
        /// </summary>
        /// <param name="id">Id de la entidad a eliminar</param>
        /// <returns>Confirmación de eliminación</returns>
        bool Delete(string id);

        /// <summary>
        /// Realiza una consulta personalizada a la tabla
        /// </summary>
        /// <param name="predicado">Expresión Lambda que define la consulta</param>
        /// <returns>Conjunto de entidades que cumplen con la consulta</returns>
        IEnumerable<T> Query(Expression<Func<T, bool>> predicado);

        /// <summary>
        /// Obtener una entidad en base a su Id
        /// </summary>
        /// <param name="id">Id de la entidad a obtener</param>
        /// <returns>Entidad comlpleta que le corresponde el Id proporcionado</returns>
        T SearchById(string id);

        #endregion
    }
}