using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesodatos;

namespace negocio
{
    public class UserNegocio
    {
        public bool loguear(User usuario)
        {
            
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where email = @email AND pass = @pass";
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.setearConsulta(consulta);

                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    usuario.ID = (int)datos.Lector["Id"];
                    usuario.Email = (string)datos.Lector["email"];
                    usuario.Pass = (string)datos.Lector["pass"];
                    if(!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    if(!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];
                    if(!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.UrlImagen = (string)datos.Lector["urlImagenPerfil"];
                    usuario.TipoUsuario = (bool)datos.Lector["admin"];
                    return true;
                }
                return false;
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

        public int agregarUsuario(User usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("agregarNuevoUsuario");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);

                return datos.ejecutarScalar();
                
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

        public bool logueado(User usuario)
        {
            try
            {
                if (usuario != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
