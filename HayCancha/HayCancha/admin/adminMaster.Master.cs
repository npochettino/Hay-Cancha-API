using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HayCancha.admin
{
    public partial class adminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["mailUsuarioActual"] == null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/login.aspx");
            }
            else
            {
                lblUsuarioLogueado.InnerText = " " + Session["mailUsuarioActual"].ToString();
                string pathLogoComplejo = Server.MapPath("\\") + "ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "_logo\\";
                if (!Directory.Exists(pathLogoComplejo))
                {
                    DirectoryInfo di2 = Directory.CreateDirectory(pathLogoComplejo);
                    File.Copy(Server.MapPath("\\") + "\\ImagenesComplejos" + "\\logo_complejo_default.png", pathLogoComplejo + Convert.ToString(Session["codigoComplejo"]) + ".png");
                    imgLogoComplejo.ImageUrl = "~\\ImagenesComplejos\\" + Session["codigoComplejo"].ToString() + "_logo\\" + Convert.ToString(Session["codigoComplejo"]) + ".png";
                }
                else
                    imgLogoComplejo.ImageUrl = "~\\ImagenesComplejos\\" + Session["codigoComplejo"].ToString() + "_logo\\" + Session["logocomplejo"].ToString();
            }
        }

        protected void lnkSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}