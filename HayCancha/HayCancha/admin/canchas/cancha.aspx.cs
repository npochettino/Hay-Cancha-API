﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaDatos.Clases;
using BibliotecaLogica.Controladores;

namespace HayCancha.admin.canchas
{
    public partial class cancha : System.Web.UI.Page
    {
        Cancha oCanchaActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarComboTipoCancha();
            if (!IsPostBack)
            {
                //Cargo el form para editar
                if ((Cancha)Session["canchaActual"] != null)
                {
                    CargarDatosParaEditar((Cancha)Session["canchaActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion", 0);
                }
            }
        }

        private void CargarDatosParaEditar(Cancha oCanchaActual)
        {
            ddTipoCancha.Value = oCanchaActual.TipoCancha.Codigo;
            ddTipoCancha.Text = oCanchaActual.TipoCancha.Descripcion;

            txtDescripcion.Text = oCanchaActual.Descripcion;
            txtPrecioMañana.Text = Convert.ToString(oCanchaActual.PrecioMañana);
            txtPrecioTarde.Text = Convert.ToString(oCanchaActual.PrecioTarde);
            txtPrecioNoche.Text = Convert.ToString(oCanchaActual.PrecioNoche);
        }

        private void CargarComboTipoCancha()
        {
            ddTipoCancha.DataSource = ControladorGeneral.RecuperarTodosTiposCancha();
            ddTipoCancha.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //si el codigoOperacion es Null es una edicion.
            if (Session["codigoOperacion"] == null)
            {
                oCanchaActual = (Cancha)Session["canchaActual"];
                ControladorGeneral.InsertarActualizarCancha(oCanchaActual.Codigo, Convert.ToInt32(Session["codigoComplejo"]), txtDescripcion.Text, Convert.ToInt32(ddTipoCancha.Value));
            }
            //si el codigoOperacion es != null hago un insert.
            else
            {
                ControladorGeneral.InsertarActualizarCancha(0, Convert.ToInt32(Session["codigoComplejo"]), txtDescripcion.Text, Convert.ToInt32(ddTipoCancha.Value));
            }
            Response.Redirect("listado.aspx");
        }
    }
}