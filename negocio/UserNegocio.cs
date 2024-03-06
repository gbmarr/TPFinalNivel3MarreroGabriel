﻿using System;
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
                string consulta = "Select Id, admin from USERS where email = @email AND pass = @pass";
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.setearConsulta(consulta);

                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    usuario.ID = (int)datos.Lector["Id"];
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
    }
}