<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ProductWebApplication.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main_container">
        <h2 class="page_titles">Perfil</h2>
        <div class="profile_container">
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
        </div>
    </div>
</asp:Content>
