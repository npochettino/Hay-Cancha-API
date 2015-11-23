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
using System.Drawing;
using DevExpress.Web;
using DevExpress.Web.Internal;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ImageControls.Internal;

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

            string path = Server.MapPath("..") + "\\assets\\images\\complejos\\" + Session["codigoComplejo"].ToString();
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                File.Copy(Server.MapPath("..") + "\\assets\\images\\complejos\\HayCancha.png", path + "\\HayCancha.png");
            }

            isComplejo.ImageSourceFolder = "~\\admin\\assets\\images\\complejos\\" + Convert.ToString(Session["codigoComplejo"]) + "\\";


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //lat DECIMAL(10, 8) NOT NULL, lng DECIMAL(11, 8) NOT NULL
            Decimal lat = Decimal.Parse(txtLatitud.Text, CultureInfo.InvariantCulture);
            Decimal lon = Decimal.Parse(txtLongitud.Text, CultureInfo.InvariantCulture);

            ControladorGeneral.InsertarActualizarComplejo(Convert.ToInt32(Session["codigoComplejo"].ToString()), txtNombreComplejo.Text, txtPlaces.Text,
                Convert.ToInt32(ddlHoraApertura.SelectedValue), Convert.ToInt32(ddlHoraCierre.SelectedValue), txtMailComplejo.Text, txtTelefono.Text, (double)lat, (double)lon, "");
        }

        const string UploadDirectory = "~/admin/assets/images/complejos/1/";




    }
}