<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="ProductWebApplication.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
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
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div>
                                <asp:Label Text="Cargar imagen:" runat="server" />
                                <asp:TextBox OnTextChanged="txtImagen_TextChanged" AutoPostBack="true" CssClass="form_txt" ID="txtImagen" runat="server" />
                            </div>
                            <asp:Image CssClass="form_img" ID="imageUrl" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UPContainerButtons" ClientIDMode="Static" runat="server">
            <ContentTemplate>
                <div class="form_containerbtn">
                    <asp:Button OnClick="btnModificar_Click" ID="btnModificar" CssClass="btn_modificar" Text="Modificar" runat="server" />
                    <asp:Button OnClick="btnEliminar_Click" ID="btnEliminar" ClientIDMode="Static" CssClass="btn_eliminar" Text="Eliminar" runat="server" />
                </div>
                <%if (confirmaEliminacion)
                    { %>
                <div class="modal_container">
                    <h3 class="modal_title">¿Estás seguro/a que quieres eliminar este articulo?</h3>
                    <div>
                        <asp:Button CssClass="btn_eliminar modal_btn" ID="btnConfirmarEliminacion" OnClick="btnConfirmarEliminacion_Click" Text="Eliminar" runat="server" />
                        <asp:Button CssClass="btn_cancelar modal_btn" ID="btnCancelarEliminacion" OnClick="btnCancelarEliminacion_Click" Text="Cancelar" runat="server" />
                    </div>
                </div>
                <%} %>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- MODAL -->
    <script src="Scripts/modalForm.js"></script>
</asp:Content>
