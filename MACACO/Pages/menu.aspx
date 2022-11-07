<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="MACACO.Pages.menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    MENU
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br /><br /><br />
    <!-- TABLA MENU DE ADMINISTRADOR-->
    <div class="mx-auto" style="max-width:1000px">
        <asp:Table runat="server" ID="tableMenu" Visible="false">
        <asp:TableRow>
            <asp:TableCell ID="categoria" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnCat" ImageUrl="~/Imagenes/categorias.png" Height="133" Width="169" OnClick="BtnCat_Click"/>
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Categorias</label>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="subcategoria" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnSubCat" ImageUrl="~/Imagenes/Sub categoria.png" Height="133" Width="169" OnClick="BtnSubCat_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Sub Categorias</label>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="area" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnAreas" ImageUrl="~/Imagenes/area.png" Height="133" Width="169" OnClick="BtnAreas_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Areas de la empresa</label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="articulo" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnProds" ImageUrl="~/Imagenes/articulo.png" Height="133" Width="169" OnClick="BtnProductos_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Listado de Materiales</label>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="marca" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnMarca" ImageUrl="~/Imagenes/Marcas.png" Height="133" Width="169" OnClick="BtnMarca_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Marcas de Materiales</label>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="medida" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnMedida" ImageUrl="~/Imagenes/medida.png" Height="133" Width="169" OnClick="BtnMedida_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Unidades de Medida</label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ID="entrada" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnEntrada" ImageUrl="~/Imagenes/Entrada.png" Height="133" Width="169" OnClick="BtnEntrada_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Entrada de Matariales</label>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="salida" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnSalida" ImageUrl="~/Imagenes/Salida.png" Height="133" Width="169" OnClick="BtnSalida_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Salida de Materiales</label>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="solicitud" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnSolicitud" ImageUrl="~/Imagenes/solicitud.png" Height="133" Width="169" OnClick="BtnSolicitud_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Solicitudes de Compra</label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="proveedor" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnProv" ImageUrl="~/Imagenes/Proveedor.png" Height="133" Width="169"  OnClick="BtnProv_Click"/>
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Proveedores</label>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="usuario" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnUser" ImageUrl="~/Imagenes/programmer.png" Height="133" Width="169" OnClick="BtnUser_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Usuarios</label>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="inventario" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnInventario" ImageUrl="~/Imagenes/inventario.png" Height="133" Width="169" OnClick="BtnInventario_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Inventario</label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </div>


    <!-- TABLA MENU DE PERFIL VENDEDOR-->
    <div class="mx-auto" style="max-width:1000px">
        <asp:Table runat="server" ID="tableMenuVendedor" Visible="false">
        <asp:TableRow>
            <asp:TableCell ID="articulo1" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnProds1" ImageUrl="~/Imagenes/articulo.png" Height="133" Width="169" OnClick="BtnProductos_Click" /><br />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Listado de Materiales</label>
            </asp:TableCell>
			<asp:TableCell ID="solicitud1" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnSolicitud1" ImageUrl="~/Imagenes/solicitud.png" Height="133" Width="169" OnClick="BtnSolicitud_Click" /><br />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Solicitudes de Compra</label>
            </asp:TableCell>
            <asp:TableCell ID="inventario1" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnInventario1" ImageUrl="~/Imagenes/inventario.png" Height="133" Width="169" OnClick="BtnInventario_Click" /><br />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Inventario</label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </div>


    <!-- TABLA MENU DE PERFIL BODEGA-->
    <div class="mx-auto" style="max-width:1000px">
        <asp:Table runat="server" ID="tableMenuBodega" Visible="false">
        <asp:TableRow>
            <asp:TableCell ID="categoria2" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnCat2" ImageUrl="~/Imagenes/categorias.png" Height="133" Width="169" OnClick="BtnCat_Click"/>
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Categorias</label>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="subcategoria2" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnSubCat2" ImageUrl="~/Imagenes/Sub categoria.png" Height="133" Width="169" OnClick="BtnSubCat_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Sub Categorias</label>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="proveedor2" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnProv2" ImageUrl="~/Imagenes/Proveedor.png" Height="133" Width="169"  OnClick="BtnProv_Click"/>
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Proveedores</label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="articulo2" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnProds2" ImageUrl="~/Imagenes/articulo.png" Height="133" Width="169" OnClick="BtnProductos_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Listado de Materiales</label>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="marca2" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnMarca2" ImageUrl="~/Imagenes/Marcas.png" Height="133" Width="169" OnClick="BtnMarca_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Marcas de Materiales</label>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ID="medida2" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnMedida2" ImageUrl="~/Imagenes/medida.png" Height="133" Width="169" OnClick="BtnMedida_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Unidades de Medida</label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ID="inventario3" HorizontalAlign="Center" class="col-sm-3">
                <asp:ImageButton runat="server" ID="BtnInventario2" ImageUrl="~/Imagenes/inventario.png" Height="133" Width="169" OnClick="BtnInventario_Click" />
                <label for="floatingEmptyPlaintextInput" class="fw-bold">Inventario</label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </div>
</asp:Content>
