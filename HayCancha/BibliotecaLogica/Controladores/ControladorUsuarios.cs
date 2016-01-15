using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        public static void InsertarActualizarUsuarioApp(int codigoUsuario, string nombre, string apellido, string mail, string contraseña, string telefono, int codigoPosicion, string codigoTelefono, bool isActivo)
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
                usuario.CodigoTelefono = codigoTelefono;
                usuario.IsActivo = isActivo;

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

        public static DataTable RecuperarContraseñaApp(string mail)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuario = new DataTable();
                tablaUsuario.Columns.Add("codigoUsuario", typeof(int));
                tablaUsuario.Columns.Add("nombre", typeof(string));
                tablaUsuario.Columns.Add("apellido", typeof(string));
                tablaUsuario.Columns.Add("mail", typeof(string));
                tablaUsuario.Columns.Add("contraseña", typeof(string));
                tablaUsuario.Columns.Add("telefono", typeof(string));
                tablaUsuario.Columns.Add("codigoPosicion", typeof(int));
                tablaUsuario.Columns.Add("descripcionPosicion", typeof(string));
                tablaUsuario.Columns.Add("codigoTelefono", typeof(string));
                tablaUsuario.Columns.Add("imagen", typeof(string));
                tablaUsuario.Columns.Add("isActivo", typeof(bool));

                UsuarioApp usuario = CatalogoGenerico<UsuarioApp>.RecuperarPor(x => x.Mail == mail, nhSesion);

                if (usuario != null)
                {
                    Random rnd = new Random();
                    int nuevaContraseña = rnd.Next(111111, 999999);
                    usuario.Contraseña = nuevaContraseña.ToString();
                    CatalogoGenerico<UsuarioApp>.InsertarActualizar(usuario, nhSesion);

                    tablaUsuario.Rows.Add(new object[] { usuario.Codigo, usuario.Nombre, usuario.Apellido, usuario.Mail, usuario.Contraseña, usuario.Telefono, 
                                                     usuario.Posicion.Codigo, usuario.Posicion.Descripcion, usuario.CodigoTelefono, "http://haycancha.sempait.com.ar/Imagenes/" + usuario.Imagen, usuario.IsActivo });
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

        public static DataTable RecuperarUsuarioApp(string mail, string contraseña)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuario = new DataTable();
                tablaUsuario.Columns.Add("codigoUsuario", typeof(int));
                tablaUsuario.Columns.Add("nombre", typeof(string));
                tablaUsuario.Columns.Add("apellido", typeof(string));
                tablaUsuario.Columns.Add("mail", typeof(string));
                tablaUsuario.Columns.Add("contraseña", typeof(string));
                tablaUsuario.Columns.Add("telefono", typeof(string));
                tablaUsuario.Columns.Add("codigoPosicion", typeof(int));
                tablaUsuario.Columns.Add("descripcionPosicion", typeof(string));
                tablaUsuario.Columns.Add("codigoTelefono", typeof(string));
                tablaUsuario.Columns.Add("imagen", typeof(string));
                tablaUsuario.Columns.Add("isActivo", typeof(bool));

                UsuarioApp usuario = CatalogoGenerico<UsuarioApp>.RecuperarPor(x => x.Mail == mail && x.Contraseña == contraseña, nhSesion);

                if (usuario != null)
                {
                    tablaUsuario.Rows.Add(new object[] { usuario.Codigo, usuario.Nombre, usuario.Apellido, usuario.Mail, usuario.Contraseña, usuario.Telefono, 
                                                     usuario.Posicion.Codigo, usuario.Posicion.Descripcion, usuario.CodigoTelefono, "http://haycancha.sempait.com.ar/Imagenes/" + usuario.Imagen, usuario.IsActivo });
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

        public static DataTable RecuperarUsuarioAppPorCodigo(int codigoUsuarioApp)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuario = new DataTable();
                tablaUsuario.Columns.Add("codigoUsuario", typeof(int));
                tablaUsuario.Columns.Add("nombre", typeof(string));
                tablaUsuario.Columns.Add("apellido", typeof(string));
                tablaUsuario.Columns.Add("mail", typeof(string));
                tablaUsuario.Columns.Add("contraseña", typeof(string));
                tablaUsuario.Columns.Add("telefono", typeof(string));
                tablaUsuario.Columns.Add("codigoPosicion", typeof(int));
                tablaUsuario.Columns.Add("descripcionPosicion", typeof(string));
                tablaUsuario.Columns.Add("codigoTelefono", typeof(string));
                tablaUsuario.Columns.Add("imagen", typeof(string));
                tablaUsuario.Columns.Add("isActivo", typeof(bool));
                tablaUsuario.Columns.Add("puntaje", typeof(int));

                UsuarioApp usuario = CatalogoGenerico<UsuarioApp>.RecuperarPorCodigo(codigoUsuarioApp, nhSesion);

                if (usuario != null)
                {
                    tablaUsuario.Rows.Add(new object[] { usuario.Codigo, usuario.Nombre, usuario.Apellido, usuario.Mail, usuario.Contraseña, usuario.Telefono, 
                                                     usuario.Posicion.Codigo, usuario.Posicion.Descripcion, usuario.CodigoTelefono, "http://haycancha.sempait.com.ar/Imagenes/" +  usuario.Imagen, usuario.IsActivo, 4 });
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

        public static DataTable RecuperarUsuariosAppActivosPorPosicion(int codigoPosicion, int codigoUsuarioApp)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuarios = new DataTable();
                tablaUsuarios.Columns.Add("codigoUsuario", typeof(int));
                tablaUsuarios.Columns.Add("nombre", typeof(string));
                tablaUsuarios.Columns.Add("apellido", typeof(string));
                tablaUsuarios.Columns.Add("mail", typeof(string));
                tablaUsuarios.Columns.Add("contraseña", typeof(string));
                tablaUsuarios.Columns.Add("telefono", typeof(string));
                tablaUsuarios.Columns.Add("codigoPosicion", typeof(int));
                tablaUsuarios.Columns.Add("descripcionPosicion", typeof(string));
                tablaUsuarios.Columns.Add("codigoTelefono", typeof(string));
                tablaUsuarios.Columns.Add("imagen", typeof(string));
                tablaUsuarios.Columns.Add("isActivo", typeof(bool));

                List<UsuarioApp> listaUsuariosApp;

                if (codigoPosicion == 0)
                {
                    listaUsuariosApp = CatalogoGenerico<UsuarioApp>.RecuperarLista(x => x.IsActivo && x.Codigo != codigoUsuarioApp, nhSesion);
                }
                else
                {
                    listaUsuariosApp = CatalogoGenerico<UsuarioApp>.RecuperarLista(x => x.IsActivo && x.Posicion.Codigo == codigoPosicion && x.Codigo != codigoUsuarioApp, nhSesion);
                }

                listaUsuariosApp.Aggregate(tablaUsuarios, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.Nombre, r.Apellido, r.Mail, r.Contraseña, r.Telefono, r.Posicion.Codigo, r.Posicion.Descripcion,
                        r.CodigoTelefono, "http://haycancha.sempait.com.ar/Imagenes/" + r.Imagen, r.IsActivo); return dt;
                });

                return tablaUsuarios;
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

        public static string InsertarActualizarImagenUsuarioApp(int codigoUsuarioApp, string imagenBase64)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                System.Drawing.Image imagen = Base64ToImage(imagenBase64);

                Bitmap original = (Bitmap)imagen;
                int reducedWidth = 250;
                int reducedHeight = 250;

                Bitmap imagenReducida = new Bitmap(reducedWidth, reducedHeight);

                using (var dc = Graphics.FromImage(imagenReducida))
                {
                    // you might want to change properties like
                    dc.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    dc.DrawImage(original, new Rectangle(0, 0, reducedWidth, reducedHeight), new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);
                }

                string rutaGuardar = AppDomain.CurrentDomain.BaseDirectory + "\\Imagenes\\" + codigoUsuarioApp + ".jpg";

                imagenReducida.Save(rutaGuardar, ImageFormat.Jpeg);

                UsuarioApp usu = CatalogoGenerico<UsuarioApp>.RecuperarPorCodigo(codigoUsuarioApp, nhSesion);
                CatalogoGenerico<UsuarioApp>.InsertarActualizar(usu, nhSesion);

                return "http://haycancha.sempait.com.ar/Imagenes/" + codigoUsuarioApp + ".jpg";
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

        private static Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0,
                                             imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public Bitmap ReduceBitmap(Bitmap original, int reducedWidth, int reducedHeight)
        {
            try
            {
                var reduced = new Bitmap(reducedWidth, reducedHeight);
                using (var dc = Graphics.FromImage(reduced))
                {
                    // you might want to change properties like
                    dc.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    dc.DrawImage(original, new Rectangle(0, 0, reducedWidth, reducedHeight), new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);
                }

                return reduced;
            }
            catch (Exception ex)
            {
                ex.Data["Parametros"] = "original" + original.ToString() + ";reducedWidth" + reducedWidth.ToString() + ";reducedHeight" + reducedHeight.ToString();
                throw ex;
            }
        }

        public static void InsertarActualizarValoracionUsuarioApp(int codigoUsuarioEvaluado, int codigoUsuarioEvaluador, int puntaje, string comentario)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                UsuarioApp usuarioEvaluado = CatalogoGenerico<UsuarioApp>.RecuperarPorCodigo(codigoUsuarioEvaluado, nhSesion);

                ValoracionUsuarioApp valoracion = usuarioEvaluado.Valoraciones.Where(x => x.UsuarioAppEvaluador.Codigo == codigoUsuarioEvaluador).SingleOrDefault();

                if (valoracion == null)
                {
                    valoracion = new ValoracionUsuarioApp();
                    valoracion.UsuarioAppEvaluador = CatalogoGenerico<UsuarioApp>.RecuperarPorCodigo(codigoUsuarioEvaluador, nhSesion);
                }

                valoracion.Comentario = comentario;
                valoracion.Puntaje = puntaje;

                usuarioEvaluado.Valoraciones.Add(valoracion);

                CatalogoGenerico<UsuarioApp>.InsertarActualizar(usuarioEvaluado, nhSesion);
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

        public static DataTable RecuperarValoracionesPorUsuarioApp(int codigoUsuarioApp)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaValoraciones = new DataTable();
                tablaValoraciones.Columns.Add("codigoUsuarioEvaluador");
                tablaValoraciones.Columns.Add("nombreUsuarioEvaluador");
                tablaValoraciones.Columns.Add("apellidoUsuarioEvaluador");
                tablaValoraciones.Columns.Add("puntaje");
                tablaValoraciones.Columns.Add("comentario");

                UsuarioApp usuario = CatalogoGenerico<UsuarioApp>.RecuperarPorCodigo(codigoUsuarioApp, nhSesion);

                usuario.Valoraciones.Aggregate(tablaValoraciones, (dt, r) =>
                {
                    dt.Rows.Add(r.UsuarioAppEvaluador.Codigo, r.UsuarioAppEvaluador.Nombre, r.UsuarioAppEvaluador.Apellido, r.Puntaje, r.Comentario); return dt;
                });

                return tablaValoraciones;
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

        public static string InsertarActualizarUsuarioWeb(int codigoUsuario, string nombre, string apellido, string mail, string contraseña)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                UsuarioWeb usuarioMailRepetido = CatalogoGenerico<UsuarioWeb>.RecuperarPor(x => x.Mail == mail && x.Codigo != codigoUsuario, nhSesion);

                if (usuarioMailRepetido == null)
                {
                    UsuarioWeb usuario;

                    if (codigoUsuario == 0)
                    {
                        usuario = new UsuarioWeb();

                        Complejo complejo = new Complejo();

                        complejo.Descripcion = "";
                        complejo.Direccion = "";
                        complejo.HoraApertura = 0;
                        complejo.HoraCierre = 0;
                        complejo.Mail = "";
                        complejo.Telefono = "";
                        complejo.Latitud = 0.0;
                        complejo.Longitud = 0.0;

                        usuario.Complejo = complejo;
                    }
                    else
                    {
                        usuario = CatalogoGenerico<UsuarioWeb>.RecuperarPorCodigo(codigoUsuario, nhSesion);
                    }

                    usuario.Nombre = nombre;
                    usuario.Apellido = apellido;
                    usuario.Mail = mail;
                    usuario.Contraseña = contraseña;

                    CatalogoGenerico<UsuarioWeb>.InsertarActualizar(usuario, nhSesion);

                    if (codigoUsuario == 0)
                    {
                        //inserto la foto del complejo
                        DataTable dtUsuarioWebActual = RecuperarUsuarioWeb(mail, contraseña);
                        Complejo complejoActual = CatalogoGenerico<Complejo>.RecuperarPorCodigo(Convert.ToInt32(dtUsuarioWebActual.Rows[0]["codigoComplejo"]), nhSesion);
                        CatalogoGenerico<Complejo>.InsertarActualizar(complejoActual, nhSesion);
                    }
                    return "ok";
                }
                else
                {
                    return "mailRepetido";
                }
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
                tablaUsuario.Columns.Add("logoComplejo");

                UsuarioWeb usuario = CatalogoGenerico<UsuarioWeb>.RecuperarPor(x => x.Mail == mail && x.Contraseña == contraseña, nhSesion);

                if (usuario != null)
                {
                    tablaUsuario.Rows.Add(new object[] { usuario.Codigo, usuario.Nombre, usuario.Apellido, usuario.Mail, usuario.Contraseña, usuario.Complejo.Codigo, 
                                                     usuario.Complejo.Descripcion, usuario.Complejo.Direccion, usuario.Complejo.HoraApertura, usuario.Complejo.HoraCierre,
                                                     usuario.Complejo.Mail, usuario.Complejo.Telefono, usuario.Complejo.Logo });
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

        public static DataTable RecuperarContraseñaWeb(string mail)
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
                tablaUsuario.Columns.Add("logoComplejo");

                UsuarioWeb usuario = CatalogoGenerico<UsuarioWeb>.RecuperarPor(x => x.Mail == mail, nhSesion);

                if (usuario != null)
                {
                    Random rnd = new Random();
                    int nuevaContraseña = rnd.Next(111111, 999999);
                    usuario.Contraseña = nuevaContraseña.ToString();
                    CatalogoGenerico<UsuarioWeb>.InsertarActualizar(usuario, nhSesion);

                    tablaUsuario.Rows.Add(new object[] { usuario.Codigo, usuario.Nombre, usuario.Apellido, usuario.Mail, usuario.Contraseña, usuario.Complejo.Codigo, 
                                                     usuario.Complejo.Descripcion, usuario.Complejo.Direccion, usuario.Complejo.HoraApertura, usuario.Complejo.HoraCierre,
                                                     usuario.Complejo.Mail, usuario.Complejo.Telefono, usuario.Complejo.Logo });
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
