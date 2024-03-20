using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesodatos;

namespace negocio
{
    public class FavoritoNegocio
    {
        public void agregarFavorito(int idUser = 0, int idArti = 0)
        {
            Articulo favorito = new Articulo();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into FAVORITOS (IdUser, IdArticulo) values (@idUser, @idArti)");
                datos.setearParametro("@idUser", idUser);
                datos.setearParametro("@idArti", idArti);
                datos.ejecutarAccion();
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
