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

            //string path = Server.MapPath("..") + "\\assets\\images\\complejos\\" + Session["codigoComplejo"].ToString();
            string pathLogoComplejo = Server.MapPath("\\") + "ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "_logo\\";
            string pathImagenesComplejo = Server.MapPath("\\") + "ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "\\";
            if (!Directory.Exists(pathLogoComplejo))
            {
                DirectoryInfo di2 = Directory.CreateDirectory(pathLogoComplejo);
                //File.Copy(pathLogoComplejo + Convert.ToString(Session["codigoComplejo"]) + ".png", Server.MapPath("\\") + "\\ImagenesComplejos" + "\\logo_complejo_default.png");
                File.Copy(Server.MapPath("\\") + "ImagenesComplejos" + "\\logo_complejo_default.png", pathLogoComplejo + Convert.ToString(Session["codigoComplejo"]) + ".png");
            }
            if (!Directory.Exists(pathImagenesComplejo))
            {
                DirectoryInfo di = Directory.CreateDirectory(pathImagenesComplejo);
                File.Copy(Server.MapPath("\\") + "ImagenesComplejos" + "\\complejo_default.jpg", pathImagenesComplejo + Convert.ToString(Session["codigoComplejo"]) + ".jpg");
            }

            //isComplejo.ImageSourceFolder = "~\\ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "\\";
            ASPxImageSlider1.ImageSourceFolder = "~\\ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "\\";
            isLogoComplejo.ImageSourceFolder = "~\\ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "_logo\\" + "\\";

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //lat DECIMAL(10, 8) NOT NULL, lng DECIMAL(11, 8) NOT NULL
            Decimal lat = Decimal.Parse(txtLatitud.Text, CultureInfo.InvariantCulture);
            Decimal lon = Decimal.Parse(txtLongitud.Text, CultureInfo.InvariantCulture);

            ControladorGeneral.InsertarActualizarComplejo(Convert.ToInt32(Session["codigoComplejo"].ToString()), txtNombreComplejo.Text, txtPlaces.Text,
                Convert.ToInt32(ddlHoraApertura.SelectedValue), Convert.ToInt32(ddlHoraCierre.SelectedValue), txtMailComplejo.Text, txtTelefono.Text, (double)lat, (double)lon, "");
        }

        protected void btnCargarLogo_Click(object sender, EventArgs e)
        {
            if (fuLogo.HasFile)
            {
                string fileName = Path.GetFileName(fuLogo.PostedFile.FileName);
                fuLogo.PostedFile.SaveAs(Server.MapPath("\\") + "ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "_logo\\" + Session["codigoComplejo"].ToString() + ".png");
                Response.Redirect("complejo.aspx");
            }
        }

        protected void btnCargarImagenes_Click(object sender, EventArgs e)
        {
            if (fileUploadImagenes.HasFile)
            {
                string fileName = Path.GetFileName(fileUploadImagenes.PostedFile.FileName);
                fileUploadImagenes.PostedFile.SaveAs(Server.MapPath("\\") + "ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "\\" + DateTime.Now.ToString("_yyyyMMdd_HHmmss") + ".jpg");
                Response.Redirect("complejo.aspx");
            }
        }

        protected void ASPxCallbackPanel1_Callback(object sender, CallbackEventArgsBase e)
        {
            string[] parameter = e.Parameter.Split(',');

            if (fileUploadImagenes.HasFile)
            {
                string fileName = Path.GetFileName(fileUploadImagenes.PostedFile.FileName);
                fileUploadImagenes.PostedFile.SaveAs(Server.MapPath("\\") + "ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "\\" + DateTime.Now.ToString("_yyyyMMdd_HHmmss") + ".jpg");
                Response.Redirect("complejo.aspx");
            }
        }
        
    }
}