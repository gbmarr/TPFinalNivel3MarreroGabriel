USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[editarPerfil]    Script Date: 4/1/2024 11:39:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[editarPerfil]
@id int,
@email varchar(100),
@pass varchar(20),
@nombre varchar(50),
@apellido varchar(50),
@img varchar(500),
@admin bit as
Update USERS set email = @email, pass = @pass, nombre = @nombre, apellido = @apellido, urlImagenPerfil = @img, admin = @admin where Id = @id
GO


