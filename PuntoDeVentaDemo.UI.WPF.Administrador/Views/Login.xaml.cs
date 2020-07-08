using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using PuntoDeVentaDemo.UI.WPF.Administrador.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PuntoDeVentaDemo.UI.WPF.Administrador.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        IUsuarioManager _manager;

        public Login()
        {
            InitializeComponent();
            _manager = Tools.Tools.FactoryManager.UsuarioManager();
        }

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
    }
}
