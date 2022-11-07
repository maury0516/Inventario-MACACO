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
    public partial class menu : System.Web.UI.Page
    {
        int id_rol = 0;
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Cache-Control", "no-store");
            if (!IsPostBack && Session["usuario"] != null)
            {
                id_rol = Convert.ToInt32(Session["id_rol"].ToString());
                Permisos(id_rol);
                //MsjExito(sOpc);
            }
        }

        void Permisos(int id_rol)
        {
            try
            {
                switch (id_rol)
                {
                    case 1:
                        tableMenu.Visible = true;
                        break;
                    case 2:
                        tableMenuVendedor.Visible = true;
                        break;
                    case 1002:
                        tableMenuBodega.Visible = true;
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
         }

        protected void BtnProductos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Productos/Productos.aspx");
        }

        protected void BtnUser_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Usuarios/Usuarios.aspx");
        }

        protected void BtnProv_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Proveedores/Proveedores.aspx");
        }

        protected void BtnMarca_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Marcas/Marcas.aspx");
        }

        protected void BtnMedida_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Medidas/Medidas.aspx");
        }

        protected void BtnEntrada_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/AdministracionProductos/Entradas/Entradas.aspx");
        }

        protected void BtnSalida_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/AdministracionProductos/Salidas/Salidas.aspx");
        }

        protected void BtnSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/AdministracionProductos/Solicitudes/Solicitudes.aspx");
        }

        protected void BtnCat_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Categorias/Category.aspx");
        }

        protected void BtnSubCat_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/SubCategorias/SubCategory.aspx");
        }

        protected void BtnAreas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/AreasEmpresa/areas.aspx");
        }

        protected void BtnInventario_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/AdministracionProductos/Inventario.aspx");
        }
        //protected void MsjExito(string usuario)
        //{
        //    string msj = "swal('Bienvenido!', 'Sesión Iniciada " + usuario + "!', 'success')";
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
        //    msj, true);
        //}
    }
}