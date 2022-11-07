<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="MACACO.Pages.RegistrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    
    <div class="container box" style="width:500px">
        <h1 class="title">Registro de usuarios</h1>
        <div class="field">
            <label class="label">User Name</label>
            <div class="control">
                <asp:TextBox runat="server" ID="username" CssClass="input" type="text" placeholder="Ej. user101112" AutoComplete="off"></asp:TextBox>
            </div>
        </div>

        <div class="field">
            <label class="label">Nombre Completo</label>
            <div class="control">
                <asp:TextBox runat="server" ID="nombre" CssClass="input" type="text" placeholder="Ej. Juan Perez" AutoComplete="off"></asp:TextBox>
            </div>
        </div>

        <div class="field">
            <label class="label">Contraseña</label>
            <div class="control">
                <asp:TextBox runat="server" ID="clave" CssClass="input" type="text" placeholder="Ej. 12345" AutoComplete="off"></asp:TextBox>
            </div>
        </div>

        <div class="field">
            <label class="label">Correo Electronico</label>
            <div class="control">
                <asp:TextBox runat="server" ID="correo" CssClass="input" type="text" placeholder="Ej. juan@correo.com" AutoComplete="off"></asp:TextBox>
            </div>
        </div>


        <div class="control">
             <label class="label">Nivel de Usuario</label>
            <label class="radio">
                <input type="radio" ID="bodega" runat="server" GroupName="nivel">
                Bodeguero
            </label>
            <label class="radio">
                <input type="radio" ID="admin" runat="server" GroupName="nivel">
                Administrador
            </label>
            <label class="radio">
                <input type="radio" ID="user" runat="server" GroupName="nivel">
                Vendedor
            </label>
        </div>
        <br /><br />
        <div class="field is-grouped">
            <div class="control">
                <asp:Button runat="server" ID="registrar" CssClass="button is-link" OnClick="registrar_Click" Text="Enviar"/>
            </div>
            <div class="control">
                <a class="button is-link is-light" href="IndexUser.aspx">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
