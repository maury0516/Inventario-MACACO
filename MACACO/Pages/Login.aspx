<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MP.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MACACO.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    LOGIN
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br /><br />
    <div class="mx-auto" style="max-width:600px">
        <br />
        <h1 class="title" style="text-align:center">Inicio de Sesión</h1>
        <div class="container">
            <img src="~/Imagenes/user.png" runat="server" width="250" height="250" class="mx-auto d-block"/>
        </div>
        <br />
        <div class="col align-self-end mx-auto" style="margin-left:5px; margin-right:5px">
            <h3 style="text-align:center"><label class="label" Font-Bold="True">Usuario</label></h3>
            <div class="control">
                <asp:Textbox runat="server" ID="username" CssClass="form-control" type="text" placehonder="Ej. user101112" AutoComplete="off" required="true" Font-Bold="True" Font-Names="Comic Sans MS" Font-Size="Larger"></asp:Textbox>
            </div>
        </div>
        <br />
        <div class="col align-self-end mx-auto" style="margin-left:5px; margin-right:5px">
            <h3 style="text-align:center"><label class="label" Font-Bold="True" >Password</label></h3>
            <div class="control">
                <asp:Textbox runat="server" id="clave" CssClass="form-control" type="password" placehonder="Ej. 12345" AutoComplete="off" required="true" Font-Size="Larger" Font-Names="Comic Sans MS"></asp:Textbox>
            </div>
        </div>
        <br />
        <div class="d-grid gap-2" style="margin-left:5px; margin-right:5px; margin-bottom:5px">
            <asp:Button runat="server" ID="ingresar" CssClass="btn btn-outline-success" class="btn btn-primary" type="button" text="Ingresar" OnClick="ingresar_Click" Font-Size="XX-Large" Font-Names="Comic Sans MS" />
        </div>
        
    </div>
</asp:Content>
