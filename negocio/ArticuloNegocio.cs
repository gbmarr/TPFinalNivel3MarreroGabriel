using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesodatos;

namespace negocio
{
    class ArticuloNegocio
    {
        // metodo que vamos a utilizar para obtener la lista de articulos
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            // creamos un objeto que tiene conexion (tiene la cadena de conexion configurada), un comando (tiene instancia) y un lector
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdMarca = M.Id AND A.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo auxiliar = new Articulo();
                    auxiliar.ID = (int)datos.Lector["Id"];
                    auxiliar.codArticulo = (string)datos.Lector["Codigo"];
                    auxiliar.Nombre = (string)datos.Lector["Nombre"];
                    auxiliar.Descripcion = (string)datos.Lector["Descripcion"];
                    auxiliar.Marca = new Elemento();
                    auxiliar.Marca.Descripcion = (string)datos.Lector["Marca"];
                    auxiliar.Categoria = new Elemento();
                    auxiliar.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    auxiliar.Imagen = (string)datos.Lector["ImagenUrl"];
                    auxiliar.Precio = (Decimal)datos.Lector["Precio"];

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

        public void agregarArticulo(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values ('', '', '', 1, 1, '', 2)");
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
