using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MACACO.Pages.AdministracionProductos.Salidas
{
    public partial class Salidas : System.Web.UI.Page
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
                    foreach (GridViewRow fila in gvSalidas.Rows)
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
                                    gvSalidas.Visible = true;
                                }
                                else
                                {
                                    btn1.Visible = true;
                                    gvSalidas.Visible = false;
                                }
                                break;
                            //case "Update":
                            //    Update = Convert.ToBoolean(reader[1].ToString());
                            //    Button btn2 = fila.FindControl("Btnupdate") as Button;
                            //    if (Update)
                            //        btn2.Visible = true;
                            //    else
                            //        btn2.Visible = false;
                            //    break;
                            //case "Delete":
                            //    Delete = Convert.ToBoolean(reader[1].ToString());
                            //    Button btn3 = fila.FindControl("Btndelete") as Button;
                            //    if (Delete)
                            //        btn3.Visible = true;
                            //    else
                            //        btn3.Visible = false;
                            //    break;
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
                SqlCommand cmd = new SqlCommand("sp_SelSalida", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvSalidas.DataSource = dt;
                gvSalidas.DataBind();
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
            Response.Redirect("~/Pages/AdministracionProductos/Salidas/SDetalle.aspx?op=C");
        }

        protected void Btnread_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/AdministracionProductos/Salidas/SDetalle.aspx?id=" + id + "&op=R");
        }
    }
}