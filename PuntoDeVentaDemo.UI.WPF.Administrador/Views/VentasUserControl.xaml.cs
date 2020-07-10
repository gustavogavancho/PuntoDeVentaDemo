using PuntoDeVentaDemo.COMMON.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace PuntoDeVentaDemo.UI.WPF.Administrador.Views
{
    /// <summary>
    /// Interaction logic for VentasUserControl.xaml
    /// </summary>
    public partial class VentasUserControl : UserControl
    {
        #region Variables

        IVentaManager _ventaManager;
        ScrollViewer contenedor;

        #endregion

        #region Constructor
        public VentasUserControl(ScrollViewer contenedor)
        {
            InitializeComponent();
            _ventaManager = Tools.Tools.FactoryManager.VentaManager();
            this.contenedor = contenedor;
        }

        #endregion

        #region Eventos
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            DtgDatos.ItemsSource = null;
            DtgDatos.ItemsSource = _ventaManager.VentasEnIntervalo(DtpInicio.SelectedDate.Value, DtpFin.SelectedDate.Value);

        }

        private void BtnNuevaVenta_Click(object sender, RoutedEventArgs e)
        {
            contenedor.Content = null;
            contenedor.Content = new NuevaVentaUserControl();
        }
        #endregion
    }
}