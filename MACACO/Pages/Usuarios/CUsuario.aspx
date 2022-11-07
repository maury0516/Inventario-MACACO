<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="CUsuario.aspx.cs" Inherits="MACACO.Pages.Usuarios.CUsuario1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="modal fade" id="Ventana">
        <div class="modal-dialog">
            <p>lodem</p>
        </div>
    </div>
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
            <a href="#Ventana" class="btn btn-primary" data-toggle="modal">Registrar</a>
           <%-- <asp:Button runat="server" ID="btnregistrar" CssClass="btn btn-primary" Text="Registrar Usuario" Visible="false" OnClick="btnregistrar_Click"/>
            <asp:Button runat="server" ID="btnvolver" CssClass="btn btn-outline-dark" Text="Volver" Visible="true" OnClick="btnvolver_Click" />--%>
        </div>
    </div>
    
</asp:Content>
