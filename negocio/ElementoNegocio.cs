using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesodatos;

namespace negocio
{
    public class ElementoNegocio
    {
        //metodo que utilizaremos para cargar desplegables de marca y categoria. Pasamos por parametro la tabla ya que vamos a utilizar el mismo metodo
        // para dos tablas con diferentes nombres
        public List<Elemento> listar(string tabla)
        {
            List<Elemento> lista = new List<Elemento>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion from " + tabla);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Elemento auxiliar = new Elemento();
                    auxiliar.ID = (int)datos.Lector["Id"];
                    auxiliar.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(auxiliar);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
