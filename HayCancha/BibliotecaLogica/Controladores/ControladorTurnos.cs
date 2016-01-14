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
        public static bool CambiarEstadoDelTurno(int codigoTurno, int estado)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            TurnoVariable tv = CatalogoGenerico<TurnoVariable>.RecuperarPor(x => x.Codigo == codigoTurno, nhSesion);

            if (tv != null)
            {
                tv.EstadoTurno = CatalogoGenerico<EstadoTurno>.RecuperarPorCodigo(estado,nhSesion);
                //tv.EstadoTurno.Codigo = Constantes.EstadosTurno.RESERVADO;

                CatalogoGenerico<TurnoVariable>.InsertarActualizar(tv, nhSesion);

                return true;
            }

            return false;
        }

        public static DataTable RecuperarTurnoPorCodigo(int codigoTurno)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaTurnos = new DataTable();
                tablaTurnos.Columns.Add("fecha", typeof(DateTime));
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
                tablaTurnos.Columns.Add("codigoUsuarioApp", typeof(string));
                tablaTurnos.Columns.Add("nombreUsuarioApp", typeof(string));
                tablaTurnos.Columns.Add("apellidoUsuarioApp", typeof(string));
                tablaTurnos.Columns.Add("telefonoUsuarioApp", typeof(string));
                tablaTurnos.Columns.Add("codigoTelefonoUsuarioApp", typeof(string));
                tablaTurnos.Columns.Add("imagenUsuarioApp", typeof(string));

                TurnoVariable tv = CatalogoGenerico<TurnoVariable>.RecuperarPor(x => x.Codigo == codigoTurno, nhSesion);

                if (tablaTurnos != null)
                {
                    tablaTurnos.Rows.Add(new object[] { tv.FechaHoraDesde.Date, tv.FechaHoraDesde.Hour, tv.FechaHoraHasta.Hour, tv.Cancha.Codigo, tv.Cancha.Descripcion, tv.Cancha.TipoCancha.Codigo, tv.Cancha.TipoCancha.Descripcion,
                        tv.Cancha.Complejo.Codigo, tv.Cancha.Complejo.Descripcion, tv.Cancha.PrecioTarde, 
                        tv.Cancha.Complejo.Direccion, tv.UsuarioApp.Codigo, tv.UsuarioApp.Nombre,  tv.UsuarioApp.Apellido, tv.UsuarioApp.Telefono, tv.UsuarioApp.CodigoTelefono,
                    tv.UsuarioApp.Imagen});
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

                                double valoracion = 0;
                                if (cancha.Complejo.ValoracionesComplejo.Count > 0)
                                {
                                    valoracion = (double)cancha.Complejo.ValoracionesComplejo.Sum(x => x.Puntaje) / (double)cancha.Complejo.ValoracionesComplejo.Count;
                                }

                                tablaTurnos.Rows.Add(new object[] { i, i + 1, cancha.Codigo, cancha.Descripcion, cancha.TipoCancha.Codigo, cancha.TipoCancha.Descripcion,
                                        cancha.Complejo.Codigo, cancha.Complejo.Descripcion, cancha.Complejo.Logo, isFavorito, cancha.PrecioTarde, cancha.Complejo.Direccion,
                                        valoracion, cancha.Complejo.Latitud, cancha.Complejo.Longitud});
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

        public static string InsertarActualizarTurnoVariable(int codigoTurnoVariable, int codigoCancha, DateTime fechaHoraDesde, DateTime fechaHoraHasta, int codigoUsuarioApp, string observaciones, string responsable, double seña)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                TurnoVariable turnoAnterior = CatalogoTurnoVariable.RecuperarPorFechaYHoraYCancha(fechaHoraDesde.Date, fechaHoraDesde.Hour, fechaHoraHasta.Hour, codigoCancha, nhSesion);

                if (turnoAnterior == null)
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

                    bool horaValida = ValidarHorario(turno.Cancha.Complejo, fechaHoraDesde.Hour, fechaHoraHasta.Hour);

                    if (horaValida)
                    {
                        turno.FechaHoraDesde = fechaHoraDesde;
                        turno.FechaHoraHasta = fechaHoraHasta;
                        turno.Observaciones = observaciones;
                        turno.Responsable = responsable;
                        turno.Seña = seña;
                        turno.UsuarioApp = CatalogoGenerico<UsuarioApp>.RecuperarPorCodigo(codigoUsuarioApp, nhSesion);
                        turno.EstadoTurno = CatalogoGenerico<EstadoTurno>.RecuperarPorCodigo(Constantes.EstadosTurno.PENDIENTE, nhSesion);
                        turno.UsuarioWeb = null;

                        CatalogoGenerico<TurnoVariable>.InsertarActualizar(turno, nhSesion);

                        return "ok";
                    }
                    else
                    {
                        return "HorarioInvalido";
                    }
                }
                else
                {
                    return "HorarioOcupado";
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

        private static bool ValidarHorario(Complejo complejo, int horaDesde, int horaHasta)
        {
            if (horaDesde >= complejo.HoraApertura && horaHasta <= complejo.HoraCierre && horaDesde <= horaHasta)
            {
                return true;
            }
            else
            {
                return false;
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

        public static DataTable RecuperarTurnosDisponiblesPorComplejoPorDia(DateTime fecha, int codigoComplejo)
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
                tablaTurnos.Columns.Add("precio", typeof(double));
                tablaTurnos.Columns.Add("direccion", typeof(string));
                tablaTurnos.Columns.Add("puntajeComplejo", typeof(int));
                tablaTurnos.Columns.Add("latitud", typeof(double));
                tablaTurnos.Columns.Add("longitud", typeof(double));
                tablaTurnos.Columns.Add("estado", typeof(string));

                Complejo complejo = CatalogoGenerico<Complejo>.RecuperarPorCodigo(codigoComplejo, nhSesion);

                int horaDesde = complejo.HoraApertura;
                int horaHasta = complejo.HoraCierre;

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
                                tablaTurnos.Rows.Add(new object[] { i, i + 1, cancha.Codigo, cancha.Descripcion, cancha.TipoCancha.Codigo, cancha.TipoCancha.Descripcion,
                                        cancha.Complejo.Codigo, cancha.Complejo.Descripcion, "imagenComplejo", cancha.PrecioTarde, cancha.Complejo.Direccion,
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

        public static DataTable RecuperarTurnosVigentesPorUsuario(int codigoUsuarioApp)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaTurnos = new DataTable();
                tablaTurnos.Columns.Add("codigoTurno", typeof(int));
                tablaTurnos.Columns.Add("horaDesde", typeof(int));
                tablaTurnos.Columns.Add("horaHasta", typeof(int));
                tablaTurnos.Columns.Add("codigoCancha", typeof(int));
                tablaTurnos.Columns.Add("descripcionCancha", typeof(string));
                tablaTurnos.Columns.Add("codigoTipoCancha", typeof(int));
                tablaTurnos.Columns.Add("descripcionTipoCancha", typeof(string));
                tablaTurnos.Columns.Add("codigoComplejo", typeof(int));
                tablaTurnos.Columns.Add("descripcionComplejo", typeof(string));
                tablaTurnos.Columns.Add("imagenComplejo", typeof(string));
                tablaTurnos.Columns.Add("precio", typeof(double));
                tablaTurnos.Columns.Add("direccion", typeof(string));
                tablaTurnos.Columns.Add("puntajeComplejo", typeof(int));
                tablaTurnos.Columns.Add("latitud", typeof(double));
                tablaTurnos.Columns.Add("longitud", typeof(double));
                tablaTurnos.Columns.Add("fecha", typeof(string));
                tablaTurnos.Columns.Add("codigoEstado", typeof(int));
                tablaTurnos.Columns.Add("descripcionEstado", typeof(string));

                List<TurnoVariable> listaTurnosVariables = CatalogoGenerico<TurnoVariable>.RecuperarLista(x => x.UsuarioApp.Codigo == codigoUsuarioApp && (x.EstadoTurno.Codigo == Constantes.EstadosTurno.PENDIENTE || x.EstadoTurno.Codigo == Constantes.EstadosTurno.RESERVADO || x.EstadoTurno.Codigo == Constantes.EstadosTurno.CANCELADO) && x.FechaHoraDesde < DateTime.Now, nhSesion);

                listaTurnosVariables.Aggregate(tablaTurnos, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.FechaHoraDesde.Hour, r.FechaHoraHasta.Hour, r.Cancha.Codigo, r.Cancha.Descripcion, r.Cancha.TipoCancha.Codigo,
                        r.Cancha.TipoCancha.Descripcion, r.Cancha.Complejo.Codigo, r.Cancha.Complejo.Descripcion, "imagen", r.Cancha.PrecioTarde, r.Cancha.Complejo.Direccion,
                        3, r.Cancha.Complejo.Latitud, r.Cancha.Complejo.Longitud, r.FechaHoraDesde.ToString("dd/MM/yyyy"), r.EstadoTurno.Codigo, r.EstadoTurno.Descripcion); return dt;
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

        public static DataTable RecuperarTurnosPorComplejoPorDia(DateTime fecha, int codigoComplejo)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Complejo complejo = CatalogoGenerico<Complejo>.RecuperarPorCodigo(codigoComplejo, nhSesion);
                List<Cancha> listaCanchas = CatalogoGenerico<Cancha>.RecuperarLista(x => x.Complejo.Codigo == codigoComplejo, nhSesion);

                DataTable tablaTurnos = new DataTable();
                tablaTurnos.Columns.Add("Hora");
                tablaTurnos.Columns.Add("HoraDesde");
                tablaTurnos.Columns.Add("HoraHasta");

                foreach (Cancha cancha in listaCanchas)
                {
                    tablaTurnos.Columns.Add("codigoCancha" + cancha.Descripcion);
                    tablaTurnos.Columns.Add("codigoTurno" + cancha.Descripcion);
                    tablaTurnos.Columns.Add(cancha.Descripcion);
                }

                int horaDesde = complejo.HoraApertura;
                int horaHasta = complejo.HoraCierre;

                List<TurnoVariable> listaTurnosVariables = CatalogoTurnoVariable.RecuperarPorFechaYHoraYComplejo(fecha, horaDesde, horaHasta, codigoComplejo, nhSesion).Where(x => x.EstadoTurno.Codigo != Constantes.EstadosTurno.CANCELADO && x.EstadoTurno.Codigo != Constantes.EstadosTurno.CANCELADO).ToList();
                List<TurnoFijo> listaTurnosFijos = CatalogoTurnoFijo.RecuperarPorFechaYHoraYComplejo(fecha, horaDesde, horaHasta, codigoComplejo, nhSesion);

                for (int i = horaDesde; i < horaHasta; i++)
                {
                    DataRow filaNueva = tablaTurnos.NewRow();
                    filaNueva["hora"] = i + " a " + (i + 1);
                    filaNueva["HoraDesde"] = i;
                    filaNueva["HoraHasta"] = i + 1;

                    foreach (Cancha cancha in listaCanchas)
                    {
                        TurnoFijo turnoFijo = (from tf in listaTurnosFijos where tf.HoraDesde == i && tf.Cancha.Codigo == cancha.Codigo select tf).SingleOrDefault();

                        if (turnoFijo == null)
                        {
                            TurnoVariable turnoVariable = (from tv in listaTurnosVariables where tv.FechaHoraDesde.Hour == i && tv.Cancha.Codigo == cancha.Codigo select tv).SingleOrDefault();

                            filaNueva["codigoCancha" + cancha.Descripcion] = cancha.Codigo; 

                            if (turnoVariable == null)
                            {
                                filaNueva["codigoTurno" + cancha.Descripcion] = "0";
                                filaNueva[cancha.Descripcion] = "Disponible";
                            }
                            else
                            {
                                if (turnoVariable.EstadoTurno.Codigo == Constantes.EstadosTurno.PENDIENTE)
                                {
                                    string nombreReserva = turnoVariable.Responsable != string.Empty ? turnoVariable.Responsable : turnoVariable.UsuarioApp.Nombre + " " + turnoVariable.UsuarioApp.Apellido;
                                    filaNueva["codigoTurno" + cancha.Descripcion] = turnoVariable.Codigo;
                                    filaNueva[cancha.Descripcion] = "Pendiente de confirmación - " + nombreReserva;
                                }
                                else if (turnoVariable.EstadoTurno.Codigo == Constantes.EstadosTurno.RESERVADO || turnoVariable.EstadoTurno.Codigo == Constantes.EstadosTurno.CERRADO)
                                {
                                    string nombreReserva = turnoVariable.Responsable != string.Empty ? turnoVariable.Responsable : turnoVariable.UsuarioApp.Nombre + " " + turnoVariable.UsuarioApp.Apellido;
                                    filaNueva["codigoTurno" + cancha.Descripcion] = turnoVariable.Codigo;
                                    filaNueva[cancha.Descripcion] = "Reservado - " + nombreReserva;
                                }
                            }
                        }
                        else
                        {
                            filaNueva["codigoTurno" + cancha.Descripcion] = turnoFijo.Codigo;
                            filaNueva[cancha.Descripcion] = "Reservado - " + turnoFijo.Responsable;
                        }
                    }
                    tablaTurnos.Rows.Add(filaNueva);
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

        public static DataTable RecuperarTurnoPorNombreCanchayHora(int codigoComplejo, string nombreCancha, DateTime FechaHoraDesde)
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

                tablaTurnos.Columns.Add("codigoUsuarioApp", typeof(string));
                tablaTurnos.Columns.Add("nombreUsuarioApp", typeof(string));
                tablaTurnos.Columns.Add("apellidoUsuarioApp", typeof(string));
                tablaTurnos.Columns.Add("telefonoUsuarioApp", typeof(string));

                Cancha cancha = CatalogoGenerico<Cancha>.RecuperarPor(x => x.Complejo.Codigo == codigoComplejo && x.Descripcion == nombreCancha, nhSesion);

                TurnoVariable tv = CatalogoGenerico<TurnoVariable>.RecuperarPor(x => x.Cancha.Codigo == cancha.Codigo && x.FechaHoraDesde == FechaHoraDesde, nhSesion);

                if (tablaTurnos != null)
                {
                    tablaTurnos.Rows.Add(new object[] { tv.FechaHoraDesde.Hour, tv.FechaHoraHasta.Hour, cancha.Codigo, cancha.Descripcion, cancha.TipoCancha.Codigo, cancha.TipoCancha.Descripcion,
                        cancha.Complejo.Codigo, cancha.Complejo.Descripcion, cancha.PrecioTarde, 
                        cancha.Complejo.Direccion, tv.UsuarioApp.Codigo, tv.UsuarioApp.Nombre,  tv.UsuarioApp.Apellido, tv.UsuarioApp.Telefono });
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
    }
}
