<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ProductWebApplication.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main_container">
        <h2 class="page_titles">Detalle de producto</h2>
        <div class="article_container">
            <asp:Label ID="txtCod" Text="" runat="server" />
            <asp:Label ID="txtNombre" Text="" runat="server" />
            <asp:Label ID="txtDesc" Text="" runat="server" />
            <asp:Label ID="txtMarca" Text="" runat="server" />
            <asp:Label ID="txtCat" Text="" runat="server" />
            <asp:Label ID="txtPrecio" Text="" runat="server" />
            <asp:Image ID="imgUrl" ImageUrl="ImageUrl" runat="server" />
        </div>
    </div>
</asp:Content>
