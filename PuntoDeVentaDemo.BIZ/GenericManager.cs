using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using System.Collections.Generic;
using System;

namespace PuntoDeVentaDemo.BIZ
{
    public abstract class GenericManager<T> : IGenericManager<T> where T : BaseDTO
    {
        #region Variable

        internal readonly IGenericRepository<T> _repositorio;

        #endregion

        #region Constructor

        public GenericManager(IGenericRepository<T> repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Métodos
        public string Error
        {
            get
            {
                return _repositorio.Error;
            }
        }

        public IEnumerable<T> ObtenerTodo
        {
            get
            {
                return _repositorio.Read;
            }
        }

        public bool Actualizar(T entidad)
        {
            return _repositorio.Update(entidad);
        }

        public T BuscarPorId(string id)
        {
            return _repositorio.SearchById(id);
        }

        public bool Eliminar(string id)
        {
            return _repositorio.Delete(id);
        }

        public bool Insertar(T entidad)
        {
            return _repositorio.Create(entidad);
        }

        #endregion
    }
}