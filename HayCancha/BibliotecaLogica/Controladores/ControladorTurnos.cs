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
                tablaTurnos.Columns.Add("horaDesde");
                tablaTurnos.Columns.Add("horaHasta");
                tablaTurnos.Columns.Add("codigoCancha");
                tablaTurnos.Columns.Add("descripcionCancha");
                tablaTurnos.Columns.Add("codigoTipoCancha");
                tablaTurnos.Columns.Add("descripcionTipoCancha");
                tablaTurnos.Columns.Add("codigoComplejo");
                tablaTurnos.Columns.Add("descripcionComplejo");
                tablaTurnos.Columns.Add("imagenComplejo");
                tablaTurnos.Columns.Add("isFavorito");
                tablaTurnos.Columns.Add("precio");
                tablaTurnos.Columns.Add("direccion");
                tablaTurnos.Columns.Add("puntajeComplejo");
                tablaTurnos.Columns.Add("latitud");
                tablaTurnos.Columns.Add("longitud");

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
    }
}
