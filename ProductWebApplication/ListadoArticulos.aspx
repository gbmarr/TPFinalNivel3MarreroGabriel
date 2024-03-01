<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="ProductWebApplication.Listado_de_Articulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main_container">
        <h2>Articulos Disponibles:</h2>
        <asp:GridView ID="gvListado" CssClass="tbl_list" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField ItemStyle-CssClass="tbl_listitem" HeaderStyle-CssClass="tbl_listheader" HeaderText="Código" DataField="codArticulo" />
                <asp:BoundField ItemStyle-CssClass="tbl_listitem" HeaderStyle-CssClass="tbl_listheader" HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField ItemStyle-CssClass="tbl_listitem" HeaderStyle-CssClass="tbl_listheader" HeaderText="Descripción" DataField="Descripcion" />
                <asp:BoundField ItemStyle-CssClass="tbl_listitem" HeaderStyle-CssClass="tbl_listheader" HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField ItemStyle-CssClass="tbl_listitem" HeaderStyle-CssClass="tbl_listheader" HeaderText="Categoría" DataField="Categoria.Descripcion" />
                <asp:BoundField ItemStyle-CssClass="tbl_listitem" HeaderStyle-CssClass="tbl_listheader" HeaderText="Precio" DataField="Precio" />
                <asp:CommandField ItemStyle-CssClass="tbl_listitem" ControlStyle-CssClass="tbl_button" HeaderStyle-CssClass="tbl_listheader" ShowSelectButton="true" SelectText="Editar" HeaderText="Acciones" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
