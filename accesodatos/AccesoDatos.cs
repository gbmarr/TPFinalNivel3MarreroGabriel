﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace accesodatos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        // constructor que nos permite leer el lector desde el exterior
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        // constructor de la clase AccesoDatos para que al crearse un objeto se setee la conexion y se instancie el comando
        public AccesoDatos()
        {
            conexion = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]);
            comando = new SqlCommand();
        }

        // se setea el tipo de comando (accion) y se pasa por parametro la accion que se desea ejecutar a traves de una consulta embebida.
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        // se setea el tipo de accion a traves de la utilizacion de un procedimiento almacenado ya creado en nuestra base de datos.
        public void setearProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        // este metodo realiza la lectura y lo guarda en el lector
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // metodo para realizar acciones sobre la base de datos, NO CONSULTAS
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // metodo para realizar acciones sobre la base de datos y que nos devuelva un numero entero
        public int ejecutarScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // metodo que nos va a permitir validar esas "variables" que creamos dentro de una consulta embebida a traves de @parametro
        // cuando llamemos este metodo lo que va a suceder es que la "variable" que hemos pasado como parametro en la consulta va a
        // ser reemplazada por el valor que le asignemos al llamar al metodo.
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        // si el lector no es nulo, lo cerramos y luego tambien cerramos la conexion
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
