<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="SDetalle.aspx.cs" Inherits="MACACO.Pages.AdministracionProductos.Salidas.SDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!--METODO QUE VALIDA INGRESO SOLO DE NUMEROS -->
    <script>
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8 && unicode != 44) {
                if (unicode < 48 || unicode > 57) //if not a number
                { return false } //disable key press    
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br /><br />
    <div class="mx-auto" style="width: 800px">
        <h2>Detalle de Salidas</h2>
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
    </div>

    <div class="mx-auto" style="max-width: 1000px">
        <asp:Table runat="server" ID="tabla1" Visible="true">
            <asp:TableRow>
                <asp:TableCell ID="IDS" HorizontalAlign="Center" class="col-sm-3" Width="333px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">ID Salida</label>
                    <asp:TextBox runat="server" ID="txtIDSalida" CssClass="form-control" ReadOnly="true" Visible="true"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell ID="Usuario" HorizontalAlign="Center" class="col-sm-3" Width="333px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Usuario de registro</label>
                    <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" ReadOnly="true" Visible="true"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell ID="fecha" HorizontalAlign="Center" class="col-sm-3" Width="333px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Fecha</label><br />
                    <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control" type="date" Visible="true"></asp:TextBox>
                    <asp:Label runat="server" ID="lblFecha"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="Descripcion" HorizontalAlign="Center" class="col-sm-3" Width="1000px" ColumnSpan="5">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Descripcion</label>
                    <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" Visible="true" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                </asp:TableCell>                
            </asp:TableRow>
        </asp:Table>
    </div>
    <br />
    <div class="mx-auto" style="max-width:1000px">
        <asp:Table runat="server" ID="tablaIngreso" Visible="true">
            <asp:TableRow>
                <asp:TableCell ID="CodigoArticulo" HorizontalAlign="Center" class="col-sm-3" Width="400px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Codigo de Material</label>
                    <asp:DropDownList class="form-control" ID="selArticulo" runat="server">
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell ID="Cantidad" HorizontalAlign="Center" class="col-sm-3" Width="125px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Cantidad</label>
                    <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" Visible="true" onkeypress="return numbersonly(event);"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell ID="area" HorizontalAlign="Center" class="col-sm-3" Width="250px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Area Empresa</label>
                    <asp:DropDownList class="form-control" ID="selArea" runat="server">
                    </asp:DropDownList>
                </asp:TableCell>
                 <asp:TableCell ID="OP" HorizontalAlign="Center" class="col-sm-3" Width="125px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold"># de OP</label>
                    <asp:TextBox runat="server" ID="txtOP" CssClass="form-control" Visible="true" onkeypress="return numbersonly(event);"></asp:TextBox>
                </asp:TableCell>
                 <asp:TableCell ID="Agregar" HorizontalAlign="Center" VerticalAlign="Bottom" class="col-sm-3" Width="100px" >
                    <asp:Button runat="server" ID="BtnAgregar" CssClass="btn btn-outline-dark" Text="Agregar Material" Visible="true" OnClick="BtnAgregar_Click"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><br /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button runat="server" ID="BtnGuardar" CssClass="btn btn-outline-info" Text="Registrar salida de Material" OnClick="BtnGuardar_Click"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <div class="container row mx-auto" style="max-width:1000px">
            <div class="table small">
                <asp:GridView  runat="server" ID="gvproductos" class="table table-borderless table-hover fw-bold" AutoGenerateColumns="false" OnRowCommand="gvproductos_RowCommand" RowStyle-HorizontalAlign="Center" PagerStyle-HorizontalAlign="Center" PagerStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" Font-Size="Larger">
                    <Columns>
                        <asp:TemplateField HeaderText="ID" Visible="false" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle  Font-Bold="true" Font-Size="14pt" BackColor="#00CCFF" HorizontalAlign="Center"/>
                            <ItemStyle Font-Size="10pt" HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CODIGO" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle  Font-Bold="true" Font-Size="14pt" BackColor="#00CCFF" HorizontalAlign="Center"/>
                            <ItemStyle Font-Size="10pt" HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CANTIDAD" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle  Font-Bold="true" Font-Size="14pt" BackColor="#00CCFF" HorizontalAlign="Center"/>
                            <ItemStyle Font-Size="10pt" HorizontalAlign="Center"/></asp:TemplateField>
                        <asp:TemplateField HeaderText="AREA" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle  Font-Bold="true" Font-Size="14pt" BackColor="#00CCFF" HorizontalAlign="Center"/>
                            <ItemStyle Font-Size="10pt" HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="# DE OP" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle  Font-Bold="true" Font-Size="14pt" BackColor="#00CCFF" HorizontalAlign="Center"/>
                            <ItemStyle Font-Size="10pt" HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Imagenes/borrador.png" ControlStyle-Height="25px" ControlStyle-Width="25px" Visible="True" ItemStyle-HorizontalAlign="Center" />
                        
                        <asp:ButtonField />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

</asp:Content>
