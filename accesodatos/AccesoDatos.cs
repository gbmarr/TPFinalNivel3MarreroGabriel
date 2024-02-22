using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            comando = new SqlCommand();
        }

        // se setea el tipo de comando (accion) y se pasa por parametro la accion que se desea ejecutar a traves de una consulta embebida.
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
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

        // si el lector no es nulo, lo cerramos y luego tambien cerramos la conexion
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
