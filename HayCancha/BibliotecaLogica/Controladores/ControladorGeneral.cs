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
    }
}
