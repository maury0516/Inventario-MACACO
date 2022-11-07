<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="RUsuario.aspx.cs" Inherits="MACACO.Pages.Usuarios.CUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
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
            </div>
            <asp:Button runat="server" ID="btnvolver" CssClass="btn btn-outline-dark" Text="Volver" Visible="true" OnClick="btnvolver_Click" />
        </div>
    </div>
</asp:Content>
