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

namespace MACACO.Pages.AdministracionProductos.Entradas
{
    public partial class TEntradas : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Cache-Control", "no-store");
            if (!IsPostBack && Session["usuario"] != null)
            {
                Datos();
            }
        }

        void Datos()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SelDetalleEntradaCompleto", con);
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
        protected void BtnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/AdministracionProductos/Entradas/Entradas.aspx");
        }

        protected void BtnMenu_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/menu.aspx");
        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SelDetalleEntradaFiltrado", con);
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