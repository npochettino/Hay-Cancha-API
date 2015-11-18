﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaLogica.Controladores;

namespace HayCancha
{
    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            ControladorUsuarios.InsertarActualizarUsuarioWeb(0, string.Empty, string.Empty, txtEmail.Value, txtContraseña.Value);
            Session.Add("contraseñaUsuarioActual", txtContraseña.Value);
            Session.Add("mailUsuarioActual", txtEmail.Value);
            //Response.Redirect("bienvenido.aspx");
            Response.Redirect("login.aspx");    
        }
    }
}