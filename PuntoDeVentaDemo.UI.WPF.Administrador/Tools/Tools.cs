﻿using Microsoft.SqlServer.Server;
using PuntoDeVentaDemo.BIZ;
using PuntoDeVentaDemo.COMMON.Entidades;

namespace PuntoDeVentaDemo.UI.WPF.Administrador.Tools
{
    public static class Tools
    {
        public static Factory FactoryManager = new Factory("MySql");

        public static usuario Usuario { get; internal set; }
    }
}
