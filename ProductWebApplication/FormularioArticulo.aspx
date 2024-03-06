<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="ProductWebApplication.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main_container">
        <h2 class="page_titles">Agregar Articulo</h2>
        <div class="form_container">
            <div class="form_containerrow">
                <div class="form_div">
                    <asp:Label Text="ID:" runat="server" />
                    <asp:TextBox CssClass="form_txt form_txtID" ID="txtID" Enabled="false" runat="server" />
                </div>
                <div class="form_div">
                    <asp:Label Text="Código:" runat="server" />
                    <asp:TextBox CssClass="form_txt" ID="txtCod" runat="server" />
                </div>
                <div class="form_div">
                    <asp:Label Text="Nombre:" runat="server" />
                    <asp:TextBox CssClass="form_txt" ID="txtNombre" runat="server" />
                </div>
                <div class="form_div">
                    <asp:Label Text="Descripción:" runat="server" />
                    <asp:TextBox CssClass="form_txt" ID="txtDesc" runat="server" />
                </div>
            </div>
            <div class="form_containerrow">
                <div class="form_div">
                    <asp:Label Text="Marca:" runat="server" />
                    <asp:DropDownList CssClass="form_ddl" ID="ddlMarca" runat="server"></asp:DropDownList>
                </div>
                <div class="form_div">
                    <asp:Label Text="Categoría:" runat="server" />
                    <asp:DropDownList CssClass="form_ddl" ID="ddlCat" runat="server"></asp:DropDownList>
                </div>
                <div class="form_div">
                    <asp:Label Text="Precio:" runat="server" />
                    <asp:TextBox CssClass="form_txt" ID="txtPrecio" runat="server" />
                </div>
            </div>
            <div class="form_containerrow">
                <div class="form_div">
                    <asp:Label Text="Cargar imagen:" runat="server" />
                    <asp:TextBox CssClass="form_txt" ID="txtImagen" runat="server" />
                    <asp:Image CssClass="form_img" ID="imageUrl" ImageUrl="imageurl" runat="server" />
                </div>
            </div>
            <div class="form_containerrow">
                <asp:Button ID="btnModificar" CssClass="btn_modificar" Text="Modificar" runat="server" />
                <asp:Button ID="btnEliminar" CssClass="btn_eliminar" Text="Eliminar" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
