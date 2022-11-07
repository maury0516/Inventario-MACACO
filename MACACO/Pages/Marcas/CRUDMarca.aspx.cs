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

namespace MACACO.Pages.Marcas
{
    public partial class CRUDMarca : System.Web.UI.Page
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
                            this.lblTitulo.Text = "Ingresar Nueva Marca";
                            idMarca.Visible = false;
                            lblID.Visible = false;
                            this.btnregistrar.Visible = true;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de Marcas";
                            cargarDatos();
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar Marca";
                            this.btnactualizar.Visible = true;
                            cargarDatos();
                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar Marca";
                            this.btndeshabilitar.Visible = true;
                            cargarDatos();
                            break;
                        case "H":
                            this.lblTitulo.Text = "Recuperar Marca";
                            this.btnhabilitar.Visible = true;
                            cargarDatos();
                            break;
                    }
                }
            }
        }

        void Limpiar()
        {
            idMarca.Text = string.Empty;
            nombreMarca.Text = string.Empty;
            estadoMarca.Text = string.Empty;
        }

        void cargarDatos()
        {
            int estado;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("unaMarca", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = sID;

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            DataRow row = dt.Rows[0];
            idMarca.Text = row[0].ToString();
            nombreMarca.Text = row[1].ToString();
            estado = int.Parse(row[2].ToString());
            if (estado == 1)
            {
                estadoMarca.Text = "Habilitado";
            }
            else { estadoMarca.Text = "Deshabilitado"; }

            con.Close();
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            Marka obj = new Marka();
            obj.marca = nombreMarca.Text;
            obj.estado = 1;
            try
            {
                if (nombreMarca.Text.Length != 0)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("validarMarca", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.marca;
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
                        SqlCommand cmd = new SqlCommand("registrarMarca", con);
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.marca;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = obj.estado;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Limpiar();
                        Response.Redirect("Marcas.aspx");

                    }
                    else
                    {
                        string msj = "swal('ERROR', 'La Marca ya existe', 'error')";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                        msj, true);
                       nombreMarca.Focus();
                    }
                }
                else
                {
                    if (nombreMarca.Text.Length == 0)
                    {
                        Mensaje();
                        nombreMarca.Focus();
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
            Marka obj = new Marka();
            obj.id_marca = int.Parse(sID);
            obj.marca = nombreMarca.Text.ToString();
            obj.estado = 1;
            try
            {
                SqlCommand cmd = new SqlCommand("updateMarca", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.id_marca;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.marca;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = obj.estado;

                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Marcas.aspx");
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
                SqlCommand cmd = new SqlCommand("inhabilitarMarca", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.id_categoria;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Marcas.aspx");
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
                SqlCommand cmd = new SqlCommand("habilitarMarca", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.id_categoria;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Marcas.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marcas.aspx");
        }

        protected void Mensaje()
        {
            string msj = "swal('WARNING', 'Valide que los campos requeridos esten llenos', 'warning')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
            msj, true);
        }
    }
}