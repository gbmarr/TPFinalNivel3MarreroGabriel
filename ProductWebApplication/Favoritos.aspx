<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="ProductWebApplication.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="main_container">
        <h2 class="page_titles">Articulos favoritos</h2>
        <asp:Label Text="Aquí encontrarás los articulos que has seleccionado como tus favoritos." runat="server" />
        <%if (ListaFavorito != null)
            { %>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="cardlist_container">
                    <asp:Repeater ID="repeaterFav" runat="server">
                        <ItemTemplate>
                            <div class="card_container">
                                <img class="card_img" src="<%#Eval("Imagen") %>" alt="Alternate Text" />
                                <div class="card_body">
                                    <p class="card_cod">Código de art.:<%#Eval("codArticulo") %></p>
                                    <h3 class="card_title"><%#Eval("Nombre") %></h3>
                                    <p class="card_precio">$<%#Eval("Precio") %></p>
                                    <div>
                                        <asp:Button ID="btnEliminarFavorito" OnClick="btnEliminarFavorito_Click" CssClass="btn_eliminar" Text="Quitar favorito" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%}
            else
            { %>
        <div class="error_container">
            <h3 class="modal_title">La lista de favoritos se encuentra vacía</h3>
        </div>
        <%} %>
    </div>
</asp:Content>
