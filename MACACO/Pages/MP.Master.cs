using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MACACO.Pages
{
    public partial class MP : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Response.AppendHeader("Cache-Control", "no-store");
            if (Session["usuario"] != null)
            {
                divuser.Visible = true;
                lbluser.Text = Session["usuario"].ToString().ToUpper();
            }
            else
            {
                divuser.Visible = false;
                lbluser.Text = string.Empty;
            }
            
        }
        

        protected void salir_Click(object sender, EventArgs e)
        {
            try
            {
                string msj = "swal('Good job!', 'You clicked the button!', 'success')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", msj, true);
                Session["usuario"] = null;
                Session["id_rol"] = null;
                Response.Redirect("~/Pages/Login.aspx");
                HttpContext.Current.Session.Abandon();
                MsjExito();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void MsjExito() {
            string msj = "swal('Good job!', 'You clicked the button!', 'success')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert",
            msj, true);
        }
    }
}