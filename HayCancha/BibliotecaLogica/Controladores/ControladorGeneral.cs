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

        #endregion

        #region Posicion

        public static DataTable RecuperarTodasPosiciones()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaPosiciones = new DataTable();
                tablaPosiciones.Columns.Add("codigo");
                tablaPosiciones.Columns.Add("descripcion");

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

        public static void InsertarActualizarComplejo(int codigoComplejo, string descripcion, string direccion, string horaApertura, string horaCierre, string mail, string telefono, double latitud, double longitud)
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
                tablaComplejo.Columns.Add("codigoComplejo");
                tablaComplejo.Columns.Add("descripcion");
                tablaComplejo.Columns.Add("direccion");
                tablaComplejo.Columns.Add("horaApertura");
                tablaComplejo.Columns.Add("horaCierre");
                tablaComplejo.Columns.Add("latitud");
                tablaComplejo.Columns.Add("longitud");
                tablaComplejo.Columns.Add("mail");
                tablaComplejo.Columns.Add("telefono");

                Complejo complejo = CatalogoGenerico<Complejo>.RecuperarPorCodigo(codigoComplejo, nhSesion);

                if (complejo != null)
                {
                    tablaComplejo.Rows.Add(new object[] { complejo.Codigo, complejo.Descripcion, complejo.Direccion, complejo.HoraApertura, complejo.HoraCierre,
                        complejo.Latitud, complejo.Longitud, complejo.Mail, complejo.Telefono});
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

        #endregion
    }
}
