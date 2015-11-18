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

        public static void InsertarActualizarCancha(int codigoCancha, int codigoComplejo, string descripcion, int codigoTipoCancha)
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
                cancha.PrecioMañana = 10;
                cancha.PrecioTarde = 20;
                cancha.PrecioNoche = 30;

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

                Cancha canchas = CatalogoGenerico<Cancha>.RecuperarPorCodigo(codigoComplejo, nhSesion);

                if (canchas != null)
                {
                    tablaCanchas.Rows.Add(new object[] { canchas.Complejo.Codigo, canchas.Codigo, canchas.Descripcion, canchas.PrecioMañana, canchas.PrecioTarde,canchas.PrecioNoche,
                        canchas.TipoCancha.Codigo,canchas.TipoCancha.Descripcion});
                }

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

        public static void InsertarActualizarComplejo(int codigoComplejo, string descripcion, string direccion, int horaApertura, int horaCierre, string mail, string telefono, Decimal latitud, Decimal longitud)
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

                Complejo complejo = CatalogoGenerico<Complejo>.RecuperarPorCodigo(codigoComplejo, nhSesion);

                if (complejo != null)
                {
                    tablaComplejo.Rows.Add(new object[] { complejo.Codigo, complejo.Descripcion, complejo.Direccion, complejo.HoraApertura, complejo.HoraCierre,
                        complejo.Latitud, complejo.Longitud, complejo.Mail, complejo.Telefono });
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

        public static DataTable RecuperarValoracionesComplejo(int codigoComplejo)
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
                tablaValoracionesComplejo.Columns.Add("fechaHoraValoracion", typeof(DateTime));
                tablaValoracionesComplejo.Columns.Add("codigoUsuarioApp", typeof(int));
                tablaValoracionesComplejo.Columns.Add("nombreApellidoUsuarioApp", typeof(string));

                Complejo complejo = CatalogoGenerico<Complejo>.RecuperarPorCodigo(codigoComplejo, nhSesion);

                complejo.ValoracionesComplejo.Aggregate(tablaValoracionesComplejo, (dt, r) =>
                {
                    dt.Rows.Add(complejo.Codigo, complejo.Descripcion, r.Puntaje, r.Comentario, r.Titulo, r.FechaHoraValoracionComplejo,
                        r.UsuarioApp.Codigo, r.UsuarioApp.Nombre + " " + r.UsuarioApp.Apellido); return dt;
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
    }
}
