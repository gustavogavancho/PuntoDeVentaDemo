using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using System.Windows;

namespace PuntoDeVentaDemo.UI.WPF.Administrador.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        #region Variables

        IUsuarioManager _manager;

        #endregion

        #region Constructor
        public Login()
        {
            InitializeComponent();
            _manager = Tools.Tools.FactoryManager.UsuarioManager();
        }

        #endregion

        #region Eventos

        private void BtnIniciar_Click(object sender, RoutedEventArgs e)
        {
            usuario user = _manager.Login(TxtUsuario.Text, PswPassword.Password);
            if (user != null)
            {
                MessageBox.Show("Bienvenido " + user.Nombres, "Tienda", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow ventana = new MainWindow(user);
                ventana.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta", "Tienda", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
