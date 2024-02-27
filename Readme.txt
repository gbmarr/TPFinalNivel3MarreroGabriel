Pasos seguidos para crear la aplicacion.

1. Primero se crearon los proyectos necesarios para separar las capas de la App y tambien la Master Page para contener a las demas paginas.
2. Luego se crearon las clases dentro de cada uno de estos proyectos. Se agregaron las referencias necesarias entre proyectos.
3. Se crearon las propiedades de las clases Articulo y Elemento.
4. Se creó la clase AccesoDatos y se configuraron los constructores del lector y de la propia clase para setear conexion e instancia del comando.
	Además se creo el metodo setearConsulta, cerrarConexion y ejecutarLectura.
5. En la clase Elemento se sobreescribio el metodo toString.
6. En la clase ArticuloNegocio se creó el metodo listar utilizando la clase AccesoDatos para realizar las conexiones a DB.
7. En la clase AccesoDatos se creó el metodo para ejecutar acciones sobre la base de datos.
8. En la clase ArticuloNegocio se creo el metodo para agregar un nuevo producto a la base de datos.
9. En AccesoDatos se creo el metodo setearParametro para poder insertar parametros dentro de la consulta embebida que usamos en el metodo del paso 8.
10. En la clase ElementoNegocio creamos el metodo listar para cargar los desplegables. Ademas se implemento la utilizacion del DisplayName en la clase
	Articulo para colocar el nombre de columna que se desea mostrar en pantalla.
11. En ArticuloNegocio se creo el metodo para modificar un Articulo de la base de datos utilizando el seteo de los parametros dentro de la consulta.
12. Se creo el metodo "eliminar" en la clase ArticuloNegocio, el cual elimina de manera fisica los registros dentro de nuestra base de datos.
	Ademas, tambien se creo la eliminacion logica, con lo cual podemos, en otras palabras, activar o desactivar registros de nuestra DB sin eliminarlos fisicamente.
13. Se agregó el metodo listarConSP para realizar la misma funcionalidad que el metodo listar de la clase ArticuloNegocio pero que trabaja con
	procedimientos almacenados y no con consultas embebidas.
14. Se agregó el metodo agregarConSP para agregar registros utilizando un procedimiento almacenado.
15. Se modifico el metodo listar inicial agregandole un parametro para trabajar la modificacion del mismo. Si el parametro sigue vacio cuando se ejecuta el metodo
	entonces la consulta no se va a ver afectada y va a seguir teniendo la misma funcionalidad que antes.
16. Se agregó el metodo de setearProcedimiento a la clase AccesoDatos.
17. Se creó el metodo modificarConSP para utilizar la misma logica que el metodo modificar pero usando un procedimiento almacenado dentro del mismo.
