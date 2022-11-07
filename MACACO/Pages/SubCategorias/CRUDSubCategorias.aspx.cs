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
using System.Web.DynamicData;
using System.Data.Common;

namespace MACACO.Pages.SubCategorias
{
    public partial class CRUDSubCategorias : System.Web.UI.Page
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
                            this.lblTitulo.Text = "Ingresar Nueva SubCategoria";
                            idSubCat.Visible = false;
                            lblID.Visible = false;
                            this.btnregistrar.Visible = true;
                            cargarLista("");
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de SubCategoria";
                            cargarDatos();
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar SubCategoria";
                            this.btnactualizar.Visible = true;
                            cargarDatos();
                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar SubCategoria";
                            this.btndeshabilitar.Visible = true;
                            cargarDatos();
                            break;
                        case "H":
                            this.lblTitulo.Text = "Habilitar SubCategoria";
                            this.btnhabilitar.Visible = true;
                            cargarDatos();
                            break;
                    }
                }
            }
        }

        void Limpiar()
        {
            idSubCat.Text = string.Empty;
            nombreSubCat.Text = string.Empty;
            calibreSubCat.Text = string.Empty;
            estadoSubCat.Text = string.Empty;
        //    selcat.Text = string.Empty;
        }

        void cargarLista(string categoria)
        {
            con.Open();
            string consulta = "Select id_categoria, nombre from categoria";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            selcat.DataSource = ds;
            selcat.DataTextField = "nombre";
            selcat.DataValueField = "id_categoria";
            selcat.DataBind();
            if(categoria.Length > 0)
            {
                selcat.Items.Insert(0, new ListItem(categoria, "0"));
            }
            else { selcat.Items.Insert(0, new ListItem("<Seleccionar Categoria>", "0")); }
            
            con.Close();
        }

        int seleccionarCategorias(string nombre)
        {
            int id = 0;
            con.Open();
            //string consulta = "Select id_categoria from categoria where nombre = ";
            SqlCommand cmd = new SqlCommand("EscogerCategoria", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if(dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                id = int.Parse(row[0].ToString());
            }

            con.Close();
            return id;
        }

        void cargarDatos()
        {
            int estado;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("unaSubCategoria", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = sID;

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            DataRow row = dt.Rows[0];
            idSubCat.Text = row[0].ToString();
            string categoria = row[2].ToString();
            //selcat.Text = row[2].ToString();
            nombreSubCat.Text = row[3].ToString();
            calibreSubCat.Text = row[4].ToString();
            estado = int.Parse(row[5].ToString());
            if (estado == 1)
            {
                estadoSubCat.Text = "Habilitado";
            }
            else { estadoSubCat.Text = "Deshabilitado"; }
            con.Close();
            cargarLista(categoria);
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            int cat;
            Clases.SubCategorias obj = new Clases.SubCategorias();
            obj.nombre = nombreSubCat.Text.ToString();
            obj.calibre = calibreSubCat.Text.ToString();
            obj.catname = selcat.SelectedItem.ToString();
            cat = seleccionarCategorias(obj.catname);
            if(cat != 0) { obj.id_categoria = cat; } 
            else{ Mensaje(); }
            obj.estado = 1;
            try
            {
                if (nombreSubCat.Text.Length != 0 && calibreSubCat.Text.Length != 0 && selcat.Text.Length != 0)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("validarSubcat", con);
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
                        SqlCommand cmd = new SqlCommand("registrarSubCategoria", con);
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idcat", SqlDbType.VarChar).Value = obj.id_categoria;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombre;
                        cmd.Parameters.Add("@calibre", SqlDbType.VarChar).Value = obj.calibre;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = obj.estado;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Limpiar();
                        Response.Redirect("SubCategory.aspx");

                    }
                    else
                    {
                        string msj = "swal('ERROR', 'La SubCategoria ya existe', 'error')";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                        msj, true);
                        nombreSubCat.Focus();
                    }
                }
                else
                {
                    if (nombreSubCat.Text.Length == 0)
                    {
                        Mensaje();
                        nombreSubCat.Focus();
                    }
                    if (calibreSubCat.Text.Length == 0)
                    {
                        Mensaje();
                        calibreSubCat.Focus();
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
            Clases.SubCategorias obj = new Clases.SubCategorias();
            obj.id_subcategoria = int.Parse(sID);
            obj.catname = selcat.SelectedItem.ToString();
            obj.id_categoria = seleccionarCategorias(obj.catname);
            obj.nombre = nombreSubCat.Text.ToString();
            obj.calibre = calibreSubCat.Text.ToString();
            obj.estado = 1;
            try
            {
                SqlCommand cmd = new SqlCommand("updateSubCategoria", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.id_subcategoria;
                cmd.Parameters.Add("@idcat", SqlDbType.Int).Value = obj.id_categoria;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombre;
                cmd.Parameters.Add("@calibre", SqlDbType.VarChar).Value = obj.calibre;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = obj.estado;

                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("SubCategory.aspx");
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btndeshabilitar_Click(object sender, EventArgs e)
        {
            Clases.SubCategorias obj = new Clases.SubCategorias();
            obj.id_subcategoria = int.Parse(sID);
            try
            {
                SqlCommand cmd = new SqlCommand("inhabilitarSubCategoria", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.id_subcategoria;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("SubCategory.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnhabilitar_Click(object sender, EventArgs e)
        {
            Clases.SubCategorias obj = new Clases.SubCategorias();
            obj.id_subcategoria = int.Parse(sID);
            try
            {
                SqlCommand cmd = new SqlCommand("habilitarSubCategoria", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.id_subcategoria;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("SubCategory.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubCategory.aspx");
        }

        protected void Mensaje()
        {
            string msj = "swal('WARNING', 'Valide que los campos requeridos esten llenos', 'warning')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
            msj, true);
        }
    }
}