using MACACO.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MACACO.Pages.Categorias
{
    public partial class CRUDCategory : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && Session["usuario"] != null)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                }
                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();
                    switch (sOpc)
                    {
                        case "C":
                            this.lblTitulo.Text = "Ingresar Nueva Categoria";
                            idCat.Visible = false;
                            lblID.Visible = false;
                            this.btnregistrar.Visible = true;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de Categoria";
                            cargarDatos();
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar Categoria";
                            this.btnactualizar.Visible = true;
                            cargarDatos();
                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar Categoria";
                            this.btndeshabilitar.Visible = true;
                            cargarDatos();
                            break;
                        case "H":
                            this.lblTitulo.Text = "Habilitar Categoria";
                            this.btnhabilitar.Visible = true;
                            cargarDatos();
                            break;
                    }
                }
            }
        }

        void Limpiar()
        {
            idCat.Text = string.Empty;
            nombreCat.Text = string.Empty;
            descripcionCat.Text = string.Empty;
            estadoCat.Text = string.Empty;  
        }

        void cargarDatos()
        {
            int estado;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("unaCategoria", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@idCat", SqlDbType.Int).Value = sID;

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            DataRow row = dt.Rows[0];
            idCat.Text = row[0].ToString();
            nombreCat.Text = row[1].ToString();
            descripcionCat.Text = row[2].ToString();
            estado = int.Parse(row[3].ToString());
            if(estado == 1)
            {
                estadoCat.Text = "Habilitado";
            }
            else { estadoCat.Text = "Deshabilitado"; }
            
            con.Close();
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            Catecoria obj = new Catecoria();
            obj.nombre = nombreCat.Text.ToString();
            obj.descripcion = descripcionCat.Text.ToString();
            obj.estado = 1;
            try
            {
                if (nombreCat.Text.Length != 0 && descripcionCat.Text.Length != 0)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("validarCategoria", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombre;
                    DataSet ds = new DataSet();
                    ds.Clear();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    int x = dt.Rows.Count;
                    if (x > 0)
                    {
                        DataRow row = dt.Rows[0];
                        string resp = row[0].ToString();
                    }
                    con.Close();
                    if (x == 0)
                    {
                        SqlCommand cmd = new SqlCommand("registrarCategoria", con);
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombre;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.descripcion;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = obj.estado;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Limpiar();
                        Response.Redirect("Category.aspx");

                    }
                    else
                    {
                        string msj = "swal('ERROR', 'La Categoria ya existe', 'error')";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                        msj, true);
                        nombreCat.Focus();
                    }
                }
                else
                {
                    if (nombreCat.Text.Length == 0)
                    {
                        Mensaje();
                        nombreCat.Focus();
                    }
                    if (descripcionCat.Text.Length == 0)
                    {
                        Mensaje();
                        descripcionCat.Focus();
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            Catecoria obj = new Catecoria();
            obj.id_categoria = int.Parse(sID);
            obj.nombre = nombreCat.Text.ToString();
            obj.descripcion = descripcionCat.Text.ToString();
            obj.estado = 1;
            try
            {
                SqlCommand cmd = new SqlCommand("updateCategoria", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idCat", SqlDbType.Int).Value = obj.id_categoria;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombre;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.descripcion;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = obj.estado;

                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Category.aspx");
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btndeshabilitar_Click(object sender, EventArgs e)
        {
            Catecoria obj = new Catecoria();
            obj.id_categoria = int.Parse(sID);
            try
            {
                SqlCommand cmd = new SqlCommand("inhabilitarCategoria", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idCat", SqlDbType.Int).Value = obj.id_categoria;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Category.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnhabilitar_Click(object sender, EventArgs e)
        {
            Catecoria obj = new Catecoria();
            obj.id_categoria = int.Parse(sID);
            try
            {
                SqlCommand cmd = new SqlCommand("habilitarCategoria", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idCat", SqlDbType.Int).Value = obj.id_categoria;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Category.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Category.aspx");
        }

        protected void Mensaje()
        {
            string msj = "swal('WARNING', 'Valide que los campos requeridos esten llenos', 'warning')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
            msj, true);
        }
    }
}