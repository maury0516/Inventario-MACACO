﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="TEntradas.aspx.cs" Inherits="MACACO.Pages.AdministracionProductos.Entradas.TEntradas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <br />
    <br />
    <div class="mx-auto" style="width: 1300px">
        <h2>Lista de Entradas de Materiales</h2>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:ImageButton runat="server" ID="BtnAtras" ImageUrl="~/Imagenes/atras.png" Height="50px" Width="50px" OnClick="BtnAtras_Click" />
                    <asp:ImageButton runat="server" ID="BtnMenu" ImageUrl="~/Imagenes/home.png" Height="50px" Width="50px" OnClick="BtnMenu_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="ml-auto" style="max-width: 600px">
            <label for="floatingEmptyPlaintextInput" class="fw-bold">Buscar por material</label>
            <asp:Table runat="server" ID="tablaConsulta" Visible="true">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control fw-bold" Visible="true" AutoComplete="off"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button runat="server" ID="BtnBuscar" CssClass="btn btn-outline-dark" Text="Buscar" Visible="true" OnClick="BtnBuscar_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvproductos" class="table table-borderless table-hover fw-bold" ShowFooter="False" SortedAscendingHeaderStyle-HorizontalAlign="Center" SortedAscendingHeaderStyle-VerticalAlign="Middle" SortedAscendingHeaderStyle-BackColor="#66CCFF" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-BackColor="#000099" Font-Bold="True" Font-Italic="False" Font-Size="Medium" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" Font-Names="Comic Sans MS">
                   <%-- <Columns>
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <div class="btn-group" role="group" aria-label="Basic mixed styles example">
                                    <asp:Button runat="server" CssClass="btn form-control-sm btn-outline-info" ID="Btnread" Text="Consultar" OnClick="Btnread_Click" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>--%>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
