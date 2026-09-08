using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_Kardex.DataAccessLayer;

namespace Solution_Framework_Kardex.BussinessLogicLayer
{
	public class DataAccessLayerSQLDataAccessLayer : DataAccessLayerDataAccessLayer
	{
        #region CONSTANTES
        private string SP__KD_FERIADOS = "sp_kd_feriados";
        private string SP__KD_CERTIFICADO_SIPPASE = "sp_kd_certificado_sippase";
        private string SP__KD_FINIQUITO = "sp_kd_finiquito";
		private string SP__KD_ASIGNACION_VACACIONES = "sp_kd_asignacion_vacaciones";
		private string SP__KD_RESPUESTA_COMBO = "sp_kd_respuesta_combo";
        private string sp_poais = "SP_mdp_Poais";
        private string sp_periodo = "sp_periodo";
        #endregion

        //INTERFACES
        #region _KD_FERIADOS
        public override bool Adicionar__kd_feriados(cls_kd_feriados _kd_feriados)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FERIADOS);

                CNXSIGRH3.AddInParameter(icom, "p_fe_fecha", DbType.DateTime, _kd_feriados.fe_fecha);
                CNXSIGRH3.AddInParameter(icom, "p_fe_descripcion", DbType.String, _kd_feriados.fe_descripcion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar__kd_feriados(cls_kd_feriados _kd_feriados)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FERIADOS);

                CNXSIGRH3.AddInParameter(icom, "p_fe_id", DbType.Int32, _kd_feriados.fe_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Actualizar__kd_feriados(cls_kd_feriados _kd_feriados)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FERIADOS);

                CNXSIGRH3.AddInParameter(icom, "p_fe_id", DbType.Int32, _kd_feriados.fe_id);
                CNXSIGRH3.AddInParameter(icom, "p_fe_fecha", DbType.DateTime, _kd_feriados.fe_fecha);
                CNXSIGRH3.AddInParameter(icom, "p_fe_descripcion", DbType.String, _kd_feriados.fe_descripcion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId__kd_feriados(cls_kd_feriados _kd_feriados)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FERIADOS);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                _kd_feriados.fe_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fe_id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerRegistro__kd_feriados(cls_kd_feriados _kd_feriados)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FERIADOS);

                CNXSIGRH3.AddInParameter(icom, "p_fe_id", DbType.Int32, _kd_feriados.fe_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["fe_id"] != DBNull.Value && ds.Tables[0].Rows[0]["fe_id"].ToString().Trim() != "") { _kd_feriados.fe_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fe_id"]); }
                //if (ds.Tables[0].Rows[0]["fe_fecha"] != DBNull.Value && ds.Tables[0].Rows[0]["fe_fecha"].ToString().Trim() != "") { _kd_feriados.fe_fecha = Convert.ToDateTime(ds.Tables[0].Rows[0]["fe_fecha"]); }
                if (ds.Tables[0].Rows[0]["fe_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["fe_descripcion"].ToString().Trim() != "") { _kd_feriados.fe_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["fe_descripcion"]); }
                if (ds.Tables[0].Rows[0]["fe_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["fe_estado"].ToString().Trim() != "") { _kd_feriados.fe_estado = Convert.ToString(ds.Tables[0].Rows[0]["fe_estado"]); }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaGrilla__kd_feriados(string fe_id,
                        string fe_fecha,
                        string fe_descripcion,
                        string fe_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FERIADOS);

                if (fe_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fe_id", DbType.Int32, Convert.ToInt32(fe_id)); }
                if (fe_fecha.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fe_fecha", DbType.DateTime, Convert.ToDateTime(fe_fecha)); }
                if (fe_descripcion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fe_descripcion", DbType.String, Convert.ToString(fe_descripcion)); }
                if (fe_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fe_estado", DbType.String, Convert.ToString(fe_estado)); }

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo__kd_feriados()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FERIADOS);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // (JQC)

        public override DataSet ObtenerGrillaFeriados(cls_kd_feriados _kd_feriados)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FERIADOS);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFeriadoX(cls_kd_feriados _kd_feriados)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FERIADOS);
                CNXSIGRH3.AddInParameter(icom, "p_fe_id", DbType.Int32, _kd_feriados.fe_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _KD_CERTIFICADO_SIPPASE
        public override int Adicionar__kd_certificado_sippase(cls_kd_certificado_sippase _kd_certificado_sippase)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_CERTIFICADO_SIPPASE);
                CNXSIGRH3.AddInParameter(icom, "p_sip_id", DbType.Int32, _kd_certificado_sippase.sip_per_id);   
                CNXSIGRH3.AddInParameter(icom, "p_sip_per_id", DbType.Int32, _kd_certificado_sippase.sip_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_sip_descripcion_cert", DbType.String, _kd_certificado_sippase.sip_descripcion_cert);
                CNXSIGRH3.AddInParameter(icom, "p_sip_fecha_cert", DbType.DateTime, _kd_certificado_sippase.sip_fecha_cert);
                CNXSIGRH3.AddInParameter(icom, "p_sip_fecha_pres", DbType.DateTime, _kd_certificado_sippase.sip_fecha_pres);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.AddInParameter(icom, "p_sip_estado", DbType.String, "V");
                //int id = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom).ToString());
                
                return CNXSIGRH3.ExecuteNonQuery(icom);
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__kd_certificado_sippase(cls_kd_certificado_sippase _kd_certificado_sippase)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_CERTIFICADO_SIPPASE);
                CNXSIGRH3.AddInParameter(icom, "p_sip_id", DbType.Int32, _kd_certificado_sippase.sip_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__kd_certificado_sippase(cls_kd_certificado_sippase _kd_certificado_sippase)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_CERTIFICADO_SIPPASE);
                CNXSIGRH3.AddInParameter(icom, "p_sip_id", DbType.Int32, _kd_certificado_sippase.sip_id);
                CNXSIGRH3.AddInParameter(icom, "p_sip_per_id", DbType.Int32, _kd_certificado_sippase.sip_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_sip_descripcion_cert", DbType.String, _kd_certificado_sippase.sip_descripcion_cert);
                CNXSIGRH3.AddInParameter(icom, "p_sip_fecha_cert", DbType.DateTime, _kd_certificado_sippase.sip_fecha_cert);
                CNXSIGRH3.AddInParameter(icom, "p_sip_fecha_pres", DbType.DateTime, _kd_certificado_sippase.sip_fecha_pres);
                CNXSIGRH3.AddInParameter(icom, "p_sip_estado", DbType.String, _kd_certificado_sippase.sip_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__kd_certificado_sippase(cls_kd_certificado_sippase _kd_certificado_sippase)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_CERTIFICADO_SIPPASE);
                CNXSIGRH3.AddInParameter(icom, "p_sip_id", DbType.Int32, _kd_certificado_sippase.sip_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__kd_certificado_sippase(
            string sip_id,
            string sip_per_id,
            string sip_descripcion_cert,
            string sip_fecha_cert,
            string sip_fecha_pres,
            string sip_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_CERTIFICADO_SIPPASE);

                //CNXSIGRH3.AddInParameter(icom, "sip_id", DbType.Int32, Convert.ToInt32(sip_id)); 
                 CNXSIGRH3.AddInParameter(icom, "p_sip_per_id", DbType.Int32, Convert.ToInt32(sip_per_id)); 
               //  CNXSIGRH3.AddInParameter(icom, "sip_descripcion_cert", DbType.String, Convert.ToString(sip_descripcion_cert)); 
               //  CNXSIGRH3.AddInParameter(icom, "sip_fecha_cert", DbType.DateTime, Convert.ToDateTime(sip_fecha_cert)); 
               //CNXSIGRH3.AddInParameter(icom, "sip_fecha_pres", DbType.DateTime, Convert.ToDateTime(sip_fecha_pres)); 
               CNXSIGRH3.AddInParameter(icom, "p_sip_estado", DbType.String, Convert.ToString(sip_estado)); 
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__kd_certificado_sippase()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_CERTIFICADO_SIPPASE);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _KD_FINIQUITO
        public override string TiempoServicio(string fecha_ingreso, string accion)
        {
            try
            {
                string resultado = "";
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_kd_tiempo_servicio");

                CNXSIGRH3.AddInParameter(icom, "fecha", DbType.DateTime, Convert.ToDateTime( fecha_ingreso));
                //CNXSIGRH3.AddInParameter(icom, "hoy", DbType.DateTime, Convert.ToDateTime(DateTime.Now.ToString()));
                CNXSIGRH3.AddInParameter(icom, "accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (accion == "anio")
                        resultado = ds.Tables[0].Rows[0]["anio"].ToString();
                    if (accion == "mes")
                        resultado = ds.Tables[0].Rows[0]["mes"].ToString();
                    if (accion == "dia")
                        resultado = ds.Tables[0].Rows[0]["dia"].ToString();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override int Adicionar_FechaIngreso(cls_kd_finiquito2 _kd_finiquito2)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

                CNXSIGRH3.AddInParameter(icom, "p_Fi_per_id", DbType.Int32, _kd_finiquito2.Fi_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_as_id", DbType.Int32, _kd_finiquito2.Fi_as_id);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_FechaIngerso", DbType.DateTime, _kd_finiquito2.Fi_FechaIngerso);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_anioServicio", DbType.Int32, _kd_finiquito2.Fi_anioServicio);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_MesServicio", DbType.Int32, _kd_finiquito2.Fi_MesServicio);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_DiasServicio", DbType.Int32, _kd_finiquito2.Fi_DiasServicio);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_estado", DbType.String, _kd_finiquito2.Fi_estado);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_FechaRetiro", DbType.DateTime, _kd_finiquito2.Fi_FechaRetiro);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_MotivoFiniquito", DbType.String, _kd_finiquito2.Fi_MotivoFiniquito);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_usuario", DbType.Int32, _kd_finiquito2.Fi_usuario);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet CalcularGestiones(string fecha_baja)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_kd_tiempo_servicio");

                CNXSIGRH3.AddInParameter(icom, "fecha", DbType.DateTime, Convert.ToDateTime(fecha_baja));
                CNXSIGRH3.AddInParameter(icom, "accion", DbType.String, "C2");
                return CNXSIGRH3.ExecuteDataSet(icom);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet PromedioRemuneracion(double rem1, double rem2, double rem3, int ANIO, int MES, int DIA)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

                CNXSIGRH3.AddInParameter(icom, "p_Fi_remuneracion1", DbType.Double, rem1);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_remuneracion2", DbType.Double, rem2);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_remuneracion3", DbType.Double, rem3);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_anioServicio", DbType.Int32, ANIO);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_MesServicio", DbType.Int32, MES);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_DiasServicio", DbType.Int32, DIA);
                CNXSIGRH3.AddInParameter(icom, "P_accion", DbType.String, "C3");
                return CNXSIGRH3.ExecuteDataSet(icom);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override int ActualizarTotalesRemuneracionFiniquito(double rem1, double rem2, double rem3, int p_Fi_id, double ba1, double ba2, double ba3, double bf1, double bf2, double bf3)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

                CNXSIGRH3.AddInParameter(icom, "p_Fi_remuneracion1", DbType.Double, rem1);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_remuneracion2", DbType.Double, rem2);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_remuneracion3", DbType.Double, rem3);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_id", DbType.Int32, p_Fi_id);

                CNXSIGRH3.AddInParameter(icom, "p_Fi_bono_a1", DbType.Double, ba1);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_bono_a2", DbType.Double, ba2);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_bono_a3", DbType.Double, ba3);

                CNXSIGRH3.AddInParameter(icom, "p_Fi_bono_f1", DbType.Double, bf1);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_bono_f2", DbType.Double, bf2);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_bono_f3", DbType.Double, bf3);


                CNXSIGRH3.AddInParameter(icom, "P_accion", DbType.String, "U");
                return CNXSIGRH3.ExecuteNonQuery(icom);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerRegistro(int per_id, int as_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

                CNXSIGRH3.AddInParameter(icom, "p_Fi_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_as_id", DbType.Int32, as_id);
                CNXSIGRH3.AddInParameter(icom, "P_accion", DbType.String, "C8");
                return CNXSIGRH3.ExecuteDataSet(icom);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override double CalcularDesahucio(int fi_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

                CNXSIGRH3.AddInParameter(icom, "p_Fi_id", DbType.Int32, fi_id);
                CNXSIGRH3.AddInParameter(icom, "P_accion", DbType.String, "C7");
                return Convert.ToDouble(CNXSIGRH3.ExecuteDataSet(icom).Tables[0].Rows[0][0].ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override double CalcularVacacionesMonto(int fi_id, int meses, int dias, int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_per_id", DbType.Int32, per_id);

                CNXSIGRH3.AddInParameter(icom, "p_Fi_id", DbType.Int32, fi_id);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_MesServicio", DbType.Int32, meses);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_DiasServicio", DbType.Int32, dias);
                CNXSIGRH3.AddInParameter(icom, "P_accion", DbType.String, "C5");

                DataSet ds= CNXSIGRH3.ExecuteDataSet(icom);
                return Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override double CalcularVacacionesDias(int fi_id, int meses, int dias, int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_per_id", DbType.Int32, per_id);

                CNXSIGRH3.AddInParameter(icom, "p_Fi_id", DbType.Int32, fi_id);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_MesServicio", DbType.Int32, meses);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_DiasServicio", DbType.Int32, dias);
                CNXSIGRH3.AddInParameter(icom, "P_accion", DbType.String, "C4");

                return Convert.ToDouble(CNXSIGRH3.ExecuteDataSet(icom).Tables[0].Rows[0][0].ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override double CalcularAguinaldo(int fi_id, string fecha_baja)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

                CNXSIGRH3.AddInParameter(icom, "p_Fi_id", DbType.Int32, fi_id);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_FechaRetiro", DbType.DateTime, Convert.ToDateTime(fecha_baja));
                CNXSIGRH3.AddInParameter(icom, "P_accion", DbType.String, "C6");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override int ActualizarInfoAdicional(int fi_id, int nro_finiquito, int cod_finiquito, string motivo, double liquido_pagable, string doc_autoriza, string fecha_doc, string estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

                CNXSIGRH3.AddInParameter(icom, "p_Fi_id", DbType.Int32, fi_id);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_Nro_Finiquito", DbType.Int32, nro_finiquito);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_Codigo_Finiquito", DbType.Int32, cod_finiquito);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_MotivoFiniquito", DbType.String, motivo);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_TotalPagado", DbType.Double, liquido_pagable);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_doc_autoriza", DbType.String, doc_autoriza);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_fecha_documento", DbType.DateTime, fecha_doc);
                CNXSIGRH3.AddInParameter(icom, "p_Fi_estado", DbType.String, estado);

                CNXSIGRH3.AddInParameter(icom, "P_accion", DbType.String, "U1");
                return CNXSIGRH3.ExecuteNonQuery(icom);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //      public override DataSet Adicionar__kd_finiquito(cls_kd_finiquito _kd_finiquito)
        //{
        //	try
        //	{
        //		DbCommand icom = null;
        //		icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

        //		CNXSIGRH3.AddInParameter(icom, "p_fin_per_id", DbType.Int32, _kd_finiquito.fin_per_id);
        //		CNXSIGRH3.AddInParameter(icom, "p_fin_tiempo_servicio", DbType.String, _kd_finiquito.fin_tiempo_servicio);
        //		CNXSIGRH3.AddInParameter(icom, "p_fin_estado", DbType.String, _kd_finiquito.fin_estado);

        //		CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
        //              DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
        //              return ds;
        //          }
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //}

        //public override bool Eliminar__kd_finiquito(cls_kd_finiquito _kd_finiquito)
        //{
        //	try
        //	{
        //		DbCommand icom = null;
        //		icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

        //		CNXSIGRH3.AddInParameter(icom, "p_fin_id", DbType.Int32, _kd_finiquito.fin_id);

        //		CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
        //		CNXSIGRH3.ExecuteNonQuery(icom);
        //		return true;
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //}

        //public override bool Actualizar__kd_finiquito(cls_kd_finiquito _kd_finiquito)
        //{
        //	try
        //	{
        //		DbCommand icom = null;
        //		icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

        //		CNXSIGRH3.AddInParameter(icom, "p_fin_id", DbType.Int32, _kd_finiquito.fin_id);
        //		CNXSIGRH3.AddInParameter(icom, "p_fin_tiempo_servicio", DbType.String, _kd_finiquito.fin_tiempo_servicio);
        //		CNXSIGRH3.AddInParameter(icom, "p_fin_liquido_pagable", DbType.Double, _kd_finiquito.fin_liquido_pagable);

        //		CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
        //		CNXSIGRH3.ExecuteNonQuery(icom);
        //		return true;
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //}

        //public override bool ObtenerId__kd_finiquito(cls_kd_finiquito _kd_finiquito)
        //{
        //	try
        //	{
        //		DbCommand icom = null;
        //		icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

        //		CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
        //		DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

        //		_kd_finiquito.fin_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fin_id"]);

        //		return true;
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //}

        //public override bool ObtenerRegistro__kd_finiquito(cls_kd_finiquito _kd_finiquito)
        //{
        //	try
        //	{
        //		DbCommand icom = null;
        //		icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

        //		CNXSIGRH3.AddInParameter(icom, "p_fin_id", DbType.Int32, _kd_finiquito.fin_id);

        //		CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
        //		DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

        //		if (ds.Tables[0].Rows[0]["fin_id"] != DBNull.Value && ds.Tables[0].Rows[0]["fin_id"].ToString().Trim() != "") { _kd_finiquito.fin_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fin_id"]); }
        //		if (ds.Tables[0].Rows[0]["fin_tiempo_servicio"] != DBNull.Value && ds.Tables[0].Rows[0]["fin_tiempo_servicio"].ToString().Trim() != "") { _kd_finiquito.fin_tiempo_servicio = Convert.ToString(ds.Tables[0].Rows[0]["fin_tiempo_servicio"]); }
        //		if (ds.Tables[0].Rows[0]["fin_liquido_pagable"] != DBNull.Value && ds.Tables[0].Rows[0]["fin_liquido_pagable"].ToString().Trim() != "") { _kd_finiquito.fin_liquido_pagable = Convert.ToDouble(ds.Tables[0].Rows[0]["fin_liquido_pagable"]); }
        //		return true;
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //}

        //public override DataSet ObtenerTablaGrilla__kd_finiquito(string fin_id, 
        //				string fin_tiempo_servicio, 
        //				string fin_liquido_pagable)
        //{
        //	try
        //	{
        //		DbCommand icom = null;
        //		icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

        //		if (fin_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fin_id", DbType.Int32, Convert.ToInt32(fin_id)); }
        //		if (fin_tiempo_servicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fin_tiempo_servicio", DbType.String, Convert.ToString(fin_tiempo_servicio)); }
        //		if (fin_liquido_pagable.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fin_liquido_pagable", DbType.Double, Convert.ToDouble(fin_liquido_pagable)); }

        //		CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
        //		DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
        //		return ds;
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //}

        //public override DataSet ObtenerTablaCombo__kd_finiquito()
        //{
        //	try
        //	{
        //		DbCommand icom = null;
        //		icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

        //		CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
        //		DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
        //		return ds;
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //}
        //public override DataSet ObtenerAsignaciones(cls_kd_finiquito _kd_finiquito)
        //{
        //    try
        //    {
        //        DbCommand icom = null;
        //        icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_FINIQUITO);

        //        CNXSIGRH3.AddInParameter(icom, "p_fin_per_id", DbType.Int32, _kd_finiquito.fin_per_id);
        //        CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
        //        //CNXSIGRH3.AddInParameter(icom, "p_Fi_per_id", DbType.Int32, _kd_finiquito.fin_per_id);
        //        //CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");

        //        DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion

        #region _KD_ASIGNACION_VACACIONES
        public override bool Adicionar__kd_asignacion_vacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

				CNXSIGRH3.AddInParameter(icom, "p_va_id", DbType.Int32, _kd_asignacion_vacaciones.va_id);
				CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_va_gestion", DbType.Int32, _kd_asignacion_vacaciones.va_gestion);
				CNXSIGRH3.AddInParameter(icom, "p_va_dias_ley", DbType.Int32, _kd_asignacion_vacaciones.va_dias_ley);
				CNXSIGRH3.AddInParameter(icom, "p_va_dias_restantes", DbType.Double, _kd_asignacion_vacaciones.va_dias_restantes);
				CNXSIGRH3.AddInParameter(icom, "p_va_horas_restantes", DbType.Int32, _kd_asignacion_vacaciones.va_horas_restantes);
				CNXSIGRH3.AddInParameter(icom, "p_va_fecha_ingreso_r", DbType.DateTime, _kd_asignacion_vacaciones.va_fecha_ingreso_r);
				CNXSIGRH3.AddInParameter(icom, "p_va_anio", DbType.Int32, _kd_asignacion_vacaciones.va_anio);
				CNXSIGRH3.AddInParameter(icom, "p_va_fecha_habilitacion_prescrito", DbType.DateTime, _kd_asignacion_vacaciones.va_fecha_habilitacion_prescrito);
				CNXSIGRH3.AddInParameter(icom, "p_va_autorizado_por", DbType.String, _kd_asignacion_vacaciones.va_autorizado_por);
				CNXSIGRH3.AddInParameter(icom, "p_va_nro_documento", DbType.String, _kd_asignacion_vacaciones.va_nro_documento);
				CNXSIGRH3.AddInParameter(icom, "p_va_observaciones", DbType.String, _kd_asignacion_vacaciones.va_observaciones);
				CNXSIGRH3.AddInParameter(icom, "p_va_fecha_registro_prescrito", DbType.DateTime, _kd_asignacion_vacaciones.va_fecha_registro_prescrito);
				CNXSIGRH3.AddInParameter(icom, "p_va_fecha_validez_prescrito", DbType.DateTime, _kd_asignacion_vacaciones.va_fecha_validez_prescrito);
				CNXSIGRH3.AddInParameter(icom, "p_va_estado", DbType.String, _kd_asignacion_vacaciones.va_estado);
				CNXSIGRH3.AddInParameter(icom, "p_va_usuario_creacion", DbType.Int32, _kd_asignacion_vacaciones.va_usuario_creacion);
				CNXSIGRH3.AddInParameter(icom, "p_va_fecha_creacion", DbType.DateTime, _kd_asignacion_vacaciones.va_fecha_creacion);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Eliminar__kd_asignacion_vacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

				CNXSIGRH3.AddInParameter(icom, "p_va_id", DbType.Int32, _kd_asignacion_vacaciones.va_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Actualizar__kd_asignacion_vacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

				CNXSIGRH3.AddInParameter(icom, "p_va_id", DbType.Int32, _kd_asignacion_vacaciones.va_id);
				CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_va_gestion", DbType.Int32, _kd_asignacion_vacaciones.va_gestion);
				CNXSIGRH3.AddInParameter(icom, "p_va_dias_ley", DbType.Int32, _kd_asignacion_vacaciones.va_dias_ley);
				CNXSIGRH3.AddInParameter(icom, "p_va_dias_restantes", DbType.Int32, _kd_asignacion_vacaciones.va_dias_restantes);
				CNXSIGRH3.AddInParameter(icom, "p_va_horas_restantes", DbType.Int32, _kd_asignacion_vacaciones.va_horas_restantes);
				CNXSIGRH3.AddInParameter(icom, "p_va_fecha_ingreso_r", DbType.DateTime, _kd_asignacion_vacaciones.va_fecha_ingreso_r);
				CNXSIGRH3.AddInParameter(icom, "p_va_anio", DbType.Int32, _kd_asignacion_vacaciones.va_anio);
				CNXSIGRH3.AddInParameter(icom, "p_va_fecha_habilitacion_prescrito", DbType.DateTime, _kd_asignacion_vacaciones.va_fecha_habilitacion_prescrito);
				CNXSIGRH3.AddInParameter(icom, "p_va_autorizado_por", DbType.String, _kd_asignacion_vacaciones.va_autorizado_por);
				CNXSIGRH3.AddInParameter(icom, "p_va_nro_documento", DbType.String, _kd_asignacion_vacaciones.va_nro_documento);
				CNXSIGRH3.AddInParameter(icom, "p_va_observaciones", DbType.String, _kd_asignacion_vacaciones.va_observaciones);
				CNXSIGRH3.AddInParameter(icom, "p_va_fecha_registro_prescrito", DbType.DateTime, _kd_asignacion_vacaciones.va_fecha_registro_prescrito);
				CNXSIGRH3.AddInParameter(icom, "p_va_fecha_validez_prescrito", DbType.DateTime, _kd_asignacion_vacaciones.va_fecha_validez_prescrito);
				CNXSIGRH3.AddInParameter(icom, "p_va_estado", DbType.String, _kd_asignacion_vacaciones.va_estado);
				CNXSIGRH3.AddInParameter(icom, "p_va_usuario_creacion", DbType.Int32, _kd_asignacion_vacaciones.va_usuario_creacion);
				CNXSIGRH3.AddInParameter(icom, "p_va_fecha_creacion", DbType.DateTime, _kd_asignacion_vacaciones.va_fecha_creacion);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerId__kd_asignacion_vacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_kd_asignacion_vacaciones.va_id = Convert.ToInt32(ds.Tables[0].Rows[0]["va_id"]);
		
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerRegistro__kd_asignacion_vacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

				CNXSIGRH3.AddInParameter(icom, "p_va_id", DbType.Int32, _kd_asignacion_vacaciones.va_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				if (ds.Tables[0].Rows[0]["va_id"] != DBNull.Value && ds.Tables[0].Rows[0]["va_id"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_id = Convert.ToInt32(ds.Tables[0].Rows[0]["va_id"]); }
				if (ds.Tables[0].Rows[0]["va_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["va_per_id"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["va_per_id"]); }
				if (ds.Tables[0].Rows[0]["va_gestion"] != DBNull.Value && ds.Tables[0].Rows[0]["va_gestion"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_gestion = Convert.ToString(ds.Tables[0].Rows[0]["va_gestion"]); }
				if (ds.Tables[0].Rows[0]["va_dias_ley"] != DBNull.Value && ds.Tables[0].Rows[0]["va_dias_ley"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_dias_ley = Convert.ToInt32(ds.Tables[0].Rows[0]["va_dias_ley"]); }
				if (ds.Tables[0].Rows[0]["va_dias_restantes"] != DBNull.Value && ds.Tables[0].Rows[0]["va_dias_restantes"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_dias_restantes = Convert.ToInt32(ds.Tables[0].Rows[0]["va_dias_restantes"]); }
				if (ds.Tables[0].Rows[0]["va_horas_restantes"] != DBNull.Value && ds.Tables[0].Rows[0]["va_horas_restantes"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_horas_restantes = Convert.ToInt32(ds.Tables[0].Rows[0]["va_horas_restantes"]); }
				if (ds.Tables[0].Rows[0]["va_fecha_ingreso_r"] != DBNull.Value && ds.Tables[0].Rows[0]["va_fecha_ingreso_r"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_fecha_ingreso_r = Convert.ToDateTime(ds.Tables[0].Rows[0]["va_fecha_ingreso_r"]); }
				if (ds.Tables[0].Rows[0]["va_anio"] != DBNull.Value && ds.Tables[0].Rows[0]["va_anio"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_anio = Convert.ToInt32(ds.Tables[0].Rows[0]["va_anio"]); }
				if (ds.Tables[0].Rows[0]["va_fecha_habilitacion_prescrito"] != DBNull.Value && ds.Tables[0].Rows[0]["va_fecha_habilitacion_prescrito"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_fecha_habilitacion_prescrito = Convert.ToDateTime(ds.Tables[0].Rows[0]["va_fecha_habilitacion_prescrito"]); }
				if (ds.Tables[0].Rows[0]["va_autorizado_por"] != DBNull.Value && ds.Tables[0].Rows[0]["va_autorizado_por"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_autorizado_por = Convert.ToString(ds.Tables[0].Rows[0]["va_autorizado_por"]); }
				if (ds.Tables[0].Rows[0]["va_nro_documento"] != DBNull.Value && ds.Tables[0].Rows[0]["va_nro_documento"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_nro_documento = Convert.ToString(ds.Tables[0].Rows[0]["va_nro_documento"]); }
				if (ds.Tables[0].Rows[0]["va_observaciones"] != DBNull.Value && ds.Tables[0].Rows[0]["va_observaciones"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_observaciones = Convert.ToString(ds.Tables[0].Rows[0]["va_observaciones"]); }
				if (ds.Tables[0].Rows[0]["va_fecha_registro_prescrito"] != DBNull.Value && ds.Tables[0].Rows[0]["va_fecha_registro_prescrito"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_fecha_registro_prescrito = Convert.ToDateTime(ds.Tables[0].Rows[0]["va_fecha_registro_prescrito"]); }
				if (ds.Tables[0].Rows[0]["va_fecha_validez_prescrito"] != DBNull.Value && ds.Tables[0].Rows[0]["va_fecha_validez_prescrito"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_fecha_validez_prescrito = Convert.ToDateTime(ds.Tables[0].Rows[0]["va_fecha_validez_prescrito"]); }
				if (ds.Tables[0].Rows[0]["va_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["va_estado"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_estado = Convert.ToString(ds.Tables[0].Rows[0]["va_estado"]); }
				if (ds.Tables[0].Rows[0]["va_usuario_creacion"] != DBNull.Value && ds.Tables[0].Rows[0]["va_usuario_creacion"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_usuario_creacion = Convert.ToInt32(ds.Tables[0].Rows[0]["va_usuario_creacion"]); }
				if (ds.Tables[0].Rows[0]["va_fecha_creacion"] != DBNull.Value && ds.Tables[0].Rows[0]["va_fecha_creacion"].ToString().Trim() != "") { _kd_asignacion_vacaciones.va_fecha_creacion = Convert.ToDateTime(ds.Tables[0].Rows[0]["va_fecha_creacion"]); }
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaGrilla__kd_asignacion_vacaciones(string va_id, 
						string va_per_id, 
						string va_gestion, 
						string va_dias_ley, 
						string va_dias_restantes, 
						string va_horas_restantes, 
						string va_fecha_ingreso_r, 
						string va_anio, 
						string va_fecha_habilitacion_prescrito, 
						string va_autorizado_por, 
						string va_nro_documento, 
						string va_observaciones, 
						string va_fecha_registro_prescrito, 
						string va_fecha_validez_prescrito, 
						string va_estado, 
						string va_usuario_creacion, 
						string va_fecha_creacion)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

				if (va_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_id", DbType.Int32, Convert.ToInt32(va_id)); }
				if (va_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, Convert.ToInt32(va_per_id)); }
				if (va_gestion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_gestion", DbType.Int32, Convert.ToInt32(va_gestion)); }
				if (va_dias_ley.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_dias_ley", DbType.Int32, Convert.ToInt32(va_dias_ley)); }
				if (va_dias_restantes.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_dias_restantes", DbType.Double, Convert.ToDouble(va_dias_restantes)); }
				if (va_horas_restantes.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_horas_restantes", DbType.Int32, Convert.ToInt32(va_horas_restantes)); }
				if (va_fecha_ingreso_r.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_fecha_ingreso_r", DbType.DateTime, Convert.ToDateTime(va_fecha_ingreso_r)); }
				if (va_anio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_anio", DbType.Int32, Convert.ToInt32(va_anio)); }
				if (va_fecha_habilitacion_prescrito.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_fecha_habilitacion_prescrito", DbType.DateTime, Convert.ToDateTime(va_fecha_habilitacion_prescrito)); }
				if (va_autorizado_por.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_autorizado_por", DbType.String, Convert.ToString(va_autorizado_por)); }
				if (va_nro_documento.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_nro_documento", DbType.String, Convert.ToString(va_nro_documento)); }
				if (va_observaciones.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_observaciones", DbType.String, Convert.ToString(va_observaciones)); }
				if (va_fecha_registro_prescrito.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_fecha_registro_prescrito", DbType.DateTime, Convert.ToDateTime(va_fecha_registro_prescrito)); }
				if (va_fecha_validez_prescrito.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_fecha_validez_prescrito", DbType.DateTime, Convert.ToDateTime(va_fecha_validez_prescrito)); }
				if (va_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_estado", DbType.String, Convert.ToString(va_estado)); }
				if (va_usuario_creacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_usuario_creacion", DbType.Int32, Convert.ToInt32(va_usuario_creacion)); }
				if (va_fecha_creacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_va_fecha_creacion", DbType.DateTime, Convert.ToDateTime(va_fecha_creacion)); }
 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__kd_asignacion_vacaciones()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        //(JQC)
        public override DataSet obtenerGrillaAsigVacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerDatosFuncionarioP(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _kd_asignacion_vacaciones.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet obtenerGrillaHistoricoVacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerVacacionAnualX(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_vac_id", DbType.Int32, _kd_asignacion_vacaciones.vac_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C21");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet listaFiltradoTipoLicencia()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int AdicionarVacacionLicencia(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones, int id_autoriza)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_vac_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_vac_a_partir", DbType.DateTime, Convert.ToDateTime(_kd_asignacion_vacaciones.vac_a_partir));
                CNXSIGRH3.AddInParameter(icom, "p_vac_hasta", DbType.DateTime, Convert.ToDateTime(_kd_asignacion_vacaciones.vac_hasta));
                CNXSIGRH3.AddInParameter(icom, "p_vac_nro_dias_vacacion", DbType.String, _kd_asignacion_vacaciones.vac_nro_dias_vacacion);
                CNXSIGRH3.AddInParameter(icom, "p_vac_va_id", DbType.String, _kd_asignacion_vacaciones.vac_va_id);
                CNXSIGRH3.AddInParameter(icom, "p_vac_observacion", DbType.String, _kd_asignacion_vacaciones.vac_observacion);
                CNXSIGRH3.AddInParameter(icom, "p_vac_correlativo", DbType.Int32, _kd_asignacion_vacaciones.vac_correlativo);
                CNXSIGRH3.AddInParameter(icom, "p_vac_usuario_creacion", DbType.Int32, _kd_asignacion_vacaciones.vac_usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_vac_per_id_autoriza", DbType.Int32, id_autoriza);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A1");
                int id = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom).ToString());

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerSumaTotalDiasV(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerCorrelativo()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerNroDiasVacacionDisp(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_vac_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C17");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerNroHorasVacacionDisp(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_vac_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C18");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarSaldoDias(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_id_actual", DbType.Int32, _kd_asignacion_vacaciones.va_id);
                CNXSIGRH3.AddInParameter(icom, "p_va_dias_restantes", DbType.Double, _kd_asignacion_vacaciones.va_dias_restantes);
                CNXSIGRH3.AddInParameter(icom, "p_va_estado", DbType.String, _kd_asignacion_vacaciones.va_estado);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaHistoricoLicenciaVac(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerLicenciaCargoVacacionX(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_lj_id", DbType.Int32, _kd_asignacion_vacaciones.lj_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C22");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarVacacion(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_vac_motivo_anulado", DbType.String, _kd_asignacion_vacaciones.vac_motivo_anulado);
                CNXSIGRH3.AddInParameter(icom, "p_vac_id", DbType.Int32, _kd_asignacion_vacaciones.vac_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet obtenerGrillaHistoricoDocumentoCAS(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet listaFiltradoTipoCas()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool AdicionarRegistroCas(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_vac_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_cs_tipo_cas", DbType.Int32, _kd_asignacion_vacaciones.cs_tipo_cas);
                CNXSIGRH3.AddInParameter(icom, "p_cs_nro_cas", DbType.String, _kd_asignacion_vacaciones.cs_nro_cas);
                CNXSIGRH3.AddInParameter(icom, "p_cs_fecha_cas", DbType.String, _kd_asignacion_vacaciones.cs_fecha_cas);
                CNXSIGRH3.AddInParameter(icom, "p_cs_anios_calif", DbType.Int32, _kd_asignacion_vacaciones.cs_anios_calif);
                CNXSIGRH3.AddInParameter(icom, "p_cs_meses_calif", DbType.Int32, _kd_asignacion_vacaciones.cs_meses_calif);
                CNXSIGRH3.AddInParameter(icom, "p_cs_dias_calif", DbType.Int32, _kd_asignacion_vacaciones.cs_dias_calif);
                CNXSIGRH3.AddInParameter(icom, "p_cs_usuario_creacion", DbType.Int32, _kd_asignacion_vacaciones.vac_usuario_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarRegistroCas(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_cs_id", DbType.Int32, _kd_asignacion_vacaciones.cs_id);
                //CNXSIGRH3.AddInParameter(icom, "p_va_estado", DbType.String, _kd_asignacion_vacaciones.vac_estado);
                CNXSIGRH3.AddInParameter(icom, "p_cs_usuario_creacion", DbType.Int32, _kd_asignacion_vacaciones.vac_usuario_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarSaldoHoras(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_id_actual", DbType.Int32, _kd_asignacion_vacaciones.va_id);
                CNXSIGRH3.AddInParameter(icom, "p_va_horas_restantes", DbType.String, _kd_asignacion_vacaciones.va_horas_restantes);
                //CNXSIGRH3.AddInParameter(icom, "p_va_estado", DbType.String, _kd_asignacion_vacaciones.va_estado);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarSaldoDiasHoras(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_id_actual", DbType.Int32, _kd_asignacion_vacaciones.va_id);
                CNXSIGRH3.AddInParameter(icom, "p_va_dias_restantes", DbType.Double, _kd_asignacion_vacaciones.va_dias_restantes);
                CNXSIGRH3.AddInParameter(icom, "p_va_horas_restantes", DbType.String, _kd_asignacion_vacaciones.va_horas_restantes);
                CNXSIGRH3.AddInParameter(icom, "p_va_estado", DbType.String, _kd_asignacion_vacaciones.va_estado);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaHistoricoGestionPrescrito(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C12");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerVacacionX(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_id", DbType.Int32, _kd_asignacion_vacaciones.va_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C13");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool AdicionarGestionPrescrito(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_id", DbType.Int32, _kd_asignacion_vacaciones.va_id);
                CNXSIGRH3.AddInParameter(icom, "p_va_nro_documento", DbType.String, _kd_asignacion_vacaciones.va_nro_documento);
                CNXSIGRH3.AddInParameter(icom, "p_va_autorizado_por", DbType.String, _kd_asignacion_vacaciones.va_autorizado_por);
                CNXSIGRH3.AddInParameter(icom, "p_va_fecha_habilitacion_prescrito", DbType.DateTime, _kd_asignacion_vacaciones.va_fecha_habilitacion_prescrito);
                CNXSIGRH3.AddInParameter(icom, "p_va_fecha_validez_prescrito", DbType.DateTime, _kd_asignacion_vacaciones.va_fecha_validez_prescrito);
                CNXSIGRH3.AddInParameter(icom, "p_va_usuario_creacion", DbType.Int32, _kd_asignacion_vacaciones.va_usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_va_id_actual", DbType.Int32, _kd_asignacion_vacaciones.va_id);


                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U4");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaFiliacion(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaHistoricoAsig(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C15");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarLicenciaVacacion(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_lj_id", DbType.Int32, _kd_asignacion_vacaciones.lj_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U6");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDiasAsignados(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_vac_id", DbType.Int32, _kd_asignacion_vacaciones.vac_id);
                CNXSIGRH3.AddInParameter(icom, "p_vac_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C16");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool RecuperarVacacion(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_id", DbType.Int32, _kd_asignacion_vacaciones.va_id);
                CNXSIGRH3.AddInParameter(icom, "p_va_dias_restantes", DbType.Double, _kd_asignacion_vacaciones.va_dias_restantes);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U7");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool RecuperarVacacionHoras(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_id", DbType.Int32, _kd_asignacion_vacaciones.va_id);
                CNXSIGRH3.AddInParameter(icom, "p_va_dias_restantes", DbType.Double, _kd_asignacion_vacaciones.va_dias_restantes);
                CNXSIGRH3.AddInParameter(icom, "p_va_horas_restantes", DbType.Int32, _kd_asignacion_vacaciones.va_horas_restantes);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U8");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleLicencia(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_lj_id", DbType.Int32, _kd_asignacion_vacaciones.lj_id);
                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C19");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerVacacionesAsignadas(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C20");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override string ObtenerVacaciones_ConDiasFeriados(string fechaInicio, string fechaFin)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_Finicio", DbType.DateTime, fechaInicio);
                CNXSIGRH3.AddInParameter(icom, "p_va_Ffin", DbType.DateTime, fechaFin);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "CTV");
                return CNXSIGRH3.ExecuteDataSet(icom).Tables[0].Rows[0][0].ToString();               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _KD_RESPUESTA_COMBO
        public override bool Adicionar__kd_respuesta_combo(cls_kd_respuesta_combo _kd_respuesta_combo)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

				CNXSIGRH3.AddInParameter(icom, "p_rc_id", DbType.Int32, _kd_respuesta_combo.rc_id);
				CNXSIGRH3.AddInParameter(icom, "p_rc_rq_id", DbType.Int32, _kd_respuesta_combo.rc_rq_id);
				CNXSIGRH3.AddInParameter(icom, "p_rc_desc", DbType.String, _kd_respuesta_combo.rc_desc);
				CNXSIGRH3.AddInParameter(icom, "p_rc_equivalencia", DbType.String, _kd_respuesta_combo.rc_equivalencia);
				CNXSIGRH3.AddInParameter(icom, "p_rc_estado", DbType.String, _kd_respuesta_combo.rc_estado);
				CNXSIGRH3.AddInParameter(icom, "p_rc_usuario_creacion", DbType.Int32, _kd_respuesta_combo.rc_usuario_creacion);
				CNXSIGRH3.AddInParameter(icom, "p_rc_fecha_creacion", DbType.DateTime, _kd_respuesta_combo.rc_fecha_creacion);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Eliminar__kd_respuesta_combo(cls_kd_respuesta_combo _kd_respuesta_combo)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

				CNXSIGRH3.AddInParameter(icom, "p_rc_id", DbType.Int32, _kd_respuesta_combo.rc_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Actualizar__kd_respuesta_combo(cls_kd_respuesta_combo _kd_respuesta_combo)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

				CNXSIGRH3.AddInParameter(icom, "p_rc_id", DbType.Int32, _kd_respuesta_combo.rc_id);
				CNXSIGRH3.AddInParameter(icom, "p_rc_rq_id", DbType.Int32, _kd_respuesta_combo.rc_rq_id);
				CNXSIGRH3.AddInParameter(icom, "p_rc_desc", DbType.String, _kd_respuesta_combo.rc_desc);
				CNXSIGRH3.AddInParameter(icom, "p_rc_equivalencia", DbType.String, _kd_respuesta_combo.rc_equivalencia);
				CNXSIGRH3.AddInParameter(icom, "p_rc_estado", DbType.String, _kd_respuesta_combo.rc_estado);
				CNXSIGRH3.AddInParameter(icom, "p_rc_usuario_creacion", DbType.Int32, _kd_respuesta_combo.rc_usuario_creacion);
				CNXSIGRH3.AddInParameter(icom, "p_rc_fecha_creacion", DbType.DateTime, _kd_respuesta_combo.rc_fecha_creacion);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerId__kd_respuesta_combo(cls_kd_respuesta_combo _kd_respuesta_combo)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_kd_respuesta_combo.rc_id = Convert.ToInt32(ds.Tables[0].Rows[0]["rc_id"]);
		
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerRegistro__kd_respuesta_combo(cls_kd_respuesta_combo _kd_respuesta_combo)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

				CNXSIGRH3.AddInParameter(icom, "p_rc_id", DbType.Int32, _kd_respuesta_combo.rc_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				if (ds.Tables[0].Rows[0]["rc_id"] != DBNull.Value && ds.Tables[0].Rows[0]["rc_id"].ToString().Trim() != "") { _kd_respuesta_combo.rc_id = Convert.ToInt32(ds.Tables[0].Rows[0]["rc_id"]); }
				if (ds.Tables[0].Rows[0]["rc_rq_id"] != DBNull.Value && ds.Tables[0].Rows[0]["rc_rq_id"].ToString().Trim() != "") { _kd_respuesta_combo.rc_rq_id = Convert.ToInt32(ds.Tables[0].Rows[0]["rc_rq_id"]); }
				if (ds.Tables[0].Rows[0]["rc_desc"] != DBNull.Value && ds.Tables[0].Rows[0]["rc_desc"].ToString().Trim() != "") { _kd_respuesta_combo.rc_desc = Convert.ToString(ds.Tables[0].Rows[0]["rc_desc"]); }
				if (ds.Tables[0].Rows[0]["rc_equivalencia"] != DBNull.Value && ds.Tables[0].Rows[0]["rc_equivalencia"].ToString().Trim() != "") { _kd_respuesta_combo.rc_equivalencia = Convert.ToString(ds.Tables[0].Rows[0]["rc_equivalencia"]); }
				if (ds.Tables[0].Rows[0]["rc_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["rc_estado"].ToString().Trim() != "") { _kd_respuesta_combo.rc_estado = Convert.ToString(ds.Tables[0].Rows[0]["rc_estado"]); }
				if (ds.Tables[0].Rows[0]["rc_usuario_creacion"] != DBNull.Value && ds.Tables[0].Rows[0]["rc_usuario_creacion"].ToString().Trim() != "") { _kd_respuesta_combo.rc_usuario_creacion = Convert.ToInt32(ds.Tables[0].Rows[0]["rc_usuario_creacion"]); }
				if (ds.Tables[0].Rows[0]["rc_fecha_creacion"] != DBNull.Value && ds.Tables[0].Rows[0]["rc_fecha_creacion"].ToString().Trim() != "") { _kd_respuesta_combo.rc_fecha_creacion = Convert.ToString(ds.Tables[0].Rows[0]["rc_fecha_creacion"]); }
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaGrilla__kd_respuesta_combo(string rc_id, 
						string rc_rq_id, 
						string rc_desc, 
						string rc_equivalencia, 
						string rc_estado, 
						string rc_usuario_creacion, 
						string rc_fecha_creacion)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

				if (rc_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_rc_id", DbType.Int32, Convert.ToInt32(rc_id)); }
				if (rc_rq_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_rc_rq_id", DbType.Int32, Convert.ToInt32(rc_rq_id)); }
				if (rc_desc.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_rc_desc", DbType.String, Convert.ToString(rc_desc)); }
				if (rc_equivalencia.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_rc_equivalencia", DbType.String, Convert.ToString(rc_equivalencia)); }
				if (rc_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_rc_estado", DbType.String, Convert.ToString(rc_estado)); }
				if (rc_usuario_creacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_rc_usuario_creacion", DbType.Int32, Convert.ToInt32(rc_usuario_creacion)); }
				if (rc_fecha_creacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_rc_fecha_creacion", DbType.DateTime, Convert.ToDateTime(rc_fecha_creacion)); }
 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__kd_respuesta_combo()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ListaRequisitos(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_rq_categoria", DbType.String, _kd_respuesta_combo.rq_categoria);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDatosFuncioanrio(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _kd_respuesta_combo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ComboRequisitos(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_rq_categoria", DbType.String, _kd_respuesta_combo.rq_categoria);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDatosPersonales(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _kd_respuesta_combo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool GuardarRequisitosPresentados(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "rp_per_id", DbType.Int32, _kd_respuesta_combo.rp_valor_pk);
                CNXSIGRH3.AddInParameter(icom, "rp_rc_id", DbType.Int32, _kd_respuesta_combo.rp_rc_id);
                CNXSIGRH3.AddInParameter(icom, "rp_fecha_presentacion", DbType.String, _kd_respuesta_combo.rp_fecha_presentacion);
                CNXSIGRH3.AddInParameter(icom, "rp_usuario_creacion", DbType.Int32, _kd_respuesta_combo.rp_usuario_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet RequisitosPresentadosFun(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_rp_nombre_pk", DbType.String, _kd_respuesta_combo.rp_nombre_pk);
                CNXSIGRH3.AddInParameter(icom, "p_rp_valor_pk", DbType.Int32, _kd_respuesta_combo.rp_valor_pk);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrillaEducFormal(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_rp_valor_pk", DbType.Int32, _kd_respuesta_combo.rp_valor_pk);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarRequisitos(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "rp_per_id", DbType.Int32, _kd_respuesta_combo.rp_valor_pk);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrillaRequisitos(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFiltradoCategoria(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C12");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool AdicionarRequisito(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_rq_descripcion", DbType.String, _kd_respuesta_combo.rq_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_rq_categoria", DbType.String, _kd_respuesta_combo.rq_categoria);
                CNXSIGRH3.AddInParameter(icom, "p_rq_estado", DbType.String, _kd_respuesta_combo.rq_estado);
                CNXSIGRH3.AddInParameter(icom, "p_rq_usuario_creacion", DbType.Int32, _kd_respuesta_combo.rq_usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C13");
                CNXSIGRH3.ExecuteNonQuery(icom);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarRequisito(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_rq_id", DbType.String, _kd_respuesta_combo.rq_id);
                CNXSIGRH3.AddInParameter(icom, "p_rq_descripcion", DbType.String, _kd_respuesta_combo.rq_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_rq_categoria", DbType.String, _kd_respuesta_combo.rq_categoria);
                CNXSIGRH3.AddInParameter(icom, "p_rq_estado", DbType.String, _kd_respuesta_combo.rq_estado);
                CNXSIGRH3.AddInParameter(icom, "p_rq_usuario_creacion", DbType.Int32, _kd_respuesta_combo.rq_usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C16");
                CNXSIGRH3.ExecuteNonQuery(icom);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarRequisito(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_rq_id", DbType.String, _kd_respuesta_combo.rq_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C20");
                CNXSIGRH3.ExecuteNonQuery(icom);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerRequisitoX(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_rq_id", DbType.String, _kd_respuesta_combo.rq_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool GuardarRequisitosPresentadosUDEP(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_rp_nombre_pk", DbType.String, _kd_respuesta_combo.rp_nombre_pk);
                CNXSIGRH3.AddInParameter(icom, "p_rp_valor_pk", DbType.Int32, _kd_respuesta_combo.rp_valor_pk);
                CNXSIGRH3.AddInParameter(icom, "p_rp_respuesta", DbType.String, _kd_respuesta_combo.rp_respuesta);
                CNXSIGRH3.AddInParameter(icom, "p_rp_rq_id", DbType.Int32, _kd_respuesta_combo.rp_rq_id);
                CNXSIGRH3.AddInParameter(icom, "p_rp_rc_id", DbType.Int32, _kd_respuesta_combo.rp_rc_id);
                CNXSIGRH3.AddInParameter(icom, "p_rp_usuario_creacion", DbType.Int32, _kd_respuesta_combo.rp_usuario_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C19");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ValidarRequisitosPresentados(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_rq_categoria", DbType.String, _kd_respuesta_combo.rq_categoria);
                CNXSIGRH3.AddInParameter(icom, "p_rp_nombre_pk", DbType.String, _kd_respuesta_combo.rp_nombre_pk);
                CNXSIGRH3.AddInParameter(icom, "p_rp_valor_pk", DbType.Int32, _kd_respuesta_combo.rp_valor_pk);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C21");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet RegistrarFormacion(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_ef_per_id", DbType.Int32, _kd_respuesta_combo.ef_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ef_nivel_instruccion", DbType.Int32, _kd_respuesta_combo.ef_nivel_instruccion);
                //CNXSIGRH3.AddInParameter(icom, "p_ef_centro_form", DbType.Int32, _kd_respuesta_combo.ef_centro_form);
                //CNXSIGRH3.AddInParameter(icom, "p_ef_carrera_especialidad", DbType.Int32, _kd_respuesta_combo.ef_carrera_especialidad);
                //CNXSIGRH3.AddInParameter(icom, "p_ef_fecha_ini", DbType.DateTime, Convert.ToDateTime(_kd_respuesta_combo.ef_fecha_ini));
                //CNXSIGRH3.AddInParameter(icom, "p_ef_fecha_fin", DbType.DateTime, Convert.ToDateTime(_kd_respuesta_combo.ef_fecha_fin));
                //CNXSIGRH3.AddInParameter(icom, "p_ef_anios_estudio", DbType.Int32, _kd_respuesta_combo.ef_anios_estudio);
                //CNXSIGRH3.AddInParameter(icom, "p_ef_titulo_obtenido", DbType.Int32, _kd_respuesta_combo.ef_titulo_obtenido);
                //CNXSIGRH3.AddInParameter(icom, "p_ef_fecha_titulo_obtenido", DbType.DateTime, Convert.ToDateTime(_kd_respuesta_combo.ef_fecha_titulo_obtenido));
                //CNXSIGRH3.AddInParameter(icom, "p_ef_nro_titulo", DbType.String, _kd_respuesta_combo.ef_nro_titulo);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFormacionX(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_ef_id", DbType.String, _kd_respuesta_combo.ef_id);
                CNXSIGRH3.AddInParameter(icom, "p_ef_per_id", DbType.String, _kd_respuesta_combo.ef_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C21");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarFormacion(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);

                CNXSIGRH3.AddInParameter(icom, "p_ef_id", DbType.Int32, _kd_respuesta_combo.ef_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C22");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerHistoricoAsigVacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C23");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarNivelInstruccion(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);
                CNXSIGRH3.AddInParameter(icom, "p_ef_id", DbType.Int32, _kd_respuesta_combo.ef_id);
                CNXSIGRH3.AddInParameter(icom, "p_ef_per_id", DbType.Int32, _kd_respuesta_combo.ef_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ef_nivel_instruccion", DbType.Int32, _kd_respuesta_combo.ef_nivel_instruccion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C23");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerNivelInstruccion(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_RESPUESTA_COMBO);
                CNXSIGRH3.AddInParameter(icom, "p_ef_per_id", DbType.Int32, _kd_respuesta_combo.ef_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C24");
                
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarTmp_ReporteFiliacion()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_REPORTE_KD");

                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region KD_CURRICULUM
        public override bool Adicionar_CurriculumFormacion(cls_cv_formacion _cv_formacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_formacion");

                CNXSIGRH3.AddInParameter(icom, "p_cv_ga_id", DbType.Int32, _cv_formacion.cv_ga_id);
                CNXSIGRH3.AddInParameter(icom, "p_cv_inst_id", DbType.String, _cv_formacion.cv_inst_id);
                CNXSIGRH3.AddInParameter(icom, "p_cv_carr_id", DbType.String, _cv_formacion.cv_carr_id);
                CNXSIGRH3.AddInParameter(icom, "p_cv_form_año_inicio", DbType.Int32, _cv_formacion.cv_form_año_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_cv_form_año_fin", DbType.Int32, _cv_formacion.cv_form_año_fin);
                CNXSIGRH3.AddInParameter(icom, "p_cv_form_prov_nal", DbType.String, _cv_formacion.cv_form_prov_nal);
                CNXSIGRH3.AddInParameter(icom, "p_cv_form_estado", DbType.String, _cv_formacion.cv_form_estado);
                CNXSIGRH3.AddInParameter(icom, "p_cv_form_per_id", DbType.String, _cv_formacion.cv_form_per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Eliminar_CurriculumFormacion(cls_cv_formacion _cv_formacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_formacion");

                CNXSIGRH3.AddInParameter(icom, "p_cv_form_id", DbType.String, _cv_formacion.cv_form_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrilla_Formacion(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_formacion");

                CNXSIGRH3.AddInParameter(icom, "p_cv_form_per_id", DbType.String, per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool InsertarFormacion_Insitucion(string nombre, int depto, string estado, int provincia, int ciudad, string observacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand("sp_instituciones");

                CNXGENERAL.AddInParameter(icom, "p_it_nombre", DbType.String, nombre.Substring(0, nombre.Length - 1));
                CNXGENERAL.AddInParameter(icom, "p_it_depto", DbType.Int32, depto);
                CNXGENERAL.AddInParameter(icom, "p_it_estado", DbType.String, 'V');
                CNXGENERAL.AddInParameter(icom, "p_it_provincia", DbType.Int32, 0);
                CNXGENERAL.AddInParameter(icom, "p_it_ciudad", DbType.Int32, 0);
                CNXGENERAL.AddInParameter(icom, "p_it_observacion", DbType.String, observacion);

                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool InsertarFormacion_Carrera(string carrera_nombre, string carrera_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand("sp_carreras");

                CNXGENERAL.AddInParameter(icom, "p_carr_nombre", DbType.String, carrera_nombre.Substring(0, carrera_nombre.Length - 1));
                CNXGENERAL.AddInParameter(icom, "p_carr_estado", DbType.String, 'V');

                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListadoCursos(int per_id, string accion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_cursos");

                //CNXGENERAL.AddInParameter(icom, "p_cv_curs_per_id", DbType.Int32, per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String,accion);
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool InsertarCursos_Insitucion(string nombre, int depto, string estado, int provincia, int ciudad, string observacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand("sp_instituciones");

                CNXGENERAL.AddInParameter(icom, "p_it_nombre", DbType.String, nombre.Substring(0, nombre.Length - 1));
                CNXGENERAL.AddInParameter(icom, "p_it_depto", DbType.Int32, depto);
                CNXGENERAL.AddInParameter(icom, "p_it_estado", DbType.String, 'V');
                CNXGENERAL.AddInParameter(icom, "p_it_provincia", DbType.Int32, 0);
                CNXGENERAL.AddInParameter(icom, "p_it_ciudad", DbType.Int32, 0);
                CNXGENERAL.AddInParameter(icom, "p_it_observacion", DbType.String, observacion);

                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool InsertarCursos_Curso(string nombre_curso, string estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_cursos");

                CNXSIGRH3.AddInParameter(icom, "p_cv_curs_nombre_curso", DbType.String, nombre_curso.Substring(0, nombre_curso.Length-1));
                CNXSIGRH3.AddInParameter(icom, "p_cv_curs_estado", DbType.String, estado);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Adicionar_CurriculumCurso(int per_id, int curs_id, int inst_id, int carga_horaria, string estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_asignacion_cursos");

                CNXSIGRH3.AddInParameter(icom, "p_asig_curs_per_id", DbType.Int32, per_id);

                CNXSIGRH3.AddInParameter(icom, "p_asig_curs_cv_curs_id", DbType.Int32, curs_id);
                CNXSIGRH3.AddInParameter(icom, "p_asig_curs_inst_id", DbType.Int32, inst_id);
                CNXSIGRH3.AddInParameter(icom, "p_asig_curs_carga_horaria", DbType.Int32, carga_horaria);
                CNXSIGRH3.AddInParameter(icom, "p_asig_curs_estado", DbType.String, estado);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrilla_Cursos(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_asignacion_cursos");

                CNXSIGRH3.AddInParameter(icom, "p_asig_curs_per_id", DbType.String, per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Eliminar_CurriculumCursos(int per_id, int curs_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_asignacion_cursos");

                CNXSIGRH3.AddInParameter(icom, "p_asig_curs_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "p_asig_curs_cv_curs_id", DbType.Int32, curs_id);


                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool InsertarTrayectoria_Insitucion(string nombre, int depto, string estado, int provincia, int ciudad, string observacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand("sp_instituciones");

                CNXGENERAL.AddInParameter(icom, "p_it_nombre", DbType.String, nombre.Substring(0, nombre.Length - 1));
                CNXGENERAL.AddInParameter(icom, "p_it_depto", DbType.Int32, depto);
                CNXGENERAL.AddInParameter(icom, "p_it_estado", DbType.String, 'V');
                CNXGENERAL.AddInParameter(icom, "p_it_provincia", DbType.Int32, 0);
                CNXGENERAL.AddInParameter(icom, "p_it_ciudad", DbType.Int32, 0);
                CNXGENERAL.AddInParameter(icom, "p_it_observacion", DbType.String, observacion);

                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Adicionar_CurriculumTrayectoria(int inst_id, string area, string ultimo_cargo, int mes_inicio, int gestion_inicio, int mes_fin, int gestion_fin, string estado, int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_experiencia_laboral");

                CNXSIGRH3.AddInParameter(icom, "p_cv_exp_inst_id", DbType.Int32, inst_id);
                CNXSIGRH3.AddInParameter(icom, "p_cv_exp_area_esp", DbType.String, area);
                CNXSIGRH3.AddInParameter(icom, "p_cv_exp_ultimo_cargo", DbType.String, ultimo_cargo);
                CNXSIGRH3.AddInParameter(icom, "p_cv_exp_mes_inicio", DbType.Int32, mes_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_cv_exp_año_inicio", DbType.Int32, gestion_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_cv_exp_mes_fin", DbType.Int32, mes_fin);
                CNXSIGRH3.AddInParameter(icom, "p_cv_exp_año_fin", DbType.Int32, gestion_fin);
                CNXSIGRH3.AddInParameter(icom, "p_cv_exp_estado", DbType.String, estado);
                CNXSIGRH3.AddInParameter(icom, "p_cv_exp_per_id", DbType.Int32, per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrilla_Trayectoria(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_experiencia_laboral");

                CNXSIGRH3.AddInParameter(icom, "p_cv_exp_per_id", DbType.String, per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Eliminar_CurriculumTrayectoria(int exp_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_experiencia_laboral");

                CNXSIGRH3.AddInParameter(icom, "p_cv_exp_id", DbType.Int32, exp_id);


                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListadoIdiomas()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand("sp_idioma");

                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
                return CNXGENERAL.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Adicionar_CurriculumIdioma(int per_id, int idioma_id, string estado, string nivel)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_asignacion_idiomas");
                
                CNXSIGRH3.AddInParameter(icom, "p_asig_idio_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "p_asig_idio_cv_idio_id", DbType.Int32, idioma_id);
                CNXSIGRH3.AddInParameter(icom, "p_asig_idio_estado", DbType.String, estado);
                CNXSIGRH3.AddInParameter(icom, "p_asig_idio_nivel", DbType.String, nivel);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Eliminar_CurriculumIdioma(int per_id, int idioma_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_asignacion_idiomas");

                CNXSIGRH3.AddInParameter(icom, "p_asig_idio_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "p_asig_idio_cv_idio_id", DbType.Int32, idioma_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrilla_Idiomas(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_asignacion_idiomas");

                CNXSIGRH3.AddInParameter(icom, "p_asig_idio_per_id", DbType.String, per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool InsertarNuevoIdioma(string nombre_idioma, string estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand("sp_idioma");
                CNXGENERAL.AddInParameter(icom, "p_idm_nombre", DbType.String, nombre_idioma.Substring(0, nombre_idioma.Length - 1));
                CNXGENERAL.AddInParameter(icom, "p_idm_estado", DbType.String, estado);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool InsertarNuevoConocimiento(string nombre_conocimiento, string estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_otros_conocimientos");
                CNXSIGRH3.AddInParameter(icom, "p_cv_oc_conocimiento", DbType.String, nombre_conocimiento.Substring(0, nombre_conocimiento.Length-1));
                CNXSIGRH3.AddInParameter(icom, "p_cv_oc_estado", DbType.String, estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListadoConocimientos()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_otros_conocimientos");

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrilla_OtrosC(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_asignacion_otros_conocimientos");

                CNXSIGRH3.AddInParameter(icom, "p_asig_oc_per_id", DbType.String, per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Adicionar_CurriculumOtrosC(int per_id, int conocimiento_id, string estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_asignacion_otros_conocimientos");

                CNXSIGRH3.AddInParameter(icom, "p_asig_oc_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "p_asig_oc_cv_oc_id", DbType.Int32, conocimiento_id);
                CNXSIGRH3.AddInParameter(icom, "p_asig_oc_estado", DbType.String, estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Eliminar_CurriculumOtrosC(int per_id, int oc_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cv_asignacion_otros_conocimientos");

                CNXSIGRH3.AddInParameter(icom, "p_asig_oc_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "p_asig_oc_cv_oc_id", DbType.Int32, oc_id);


                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGradoAcademico_Reporte()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_REPORTE_CV");
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                return CNXSIGRH3.ExecuteDataSet(icom);              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerCarreras_Reporte(string grado_academico)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_REPORTE_CV");
                CNXSIGRH3.AddInParameter(icom, "p_cv_combo", DbType.String, grado_academico);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region CHEQUES
        public override DataSet Gestion()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXCHEQUES.GetStoredProcCommand("SP_BusquedaProceso");

                CNXCHEQUES.AddInParameter(icom, "Accion", DbType.String, "A");
                return CNXCHEQUES.ExecuteDataSet(icom);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet BuscarCheque(string preventivo, string proceso_nombre, int id_gestion, string beneficiario, string nit_ci, string num_cheque)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXCHEQUES.GetStoredProcCommand("SP_BusquedaProceso");
                if (preventivo!="") CNXCHEQUES.AddInParameter(icom, "Preventivo", DbType.Int32, Convert.ToInt32(preventivo));
                if (proceso_nombre!="") CNXCHEQUES.AddInParameter(icom, "Proceso_nombre", DbType.String, proceso_nombre);
                CNXCHEQUES.AddInParameter(icom, "gestion_id", DbType.Int32, id_gestion);
                if (beneficiario != "") CNXCHEQUES.AddInParameter(icom, "beneficiario", DbType.String, beneficiario);
                if (nit_ci != "") CNXCHEQUES.AddInParameter(icom, "nit_ci", DbType.String, nit_ci);
                if (num_cheque != "") CNXCHEQUES.AddInParameter(icom, "num_cheque", DbType.String, num_cheque);
                CNXCHEQUES.AddInParameter(icom, "Accion", DbType.String, "B");
                return CNXCHEQUES.ExecuteDataSet(icom);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet DetalleCheque(int pago_id){
            try
            {
                DbCommand icom = null;
                icom = CNXCHEQUES.GetStoredProcCommand("SP_InfoPago");
                CNXCHEQUES.AddInParameter(icom, "pago_id", DbType.Int32, pago_id);
                return CNXCHEQUES.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public override DataSet ObtenerTipoDoc()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXCHEQUES.GetStoredProcCommand("SP_Cheques");
                CNXCHEQUES.AddInParameter(icom, "Accion", DbType.String, "C1");
                return CNXCHEQUES.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override bool AdicionarPDF(int tipoDoc_id, int proce_id, byte[] foto, string fecha_doc, int per_id, string obser)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXCHEQUES.GetStoredProcCommand("SP_Cheques");
                CNXCHEQUES.AddInParameter(icom, "pdf_tipo_doc_id", DbType.Int32, tipoDoc_id);
                CNXCHEQUES.AddInParameter(icom, "pdf_proceso_id", DbType.Int32, proce_id);
                CNXCHEQUES.AddInParameter(icom, "pdf_documento", DbType.Binary, foto);
                if (fecha_doc != "")
                {
                    CNXCHEQUES.AddInParameter(icom, "pdf_fecha_doc", DbType.Date, Convert.ToDateTime(fecha_doc));
                }
                else
                {
                    CNXCHEQUES.AddInParameter(icom, "pdf_fecha_doc", DbType.Date, Convert.ToDateTime("1/1/2022"));
                }
                CNXCHEQUES.AddInParameter(icom, "pdf_per_id", DbType.Int32, per_id);
                CNXCHEQUES.AddInParameter(icom, "pdf_observacion", DbType.String, obser);
                CNXCHEQUES.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region poai

        public override DataSet ListarResultados(int poai_id, string r_tipo) 
        {
            try
            {
                DbCommand dbCommand = null;
                dbCommand = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(dbCommand, "pu_id", DbType.Int32, poai_id);
                CNXSIGRH3.AddInParameter(dbCommand, "r_tipo", DbType.String, r_tipo);
                CNXSIGRH3.AddInParameter(dbCommand, "Accion", DbType.String, "C3");
                return CNXSIGRH3.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //================== FORMACION OBLIGATORIA ======================
        public override DataSet ListarFormacionObligatoria(int pu_id, string fo_tipo)
        {
            try
            {
                DbCommand dbCommand = null;
                dbCommand = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(dbCommand, "pu_id", DbType.Int32, pu_id);
                CNXSIGRH3.AddInParameter(dbCommand, "fo_tipo", DbType.String, fo_tipo);
                CNXSIGRH3.AddInParameter(dbCommand, "Accion", DbType.String, "C13");
                return CNXSIGRH3.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet DevolverDatosFormacionObligatoria(int fo_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "fo_id", DbType.Int32, fo_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C14");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ActualizarFormacionO(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "FO_ID", DbType.Int32, _kd_finiquito.fo_id);
                CNXSIGRH3.AddInParameter(icom, "fo_tipo", DbType.String, _kd_finiquito.fo_tipo2);
                CNXSIGRH3.AddInParameter(icom, "p_descripcion", DbType.String, _kd_finiquito.p_descripcion2);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "U4");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        
        //================== /FORMACION OBLIGATORIA ======================
        public override DataSet ListarActividades(int r_id)
        {
            try
            {
                DbCommand dbCommand = null;
                dbCommand = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(dbCommand, "r_id", DbType.Int32, r_id);
                CNXSIGRH3.AddInParameter(dbCommand, "Accion", DbType.String, "C6");
                return CNXSIGRH3.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet List_Gestion()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(sp_periodo);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
                return CNXGENERAL.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public override DataSet Listar_Supervisores()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C1");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public override DataSet Listar_Caracteristicas()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C12");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override DataSet Listar_Complementarios()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C11");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public override int Adicionar_Poai(int ca_id2, int p_tipo, string inter, string intra, int ca_id, int super_id, int nro_puesto, string pu_nombre , string pu_pref, string pu_objetivo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "p_tipo", DbType.Int32, p_tipo);
                CNXSIGRH3.AddInParameter(icom, "ca_id", DbType.Int32, ca_id2);
                CNXSIGRH3.AddInParameter(icom, "p_descripcion", DbType.Int32, ca_id2);

                CNXSIGRH3.AddInParameter(icom, "i_inter", DbType.String, inter);
                CNXSIGRH3.AddInParameter(icom, "i_intra", DbType.String, intra);
                CNXSIGRH3.AddInParameter(icom, "i_ca_id", DbType.Int32, ca_id);
                CNXSIGRH3.AddInParameter(icom, "i_super_id", DbType.Int32, super_id);

                CNXSIGRH3.AddInParameter(icom, "pu_nro_puesto", DbType.Int32, nro_puesto);
                CNXSIGRH3.AddInParameter(icom, "pu_nombre", DbType.String, pu_nombre);
                CNXSIGRH3.AddInParameter(icom, "pu_pref", DbType.String, pu_pref);
                CNXSIGRH3.AddInParameter(icom, "pu_objetivo", DbType.String, pu_objetivo);

                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "A2");
                int c = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom));
                return c;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public override int Devolver_tipo_Poai(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C4");
                int x = Convert.ToInt32( CNXSIGRH3.ExecuteScalar(icom));
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ========= devolver cargo ===========

        public override int DevolverCargoXPer(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C21");
                int x = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom));
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //---------- devolver cargo ------------


        public override DataSet DevolverGestionPerId(int per_id, int gestion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "PERIODO", DbType.Int32, gestion);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C2");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet DevolverDatosResultadosEspecificos(int r_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "@r_id", DbType.Int32, r_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C5");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ========= devolver datos poai ===========

        public override DataSet DevolverDatosPoai(int poai_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "poai_id", DbType.Int32, poai_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C20");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //---------- devolver datos poai -----------

        public override DataSet DevolverDatosActividad(int actividad_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "a_actividad_id", DbType.Int32, actividad_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C8");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ActualizarResultadoEspecifico(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "r_id", DbType.Int32, _kd_finiquito.id3);
                CNXSIGRH3.AddInParameter(icom, "r_indicador", DbType.String, _kd_finiquito.r_indicador2);
                CNXSIGRH3.AddInParameter(icom, "r_resultado", DbType.String, _kd_finiquito.r_resultado2);
                CNXSIGRH3.AddInParameter(icom, "r_ponderacion", DbType.Decimal, Convert.ToDecimal(_kd_finiquito.r_ponderacion2));
                CNXSIGRH3.AddInParameter(icom, "r_tipo", DbType.String, "E");
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "U1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ActualizarResultadoEspecifico2(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "r_id", DbType.Int32, _kd_finiquito.id3);
                CNXSIGRH3.AddInParameter(icom, "r_indicador", DbType.String, _kd_finiquito.r_indicador2);
                CNXSIGRH3.AddInParameter(icom, "r_resultado", DbType.String, _kd_finiquito.r_resultado2);
                CNXSIGRH3.AddInParameter(icom, "r_ponderacion", DbType.Decimal, Convert.ToDecimal(_kd_finiquito.r_ponderacion2));
                CNXSIGRH3.AddInParameter(icom, "r_tipo", DbType.String, "R");
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "U1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        //=========== POAI ==============

        public override bool ActualizarPoai(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "i_super_id", DbType.Int32, _kd_finiquito.i_super_id);
                CNXSIGRH3.AddInParameter(icom, "i_id2", DbType.Int32, _kd_finiquito.i_id);
                CNXSIGRH3.AddInParameter(icom, "i_inter", DbType.String, _kd_finiquito.poai_i_inter);
                CNXSIGRH3.AddInParameter(icom, "i_intra", DbType.String, _kd_finiquito.poai_i_intra);
                CNXSIGRH3.AddInParameter(icom, "objetivo", DbType.String, _kd_finiquito.poai_objetivo_p);
                CNXSIGRH3.AddInParameter(icom, "poai_id", DbType.Int32, _kd_finiquito.POAI_ID);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "B56");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        //----------- POAI -------------

        public override bool ActualizarActividad(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "a_actividad_id", DbType.Int32, _kd_finiquito.id_actividad2); ///ojojojojojojojo
                CNXSIGRH3.AddInParameter(icom, "a_descripcion", DbType.String, _kd_finiquito.actividad_descripcion);
                CNXSIGRH3.AddInParameter(icom, "a_medio_verif", DbType.String, _kd_finiquito.actividad_medio_verificacion);
                CNXSIGRH3.AddInParameter(icom, "r_id", DbType.Int32, _kd_finiquito.r_id2);
                CNXSIGRH3.AddInParameter(icom, "a_puntaje", DbType.Decimal, Convert.ToDecimal(_kd_finiquito.actividad_puntaje));
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "U2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool AdicionarResultadoEspecifico(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "r_indicador", DbType.String, _kd_finiquito.r_indicador);
                CNXSIGRH3.AddInParameter(icom, "r_resultado", DbType.String, _kd_finiquito.r_resultado);
                CNXSIGRH3.AddInParameter(icom, "r_tipo", DbType.String, _kd_finiquito.r_tipo);
                CNXSIGRH3.AddInParameter(icom, "r_ponderacion", DbType.Decimal ,_kd_finiquito.r_ponderacion);
                CNXSIGRH3.AddInParameter(icom, "pu_id", DbType.Int32, _kd_finiquito.r_poai_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        // =============== Cualidades ==========

        public override bool AdicionarCualidad(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "a_descripcion", DbType.String, _kd_finiquito.cu_descripcion);
                CNXSIGRH3.AddInParameter(icom, "pu_id", DbType.Int32, _kd_finiquito.cua_pu_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "A5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ActualizarCualidad(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "cualidad_id", DbType.Int32, _kd_finiquito.cua_id);
                CNXSIGRH3.AddInParameter(icom, "a_descripcion", DbType.String, _kd_finiquito.cu_descripcion);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "U5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool EliminarCualidad(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "cualidad_id", DbType.Int32, _kd_finiquito.cua_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "B1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        // --------------- CUALIDADES ----------

        // =============== NORMATIVA ============

        public override bool AdicionarNormativa(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "a_descripcion", DbType.String, _kd_finiquito.nor_descripcion);
                CNXSIGRH3.AddInParameter(icom, "pu_id", DbType.Int32, _kd_finiquito.nor_pu_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "A6");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ListarNormas(int pu_id)
        {
            try
            {
                DbCommand dbCommand = null;
                dbCommand = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(dbCommand, "pu_id", DbType.Int32, pu_id);
                CNXSIGRH3.AddInParameter(dbCommand, "Accion", DbType.String, "C17");
                return CNXSIGRH3.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet DevolverDatosNorma(int nor_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "Cumpl_id", DbType.Int32, nor_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C98");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarNorma(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "Cumpl_id", DbType.Int32, _kd_finiquito.nor_id);
                CNXSIGRH3.AddInParameter(icom, "a_descripcion", DbType.String, _kd_finiquito.nor_descripcion);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "U6");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool EliminarNorma(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "Cumpl_id", DbType.Int32, _kd_finiquito.nor_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "B97");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        // --------------- NOMATIVA -------------


        public override bool AdicionarFormacion(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "fo_tipo", DbType.String, _kd_finiquito.fo_tipo);
                CNXSIGRH3.AddInParameter(icom, "p_descripcion", DbType.String, _kd_finiquito.p_descripcion);
                CNXSIGRH3.AddInParameter(icom, "pu_id", DbType.Int32, _kd_finiquito.pu_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "A4");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ListarCualidades(int pu_id)
        {
            try
            {
                DbCommand dbCommand = null;
                dbCommand = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(dbCommand, "pu_id", DbType.Int32, pu_id);
                CNXSIGRH3.AddInParameter(dbCommand, "Accion", DbType.String, "C16");
                return CNXSIGRH3.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet DevolverDatosCualidad(int cu_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "cualidad_id", DbType.Int32, cu_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C99");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // =========== Experiencia =============

        public override bool AdicionarExperciencia(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "pu_id", DbType.Int32, _kd_finiquito.Exp_pu_id);
                CNXSIGRH3.AddInParameter(icom, "EXP_GRAL", DbType.Decimal, _kd_finiquito.EXP_GRAL);
                CNXSIGRH3.AddInParameter(icom, "EXP_ESP", DbType.Decimal, _kd_finiquito.EXP_ESP);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "AU1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ListarExperiencia(int pu_id)
        {
            try
            {
                DbCommand dbCommand = null;
                dbCommand = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(dbCommand, "pu_id", DbType.Int32, pu_id);
                CNXSIGRH3.AddInParameter(dbCommand, "Accion", DbType.String, "C15");
                return CNXSIGRH3.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // ----------- Experiencia -------------



        public override int AdicionarActividad(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "a_descripcion", DbType.String, _kd_finiquito.a_descripcion);
                CNXSIGRH3.AddInParameter(icom, "a_medio_verif", DbType.String, _kd_finiquito.a_medio_verif);
                CNXSIGRH3.AddInParameter(icom, "r_id", DbType.Int32, _kd_finiquito.r_id2);
                CNXSIGRH3.AddInParameter(icom, "a_puntaje", DbType.Decimal, _kd_finiquito.a_puntaje);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "A3");
                int x = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom));
                return x;
            }
            catch (Exception ex) { throw ex; }
        }

        public override int TotalActividad(int r_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "r_id", DbType.Int32, r_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C7");
                int x = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom));
                return x;
            }
            catch (Exception ex) { throw ex; }
        }

        public override decimal TotalE(int result_pu_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "result_pu_id", DbType.Int32, result_pu_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C9");
                decimal x = Convert.ToDecimal(CNXSIGRH3.ExecuteScalar(icom));
                return x;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool EliminarResultado(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "r_id", DbType.Int32, _kd_finiquito.id2);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "U");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool EliminarActividad(cls_kd_finiquito2 _kd_finiquito)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(sp_poais);
                CNXSIGRH3.AddInParameter(icom, "a_actividad_id", DbType.Int32, _kd_finiquito.id_actividad2);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "U3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
        #region INFORMACION
        public override DataSet Cargos()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_Datos_POAI");
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet Informacion(int es_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_Datos_POAI");
                CNXSIGRH3.AddInParameter(icom, "es_id", DbType.Int32, es_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C1");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet UltimoCargo(int as_id, int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_Datos_POAI");
                CNXSIGRH3.AddInParameter(icom, "as_id", DbType.Int32, as_id);
                CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C4");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet GrillaInformacionFunc(
string per_id,
string per_tipo_doc,
string per_num_doc,
string per_lugar_exp,
string per_ap_paterno,
string per_ap_materno,
string per_nombres,
string per_ap_casada,
string per_sexo,
string per_fecha_nac,
string per_procedencia,
string per_serie_libreta_militar,
string per_lugar_nac,
string per_estado_civil)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_Datos_POAI");

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, Convert.ToInt32(per_id)); }
                if (per_tipo_doc.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_tipo_doc", DbType.Int32, Convert.ToInt32(per_tipo_doc)); }
                if (per_num_doc.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, Convert.ToString(per_num_doc)); }
                if (per_lugar_exp.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_lugar_exp", DbType.Int32, Convert.ToInt32(per_lugar_exp)); }
                if (per_ap_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, Convert.ToString(per_ap_paterno)); }
                if (per_ap_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, Convert.ToString(per_ap_materno)); }
                if (per_nombres.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, Convert.ToString(per_nombres)); }
                if (per_ap_casada.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_casada", DbType.String, Convert.ToString(per_ap_casada)); }
                if (per_sexo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_sexo", DbType.String, Convert.ToString(per_sexo)); }
                if (per_fecha_nac.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_fecha_nac", DbType.DateTime, Convert.ToDateTime(per_fecha_nac)); }
                if (per_procedencia.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_procedencia", DbType.Int32, Convert.ToInt32(per_procedencia)); }
                if (per_serie_libreta_militar.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_serie_libreta_militar", DbType.String, Convert.ToString(per_serie_libreta_militar)); }
                if (per_lugar_nac.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_lugar_nac", DbType.Int32, Convert.ToString(per_lugar_nac)); }
                if (per_estado_civil.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_estado_civil", DbType.Int32, Convert.ToString(per_estado_civil)); }
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion


        public override DataSet OBTENERGRIDASGINACIONES(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones, int nro)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__KD_ASIGNACION_VACACIONES);

                CNXSIGRH3.AddInParameter(icom, "p_va_per_id", DbType.Int32, _kd_asignacion_vacaciones.va_per_id);
                CNXSIGRH3.AddInParameter(icom, "TIPO_FUNC", DbType.Int32, nro);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "K1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
