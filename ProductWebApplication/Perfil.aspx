<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ProductWebApplication.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="main_container">
        <h2 class="page_titles">Perfil</h2>
        <div class="profile_container">
            <%if (!isEdit)
                { %>
            <div class="profile_containerdivs">
                <div class="profile_div">
                    <asp:Label Text="ID:" runat="server" />
                    <asp:Label CssClass="profile_txt profile_id" ID="lblID" runat="server" />
                </div>
                <div class="profile_div">
                    <asp:Label Text="Nombre:" runat="server" />
                    <asp:Label CssClass="profile_txt" ID="lblNombre" runat="server" />
                </div>
                <div class="profile_div">
                    <asp:Label Text="Apellido:" runat="server" />
                    <asp:Label CssClass="profile_txt" ID="lblApellido" runat="server" />
                </div>
                <div class="profile_div">
                    <asp:CheckBox CssClass="profile_txt" ID="ckbAdmin" Text="Admin" runat="server" />
                </div>
            </div>
            <div class="profile_divimg">
                <asp:Image CssClass="profile_img" ImageUrl="imageurl" ID="imgPerfilUsuario" runat="server" />
            </div>
            <asp:Button CssClass="profile_btnEditar" ID="btnEditarPerfil" OnClick="btnEditarPerfil_Click" Text="Editar perfil" runat="server" />
            <%}
                else
                {%>
            <div class="profile_containerdivs">
                <div class="profile_div">
                    <asp:Label Text="ID:" runat="server" />
                    <asp:TextBox CssClass="form_txt form_txtID" ID="txtPerfilID" ReadOnly="true" runat="server" />
                </div>
                <div class="profile_div">
                    <asp:Label Text="Email:" runat="server" />
                    <asp:TextBox CssClass="form_txt form_txtID" ID="txtPerfilEmail" ReadOnly="true" runat="server" />
                </div>
                <div class="profile_div">
                    <asp:Label Text="Password:" runat="server" />
                    <asp:TextBox CssClass="form_txt" ID="txtPerfilPass" TextMode="Password" runat="server" />
                </div>
                <div class="profile_div">
                    <asp:Label Text="Nombre:" runat="server" />
                    <asp:TextBox CssClass="form_txt" ID="txtPerfilNombre" runat="server" />
                </div>
                <div class="profile_div">
                    <asp:Label Text="Apellido:" runat="server" />
                    <asp:TextBox CssClass="form_txt" ID="txtPerfilApellido" runat="server" />
                </div>
                <div class="profile_div">
                    <asp:CheckBox CssClass="profile_txt" ID="ckdAdmin" Text="Admin" runat="server" />
                </div>
            </div>
            <div class="profile_divimg">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Label Text="Imagen de perfil:" runat="server" />
                        <asp:TextBox CssClass="form_txt" ID="txtPerfilImagen" OnTextChanged="txtPerfilImagen_TextChanged" AutoPostBack="true" runat="server" />
                        <asp:Image CssClass="profile_img" ImageUrl="imageurl" ID="imgPerfilUsuarioEdit" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <asp:Button CssClass="profile_btnEditar" ID="btnAceptarEditPerfil" OnClick="btnAceptarEditPerfil_Click" Text="Aceptar" runat="server" />
            <%} %>
        </div>
    </div>
</asp:Content>
