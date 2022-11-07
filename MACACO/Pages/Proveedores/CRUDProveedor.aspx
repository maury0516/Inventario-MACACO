<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="CRUDProveedor.aspx.cs" Inherits="MACACO.Pages.Proveedores.CRUDProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br /><br />
    <div class="mx-auto" style="width: 500px">
        <asp:Label runat="server" CssClass="h2" ID="lblTitulo"></asp:Label>
        <div>
            <div class="mb-3">
                <label class="form-label" id="lblID" runat="server">Id del Usuario</label>
                <asp:TextBox runat="server" ID="idprov" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre del Proveedor</label>
                <asp:TextBox runat="server" ID="nomprov" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Direccion</label>
                <asp:TextBox runat="server" ID="dirprov" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">numero telefónico</label>
                <asp:TextBox runat="server" ID="telprov" CssClass="form-control" MaxLength="8"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Correo de contacto</label>
                <asp:TextBox runat="server" Type="email" ID="correo" CssClass="form-control" MaxLength="25"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Estado</label>
                <asp:TextBox runat="server" ID="estado" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnregistrar" CssClass="btn btn-primary" Text="Registrar Proveedor" Visible="false" OnClick="btnregistrar_Click"/>
            <asp:Button runat="server" ID="btnactualizar" CssClass="btn btn-outline-success" Text="Actualizar Proveedor" Visible="false" OnClick="btnactualizar_Click" />
            <asp:Button runat="server" ID="btndeshabilitar" CssClass="btn btn-outline-danger" Text="Deshabilitar Proveedor" Visible="false" OnClick="btndeshabilitar_Click"/>
            <asp:Button runat="server" ID="btnhabilitar" CssClass="btn btn-outline-warning" Text="Habilitar Proveedor" Visible="false" OnClick="btnhabilitar_Click"/>
            <asp:Button runat="server" ID="btnvolver" CssClass="btn btn-outline-dark" Text="Volver" Visible="true" OnClick="btnvolver_Click" />
        </div>
    </div>
</asp:Content>
