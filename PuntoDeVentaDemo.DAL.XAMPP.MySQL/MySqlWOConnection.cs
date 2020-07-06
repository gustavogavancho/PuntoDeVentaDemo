using MySql.Data.MySqlClient;
using PuntoDeVentaDemo.COMMON.Interfaces;
using System;
using System.Data;

namespace PuntoDeVentaDemo.DAL.XAMPP.MySQL
{
    public class MySqlWOConnection : IMySqlWOConnection
    {
        private MySqlConnection conexion;
        public MySqlWOConnection()
        {
            string server = "";
            string database = "";
            string uid = "";
            string password = "";
            conexion = new MySqlConnection
                ($"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};SslMode=none;");
            Conectar();
        }


        private bool Conectar()
        {
            try
            {
                conexion.Open();
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
                MySqlCommand cmd = new MySqlCommand(command, conexion);
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
                MySqlCommand cmd = new MySqlCommand(consulta, conexion);
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

        ~MySqlWOConnection()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
