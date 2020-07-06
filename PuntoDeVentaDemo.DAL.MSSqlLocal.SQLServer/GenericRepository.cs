using FluentValidation;
using FluentValidation.Results;
using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace PuntoDeVentaDemo.DAL.MSSqlLocal.SQLServer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseDTO
    {
        private SQLServerConnection _db;
        private bool _idEsAutonumerico;
        private AbstractValidator<T> _validator;

        public GenericRepository(AbstractValidator<T> validator, bool idEsAutonumerico = true)
        {
            _validator = validator;
            _idEsAutonumerico = idEsAutonumerico;
            _db = new SQLServerConnection();
        }

        public string Error { get; private set; }

        public IEnumerable<T> Read
        {
            get
            {
                try
                {
                    string sql = string.Format($"SELECT * FROM {typeof(T).Name}");
                    SqlDataReader r = (SqlDataReader)_db.Consulta(sql);
                    List<T> datos = new List<T>();
                    var campos = typeof(T).GetProperties();
                    T dato;
                    Type Ttypo = typeof(T);
                    while (r.Read())
                    {
                        dato = (T)Activator.CreateInstance(typeof(T));
                        for (int i = 0; i < campos.Length; i++)
                        {
                            PropertyInfo prop = Ttypo.GetProperty(campos[i].Name);
                            prop.SetValue(dato, r[i]);
                        }
                        datos.Add(dato);
                    }
                    r.Close();
                    Error = "";
                    return datos;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Create(T entidad)
        {
            ValidationResult resultadoDeValidacion = _validator.Validate(entidad);
            if (resultadoDeValidacion.IsValid)
            {
                string sql1 = $"INSERT INTO {typeof(T).Name} (";
                string sql2 = $") VALUES (";
                var campos = typeof(T).GetProperties();
                T dato = (T)Activator.CreateInstance(typeof(T));
                Type Ttypo = typeof(T);
                for (int i = 0; i < campos.Length; i++)
                {
                    if (_idEsAutonumerico && i == 0)
                    {
                        continue;
                    }
                    sql1 += $" {campos[i].Name}";
                    var propiedad = Ttypo.GetProperty(campos[i].Name);
                    var valor = propiedad.GetValue(entidad);
                    switch (propiedad.PropertyType.Name)
                    {
                        case "String":
                            sql2 += $"'{valor}'";
                            break;
                        case "DateTime":
                            DateTime v = (DateTime)valor;
                            sql2 += $"convert(datetime, '{v.Day}-{v.Month}-{v.Year.ToString().Substring(2, 2)} {v.Hour}:{v.Minute}:{v.Second}',5)";
                            break;
                        default:
                            sql2 += $" {valor}";
                            break;
                    }

                    if (i != campos.Length - 1)
                    {
                        sql1 += $" ,";
                        sql2 += $" ,";
                    }
                }
                return EjecutaComando($"{sql1}{sql2});");
            }
            else
            {
                Error = "Error de validación";
                foreach (var item in resultadoDeValidacion.Errors)
                {
                    Error += $"{item.ErrorMessage}. ";
                }
                return false;
            }
        }

        private bool EjecutaComando(string sql)
        {
            if (_db.Comando(sql))
            {
                Error = "";
                return true;
            }
            else
            {
                Error = _db.Error;
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var campos = typeof(T).GetProperties();
                Type Ttypo = typeof(T);
                string sql = $"DELETE FROM {typeof(T).Name} WHERE {campos[0].Name}=";
                switch (Ttypo.GetProperty(campos[0].Name).PropertyType.Name)
                {
                    case "String":
                        sql += $"'{id}'";
                        break;
                    default:
                        sql += $" {id}";
                        break;
                }
                if (_db.Comando($"{sql};"))
                {
                    Error = "";
                    return true;
                }
                else
                {
                    Error = _db.Error;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicado)
        {
            return Read.Where(predicado.Compile());
        }

        public T SearchById(string id)
        {
            try
            {
                var campos = typeof(T).GetProperties();
                Type TTypo = typeof(T);
                string sql = $"SELECT * FROM {typeof(T).Name} WHERE {campos[0].Name}=";
                switch (TTypo.GetProperty(campos[0].Name).PropertyType.Name)
                {
                    case "String":
                        sql += $"'{id}'";
                        break;
                    default:
                        sql += $" {id}";
                        break;
                }
                SqlDataReader r = (SqlDataReader)_db.Consulta(sql);
                T dato = (T)Activator.CreateInstance(typeof(T));
                int j = 0;
                while (r.Read())
                {
                    dato = (T)Activator.CreateInstance(typeof(T));
                    for (int i = 0; i < campos.Length; i++)
                    {
                        PropertyInfo prop = TTypo.GetProperty(campos[i].Name);
                        prop.SetValue(dato, r[i]);
                    }
                    j++;
                }
                r.Close();
                if (j > 0)
                {
                    Error = "";
                    return dato;
                }
                else
                {
                    Error = "Id no existente...";
                    return null;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public bool Update(T entidad)
        {
            try
            {
                string sql1 = $"UPDATE {typeof(T).Name} SET";
                string sql2 = $" WHERE ";
                string sql = "";
                var campos = typeof(T).GetProperties();
                T dato = (T)Activator.CreateInstance(typeof(T));
                Type Ttypo = typeof(T);
                for (int i = 0; i < campos.Length; i++)
                {
                    var propiedad = Ttypo.GetProperty(campos[i].Name);
                    var valor = propiedad.GetValue(entidad);
                    sql += $"{propiedad.PropertyType.Name}=";
                    switch (propiedad.PropertyType.Name)
                    {
                        case "String":
                            sql += $"'{valor}'";
                            break;
                        case "DateTime":
                            DateTime v = (DateTime)valor;
                            sql += $"'{v.Year}-{v.Month}-{v.Day} {v.Hour}:{v.Minute}:00'";
                            break;
                        default:
                            sql += $" {valor}";
                            break;
                    }
                    if (i == 0)
                    {
                        sql2 += sql;
                    }
                    if (i != campos.Length - 1)
                    {
                        sql += " ,";
                    }
                    sql1 += sql;
                    sql = "";
                }
                if (_db.Comando(sql1 + sql2))
                {
                    Error = "";
                    return true;
                }
                else
                {
                    Error = _db.Error;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }
    }
}
