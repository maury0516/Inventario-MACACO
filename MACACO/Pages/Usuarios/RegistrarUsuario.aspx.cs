using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MACACO.Pages
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Cache-Control", "no-store");
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());

        string patron = "InfoToolsSV";
        void Limpiar() {
            username.Text = string.Empty;
            nombre.Text = string.Empty;
            clave.Text = string.Empty;
            correo.Text = string.Empty;
        }

        protected void registrar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_registrar_usuario", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value = username.Text;
                cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nombre.Text;
                cmd.Parameters.Add("@clave", System.Data.SqlDbType.VarChar).Value = clave.Text;
                cmd.Parameters.Add("@correo", System.Data.SqlDbType.VarChar).Value = correo.Text;
                cmd.Parameters.Add("@patron", System.Data.SqlDbType.VarChar).Value = patron;
                cmd.Parameters.Add("@estado", System.Data.SqlDbType.Int).Value = 1;
                if(bodega.Checked)
                    cmd.Parameters.Add("@id_rol", System.Data.SqlDbType.Int).Value = 3;
                else if(admin.Checked)
                    cmd.Parameters.Add("@id_rol", System.Data.SqlDbType.Int).Value = 1;
                else if(user.Checked)
                    cmd.Parameters.Add("@id_rol", System.Data.SqlDbType.Int).Value = 2;
                else
                    cmd.Parameters.Add("@id_rol", System.Data.SqlDbType.Int).Value = 2;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("IndexUser.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}