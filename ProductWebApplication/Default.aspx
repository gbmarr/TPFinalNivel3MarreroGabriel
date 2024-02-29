<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductWebApplication.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main_container">
        <h2>Bienvenido/a</h2>
        <asp:Label Text="Conoce nuestro stock de productos disponibles y aprovecha los mejores precios." runat="server" />
        <div class="cardlist_container">
            <% foreach (dominio.Articulo arti in ListaArticulo)
                {    %>
            <div class="card_container">
                    <img class="card_img" src="<%: arti.Imagen %>" alt="" />
                    <div class="card_body">
                        <h3 class="card_title"><%: arti.Nombre %></h3>
                        <p class="card_desc"><%: arti.Descripcion %></p>
                        <p class="card_precio"><%: arti.Precio %></p>
                    </div>
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>
