USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[agregarNuevoUsuario]    Script Date: 4/1/2024 11:39:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[agregarNuevoUsuario]
@email varchar(100),
@pass varchar(20)
as
Insert into USERS (email, pass, admin) output inserted.Id values (@email, @pass, 0)
GO


