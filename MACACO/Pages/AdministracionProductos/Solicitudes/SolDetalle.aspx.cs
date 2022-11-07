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

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Text;

namespace MACACO.Pages.AdministracionProductos.Solicitudes
{
    public partial class SolDetalle : System.Web.UI.Page
    {
        List<ArregloSolicitud.gridV> gvArray = new List<ArregloSolicitud.gridV>();
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
                            txtIDSolicitud.Text = "NEW";
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

        int SeleccionarUltimaSolicitud()
        {
            int ultimo = 0;
            con.Open();
            string consulta = "SELECT id_solicitud FROM solicitudencabezado WHERE id_solicitud=(SELECT max(id_solicitud) FROM solicitudencabezado);";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                ultimo = registro.GetInt32(0);
            }
            con.Close();
            return ultimo;
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
            Response.Redirect("~/Pages/AdministracionProductos/Solicitudes/Solicitudes.aspx");
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
                gvproductos.SelectedRow.Cells[3].Text = gvArray[k].op.ToString();
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
            int ordenP;
            if (selArticulo.SelectedItem.ToString() != "<Seleccionar Material>") {
                if(txtCantidad.Text.Length > 0)
                {
                    if(txtOP.Text.Length > 0)
                    {ordenP = int.Parse(txtOP.Text);}
                    else{ordenP = 0;}
                    if (!Existe(selArticulo.SelectedItem.ToString()))
                    {
                        if (ViewState["Estado"] != null)
                        {
                            gvArray = ViewState["Estado"] as List<ArregloSolicitud.gridV>;
                        }
                        gvArray.Add(new ArregloSolicitud.gridV
                        {
                            codigo = selArticulo.SelectedItem.ToString(),
                            cantidad = int.Parse(txtCantidad.Text),
                            op = ordenP
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
                    string msj = "swal('WARNING', 'Debe agregar la Cantidad', 'warning')";
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
            gvArray = ViewState["Estado"] as List<ArregloSolicitud.gridV>;
            gvArray.RemoveAt(f);
            InsertDetalle();
        }

        //void EnviarMensaje(string mensaje)
        //{
        //    TwilioClient.Init(
        //            username: ("ACab1f3d2e5f9afcf85b9aa6a4eeda8a01"),
        //            password: ("4495c0056e63e0bbf1a8709dc77aa72b"));

        //    MessageResource.Create(
        //             to: new PhoneNumber("+50373598472"),
        //             from: new PhoneNumber("+12512414005"),
        //             body: mensaje);
        //}
        void EnvioCorreo(string mensaje, int sol)
        {
            Clases.EnvioCorreo objCorreo = new Clases.EnvioCorreo();
            MensajitosSMS objsms = new MensajitosSMS();
            string display = "Solicitud de Material #" + sol;
            string sms = "Se agrego una nueva solicitud de material  #" + sol + ", Favor revise su correo";
            string body = @"<style>
                            h1{color:dodgerblue;}
                            </style>
                            <h1>Solicitud de Material Ingresada al Sistema</h1></br>
                            </br> <p>" + mensaje + "</p>";
            objCorreo.sendMail("comprasmacaco@outlook.com", "Nueva Solicitud de Material", body, display);
            objsms.EnviarMensaje(sms);
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarEntrada();
                GuardarDetalle();
                gvArray = ViewState["Estado"] as List<ArregloSolicitud.gridV>;
                StringBuilder sb = new StringBuilder();
                int k;
                for (k = 0; k < gvArray.Count; k++)
                {
                    sb.Append("Codigo de Material: " + gvArray[k].codigo +
                                    ", Cantidad: " + gvArray[k].cantidad +
                                    ", Para la Orden de Produccion: " + gvArray[k].op + "</br>");
                }
                string mensaje = sb.ToString();
                int ultimo = SeleccionarUltimaSolicitud();
                EnvioCorreo(mensaje, ultimo);

                string msj = "swal('SUCCESS', 'Se envio un correo especificando la entrada de material', 'success')";
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
        void GuardarEntrada()
        {
            if (selArea.SelectedItem.ToString() != "<Seleccionar Area>")
            {
                if (txtFecha.Text.Length > 0)
                {
                    int idUser = seleccionarUsuario(txtUsuario.Text);
                    int idAreaSolicita = seleccionarArea(selArea.SelectedItem.ToString());
                    SqlCommand cmd = new SqlCommand("registrarSolicitud", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = txtFecha.Text;
                    cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = idUser;
                    cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = "Pendiente";
                    cmd.Parameters.Add("@id_area", SqlDbType.VarChar).Value = idAreaSolicita;
                    
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
                string msj = "swal('WARNING', 'Debe Seleccionar el Area Solicitante', 'warning')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                msj, true);
            }
        }

        void GuardarDetalle()
        {
            int k;
            int idSolic = SeleccionarUltimaSolicitud();
            gvArray.Clear();
            gvArray = ViewState["Estado"] as List<ArregloSolicitud.gridV>;
            List<string> insertados = new List<string>();

            for (k = 0; k < gvArray.Count; k++)
            {
                SqlCommand cmd = new SqlCommand("registrarSolicitudDetalle", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_solicitud", SqlDbType.Int).Value = idSolic;
                cmd.Parameters.Add("@codigoarticulo", SqlDbType.VarChar).Value = gvArray[k].codigo.ToString();
                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = int.Parse(gvArray[k].cantidad.ToString());
                cmd.Parameters.Add("@numero_op", SqlDbType.Int).Value = int.Parse(gvArray[k].op.ToString());
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = txtFecha.Text;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}