using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows;

namespace PuntoDeVentaDemo.UI.WPF.Administrador.Views
{
    /// <summary>
    /// Interaction logic for Reporteador.xaml
    /// </summary>
    public partial class Reporteador : Window
    {
        #region Variables

        string _reporte;
        List<ReportDataSource> _origenes;
        bool _cargado;

        #endregion

        #region Constructor
        public Reporteador(string nombreReporte, List<ReportDataSource> datos)
        {
            InitializeComponent();
            _reporte = nombreReporte;
            _origenes = datos;
            Contenedor.Load += Contenedor_Local;
        }

        #endregion

        #region Eventos
        private void Contenedor_Local(object sender, EventArgs e)
        {
            if (!_cargado)
            {
                Contenedor.LocalReport.ReportEmbeddedResource = _reporte;
                foreach (var item in _origenes)
                {
                    Contenedor.LocalReport.DataSources.Add(item);
                }
                Contenedor.RefreshReport();
                _cargado = true;
            }
        }

        #endregion
    }
}
