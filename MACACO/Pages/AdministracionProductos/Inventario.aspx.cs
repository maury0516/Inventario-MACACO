using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MACACO.Pages.AreasEmpresa;

namespace MACACO.Pages.AdministracionProductos
{
    public partial class Inventario : System.Web.UI.Page
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
                switch (id_rol)
                {
                    case 1:
                        BtnEntradas.Visible = true;
                        BtnSalidas.Visible = true;
                        BtnSolicitudes.Visible = true;
                        break;
                    case 2:
                        BtnEntradas.Visible = false;
                        BtnSalidas.Visible = false;
                        BtnSolicitudes.Visible = false;
                        break;
                    case 1002:
                        BtnEntradas.Visible = true;
                        BtnSalidas.Visible = true;
                        BtnSolicitudes.Visible = true;
                        break;
                }
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
                SqlCommand cmd = new SqlCommand("sp_Inventario", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvproductos.DataSource = dt;
                gvproductos.DataBind();
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

        protected void BtnEntradas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/AdministracionProductos/Entradas/Entradas.aspx");
        }

        protected void BtnSalidas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/AdministracionProductos/Salidas/Salidas.aspx");
        }

        protected void BtnSolicitudes_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/AdministracionProductos/Solicitudes/Solicitudes.aspx");
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_InventarioFiltrado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@busca", SqlDbType.VarChar).Value = txtBuscar.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvproductos.DataSource = dt;
                gvproductos.DataBind();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}