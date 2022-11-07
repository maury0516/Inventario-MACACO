<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="crudAreaEmpresa.aspx.cs" Inherits="MACACO.Pages.AreasEmpresa.crudAreaEmpresa" %>
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
                <label class="form-label" id="lblID" runat="server">Id del Area</label>
                <asp:TextBox runat="server" ID="idarea" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre Area</label>
                <asp:TextBox runat="server" ID="nombre" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Descripción</label>
                <asp:TextBox runat="server"  ID="descripcion" CssClass="form-control" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Encargado del Area</label>
                <asp:TextBox runat="server" ID="encargado" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnregistrar" CssClass="btn btn-primary" Text="Agregar Area" Visible="false" OnClick="btnregistrar_Click"/>
            <asp:Button runat="server" ID="btnactualizar" CssClass="btn btn-outline-success" Text="Actualizar Area" Visible="false" OnClick="btnactualizar_Click" />
            <asp:Button runat="server" ID="btnvolver" CssClass="btn btn-outline-dark" Text="Volver" Visible="true" OnClick="btnvolver_Click" />
        </div>
    </div>
</asp:Content>
