<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="MACACO.Pages.AdministracionProductos.Inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
     <br />   <br />  <br />
        <div class="mx-auto" style="width:1200px">
            <h2>Inventario de Materiales</h2>
        <br />
        <div class="container">
                <div class="row">
                    <div class="col align-self-end">
                        <asp:ImageButton runat="server" ID="BtnMenu" ImageUrl="~/Imagenes/atras.png" Height="50px" Width="50px" OnClick="Btnmenu_Click"/>
                         <asp:ImageButton runat="server" ID="BtnEntradas" ImageUrl="~/Imagenes/Entrada.png" Height="50px" Width="50px" OnClick="BtnEntradas_Click"/>
                        <asp:ImageButton runat="server" ID="BtnSalidas" ImageUrl="~/Imagenes/Salida.png" Height="50px" Width="50px" OnClick="BtnSalidas_Click" />
                    <asp:ImageButton runat="server" ID="BtnSolicitudes" ImageUrl="~/Imagenes/Solicitud.png" Height="50px" Width="50px" Visible="false" OnClick="BtnSolicitudes_Click"/>
                    </div>
                </div>
            </div>
        <br />
        <div class="ml-auto" style="max-width:600px">
            <label for="floatingEmptyPlaintextInput" class="fw-bold">Buscar por material</label>
            <asp:Table runat="server" ID="tablaConsulta" Visible="true">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control fw-bold" Visible="true"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button runat="server" ID="BtnBuscar" CssClass="btn btn-outline-dark" Text="Buscar" Visible="true" OnClick="BtnBuscar_Click"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
            <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView  runat="server" ID="gvproductos" class="table table-borderless table-hover fw-bold" ShowFooter="False" SortedAscendingHeaderStyle-HorizontalAlign="Center" SortedAscendingHeaderStyle-VerticalAlign="Middle" SortedAscendingHeaderStyle-BackColor="#66CCFF" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-BackColor="#663300" Font-Bold="True" Font-Italic="False" Font-Size="Medium" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" Font-Names="Comic Sans MS">
                </asp:GridView>
            </div>
        </div>
        </div>
</asp:Content>
