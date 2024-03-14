<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductWebApplication.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="main_container">
        <h2 class="page_titles">Bienvenido/a</h2>
        <asp:Label Text="Conoce nuestro stock de productos disponibles y aprovecha los mejores precios." runat="server" />
        <div class="container_busqueda">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label Text="Campo:" runat="server" />
                    <asp:DropDownList ID="ddlCampoBusqueda" OnSelectedIndexChanged="ddlCampoBusqueda_SelectedIndexChanged" AutoPostBack="true" CssClass="busqueda_ddl" runat="server"></asp:DropDownList>
                    <asp:Label Text="Criterio:" runat="server" />
                    <asp:DropDownList ID="ddlCriterioBusqueda" CssClass="busqueda_ddl" runat="server"></asp:DropDownList>
                    <asp:Label Text="Filtro:" runat="server" />
                    <asp:TextBox ID="txtValorBusqueda" CssClass="busqueda_txt" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="btnBusqueda" CssClass="btn_agregar" Text="Buscar" runat="server" />
        </div>
        <div class="cardlist_container">
            <% foreach (dominio.Articulo arti in ListaArticulo)
                {    %>
            <div class="card_container">
                <img class="card_img" src="<%: cargarCardImg(arti.Imagen) %>" alt="" />
                <div class="card_body">
                    <p class="card_cod">Código de art: <%: arti.codArticulo %></p>
                    <h3 class="card_title"><%: arti.Nombre %></h3>
                    <p class="card_precio">$<%: arti.Precio %></p>
                    <div>
                        <a href="/Detalle.aspx?id=<%: arti.ID %>" class="btn_detalle">Ver Detalle</a>
                        <% if (Session["usuario"] != null)
                            { %>
                        <asp:Button ID="cardFavorito" OnClick="cardFavorito_Click" CssClass="card_favorito" Text="Fav" runat="server" />
                        <%} %>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>
