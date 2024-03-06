<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProductWebApplication.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class=" main_container">
        <asp:Label ID="lblLoginTitle" Text="Login" CssClass="page_titles" runat="server" />
        <div class="login_container">
            <asp:Label Text="Ingrese su email:" CssClass="login_label" runat="server" />
            <asp:TextBox ID="txtEmailLogin" CssClass="txt_login" runat="server" />
            <asp:Label Text="Password:" CssClass="login_label" runat="server" />
            <asp:TextBox ID="txtPassLogin" CssClass="txt_login" TextMode="Password" runat="server" />
            <asp:Button ID="btnLogin" OnClick="btnLogin_Click" CssClass="btn_login" Text="Ingresar" runat="server" />
        </div>
    </div>
</asp:Content>
