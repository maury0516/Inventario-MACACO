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

namespace MACACO.Pages.AreasEmpresa
{
    public partial class crudAreaEmpresa : System.Web.UI.Page
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
                            this.lblTitulo.Text = "Ingresar Nueva Area";
                            idarea.Visible = false;
                            lblID.Visible = false;
                            this.btnregistrar.Visible = true;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta Area de Empresa";
                            cargarDatos();
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar Area de la Empresa";
                            this.btnactualizar.Visible = true;
                            cargarDatos();
                            break;
                    }
                }
            }
        }

        void Limpiar()
        {
            idarea.Text = string.Empty;
            nombre.Text = string.Empty;
            descripcion.Text = string.Empty;
            encargado.Text = string.Empty;
        }

        void cargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("un_area", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id_area", SqlDbType.Int).Value = sID;

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            DataRow row = dt.Rows[0];
            idarea.Text = row[0].ToString();
            nombre.Text = row[1].ToString();
            descripcion.Text = row[2].ToString();
            encargado.Text = row[3].ToString();
            con.Close();
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            Clases.AreasEmpresa obj = new Clases.AreasEmpresa();
            obj.nombre = nombre.Text.ToString();
            obj.descripcion = descripcion.Text.ToString();
            obj.encargado = encargado.Text.ToString();
            try
            {
                if (nombre.Text.Length != 0 && descripcion.Text.Length != 0 && encargado.Text.Length != 0)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("validar_Area", con);
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
                        SqlCommand cmd = new SqlCommand("registrarArea", con);
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombre;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.descripcion;
                        cmd.Parameters.Add("@encargado", SqlDbType.VarChar).Value = obj.encargado;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Limpiar();
                        Response.Redirect("Areas.aspx");

                    }
                    else
                    {
                        string msj = "swal('ERROR', 'El nombre de usuario ya existe', 'error')";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                        msj, true);
                        nombre.Focus();
                    }
                }
                else
                {
                    if (nombre.Text.Length == 0)
                    {
                        Mensaje();
                        nombre.Focus();
                    }
                    if (descripcion.Text.Length == 0)
                    {
                        Mensaje();
                        descripcion.Focus();
                    }
                    if (encargado.Text.Length == 0)
                    {
                        Mensaje();
                        encargado.Focus();
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
            Clases.AreasEmpresa obj = new Clases.AreasEmpresa();
            obj.id_area = int.Parse(idarea.Text.ToString());
            obj.nombre = nombre.Text.ToString();
            obj.descripcion = descripcion.Text.ToString();
            obj.encargado = encargado.Text.ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("update_Area", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_area", SqlDbType.Int).Value = obj.id_area;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombre;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.descripcion;
                cmd.Parameters.Add("@encargado", SqlDbType.VarChar).Value = obj.encargado;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Areas.aspx");
            }
            catch (Exception)
            {
                throw;
            }

        }
        protected void Mensaje()
        {
            string msj = "swal('WARNING', 'Valide que los campos requeridos esten llenos', 'warning')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
            msj, true);
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Areas.aspx");
        }
    }
}