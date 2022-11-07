<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="Areas.aspx.cs" Inherits="MACACO.Pages.AreasEmpresa.Areas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Areas de la Empresa
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />   <br />  <br />
    <div class="mx-auto" style="width: 800px">
        <h2>Areas de la Empresa</h2>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:ImageButton runat="server" ID="BtnMenu" ImageUrl="~/Imagenes/atras.png" Height="50px" Width="50px" OnClick="Btnmenu_Click" />
                    <asp:ImageButton runat="server" ID="Btncreate" ImageUrl="~/Imagenes/empresa.png" Height="50px" Width="50px" OnClick="Btncreate_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvArea" class="table table-borderless table-hover fw-bold" ShowFooter="False" SortedAscendingHeaderStyle-HorizontalAlign="Center" SortedAscendingHeaderStyle-VerticalAlign="Middle" SortedAscendingHeaderStyle-BackColor="#66CCFF" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-BackColor="#000099" Font-Bold="True" Font-Italic="False" Font-Size="Larger" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" Font-Names="Comic Sans MS">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <div class="btn-group" role="group" aria-label="Basic mixed styles example">
                                    <asp:Button runat="server" CssClass="btn form-control-sm btn-outline-info" ID="Btnread" Text="Consultar" OnClick="Btnread_Click"/>
                                    <asp:Button runat="server" CssClass="btn form-control-sm btn-outline-success" ID="Btnupdate" Text="Actualizar" OnClick="Btnupdate_Click"/>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
