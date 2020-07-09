﻿using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.UI.WPF.Administrador.Tools;
using PuntoDeVentaDemo.UI.WPF.Administrador.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PuntoDeVentaDemo.UI.WPF.Administrador
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(usuario usr)
        {
            InitializeComponent();
            LblUsuario.Content = $"[{usr.NombreDeUsuario}] {usr.Nombres} {usr.Apellidos}";
            Tools.Tools.Usuario = usr;
        }

        private void MenuHome_Selected(object sender, RoutedEventArgs e)
        {
            MostrarContenido(new HomeUserControl());
        }

        private void MenuProductos_Selected(object sender, RoutedEventArgs e)
        {
            MostrarContenido(new ProductosUserControl());
        }

        private void MostrarContenido(UserControl control)
        {
            Contenedor.Content = null;
            Contenedor.Content = control;         
        }

        private void MenuUsuarios_Selected(object sender, RoutedEventArgs e)
        {
            MostrarContenido(new UsuariosUserControl());
        }

        private void MenuVentas_Selected(object sender, RoutedEventArgs e)
        {
            MostrarContenido(new VentasUserControl(Contenedor));
        }
    }
}
