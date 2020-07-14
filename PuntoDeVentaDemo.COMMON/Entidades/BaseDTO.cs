using System;

namespace PuntoDeVentaDemo.COMMON.Entidades
{
    public abstract class BaseDTO : IDisposable
    {
        #region Variables

        private bool _isDiposed;

        #endregion

        #region Métodos

        /// <summary>
        /// Implementa el método dispose que si la variable "_isDisposed" es true llamar al Garbage Collector para reclamar
        /// el espacio de memorio
        /// </summary>
        public void Dispose()
        {
            if (!_isDiposed)
            {
                this._isDiposed = true;
                GC.SuppressFinalize(this);
            }
        }

        #endregion

    }
}