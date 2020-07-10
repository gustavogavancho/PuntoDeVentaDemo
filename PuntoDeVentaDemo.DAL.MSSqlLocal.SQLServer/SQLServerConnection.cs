using PuntoDeVentaDemo.COMMON.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;


namespace PuntoDeVentaDemo.DAL.MSSqlLocal.SQLServer
{
    public class SQLServerConnection : IDB
    {
        #region Variables

        SqlConnection _connection;

        #endregion

        #region Propiedades
        public string Error { get; private set; }

        #endregion

        #region Constructor

        public SQLServerConnection()
        {
            string server = @"GUSTAVO";
            string database = "tienda";
            string uid = "tiendauser";
            string password = "12345";
            _connection = new SqlConnection
                ($"Data Source={server};Initial Catalog={database};Persist Security Info=True;User ID={uid};Password={password}");
            Conectar();
        }

        #endregion

        #region Métodos
        private bool Conectar()
        {
            try
            {
                _connection.Open();
                Error = "";
                return true;
            }
            catch (SqlException ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool Comando(string command)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(command, _connection);
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
                SqlCommand cmd = new SqlCommand(consulta, _connection);
                SqlDataReader dr = cmd.ExecuteReader();
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
        ~SQLServerConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        #endregion
    }
}
