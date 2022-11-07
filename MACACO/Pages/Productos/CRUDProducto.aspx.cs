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
using MACACO.Pages.AreasEmpresa;

namespace MACACO.Pages.Productos
{
    public partial class CRUDProducto : System.Web.UI.Page
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
                            idProd.Visible = false;
                            lblID.Visible = false;
                            DivEstado.Visible = false;
                            this.btnregistrar.Visible = true;
                            cargarCategorias("");
                            cargarSubCategorias("");
                            cargarMedidas("");
                            cargarMarcas("");
                            cargarAreas("");
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de Material";
                            cargarDatos();
                            divstock.Visible = false;
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar Material";
                            this.btnactualizar.Visible = true;
                            cargarDatos();
                            divstock.Visible = false;
                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar Material";
                            this.btndeshabilitar.Visible = true;
                            cargarDatos();
                            divstock.Visible = false;
                            break;
                        case "H":
                            this.lblTitulo.Text = "Habilitar Material";
                            this.btnhabilitar.Visible = true;
                            cargarDatos();
                            divstock.Visible = false;
                            break;
                    }
                }
            }
        }

        void Limpiar()
        {
            idProd.Text = string.Empty;
            codigoarticulo.Text = string.Empty;
            nombre.Text = string.Empty;
            descripcion.Text = string.Empty;
            stock.Text = string.Empty;
            estadoSubCat.Text = string.Empty;
        }

        void cargarCategorias(string categoria)
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
            if (categoria.Length > 0)
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
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                id = int.Parse(row[0].ToString());
            }

            con.Close();
            return id;
        }

        void cargarSubCategorias(string subcategoria)
        {
            con.Open();
            string consulta = "Select id_subcategoria, nombre from subcategoria";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            selsubcat.DataSource = ds;
            selsubcat.DataTextField = "nombre";
            selsubcat.DataValueField = "id_subcategoria";
            selsubcat.DataBind();
            if (subcategoria.Length > 0)
            {
                selsubcat.Items.Insert(0, new ListItem(subcategoria, "0"));
            }
            else { selsubcat.Items.Insert(0, new ListItem("<Seleccionar SubCategoria>", "0")); }

            con.Close();
        }

        int seleccionarSubCategorias(string nombre)
        {
            int id = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("EscogerSubCategoria", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
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

        void cargarMedidas(string medida)
        {
            con.Open();
            string consulta = "Select id_medida, medida from medida";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            selmedida.DataSource = ds;
            selmedida.DataTextField = "medida";
            selmedida.DataValueField = "id_medida";
            selmedida.DataBind();
            if (medida.Length > 0)
            {
                selmedida.Items.Insert(0, new ListItem(medida, "0"));
            }
            else { selmedida.Items.Insert(0, new ListItem("<Seleccionar Medida>", "0")); }

            con.Close();
        }

        int seleccionarMedida(string medida)
        {
            int id = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("EscogerMedida", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@medida", SqlDbType.VarChar).Value = medida;
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

        void cargarMarcas(string marca)
        {
            con.Open();
            string consulta = "Select id_marca, marca from marca";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            selmarca.DataSource = ds;
            selmarca.DataTextField = "marca";
            selmarca.DataValueField = "id_marca";
            selmarca.DataBind();
            if (marca.Length > 0)
            {
                selmarca.Items.Insert(0, new ListItem(marca, "0"));
            }
            else { selmarca.Items.Insert(0, new ListItem("<Seleccionar Marca>", "0")); }

            con.Close();
        }

        int seleccionarMarca(string marca)
        {
            int id = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("EscogerMarca", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@marca", SqlDbType.VarChar).Value = marca;
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

        void cargarAreas(string area)
        {
            con.Open();
            string consulta = "Select id_area, nombre from areaempresa";
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            selarea.DataSource = ds;
            selarea.DataTextField = "nombre";
            selarea.DataValueField = "id_area";
            selarea.DataBind();
            if (area.Length > 0)
            {
                selarea.Items.Insert(0, new ListItem(area, "0"));
            }
            else { selarea.Items.Insert(0, new ListItem("<Seleccionar Area>", "0")); }

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
        void cargarDatos()
        {
            int estado;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("unArticulo", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = sID;

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            DataRow row = dt.Rows[0];
            idProd.Text = row[0].ToString();
            string categoria = row[2].ToString();
            string subcategoria = row[4].ToString();
            codigoarticulo.Text = row[5].ToString();
            nombre.Text = row[6].ToString();
            descripcion.Text = row[7].ToString();
            stock.Text = row[8].ToString();
            string medida = row[10].ToString();
            string marca = row[12].ToString();
            string area = row[14].ToString();
            estado = int.Parse(row[15].ToString());
            if (estado == 1)
            {
                estadoSubCat.Text = "Habilitado";
            }
            else { estadoSubCat.Text = "Deshabilitado"; }
            con.Close();
            cargarCategorias(categoria);
            cargarSubCategorias(subcategoria);
            cargarMedidas(medida);
            cargarMarcas(marca);
            cargarAreas(area);
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            int cat,sub,med,mark,area;
            Articulo obj = new Articulo();
            obj.codigoarticulo = codigoarticulo.Text.ToString();
            obj.nombre = nombre.Text.ToString();
            obj.descripcion = descripcion.Text.ToString();
            if(stock.Text.Length > 0)
            {
                obj.stock = int.Parse(stock.Text.ToString());
            }
            else { 
                obj.stock = 0; 
            }
            obj.catname = selcat.SelectedItem.ToString();
            cat = seleccionarCategorias(obj.catname);
            if (cat != 0) { obj.id_categoria = cat; }
            else { Mensaje(); }

            obj.subcategoria = selsubcat.SelectedItem.ToString();
            sub = seleccionarSubCategorias(obj.subcategoria);
            if (sub != 0) { obj.id_subcategoria = sub; }
            else { Mensaje(); }

            obj.medida = selmedida.SelectedItem.ToString();
            med = seleccionarMedida(obj.medida);
            if (med != 0) { obj.id_medida = med; }
            else { Mensaje(); }

            obj.marca = selmarca.SelectedItem.ToString();
            mark = seleccionarMarca(obj.marca);
            if (mark != 0) { obj.id_marca = mark; }
            else { Mensaje(); }

            obj.area = selarea.SelectedItem.ToString();
            area = seleccionarArea(obj.area);
            if (area != 0) { obj.id_area = area; }
            else { Mensaje(); }

            obj.estado = 1;
            try
            {
                if (codigoarticulo.Text.Length != 0 && nombre.Text.Length != 0 && descripcion.Text.Length != 0)
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("validarArticulo", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@codigo", SqlDbType.VarChar).Value = obj.nombre;
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
                        SqlCommand cmd = new SqlCommand("registrarArticulo", con);
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_categoria", SqlDbType.Int).Value = obj.id_categoria;
                        cmd.Parameters.Add("@id_subcategoria", SqlDbType.Int).Value = obj.id_subcategoria;
                        cmd.Parameters.Add("@codigoarticulo", SqlDbType.VarChar).Value = obj.codigoarticulo;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombre;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.descripcion;
                        cmd.Parameters.Add("@stock", SqlDbType.Int).Value = obj.stock;
                        cmd.Parameters.Add("@id_medida", SqlDbType.Int).Value = obj.id_medida;
                        cmd.Parameters.Add("@id_marca", SqlDbType.Int).Value = obj.id_marca;
                        cmd.Parameters.Add("@id_area", SqlDbType.Int).Value = obj.id_area;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = obj.estado;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Limpiar();
                        Response.Redirect("Productos.aspx");

                    }
                    else
                    {
                        string msj = "swal('ERROR', 'El codigo de Material ya existe, Si necesita crearlo favor asignar un codigo diferente', 'error')";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
                        msj, true);
                        codigoarticulo.Focus();
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
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            int cat, sub, med, mark, area;
            Articulo obj = new Articulo();
            obj.id_articulo = int.Parse(idProd.Text.ToString());
            obj.codigoarticulo = codigoarticulo.Text.ToString();
            obj.nombre = nombre.Text.ToString();
            obj.descripcion = descripcion.Text.ToString();
            obj.catname = selcat.SelectedItem.ToString();
            cat = seleccionarCategorias(obj.catname);
            if (cat != 0) { obj.id_categoria = cat; }
            else { Mensaje(); }
            obj.subcategoria = selsubcat.SelectedItem.ToString();
            sub = seleccionarSubCategorias(obj.subcategoria);
            if (sub != 0) { obj.id_subcategoria = sub; }
            else { Mensaje(); }
            obj.medida = selmedida.SelectedItem.ToString();
            med = seleccionarMedida(obj.medida);
            if (med != 0) { obj.id_medida = med; }
            else { Mensaje(); }
            obj.marca = selmarca.SelectedItem.ToString();
            mark = seleccionarMarca(obj.marca);
            if (mark != 0) { obj.id_marca = mark; }
            else { Mensaje(); }
            obj.area = selarea.SelectedItem.ToString();
            area = seleccionarArea(obj.area);
            if (area != 0) { obj.id_area = area; }
            else { Mensaje(); }
            obj.estado = 1;
            try
            {
                SqlCommand cmd = new SqlCommand("updateArticulo", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idart", SqlDbType.Int).Value = obj.id_articulo;
                cmd.Parameters.Add("@idcat", SqlDbType.Int).Value = obj.id_categoria;
                cmd.Parameters.Add("@idsub", SqlDbType.Int).Value = obj.id_subcategoria;
                cmd.Parameters.Add("@codart", SqlDbType.VarChar).Value = obj.codigoarticulo;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nombre;
                cmd.Parameters.Add("@des", SqlDbType.VarChar).Value = obj.descripcion;
                cmd.Parameters.Add("@idmed", SqlDbType.Int).Value = obj.id_medida;
                cmd.Parameters.Add("@idmarca", SqlDbType.Int).Value = obj.id_marca;
                cmd.Parameters.Add("@idarea", SqlDbType.Int).Value = obj.id_area;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = obj.estado;

                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Productos.aspx");
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btndeshabilitar_Click(object sender, EventArgs e)
        {
            Articulo obj = new Articulo();
            obj.id_articulo = int.Parse(sID);
            try
            {
                string consulta = "update articulo set  estado=0 where id_articulo =  " + obj.id_articulo;
                SqlCommand cmd = new SqlCommand(consulta, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Productos.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnhabilitar_Click(object sender, EventArgs e)
        {
            Articulo obj = new Articulo();
            obj.id_articulo = int.Parse(sID);
            try
            {
                string consulta = "update articulo set  estado=1 where id_articulo =  " + obj.id_articulo;
                SqlCommand cmd = new SqlCommand(consulta, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("Productos.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }

        protected void Mensaje()
        {
            string msj = "swal('WARNING', 'Valide que los campos requeridos esten llenos', 'warning')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
            msj, true);
        }
    }
}