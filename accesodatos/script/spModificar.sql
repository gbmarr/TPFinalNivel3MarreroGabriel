USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[spModificar]    Script Date: 4/1/2024 11:40:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spModificar]
@codigo varchar(50),
@nombre varchar(50),
@desc varchar(150),
@idMarca int,
@idCat int,
@imagen varchar(1000),
@precio money,
@id int
as
Update ARTICULOS 
set Codigo = @codigo, Nombre = @nombre, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCat, ImagenUrl = @imagen, Precio = @precio 
where Id = @id
GO


