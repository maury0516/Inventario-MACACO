<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="CRUDProducto.aspx.cs" Inherits="MACACO.Pages.Productos.CRUDProducto" %>
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
                <asp:TextBox runat="server" ID="idsubcat" CssClass="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label" id="lblID" runat="server">Id Material</label>
                <asp:TextBox runat="server" ID="idProd" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Categoria</label>
                <asp:DropDownList class="form-control" ID="selcat" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">SubCategoria</label>
                <asp:DropDownList class="form-control" ID="selsubcat" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">Codigo de Articulo</label>
                <asp:TextBox runat="server" ID="codigoarticulo" CssClass="form-control" MaxLength="10"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre de Articulo</label>
                <asp:TextBox runat="server" ID="nombre" CssClass="form-control" MaxLength="25"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Descripcion de Articulo</label>
                <asp:TextBox runat="server" ID="descripcion" CssClass="form-control" TextMode="MultiLine" MaxLength="100"></asp:TextBox>
            </div>
            <div class="mb-3" id="divstock" runat="server">
                <label class="form-label">Unidades en Existencia</label>
                <asp:TextBox runat="server" ID="stock" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Medida</label>
                <asp:DropDownList class="form-control" ID="selmedida" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">Marca</label>
                <asp:DropDownList class="form-control" ID="selmarca" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">Area de la Empresa</label>
                <asp:DropDownList class="form-control" ID="selarea" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mb-3" id="DivEstado" runat="server">
                <label class="form-label">Estado</label>
                <asp:TextBox runat="server" ID="estadoSubCat" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            
            <asp:Button runat="server" ID="btnregistrar" CssClass="btn btn-primary" Text="Registrar Material" Visible="false" OnClick="btnregistrar_Click"/>
            <asp:Button runat="server" ID="btnactualizar" CssClass="btn btn-outline-success" Text="Actualizar Material" Visible="false" OnClick="btnactualizar_Click" />
            <asp:Button runat="server" ID="btndeshabilitar" CssClass="btn btn-outline-danger" Text="Deshabilitar Material" Visible="false" OnClick="btndeshabilitar_Click"/>
            <asp:Button runat="server" ID="btnhabilitar" CssClass="btn btn-outline-warning" Text="Habilitar Material" Visible="false" OnClick="btnhabilitar_Click"/>
            <asp:Button runat="server" ID="btnvolver" CssClass="btn btn-outline-dark" Text="Volver" Visible="true" OnClick="btnvolver_Click" />
        </div>
    </div>
</asp:Content>
