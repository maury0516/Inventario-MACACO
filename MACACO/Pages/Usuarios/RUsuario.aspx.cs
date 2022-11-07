using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace MACACO.Pages.Usuarios
{
    public partial class CUsuario : System.Web.UI.Page
    {
        int rol = -1;
        int est = -1;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        public static string sID = "-1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && Session["usuario"] != null)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                }
                
                    this.lblTitulo.Text = "Consulta de Usuario";
                    cargarDatos();
            }
        }

        void cargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("un_usuario", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id_usuario", SqlDbType.Int).Value = sID;

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            DataRow row = dt.Rows[0];
            idusuario.Text = row[0].ToString();
            rol = Int32.Parse(row[1].ToString());
            switch (rol)
            {
                case 1:
                    nivel.Text = "Administrador";
                    break;
                case 2:
                    nivel.Text = "Vendedor";
                    break;
                case 3:
                    nivel.Text = "Bodeguero";
                    break;
            }
            username.Text = row[2].ToString();
            nombre.Text = row[3].ToString();
            password.Text = row[4].ToString();
            est = Int32.Parse(row[5].ToString());
            switch (est)
            {
                case 0:
                    estado.Text = "Deshabilitado";
                    break;
                case 1:
                    estado.Text = "Habilitado";
                    break;
            }
            correo.Text = row[6].ToString();
            con.Close();
        }
        protected void btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }
    }
}