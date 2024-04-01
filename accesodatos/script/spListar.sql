USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[spListar]    Script Date: 4/1/2024 11:40:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spListar] as
Select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion Marca, IdCategoria, C.Descripcion Categoria, ImagenUrl, Precio
from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdMarca = M.Id AND A.IdCategoria = C.Id
GO


