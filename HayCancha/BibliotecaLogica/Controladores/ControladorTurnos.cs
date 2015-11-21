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
    public class ControladorTurnos
    {
        public static DataTable RecuperarTurnosPorRangoHorario(DateTime fecha, int horaDesde, int horaHasta, int codigoUsuarioApp)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaTurnos = new DataTable();
                tablaTurnos.Columns.Add("horaDesde", typeof(int));
                tablaTurnos.Columns.Add("horaHasta", typeof(int));
                tablaTurnos.Columns.Add("codigoCancha", typeof(int));
                tablaTurnos.Columns.Add("descripcionCancha", typeof(string));
                tablaTurnos.Columns.Add("codigoTipoCancha", typeof(int));
                tablaTurnos.Columns.Add("descripcionTipoCancha", typeof(string));
                tablaTurnos.Columns.Add("codigoComplejo", typeof(int));
                tablaTurnos.Columns.Add("descripcionComplejo", typeof(string));
                tablaTurnos.Columns.Add("imagenComplejo", typeof(string));
                tablaTurnos.Columns.Add("isFavorito", typeof(bool));
                tablaTurnos.Columns.Add("precio", typeof(double));
                tablaTurnos.Columns.Add("direccion", typeof(string));
                tablaTurnos.Columns.Add("puntajeComplejo", typeof(int));
                tablaTurnos.Columns.Add("latitud", typeof(double));
                tablaTurnos.Columns.Add("longitud", typeof(double));

                UsuarioApp usuarioApp = CatalogoGenerico<UsuarioApp>.RecuperarPorCodigo(codigoUsuarioApp, nhSesion);

                List<TurnoVariable> listaTurnosVariables = CatalogoTurnoVariable.RecuperarPorFechaYHora(fecha, horaDesde, horaHasta, nhSesion);
                List<TurnoFijo> listaTurnosFijos = CatalogoTurnoFijo.RecuperarPorFechaYHora(fecha, horaDesde, horaHasta, nhSesion);
                List<Cancha> listaCanchas = CatalogoGenerico<Cancha>.RecuperarTodos(nhSesion);

                for (int i = horaDesde; i < horaHasta; i++)
                {
                    foreach (Cancha cancha in listaCanchas)
                    {
                        TurnoFijo turnoFijo = (from tf in listaTurnosFijos where tf.HoraDesde == i && tf.Cancha.Codigo == cancha.Codigo select tf).SingleOrDefault();

                        if (turnoFijo == null)
                        {
                            TurnoVariable turnoVariable = (from tv in listaTurnosVariables where tv.FechaHoraDesde.Hour == i && tv.Cancha.Codigo == cancha.Codigo select tv).SingleOrDefault();

                            if (turnoVariable == null)
                            {
                                bool isFavorito = usuarioApp.ComplejosFravoritos.Where(x => x.Codigo == cancha.Complejo.Codigo) == null ? false : true;

                                tablaTurnos.Rows.Add(new object[] { i, i + 1, cancha.Codigo, cancha.Descripcion, cancha.TipoCancha.Codigo, cancha.TipoCancha.Descripcion,
                                        cancha.Complejo.Codigo, cancha.Complejo.Descripcion, "imagenComplejo", isFavorito, cancha.PrecioTarde, cancha.Complejo.Direccion,
                                        3, cancha.Complejo.Latitud, cancha.Complejo.Longitud});
                            }
                        }
                    }
                }

                return tablaTurnos;
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

        public static void InsertarActualizarTurnoVariable(int codigoTurnoVariable, int codigoCancha, DateTime fechaHoraDesde, DateTime fechaHoraHasta, int codigoUsuarioApp, string observaciones, string responsable, double seña)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                TurnoVariable turno;

                if (codigoTurnoVariable == 0)
                {
                    turno = new TurnoVariable();
                }
                else
                {
                    turno = CatalogoGenerico<TurnoVariable>.RecuperarPorCodigo(codigoTurnoVariable, nhSesion);
                }

                turno.Cancha = CatalogoGenerico<Cancha>.RecuperarPorCodigo(codigoCancha, nhSesion);
                turno.FechaHoraDesde = fechaHoraDesde;
                turno.FechaHoraHasta = fechaHoraHasta;
                turno.Observaciones = observaciones;
                turno.Responsable = responsable;
                turno.Seña = seña;
                turno.UsuarioApp = CatalogoGenerico<UsuarioApp>.RecuperarPorCodigo(codigoUsuarioApp, nhSesion);
                turno.EstadoTurno = CatalogoGenerico<EstadoTurno>.RecuperarPorCodigo(Constantes.EstadosTurno.PENDIENTE, nhSesion);
                turno.UsuarioWeb = null;

                CatalogoGenerico<TurnoVariable>.InsertarActualizar(turno, nhSesion);
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

        public static bool ValidarTurnoDesocupado(DateTime fechaHoraDesde, DateTime fechaHoraHasta, int codigoCancha)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                TurnoVariable turnoV = CatalogoTurnoVariable.RecuperarTurnoPorCanchaYFechas(fechaHoraDesde, fechaHoraHasta, codigoCancha, nhSesion);

                if (turnoV != null)
                {
                    return false;
                }
                else
                {
                    TurnoFijo turnoF = CatalogoGenerico<TurnoFijo>.RecuperarPor(x => x.Cancha.Codigo == codigoCancha && x.FechaHasta == null && x.CodigoDiaSemana == Convert.ToInt32(fechaHoraDesde.DayOfWeek) && x.HoraDesde <= fechaHoraDesde.Hour && x.HoraHasta >= fechaHoraHasta.Hour, nhSesion);

                    if (turnoF != null)
                    {
                        return false;
                    }
                }

                return true;
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

        public static DataTable RecuperarTurnosPorFechaPorCancha(DateTime fecha, int codigoCancha)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaTurnos = new DataTable();
                tablaTurnos.Columns.Add("horaDesde", typeof(int));
                tablaTurnos.Columns.Add("horaHasta", typeof(int));
                tablaTurnos.Columns.Add("codigoCancha", typeof(int));
                tablaTurnos.Columns.Add("descripcionCancha", typeof(string));
                tablaTurnos.Columns.Add("codigoTipoCancha", typeof(int));
                tablaTurnos.Columns.Add("descripcionTipoCancha", typeof(string));
                tablaTurnos.Columns.Add("codigoComplejo", typeof(int));
                tablaTurnos.Columns.Add("descripcionComplejo", typeof(string));
                
                tablaTurnos.Columns.Add("precio", typeof(double));
                tablaTurnos.Columns.Add("direccion", typeof(string));
                tablaTurnos.Columns.Add("puntajeComplejo", typeof(int));
                tablaTurnos.Columns.Add("latitud", typeof(double));
                tablaTurnos.Columns.Add("longitud", typeof(double));
                tablaTurnos.Columns.Add("estado", typeof(string));
                
                
                Cancha cancha = CatalogoGenerico<Cancha>.RecuperarPorCodigo(codigoCancha, nhSesion);
                Complejo complejo = CatalogoGenerico<Complejo>.RecuperarPorCodigo(cancha.Complejo.Codigo, nhSesion);

                List<TurnoVariable> listaTurnosVariables = CatalogoTurnoVariable.RecuperarTurnoPorCanchaYFecha(fecha, codigoCancha, nhSesion);
                List<TurnoFijo> listaTurnosFijos = CatalogoTurnoFijo.RecuperarTurnoPorCanchaYFecha(fecha, codigoCancha, nhSesion);

                (from p in listaTurnosFijos select p).Aggregate(tablaTurnos, (dt, r) =>
                {
                    dt.Rows.Add( r.HoraDesde, r.HoraHasta, cancha.Codigo, cancha.Descripcion, cancha.TipoCancha.Codigo, cancha.TipoCancha.Descripcion,
                    cancha.Complejo.Codigo, cancha.Complejo.Descripcion, cancha.PrecioTarde, cancha.Complejo.Direccion,
                     3, cancha.Complejo.Latitud, cancha.Complejo.Longitud, Constantes.EstadosTurno.RESERVADO); return dt;
                });

                (from p in listaTurnosVariables select p).Aggregate(tablaTurnos, (dt, r) =>
                {
                    dt.Rows.Add(r.FechaHoraDesde.Hour, r.FechaHoraHasta.Hour, cancha.Codigo, cancha.Descripcion, cancha.TipoCancha.Codigo, cancha.TipoCancha.Descripcion,
                    cancha.Complejo.Codigo, cancha.Complejo.Descripcion, cancha.PrecioTarde, cancha.Complejo.Direccion,
                     3, cancha.Complejo.Latitud, cancha.Complejo.Longitud, r.EstadoTurno.Descripcion); return dt;
                });
                
                return tablaTurnos;
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


    }
}
