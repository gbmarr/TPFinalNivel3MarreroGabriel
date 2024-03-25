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

        public List<Articulo> listarFavoritos(int iD)
        {
            List<Articulo> listaFavoritos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            { 
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion Marca, IdCategoria, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M, FAVORITOS where A.IdMarca = M.Id AND A.IdCategoria = C.Id AND A.Id = IdArticulo AND IdUser = @idUser";

                datos.setearConsulta(consulta);
                datos.setearParametro("@idUser", iD);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo auxiliar = new Articulo();
                    auxiliar.ID = (int)datos.Lector["Id"];
                    auxiliar.codArticulo = (string)datos.Lector["Codigo"];
                    auxiliar.Nombre = (string)datos.Lector["Nombre"];
                    auxiliar.Descripcion = (string)datos.Lector["Descripcion"];
                    auxiliar.Marca = new Elemento();
                    auxiliar.Marca.ID = (int)datos.Lector["IdMarca"];
                    auxiliar.Marca.Descripcion = (string)datos.Lector["Marca"];
                    auxiliar.Categoria = new Elemento();
                    auxiliar.Categoria.ID = (int)datos.Lector["IdCategoria"];
                    auxiliar.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    auxiliar.Imagen = (string)datos.Lector["ImagenUrl"];
                    auxiliar.Precio = (Decimal)datos.Lector["Precio"];

                    listaFavoritos.Add(auxiliar);
                }

                return listaFavoritos;
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

        public void eliminarFavorito(string idArti, string idUser)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete from FAVORITOS where IdArticulo = @idArti AND IdUser = @idUser");
                datos.setearParametro("@idArti", idArti);
                datos.setearParametro("@idUser", idUser);

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
