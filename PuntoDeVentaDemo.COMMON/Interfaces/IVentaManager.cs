using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Modelos;
using System;
using System.Collections.Generic;

namespace PuntoDeVentaDemo.COMMON.Interfaces
{
    /// <summary>
    /// Proporciona métodos relacionados a las ventas
    /// </summary>
    public interface IVentaManager : IGenericManager<venta>
    {
        /// <summary>
        /// Obtiene todas las ventas en el intervalo especificado
        /// </summary>
        /// <param name="inicio">Fecha de inicio</param>
        /// <param name="fin">Fecha de fin</param>
        /// <returns>Conjunto de vnetas efectuadas en el intervalo proporcionado</returns>
        IEnumerable<VentaCompletaModel> VentasEnIntervalo(DateTime inicio, DateTime fin);

        /// <summary>
        /// Obtiene las ventas a un cliente en un intervalo especificado
        /// </summary>
        /// <param name="nombreCliente">Nombre del cliente</param>
        /// <param name="Inicio">Fecha de inicio</param>
        /// <param name="fin">Fecha de fin</param>
        /// <returns>Conjunto de ventas realizadas al cliente en un intervalo especificado</returns>
        IEnumerable<VentaCompletaModel> VentasDeClienteEnIntervalor(string nombreCliente, DateTime Inicio, DateTime fin);
    }
}
