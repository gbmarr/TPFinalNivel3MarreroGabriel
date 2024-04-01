USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[agregarConSP]    Script Date: 4/1/2024 11:39:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[agregarConSP]
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(150),
@idMarca int,
@idCat int,
@imagen varchar(1000),
@precio money
as
Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)
values (@codigo, @nombre, @descripcion, @idMarca, @idCat, @imagen, @precio)
GO


