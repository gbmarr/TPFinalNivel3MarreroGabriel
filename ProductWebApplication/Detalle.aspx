<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ProductWebApplication.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main_container">
        <h2 class="page_titles">Detalle de producto</h2>
        <div class="article_container">
            <div class="article_bodycontainer">
                <div>
                    <asp:Label Text="Código:" runat="server" />
                    <asp:Label CssClass="article_cod" ID="txtCod" Text="" runat="server" />
                </div>
                <div>
                    <asp:Label Text="Nombre:" runat="server" />
                    <asp:Label CssClass="article_nombre" ID="txtNombre" Text="" runat="server" />
                </div>
                <div>
                    <asp:Label Text="Descripción:" runat="server" />
                    <asp:Label CssClass="article_desc" ID="txtDesc" Text="" runat="server" />
                </div>
                <div>
                    <asp:Label Text="Marca:" runat="server" />
                    <asp:Label CssClass="article_marca" ID="txtMarca" Text="" runat="server" />
                </div>
                <div>
                    <asp:Label Text="Categoría:" runat="server" />
                    <asp:Label CssClass="article_cat" ID="txtCat" Text="" runat="server" />
                </div>
                <div>
                    <asp:Label Text="Precio:" runat="server" />
                    <asp:Label CssClass="article_precio" ID="txtPrecio" Text="" runat="server" />
                </div>
            </div>
            <div class="article_imgcontainer">
                <asp:Image CssClass="article_img" ID="imgUrl" ImageUrl="ImageUrl" runat="server" />
            </div>
        </div>
        <a href="/Default.aspx" class="btn_volver">Regresar</a>
    </div>
</asp:Content>
