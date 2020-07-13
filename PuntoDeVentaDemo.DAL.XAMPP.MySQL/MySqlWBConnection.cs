using MySql.Data.MySqlClient;
using PuntoDeVentaDemo.COMMON.Interfaces;
using PuntoDeVentaDemo.Tools;
using System;
using System.Configuration;
using System.Data;

namespace PuntoDeVentaDemo.DAL.XAMPP.MySQL
{
    public class MySqlWBConnection : IDB
    {
        #region Variables

        private MySqlConnection _conexion;

        #endregion

        #region Propiedades
        public string Error { get; private set; }

        #endregion

        #region Constructor
        public MySqlWBConnection()
        {
            string server = "localhost";
            string database = "tienda";
            string uid = "root";
            string password = "";

            //_conexion = new MySqlConnection($"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};SslMode=none;");
            _conexion = new MySqlConnection(ConectionString.MySQL);
            Conectar();
        }

        #endregion

        #region Métodos
        private bool Conectar()
        {
            try
            {
                _conexion.Open();
                Error = "";
                return true;
            }
            catch (MySqlException ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool Comando(string command)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(command, _conexion);
                cmd.ExecuteNonQuery();
                Error = "";
                return true;
            }
            catch (Exception ex)
            {

                Error = ex.Message;
                return false;
            }
        }

        public object Consulta(string consulta)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(consulta, _conexion);
                MySqlDataReader dr = cmd.ExecuteReader();
                Error = "";
                return dr;
            }
            catch (Exception ex)
            {

                Error = ex.Message;
                return null;
            }
        }

        #endregion

        #region Destructor
        ~MySqlWBConnection()
        {
            if (_conexion.State == ConnectionState.Open)
            {
                _conexion.Close();
            }
        }

        #endregion
    }
}
