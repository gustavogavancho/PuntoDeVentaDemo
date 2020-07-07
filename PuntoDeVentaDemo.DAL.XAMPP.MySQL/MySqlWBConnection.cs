using MySql.Data.MySqlClient;
using PuntoDeVentaDemo.COMMON.Interfaces;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;

namespace PuntoDeVentaDemo.DAL.XAMPP.MySQL
{
    public class MySqlWBConnection : IDB
    {
        private MySqlConnection _conexion;

        public MySqlWBConnection()
        {
            string server = "localhost";
            string database = "tienda";
            string uid = "root";
            string password = "";
            _conexion = new MySqlConnection
                ($"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};SslMode=none;");
            Conectar();
        }

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

        public string Error { get; private set; }


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

        ~MySqlWBConnection()
        {
            if (_conexion.State == ConnectionState.Open)
            {
                _conexion.Close();
            }
        }
    }
}
