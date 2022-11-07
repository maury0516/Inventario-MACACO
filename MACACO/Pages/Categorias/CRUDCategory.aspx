<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="CRUDCategory.aspx.cs" Inherits="MACACO.Pages.Categorias.CRUDCategory" %>
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
                <label class="form-label" id="lblID" runat="server">Id Categoria</label>
                <asp:TextBox runat="server" ID="idCat" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre Categoria</label>
                <asp:TextBox runat="server" ID="nombreCat" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Descripcion</label>
                <asp:TextBox runat="server" ID="descripcionCat" CssClass="form-control" TextMode="MultiLine" MaxLength="100"></asp:TextBox>
            </div>
            
            <div class="mb-3">
                <label class="form-label">Estado</label>
                <asp:TextBox runat="server" ID="estadoCat" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            
            <asp:Button runat="server" ID="btnregistrar" CssClass="btn btn-primary" Text="Registrar Categoria" Visible="false" OnClick="btnregistrar_Click"/>
            <asp:Button runat="server" ID="btnactualizar" CssClass="btn btn-outline-success" Text="Actualizar Categoria" Visible="false" OnClick="btnactualizar_Click" />
            <asp:Button runat="server" ID="btndeshabilitar" CssClass="btn btn-outline-danger" Text="Deshabilitar Categoria" Visible="false" OnClick="btndeshabilitar_Click"/>
            <asp:Button runat="server" ID="btnhabilitar" CssClass="btn btn-outline-warning" Text="Habilitar Categoria" Visible="false" OnClick="btnhabilitar_Click"/>
            <asp:Button runat="server" ID="btnvolver" CssClass="btn btn-outline-dark" Text="Volver" Visible="true" OnClick="btnvolver_Click" />
        </div>
    </div>
</asp:Content>
