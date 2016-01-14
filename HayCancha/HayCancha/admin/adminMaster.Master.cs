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
                string pathLogoComplejo = Server.MapPath("\\") + "haycancha\\ImagenesComplejos\\Logos\\";
                if (!Directory.Exists(pathLogoComplejo))
                {
                    DirectoryInfo di2 = Directory.CreateDirectory(pathLogoComplejo);
                    File.Copy(Server.MapPath("\\") + "haycancha\\ImagenesComplejos" + "\\logo_complejo_default.png", pathLogoComplejo + Convert.ToString(Session["codigoComplejo"]) + ".png");
                    imgLogoComplejo.ImageUrl = "~\\ImagenesComplejos\\Logos\\" + Convert.ToString(Session["codigoComplejo"]) + ".png";
                }
                else
                    imgLogoComplejo.ImageUrl = "~\\ImagenesComplejos\\Logos\\" + Convert.ToString(Session["codigoComplejo"]) + ".png";
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