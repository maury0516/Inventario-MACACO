<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="CRUDSubCategorias.aspx.cs" Inherits="MACACO.Pages.SubCategorias.CRUDSubCategorias" %>
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
                <asp:TextBox runat="server" ID="idcat" CssClass="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label" id="lblID" runat="server">Id SubCategoria</label>
                <asp:TextBox runat="server" ID="idSubCat" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre Categoria</label>
                <asp:DropDownList class="form-control" ID="selcat" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre SubCategoria</label>
                <asp:TextBox runat="server" ID="nombreSubCat" CssClass="form-control" MaxLength="60"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Calibre</label>
                <asp:TextBox runat="server" ID="calibreSubCat" CssClass="form-control" MaxLength="10"></asp:TextBox>
            </div>
            
            <div class="mb-3">
                <label class="form-label">Estado</label>
                <asp:TextBox runat="server" ID="estadoSubCat" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            
            <asp:Button runat="server" ID="btnregistrar" CssClass="btn btn-primary" Text="Registrar Categoria" Visible="false" OnClick="btnregistrar_Click"/>
            <asp:Button runat="server" ID="btnactualizar" CssClass="btn btn-outline-success" Text="Actualizar Categoria" Visible="false" OnClick="btnactualizar_Click" />
            <asp:Button runat="server" ID="btndeshabilitar" CssClass="btn btn-outline-danger" Text="Deshabilitar Categoria" Visible="false" OnClick="btndeshabilitar_Click"/>
            <asp:Button runat="server" ID="btnhabilitar" CssClass="btn btn-outline-warning" Text="Habilitar Categoria" Visible="false" OnClick="btnhabilitar_Click"/>
            <asp:Button runat="server" ID="btnvolver" CssClass="btn btn-outline-dark" Text="Volver" Visible="true" OnClick="btnvolver_Click" />
        </div>
    </div>
</asp:Content>
