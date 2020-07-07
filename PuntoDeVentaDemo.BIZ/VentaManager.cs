using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using System;
using System.Collections.Generic;

namespace PuntoDeVentaDemo.BIZ
{
    public class VentaManager : GenericManager<venta>, IVentaManager
    {
        public VentaManager(IGenericRepository<venta> repositorio) : base(repositorio)
        {
        }

        public IEnumerable<venta> VentasDeClienteEnIntervalor(string nombreCliente, DateTime inicio, DateTime fin)
        {
            DateTime rInicio = new DateTime(inicio.Year, inicio.Month, inicio.Day, 0, 0, 0);
            DateTime rFin = new DateTime(fin.Year, fin.Month, fin.Day, 0, 0, 0).AddDays(1);
            return _repositorio.Query(v => v.FechaHora >= rInicio && v.FechaHora <= rFin && v.Cliente == nombreCliente);
        }

        public IEnumerable<venta> VentasEnIntervalo(DateTime inicio, DateTime fin)
        {
            DateTime rInicio = new DateTime(inicio.Year, inicio.Month, inicio.Day, 0,0,0);
            DateTime rFin = new DateTime(fin.Year, fin.Month, fin.Day, 0, 0, 0).AddDays(1);
            return _repositorio.Query(v => v.FechaHora >= rInicio && v.FechaHora <= rFin);
        }
    }
}