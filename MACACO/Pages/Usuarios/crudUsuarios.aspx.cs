using MACACO.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MACACO.Pages.Usuarios
{
    public partial class crudUsuarios : System.Web.UI.Page
    {
        int rol = -1;
        int est = -1;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        public static string sID = "-1";
        public static string sOpc = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && Session["usuario"] != null) {
                if (Request.QueryString["id"] != null) { 
                    sID = Request.QueryString["id"].ToString();
                }
                if (Request.QueryString["op"] != null) {
                    sOpc = Request.QueryString["op"].ToString();
                    switch (sOpc) {
                        case "C":
                            this.lblTitulo.Text = "Ingresar Nuevo Usuario";
                            idusuario.Visible = false;
                            lblID.Visible = false;
                            nivel.Visible = false;
                            radios.Visible = true;
                            this.btnregistrar.Visible = true;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de Usuario";
                            radios.Visible = false;
                            cargarDatos();
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar Usuario";
                            this.btnactualizar.Visible = true;
                            radios.Visible = true;
                            cargarDatos();
                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar Usuario";
                            this.btndeshabilitar.Visible = true;
                            radios.Visible = false;
                            cargarDatos();
                            break;
                        case "H":
                            this.lblTitulo.Text = "Habilitar Usuario";
                            this.btnhabilitar.Visible = true;
                            radios.Visible = false;
                            cargarDatos();
                            break;
                    }
                }
            }
        }

        void Limpiar()
        {
            username.Text = string.Empty;
            nombre.Text = string.Empty;
            password.Text = string.Empty;
            correo.Text = string.Empty;
            idusuario.Text = string.Empty;
            estado.Text = string.Empty;
            nivel.Text = string.Empty;
            admin.Checked = false;
            bodega.Checked = false;
            user.Checked = false;
        }

        void cargarDatos() { 
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("un_usuario", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id_usuario",SqlDbType.Int).Value= sID;

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            DataRow row = dt.Rows[0];
            idusuario.Text = row[0].ToString();
            rol = Int32.Parse(row[1].ToString());
            switch (rol)
            {
                case 1:
                    nivel.Text = "Administrador";
                    admin.Checked = true;
                    bodega.Checked = false;
                    user.Checked = false;
                    break;
                case 2:
                    nivel.Text = "Vendedor";
                    admin.Checked = false;
                    bodega.Checked = false;
                    user.Checked = true;
                    break;
                case 3:
                    nivel.Text = "Bodeguero";
                    admin.Checked = false;
                    bodega.Checked = true;
                    user.Checked = false;
                    break;
            }
            username.Text = row[2].ToString();
            nombre.Text = row[3].ToString();
            password.Text = row[4].ToString();
            est = Int32.Parse(row[5].ToString());
            switch (est) {
                case 0:
                    estado.Text = "Deshabilitado";
                    break;
                case 1:
                    estado.Text = "Habilitado";
                    break;
            }
            correo.Text = row[6].ToString();
            con.Close();
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            Usuario obj = new Usuario();
            obj.nombre = nombre.Text;
            obj.username = username.Text.ToLower();
            obj.clave = password.Text;
            obj.correo = correo.Text.ToLower();
            obj.estado = 1;

            if (bodega.Checked)
                obj.id_rol = 1002;
            else if (admin.Checked)
                obj.id_rol = 1;
            else if (user.Checked)
                obj.id_rol = 2;
            else
                obj.id_rol = 2;
            try
            {
                if (username.Text.Length != 0 && nombre.Text.Length != 0 && password.Text.Length != 0 && correo.Text.Length != 0)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("validar_usuario", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = obj.username;
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
                        SqlCommand cmd = new SqlCommand("sp_registrar_usuario", con);
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = obj.username;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombre;
                        cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = obj.clave;
                        cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = obj.correo;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = obj.estado;
                        cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = obj.id_rol;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Limpiar();
                        Response.Redirect("Usuarios.aspx");
                        
                    }
                    else
                    {
                        string msj = "swal('ERROR', 'El nombre de usuario ya existe', 'error')";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                        msj, true);
                        username.Focus();
                    }
                }
                else
                {
                    if (username.Text.Length == 0)
                    {
                        Mensaje();
                        username.Focus();
                    }
                    if (nombre.Text.Length == 0)
                    {
                        Mensaje();
                        nombre.Focus();
                    }
                    if (password.Text.Length == 0)
                    {
                        Mensaje();
                        password.Focus();
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
            Usuario obj = new Usuario();
            obj.id_usuario = int.Parse(sID);
            obj.nombre = nombre.Text;
            obj.username = username.Text.ToLower();
            obj.clave = password.Text;
            obj.correo = correo.Text.ToLower();
            obj.estado = 1;
            if (bodega.Checked)
                obj.id_rol = 1002;
            else if (admin.Checked)
                obj.id_rol = 1;
            else if (user.Checked)
                obj.id_rol = 2;
            else
                obj.id_rol = 2;


            try
            {
                SqlCommand cmd = new SqlCommand("update_usuario", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = obj.id_usuario;
                cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = obj.id_rol;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = obj.username;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombre;
                cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = obj.clave;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = obj.estado;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = obj.correo;

                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Usuarios.aspx");
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        protected void btndeshabilitar_Click(object sender, EventArgs e)
        {
            Usuario obj = new Usuario();
            obj.id_usuario = int.Parse(sID);
            try
            {
                SqlCommand cmd = new SqlCommand("inhabilitar_usuario", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = obj.id_usuario;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Usuarios.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnhabilitar_Click(object sender, EventArgs e)
        {
            Usuario obj = new Usuario();
            obj.id_usuario = int.Parse(sID);
            try
            {
                SqlCommand cmd = new SqlCommand("habilitar_usuario", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = obj.id_usuario;
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Usuarios.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        protected void Mensaje() {
            string msj = "swal('WARNING', 'Valide que los campos requeridos esten llenos', 'warning')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
            msj, true);
            username.Focus();
        }
    }
}