using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MACACO.Pages.Usuarios
{
    public partial class CUsuario1 : System.Web.UI.Page
    {
        int rol = -1;
        int est = -1;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && Session["usuario"] != null)
            {
                this.lblTitulo.Text = "Ingresar Nuevo Usuario";
            }
        }
        void Limpiar()
        {
            username.Text = string.Empty;
            nombre.Text = string.Empty;
            password.Text = string.Empty;
            correo.Text = string.Empty;
            idusuario.Text = string.Empty;
            estado.Text = string.Empty;
            admin.Checked = false;
            bodega.Checked = false;
            user.Checked = false;
        }
    }
}