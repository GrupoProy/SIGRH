using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_ControlPersonal.DataAccessLayer;
using System.Globalization;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
    public class DataAccessLayerSQLDataAccessLayer : DataAccessLayerDataAccessLayer
    {
        #region CONSTANTES
        private string SP__CP_CONTROLES_PERSONAL = "sp_cp_controles_personal";
        private string SP__CP_CIERRE_MENSUAL = "sp_cp_cierre_mensual";
        private string SP__CP_SANCIONES_REL_CIERRE = "sp_cp_sanciones_rel_cierre";
        private string SP__CP_SANCIONES = "sp_cp_sanciones";
        private string SP__CP_ASIGNACION_HORARIO = "sp_cp_asignacion_horario";
        private string SP__CP_MARCACIONES = "sp_cp_marcaciones";
        private string SP__CP_UBICACION_FISICA = "sp_cp_ubicacion_fisica";
        private string SP__CP_LICENCIA_JUSTIFICADA = "sp_cp_licencia_justificada";
        private string SP_evaluacion_puntaje = "SP_evaluacion_puntaje";
        #endregion

        //INTERFACES
        #region _CP_CONTROLES_PERSONAL
        public override bool Adicionar__cp_controles_personal(cls_cp_controles_personal _cp_controles_personal)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CONTROLES_PERSONAL);

                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.Int32, _cp_controles_personal.cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_cp_per_id", DbType.Int32, _cp_controles_personal.cp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_cp_edificio", DbType.Int32, _cp_controles_personal.cp_edificio);
                CNXSIGRH3.AddInParameter(icom, "p_cp_fecha_inicio", DbType.String, _cp_controles_personal.cp_fecha_inicio);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar__cp_controles_personal(cls_cp_controles_personal _cp_controles_personal)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CONTROLES_PERSONAL);

                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.Int32, _cp_controles_personal.cp_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Actualizar__cp_controles_personal(cls_cp_controles_personal _cp_controles_personal)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CONTROLES_PERSONAL);

                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.Int32, _cp_controles_personal.cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_cp_edificio", DbType.Int32, _cp_controles_personal.cp_edificio);
                CNXSIGRH3.AddInParameter(icom, "p_cp_fecha_inicio", DbType.String, _cp_controles_personal.cp_fecha_inicio);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId__cp_controles_personal(cls_cp_controles_personal _cp_controles_personal)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CONTROLES_PERSONAL);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                _cp_controles_personal.cp_id = Convert.ToInt32(ds.Tables[0].Rows[0]["cp_id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerRegistro__cp_controles_personal(cls_cp_controles_personal _cp_controles_personal)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CONTROLES_PERSONAL);

                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.Int32, _cp_controles_personal.cp_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["cp_id"] != DBNull.Value && ds.Tables[0].Rows[0]["cp_id"].ToString().Trim() != "") { _cp_controles_personal.cp_id = Convert.ToInt32(ds.Tables[0].Rows[0]["cp_id"]); }
                if (ds.Tables[0].Rows[0]["cp_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["cp_per_id"].ToString().Trim() != "") { _cp_controles_personal.cp_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["cp_per_id"]); }
                if (ds.Tables[0].Rows[0]["cp_edificio"] != DBNull.Value && ds.Tables[0].Rows[0]["cp_edificio"].ToString().Trim() != "") { _cp_controles_personal.cp_edificio = Convert.ToInt32(ds.Tables[0].Rows[0]["cp_edificio"]); }
                if (ds.Tables[0].Rows[0]["cp_fecha_inicio"] != DBNull.Value && ds.Tables[0].Rows[0]["cp_fecha_inicio"].ToString().Trim() != "") { _cp_controles_personal.cp_fecha_inicio = Convert.ToString(ds.Tables[0].Rows[0]["cp_fecha_inicio"]); }
                if (ds.Tables[0].Rows[0]["cp_fecha_final"] != DBNull.Value && ds.Tables[0].Rows[0]["cp_fecha_final"].ToString().Trim() != "") { _cp_controles_personal.cp_fecha_final = Convert.ToString(ds.Tables[0].Rows[0]["cp_fecha_final"]); }
                if (ds.Tables[0].Rows[0]["cp_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["cp_estado"].ToString().Trim() != "") { _cp_controles_personal.cp_estado = Convert.ToString(ds.Tables[0].Rows[0]["cp_estado"]); }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaGrilla__cp_controles_personal(string cp_id,
                        string cp_per_id,
                        string cp_edificio,
                        string cp_fecha_inicio,
                        string cp_fecha_final,
                        string cp_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CONTROLES_PERSONAL);

                if (cp_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.Int32, Convert.ToInt32(cp_id)); }
                if (cp_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_per_id", DbType.Int32, Convert.ToInt32(cp_per_id)); }
                if (cp_edificio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_edificio", DbType.Int32, Convert.ToInt32(cp_edificio)); }
                if (cp_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_fecha_inicio", DbType.String, Convert.ToString(cp_fecha_inicio)); }
                if (cp_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_fecha_final", DbType.String, Convert.ToString(cp_fecha_final)); }
                if (cp_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_estado", DbType.String, Convert.ToString(cp_estado)); }

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo__cp_controles_personal()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CONTROLES_PERSONAL);

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
        public override DataSet ListarGrillaEdificio(cls_cp_controles_personal _cp_controles_personal)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CONTROLES_PERSONAL);

                CNXSIGRH3.AddInParameter(icom, "p_cp_per_id", DbType.String, _cp_controles_personal.cp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ListarFiltradoEdificio(cls_cp_controles_personal _cp_controles_personal)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CONTROLES_PERSONAL);

                CNXSIGRH3.AddInParameter(icom, "p_cp_per_id", DbType.String, _cp_controles_personal.cp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtieneAsignacionEdicioX(cls_cp_controles_personal _cp_controles_personal)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CONTROLES_PERSONAL);

                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.String, _cp_controles_personal.cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarFechaBaja(cls_cp_controles_personal _cp_controles_personal)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CONTROLES_PERSONAL);

                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.Int32, _cp_controles_personal.cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_cp_fecha_final", DbType.String, _cp_controles_personal.cp_fecha_final);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ListarFiltradoEdificioEditar(cls_cp_controles_personal _cp_controles_personal)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CONTROLES_PERSONAL);

                CNXSIGRH3.AddInParameter(icom, "p_cp_per_id", DbType.String, _cp_controles_personal.cp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_cp_edificio", DbType.String, _cp_controles_personal.cp_edificio);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _CP_CIERRE_MENSUAL
        public override bool Adicionar__cp_cierre_mensual(cls_cp_cierre_mensual _cp_cierre_mensual)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CIERRE_MENSUAL);
                CNXSIGRH3.AddInParameter(icom, "p_cm_id", DbType.Int32, _cp_cierre_mensual.cm_id);
                CNXSIGRH3.AddInParameter(icom, "p_cm_fecha_inicio", DbType.Date, _cp_cierre_mensual.cm_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_cm_fecha_final", DbType.Date, _cp_cierre_mensual.cm_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_cm_estado", DbType.String, _cp_cierre_mensual.cm_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__cp_cierre_mensual(cls_cp_cierre_mensual _cp_cierre_mensual)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CIERRE_MENSUAL);
                CNXSIGRH3.AddInParameter(icom, "p_cm_id", DbType.Int32, _cp_cierre_mensual.cm_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__cp_cierre_mensual(cls_cp_cierre_mensual _cp_cierre_mensual)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CIERRE_MENSUAL);
                CNXSIGRH3.AddInParameter(icom, "p_cm_id", DbType.Int32, _cp_cierre_mensual.cm_id);
                CNXSIGRH3.AddInParameter(icom, "p_cm_fecha_inicio", DbType.Date, _cp_cierre_mensual.cm_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_cm_fecha_final", DbType.Date, _cp_cierre_mensual.cm_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_cm_estado", DbType.String, _cp_cierre_mensual.cm_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerId__cp_cierre_mensual(cls_cp_cierre_mensual _cp_cierre_mensual)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CIERRE_MENSUAL);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                _cp_cierre_mensual.cm_id = Convert.ToInt32(ds.Tables[0].Rows[0]["cm_id"]);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__cp_cierre_mensual(cls_cp_cierre_mensual _cp_cierre_mensual)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CIERRE_MENSUAL);
                CNXSIGRH3.AddInParameter(icom, "p_cm_id", DbType.Int32, _cp_cierre_mensual.cm_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__cp_cierre_mensual(
            string cm_id,
            string cm_fecha_inicio,
            string cm_fecha_final,
            string cm_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CIERRE_MENSUAL);

                if (cm_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cm_id", DbType.Int32, Convert.ToInt32(cm_id)); }
                if (cm_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cm_fecha_inicio", DbType.Date, Convert.ToDateTime(cm_fecha_inicio)); }
                if (cm_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cm_fecha_final", DbType.Date, Convert.ToDateTime(cm_fecha_final)); }
                if (cm_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cm_estado", DbType.String, Convert.ToString(cm_estado)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__cp_cierre_mensual()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_CIERRE_MENSUAL);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
        #region _CP_SANCIONES_REL_CIERRE
        public override bool Adicionar__cp_sanciones_rel_cierre(cls_cp_sanciones_rel_cierre _cp_sanciones_rel_cierre)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES_REL_CIERRE);
                CNXSIGRH3.AddInParameter(icom, "p_src_sa_id", DbType.Int32, _cp_sanciones_rel_cierre.src_sa_id);
                CNXSIGRH3.AddInParameter(icom, "p_src_cp_id", DbType.Int32, _cp_sanciones_rel_cierre.src_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_src_cm_id", DbType.Int32, _cp_sanciones_rel_cierre.src_cm_id);
                CNXSIGRH3.AddInParameter(icom, "p_src_fecha_ejecucion", DbType.Date, _cp_sanciones_rel_cierre.src_fecha_ejecucion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__cp_sanciones_rel_cierre(cls_cp_sanciones_rel_cierre _cp_sanciones_rel_cierre)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES_REL_CIERRE);
                CNXSIGRH3.AddInParameter(icom, "p_src_sa_id", DbType.Int32, _cp_sanciones_rel_cierre.src_sa_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__cp_sanciones_rel_cierre(cls_cp_sanciones_rel_cierre _cp_sanciones_rel_cierre)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES_REL_CIERRE);
                CNXSIGRH3.AddInParameter(icom, "p_src_sa_id", DbType.Int32, _cp_sanciones_rel_cierre.src_sa_id);
                CNXSIGRH3.AddInParameter(icom, "p_src_cp_id", DbType.Int32, _cp_sanciones_rel_cierre.src_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_src_cm_id", DbType.Int32, _cp_sanciones_rel_cierre.src_cm_id);
                CNXSIGRH3.AddInParameter(icom, "p_src_fecha_ejecucion", DbType.Date, _cp_sanciones_rel_cierre.src_fecha_ejecucion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__cp_sanciones_rel_cierre(cls_cp_sanciones_rel_cierre _cp_sanciones_rel_cierre)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES_REL_CIERRE);
                CNXSIGRH3.AddInParameter(icom, "p_src_sa_id", DbType.Int32, _cp_sanciones_rel_cierre.src_sa_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__cp_sanciones_rel_cierre(
            string src_sa_id,
            string src_cp_id,
            string src_cm_id,
            string src_fecha_ejecucion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES_REL_CIERRE);

                if (src_sa_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_src_sa_id", DbType.Int32, Convert.ToInt32(src_sa_id)); }
                if (src_cp_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_src_cp_id", DbType.Int32, Convert.ToInt32(src_cp_id)); }
                if (src_cm_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_src_cm_id", DbType.Int32, Convert.ToInt32(src_cm_id)); }
                if (src_fecha_ejecucion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_src_fecha_ejecucion", DbType.Date, Convert.ToDateTime(src_fecha_ejecucion)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__cp_sanciones_rel_cierre()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES_REL_CIERRE);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _CP_SANCIONES
        public override int UpdateFaltas(int per_id, string fecha_ini, string fecha_fin)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("UPDATE_FALTAS");
                CNXSIGRH3.AddInParameter(icom, "COD_PER", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "FECHA1", DbType.String, fecha_ini);
                CNXSIGRH3.AddInParameter(icom, "FECHA2", DbType.String, fecha_fin);
                //CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                return CNXSIGRH3.ExecuteNonQuery(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool Adicionar__cp_sanciones(cls_cp_sanciones _cp_sanciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES);
                CNXSIGRH3.AddInParameter(icom, "p_sa_id", DbType.Int32, _cp_sanciones.sa_id);
                CNXSIGRH3.AddInParameter(icom, "p_sa_per_id", DbType.Int32, _cp_sanciones.sa_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_sa_factor", DbType.Int32, _cp_sanciones.sa_factor);
                CNXSIGRH3.AddInParameter(icom, "p_sa_minutos", DbType.Int32, _cp_sanciones.sa_minutos);
                CNXSIGRH3.AddInParameter(icom, "p_sa_fecha_inicio", DbType.Date, _cp_sanciones.sa_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_sa_fecha_fin", DbType.Date, _cp_sanciones.sa_fecha_fin);
                //CNXSIGRH3.AddInParameter(icom, "p_sa_tipo_sancion", DbType.String, _cp_sanciones.sa_tipo_sancion);
                CNXSIGRH3.AddInParameter(icom, "p_sa_dias_sancion", DbType.Double, _cp_sanciones.sa_dias_sancion);
                //CNXSIGRH3.AddInParameter(icom, "p_sa_estado", DbType.String, _cp_sanciones.sa_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool Adicionar__cp_sanciones_faltasDocentes(cls_cp_sanciones _cp_sanciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES);
                CNXSIGRH3.AddInParameter(icom, "p_sa_id", DbType.Int32, _cp_sanciones.sa_id);
                CNXSIGRH3.AddInParameter(icom, "p_sa_per_id", DbType.Int32, _cp_sanciones.sa_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_sa_factor", DbType.Int32, _cp_sanciones.sa_factor);
                CNXSIGRH3.AddInParameter(icom, "p_sa_minutos", DbType.Int32, _cp_sanciones.sa_minutos);
                CNXSIGRH3.AddInParameter(icom, "p_sa_fecha_inicio", DbType.Date, _cp_sanciones.sa_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_sa_fecha_fin", DbType.Date, _cp_sanciones.sa_fecha_fin);
                //CNXSIGRH3.AddInParameter(icom, "p_sa_tipo_sancion", DbType.String, _cp_sanciones.sa_tipo_sancion);
                CNXSIGRH3.AddInParameter(icom, "p_sa_dias_sancion", DbType.Double, _cp_sanciones.sa_dias_sancion);
                //CNXSIGRH3.AddInParameter(icom, "p_sa_estado", DbType.String, _cp_sanciones.sa_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "AA");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool Eliminar__cp_sanciones(cls_cp_sanciones _cp_sanciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES);
                CNXSIGRH3.AddInParameter(icom, "p_sa_id", DbType.Int32, _cp_sanciones.sa_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__cp_sanciones(cls_cp_sanciones _cp_sanciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES);
                CNXSIGRH3.AddInParameter(icom, "p_sa_id", DbType.Int32, _cp_sanciones.sa_id);
                CNXSIGRH3.AddInParameter(icom, "p_sa_estado", DbType.String, _cp_sanciones.sa_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerId__cp_sanciones(cls_cp_sanciones _cp_sanciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                _cp_sanciones.sa_id = Convert.ToInt32(ds.Tables[0].Rows[0]["sa_id"]);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__cp_sanciones(cls_cp_sanciones _cp_sanciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES);
                CNXSIGRH3.AddInParameter(icom, "p_sa_id", DbType.Int32, _cp_sanciones.sa_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__cp_sanciones(
            string sa_id,
            string sa_per_id,
            string sa_factor,
            string sa_minutos,
            string sa_fecha_inicio,
            string sa_fecha_fin,
            string sa_tipo_sancion,
            string sa_dias_sancion,
            string sa_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES);

                if (sa_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_sa_id", DbType.Int32, Convert.ToInt32(sa_id)); }
                if (sa_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_sa_per_id", DbType.Int32, Convert.ToInt32(sa_per_id)); }
                if (sa_factor.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_sa_factor", DbType.Int32, Convert.ToInt32(sa_factor)); }
                if (sa_minutos.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_sa_minutos", DbType.Int32, Convert.ToInt32(sa_minutos)); }
                if (sa_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_sa_fecha_inicio", DbType.Date, Convert.ToDateTime(sa_fecha_inicio)); }
                if (sa_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_sa_fecha_fin", DbType.Date, Convert.ToDateTime(sa_fecha_fin)); }
                if (sa_tipo_sancion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_sa_tipo_sancion", DbType.String, Convert.ToString(sa_tipo_sancion)); }
                if (sa_dias_sancion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_sa_dias_sancion", DbType.Double, Convert.ToDouble(sa_dias_sancion)); }
                if (sa_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_sa_estado", DbType.String, Convert.ToString(sa_estado)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__cp_sanciones()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos)
        public override DataSet ObtenerTablaGrillaC__cp_sanciones(
            //string cp_da,
            //string cp_ue,
            //string cp_programa,
            //string cp_proyecto,
            //string cp_actividad,
            string sa_per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string ps_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES);

                //if (cp_da.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_da", DbType.Int32, Convert.ToInt32(cp_da)); }
                //if (cp_ue.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_ue", DbType.Int32, Convert.ToInt32(cp_ue)); }
                //if (cp_programa.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_programa", DbType.Int32, Convert.ToInt32(cp_programa)); }
                //if (cp_proyecto.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_proyecto", DbType.Int32, Convert.ToInt32(cp_proyecto)); }
                //if (cp_actividad.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_actividad", DbType.Int32, Convert.ToInt32(cp_actividad)); }
                if (sa_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_sa_per_id", DbType.Int32, Convert.ToInt32(sa_per_id)); }
                if (per_num_doc.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, Convert.ToString(per_num_doc)); }
                if (per_ap_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, Convert.ToString(per_ap_paterno)); }
                if (per_ap_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, Convert.ToString(per_ap_materno)); }
                if (per_nombres.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, Convert.ToString(per_nombres)); }
                if (ps_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ps_id", DbType.Int32, Convert.ToInt32(ps_id)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos)
        public override DataSet ObtenerRegistroDS__cp_sanciones(cls_cp_sanciones _cp_sanciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES);
                CNXSIGRH3.AddInParameter(icom, "p_sa_minutos", DbType.Int32, _cp_sanciones.sa_minutos);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ActualizarRegistroSanciones(cls_cp_sanciones _cp_sanciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cp_sanciones");
                CNXSIGRH3.AddInParameter(icom, "p_sa_id", DbType.Int32, _cp_sanciones.sa_id);
                CNXSIGRH3.AddInParameter(icom, "p_sa_dias_sancion", DbType.Double, _cp_sanciones.sa_dias_sancion);
                CNXSIGRH3.AddInParameter(icom, "p_sa_fecha_inicio", DbType.Date, _cp_sanciones.sa_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_sa_fecha_fin", DbType.Date, _cp_sanciones.sa_fecha_fin);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "CC");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ListarAsignacionesParaSancion(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES);
                CNXSIGRH3.AddInParameter(icom, "p_sa_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ListarMesesParaSancion()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_SANCIONES);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _CP_ASIGNACION_HORARIO
        public override bool Eliminar__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_ah_id", DbType.Int32, _cp_asignacion_horario.ah_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_ah_id", DbType.Int32, _cp_asignacion_horario.ah_id);
                CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, _cp_asignacion_horario.ah_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ah_tipo_horario", DbType.Int32, _cp_asignacion_horario.ah_tipo_horario);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, _cp_asignacion_horario.ah_fecha_inicial);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, _cp_asignacion_horario.ah_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_ah_lun_ing1", DbType.DateTime, _cp_asignacion_horario.ah_lun_ing1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_lun_sal1", DbType.DateTime, _cp_asignacion_horario.ah_lun_sal1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_lun_ing2", DbType.DateTime, _cp_asignacion_horario.ah_lun_ing2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_lun_sal2", DbType.DateTime, _cp_asignacion_horario.ah_lun_sal2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_mar_ing1", DbType.DateTime, _cp_asignacion_horario.ah_mar_ing1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_mar_sal1", DbType.DateTime, _cp_asignacion_horario.ah_mar_sal1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_mar_ing2", DbType.DateTime, _cp_asignacion_horario.ah_mar_ing2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_mar_sal2", DbType.DateTime, _cp_asignacion_horario.ah_mar_sal2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_mie_ing1", DbType.DateTime, _cp_asignacion_horario.ah_mie_ing1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_mie_sal1", DbType.DateTime, _cp_asignacion_horario.ah_mie_sal1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_mie_ing2", DbType.DateTime, _cp_asignacion_horario.ah_mie_ing2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_mie_sal2", DbType.DateTime, _cp_asignacion_horario.ah_mie_sal2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_jue_ing1", DbType.DateTime, _cp_asignacion_horario.ah_jue_ing1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_jue_sal1", DbType.DateTime, _cp_asignacion_horario.ah_jue_sal1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_jue_ing2", DbType.DateTime, _cp_asignacion_horario.ah_jue_ing2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_jue_sal2", DbType.DateTime, _cp_asignacion_horario.ah_jue_sal2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_vie_ing1", DbType.DateTime, _cp_asignacion_horario.ah_vie_ing1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_vie_sal1", DbType.DateTime, _cp_asignacion_horario.ah_vie_sal1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_vie_ing2", DbType.DateTime, _cp_asignacion_horario.ah_vie_ing2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_vie_sal2", DbType.DateTime, _cp_asignacion_horario.ah_vie_sal2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_sab_ing1", DbType.DateTime, _cp_asignacion_horario.ah_sab_ing1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_sab_sal1", DbType.DateTime, _cp_asignacion_horario.ah_sab_sal1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_sab_ing2", DbType.DateTime, _cp_asignacion_horario.ah_sab_ing2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_sab_sal2", DbType.DateTime, _cp_asignacion_horario.ah_sab_sal2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_dom_ing1", DbType.DateTime, _cp_asignacion_horario.ah_dom_ing1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_dom_sal1", DbType.DateTime, _cp_asignacion_horario.ah_dom_sal1);
                CNXSIGRH3.AddInParameter(icom, "p_ah_dom_ing2", DbType.DateTime, _cp_asignacion_horario.ah_dom_ing2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_dom_sal2", DbType.DateTime, _cp_asignacion_horario.ah_dom_sal2);
                CNXSIGRH3.AddInParameter(icom, "p_ah_json", DbType.Int32, _cp_asignacion_horario.ah_json);
                CNXSIGRH3.AddInParameter(icom, "p_ah_estado", DbType.String, _cp_asignacion_horario.ah_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__cp_asignacion_horario(
            string ah_id,
            string ah_per_id,
            string ah_tipo_horario,
            string ah_fecha_inicial,
            string ah_fecha_final,
            string ah_lun_ing1,
            string ah_lun_sal1,
            string ah_lun_ing2,
            string ah_lun_sal2,
            string ah_mar_ing1,
            string ah_mar_sal1,
            string ah_mar_ing2,
            string ah_mar_sal2,
            string ah_mie_ing1,
            string ah_mie_sal1,
            string ah_mie_ing2,
            string ah_mie_sal2,
            string ah_jue_ing1,
            string ah_jue_sal1,
            string ah_jue_ing2,
            string ah_jue_sal2,
            string ah_vie_ing1,
            string ah_vie_sal1,
            string ah_vie_ing2,
            string ah_vie_sal2,
            string ah_sab_ing1,
            string ah_sab_sal1,
            string ah_sab_ing2,
            string ah_sab_sal2,
            string ah_dom_ing1,
            string ah_dom_sal1,
            string ah_dom_ing2,
            string ah_dom_sal2,
            string ah_json,
            string ah_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);

                if (ah_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_id", DbType.Int32, Convert.ToInt32(ah_id)); }
                if (ah_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, Convert.ToInt32(ah_per_id)); }
                if (ah_tipo_horario.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_tipo_horario", DbType.Int32, Convert.ToInt32(ah_tipo_horario)); }
                if (ah_fecha_inicial.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, Convert.ToDateTime(ah_fecha_inicial)); }
                if (ah_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, Convert.ToDateTime(ah_fecha_final)); }
                if (ah_lun_ing1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_lun_ing1", DbType.DateTime, Convert.ToDateTime(ah_lun_ing1)); }
                if (ah_lun_sal1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_lun_sal1", DbType.DateTime, Convert.ToDateTime(ah_lun_sal1)); }
                if (ah_lun_ing2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_lun_ing2", DbType.DateTime, Convert.ToDateTime(ah_lun_ing2)); }
                if (ah_lun_sal2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_lun_sal2", DbType.DateTime, Convert.ToDateTime(ah_lun_sal2)); }
                if (ah_mar_ing1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_mar_ing1", DbType.DateTime, Convert.ToDateTime(ah_mar_ing1)); }
                if (ah_mar_sal1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_mar_sal1", DbType.DateTime, Convert.ToDateTime(ah_mar_sal1)); }
                if (ah_mar_ing2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_mar_ing2", DbType.DateTime, Convert.ToDateTime(ah_mar_ing2)); }
                if (ah_mar_sal2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_mar_sal2", DbType.DateTime, Convert.ToDateTime(ah_mar_sal2)); }
                if (ah_mie_ing1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_mie_ing1", DbType.DateTime, Convert.ToDateTime(ah_mie_ing1)); }
                if (ah_mie_sal1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_mie_sal1", DbType.DateTime, Convert.ToDateTime(ah_mie_sal1)); }
                if (ah_mie_ing2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_mie_ing2", DbType.DateTime, Convert.ToDateTime(ah_mie_ing2)); }
                if (ah_mie_sal2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_mie_sal2", DbType.DateTime, Convert.ToDateTime(ah_mie_sal2)); }
                if (ah_jue_ing1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_jue_ing1", DbType.DateTime, Convert.ToDateTime(ah_jue_ing1)); }
                if (ah_jue_sal1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_jue_sal1", DbType.DateTime, Convert.ToDateTime(ah_jue_sal1)); }
                if (ah_jue_ing2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_jue_ing2", DbType.DateTime, Convert.ToDateTime(ah_jue_ing2)); }
                if (ah_jue_sal2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_jue_sal2", DbType.DateTime, Convert.ToDateTime(ah_jue_sal2)); }
                if (ah_vie_ing1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_vie_ing1", DbType.DateTime, Convert.ToDateTime(ah_vie_ing1)); }
                if (ah_vie_sal1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_vie_sal1", DbType.DateTime, Convert.ToDateTime(ah_vie_sal1)); }
                if (ah_vie_ing2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_vie_ing2", DbType.DateTime, Convert.ToDateTime(ah_vie_ing2)); }
                if (ah_vie_sal2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_vie_sal2", DbType.DateTime, Convert.ToDateTime(ah_vie_sal2)); }
                if (ah_sab_ing1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_sab_ing1", DbType.DateTime, Convert.ToDateTime(ah_sab_ing1)); }
                if (ah_sab_sal1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_sab_sal1", DbType.DateTime, Convert.ToDateTime(ah_sab_sal1)); }
                if (ah_sab_ing2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_sab_ing2", DbType.DateTime, Convert.ToDateTime(ah_sab_ing2)); }
                if (ah_sab_sal2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_sab_sal2", DbType.DateTime, Convert.ToDateTime(ah_sab_sal2)); }
                if (ah_dom_ing1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_dom_ing1", DbType.DateTime, Convert.ToDateTime(ah_dom_ing1)); }
                if (ah_dom_sal1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_dom_sal1", DbType.DateTime, Convert.ToDateTime(ah_dom_sal1)); }
                if (ah_dom_ing2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_dom_ing2", DbType.DateTime, Convert.ToDateTime(ah_dom_ing2)); }
                if (ah_dom_sal2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_dom_sal2", DbType.DateTime, Convert.ToDateTime(ah_dom_sal2)); }
                if (ah_json.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_json", DbType.String, Convert.ToString(ah_json)); }
                if (ah_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_estado", DbType.String, Convert.ToString(ah_estado)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos) Lista de todos los registros de la tabla
        public override DataSet ObtenerTablaGrillaC__cp_asignacion_horario(
            string ah_id,
            string ah_per_id,
            string ah_tipo_horario,
            string ah_fecha_inicial,
            string ah_fecha_final,
            string ah_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                if (ah_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_id", DbType.Int32, Convert.ToInt32(ah_id)); }
                if (ah_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, Convert.ToInt32(ah_per_id)); }
                if (ah_tipo_horario.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_tipo_horario", DbType.Int32, Convert.ToInt32(ah_tipo_horario)); }
                if (ah_fecha_inicial.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, Convert.ToDateTime(ah_fecha_inicial)); }
                if (ah_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, Convert.ToDateTime(ah_fecha_final)); }
                if (ah_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_estado", DbType.String, Convert.ToString(ah_estado)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos) Genera un calendario para horarios
        public override DataSet ObtenerTablaGrillaCH__cp_asignacion_horario(
            string tds_per_id,
            string tds_fecha_inicial,
            string tds_fecha_final)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);

                if (tds_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, Convert.ToInt32(tds_per_id)); }
                if (tds_fecha_inicial.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, Convert.ToDateTime(tds_fecha_inicial)); }
                if (tds_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, Convert.ToDateTime(tds_fecha_final)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = new DataSet();
                ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos) Genera el horario que se mostrará en el calendario
        public override bool GenerarHorario__cp_asignacion_horario(
            string th_per_id,
            string th_ing1,
            string th_sal1,
            string th_ing2,
            string th_sal2,
            string th_tipo,
            string th_tipo_semana,
            string th_tipo_dia,
            string th_lunes,
            string th_martes,
            string th_miercoles,
            string th_jueves,
            string th_viernes,
            string th_sabado,
            string th_domingo,
            string th_tipo_p,
            string th_tipo_t1,
            string th_tipo_t2)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);

                if (th_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, Convert.ToInt32(th_per_id)); }
                if (th_ing1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_ing1", DbType.DateTime, Convert.ToDateTime(th_ing1)); }
                if (th_sal1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_sal1", DbType.DateTime, Convert.ToDateTime(th_sal1)); }
                if (th_ing2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_ing2", DbType.DateTime, Convert.ToDateTime(th_ing2)); }
                if (th_sal2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_sal2", DbType.DateTime, Convert.ToDateTime(th_sal2)); }
                if (th_tipo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo", DbType.Int32, Convert.ToInt32(th_tipo)); }
                if (th_tipo_semana.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo_semana", DbType.Int32, Convert.ToInt32(th_tipo_semana)); }
                if (th_tipo_dia.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo_dia", DbType.Int32, Convert.ToInt32(th_tipo_dia)); }
                if (th_lunes.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_lunes", DbType.Boolean, Convert.ToBoolean(th_lunes)); }
                if (th_martes.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_martes", DbType.Boolean, Convert.ToBoolean(th_martes)); }
                if (th_miercoles.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_miercoles", DbType.Boolean, Convert.ToBoolean(th_miercoles)); }
                if (th_jueves.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_jueves", DbType.Boolean, Convert.ToBoolean(th_jueves)); }
                if (th_viernes.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_viernes", DbType.Boolean, Convert.ToBoolean(th_viernes)); }
                if (th_sabado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_sabado", DbType.Boolean, Convert.ToBoolean(th_sabado)); }
                if (th_domingo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_domingo", DbType.Boolean, Convert.ToBoolean(th_domingo)); }
                if (th_tipo_p.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo_p", DbType.String, Convert.ToString(th_tipo_p)); }
                if (th_tipo_t1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo_t1", DbType.String, Convert.ToString(th_tipo_t1)); }
                if (th_tipo_t2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo_t2", DbType.String, Convert.ToString(th_tipo_t2)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos) Obtiene todos los datos de horario para mostrar en la grilla
        public override DataSet ObtenerTablaGrillaHC__cp_asignacion_horario(
            string th_per_id,
            string th_semana,
            string th_dia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);

                if (th_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, Convert.ToInt32(th_per_id)); }
                if (th_semana.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo_semana", DbType.Int32, Convert.ToInt32(th_semana)); }
                if (th_dia.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo_dia", DbType.Int32, Convert.ToInt32(th_dia)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = new DataSet();
                ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos) Elimina todos los datos del calendario
        public override bool EliminarCH__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, _cp_asignacion_horario.ah_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos) Elimina todos los datos de horario para mostrar en la grilla
        public override bool EliminarHC__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, _cp_asignacion_horario.ah_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        
        //(Kevin Carlos Prado Bustillos) Adicionar los datos del horario que se encuentra en el calendario (grilla)
        public override bool AdicionarHC__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, _cp_asignacion_horario.ah_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ah_tipo_horario", DbType.Int32, _cp_asignacion_horario.ah_tipo_horario);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, _cp_asignacion_horario.ah_fecha_inicial);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, _cp_asignacion_horario.ah_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_ah_autorizado", DbType.String, _cp_asignacion_horario.ah_autorizado);
                CNXSIGRH3.AddInParameter(icom, "p_ah_json", DbType.Int32, _cp_asignacion_horario.ah_json);
                CNXSIGRH3.AddInParameter(icom, "p_gl_fecha_doc", DbType.DateTime, _cp_asignacion_horario.gl_fecha_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_tipo_doc", DbType.Int32, _cp_asignacion_horario.gl_tipo_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_glosa", DbType.String, _cp_asignacion_horario.gl_glosa);
                CNXSIGRH3.AddInParameter(icom, "p_gl_numero_doc", DbType.String, _cp_asignacion_horario.gl_numero_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_usuario", DbType.Int32, _cp_asignacion_horario.gl_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Modifica el horario que se mostrará en el calendario
        public override bool ModificarHC__cp_asignacion_horario(
            string th_per_id,
            string th_semana,
            string th_dia,
            string th_ing1,
            string th_sal1,
            string th_ing2,
            string th_sal2,
            string th_tipo_p,
            string th_tipo_t1,
            string th_tipo_t2)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);

                if (th_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, Convert.ToInt32(th_per_id)); }
                if (th_semana.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo_semana", DbType.Int32, Convert.ToInt32(th_semana)); }
                if (th_dia.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo_dia", DbType.Int32, Convert.ToInt32(th_dia)); }
                if (th_ing1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_ing1", DbType.DateTime, Convert.ToDateTime(th_ing1)); }
                if (th_sal1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_sal1", DbType.DateTime, Convert.ToDateTime(th_sal1)); }
                if (th_ing2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_ing2", DbType.DateTime, Convert.ToDateTime(th_ing2)); }
                if (th_sal2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_sal2", DbType.DateTime, Convert.ToDateTime(th_sal2)); }
                if (th_tipo_p.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo_p", DbType.String, Convert.ToString(th_tipo_p)); }
                if (th_tipo_t1.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo_t1", DbType.String, Convert.ToString(th_tipo_t1)); }
                if (th_tipo_t2.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_th_tipo_t2", DbType.String, Convert.ToString(th_tipo_t2)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Genera el horario que se mostrará en el calendario según rango de fechas
        public override bool ObtenerTablaGrillaVM__cp_asignacion_horario(
            string ah_per_id,
            string ah_fecha_inicial,
            string ah_fecha_final)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);

                if (ah_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, Convert.ToInt32(ah_per_id)); }
                if (ah_fecha_inicial.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, Convert.ToDateTime(ah_fecha_inicial)); }
                if (ah_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, Convert.ToDateTime(ah_fecha_final)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                CNXSIGRH3.ExecuteDataSet(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Obtener todos los registros según rango de fechas para mostrar el horario
        public override DataSet ObtenerTablaGrillaFH__cp_asignacion_horario(
            string ah_per_id,
            string ah_fecha_inicial,
            string ah_fecha_final)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);

                if (ah_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, Convert.ToInt32(ah_per_id)); }
                if (ah_fecha_inicial.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, Convert.ToDateTime(ah_fecha_inicial)); }
                if (ah_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, Convert.ToDateTime(ah_fecha_final)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = new DataSet();
                ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        /**********************************************************************/
        /******************** MÉTODOS PROCESAMIENTO MASIVO ********************/
        /**********************************************************************/
        // (Kevin Carlos Prado Bustillos) Obtener todos los registros para llenar una grilla
        public override DataSet ObtenerTablaGrillaUFI__cp_asignacion_horario(
            string prma_id,
            string prma_tipo,
            string prma_descripcion,
            string prma_ei_id,
            string prma_ti_id,
            string prma_usuario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);

                if (prma_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_prma_id", DbType.Int32, Convert.ToInt32(prma_id)); }
                if (prma_tipo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_prma_tipo", DbType.String, Convert.ToString(prma_tipo)); }
                if (prma_descripcion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_prma_descripcion", DbType.String, Convert.ToString(prma_descripcion)); }
                if (prma_ei_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_prma_ei_id", DbType.Int32, Convert.ToInt32(prma_ei_id)); }
                if (prma_ti_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_prma_ti_id", DbType.String, Convert.ToString(prma_ti_id)); }
                if (prma_usuario.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, Convert.ToInt32(prma_usuario)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                DataSet ds = new DataSet();
                ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Adicionar datos del edificio
        public override bool AdicionarEI__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_prma_id", DbType.Int32, _cp_asignacion_horario.prma_id);
                CNXSIGRH3.AddInParameter(icom, "p_prma_tipo", DbType.String, _cp_asignacion_horario.prma_tipo);
                CNXSIGRH3.AddInParameter(icom, "p_prma_descripcion", DbType.String, _cp_asignacion_horario.prma_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, _cp_asignacion_horario.prma_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Adicionar datos de los edificios (según el tipo item)
        public override bool AdicionarIEI__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, _cp_asignacion_horario.ah_fecha_inicial);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, _cp_asignacion_horario.ah_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_prma_ti_id", DbType.String, _cp_asignacion_horario.prma_ti_id);
                CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, _cp_asignacion_horario.prma_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Eliminar datos del edificio, funcionario o tipo ítem (seleccionado o todos)
        public override bool EliminarEIDFTI__cp_asignacion_horario(
            string prma_id,
            string prma_tipo,
            string prma_ei_id,
            string prma_ti_id,
            string prma_usuario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);

                if (prma_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_prma_id", DbType.Int32, Convert.ToInt32(prma_id)); }
                if (prma_tipo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_prma_tipo", DbType.String, Convert.ToString(prma_tipo)); }
                if (prma_ei_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_prma_ei_id", DbType.Int32, Convert.ToInt32(prma_ei_id)); }
                if (prma_ti_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_prma_ti_id", DbType.String, Convert.ToString(prma_ti_id)); }
                if (prma_usuario.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, Convert.ToInt32(prma_usuario)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) LLenar datos de todos los edificios
        public override bool LLenarEI__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, _cp_asignacion_horario.prma_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A4");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Adicionar datos del funcionario
        public override bool AdicionarDF__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_ah_per_id", DbType.Int32, _cp_asignacion_horario.ah_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, _cp_asignacion_horario.ah_fecha_inicial);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, _cp_asignacion_horario.ah_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, _cp_asignacion_horario.prma_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Adicionar datos de los funcionario (según el edificio)
        public override bool AdicionarEDF__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_prma_ei_id", DbType.Int32, _cp_asignacion_horario.prma_ei_id);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, _cp_asignacion_horario.ah_fecha_inicial);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, _cp_asignacion_horario.ah_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, _cp_asignacion_horario.prma_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A6");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Llenar datos de todos los funcionarios
        public override bool LlenarDF__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, _cp_asignacion_horario.ah_fecha_inicial);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, _cp_asignacion_horario.ah_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, _cp_asignacion_horario.prma_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A7");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Adicionar datos del tipo de ítem
        public override bool AdicionarTI__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, _cp_asignacion_horario.ah_fecha_inicial);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, _cp_asignacion_horario.ah_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_prma_ti_id", DbType.String, _cp_asignacion_horario.prma_ti_id);
                CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, _cp_asignacion_horario.prma_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A8");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Llenar datos de todos los tipo de ítem
        public override DataSet LlenarTI__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, _cp_asignacion_horario.prma_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = new DataSet();
                ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Adiciona los datos del horario especial para cada funcionario (masivo)
        public override bool AdicionarHEM__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, _cp_asignacion_horario.prma_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_ah_tipo_horario", DbType.Int32, _cp_asignacion_horario.ah_tipo_horario);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, _cp_asignacion_horario.ah_fecha_inicial);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.Date, _cp_asignacion_horario.ah_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_he_tipo_marc", DbType.String, _cp_asignacion_horario.he_tipo_marc);
                CNXSIGRH3.AddInParameter(icom, "p_he_ing1", DbType.DateTime, _cp_asignacion_horario.he_ing1);
                CNXSIGRH3.AddInParameter(icom, "p_he_sal1", DbType.DateTime, _cp_asignacion_horario.he_sal1);
                CNXSIGRH3.AddInParameter(icom, "p_he_ing2", DbType.DateTime, _cp_asignacion_horario.he_ing2);
                CNXSIGRH3.AddInParameter(icom, "p_he_sal2", DbType.DateTime, _cp_asignacion_horario.he_sal2);
                CNXSIGRH3.AddInParameter(icom, "p_he_autoriza", DbType.String, _cp_asignacion_horario.he_autoriza);
                CNXSIGRH3.AddInParameter(icom, "p_gl_fecha_doc", DbType.DateTime, _cp_asignacion_horario.gl_fecha_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_tipo_doc", DbType.Int32, _cp_asignacion_horario.gl_tipo_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_glosa", DbType.String, _cp_asignacion_horario.gl_glosa);
                CNXSIGRH3.AddInParameter(icom, "p_gl_numero_doc", DbType.String, _cp_asignacion_horario.gl_numero_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_usuario", DbType.Int32, _cp_asignacion_horario.gl_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A9");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Adiciona los datos del horario que se encuentra en el calendario (grilla) para cada funcionario (masivo)
        public override bool AdicionarHCM__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, _cp_asignacion_horario.prma_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_ah_tipo_horario", DbType.Int32, _cp_asignacion_horario.ah_tipo_horario);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, _cp_asignacion_horario.ah_fecha_inicial);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, _cp_asignacion_horario.ah_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_ah_autorizado", DbType.String, _cp_asignacion_horario.ah_autorizado);
                CNXSIGRH3.AddInParameter(icom, "p_gl_fecha_doc", DbType.DateTime, _cp_asignacion_horario.gl_fecha_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_tipo_doc", DbType.Int32, _cp_asignacion_horario.gl_tipo_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_glosa", DbType.String, _cp_asignacion_horario.gl_glosa);
                CNXSIGRH3.AddInParameter(icom, "p_gl_usuario", DbType.Int32, _cp_asignacion_horario.gl_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A10");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Adiciona los datos de la licencia justificada para cada funcionario (masivo)
        public override DataSet AdicionarLJM__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_ASIGNACION_HORARIO);
                CNXSIGRH3.AddInParameter(icom, "p_prma_usuario", DbType.Int32, _cp_asignacion_horario.prma_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_lj_tipo_licencia", DbType.Int32, _cp_asignacion_horario.lj_tipo_licencia);
                CNXSIGRH3.AddInParameter(icom, "p_lj_tipo_funcionario", DbType.String, _cp_asignacion_horario.lj_tipo_funcionario);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_inicial", DbType.DateTime, _cp_asignacion_horario.ah_fecha_inicial);
                CNXSIGRH3.AddInParameter(icom, "p_ah_fecha_final", DbType.DateTime, _cp_asignacion_horario.ah_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_lj_hora_salida", DbType.DateTime, _cp_asignacion_horario.lj_hora_salida);
                CNXSIGRH3.AddInParameter(icom, "p_lj_hora_retorno", DbType.DateTime, _cp_asignacion_horario.lj_hora_retorno);
                CNXSIGRH3.AddInParameter(icom, "p_lj_motivo", DbType.String, _cp_asignacion_horario.lj_motivo);
                CNXSIGRH3.AddInParameter(icom, "p_lj_lugar", DbType.String, _cp_asignacion_horario.lj_lugar);
                CNXSIGRH3.AddInParameter(icom, "p_lj_per_id_autoriza", DbType.String, _cp_asignacion_horario.lj_per_id_autoriza);
                CNXSIGRH3.AddInParameter(icom, "p_gl_fecha_doc", DbType.DateTime, _cp_asignacion_horario.gl_fecha_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_tipo_doc", DbType.Int32, _cp_asignacion_horario.gl_tipo_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_glosa", DbType.String, _cp_asignacion_horario.gl_glosa);
                CNXSIGRH3.AddInParameter(icom, "p_gl_numero_doc", DbType.String, _cp_asignacion_horario.gl_numero_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_usuario", DbType.Int32, _cp_asignacion_horario.gl_usuario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A11");
                DataSet ds = new DataSet();
                ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion


        #region _CP_MARCACIONES
        public override bool Adicionar__cp_marcaciones(cls_cp_marcaciones _cp_marcaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_MARCACIONES);
                CNXSIGRH3.AddInParameter(icom, "p_ma_id", DbType.Int32, _cp_marcaciones.ma_id);
                CNXSIGRH3.AddInParameter(icom, "p_ma_per_id", DbType.Int32, _cp_marcaciones.ma_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ma_fecha", DbType.DateTime, _cp_marcaciones.ma_fecha);
                CNXSIGRH3.AddInParameter(icom, "p_ma_di_id", DbType.Int32, _cp_marcaciones.ma_di_id);
                CNXSIGRH3.AddInParameter(icom, "p_ma_hora", DbType.DateTime, _cp_marcaciones.ma_hora);
                CNXSIGRH3.AddInParameter(icom, "p_ma_tipo", DbType.String, _cp_marcaciones.ma_tipo);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__cp_marcaciones(cls_cp_marcaciones _cp_marcaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_MARCACIONES);
                CNXSIGRH3.AddInParameter(icom, "p_ma_id", DbType.Int32, _cp_marcaciones.ma_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__cp_marcaciones(cls_cp_marcaciones _cp_marcaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_MARCACIONES);
                CNXSIGRH3.AddInParameter(icom, "p_ma_id", DbType.Int32, _cp_marcaciones.ma_id);
                CNXSIGRH3.AddInParameter(icom, "p_ma_per_id", DbType.Int32, _cp_marcaciones.ma_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ma_fecha", DbType.DateTime, _cp_marcaciones.ma_fecha);
                CNXSIGRH3.AddInParameter(icom, "p_ma_di_id", DbType.Int32, _cp_marcaciones.ma_di_id);
                CNXSIGRH3.AddInParameter(icom, "p_ma_hora", DbType.DateTime, _cp_marcaciones.ma_hora);
                CNXSIGRH3.AddInParameter(icom, "p_ma_estado", DbType.String, _cp_marcaciones.ma_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ma_tipo", DbType.String, _cp_marcaciones.ma_tipo);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerId__cp_marcaciones(cls_cp_marcaciones _cp_marcaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_MARCACIONES);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                _cp_marcaciones.ma_id = Convert.ToInt32(ds.Tables[0].Rows[0]["ma_id"]);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__cp_marcaciones(cls_cp_marcaciones _cp_marcaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_MARCACIONES);
                CNXSIGRH3.AddInParameter(icom, "p_ma_id", DbType.Int32, _cp_marcaciones.ma_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__cp_marcaciones(
            string ma_id,
            string ma_per_id,
            string ma_fecha,
            string ma_di_id,
            string ma_hora,
            string ma_estado,
            string ma_tipo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_MARCACIONES);
                if (ma_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ma_id", DbType.Int32, Convert.ToInt32(ma_id)); }
                if (ma_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ma_per_id", DbType.Int32, Convert.ToInt32(ma_per_id)); }
                if (ma_fecha.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ma_fecha", DbType.DateTime, Convert.ToDateTime(ma_fecha)); }
                if (ma_di_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ma_di_id", DbType.Int32, Convert.ToInt32(ma_di_id)); }
                if (ma_hora.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ma_hora", DbType.DateTime, Convert.ToDateTime(ma_hora)); }
                if (ma_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ma_estado", DbType.String, Convert.ToString(ma_estado)); }
                if (ma_tipo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ma_tipo", DbType.String, Convert.ToString(ma_tipo)); }

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__cp_marcaciones()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_MARCACIONES);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos)
        public override DataSet ObtenerTablaGrillaM__cp_marcaciones(cls_cp_marcaciones _cp_marcaciones)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_MARCACIONES);
                CNXSIGRH3.AddInParameter(icom, "p_ma_per_id", DbType.Int32, _cp_marcaciones.ma_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ma_fecha", DbType.DateTime, _cp_marcaciones.ma_fecha);
                CNXSIGRH3.AddInParameter(icom, "p_ma_fecha_f", DbType.DateTime, _cp_marcaciones.ma_fecha_f);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _CP_UBICACION_FISICA
        public override bool Adicionar__cp_ubicacion_fisica(cls_cp_ubicacion_fisica _cp_ubicacion_fisica)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_UBICACION_FISICA);
                CNXSIGRH3.AddInParameter(icom, "p_uf_per_id", DbType.Int32, _cp_ubicacion_fisica.uf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_uf_edificio", DbType.Int32, _cp_ubicacion_fisica.uf_edificio);
                CNXSIGRH3.AddInParameter(icom, "p_uf_piso", DbType.String, _cp_ubicacion_fisica.uf_piso);
                CNXSIGRH3.AddInParameter(icom, "p_uf_bloque", DbType.String, _cp_ubicacion_fisica.uf_bloque);
                CNXSIGRH3.AddInParameter(icom, "p_uf_telefono_interno", DbType.Int32, _cp_ubicacion_fisica.uf_telefono_interno);
                CNXSIGRH3.AddInParameter(icom, "p_uf_telefono_oficina", DbType.Int32, _cp_ubicacion_fisica.uf_telefono_oficina);
                CNXSIGRH3.AddInParameter(icom, "p_uf_nombre_oficina", DbType.String, _cp_ubicacion_fisica.uf_nombre_oficina);
                CNXSIGRH3.AddInParameter(icom, "p_uf_fecha_inicio", DbType.DateTime, _cp_ubicacion_fisica.uf_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__cp_ubicacion_fisica(cls_cp_ubicacion_fisica _cp_ubicacion_fisica)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_UBICACION_FISICA);
                CNXSIGRH3.AddInParameter(icom, "p_uf_id", DbType.Int32, _cp_ubicacion_fisica.uf_id);
                CNXSIGRH3.AddInParameter(icom, "p_uf_fecha_inicio", DbType.DateTime, _cp_ubicacion_fisica.uf_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__cp_ubicacion_fisica(cls_cp_ubicacion_fisica _cp_ubicacion_fisica)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_UBICACION_FISICA);
                CNXSIGRH3.AddInParameter(icom, "p_uf_id", DbType.Int32, _cp_ubicacion_fisica.uf_id);
                CNXSIGRH3.AddInParameter(icom, "p_uf_per_id", DbType.Int32, _cp_ubicacion_fisica.uf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_uf_edificio", DbType.Int32, _cp_ubicacion_fisica.uf_edificio);
                CNXSIGRH3.AddInParameter(icom, "p_uf_piso", DbType.String, _cp_ubicacion_fisica.uf_piso);
                CNXSIGRH3.AddInParameter(icom, "p_uf_bloque", DbType.String, _cp_ubicacion_fisica.uf_bloque);
                CNXSIGRH3.AddInParameter(icom, "p_uf_telefono_interno", DbType.Int32, _cp_ubicacion_fisica.uf_telefono_interno);
                CNXSIGRH3.AddInParameter(icom, "p_uf_telefono_oficina", DbType.Int32, _cp_ubicacion_fisica.uf_telefono_oficina);
                CNXSIGRH3.AddInParameter(icom, "p_uf_nombre_oficina", DbType.String, _cp_ubicacion_fisica.uf_nombre_oficina);
                CNXSIGRH3.AddInParameter(icom, "p_uf_fecha_inicio", DbType.DateTime, _cp_ubicacion_fisica.uf_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_uf_fecha_final", DbType.DateTime, _cp_ubicacion_fisica.uf_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_uf_estado", DbType.String, _cp_ubicacion_fisica.uf_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__cp_ubicacion_fisica(cls_cp_ubicacion_fisica _cp_ubicacion_fisica)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_UBICACION_FISICA);
                CNXSIGRH3.AddInParameter(icom, "p_uf_id", DbType.Int32, _cp_ubicacion_fisica.uf_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__cp_ubicacion_fisica(
            string uf_id,
            string uf_per_id,
            string uf_edificio,
            string uf_piso,
            string uf_bloque,
            string uf_telefono_interno,
            string uf_telefono_oficina,
            string uf_nombre_oficina,
            string uf_fecha_inicio,
            string uf_fecha_final,
            string uf_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_UBICACION_FISICA);
                if (uf_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_id", DbType.Int32, Convert.ToInt32(uf_id)); }
                if (uf_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_per_id", DbType.Int32, Convert.ToInt32(uf_per_id)); }
                if (uf_edificio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_edificio", DbType.Int32, Convert.ToInt32(uf_edificio)); }
                if (uf_piso.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_piso", DbType.String, Convert.ToString(uf_piso)); }
                if (uf_bloque.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_bloque", DbType.String, Convert.ToString(uf_bloque)); }
                if (uf_telefono_interno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_telefono_interno", DbType.Int32, Convert.ToInt32(uf_telefono_interno)); }
                if (uf_telefono_oficina.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_telefono_oficina", DbType.Int32, Convert.ToInt32(uf_telefono_oficina)); }
                if (uf_nombre_oficina.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_nombre_oficina", DbType.String, Convert.ToString(uf_nombre_oficina)); }
                if (uf_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_fecha_inicio", DbType.DateTime, Convert.ToDateTime(uf_fecha_inicio)); }
                if (uf_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_fecha_final", DbType.DateTime, Convert.ToDateTime(uf_fecha_final)); }
                if (uf_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_estado", DbType.String, Convert.ToString(uf_estado)); }

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__cp_ubicacion_fisica()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_UBICACION_FISICA);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla
        public override DataSet ObtenerTablaGrillaC__cp_ubicacion_fisica(
            string uf_id,
            string uf_per_id,
            string uf_edificio,
            string uf_piso,
            string uf_bloque,
            string uf_telefono_interno,
            string uf_telefono_oficina,
            string uf_nombre_oficina,
            string uf_fecha_inicio,
            string uf_fecha_final,
            string uf_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_UBICACION_FISICA);
                if (uf_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_id", DbType.Int32, Convert.ToInt32(uf_id)); }
                if (uf_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_per_id", DbType.Int32, Convert.ToInt32(uf_per_id)); }
                if (uf_edificio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_edificio", DbType.Int32, Convert.ToInt32(uf_edificio)); }
                if (uf_piso.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_piso", DbType.String, Convert.ToString(uf_piso)); }
                if (uf_bloque.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_bloque", DbType.String, Convert.ToString(uf_bloque)); }
                if (uf_telefono_interno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_telefono_interno", DbType.Int32, Convert.ToInt32(uf_telefono_interno)); }
                if (uf_telefono_oficina.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_telefono_oficina", DbType.Int32, Convert.ToInt32(uf_telefono_oficina)); }
                if (uf_nombre_oficina.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_nombre_oficina", DbType.String, Convert.ToString(uf_nombre_oficina)); }
                if (uf_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_fecha_inicio", DbType.DateTime, Convert.ToDateTime(uf_fecha_inicio)); }
                if (uf_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_fecha_final", DbType.DateTime, Convert.ToDateTime(uf_fecha_final)); }
                if (uf_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_uf_estado", DbType.String, Convert.ToString(uf_estado)); }

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _CP_LICENCIA_JUSTIFICADA
        public override int Adicionar__cp_licencia_justificada(cls_cp_licencia_justificada _cp_licencia_justificada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_lj_per_id", DbType.Int32, _cp_licencia_justificada.lj_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_lj_tipo_licencia", DbType.Int32, _cp_licencia_justificada.lj_tipo_licencia);

                if (_cp_licencia_justificada.lj_fecha_inicial.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_inicial", DbType.DateTime, _cp_licencia_justificada.lj_fecha_inicial); }
                if (_cp_licencia_justificada.lj_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_final", DbType.DateTime, _cp_licencia_justificada.lj_fecha_final); }
                if (_cp_licencia_justificada.lj_fecha_emision.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_emision", DbType.DateTime, _cp_licencia_justificada.lj_fecha_emision); }
                if (_cp_licencia_justificada.lj_hora_salida.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_hora_salida", DbType.DateTime, _cp_licencia_justificada.lj_hora_salida); }
                if (_cp_licencia_justificada.lj_hora_retorno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_hora_retorno", DbType.DateTime, _cp_licencia_justificada.lj_hora_retorno); }
                CNXSIGRH3.AddInParameter(icom, "p_lj_motivo", DbType.String, _cp_licencia_justificada.lj_motivo);
                CNXSIGRH3.AddInParameter(icom, "p_lj_lugar", DbType.String, _cp_licencia_justificada.lj_lugar);
                CNXSIGRH3.AddInParameter(icom, "p_lj_per_id_autoriza", DbType.String, _cp_licencia_justificada.lj_per_id_autoriza);
                CNXSIGRH3.AddInParameter(icom, "p_lj_estado", DbType.String, _cp_licencia_justificada.lj_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");

                object result = CNXSIGRH3.ExecuteScalar(icom);
                if (result == null) return 0;
                int codigo = Convert.ToInt32(result);
                if (codigo < 0) return codigo;  
                return codigo;  
            }
            catch (Exception ex) { throw ex; }
        }

        public override int Eliminar__cp_licencia_justificada(cls_cp_licencia_justificada _cp_licencia_justificada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_lj_id", DbType.Int32, _cp_licencia_justificada.lj_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                return Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom));
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__cp_licencia_justificada(cls_cp_licencia_justificada _cp_licencia_justificada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_lj_id", DbType.Int32, _cp_licencia_justificada.lj_id);
                CNXSIGRH3.AddInParameter(icom, "p_lj_estado", DbType.String, _cp_licencia_justificada.lj_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__cp_licencia_justificada(cls_cp_licencia_justificada _cp_licencia_justificada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_lj_id", DbType.Int32, _cp_licencia_justificada.lj_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__cp_licencia_justificada(
            string lj_id,
            string lj_per_id,
            string lj_tipo_licencia,
            string lj_fecha_inicial,
            string lj_fecha_final,
            string lj_fecha_emision,
            string lj_hora_salida,
            string lj_hora_retorno,
            string lj_motivo,
            string lj_lugar,
            string lj_per_id_autoriza,
            string lj_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);

                if (lj_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_id", DbType.Int32, Convert.ToInt32(lj_id)); }
                if (lj_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_per_id", DbType.Int32, Convert.ToInt32(lj_per_id)); }
                if (lj_tipo_licencia.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_tipo_licencia", DbType.Int32, Convert.ToInt32(lj_tipo_licencia)); }
                if (lj_fecha_inicial.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_inicial", DbType.DateTime, Convert.ToDateTime(lj_fecha_inicial)); }
                if (lj_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_final", DbType.DateTime, Convert.ToDateTime(lj_fecha_final)); }
                if (lj_fecha_emision.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_emision", DbType.DateTime, Convert.ToDateTime(lj_fecha_emision)); }
                if (lj_hora_salida.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_hora_salida", DbType.DateTime, Convert.ToDateTime(lj_hora_salida)); }
                if (lj_hora_retorno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_hora_retorno", DbType.DateTime, Convert.ToDateTime(lj_hora_retorno)); }
                if (lj_motivo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_motivo", DbType.String, Convert.ToString(lj_motivo)); }
                if (lj_lugar.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_lugar", DbType.String, Convert.ToString(lj_lugar)); }
                if (lj_per_id_autoriza.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_per_id_autoriza", DbType.String, Convert.ToString(lj_per_id_autoriza)); }
                if (lj_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_estado", DbType.String, Convert.ToString(lj_estado)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__cp_licencia_justificada()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla para llenar una grilla
        public override DataSet ObtenerTablaGrillaC__cp_licencia_justificada(
            string lj_id,
            string lj_per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string lj_tipo_licencia,
            string lj_fecha_inicial,
            string lj_fecha_final,
            string lj_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);

                if (lj_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_id", DbType.Int32, Convert.ToInt32(lj_id)); }
                if (lj_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_per_id", DbType.Int32, Convert.ToInt32(lj_per_id)); }
                if (lj_tipo_licencia.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_tipo_licencia", DbType.Int32, Convert.ToInt32(lj_tipo_licencia)); }
                if (lj_fecha_inicial.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_inicial", DbType.DateTime, Convert.ToDateTime(lj_fecha_inicial)); }
                if (lj_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_final", DbType.DateTime, Convert.ToDateTime(lj_fecha_final)); }
                if (per_num_doc.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, Convert.ToString(per_num_doc)); }
                if (per_ap_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, Convert.ToString(per_ap_paterno)); }
                if (per_ap_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, Convert.ToString(per_ap_materno)); }
                if (per_nombres.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, Convert.ToString(per_nombres)); }
                if (lj_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_estado", DbType.String, Convert.ToString(lj_estado)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrillaC__VALIDAR_COMISION(
            string lj_id,
            string lj_per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string lj_tipo_licencia,
            string lj_fecha_inicial,
            string lj_fecha_final,
            string lj_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);

                if (lj_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_id", DbType.Int32, Convert.ToInt32(lj_id)); }
                if (lj_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_per_id", DbType.Int32, Convert.ToInt32(lj_per_id)); }
                if (lj_tipo_licencia.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_tipo_licencia", DbType.Int32, Convert.ToInt32(lj_tipo_licencia)); }
                if (lj_fecha_inicial.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_inicial", DbType.DateTime, Convert.ToDateTime(lj_fecha_inicial)); }
                if (lj_fecha_final.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_final", DbType.DateTime, Convert.ToDateTime(lj_fecha_final)); }
                if (per_num_doc.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, Convert.ToString(per_num_doc)); }
                if (per_ap_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, Convert.ToString(per_ap_paterno)); }
                if (per_ap_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, Convert.ToString(per_ap_materno)); }
                if (per_nombres.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, Convert.ToString(per_nombres)); }
                if (lj_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_estado", DbType.String, Convert.ToString(lj_estado)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Lista de inmediatos superiores
        public override DataSet ObtenerTablaComboIS__cp_licencia_justificada(cls_cp_licencia_justificada _cp_licencia_justificada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_lj_per_id", DbType.Int32, _cp_licencia_justificada.lj_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (JQC)
        public override bool AdicionarLicenciaVacacion(cls_cp_licencia_justificada _cp_licencia_justificada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_lj_per_id", DbType.Int32, _cp_licencia_justificada.lj_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_lj_tipo_licencia", DbType.Int32, _cp_licencia_justificada.lj_tipo_licencia);
                CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_inicial", DbType.DateTime, _cp_licencia_justificada.lj_fecha_inicial);
                CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_final", DbType.DateTime, _cp_licencia_justificada.lj_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_lj_hora_salida", DbType.DateTime, _cp_licencia_justificada.lj_hora_salida);
                CNXSIGRH3.AddInParameter(icom, "p_lj_hora_retorno", DbType.DateTime, _cp_licencia_justificada.lj_hora_retorno);
                CNXSIGRH3.AddInParameter(icom, "p_lj_motivo", DbType.String, _cp_licencia_justificada.lj_motivo);
                CNXSIGRH3.AddInParameter(icom, "p_lj_lugar", DbType.String, _cp_licencia_justificada.lj_lugar);
                CNXSIGRH3.AddInParameter(icom, "p_lj_per_id_autoriza", DbType.String, _cp_licencia_justificada.lj_per_id_autoriza);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla (licencias y suspensión sin goce de haberes)
        public override DataSet ObtenerTablaGrillaLS__cp_licencia_justificada()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Modificación de licencia / suspensión sin goce de haberes, bajas médicas
        public override bool ActualizarLSBM__cp_licencia_justificada(cls_cp_licencia_justificada _cp_licencia_justificada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_lj_id", DbType.Int32, _cp_licencia_justificada.lj_id);
                CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_inicial", DbType.DateTime, _cp_licencia_justificada.lj_fecha_inicial);
                CNXSIGRH3.AddInParameter(icom, "p_lj_fecha_final", DbType.DateTime, _cp_licencia_justificada.lj_fecha_final);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "M");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerRegistroFun(cls_cp_licencia_justificada _cp_licencia_justificada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_lj_per_id", DbType.Int32, _cp_licencia_justificada.lj_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerLicenciasSGHFun(cls_cp_licencia_justificada _cp_licencia_justificada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_lj_per_id", DbType.Int32, _cp_licencia_justificada.lj_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla (bajas médicas)
        public override DataSet ObtenerTablaGrillaBM__cp_licencia_justificada(
            string lj_per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                if (lj_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_per_id", DbType.Int32, Convert.ToInt32(lj_per_id)); }
                if (per_num_doc.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, Convert.ToString(per_num_doc)); }
                if (per_ap_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, Convert.ToString(per_ap_paterno)); }
                if (per_ap_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, Convert.ToString(per_ap_materno)); }
                if (per_nombres.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, Convert.ToString(per_nombres)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        //// (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla (validación licencias)
        //public override DataSet ObtenerTablaGrillaVLJ__cp_licencia_justificada(
        //    string lj_id,
        //    string lj_per_id,
        //    string per_num_doc,
        //    string per_ap_paterno,
        //    string per_ap_materno,
        //    string per_nombres,
        //    string lj_estado)
        //{
        //    try
        //    {
        //        DbCommand icom = null;
        //        icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);

        //        if (lj_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_id", DbType.Int32, Convert.ToInt32(lj_id)); }
        //        if (lj_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_per_id", DbType.Int32, Convert.ToInt32(lj_per_id)); }
        //        if (per_num_doc.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, Convert.ToString(per_num_doc)); }
        //        if (per_ap_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, Convert.ToString(per_ap_paterno)); }
        //        if (per_ap_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, Convert.ToString(per_ap_materno)); }
        //        if (per_nombres.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, Convert.ToString(per_nombres)); }
        //        if (lj_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_lj_estado", DbType.String, Convert.ToString(lj_estado)); }
        //        CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
        //        DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
        //        return ds;
        //    }
        //    catch (Exception ex) { throw ex; }
        //}
        public override DataSet VerificarSiCorrespondeBoletaComision(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_lj_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet AutoridadesParaValidarComisiones()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet Grilla_ComisionesSolicitadas(int autoridad_per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_lj_per_id_autoriza", DbType.String, autoridad_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool GenerarAsistencia_UpdateFaltas___LicenciasJustificadas(int per_id, string fecha_inicio, string fecha_fin)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("GenararAsistencia_Individual");
                CNXSIGRH3.AddInParameter(icom, "cod_persona", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "FECHA_INICIO", DbType.String, fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "FECHA_FIN", DbType.String, fecha_fin);
                CNXSIGRH3.ExecuteNonQuery(icom);

                DbCommand icom2 = null;
                icom2 = CNXSIGRH3.GetStoredProcCommand("UPDATE_FALTAS");
                CNXSIGRH3.AddInParameter(icom2, "COD_PER", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom2, "FECHA1", DbType.String, fecha_inicio);
                CNXSIGRH3.AddInParameter(icom2, "FECHA2", DbType.String, fecha_fin);
                CNXSIGRH3.ExecuteNonQuery(icom2);
                
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerSaldoLicencia(int perId, int tipoLicencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__CP_LICENCIA_JUSTIFICADA);
                CNXSIGRH3.AddInParameter(icom, "p_lj_per_id", DbType.Int32, perId);
                CNXSIGRH3.AddInParameter(icom, "p_lj_tipo_licencia", DbType.Int32, tipoLicencia);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Aprobar_comision
        public override bool ActualizarLC(int codigoComisionInput)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_cp_licencia_justificada");
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                CNXSIGRH3.AddInParameter(icom, "codigoComisionInput", DbType.Int32, codigoComisionInput);
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        public override DataSet MesAsistencia()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("ASISTENCIA_STEVE_GENERAL");
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C3");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ListarFuncAsis(string lista)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("ASISTENCIA_STEVE_GENERAL");
                CNXSIGRH3.AddInParameter(icom, "ListPer_id", DbType.String, lista);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C2");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ListarPorFecha(string tipo, string mes)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("ASISTENCIA_STEVE_GENERAL");
                CNXSIGRH3.AddInParameter(icom, "TIPO", DbType.String, tipo);
                CNXSIGRH3.AddInParameter(icom, "MES", DbType.String, mes);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C1");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Procesar(string lista_per_id, string fecha1, string fecha2)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_Aux_asis");
                CNXSIGRH3.AddInParameter(icom, "ListPer_id", DbType.String, lista_per_id);
                CNXSIGRH3.AddInParameter(icom, "Fecha_i", DbType.String, fecha1);
                CNXSIGRH3.AddInParameter(icom, "Fecha_f", DbType.String, fecha2);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "A1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet BuscarFuncionario(string ci)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C1");
                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, ci);
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet cargarDestino()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C2");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet cargarCategoria(string destino)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C3");
                CNXSIGRH3.AddInParameter(icom, "destino", DbType.String, destino.Trim());
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool LlenarGridViatico(int per_id, int ev_id, string tipo_cambio, string fecha1, string fecha2, int as_id, string monto_curso, string objeto, string dias)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "ev_id", DbType.Int32, ev_id);
                CNXSIGRH3.AddInParameter(icom, "ti_cambio", DbType.String, tipo_cambio);
                CNXSIGRH3.AddInParameter(icom, "Fecha_ini", DbType.String, fecha1);
                CNXSIGRH3.AddInParameter(icom, "Fecha_fin", DbType.String, fecha2);
                CNXSIGRH3.AddInParameter(icom, "as_id", DbType.Int32, as_id);
                CNXSIGRH3.AddInParameter(icom, "monto_curso", DbType.Decimal, Convert.ToDecimal(monto_curso));
                CNXSIGRH3.AddInParameter(icom, "objeto", DbType.String, objeto);
                CNXSIGRH3.AddInParameter(icom, "dias", DbType.String, Convert.ToInt32(dias));
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "A1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet LlenarGridPlanillaViatico()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C4");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar(int ev_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "B1");
                CNXSIGRH3.AddInParameter(icom, "ev_id", DbType.Int32, ev_id);
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ProcesarPlanillaViatico(int nro_planilla, int us_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "vi_pla", DbType.Int32, nro_planilla);
                CNXSIGRH3.AddInParameter(icom, "US_ID", DbType.Int32, us_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "B2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet NroPlanillaCombo(int pr_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "PR_ID", DbType.Int32, pr_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C5");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EnviarEncuesta(int per_id, int op1, int op2, int op3, int op4)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_Datos_POAI");
                CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "OP1", DbType.Int32, op1);
                CNXSIGRH3.AddInParameter(icom, "OP2", DbType.Int32, op2);
                CNXSIGRH3.AddInParameter(icom, "OP3", DbType.Int32, op3);
                CNXSIGRH3.AddInParameter(icom, "OP4", DbType.Int32, op4);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet LlenarListaViatico()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C16");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet CargarInfoPlanilla(int nro_pla)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "pla_nro", DbType.Int32, nro_pla);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C17");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int ReprobarPlanilla(int nro_pla)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "B3");
                CNXSIGRH3.AddInParameter(icom, "pla_nro", DbType.Int32, nro_pla);
                return CNXSIGRH3.ExecuteNonQuery(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet cargarMeses()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C18");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet LlenarViaticosMes(int mes)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "mes", DbType.Int32, mes);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C19");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int ObtenerDiasViatico(string fecha1, string fecha2)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_viaticos");
                CNXSIGRH3.AddInParameter(icom, "Fecha_ini", DbType.String, fecha1);
                CNXSIGRH3.AddInParameter(icom, "Fecha_fin", DbType.String, fecha2);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C20");
                return Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override decimal puntaje_evaluacion(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_evaluacion_puntaje);
                CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "accion", DbType.String, "M1");
                object result = CNXSIGRH3.ExecuteScalar(icom);

                if (result != DBNull.Value)
                {
                    decimal x = Convert.ToDecimal(result);
                    return x;
                }
                else
                {
                    return 0; // o cualquier otro valor que desees devolver en caso de que la consulta devuelva null
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
