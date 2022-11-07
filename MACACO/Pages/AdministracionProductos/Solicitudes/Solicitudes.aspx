<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="Solicitudes.aspx.cs" Inherits="MACACO.Pages.AdministracionProductos.Solicitudes.Solicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Solicitudes de Materiales
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />   <br />  <br />
        <div class="mx-auto" style="width:800px">
            <h2>Solicitudes de Materiales</h2>
        <br /> 
        <div class="container">
                <div class="row">
                    <div class="col align-self-end">
                        <asp:ImageButton runat="server" ID="BtnMenu" ImageUrl="~/Imagenes/atras.png" Height="50px" Width="50px" OnClick="Btnmenu_Click"/>
                         <asp:ImageButton runat="server" ID="Btncreate" ImageUrl="~/Imagenes/demanda.png" Height="50px" Width="50px" OnClick="Btncreate_Click"/>
                    </div>
                </div>
            </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView  runat="server" ID="gvSolicitudes" class="table table-borderless table-hover fw bold" ShowFooter="False" SortedAscendingHeaderStyle-HorizontalAlign="Center" SortedAscendingHeaderStyle-VerticalAlign="Middle" SortedAscendingHeaderStyle-BackColor="#66CCFF" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-BackColor="#000099" Font-Bold="True" Font-Italic="False" Font-Size="Medium" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" Font-Names="Comic Sans MS">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <div class="btn-group" role="group" aria-label="Basic mixed styles example">
                                    <asp:Button runat="server" CssClass="btn form-control-sm btn-outline-info" ID="Btnread" Text="Consultar"/>
                                    <%--<asp:Button runat="server" CssClass="btn form-control-sm btn-outline-success" ID="Btnupdate" Text="Actualizar"/>
                                    <asp:Button runat="server" CssClass="btn form-control-sm btn-outline-danger" ID="Btndelete" Text="Deshabilitar"/>--%>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        </div>
</asp:Content>
