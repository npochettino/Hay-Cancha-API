using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaLogica.Controladores;
using DevExpress.Web;
using DevExpress.Web.Internal;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ImageControls.Internal;
using System.Web.Services;

namespace HayCancha.admin.complejo
{
    public partial class complejo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["codigoComplejo"] == null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
                LoadComplejo();
        }

        private void LoadComplejo()
        {
            DataTable dtComplejoActual = ControladorGeneral.RecuperarComplejo(Convert.ToInt32(Session["codigoComplejo"]));//ControladorUsuarios.RecuperarUsuarioWeb(Session["mailUsuarioActual"].ToString(), Session["contraseñaUsuarioActual"].ToString());

            txtNombreComplejo.Text = dtComplejoActual.Rows[0]["descripcion"].ToString();
            txtPlaces.Text = dtComplejoActual.Rows[0]["direccion"].ToString();
            txtTelefono.Text = dtComplejoActual.Rows[0]["telefono"].ToString();
            ddlHoraApertura.Text = dtComplejoActual.Rows[0]["horaApertura"].ToString();
            ddlHoraCierre.Text = dtComplejoActual.Rows[0]["horaCierre"].ToString();
            txtMailComplejo.Text = dtComplejoActual.Rows[0]["mail"].ToString();
            txtLatitud.Text = dtComplejoActual.Rows[0]["latitud"].ToString();
            txtLongitud.Text = dtComplejoActual.Rows[0]["longitud"].ToString();

            string pathLogoComplejo = Server.MapPath("\\") + "haycancha\\ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "_logo\\";
            if (!Directory.Exists(pathLogoComplejo))
            {
                DirectoryInfo di2 = Directory.CreateDirectory(pathLogoComplejo);
                File.Copy(Server.MapPath("\\") + "haycancha\\ImagenesComplejos" + "\\logo_complejo_default.png", pathLogoComplejo + Convert.ToString(Session["codigoComplejo"]) + ".png");
            }

            isLogoComplejo.ImageSourceFolder = "~\\ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "_logo\\" + "\\";

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //lat DECIMAL(10, 8) NOT NULL, lng DECIMAL(11, 8) NOT NULL
            Decimal lat = Decimal.Parse(txtLatitud.Text, CultureInfo.InvariantCulture);
            Decimal lon = Decimal.Parse(txtLongitud.Text, CultureInfo.InvariantCulture);

            string[] direccion = txtPlaces.Text.Split(',');

            ControladorGeneral.InsertarActualizarComplejo(Convert.ToInt32(Session["codigoComplejo"].ToString()), txtNombreComplejo.Text, direccion[0],
                Convert.ToInt32(ddlHoraApertura.SelectedValue), Convert.ToInt32(ddlHoraCierre.SelectedValue), txtMailComplejo.Text, txtTelefono.Text, (double)lat, (double)lon, Convert.ToString(Session["codigoComplejo"]) + ".png");

            Response.Redirect("complejo.aspx");
        }

        protected void btnCargarLogo_Click(object sender, EventArgs e)
        {
            if (fuLogo.HasFile)
            {
                string fileName = Path.GetFileName(fuLogo.PostedFile.FileName);
                fuLogo.PostedFile.SaveAs(Server.MapPath("\\") + "haycancha\\ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "_logo\\" + Session["codigoComplejo"].ToString() + ".png");
                Response.Redirect("complejo.aspx");
            }
        }


    }
}