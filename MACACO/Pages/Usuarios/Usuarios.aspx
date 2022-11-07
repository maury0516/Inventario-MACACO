<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="MACACO.Pages.Usuarios.IndexUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Listado de Usuarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <%--<link href="Estilo.css" rel="stylesheet" />
    <script type="text/javascript">
        function Resaltar_On(gvusuarios) {
             if (gvusuarios != null) {
                 gvusuarios.originalBgColor = gvusuarios.style.backgroundColor;
                 gvusuarios.style.backgroundColor = "red";
    }
         }

        function Resaltar_Off(gvusuarios) {
             if (gvusuarios != null) {
                 gvusuarios.style.backgroundColor = gvusuarios.originalBgColor;

             }
         }
    </script>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <br />  <br />  <br />  
    <div class="mx-auto" style="width: 1300px">
        <h2>Listado de Usuarios</h2>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:ImageButton runat="server" ID="BtnMenu" ImageUrl="~/Imagenes/atras.png" Height="50px" Width="50px" OnClick="Btnmenu_Click" />
                    <asp:ImageButton runat="server" ID="btncreate" ImageUrl="~/Imagenes/add-user1.png" Height="50px" Width="50px" OnClick="Btncreate_Click" />
                    <asp:ImageButton runat="server" ID="BtnUserInhabilitados" ImageUrl="~/Imagenes/basura.png" Height="50px" Width="50px" OnClick="BtnUserInhabilitados_Click" />
                    <asp:ImageButton runat="server" ID="BtnRecargar" ImageUrl="~/Imagenes/volver-a-publicar.png" Height="50px" Width="50px" Visible="false" OnClick="BtnRecargar_Click"/>
                </div>
            </div>
        </div>
        <br />
        <div class="container row mx-auto" style="width: 1300px">
            <div class="table small" style="width: 1250px; height: 500px; overflow: auto">
                <asp:GridView runat="server" ID="gvusuarios" class="table table-borderless table-hover fw-bold " ShowFooter="False" SortedAscendingHeaderStyle-HorizontalAlign="Center" SortedAscendingHeaderStyle-VerticalAlign="Middle" SortedAscendingHeaderStyle-BackColor="#66CCFF" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-BackColor="#000099" Font-Bold="True" Font-Italic="False" Font-Size="Medium" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" Font-Names="Comic Sans MS">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <div class="btn-group" role="group" aria-label="Basic mixed styles example">
                                    <asp:Button runat="server" CssClass="btn form-control-sm btn-outline-info" ID="btnread" Text="Consultar" OnClick="Btnread_Click" />
                                    <asp:Button runat="server" CssClass="btn form-control-sm btn-outline-success" ID="btnupdate" Text="Actualizar" OnClick="Btnupdate_Click" />
                                    <asp:Button runat="server" CssClass="btn form-control-sm btn-outline-danger" ID="btndelete" Text="Deshabilitar" OnClick="Btndelete_Click" />
                                    <asp:Button runat="server" CssClass="btn form-control-sm btn-outline-warning" ID="btnhabilitar" Text="Habilitar" Visible="false" OnClick="Btnhabilitar_Click"/>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>


</asp:Content>
