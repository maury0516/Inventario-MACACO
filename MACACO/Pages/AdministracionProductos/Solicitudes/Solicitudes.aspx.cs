using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MACACO.Pages.AdministracionProductos.Solicitudes
{
    public partial class Solicitudes : System.Web.UI.Page
    {
        int id_rol = 0;
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Cache-Control", "no-store");
            if (!IsPostBack && Session["usuario"] != null)
            {
                id_rol = Convert.ToInt32(Session["id_rol"].ToString());
                Datos();
                Permisos(id_rol);
            }
        }

        void Permisos(int id_rol)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_permisos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = id_rol;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                bool Create, Read;

                //foreach  (GridViewRow fila in seleccionarusuarios.Rows)
                while (reader.Read())
                {
                    foreach (GridViewRow fila in gvSolicitudes.Rows)
                    //while (reader.Read())
                    {
                        switch (reader[0].ToString())
                        {
                            case "Create":
                                Create = Convert.ToBoolean(reader[1].ToString());
                                if (Create)
                                    Btncreate.Visible = true;
                                else
                                    Btncreate.Visible = false;
                                break;
                            case "Read":
                                Read = Convert.ToBoolean(reader[1].ToString());
                                Button btn1 = fila.FindControl("Btnread") as Button;
                                if (Read)
                                {
                                    btn1.Visible = true;
                                    gvSolicitudes.Visible = true;
                                }
                                else
                                {
                                    btn1.Visible = true;
                                    gvSolicitudes.Visible = false;
                                }
                                break;
                            case "Update":
                                
                                break;
                            case "Delete":
                                
                                break;
                        }
                    }
                }
                con.Close();
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        void Datos()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_SelSolicitud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvSolicitudes.DataSource = dt;
                gvSolicitudes.DataBind();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void Btnmenu_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/menu.aspx");
        }

        protected void Btncreate_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/AdministracionProductos/Solicitudes/SolDetalle.aspx?op=C");
        }
    }
}