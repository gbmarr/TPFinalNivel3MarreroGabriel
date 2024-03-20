<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="ProductWebApplication.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main_container">
        <h2 class="page_titles">Articulos favoritos</h2>
        <asp:Label Text="Aquí encontrarás los articulos que has seleccionado como tus favoritos." runat="server" />
        <div class="cardlist_container">
            <% foreach (dominio.Articulo artiFav in ListaFavorito)
                { %>
            <div class="card_container">
                <img class="card_img" src="<%: cargarCardImg(artiFav.Imagen) %>" alt="Alternate Text" />
                <div class="card_body">
                    <p class="card_cod">Código de art: <%: artiFav.codArticulo %></p>
                    <h3 class="card_title"><%: artiFav.Nombre %></h3>
                    <p class="card_precio">$<%: artiFav.Precio %></p>
                    <div>
                        <a class="btn_detalle" href="/Detalle.aspx?id=<%: artiFav.ID %>">Ver detalle</a>
                    </div>
                </div>
            </div>
            <%} %>
        </div>
    </div>
</asp:Content>
