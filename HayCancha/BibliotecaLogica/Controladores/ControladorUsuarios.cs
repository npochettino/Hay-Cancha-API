using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Catalogos;
using BibliotecaDatos.Clases;
using BibliotecaDatos.ClasesComplementarias;
using NHibernate;

namespace BibliotecaLogica.Controladores
{
    public class ControladorUsuarios
    {
        #region UsuarioApp

        public static void InsertarActualizarUsuarioApp(int codigoUsuario, string nombre, string apellido, string mail, string contraseña, string telefono, int codigoPosicion)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                UsuarioApp usuario;

                if (codigoUsuario == 0)
                {
                    usuario = new UsuarioApp();
                }
                else
                {
                    usuario = CatalogoGenerico<UsuarioApp>.RecuperarPorCodigo(codigoUsuario, nhSesion);
                }

                usuario.Nombre = nombre;
                usuario.Apellido = apellido;
                usuario.Mail = mail;
                usuario.Contraseña = contraseña;
                usuario.Telefono = telefono;
                usuario.Posicion = CatalogoGenerico<Posicion>.RecuperarPorCodigo(codigoPosicion, nhSesion);
                usuario.IsActivo = true; //lo ponemos activo de arranque???

                CatalogoGenerico<UsuarioApp>.InsertarActualizar(usuario, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarUsuarioApp(string mail, string contraseña)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuario = new DataTable();
                tablaUsuario.Columns.Add("codigoUsuario");
                tablaUsuario.Columns.Add("nombre");
                tablaUsuario.Columns.Add("apellido");
                tablaUsuario.Columns.Add("mail");
                tablaUsuario.Columns.Add("contraseña");
                tablaUsuario.Columns.Add("telefono");
                tablaUsuario.Columns.Add("codigoPosicion");
                tablaUsuario.Columns.Add("descripcionPosicion");
                tablaUsuario.Columns.Add("isActivo");

                UsuarioApp usuario = CatalogoGenerico<UsuarioApp>.RecuperarPor(x => x.Mail == mail && x.Contraseña == contraseña, nhSesion);

                if (usuario != null)
                {
                    tablaUsuario.Rows.Add(new object[] { usuario.Codigo, usuario.Nombre, usuario.Apellido, usuario.Mail, usuario.Contraseña, usuario.Telefono, 
                                                     usuario.Posicion.Codigo, usuario.Posicion.Descripcion, usuario.IsActivo });
                }

                return tablaUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region UsuarioWeb

        public static void InsertarNuevoUsuarioWebConComplejo(string nombre, string apellido, string mail, string contraseña, string descripcionComplejo, string direccionComplejo, string horaApertura, string horaCierre, string mailComplejo, string telefonoComplejo)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                UsuarioWeb usuario = new UsuarioWeb();

                usuario.Nombre = nombre;
                usuario.Apellido = apellido;
                usuario.Mail = mail;
                usuario.Contraseña = contraseña;

                Complejo complejo = new Complejo();
                complejo.Descripcion = descripcionComplejo;
                complejo.Direccion = direccionComplejo;
                complejo.HoraApertura = horaApertura;
                complejo.HoraCierre = horaCierre;
                complejo.Mail = mailComplejo;
                complejo.Telefono = telefonoComplejo;

                usuario.Complejo = complejo;

                CatalogoGenerico<UsuarioWeb>.InsertarActualizar(usuario, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarUsuarioWeb(string mail, string contraseña)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuario = new DataTable();
                tablaUsuario.Columns.Add("codigoUsuario");
                tablaUsuario.Columns.Add("nombre");
                tablaUsuario.Columns.Add("apellido");
                tablaUsuario.Columns.Add("mail");
                tablaUsuario.Columns.Add("contraseña");
                tablaUsuario.Columns.Add("codigoComplejo");
                tablaUsuario.Columns.Add("descripcionComplejo");
                tablaUsuario.Columns.Add("direccionComplejo");
                tablaUsuario.Columns.Add("horaApertura");
                tablaUsuario.Columns.Add("horaCierre");
                tablaUsuario.Columns.Add("mailComplejo");
                tablaUsuario.Columns.Add("telefonoComplejo");

                UsuarioWeb usuario = CatalogoGenerico<UsuarioWeb>.RecuperarPor(x => x.Mail == mail && x.Contraseña == contraseña, nhSesion);

                if (usuario != null)
                {
                    tablaUsuario.Rows.Add(new object[] { usuario.Codigo, usuario.Nombre, usuario.Apellido, usuario.Mail, usuario.Contraseña, usuario.Complejo.Codigo, 
                                                     usuario.Complejo.Descripcion, usuario.Complejo.Direccion, usuario.Complejo.HoraApertura, usuario.Complejo.HoraCierre,
                                                     usuario.Complejo.Mail, usuario.Complejo.Telefono });
                }

                return tablaUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion
    }
}
