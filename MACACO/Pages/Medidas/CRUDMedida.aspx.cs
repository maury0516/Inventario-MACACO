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

namespace MACACO.Pages.Medidas
{
    public partial class CRUDMedida : System.Web.UI.Page
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
                            this.lblTitulo.Text = "Ingresar Nueva Medida";
                            idMedida.Visible = false;
                            lblID.Visible = false;
                            this.btnregistrar.Visible = true;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de Medida";
                            cargarDatos();
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar Medida";
                            this.btnactualizar.Visible = true;
                            cargarDatos();
                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar Medida";
                            this.btndeshabilitar.Visible = true;
                            cargarDatos();
                            break;
                        case "H":
                            this.lblTitulo.Text = "Habilitar Medida";
                            this.btnhabilitar.Visible = true;
                            cargarDatos();
                            break;
                    }
                }
            }
        }

        void Limpiar()
        {
            idMedida.Text = string.Empty;
            nombreMedida.Text = string.Empty;
            estadoMedida.Text = string.Empty;
        }

        void cargarDatos()
        {
            int estado;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("unaMedida", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = sID;

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            DataRow row = dt.Rows[0];
            idMedida.Text = row[0].ToString();
            nombreMedida.Text = row[1].ToString();
            estado = int.Parse(row[2].ToString());
            if (estado == 1)
            {
                estadoMedida.Text = "Habilitado";
            }
            else { estadoMedida.Text = "Deshabilitado"; }

            con.Close();
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            Medida obj = new Medida();
            obj.medida = nombreMedida.Text.ToString();
            obj.estado = 1;
            try
            {
                if (nombreMedida.Text.Length != 0 )
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("validarMedida", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@medida", SqlDbType.VarChar).Value = obj.medida;
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
                        SqlCommand cmd = new SqlCommand("registrarMedida", con);
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@medida", SqlDbType.VarChar).Value = obj.medida;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = obj.estado;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Limpiar();
                        Response.Redirect("Medidas.aspx");

                    }
                    else
                    {
                        string msj = "swal('ERROR', 'La Medida ya existe dentro de los registros', 'error')";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                        msj, true);
                        nombreMedida.Focus();
                    }
                }
                else
                {
                    if (nombreMedida.Text.Length == 0)
                    {
                        Mensaje();
                        nombreMedida.Focus();
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
            Medida obj = new Medida();
            obj.id_medida = int.Parse(sID);
            obj.medida = nombreMedida.Text.ToString();
            obj.estado = 1;
            try
            {
                SqlCommand cmd = new SqlCommand("updateMedida", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.id_medida;
                cmd.Parameters.Add("@medida", SqlDbType.VarChar).Value = obj.medida;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = obj.estado;

                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Medidas.aspx");
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btndeshabilitar_Click(object sender, EventArgs e)
        {
            Medida obj = new Medida();
            obj.id_medida = int.Parse(sID);
            try
            {
                SqlCommand cmd = new SqlCommand("inhabilitarMedida", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.id_medida;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Medidas.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnhabilitar_Click(object sender, EventArgs e)
        {
            Medida obj = new Medida();
            obj.id_medida = int.Parse(sID);
            try
            {
                SqlCommand cmd = new SqlCommand("habilitarMedida", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.id_medida;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Medidas.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Medidas.aspx");
        }

        protected void Mensaje()
        {
            string msj = "swal('WARNING', 'Valide que los campos requeridos esten llenos', 'warning')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
            msj, true);
        }
    }
}