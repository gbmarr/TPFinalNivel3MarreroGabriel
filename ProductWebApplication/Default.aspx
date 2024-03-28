<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductWebApplication.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="main_container">
        <h2 class="page_titles">Bienvenido/a</h2>
        <asp:Label Text="Conoce nuestro stock de productos disponibles y aprovecha los mejores precios." runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="container_busqueda">
                    <div>
                        <asp:Label Text="Campo:" runat="server" />
                        <asp:DropDownList ID="ddlCampoBusqueda" OnSelectedIndexChanged="ddlCampoBusqueda_SelectedIndexChanged" AutoPostBack="true" CssClass="busqueda_ddl" runat="server"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label Text="Criterio:" runat="server" />
                        <asp:DropDownList ID="ddlCriterioBusqueda" CssClass="busqueda_ddl" runat="server"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label Text="Filtro:" runat="server" />
                        <asp:TextBox ID="txtValorBusqueda" OnTextChanged="txtValorBusqueda_TextChanged" AutoPostBack="true" Enabled="false" CssClass="busqueda_txt" runat="server" />
                    </div>
                    <div>
                        <asp:Button ID="btnBusqueda" OnClick="btnBusqueda_Click" Enabled="false" CssClass="btn_desactivado" Text="Buscar" runat="server" />
                        <asp:Button ID="btnResetBusqueda" OnClick="btnResetBusqueda_Click" CssClass="btn_cancelar" Text="Resetear" runat="server" />
                    </div>
                </div>
                <div class="cardlist_container">
                    <asp:Repeater ID="repeaterArti" runat="server">
                        <ItemTemplate>
                            <div class="card_container">
                                <img class="card_img" src="<%#Eval("Imagen") %>" alt="Alternate Text" />
                                <div class="card_body">
                                    <p class="card_cod">Código de art.:<%#Eval("codArticulo") %></p>
                                    <h3 class="card_title"><%#Eval("Nombre") %></h3>
                                    <p class="card_precio">$<%#Eval("Precio") %></p>
                                    <div>
                                        <a href="/Detalle.aspx?id=<%#Eval("ID") %>" class="btn_detalle">Ver Detalle</a>
                                        <%if (Session["usuario"] != null)
                                            { %>
                                        <asp:Button ID="cardFavorito" ClientIDMode="Static" OnClick="cardFavorito_Click" CommandArgument='<%#Eval("ID") %>' CommandName="artiID" CssClass="card_btnFav" Text="Fav" runat="server" />
                                        <%} %>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <% if (noEsFavorito)
                    { %>
                <div class="modal_container">
                    <h3 class="modal_title">El artículo seleccionado ya forma parte de los favoritos.</h3>
                    <asp:Button ID="btnEntendido" OnClick="btnEntendido_Click" CssClass="modal_btn btn_agregar" Text="Entendido" runat="server" />
                </div>
                <!-- MODAL -->
                <script src="Scripts/modalDefault.js"></script>
                <%} %>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
