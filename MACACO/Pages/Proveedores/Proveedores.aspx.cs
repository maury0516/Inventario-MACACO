using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace MACACO.Pages.Proveedores
{
    public partial class IndexProveedores : System.Web.UI.Page
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
                bool Create, Read, Update, Delete;

                //foreach  (GridViewRow fila in seleccionarusuarios.Rows)
                while (reader.Read())
                {
                    foreach (GridViewRow fila in gvProveedor.Rows)
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
                                    gvProveedor.Visible = true;
                                }
                                else
                                {
                                    btn1.Visible = true;
                                    gvProveedor.Visible = false;
                                }
                                break;
                            case "Update":
                                Update = Convert.ToBoolean(reader[1].ToString());
                                Button btn2 = fila.FindControl("Btnupdate") as Button;
                                if (Update)
                                    btn2.Visible = true;
                                else
                                    btn2.Visible = false;
                                break;
                            case "Delete":
                                Delete = Convert.ToBoolean(reader[1].ToString());
                                Button btn3 = fila.FindControl("Btndelete") as Button;
                                if (Delete)
                                    btn3.Visible = true;
                                else
                                    btn3.Visible = false;
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
                SqlCommand cmd = new SqlCommand("sp_SelProoveedores", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProveedor.DataSource = dt;
                gvProveedor.DataBind();
                con.Close();
                /*gvProveedor.Columns[1].Visible = false;*/
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
        public void Confirmar()
        {
            string msj = "swal('Good job!', 'You clicked the button!', 'success')";
            string swal = "swal('Are you sure you want to do this?', {buttons: ['yes', 'no'],})";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
            swal, true);
        }

        protected void Btncreate_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CRUDProveedor.aspx?op=C");
            //Confirmar();
        }

        protected void Btnread_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("CRUDProveedor.aspx?id=" + id + "&op=R");
        }

        protected void Btnupdate_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("CRUDProveedor.aspx?id=" + id + "&op=U");
        }

        protected void Btndelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("CRUDProveedor.aspx?id=" + id + "&op=D");
        }
        protected void Btnhabilitar_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("CRUDProveedor.aspx?id=" + id + "&op=H");
        }

        protected void BtnUserInhabilitados_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BtnRecargar.Visible = true;
                BtnInhabilitados.Visible = false;
                SqlCommand cmd = new SqlCommand("proveedores_deshabilitados", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                gvProveedor.DataSource = dt;
                gvProveedor.DataBind();

                SqlCommand cmd1 = new SqlCommand("proveedores_deshabilitados", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    foreach (GridViewRow fila in gvProveedor.Rows)
                    {
                        Button btn1 = fila.FindControl("Btnread") as Button;
                        btn1.Visible = false;
                        Button btn2 = fila.FindControl("Btnupdate") as Button;
                        btn2.Visible = false;
                        Button btn3 = fila.FindControl("Btndelete") as Button;
                        btn3.Visible = false;
                        Button btn4 = fila.FindControl("Btnhabilitar") as Button;
                        btn4.Visible = true;
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

        protected void BtnRecargar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Proveedores/Proveedores.aspx");
        }

    }
}