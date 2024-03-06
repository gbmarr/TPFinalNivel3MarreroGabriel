<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ProductWebApplication.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main_container">
        <h2 class="page_titles">Perfil</h2>
        <div class="profile_container">
            <asp:Label Text="ID:" runat="server" />
            <asp:Label CssClass="profile_txt profile_id" ID="lblID" Text="" runat="server" />
            <asp:Label Text="Nombre:" runat="server" />
            <asp:Label CssClass="profile_txt" ID="lblNombre" Text="" runat="server" />
            <asp:Label Text="Apellido:" runat="server" />
            <asp:Label CssClass="profile_txt" ID="imgImagenPerfil" Text="" runat="server" />
            <div>
                <asp:CheckBox CssClass="profile_img" ID="ckbAdmin" Text="Admin" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
