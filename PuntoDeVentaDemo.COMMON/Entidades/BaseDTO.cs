using System;

namespace PuntoDeVentaDemo.COMMON.Entidades
{
    public abstract class BaseDTO : IDisposable
    {
        private bool _isDiposed;

        public void Dispose()
        {
            if (!_isDiposed)
            {
                this._isDiposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }
}