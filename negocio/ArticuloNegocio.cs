using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesodatos;

namespace negocio
{
    public class ArticuloNegocio
    {

        // metodo que vamos a utilizar para obtener la lista de articulos
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            // creamos un objeto que tiene conexion (tiene la cadena de conexion configurada), un comando (tiene instancia) y un lector
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // tengo que recordar que en esta consulta no traigo IdMarca ni IdCategoria, IMPORTANTE cuando trabaje con desplegables! (Unidad 8, video 1 - Nivel 2)
                // ademas, si utilizamos la eliminacion logica, al final de la consulta, debemos agregar un AND adicional que filtre los registros con determinado estado
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion Marca, IdCategoria, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdMarca = M.Id AND A.IdCategoria = C.Id";

                // en caso de que el parametro id venga cargado, se modificara la consulta para obtener solo el registro que coincida
                if (id != "")
                    consulta += " AND A.Id = " + id; 

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                // si existen datos dentro del lector, se ejecutará el codigo dentro del while
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

        // metodo de listado con stored procedure
        public List<Articulo> listarConSP()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // reemplazamos el uso de consultas embebidas por el uso de procedimientos almacenados. NO HACERLO SIEMPRE.
                datos.setearProcedimiento("spListar");
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

        // metodo que nos va a permitir insertar nuevos registros en la DB a traves de una consulta embebida
        public void agregarArticulo(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // consulta + seteo de los parametros dentro de la consulta
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@codigo, @nombre, @descripcion, @idMarca, @idCat, @imagen, @precio)");
                datos.setearParametro("@codigo", nuevo.codArticulo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.ID);
                datos.setearParametro("@idCat", nuevo.Categoria.ID);
                datos.setearParametro("@imagen", nuevo.Imagen);
                datos.setearParametro("@precio", nuevo.Precio);
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

        // metodo para inertar nuevos registros utilizando procedimiento almacenado
        public void agregarArticuloConSP(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("agregarConSP");
                datos.setearParametro("@codigo", nuevo.codArticulo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.ID);
                datos.setearParametro("@idCat", nuevo.Categoria.ID);
                datos.setearParametro("@imagen", nuevo.Imagen);
                datos.setearParametro("@precio", nuevo.Precio);
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

        // metodo que nos permite modificar un articulo de nuestra base de datos
        public void modificarArticulo(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCat, ImagenUrl = @imagen, Precio = @precio where Id = @id");
                datos.setearParametro("@codigo", modificar.codArticulo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@desc", modificar.Descripcion);
                datos.setearParametro("@idMarca", modificar.Marca.ID);
                datos.setearParametro("@idCat", modificar.Categoria.ID);
                datos.setearParametro("@imagen", modificar.Imagen);
                datos.setearParametro("@precio", modificar.Precio);
                datos.setearParametro("@id", modificar.ID);
                
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

        // metodo que nos permitira realizar modificaciones como el anterior pero usando procedimiento almacenado
        public void modificarArticuloConSP(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("spModificar");
                datos.setearParametro("@codigo", modificar.codArticulo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@desc", modificar.Descripcion);
                datos.setearParametro("@idMarca", modificar.Marca.ID);
                datos.setearParametro("@idCat", modificar.Categoria.ID);
                datos.setearParametro("@imagen", modificar.Imagen);
                datos.setearParametro("@precio", modificar.Precio);
                datos.setearParametro("@id", modificar.ID);

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

        // metodo para realizar filtrado de lista contra DB. Hay que modificarlo en base a la busqueda que quiera realizar
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> listafiltrada = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion Marca, IdCategoria, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdMarca = M.Id AND A.IdCategoria = C.Id AND ";

                switch (campo)
                {
                    case "Codigo":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Codigo > " + filtro;
                                break;       
                            case "Menor a":  
                                consulta += "Codigo < " + filtro;
                                break;
                            case "Igual a":
                                consulta += "Codigo = " + filtro;
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Descripción":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "A.Descripcion like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "A.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                }

                datos.setearConsulta(consulta);
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

                    listafiltrada.Add(auxiliar);
                }

                return listafiltrada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // metodo que vamos a utilizar para eliminar de manera fisica los registros de nuestra base de datos.
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete from ARTICULOS where Id = @id");
                datos.setearParametro("@id", id);

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

        // metodo de eliminacion logica de registros de la base de datos utilizando un "estado"
        public void eliminarLogico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // este metodo se debe configurar ya que fue creado teniendo como parametro que la tabla a utilizar
                // tiene registros con una columna estado que puede ser activo = 0 o activo = 1. Nuestra tabla de Articulos no tiene dicha columna
                datos.setearConsulta("Update NOMBREDELATABLA set Activo = 0 where Id = @id");
                datos.setearParametro("@id", id);
                
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
