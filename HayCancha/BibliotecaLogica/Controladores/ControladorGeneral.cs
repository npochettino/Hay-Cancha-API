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
    public class ControladorGeneral
    {
        #region Cancha

        public static void InsertarActualizarCancha(int codigoCancha, int codigoComplejo, string descripcion, double precioMañana, double precioTarde, double precioNoche, int codigoTipoCancha)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Cancha cancha;

                if (codigoCancha == 0)
                {
                    cancha = new Cancha();
                }
                else
                {
                    cancha = CatalogoGenerico<Cancha>.RecuperarPorCodigo(codigoCancha, nhSesion);
                }

                cancha.Complejo = CatalogoGenerico<Complejo>.RecuperarPorCodigo(codigoComplejo, nhSesion);
                cancha.Descripcion = descripcion;
                cancha.TipoCancha = CatalogoGenerico<TipoCancha>.RecuperarPorCodigo(codigoTipoCancha, nhSesion);
                cancha.PrecioMañana = precioMañana;
                cancha.PrecioTarde = precioTarde;
                cancha.PrecioNoche = precioNoche;

                CatalogoGenerico<Cancha>.InsertarActualizar(cancha, nhSesion);
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

        public static DataTable RecuperarCanchasPorComplejo(int codigoComplejo)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaCanchas = new DataTable();
                tablaCanchas.Columns.Add("codigoComplejo");
                tablaCanchas.Columns.Add("codigoCancha");
                tablaCanchas.Columns.Add("descripcion");
                tablaCanchas.Columns.Add("precioMañana");
                tablaCanchas.Columns.Add("precioTarde");
                tablaCanchas.Columns.Add("precioNoche");
                tablaCanchas.Columns.Add("codigoTipoCancha");
                tablaCanchas.Columns.Add("descripcionTipoCancha");

                List<Cancha> listaCanchas = CatalogoCancha.RecuperarPorCodigoComplejo(codigoComplejo, nhSesion);

                (from p in listaCanchas select p).Aggregate(tablaCanchas, (dt, r) =>
                {
                    dt.Rows.Add(r.Complejo.Codigo, r.Codigo, r.Descripcion, r.PrecioMañana, r.PrecioTarde, r.PrecioNoche,
                        r.TipoCancha.Codigo, r.TipoCancha.Descripcion); return dt;
                });

                return tablaCanchas;
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

        public static void EliminarCancha(int codigoCancha)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Cancha cancha = CatalogoGenerico<Cancha>.RecuperarPorCodigo(codigoCancha, nhSesion);

                CatalogoGenerico<Cancha>.Eliminar(cancha, nhSesion);
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

        #region Posicion

        public static DataTable RecuperarTodasPosiciones()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaPosiciones = new DataTable();
                tablaPosiciones.Columns.Add("codigo", typeof(int));
                tablaPosiciones.Columns.Add("descripcion", typeof(string));

                List<Posicion> listaPosiciones = CatalogoGenerico<Posicion>.RecuperarTodos(nhSesion);

                listaPosiciones.Aggregate(tablaPosiciones, (dt, r) => { dt.Rows.Add(r.Codigo, r.Descripcion); return dt; });

                return tablaPosiciones;
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

        #region TipoCancha

        public static DataTable RecuperarTodosTiposCancha()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaTiposCancha = new DataTable();
                tablaTiposCancha.Columns.Add("codigo");
                tablaTiposCancha.Columns.Add("descripcion");

                List<TipoCancha> listaTiposCancha = CatalogoGenerico<TipoCancha>.RecuperarTodos(nhSesion);

                listaTiposCancha.Aggregate(tablaTiposCancha, (dt, r) => { dt.Rows.Add(r.Codigo, r.Descripcion); return dt; });

                return tablaTiposCancha;
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

        #region Complejo

        public static void InsertarActualizarComplejo(int codigoComplejo, string descripcion, string direccion, int horaApertura, int horaCierre, string mail, string telefono, double latitud, double longitud)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Complejo complejo;

                if (codigoComplejo == 0)
                {
                    complejo = new Complejo();
                }
                else
                {
                    complejo = CatalogoGenerico<Complejo>.RecuperarPorCodigo(codigoComplejo, nhSesion);
                }

                complejo.Descripcion = descripcion;
                complejo.Direccion = direccion;
                complejo.HoraApertura = horaApertura;
                complejo.HoraCierre = horaCierre;
                complejo.Latitud = latitud;
                complejo.Longitud = longitud;
                complejo.Mail = mail;
                complejo.Telefono = telefono;

                CatalogoGenerico<Complejo>.InsertarActualizar(complejo, nhSesion);
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

        public static DataTable RecuperarComplejo(int codigoComplejo)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaComplejo = new DataTable();
                tablaComplejo.Columns.Add("codigoComplejo", typeof(int));
                tablaComplejo.Columns.Add("descripcion", typeof(string));
                tablaComplejo.Columns.Add("direccion", typeof(string));
                tablaComplejo.Columns.Add("horaApertura", typeof(int));
                tablaComplejo.Columns.Add("horaCierre", typeof(int));
                tablaComplejo.Columns.Add("latitud", typeof(decimal));
                tablaComplejo.Columns.Add("longitud", typeof(decimal));
                tablaComplejo.Columns.Add("mail", typeof(string));
                tablaComplejo.Columns.Add("telefono", typeof(string));
                tablaComplejo.Columns.Add("logo", typeof(string));

                Complejo complejo = CatalogoGenerico<Complejo>.RecuperarPorCodigo(codigoComplejo, nhSesion);

                if (complejo != null)
                {
                    tablaComplejo.Rows.Add(new object[] { complejo.Codigo, complejo.Descripcion, complejo.Direccion, complejo.HoraApertura, complejo.HoraCierre,
                        complejo.Latitud, complejo.Longitud, complejo.Mail, complejo.Telefono, complejo.Logo });
                }

                return tablaComplejo;
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

        public static DataTable RecuperarTodosComplejos()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaComplejos = new DataTable();
                tablaComplejos.Columns.Add("codigoComplejo", typeof(int));
                tablaComplejos.Columns.Add("descripcion", typeof(string));
                tablaComplejos.Columns.Add("direccion", typeof(string));
                tablaComplejos.Columns.Add("horaApertura", typeof(int));
                tablaComplejos.Columns.Add("horaCierre", typeof(int));
                tablaComplejos.Columns.Add("latitud", typeof(decimal));
                tablaComplejos.Columns.Add("longitud", typeof(decimal));
                tablaComplejos.Columns.Add("mail", typeof(string));
                tablaComplejos.Columns.Add("telefono", typeof(string));

                List<Complejo> listaComplejos = CatalogoGenerico<Complejo>.RecuperarTodos(nhSesion);

                if (listaComplejos != null)
                {
                    listaComplejos.Aggregate(tablaComplejos, (dt, r) =>
                    {
                        dt.Rows.Add(r.Codigo, r.Descripcion, r.Direccion, r.HoraApertura, r.HoraCierre,
                            r.Latitud, r.Longitud, r.Mail, r.Telefono); return dt;
                    });
                }

                return tablaComplejos;
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

        #region ValoracionComplejo

        public static DataTable RecuperarValoracionesComplejo(int codigoComplejo, int codigoUsuarioApp)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaValoracionesComplejo = new DataTable();
                tablaValoracionesComplejo.Columns.Add("codigoComplejo", typeof(int));
                tablaValoracionesComplejo.Columns.Add("descripcion", typeof(string));
                tablaValoracionesComplejo.Columns.Add("puntaje", typeof(int));
                tablaValoracionesComplejo.Columns.Add("comentario", typeof(string));
                tablaValoracionesComplejo.Columns.Add("titulo", typeof(string));
                tablaValoracionesComplejo.Columns.Add("fechaHoraValoracion", typeof(string));
                tablaValoracionesComplejo.Columns.Add("codigoUsuarioApp", typeof(int));
                tablaValoracionesComplejo.Columns.Add("nombreApellidoUsuarioApp", typeof(string));
                tablaValoracionesComplejo.Columns.Add("myComment", typeof(bool));
                tablaValoracionesComplejo.Columns.Add("logoComplejo", typeof(string));

                Complejo complejo = CatalogoGenerico<Complejo>.RecuperarPorCodigo(codigoComplejo, nhSesion);

                complejo.ValoracionesComplejo.OrderByDescending(x => x.FechaHoraValoracionComplejo).Aggregate(tablaValoracionesComplejo, (dt, r) =>
                {
                    dt.Rows.Add(complejo.Codigo, complejo.Descripcion, r.Puntaje, r.Comentario, r.Titulo, r.FechaHoraValoracionComplejo.ToString("dd/MM/yyyy"),
                        r.UsuarioApp.Codigo, r.UsuarioApp.Nombre + " " + r.UsuarioApp.Apellido, r.UsuarioApp.Codigo == codigoUsuarioApp ? true : false, complejo.Logo); return dt;
                });

                return tablaValoracionesComplejo;
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

        public static void InsertarActualizarValoracionComplejo(int puntaje, string titulo, string comentario, int codigoComplejo, int codigoUsuarioApp)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Complejo complejo = CatalogoGenerico<Complejo>.RecuperarPorCodigo(codigoComplejo, nhSesion);

                ValoracionComplejo valCom = complejo.ValoracionesComplejo.Where(x => x.UsuarioApp.Codigo == codigoUsuarioApp).SingleOrDefault();

                if (valCom == null)
                {
                    valCom = new ValoracionComplejo();
                    complejo.ValoracionesComplejo.Add(valCom);
                }

                valCom.Comentario = comentario;
                valCom.Puntaje = puntaje;
                valCom.Titulo = titulo;
                valCom.FechaHoraValoracionComplejo = DateTime.Now;
                valCom.UsuarioApp = CatalogoGenerico<UsuarioApp>.RecuperarPorCodigo(codigoUsuarioApp, nhSesion);

                CatalogoGenerico<Complejo>.InsertarActualizar(complejo, nhSesion);
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

        #region Solicitud

        public static void InsertarActualizarSolicitud(int codigoSolicitud, int codigoTurno, bool isVariable, int codigoUsuarioAppInvitado, int codigoEstadoSolicitud)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Solicitud solicitud;

                if (codigoSolicitud == 0)
                {
                    solicitud = new Solicitud();
                }
                else
                {
                    solicitud = CatalogoGenerico<Solicitud>.RecuperarPorCodigo(codigoSolicitud, nhSesion);
                }

                if (isVariable)
                {
                    solicitud.TurnoVariable = CatalogoGenerico<TurnoVariable>.RecuperarPorCodigo(codigoTurno, nhSesion);
                }
                else
                {
                    solicitud.TurnoFijo = CatalogoGenerico<TurnoFijo>.RecuperarPorCodigo(codigoTurno, nhSesion);
                }

                solicitud.UsuarioAppInvitado = CatalogoGenerico<UsuarioApp>.RecuperarPorCodigo(codigoUsuarioAppInvitado, nhSesion);
                solicitud.EstadoSolicitud = CatalogoGenerico<EstadoSolicitud>.RecuperarPorCodigo(codigoEstadoSolicitud, nhSesion);

                CatalogoGenerico<Solicitud>.InsertarActualizar(solicitud, nhSesion);
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

        public static DataTable RecuperarSolicitudesPorUsuario(int codigoUsuarioApp, int codigoEstadoSolicitud)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaSolicitudes = new DataTable();
                tablaSolicitudes.Columns.Add("codigoSolicitud", typeof(int));
                tablaSolicitudes.Columns.Add("codigoEstadoSolicitud", typeof(int));
                tablaSolicitudes.Columns.Add("descripcionEstadoSolicitud", typeof(string));
                tablaSolicitudes.Columns.Add("codigoCancha", typeof(int));
                tablaSolicitudes.Columns.Add("descripcionCancha", typeof(string));
                tablaSolicitudes.Columns.Add("codigoComplejo", typeof(int));
                tablaSolicitudes.Columns.Add("descripcionComplejo", typeof(string));
                tablaSolicitudes.Columns.Add("fecha", typeof(string));
                tablaSolicitudes.Columns.Add("horaDesde", typeof(string));
                tablaSolicitudes.Columns.Add("horaHasta", typeof(string));
                tablaSolicitudes.Columns.Add("imagenUsuario", typeof(string));
                tablaSolicitudes.Columns.Add("nombreApellidoUsuario", typeof(string));
                tablaSolicitudes.Columns.Add("isCreator", typeof(bool));
                tablaSolicitudes.Columns.Add("codigoTurno", typeof(int));
                tablaSolicitudes.Columns.Add("codigoUsuarioAppInvitado", typeof(int));
                tablaSolicitudes.Columns.Add("direccionComplejo", typeof(string));
                tablaSolicitudes.Columns.Add("precio", typeof(double));
                tablaSolicitudes.Columns.Add("codigoTelefono", typeof(string));

                List<Solicitud> listaSolicitudesInvitado;

                if (codigoEstadoSolicitud == 0)
                {
                    listaSolicitudesInvitado = CatalogoSolicitud.RecuperarVigentesPorUsuarioApp(codigoUsuarioApp, nhSesion);
                }
                else
                {
                    listaSolicitudesInvitado = CatalogoSolicitud.RecuperarVigentesPorUsuarioAppYEstado(codigoUsuarioApp, codigoEstadoSolicitud, nhSesion);
                }

                foreach (Solicitud solicitud in listaSolicitudesInvitado)
                {
                    int codigoCancha;
                    string descripcionCancha;
                    int codigoComplejo;
                    string descripcionComplejo;
                    string direccionComplejo;
                    double precio;
                    DateTime fechaHoraDesde = new DateTime();
                    DateTime fechaHoraHasta = new DateTime();
                    string imagenUsuario;
                    string nombreApellido;
                    int codigoTurno;
                    bool isVariable;
                    string codigoTelefono = string.Empty;

                    if (solicitud.TurnoFijo != null)
                    {
                        codigoCancha = solicitud.TurnoFijo.Cancha.Codigo;
                        descripcionCancha = solicitud.TurnoFijo.Cancha.Descripcion;
                        codigoComplejo = solicitud.TurnoFijo.Cancha.Complejo.Codigo;
                        descripcionComplejo = solicitud.TurnoFijo.Cancha.Complejo.Descripcion;
                        nombreApellido = solicitud.TurnoFijo.Responsable;
                        imagenUsuario = string.Empty;
                        codigoTurno = solicitud.TurnoFijo.Codigo;
                        isVariable = false;
                        direccionComplejo = solicitud.TurnoFijo.Cancha.Complejo.Direccion;
                        precio = solicitud.TurnoFijo.Cancha.PrecioTarde;

                        for (int i = 0; i < 6; i++)
                        {
                            DateTime fecha = DateTime.Now.AddDays(i);
                            if (Convert.ToInt32(fecha.DayOfWeek) == solicitud.TurnoFijo.CodigoDiaSemana)
                            {
                                fechaHoraDesde = Convert.ToDateTime(fecha.ToString("dd/MM/yyyy") + " " + solicitud.TurnoFijo.HoraDesde.ToString("00") + ":00:00");
                                fechaHoraHasta = Convert.ToDateTime(fecha.ToString("dd/MM/yyyy") + " " + solicitud.TurnoFijo.HoraHasta.ToString("00") + ":00:00");
                            }
                        }
                    }
                    else
                    {
                        codigoCancha = solicitud.TurnoVariable.Cancha.Codigo;
                        descripcionCancha = solicitud.TurnoVariable.Cancha.Descripcion;
                        codigoComplejo = solicitud.TurnoVariable.Cancha.Complejo.Codigo;
                        descripcionComplejo = solicitud.TurnoVariable.Cancha.Complejo.Descripcion;
                        fechaHoraDesde = solicitud.TurnoVariable.FechaHoraDesde;
                        fechaHoraHasta = solicitud.TurnoVariable.FechaHoraHasta;
                        nombreApellido = solicitud.TurnoVariable.UsuarioApp.Nombre + " " + solicitud.TurnoVariable.UsuarioApp.Apellido;
                        imagenUsuario = solicitud.TurnoVariable.UsuarioApp.Imagen;
                        codigoTurno = solicitud.TurnoVariable.Codigo;
                        isVariable = true;
                        direccionComplejo = solicitud.TurnoVariable.Cancha.Complejo.Direccion;
                        precio = solicitud.TurnoVariable.Cancha.PrecioTarde;
                        codigoTelefono = solicitud.TurnoVariable.UsuarioApp.CodigoTelefono;
                    }

                    tablaSolicitudes.Rows.Add(new object[] { solicitud.Codigo, solicitud.EstadoSolicitud.Codigo, solicitud.EstadoSolicitud.Descripcion, codigoCancha,
                    descripcionCancha, codigoComplejo, descripcionComplejo, fechaHoraDesde.ToString("dd/MM/yyyy"), fechaHoraDesde.Hour, fechaHoraHasta.Hour,
                    imagenUsuario, nombreApellido, false, codigoTurno, codigoUsuarioApp, direccionComplejo, precio, codigoTelefono });
                }

                List<int> listaTurnosVariables = CatalogoGenerico<TurnoVariable>.RecuperarLista(x => x.UsuarioApp.Codigo == codigoUsuarioApp && x.FechaHoraDesde > DateTime.Now, nhSesion).Select(x => x.Codigo).ToList();
                List<Solicitud> listaSolicitud;

                if (codigoEstadoSolicitud == 0)
                {
                    listaSolicitud = CatalogoSolicitud.RecuperarPorTurnos(listaTurnosVariables, nhSesion);
                }
                else
                {
                    listaSolicitud = CatalogoSolicitud.RecuperarPorTurnosYEstado(listaTurnosVariables, codigoEstadoSolicitud, nhSesion);
                }

                foreach (Solicitud solicitud in listaSolicitud)
                {
                    int codigoCancha;
                    string descripcionCancha;
                    int codigoComplejo;
                    string descripcionComplejo;
                    DateTime fechaHoraDesde = new DateTime();
                    DateTime fechaHoraHasta = new DateTime();
                    string direccionComplejo;
                    double precio;
                    int codigoTurno;
                    string codigoTelefono = string.Empty;
                    bool isVariable;

                    if (solicitud.TurnoFijo != null)
                    {
                        codigoCancha = solicitud.TurnoFijo.Cancha.Codigo;
                        descripcionCancha = solicitud.TurnoFijo.Cancha.Descripcion;
                        codigoComplejo = solicitud.TurnoFijo.Cancha.Complejo.Codigo;
                        descripcionComplejo = solicitud.TurnoFijo.Cancha.Complejo.Descripcion;
                        codigoTurno = solicitud.TurnoFijo.Codigo;
                        isVariable = false;
                        direccionComplejo = solicitud.TurnoFijo.Cancha.Complejo.Direccion;
                        precio = solicitud.TurnoFijo.Cancha.PrecioTarde;

                        for (int i = 0; i < 6; i++)
                        {
                            DateTime fecha = DateTime.Now.AddDays(i);
                            if (Convert.ToInt32(fecha.DayOfWeek) == solicitud.TurnoFijo.CodigoDiaSemana)
                            {
                                fechaHoraDesde = Convert.ToDateTime(fecha.ToString("dd/MM/yyyy") + " " + solicitud.TurnoFijo.HoraDesde.ToString("00") + ":00:00");
                                fechaHoraHasta = Convert.ToDateTime(fecha.ToString("dd/MM/yyyy") + " " + solicitud.TurnoFijo.HoraHasta.ToString("00") + ":00:00");
                            }
                        }
                    }
                    else
                    {
                        codigoCancha = solicitud.TurnoVariable.Cancha.Codigo;
                        descripcionCancha = solicitud.TurnoVariable.Cancha.Descripcion;
                        codigoComplejo = solicitud.TurnoVariable.Cancha.Complejo.Codigo;
                        descripcionComplejo = solicitud.TurnoVariable.Cancha.Complejo.Descripcion;
                        fechaHoraDesde = solicitud.TurnoVariable.FechaHoraDesde;
                        fechaHoraHasta = solicitud.TurnoVariable.FechaHoraHasta;
                        codigoTurno = solicitud.TurnoVariable.Codigo;
                        isVariable = true;
                        direccionComplejo = solicitud.TurnoVariable.Cancha.Complejo.Direccion;
                        precio = solicitud.TurnoVariable.Cancha.PrecioTarde;
                        codigoTelefono = solicitud.TurnoVariable.UsuarioApp.CodigoTelefono;
                    }

                    tablaSolicitudes.Rows.Add(new object[] { solicitud.Codigo, solicitud.EstadoSolicitud.Codigo, solicitud.EstadoSolicitud.Descripcion, codigoCancha,
                    descripcionCancha, codigoComplejo, descripcionComplejo, fechaHoraDesde.ToString("dd/MM/yyyy"), fechaHoraDesde.Hour, fechaHoraHasta.Hour,
                    solicitud.UsuarioAppInvitado.Imagen, solicitud.UsuarioAppInvitado.Nombre + " " + solicitud.UsuarioAppInvitado.Apellido, true, 
                    codigoTurno, codigoUsuarioApp, direccionComplejo, precio, codigoTelefono });
                }

                return tablaSolicitudes;
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
