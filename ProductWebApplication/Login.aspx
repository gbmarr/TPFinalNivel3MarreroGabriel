<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProductWebApplication.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class=" main_container">
        <asp:Label ID="lblLoginTitle" Text="Login" CssClass="page_titles" runat="server" />
        <div class="login_container">
            <asp:Label Text="Ingrese su email:" CssClass="login_label" runat="server" />
            <asp:TextBox ID="txtEmailLogin" CssClass="txt_login" runat="server" />
            <asp:Label Text="Password:" CssClass="login_label" runat="server" />
            <asp:TextBox ID="txtPassLogin" CssClass="txt_login" TextMode="Password" runat="server" />
        </div>
        <asp:UpdatePanel ID="UPContainerButtons" ClientIDMode="Static" runat="server">
            <ContentTemplate>
                <div class="form_containerbtn">
                    <% if (!(Request.QueryString["page"] != null))
                        {%>
                    <asp:Button ID="btnLogin" ClientIDMode="Static" OnClick="btnLogin_Click" CssClass="btn_login" Text="Ingresar" runat="server" />
                    <!-- MODAL -->
                    <script src="Scripts/modalLogin.js"></script>
                    <%}
                        else
                        { %>
                    <asp:Button ID="btnRegistrarse" ClientIDMode="Static" OnClick="btnRegistrarse_Click" CssClass="btn_login" Text="Registrarse" runat="server" />
                    <!-- MODAL -->
                    <script src="Scripts/modalRegistro.js"></script>
                    <%} %>
                    <%if (camposInvalidos)
                        { %>
                    <div class="modal_container">
                        <h3 class="modal_title">Los datos ingresados no son válidos, intentelo nuevamente.</h3>
                        <asp:Button ID="btnEntendido" OnClick="btnEntendido_Click" CssClass="modal_btn btn_agregar" Text="Entendido" runat="server" />
                    </div>
                    <%} %>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
