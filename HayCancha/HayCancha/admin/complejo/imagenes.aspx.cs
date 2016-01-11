using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HayCancha.admin.complejo
{
    public partial class imagenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadComplejo();
        }

        private void LoadComplejo()
        {
            string pathImagenesComplejo = Server.MapPath("\\") + "haycancha\\ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "\\";
            
            if (!Directory.Exists(pathImagenesComplejo))
            {
                DirectoryInfo di = Directory.CreateDirectory(pathImagenesComplejo);
                File.Copy(Server.MapPath("\\") + "haycancha\\ImagenesComplejos" + "\\complejo_default.jpg", pathImagenesComplejo + Convert.ToString(Session["codigoComplejo"]) + ".jpg");
            }

            isImagenesComplejo.ImageSourceFolder = "~\\ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "\\";
        }

        protected void btnSubirImagenes_Click(object sender, EventArgs e)
        {
            if (fileUploadImagenes.HasFile)
            {
                string fileName = Path.GetFileName(fileUploadImagenes.PostedFile.FileName);
                fileUploadImagenes.PostedFile.SaveAs(Server.MapPath("\\") + "haycancha\\ImagenesComplejos\\" + Convert.ToString(Session["codigoComplejo"]) + "\\" + DateTime.Now.ToString("_yyyyMMdd_HHmmss") + ".jpg");
                Response.Redirect("imagenes.aspx");
            }
        }

        protected void btnEliminarImagen_Click(object sender, EventArgs e)
        {
        }
    }
}