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

namespace MACACO.Pages.Proveedores
{
    public partial class CRUDProveedor : System.Web.UI.Page
    {
        int rol = -1;
        int est = -1;
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
                            this.lblTitulo.Text = "Ingresar Nuevo Proveedor";
                            idprov.Visible = false;
                            lblID.Visible = false;
                            this.btnregistrar.Visible = true;
                            estado.Visible = false;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de Proveedor";
                            cargarDatos();
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar Proveedor";
                            this.btnactualizar.Visible = true;
                            cargarDatos();
                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar Proveedor";
                            this.btndeshabilitar.Visible = true;
                            cargarDatos();
                            break;
                        case "H":
                            this.lblTitulo.Text = "Habilitar Proveedor";
                            this.btnhabilitar.Visible = true;
                            cargarDatos();
                            break;
                    }
                }
            }
        }

        void Limpiar()
        {
            idprov.Text = string.Empty;
            nomprov.Text = string.Empty;
            dirprov.Text = string.Empty;
            correo.Text = string.Empty;
            telprov.Text = string.Empty;
            estado.Text = string.Empty;
        }
        void cargarDatos(){
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("un_proveedor", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id_prov", SqlDbType.Int).Value = sID;

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            DataRow row = dt.Rows[0];
            idprov.Text = row[0].ToString();
            nomprov.Text = row[1].ToString();
            dirprov.Text = row[2].ToString();
            telprov.Text = row[3].ToString();
            correo.Text = row[4].ToString();
            estado.Text = row[5].ToString();

            con.Close();
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            Proveedor prov = new Proveedor();
            prov.nombre = nomprov.Text.ToString();
            prov.direccion = dirprov.Text.ToString();
            prov.telefono = telprov.Text.ToString();
            prov.correo = correo.Text.ToString();
            prov.estado = 1;

            try
            {
                if (nomprov.Text.Length != 0 && dirprov.Text.Length != 0 && telprov.Text.Length != 0 && correo.Text.Length != 0)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("validar_proveedor", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = prov.nombre;
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
                        SqlCommand cmd = new SqlCommand("registrar_proveedor", con);
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = prov.nombre;
                        cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = prov.direccion;
                        cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = prov.telefono;
                        cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = prov.correo;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = prov.estado;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Limpiar();
                        Response.Redirect("Proveedores.aspx");

                    }
                    else
                    {
                        string msj = "swal('ERROR', 'El nombre de Proveedor ya existe', 'error')";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                        msj, true);
                        nomprov.Focus();
                    }
                }
                else
                {
                    if (nomprov.Text.Length == 0)
                    {
                        Mensaje();
                        nomprov.Focus();
                    }
                    if (dirprov.Text.Length == 0)
                    {
                        Mensaje();
                        dirprov.Focus();
                    }
                    if (telprov.Text.Length == 0)
                    {
                        Mensaje();
                        telprov.Focus();
                    }
                    if (correo.Text.Length == 0)
                    {
                        Mensaje();
                        correo.Focus();
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
            Proveedor prov = new Proveedor();
            prov.id_proveedor = int.Parse(sID);
            prov.nombre = nomprov.Text.ToString();
            prov.direccion = dirprov.Text.ToString();
            prov.telefono = telprov.Text.ToString();
            prov.correo = correo.Text.ToString();
            prov.estado = 1;


            try
            {
                SqlCommand cmd = new SqlCommand("update_proveedor", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_proveedor", SqlDbType.Int).Value = prov.id_proveedor;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = prov.nombre;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = prov.direccion;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = prov.telefono;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = prov.correo;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = prov.estado;

                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Proveedores.aspx");
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btndeshabilitar_Click(object sender, EventArgs e)
        {
            Proveedor prov = new Proveedor();
            prov.id_proveedor = int.Parse(sID);
            try
            {
                SqlCommand cmd = new SqlCommand("inhabilitar_proveedor", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_proveedor", SqlDbType.Int).Value = prov.id_proveedor;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Proveedores.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnhabilitar_Click(object sender, EventArgs e)
        {
            Proveedor prov = new Proveedor();
            prov.id_proveedor = int.Parse(sID);
            try
            {
                SqlCommand cmd = new SqlCommand("habilitar_proveedor", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_proveedor", SqlDbType.Int).Value = prov.id_proveedor;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Proveedores.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }

        protected void Mensaje()
        {
            string msj = "swal('WARNING', 'Valide que los campos requeridos esten llenos', 'warning')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
            msj, true);
        }
    }
}