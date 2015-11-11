using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaLogica.Controladores;

namespace HayCancha.admin
{
    public partial class canchas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadCanchas();
        }

        private void LoadCanchas()
        {
            //gvCancha.DataSource = ControladorGeneral.
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }
    }
}