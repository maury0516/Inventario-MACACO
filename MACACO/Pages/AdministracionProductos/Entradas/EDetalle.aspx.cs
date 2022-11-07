using MACACO.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio.TwiML.Voice;

namespace MACACO.Pages.AdministracionProductos.Entradas
{
    public partial class EDetalle : System.Web.UI.Page
    {
        List<ArregloEntrada.gridV> gvArray = new List<ArregloEntrada.gridV>();
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
                            txtUsuario.Text = Session["usuario"].ToString().ToLower();
                            txtIDEntrada.Text = "NEW";
                            //txtIDEntrada.Text = (SeleccionarUltimaEntrada() +1).ToString();
                            cargarAreas("");
                            cargarMateriales("");
                            cargarProveedores("");
                            CargarComprobantes();
                            gvProdCarga.Visible = false;
                            break;
                        case "R":
                            CargarDatos();
                            gvproductos.Visible = false;
                            tablaIngreso.Visible = false;
                            txtFecha.Visible = false;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            string idProv;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("UnaEntrada", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id_entrada", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            txtIDEntrada.Text = row[0].ToString();
            idProv = row[1].ToString();
            txtUsuario.Text = row[2].ToString();
            selComprobante.Items.Insert(0, new ListItem(row[3].ToString(), "0"));
            txtNumComprobante.Text = row[4].ToString();
            DateTime lafecha = Convert.ToDateTime(row[5].ToString());
            lblFecha.Text = lafecha.ToShortDateString();
            con.Close();
            cargarProveedores(idProv);
            DatosTabla();
        }
        void DatosTabla()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SelDetalleEntrada", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_entrada", SqlDbType.Int).Value = sID;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProdCarga.DataSource = dt;
                gvProdCarga.DataBind();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        void CargarComprobantes()
        {
            selComprobante.Items.Insert(0, new ListItem("NOTA DE ENVIO", "0"));
            selComprobante.Items.Insert(0, new ListItem("RECIBO", "1"));
            selComprobante.Items.Insert(0, new ListItem("CREDITO FISCAL", "2"));
            selComprobante.Items.Insert(0, new ListItem("CONSUMIDOR FINAL", "3"));
            selComprobante.Items.Insert(0, new ListItem("Seleccionar...", "4"));
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

        void cargarProveedores(string prov)
        {
            con.Open();
            string consulta = "select id_proveedor, nombre from proveedores";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            selProv.DataSource = ds;
            selProv.DataTextField = "nombre";
            selProv.DataValueField = "id_proveedor";
            selProv.DataBind();
            if (prov.Length > 0)
            {
                selProv.Items.Insert(0, new ListItem(prov, "0"));
            }
            else { selProv.Items.Insert(0, new ListItem("<Seleccionar Proveedor>", "0")); }

            con.Close();
        }

        int seleccionarProveedor(string prov)
        {
            int id = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("EscogerProveedor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = prov;
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

        int SeleccionarUltimaEntrada()
        {
            int ultimo = 0;
            con.Open();
            string consulta = "SELECT id_entrada FROM entrada WHERE id_entrada=(SELECT max(id_entrada) FROM entrada);";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                ultimo = registro.GetInt32(0);
            }
            con.Close();
            return ultimo;
        }

        protected void InsertDetalle()
        {
            int k;
            ViewState["Estado"] = gvArray;
            gvproductos.DataSource = gvArray;
            gvproductos.DataBind();
            for(k=0; k < gvArray.Count; k++)
            {
                gvproductos.SelectedIndex = k;
                gvproductos.SelectedRow.Cells[0].Text = gvArray[k].id.ToString();
                gvproductos.SelectedRow.Cells[1].Text = gvArray[k].codigo.ToString();
                gvproductos.SelectedRow.Cells[2].Text = gvArray[k].cantidad.ToString();
                gvproductos.SelectedRow.Cells[3].Text = gvArray[k].area;
                gvproductos.SelectedRow.Cells[4].Text = gvArray[k].precio.ToString();
            }
        }
        protected bool Existe(string dato)
        {
            int f;
            bool esta = false;
            for(f=0; f < gvproductos.Rows.Count && !esta; f++)
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
            if(selArticulo.SelectedItem.ToString() != "<Seleccionar Material>")
            {
                if(txtCantidad.Text.Length > 0)
                {
                    if(selArea.SelectedItem.ToString() != "<Seleccionar Area>")
                    {
                        if(txtPrecio.Text.Length > 0)
                        {
                            if (!Existe(selArticulo.SelectedItem.ToString()))
                            {
                                if (ViewState["Estado"] != null)
                                {
                                    gvArray = ViewState["Estado"] as List<ArregloEntrada.gridV>;
                                }
                                gvArray.Add(new ArregloEntrada.gridV
                                {
                                    codigo = selArticulo.SelectedItem.ToString(),
                                    area = selArea.SelectedItem.ToString(),
                                    cantidad = int.Parse(txtCantidad.Text),
                                    precio = double.Parse(txtPrecio.Text)
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

        protected void BtnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/AdministracionProductos/Entradas/Entradas.aspx");
        }

        protected void BtnMenu_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/menu.aspx");
        }

        protected void gvproductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int f = Convert.ToInt32(e.CommandArgument);
            gvArray.Clear();
            gvArray = ViewState["Estado"] as List<ArregloEntrada.gridV>;
            gvArray.RemoveAt(f);
            InsertDetalle();
        }

        void GuardarEntrada()
        {
            if (selProv.SelectedItem.ToString() != "<Seleccionar Proveedor>") {
                if(selComprobante.SelectedItem.ToString() != "Seleccionar...")
                {
                    if(txtNumComprobante.Text.Length > 0)
                    {
                        if(txtFecha.Text.Length > 0)
                        {
                            int idProv = seleccionarProveedor(selProv.SelectedItem.ToString());
                            int idUser = seleccionarUsuario(txtUsuario.Text);

                            SqlCommand cmd = new SqlCommand("registrarEntrada", con);
                            con.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@id_proveedor", SqlDbType.Int).Value = idProv;
                            cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = idUser;
                            cmd.Parameters.Add("@tipo_comprobante", SqlDbType.VarChar).Value = selComprobante.SelectedItem.ToString();
                            cmd.Parameters.Add("@numerocomprobante", SqlDbType.Int).Value = txtNumComprobante.Text;
                            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = txtFecha.Text;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            string msj = "swal('WARNING', 'Debe Seleccionar la fecha de registro', 'warning')";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                            msj, true);
                        }
                    }
                    else
                    {
                        string msj = "swal('WARNING', 'Debe agregar el numero de comprobante', 'warning')";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                        msj, true);
                    }
                }
                else
                {
                    string msj = "swal('WARNING', 'Debe Seleccionar el tipo de comprobante', 'warning')";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                    msj, true);
                }
            }
            else
            {
                string msj = "swal('WARNING', 'Debe Seleccionar el Proveedor', 'warning')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                msj, true);
            }
            
        }

        void GuardarDetalle()
        {
            int k;
            int idEntrada = SeleccionarUltimaEntrada();
            gvArray.Clear();
            gvArray = ViewState["Estado"] as List<ArregloEntrada.gridV>;
            List<string> insertados = new List<string>();
            
            for (k = 0; k < gvArray.Count; k++)
            {
                int idarea = seleccionarArea(gvArray[k].area.ToString());
                SqlCommand cmd = new SqlCommand("registrarDetalle", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_entrada", SqlDbType.Int).Value = idEntrada;
                cmd.Parameters.Add("@codigoarticulo", SqlDbType.VarChar).Value = gvArray[k].codigo.ToString();
                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = int.Parse(gvArray[k].cantidad.ToString());
                cmd.Parameters.Add("@id_area", SqlDbType.Int).Value = idarea;
                cmd.Parameters.Add("@precio_unitario", SqlDbType.Float).Value = gvArray[k].precio;
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
                gvArray = ViewState["Estado"] as List<ArregloEntrada.gridV>;
                StringBuilder sb = new StringBuilder();
                int k;
                for (k = 0; k < gvArray.Count; k++)
                {
                    sb.Append("Codigo de Material: " + gvArray[k].codigo +
                                    ", Cantidad: " + gvArray[k].cantidad +
                                    ", Area destino: " + gvArray[k].area +
                                   ", Precio unitario de compra segun factura: $" + gvArray[k].precio + "</br>");
                }
                string mensaje = sb.ToString();
                EnvioCorreo(mensaje);

                string msj = "swal('SUCCESS', 'Se envio un correo especificando la entrada de material', 'success')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                msj, true);
            }
            catch (Exception ex) {
                string msj = "swal('WARNING', '"+ ex.Message.ToString() + "', 'error')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                msj, true);
            }
        }

        void EnvioCorreo(string mensaje)
        {
            Clases.EnvioCorreo objCorreo = new Clases.EnvioCorreo();
            MensajitosSMS objsms = new MensajitosSMS();
            string display = "Ingreso de Material";
            string body = @"<style>
                            h1{color:dodgerblue;}
                            </style>
                            <h1>Ingreso de Materiales</h1></br>
                            <strong>" + mensaje +"</strong>";
            objCorreo.sendMail("comprasmacaco@outlook.com", "Nuevo Ingreso Material", body, display);
            Console.WriteLine(mensaje);
            objsms.EnviarMensaje(body);
        }
    }
}