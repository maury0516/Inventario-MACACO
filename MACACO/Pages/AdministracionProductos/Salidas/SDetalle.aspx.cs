using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MACACO.Clases;
using System.Text;

namespace MACACO.Pages.AdministracionProductos.Salidas
{
    public partial class SDetalle : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        List<ArregloSalida.gridV> gvArray = new List<ArregloSalida.gridV>();
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
                            txtUsuario.Text = Session["usuario"].ToString().ToLower();
                            txtIDSalida.Text = "NEW";
                            cargarAreas("");
                            cargarMateriales("");
                            break;
                        case "R":
                            IDS.Visible = true;
                            break;
                    }
                }
            }
        }

        void cargarAreas(string area)
        {
            con.Open();
            string consulta = "Select id_area, nombre from areaempresa";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            selArea.DataSource = ds;
            selArea.DataTextField = "nombre";
            selArea.DataValueField = "id_area";
            selArea.DataBind();
            if (area.Length > 0)
            {
                selArea.Items.Insert(0, new ListItem(area, "0"));
            }
            else { selArea.Items.Insert(0, new ListItem("<Seleccionar Area>", "0")); }

            con.Close();
        }

        int seleccionarArea(string area)
        {
            int id = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("EscogerArea", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = area;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                id = int.Parse(row[0].ToString());
            }
            con.Close();
            return id;
        }

        void cargarMateriales(string articulo)
        {
            con.Open();
            string consulta = "select id_articulo, codigoarticulo from articulo";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            selArticulo.DataSource = ds;
            selArticulo.DataTextField = "codigoarticulo";
            selArticulo.DataValueField = "id_articulo";
            selArticulo.DataBind();
            if (articulo.Length > 0)
            {
                selArticulo.Items.Insert(0, new ListItem(articulo, "0"));
            }
            else { selArticulo.Items.Insert(0, new ListItem("<Seleccionar Material>", "0")); }

            con.Close();
        }

        int seleccionarMaterial(string material)
        {
            int id = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("EscogerMaterial", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = material;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                id = int.Parse(row[0].ToString());
            }
            con.Close();
            return id;
        }

        int seleccionarUsuario(string usua)
        {
            int id = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("EscogerUsuario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = usua;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                id = int.Parse(row[0].ToString());
            }
            con.Close();
            return id;
        }
        protected void BtnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/AdministracionProductos/Salidas/Salidas.aspx");
        }

        protected void BtnMenu_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/menu.aspx");
        }

        protected void InsertDetalle()
        {
            int k;
            ViewState["Estado"] = gvArray;
            gvproductos.DataSource = gvArray;
            gvproductos.DataBind();
            for (k = 0; k < gvArray.Count; k++)
            {
                gvproductos.SelectedIndex = k;
                gvproductos.SelectedRow.Cells[0].Text = gvArray[k].id.ToString();
                gvproductos.SelectedRow.Cells[1].Text = gvArray[k].codigo.ToString();
                gvproductos.SelectedRow.Cells[2].Text = gvArray[k].cantidad.ToString();
                gvproductos.SelectedRow.Cells[3].Text = gvArray[k].area;
                gvproductos.SelectedRow.Cells[4].Text = gvArray[k].op.ToString();
            }
        }
        protected bool Existe(string dato)
        {
            int f;
            bool esta = false;
            for (f = 0; f < gvproductos.Rows.Count && !esta; f++)
            {
                if (gvproductos.Rows[f].Cells[1].Text == dato)
                {
                    esta = true;
                }
            }
            return esta;
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (selArticulo.SelectedItem.ToString() != "<Seleccionar Material>")
            {
                if (txtCantidad.Text.Length > 0)
                {
                    if (selArea.SelectedItem.ToString() != "<Seleccionar Area>")
                    {
                        if (txtOP.Text.Length > 0)
                        {
                            if (!Existe(selArticulo.SelectedItem.ToString()))
                            {
                                if (ViewState["Estado"] != null)
                                {
                                    gvArray = ViewState["Estado"] as List<ArregloSalida.gridV>;
                                }
                                gvArray.Add(new ArregloSalida.gridV
                                {
                                    codigo = selArticulo.SelectedItem.ToString(),
                                    area = selArea.SelectedItem.ToString(),
                                    cantidad = int.Parse(txtCantidad.Text),
                                    op = int.Parse(txtOP.Text)
                                });
                                InsertDetalle();
                            }
                            else
                            {
                                string msj = "swal('WARNING', 'El Material ya esta agregado', 'warning')";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                                msj, true);
                            }
                        }
                        else
                        {
                            string msj = "swal('WARNING', 'Debe agregar el precio unitario de compra', 'warning')";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                            msj, true);
                        }
                    }
                    else
                    {
                        string msj = "swal('WARNING', 'Debe Seleccionar el Area de la Empresa', 'warning')";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                        msj, true);
                    }
                }
                else
                {
                    string msj = "swal('WARNING', 'Debe Agregar la Cantidad', 'warning')";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                    msj, true);
                }
            }
            else
            {
                string msj = "swal('WARNING', 'Debe Seleccionar el Material', 'warning')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                msj, true);
            }           
        }

        protected void gvproductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int f = Convert.ToInt32(e.CommandArgument);
            gvArray.Clear();
            gvArray = ViewState["Estado"] as List<ArregloSalida.gridV>;
            gvArray.RemoveAt(f);
            InsertDetalle();
        }

        int SeleccionarUltimaSalida()
        {
            int ultimo = 0;
            con.Open();
            string consulta = "SELECT id_salida FROM salida WHERE id_salida=(SELECT max(id_salida) FROM salida);";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                ultimo = registro.GetInt32(0);
            }
            con.Close();
            return ultimo;
        }
        void GuardarEntrada()
        {
            int idUser = seleccionarUsuario(txtUsuario.Text);

            SqlCommand cmd = new SqlCommand("registrarSalida", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = idUser;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = txtFecha.Text;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = txtDescripcion.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        void GuardarDetalle()
        {
            int k;
            int idSalida = SeleccionarUltimaSalida();
            gvArray.Clear();
            gvArray = ViewState["Estado"] as List<ArregloSalida.gridV>;
            
            for (k = 0; k < gvArray.Count; k++)
            {
                int idarea = seleccionarArea(gvArray[k].area.ToString());
                SqlCommand cmd = new SqlCommand("registrarDetalleSalida", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_salida", SqlDbType.Int).Value = idSalida;
                cmd.Parameters.Add("@codigoarticulo", SqlDbType.VarChar).Value = gvArray[k].codigo.ToString();
                cmd.Parameters.Add("@id_area", SqlDbType.Int).Value = idarea;
                cmd.Parameters.Add("@numero_op", SqlDbType.Int).Value = int.Parse(gvArray[k].op.ToString());
                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = int.Parse(gvArray[k].cantidad.ToString());
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = txtFecha.Text;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarEntrada();
                GuardarDetalle();
                gvArray = ViewState["Estado"] as List<ArregloSalida.gridV>;
                StringBuilder sb = new StringBuilder();
                int k;
                for (k = 0; k < gvArray.Count; k++)
                {
                    sb.Append("Codigo de Material: " + gvArray[k].codigo +
                                    ", Cantidad: " + gvArray[k].cantidad +
                                    ", Area que lo solicito: " + gvArray[k].area +
                                   ", Orden de Produccion: " + gvArray[k].op + "</br>");
                }
                string mensaje = sb.ToString();
                EnvioCorreo(mensaje);

                string msj = "swal('SUCCESS', 'Se envio un correo especificando la descarga de material', 'success')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                msj, true);
            }
            catch (Exception ex)
            {
                string msj = "swal('WARNING', '" + ex.Message.ToString() + "', 'error')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                msj, true);
            }
        }

        void EnvioCorreo(string mensaje)
        {
            Clases.EnvioCorreo objCorreo = new Clases.EnvioCorreo();
            MensajitosSMS objsms = new MensajitosSMS();
            string display = "Salida de Material de Bodega";
            string body = @"<style>
                            h1{color:dodgerblue;}
                            </style>
                            <h1>Descarga de Materiales</h1></br>
                            <strong>" + mensaje + "</strong>";
            objCorreo.sendMail("comprasmacaco@outlook.com", "Registro de Salida de Material", body, display);
            Console.WriteLine(mensaje);
            objsms.EnviarMensaje(body);
        }
    }
}