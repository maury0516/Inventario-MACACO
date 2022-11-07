using MACACO.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MACACO.Pages.Usuarios
{
    public partial class IndexUser : System.Web.UI.Page
    {
        public static string mensaje = "";
        public static string usuario = "";
        public static int tipo = 0;
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

        void Datos()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SeleccionarUsuarios", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvusuarios.DataSource = dt;
                gvusuarios.DataBind();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        void Permisos(int id_rol)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_permisos", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = id_rol;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                bool Create, Read, Update, Delete;

                //foreach  (GridViewRow fila in seleccionarusuarios.Rows)
                while (reader.Read())
                {
                    foreach (GridViewRow fila in gvusuarios.Rows)
                    {
                        switch (reader[0].ToString())
                        {
                            case "Create":
                                Create = Convert.ToBoolean(reader[1].ToString());
                                if (Create)
                                    btncreate.Visible = true;
                                else
                                    btncreate.Visible = false;
                                break;
                            case "Read":
                                Read = Convert.ToBoolean(reader[1].ToString());
                                Button btn1 = fila.FindControl("btnread") as Button;
                                if (Read)
                                {
                                    btn1.Visible = true;
                                    gvusuarios.Visible = true;
                                }
                                else
                                {
                                    btn1.Visible = true;
                                    gvusuarios.Visible = false;
                                }
                                break;
                            case "Update":
                                Update = Convert.ToBoolean(reader[1].ToString());
                                Button btn2 = fila.FindControl("btnupdate") as Button;
                                if (Update)
                                    btn2.Visible = true;
                                else
                                    btn2.Visible = false;
                                break;
                            case "Delete":
                                Delete = Convert.ToBoolean(reader[1].ToString());
                                Button btn3 = fila.FindControl("btndelete") as Button;
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

        protected void Btncreate_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("RegistrarUsuario.aspx");
            Response.Redirect("crudUsuarios.aspx?op=C");
        }
        protected void Btnread_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("crudUsuarios.aspx?id="+id+"&op=R");
        }

        protected void Btnupdate_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("crudUsuarios.aspx?id="+id+ "&op=U");
        }

        protected void Btndelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("crudUsuarios.aspx?id=" + id + "&op=D");
        }

        protected void Btnhabilitar_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("crudUsuarios.aspx?id=" + id + "&op=H");
        }

        protected void Btnmenu_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/menu.aspx");
        }

        protected void BtnUserInhabilitados_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BtnRecargar.Visible = true;
                BtnUserInhabilitados.Visible = false;
                SqlCommand cmd = new SqlCommand("sp_usuarios_Deshabilitados", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                gvusuarios.DataSource = dt;
                gvusuarios.DataBind();

                SqlCommand cmd1 = new SqlCommand("sp_usuarios_Deshabilitados", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    foreach (GridViewRow fila in gvusuarios.Rows)
                    {
                        Button btn1 = fila.FindControl("btnread") as Button;
                        btn1.Visible =  false;
                        Button btn2 = fila.FindControl("btnupdate") as Button;
                        btn2.Visible = false;
                        Button btn3 = fila.FindControl("btndelete") as Button;
                        btn3.Visible = false;
                        Button btn4 = fila.FindControl("btnhabilitar") as Button;
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
            Response.Redirect("~/Pages/Usuarios/Usuarios.aspx");
        }
        //protected void MsjAlert(string user, string mensaje, int tipo)
        //{
        //    string msj;
        //    switch (tipo) {
        //        case 1:
        //            msj = "swal('" + mensaje + "', '" + user + "!', 'success')";
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
        //            msj, true);
        //            break;
        //        case 0:
        //            msj = "swal('" + mensaje + "', '" + user + "', 'error')";
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
        //            msj, true);
        //            break;
        //        default:
        //            break;
        //    }
    }
}