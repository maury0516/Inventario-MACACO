<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="EDetalle.aspx.cs" Inherits="MACACO.Pages.AdministracionProductos.Entradas.EDetalle" %>
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

    <!--METODO QUE VALIDA INGRESO DE DECIMAL CON DOS DIGITOS-->
    <script>
        function filterFloat(evt, input) {
            // Backspace = 8, Enter = 13, ‘0′ = 48, ‘9′ = 57, ‘.’ = 46, ‘-’ = 43
            var key = window.Event ? evt.which : evt.keyCode;
            var chark = String.fromCharCode(key);
            var tempValue = input.value + chark;
            if (key >= 48 && key <= 57) {
                if (filter(tempValue) === false) {
                    return false;
                } else {
                    return true;
                }
            } else {
                if (key == 8 || key == 13 || key == 0) {
                    return true;
                } else if (key == 46) {
                    if (filter(tempValue) === false) {
                        return false;
                    } else {
                        return true;
                    }
                } else {
                    return false;
                }
            }
        }
        function filter(__val__) {
            var preg = /^([0-9]+\.?[0-9]{0,2})$/;
            if (preg.test(__val__) === true) {
                return true;
            } else {
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
        <br /><br />
    <div class="mx-auto" style="width: 800px">
        <h2>Detalle de Entrada</h2>
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
                <asp:TableCell ID="IDE" HorizontalAlign="Center" class="col-sm-3" Width="200px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">ID Entrada</label>
                    <asp:TextBox runat="server" ID="txtIDEntrada" CssClass="form-control fw-bold" ReadOnly="true" Visible="true"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell ID="Prov" HorizontalAlign="Center" class="col-sm-3" Width="300px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Proveedor</label>
                    <asp:DropDownList class="form-control fw-bold" ID="selProv" runat="server">
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell ID="Usuario" HorizontalAlign="Center" class="col-sm-3" Width="200px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Usuario de registro</label>
                    <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control fw-bold" ReadOnly="true" Visible="true"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell ID="fecha" HorizontalAlign="Center" class="col-sm-3" Width="300px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Fecha</label><br />
                    <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control fw-bold" type="date" Visible="true"></asp:TextBox>
                    <asp:Label runat="server" ID="lblFecha" CssClass="fw-bold"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="Comprobante" HorizontalAlign="Center" class="col-sm-3" Width="333px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Tipo de Comprobante</label>
                    <asp:DropDownList class="form-control fw-bold" id="selComprobante" runat="server">

                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell ID="numeroComprobante" HorizontalAlign="Center" class="col-sm-3" Width="333px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Numero de Comprobante</label>
                    <asp:TextBox runat="server" ID="txtNumComprobante" CssClass="form-control fw-bold" Visible="true" onkeypress="return numbersonly(event);"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell ID="archivo" HorizontalAlign="Center" ColumnSpan="2" VerticalAlign="Bottom">
                     <label for="floatingEmptyPlaintextInput" class="fw-bold">Copia digital de documento</label>
                    <input type="file" class="form-control" id="inputFile">
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
                    <asp:DropDownList class="form-control fw-bold" ID="selArticulo" runat="server">
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell ID="Cantidad" HorizontalAlign="Center" class="col-sm-3" Width="125px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Cantidad</label>
                    <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control fw-bold" Visible="true" onkeypress="return numbersonly(event);"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell ID="area" HorizontalAlign="Center" class="col-sm-3" Width="250px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Area Empresa</label>
                    <asp:DropDownList class="form-control fw-bold" ID="selArea" runat="server">
                    </asp:DropDownList>
                </asp:TableCell>
                 <asp:TableCell ID="PrecioUnitario" HorizontalAlign="Center" class="col-sm-3" Width="125px">
                    <label for="floatingEmptyPlaintextInput" class="fw-bold">Precio</label>
                    <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control fw-bold" Visible="true" onkeypress="return filterFloat(event,this);"></asp:TextBox>
                </asp:TableCell>
                 <asp:TableCell ID="Agregar" HorizontalAlign="Center" VerticalAlign="Bottom" class="col-sm-3" Width="100px" >
                    <asp:Button runat="server" ID="BtnAgregar" CssClass="btn btn-outline-dark" Text="Agregar Material" Visible="true" OnClick="BtnAgregar_Click"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><br />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button runat="server" ID="BtnGuardar" CssClass="btn btn-outline-info" Text="Guardar Entrada"  OnClick="BtnGuardar_Click"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <br />
    
    <div class="container row mx-auto" style="max-width:1000px">
            <div class="table small">
                <asp:GridView  runat="server" ID="gvproductos" class="table table-borderless table-hover fw-bold" AutoGenerateColumns="false" OnRowCommand="gvproductos_RowCommand" HeaderStyle-HorizontalAlign="Center" Font-Size="Larger">
                    <Columns>
                        <asp:TemplateField HeaderText="ID" Visible="false"></asp:TemplateField>
                        <asp:TemplateField HeaderText="CODIGO">
                            <HeaderStyle  Font-Bold="true" Font-Size="14pt" BackColor="#33CC33" HorizontalAlign="Center"/>
                            <ItemStyle Font-Size="10pt" HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CANTIDAD">
                            <HeaderStyle  Font-Bold="true" Font-Size="14pt" BackColor="#33CC33" HorizontalAlign="Center"/>
                            <ItemStyle Font-Size="10pt" HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AREA">
                            <HeaderStyle  Font-Bold="true" Font-Size="14pt" BackColor="#33CC33" HorizontalAlign="Center"/>
                            <ItemStyle Font-Size="10pt" HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PRECIO">
                            <HeaderStyle  Font-Bold="true" Font-Size="14pt" BackColor="#33CC33" HorizontalAlign="Center"/>
                            <ItemStyle Font-Size="10pt" HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:ButtonField HeaderText="Borrar" ButtonType="Image" ImageUrl="~/Imagenes/borrador.png" ControlStyle-Height="25px" ControlStyle-Width="25px" ItemStyle-HorizontalAlign="Center"/>
                            
                        <asp:ButtonField />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    <div class="container row mx-auto" style="max-width:1000px">
            <div class="table small">
                <asp:GridView  runat="server" ID="gvProdCarga" class="table table-borderless table-hover fw-bold" ShowFooter="False" SortedAscendingHeaderStyle-HorizontalAlign="Center" SortedAscendingHeaderStyle-VerticalAlign="Middle" SortedAscendingHeaderStyle-BackColor="#66CCFF" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-BackColor="#003300" Font-Bold="True" Font-Italic="False" Font-Size="Medium" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" Font-Names="Comic Sans MS">
                </asp:GridView>
            </div>
        </div>

</asp:Content>