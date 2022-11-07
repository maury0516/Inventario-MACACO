using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MACACO.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Cache-Control", "no-store");
            username.Focus();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        //string patron = "InfoToolsSV";

        protected void ingresar_Click(object sender, EventArgs e)
        {
            try{
                SqlCommand cmd = new SqlCommand("sp_login", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value = username.Text;
                cmd.Parameters.Add("@clave", System.Data.SqlDbType.VarChar).Value = clave.Text;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    Session["id_rol"] = rd[1].ToString();
                    Session["usuario"] = rd[2].ToString();
                    Response.Redirect("menu.aspx");
                    //Response.Redirect("menu.aspx?user=" + user);
                }
                else {
                    string msj = "swal('ERROR', 'Usuario o Contraseña incorrectos', 'error')";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                    msj, true);
                    username.Text = null;
                    clave.Text = null;
                    username.Focus();
                }
                con.Close();
            }
            catch (Exception) {
                throw;
            }
        }
    }
}