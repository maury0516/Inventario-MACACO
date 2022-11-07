<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="crudUsuarios.aspx.cs" Inherits="MACACO.Pages.Usuarios.crudUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
        Administración de Usuarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width: 500px">
        <asp:Label runat="server" CssClass="h2" ID="lblTitulo"></asp:Label>
        <div>
            <div class="mb-3">
                <label class="form-label" id="lblID" runat="server">Id del Usuario</label>
                <asp:TextBox runat="server" ID="idusuario" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">UserName</label>
                <asp:TextBox runat="server" ID="username" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre Completo</label>
                <asp:TextBox runat="server" ID="nombre" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Correo de Usuario</label>
                <asp:TextBox runat="server" Type="email" ID="correo" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña de Usuario</label>
                <asp:TextBox runat="server" ID="password" CssClass="form-control" Type="password"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Estado de Usuario</label>
                <asp:TextBox runat="server" ID="estado" CssClass="form-control"></asp:TextBox>

            </div>
            <div class="mb-3">
                <label class="form-label">Nivel de Usuario</label>
                <asp:TextBox runat="server" ID="nivel" CssClass="form-control"></asp:TextBox>
                <br />
                <div class="control" id="radios" runat="server">
                    <label class="radio">
                        <input type="radio" id="bodega" runat="server" groupname="nivel">
                        Bodeguero
                    </label>
                    <label class="radio">
                        <input type="radio" id="admin" runat="server" groupname="nivel">
                        Administrador
                    </label>
                    <label class="radio">
                        <input type="radio" id="user" runat="server" groupname="nivel">
                        Vendedor
                    </label>
                </div>
            </div>

            <asp:Button runat="server" ID="btnregistrar" CssClass="btn btn-primary" Text="Registrar Usuario" Visible="false" OnClick="btnregistrar_Click"/>
            <asp:Button runat="server" ID="btnactualizar" CssClass="btn btn-outline-success" Text="Actualizar Usuario" Visible="false" OnClick="btnactualizar_Click" />
            <asp:Button runat="server" ID="btndeshabilitar" CssClass="btn btn-outline-danger" Text="Deshabilitar Usuario" Visible="false" OnClick="btndeshabilitar_Click"/>
            <asp:Button runat="server" ID="btnhabilitar" CssClass="btn btn-outline-warning" Text="Habilitar Usuario" Visible="false" OnClick="btnhabilitar_Click"/>
            <asp:Button runat="server" ID="btnvolver" CssClass="btn btn-outline-dark" Text="Volver" Visible="true" OnClick="btnvolver_Click" />
        </div>
    </div>
</asp:Content>

