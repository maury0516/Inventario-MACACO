<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="CRUDMarca.aspx.cs" Inherits="MACACO.Pages.Marcas.CRUDMarca" %>
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
                <label class="form-label" id="lblID" runat="server">Id Marca</label>
                <asp:TextBox runat="server" ID="idMarca" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre Marca</label>
                <asp:TextBox runat="server" ID="nombreMarca" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Estado</label>
                <asp:TextBox runat="server" ID="estadoMarca" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnregistrar" CssClass="btn btn-primary" Text="Registrar Marca" Visible="false" OnClick="btnregistrar_Click"/>
            <asp:Button runat="server" ID="btnactualizar" CssClass="btn btn-outline-success" Text="Actualizar Marca" Visible="false" OnClick="btnactualizar_Click" />
            <asp:Button runat="server" ID="btndeshabilitar" CssClass="btn btn-outline-danger" Text="Deshabilitar Marca" Visible="false" OnClick="btndeshabilitar_Click"/>
            <asp:Button runat="server" ID="btnhabilitar" CssClass="btn btn-outline-warning" Text="Habilitar Marca" Visible="false" OnClick="btnhabilitar_Click"/>
            <asp:Button runat="server" ID="btnvolver" CssClass="btn btn-outline-dark" Text="Volver" Visible="true" OnClick="btnvolver_Click" />
        </div>
    </div>
</asp:Content>
