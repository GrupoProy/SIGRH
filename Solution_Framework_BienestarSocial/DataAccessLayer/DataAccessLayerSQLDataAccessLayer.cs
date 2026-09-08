using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using Solution_Framework_BienestarSocial.DataAccessLayer;

namespace Solution_Framework_BienestarSocial.BussinessLogicLayer
{
	public class DataAccessLayerSQLDataAccessLayer : DataAccessLayerDataAccessLayer
	{
		#region CONSTANTES
		private string SP__BS_ENFERMEDADES_RECURRENTES = "sp_bs_enfermedades_recurrentes";
		private string SP__BS_AGENTE_EXPUESTO = "sp_bs_agente_expuesto";
		private string SP__BS_EXAMEN_PREOCUPACIONAL = "sp_bs_examen_preocupacional";
		private string SP__BS_AFILIACION_EGS = "sp_bs_afiliacion_egs";
		private string SP__BS_ASIGNACION_BENEFICIO = "sp_bs_asignacion_beneficio";
		private string SP__BS_AFP = "sp_bs_afp";
        #endregion

        //INTERFACES
		#region _BS_ENFERMEDADES_RECURRENTES
		public override bool Adicionar__bs_enfermedades_recurrentes(cls_bs_enfermedades_recurrentes _bs_enfermedades_recurrentes)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ENFERMEDADES_RECURRENTES);

				CNXSIGRH3.AddInParameter(icom, "p_enfrec_exp_id", DbType.Int32, _bs_enfermedades_recurrentes.enfrec_exp_id);
				CNXSIGRH3.AddInParameter(icom, "p_enfrec_pat_id", DbType.Int32, _bs_enfermedades_recurrentes.enfrec_pat_id);
				CNXSIGRH3.AddInParameter(icom, "p_enfrec_esp_id", DbType.Int32, _bs_enfermedades_recurrentes.enfrec_esp_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Eliminar__bs_enfermedades_recurrentes(cls_bs_enfermedades_recurrentes _bs_enfermedades_recurrentes)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ENFERMEDADES_RECURRENTES);

				CNXSIGRH3.AddInParameter(icom, "p_enfrec_id", DbType.Int32, _bs_enfermedades_recurrentes.enfrec_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Actualizar__bs_enfermedades_recurrentes(cls_bs_enfermedades_recurrentes _bs_enfermedades_recurrentes)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ENFERMEDADES_RECURRENTES);

				CNXSIGRH3.AddInParameter(icom, "p_enfrec_id", DbType.Int32, _bs_enfermedades_recurrentes.enfrec_id);
				CNXSIGRH3.AddInParameter(icom, "p_enfrec_estado", DbType.String, _bs_enfermedades_recurrentes.enfrec_estado);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerId__bs_enfermedades_recurrentes(cls_bs_enfermedades_recurrentes _bs_enfermedades_recurrentes)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ENFERMEDADES_RECURRENTES);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_bs_enfermedades_recurrentes.enfrec_id = Convert.ToInt32(ds.Tables[0].Rows[0]["enfrec_id"]);
		
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerRegistro__bs_enfermedades_recurrentes(cls_bs_enfermedades_recurrentes _bs_enfermedades_recurrentes)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ENFERMEDADES_RECURRENTES);

				CNXSIGRH3.AddInParameter(icom, "p_enfrec_id", DbType.Int32, _bs_enfermedades_recurrentes.enfrec_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				if (ds.Tables[0].Rows[0]["enfrec_id"] != DBNull.Value && ds.Tables[0].Rows[0]["enfrec_id"].ToString().Trim() != "") { _bs_enfermedades_recurrentes.enfrec_id = Convert.ToInt32(ds.Tables[0].Rows[0]["enfrec_id"]); }
				if (ds.Tables[0].Rows[0]["enfrec_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["enfrec_estado"].ToString().Trim() != "") { _bs_enfermedades_recurrentes.enfrec_estado = Convert.ToString(ds.Tables[0].Rows[0]["enfrec_estado"]); }
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaGrilla__bs_enfermedades_recurrentes(cls_bs_enfermedades_recurrentes _bs_enfermedades_recurrentes)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ENFERMEDADES_RECURRENTES);

                CNXSIGRH3.AddInParameter(icom, "p_enfrec_exp_id", DbType.Int32, _bs_enfermedades_recurrentes.enfrec_exp_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__bs_enfermedades_recurrentes()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ENFERMEDADES_RECURRENTES);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion 

		#region _BS_AGENTE_EXPUESTO
		public override bool Adicionar__bs_agente_expuesto(cls_bs_agente_expuesto _bs_agente_expuesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AGENTE_EXPUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_agexp_exp_id", DbType.Int32, _bs_agente_expuesto.agexp_exp_id);
				CNXSIGRH3.AddInParameter(icom, "p_agexp_fisico", DbType.String, _bs_agente_expuesto.agexp_fisico);
				CNXSIGRH3.AddInParameter(icom, "p_agexp_quimico", DbType.String, _bs_agente_expuesto.agexp_quimico);
				CNXSIGRH3.AddInParameter(icom, "p_agexp_biologico", DbType.String, _bs_agente_expuesto.agexp_biologico);
				CNXSIGRH3.AddInParameter(icom, "p_agexp_psicosocial", DbType.String, _bs_agente_expuesto.agexp_psicosocial);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Eliminar__bs_agente_expuesto(cls_bs_agente_expuesto _bs_agente_expuesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AGENTE_EXPUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_agexp_id", DbType.Int32, _bs_agente_expuesto.agexp_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Actualizar__bs_agente_expuesto(cls_bs_agente_expuesto _bs_agente_expuesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AGENTE_EXPUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_agexp_exp_id", DbType.Int32, _bs_agente_expuesto.agexp_exp_id);
				CNXSIGRH3.AddInParameter(icom, "p_agexp_fisico", DbType.String, _bs_agente_expuesto.agexp_fisico);
				CNXSIGRH3.AddInParameter(icom, "p_agexp_quimico", DbType.String, _bs_agente_expuesto.agexp_quimico);
				CNXSIGRH3.AddInParameter(icom, "p_agexp_biologico", DbType.String, _bs_agente_expuesto.agexp_biologico);
				CNXSIGRH3.AddInParameter(icom, "p_agexp_psicosocial", DbType.String, _bs_agente_expuesto.agexp_psicosocial);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerId__bs_agente_expuesto(cls_bs_agente_expuesto _bs_agente_expuesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AGENTE_EXPUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_bs_agente_expuesto.agexp_id = Convert.ToInt32(ds.Tables[0].Rows[0]["agexp_id"]);
		
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerRegistro__bs_agente_expuesto(cls_bs_agente_expuesto _bs_agente_expuesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AGENTE_EXPUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_agexp_exp_id", DbType.Int32, _bs_agente_expuesto.agexp_exp_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaGrilla__bs_agente_expuesto(string agexp_id, 
						string agexp_fisico, 
						string agexp_quimico, 
						string agexp_biologico, 
						string agexp_psicosocial, 
						string agexp_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AGENTE_EXPUESTO);

				if (agexp_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_agexp_id", DbType.Int32, Convert.ToInt32(agexp_id)); }
				if (agexp_fisico.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_agexp_fisico", DbType.String, Convert.ToString(agexp_fisico)); }
				if (agexp_quimico.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_agexp_quimico", DbType.String, Convert.ToString(agexp_quimico)); }
				if (agexp_biologico.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_agexp_biologico", DbType.String, Convert.ToString(agexp_biologico)); }
				if (agexp_psicosocial.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_agexp_psicosocial", DbType.String, Convert.ToString(agexp_psicosocial)); }
				if (agexp_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_agexp_estado", DbType.String, Convert.ToString(agexp_estado)); }
 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__bs_agente_expuesto()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AGENTE_EXPUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerAgentesExpFisico(cls_bs_agente_expuesto _bs_agente_expuesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AGENTE_EXPUESTO);

                CNXSIGRH3.AddInParameter(icom, "p_agexp_exp_id", DbType.String, _bs_agente_expuesto.agexp_exp_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerAgentesExpQuimico(cls_bs_agente_expuesto _bs_agente_expuesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AGENTE_EXPUESTO);

                CNXSIGRH3.AddInParameter(icom, "p_agexp_exp_id", DbType.String, _bs_agente_expuesto.agexp_exp_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerAgentesExpBilogico(cls_bs_agente_expuesto _bs_agente_expuesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AGENTE_EXPUESTO);

                CNXSIGRH3.AddInParameter(icom, "p_agexp_exp_id", DbType.String, _bs_agente_expuesto.agexp_exp_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerAgentesExpPsicosocial(cls_bs_agente_expuesto _bs_agente_expuesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AGENTE_EXPUESTO);

                CNXSIGRH3.AddInParameter(icom, "p_agexp_exp_id", DbType.String, _bs_agente_expuesto.agexp_exp_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _BS_EXAMEN_PREOCUPACIONAL
        public override DataSet Adicionar__bs_examen_preocupacional(cls_bs_examen_preocupacional _bs_examen_preocupacional)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

				CNXSIGRH3.AddInParameter(icom, "p_exp_per_id", DbType.Int32, _bs_examen_preocupacional.exp_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_exp_convenio", DbType.Boolean, _bs_examen_preocupacional.exp_convenio);
				CNXSIGRH3.AddInParameter(icom, "p_exp_lugar", DbType.Int32, _bs_examen_preocupacional.exp_lugar);
				CNXSIGRH3.AddInParameter(icom, "p_exp_fecha_prog", DbType.String, _bs_examen_preocupacional.exp_fecha_prog);
				CNXSIGRH3.AddInParameter(icom, "p_exp_tel_of_fun", DbType.Int32, _bs_examen_preocupacional.exp_tel_of_fun);
				CNXSIGRH3.AddInParameter(icom, "p_exp_actividad_realiza", DbType.String, _bs_examen_preocupacional.exp_actividad_realiza);
				CNXSIGRH3.AddInParameter(icom, "p_exp_obs_aut", DbType.String, _bs_examen_preocupacional.exp_obs_aut);
				CNXSIGRH3.AddInParameter(icom, "p_exp_pr_id", DbType.Int32, _bs_examen_preocupacional.exp_pr_id);
				CNXSIGRH3.AddInParameter(icom, "p_exp_as_id", DbType.Int32, _bs_examen_preocupacional.exp_as_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Eliminar__bs_examen_preocupacional(cls_bs_examen_preocupacional _bs_examen_preocupacional)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

				CNXSIGRH3.AddInParameter(icom, "p_exp_id", DbType.Int32, _bs_examen_preocupacional.exp_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Actualizar__bs_examen_preocupacional(cls_bs_examen_preocupacional _bs_examen_preocupacional)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

				CNXSIGRH3.AddInParameter(icom, "p_exp_id", DbType.Int32, _bs_examen_preocupacional.exp_id);
				CNXSIGRH3.AddInParameter(icom, "p_exp_per_id", DbType.Int32, _bs_examen_preocupacional.exp_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_exp_fecha_elab", DbType.DateTime, _bs_examen_preocupacional.exp_fecha_elab);
				CNXSIGRH3.AddInParameter(icom, "p_exp_carts_puesto", DbType.String, _bs_examen_preocupacional.exp_carts_puesto);
				CNXSIGRH3.AddInParameter(icom, "p_exp_fecha_examen", DbType.DateTime, _bs_examen_preocupacional.exp_fecha_examen);
				CNXSIGRH3.AddInParameter(icom, "p_exp_estado", DbType.String, _bs_examen_preocupacional.exp_estado);
				CNXSIGRH3.AddInParameter(icom, "p_exp_diagnostico", DbType.String, _bs_examen_preocupacional.exp_diagnostico);
				CNXSIGRH3.AddInParameter(icom, "p_exp_comentario", DbType.String, _bs_examen_preocupacional.exp_comentario);
				CNXSIGRH3.AddInParameter(icom, "p_exp_recomendaciones", DbType.String, _bs_examen_preocupacional.exp_recomendaciones);
				CNXSIGRH3.AddInParameter(icom, "p_exp_fecha_recep_Funcionario", DbType.DateTime, _bs_examen_preocupacional.exp_fecha_recep_Funcionario);
				CNXSIGRH3.AddInParameter(icom, "p_exp_nro_historia_clinica", DbType.Int32, _bs_examen_preocupacional.exp_nro_historia_clinica);
				CNXSIGRH3.AddInParameter(icom, "p_exp_medico", DbType.String, _bs_examen_preocupacional.exp_medico);
				CNXSIGRH3.AddInParameter(icom, "p_exp_n_autorizacion", DbType.Int32, _bs_examen_preocupacional.exp_n_autorizacion);
				CNXSIGRH3.AddInParameter(icom, "p_exp_convenio", DbType.Boolean, _bs_examen_preocupacional.exp_convenio);
				CNXSIGRH3.AddInParameter(icom, "p_exp_fecha_prog", DbType.DateTime, _bs_examen_preocupacional.exp_fecha_prog);
				CNXSIGRH3.AddInParameter(icom, "p_exp_tel_of_fun", DbType.String, _bs_examen_preocupacional.exp_tel_of_fun);
				CNXSIGRH3.AddInParameter(icom, "p_exp_tel_dom_fun", DbType.String, _bs_examen_preocupacional.exp_tel_dom_fun);
				CNXSIGRH3.AddInParameter(icom, "p_exp_importe", DbType.Double, _bs_examen_preocupacional.exp_importe);
				CNXSIGRH3.AddInParameter(icom, "p_exp_tipo_sangre", DbType.String, _bs_examen_preocupacional.exp_tipo_sangre);
				CNXSIGRH3.AddInParameter(icom, "p_exp_correlativo_fecha_registro_n_autorizacion", DbType.DateTime, _bs_examen_preocupacional.exp_correlativo_fecha_registro_n_autorizacion);
				CNXSIGRH3.AddInParameter(icom, "p_exp_as_id", DbType.Int32, _bs_examen_preocupacional.exp_as_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerId__bs_examen_preocupacional(cls_bs_examen_preocupacional _bs_examen_preocupacional)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_bs_examen_preocupacional.exp_id = Convert.ToInt32(ds.Tables[0].Rows[0]["exp_id"]);
		
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerRegistro__bs_examen_preocupacional(cls_bs_examen_preocupacional _bs_examen_preocupacional)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

				CNXSIGRH3.AddInParameter(icom, "p_exp_id", DbType.Int32, _bs_examen_preocupacional.exp_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				if (ds.Tables[0].Rows[0]["exp_id"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_id"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_id = Convert.ToInt32(ds.Tables[0].Rows[0]["exp_id"]); }
				if (ds.Tables[0].Rows[0]["exp_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_per_id"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["exp_per_id"]); }
				if (ds.Tables[0].Rows[0]["exp_fecha_elab"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_fecha_elab"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_fecha_elab = Convert.ToDateTime(ds.Tables[0].Rows[0]["exp_fecha_elab"]); }
				if (ds.Tables[0].Rows[0]["exp_carts_puesto"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_carts_puesto"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_carts_puesto = Convert.ToString(ds.Tables[0].Rows[0]["exp_carts_puesto"]); }
				if (ds.Tables[0].Rows[0]["exp_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_estado"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_estado = Convert.ToString(ds.Tables[0].Rows[0]["exp_estado"]); }
				if (ds.Tables[0].Rows[0]["exp_diagnostico"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_diagnostico"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_diagnostico = Convert.ToString(ds.Tables[0].Rows[0]["exp_diagnostico"]); }
				if (ds.Tables[0].Rows[0]["exp_comentario"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_comentario"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_comentario = Convert.ToString(ds.Tables[0].Rows[0]["exp_comentario"]); }
				if (ds.Tables[0].Rows[0]["exp_recomendaciones"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_recomendaciones"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_recomendaciones = Convert.ToString(ds.Tables[0].Rows[0]["exp_recomendaciones"]); }
				if (ds.Tables[0].Rows[0]["exp_fecha_recep_Funcionario"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_fecha_recep_Funcionario"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_fecha_recep_Funcionario = Convert.ToDateTime(ds.Tables[0].Rows[0]["exp_fecha_recep_Funcionario"]); }
				if (ds.Tables[0].Rows[0]["exp_nro_historia_clinica"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_nro_historia_clinica"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_nro_historia_clinica = Convert.ToInt32(ds.Tables[0].Rows[0]["exp_nro_historia_clinica"]); }
				if (ds.Tables[0].Rows[0]["exp_medico"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_medico"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_medico = Convert.ToString(ds.Tables[0].Rows[0]["exp_medico"]); }
				if (ds.Tables[0].Rows[0]["exp_n_autorizacion"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_n_autorizacion"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_n_autorizacion = Convert.ToInt32(ds.Tables[0].Rows[0]["exp_n_autorizacion"]); }
				if (ds.Tables[0].Rows[0]["exp_convenio"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_convenio"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_convenio = Convert.ToBoolean(ds.Tables[0].Rows[0]["exp_convenio"]); }
				if (ds.Tables[0].Rows[0]["exp_tel_of_fun"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_tel_of_fun"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_tel_of_fun = Convert.ToString(ds.Tables[0].Rows[0]["exp_tel_of_fun"]); }
				if (ds.Tables[0].Rows[0]["exp_tel_dom_fun"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_tel_dom_fun"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_tel_dom_fun = Convert.ToString(ds.Tables[0].Rows[0]["exp_tel_dom_fun"]); }
				if (ds.Tables[0].Rows[0]["exp_importe"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_importe"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_importe = Convert.ToDouble(ds.Tables[0].Rows[0]["exp_importe"]); }
				if (ds.Tables[0].Rows[0]["exp_tipo_sangre"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_tipo_sangre"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_tipo_sangre = Convert.ToString(ds.Tables[0].Rows[0]["exp_tipo_sangre"]); }
				if (ds.Tables[0].Rows[0]["exp_correlativo_fecha_registro_n_autorizacion"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_correlativo_fecha_registro_n_autorizacion"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_correlativo_fecha_registro_n_autorizacion = Convert.ToDateTime(ds.Tables[0].Rows[0]["exp_correlativo_fecha_registro_n_autorizacion"]); }
				if (ds.Tables[0].Rows[0]["exp_as_id"] != DBNull.Value && ds.Tables[0].Rows[0]["exp_as_id"].ToString().Trim() != "") { _bs_examen_preocupacional.exp_as_id = Convert.ToInt32(ds.Tables[0].Rows[0]["exp_as_id"]); }
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaGrilla__bs_examen_preocupacional(string exp_id, 
						string exp_per_id, 
						string exp_fecha_elab, 
						string exp_carts_puesto, 
						string exp_fecha_examen, 
						string exp_estado, 
						string exp_diagnostico, 
						string exp_comentario, 
						string exp_recomendaciones, 
						string exp_fecha_recep_Funcionario, 
						string exp_nro_historia_clinica, 
						string exp_medico, 
						string exp_n_autorizacion, 
						string exp_convenio, 
						string exp_fecha_prog, 
						string exp_tel_of_fun, 
						string exp_tel_dom_fun, 
						string exp_obsaut, 
						string exp_importe, 
						string exp_tipo_sangre, 
						string exp_correlativo_gestion_n_autorizacion, 
						string exp_correlativo_fecha_registro_n_autorizacion, 
						string exp_as_id)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

				if (exp_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_id", DbType.Int32, Convert.ToInt32(exp_id)); }
				if (exp_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_per_id", DbType.Int32, Convert.ToInt32(exp_per_id)); }
				if (exp_fecha_elab.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_fecha_elab", DbType.DateTime, Convert.ToDateTime(exp_fecha_elab)); }
				if (exp_carts_puesto.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_carts_puesto", DbType.String, Convert.ToString(exp_carts_puesto)); }
				if (exp_fecha_examen.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_fecha_examen", DbType.DateTime, Convert.ToDateTime(exp_fecha_examen)); }
				if (exp_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_estado", DbType.String, Convert.ToString(exp_estado)); }
				if (exp_diagnostico.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_diagnostico", DbType.String, Convert.ToString(exp_diagnostico)); }
				if (exp_comentario.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_comentario", DbType.String, Convert.ToString(exp_comentario)); }
				if (exp_recomendaciones.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_recomendaciones", DbType.String, Convert.ToString(exp_recomendaciones)); }
				if (exp_fecha_recep_Funcionario.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_fecha_recep_Funcionario", DbType.DateTime, Convert.ToDateTime(exp_fecha_recep_Funcionario)); }
				if (exp_nro_historia_clinica.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_nro_historia_clinica", DbType.Int32, Convert.ToInt32(exp_nro_historia_clinica)); }
				if (exp_medico.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_medico", DbType.String, Convert.ToString(exp_medico)); }
				if (exp_n_autorizacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_n_autorizacion", DbType.Int32, Convert.ToInt32(exp_n_autorizacion)); }
				if (exp_convenio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_convenio", DbType.Boolean, Convert.ToBoolean(exp_convenio)); }
				if (exp_fecha_prog.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_fecha_prog", DbType.DateTime, Convert.ToDateTime(exp_fecha_prog)); }
				if (exp_tel_of_fun.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_tel_of_fun", DbType.String, Convert.ToString(exp_tel_of_fun)); }
				if (exp_tel_dom_fun.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_tel_dom_fun", DbType.String, Convert.ToString(exp_tel_dom_fun)); }
				if (exp_obsaut.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_obsaut", DbType.String, Convert.ToString(exp_obsaut)); }
				if (exp_importe.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_importe", DbType.Double, Convert.ToDouble(exp_importe)); }
				if (exp_tipo_sangre.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_tipo_sangre", DbType.String, Convert.ToString(exp_tipo_sangre)); }
				if (exp_correlativo_gestion_n_autorizacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_correlativo_gestion_n_autorizacion", DbType.Int32, Convert.ToInt32(exp_correlativo_gestion_n_autorizacion)); }
				if (exp_correlativo_fecha_registro_n_autorizacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_correlativo_fecha_registro_n_autorizacion", DbType.DateTime, Convert.ToDateTime(exp_correlativo_fecha_registro_n_autorizacion)); }
				if (exp_as_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_exp_as_id", DbType.Int32, Convert.ToInt32(exp_as_id)); }
 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__bs_examen_preocupacional()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerDatosFuncionario(cls_bs_examen_preocupacional _bs_examen_preocupacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _bs_examen_preocupacional.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_pr_id", DbType.Int32, _bs_examen_preocupacional.pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_exp_per_id", DbType.Int32, _bs_examen_preocupacional.exp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDatosFuncionarioExamen(cls_bs_examen_preocupacional _bs_examen_preocupacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_exp_id", DbType.Int32, _bs_examen_preocupacional.exp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerNroAutorizacion(cls_bs_examen_preocupacional _bs_examen_preocupacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_exp_pr_id", DbType.String, _bs_examen_preocupacional.pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerExamenesRealizados(cls_bs_examen_preocupacional _bs_examen_preocupacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_exp_per_id", DbType.Int32, _bs_examen_preocupacional.exp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerTelefonos(cls_bs_examen_preocupacional _bs_examen_preocupacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_exp_per_id", DbType.Int32, _bs_examen_preocupacional.exp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerExamenProgramado(cls_bs_examen_preocupacional _bs_examen_preocupacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_exp_id", DbType.Int32, _bs_examen_preocupacional.exp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ReprogramarExamen(cls_bs_examen_preocupacional _bs_examen_preocupacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_exp_id", DbType.Int32, _bs_examen_preocupacional.exp_id);
                CNXSIGRH3.AddInParameter(icom, "p_exp_convenio", DbType.Boolean, _bs_examen_preocupacional.exp_convenio);
                CNXSIGRH3.AddInParameter(icom, "p_exp_lugar", DbType.Int32, _bs_examen_preocupacional.exp_lugar);
                CNXSIGRH3.AddInParameter(icom, "p_exp_fecha_prog", DbType.String, _bs_examen_preocupacional.exp_fecha_prog);
                CNXSIGRH3.AddInParameter(icom, "p_exp_tel_of_fun", DbType.Int32, _bs_examen_preocupacional.exp_tel_of_fun);
                CNXSIGRH3.AddInParameter(icom, "p_exp_actividad_realiza", DbType.String, _bs_examen_preocupacional.exp_actividad_realiza);
                CNXSIGRH3.AddInParameter(icom, "p_exp_obs_aut", DbType.String, _bs_examen_preocupacional.exp_obs_aut);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool DeclararExamen(cls_bs_examen_preocupacional _bs_examen_preocupacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_EXAMEN_PREOCUPACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_exp_id", DbType.Int32, _bs_examen_preocupacional.exp_id);
                CNXSIGRH3.AddInParameter(icom, "p_exp_diagnostico", DbType.String, _bs_examen_preocupacional.exp_diagnostico);
                CNXSIGRH3.AddInParameter(icom, "p_exp_comentario", DbType.String, _bs_examen_preocupacional.exp_comentario);
                CNXSIGRH3.AddInParameter(icom, "p_exp_recomendaciones", DbType.String, _bs_examen_preocupacional.exp_recomendaciones);
                CNXSIGRH3.AddInParameter(icom, "p_exp_fecha_examen", DbType.String, _bs_examen_preocupacional.exp_fecha_examen);
                CNXSIGRH3.AddInParameter(icom, "p_exp_medico", DbType.String, _bs_examen_preocupacional.exp_medico);
                CNXSIGRH3.AddInParameter(icom, "p_exp_nro_historia_clinica", DbType.Int32, _bs_examen_preocupacional.exp_nro_historia_clinica);
                CNXSIGRH3.AddInParameter(icom, "p_exp_tipo_sangre", DbType.Int32, _bs_examen_preocupacional.exp_tipo_sangre);
                CNXSIGRH3.AddInParameter(icom, "p_exp_caracteristica_puesto", DbType.String, _bs_examen_preocupacional.exp_caracteristica_puesto);
                CNXSIGRH3.AddInParameter(icom, "p_exp_importe", DbType.Double, _bs_examen_preocupacional.exp_importe);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _BS_AFILIACION_EGS
        public override bool Adicionar__bs_afiliacion_egs(cls_bs_afiliacion_egs _bs_afiliacion_egs)
		{
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFILIACION_EGS);
                CNXSIGRH3.AddInParameter(icom, "p_ae_id", DbType.Int32, _bs_afiliacion_egs.ae_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_per_id", DbType.Int32, _bs_afiliacion_egs.ae_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_as_id", DbType.Int32, _bs_afiliacion_egs.ae_as_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_egs_id", DbType.Int32, _bs_afiliacion_egs.ae_egs_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_estado", DbType.String, _bs_afiliacion_egs.ae_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_form", DbType.DateTime, _bs_afiliacion_egs.ae_fecha_form);
                CNXSIGRH3.AddInParameter(icom, "p_ae_policlinico", DbType.Int32, _bs_afiliacion_egs.ae_policlinico);
                CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_baja_form", DbType.DateTime, _bs_afiliacion_egs.ae_fecha_baja_form);
                CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_baja_elab", DbType.DateTime, _bs_afiliacion_egs.ae_fecha_baja_elab);
                CNXSIGRH3.AddInParameter(icom, "p_ae_tipo_ingreso", DbType.String, _bs_afiliacion_egs.ae_tipo_ingreso);
                CNXSIGRH3.AddInParameter(icom, "p_ae_tipo_proceso_baja", DbType.String, _bs_afiliacion_egs.ae_tipo_proceso_baja);
                CNXSIGRH3.AddInParameter(icom, "p_ae_em_id", DbType.Int32, _bs_afiliacion_egs.ae_em_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
		}

		public override bool Eliminar__bs_afiliacion_egs(cls_bs_afiliacion_egs _bs_afiliacion_egs)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFILIACION_EGS);
				CNXSIGRH3.AddInParameter(icom, "p_ae_id", DbType.Int32, _bs_afiliacion_egs.ae_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Actualizar__bs_afiliacion_egs(cls_bs_afiliacion_egs _bs_afiliacion_egs)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFILIACION_EGS);
				CNXSIGRH3.AddInParameter(icom, "p_ae_id", DbType.Int32, _bs_afiliacion_egs.ae_id);
				CNXSIGRH3.AddInParameter(icom, "p_ae_per_id", DbType.Int32, _bs_afiliacion_egs.ae_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_ae_as_id", DbType.Int32, _bs_afiliacion_egs.ae_as_id);
				CNXSIGRH3.AddInParameter(icom, "p_ae_egs_id", DbType.Int32, _bs_afiliacion_egs.ae_egs_id);
				CNXSIGRH3.AddInParameter(icom, "p_ae_estado", DbType.String, _bs_afiliacion_egs.ae_estado);
				CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_form", DbType.DateTime, _bs_afiliacion_egs.ae_fecha_form);
				CNXSIGRH3.AddInParameter(icom, "p_ae_policlinico", DbType.Int32, _bs_afiliacion_egs.ae_policlinico);
				CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_baja_form", DbType.DateTime, _bs_afiliacion_egs.ae_fecha_baja_form);
				CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_baja_elab", DbType.DateTime, _bs_afiliacion_egs.ae_fecha_baja_elab);
				CNXSIGRH3.AddInParameter(icom, "p_ae_tipo_ingreso", DbType.String, _bs_afiliacion_egs.ae_tipo_ingreso);
				CNXSIGRH3.AddInParameter(icom, "p_ae_tipo_proceso_baja", DbType.String, _bs_afiliacion_egs.ae_tipo_proceso_baja);
				CNXSIGRH3.AddInParameter(icom, "p_ae_em_id", DbType.Int32, _bs_afiliacion_egs.ae_em_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool ObtenerId__bs_afiliacion_egs(cls_bs_afiliacion_egs _bs_afiliacion_egs)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFILIACION_EGS);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				_bs_afiliacion_egs.ae_id = Convert.ToInt32(ds.Tables[0].Rows[0]["ae_id"]);		
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerRegistro__bs_afiliacion_egs(cls_bs_afiliacion_egs _bs_afiliacion_egs)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFILIACION_EGS);
				CNXSIGRH3.AddInParameter(icom, "p_ae_id", DbType.Int32, _bs_afiliacion_egs.ae_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaGrilla__bs_afiliacion_egs(
            string ae_id, 
			string ae_per_id, 
			string ae_as_id, 
			string ae_egs_id, 
			string ae_estado, 
			string ae_fecha_form, 
			string ae_policlinico, 
			string ae_fecha_baja_form, 
			string ae_fecha_baja_elab, 
			string ae_tipo_ingreso, 
			string ae_tipo_proceso_baja, 
			string ae_em_id)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFILIACION_EGS);

				if (ae_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_id", DbType.Int32, Convert.ToInt32(ae_id)); }
				if (ae_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_per_id", DbType.Int32, Convert.ToInt32(ae_per_id)); }
				if (ae_as_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_as_id", DbType.Int32, Convert.ToInt32(ae_as_id)); }
				if (ae_egs_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_egs_id", DbType.Int32, Convert.ToInt32(ae_egs_id)); }
				if (ae_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_estado", DbType.String, Convert.ToString(ae_estado)); }
				if (ae_fecha_form.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_form", DbType.DateTime, Convert.ToDateTime(ae_fecha_form)); }
				if (ae_policlinico.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_policlinico", DbType.Int32, Convert.ToInt32(ae_policlinico)); }
				if (ae_fecha_baja_form.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_baja_form", DbType.DateTime, Convert.ToDateTime(ae_fecha_baja_form)); }
				if (ae_fecha_baja_elab.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_baja_elab", DbType.DateTime, Convert.ToDateTime(ae_fecha_baja_elab)); }
				if (ae_tipo_ingreso.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_tipo_ingreso", DbType.String, Convert.ToString(ae_tipo_ingreso)); }
				if (ae_tipo_proceso_baja.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_tipo_proceso_baja", DbType.String, Convert.ToString(ae_tipo_proceso_baja)); }
				if (ae_em_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_em_id", DbType.Int32, Convert.ToInt32(ae_em_id)); } 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaCombo__bs_afiliacion_egs()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFILIACION_EGS);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

        public override bool Adicionar_2_bs_afiliacion_egs(cls_bs_afiliacion_egs _bs_afiliacion_egs)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFILIACION_EGS);
                CNXSIGRH3.AddInParameter(icom, "p_ae_id", DbType.Int32, _bs_afiliacion_egs.ae_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_per_id", DbType.Int32, _bs_afiliacion_egs.ae_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_as_id", DbType.Int32, _bs_afiliacion_egs.ae_as_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_form", DbType.DateTime, _bs_afiliacion_egs.ae_fecha_form);
                CNXSIGRH3.AddInParameter(icom, "p_ae_tipo_ingreso", DbType.String, _bs_afiliacion_egs.ae_tipo_ingreso);
                CNXSIGRH3.AddInParameter(icom, "p_ae_em_id", DbType.Int32, _bs_afiliacion_egs.ae_em_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _BS_ASIGNACION_BENEFICIO
        public override DataSet DatosFuncionario(int codigo, string nombre, string paterno, string materno, string esposo, string ci)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                if(codigo != 0) CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, codigo);
                if (paterno != "") CNXSIGRH3.AddInParameter(icom, "p_paterno", DbType.String, paterno);
                if (materno != "") CNXSIGRH3.AddInParameter(icom, "p_materno", DbType.String, materno);
                if (nombre != "") CNXSIGRH3.AddInParameter(icom, "p_nombre", DbType.String, nombre);
                if (esposo != "") CNXSIGRH3.AddInParameter(icom, "p_esposo", DbType.String, esposo);
                if (ci != "") CNXSIGRH3.AddInParameter(icom, "p_ci", DbType.String, ci);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C39");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ListarBenef(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C38");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool CambiarMatricula(cls_bs_afiliacion_egs afili)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFILIACION_EGS);
                CNXSIGRH3.AddInParameter(icom, "p_ae_as_id", DbType.Int32, afili.ae_as_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Adicionar__bs_asignacion_beneficio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_ab_aeb_id", DbType.Int32, _bs_asignacion_beneficio.ab_aeb_id);
				CNXSIGRH3.AddInParameter(icom, "p_ab_fa_id", DbType.Int32, _bs_asignacion_beneficio.ab_fa_id);
				CNXSIGRH3.AddInParameter(icom, "p_ab_fecha_inicio", DbType.DateTime, _bs_asignacion_beneficio.ab_fecha_inicio);
				CNXSIGRH3.AddInParameter(icom, "p_ab_fecha_fin", DbType.DateTime, _bs_asignacion_beneficio.ab_fecha_fin);
				CNXSIGRH3.AddInParameter(icom, "p_ab_tipo_beneficiario", DbType.String, _bs_asignacion_beneficio.ab_tipo_beneficiario);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Eliminar__bs_asignacion_beneficio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

				CNXSIGRH3.AddInParameter(icom, "p_ab_id", DbType.Int32, _bs_asignacion_beneficio.ab_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Actualizar__bs_asignacion_beneficio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

				CNXSIGRH3.AddInParameter(icom, "p_ab_id", DbType.Int32, _bs_asignacion_beneficio.ab_id);
				CNXSIGRH3.AddInParameter(icom, "p_ab_aeb_id", DbType.Int32, _bs_asignacion_beneficio.ab_aeb_id);
				CNXSIGRH3.AddInParameter(icom, "p_ab_fa_id", DbType.Int32, _bs_asignacion_beneficio.ab_fa_id);
				CNXSIGRH3.AddInParameter(icom, "p_ab_fecha_inicio", DbType.DateTime, _bs_asignacion_beneficio.ab_fecha_inicio);
				CNXSIGRH3.AddInParameter(icom, "p_ab_fecha_fin", DbType.DateTime, _bs_asignacion_beneficio.ab_fecha_fin);
				CNXSIGRH3.AddInParameter(icom, "p_ab_estado", DbType.String, _bs_asignacion_beneficio.ab_estado);
				CNXSIGRH3.AddInParameter(icom, "p_ab_tipo_beneficiario", DbType.String, _bs_asignacion_beneficio.ab_tipo_beneficiario);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerId__bs_asignacion_beneficio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_bs_asignacion_beneficio.ab_id = Convert.ToInt32(ds.Tables[0].Rows[0]["ab_id"]);
		
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerRegistro__bs_asignacion_beneficio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

				CNXSIGRH3.AddInParameter(icom, "p_ab_id", DbType.Int32, _bs_asignacion_beneficio.ab_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				if (ds.Tables[0].Rows[0]["ab_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ab_id"].ToString().Trim() != "") { _bs_asignacion_beneficio.ab_id = Convert.ToInt32(ds.Tables[0].Rows[0]["ab_id"]); }
				if (ds.Tables[0].Rows[0]["ab_aeb_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ab_aeb_id"].ToString().Trim() != "") { _bs_asignacion_beneficio.ab_aeb_id = Convert.ToInt32(ds.Tables[0].Rows[0]["ab_aeb_id"]); }
				if (ds.Tables[0].Rows[0]["ab_fa_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ab_fa_id"].ToString().Trim() != "") { _bs_asignacion_beneficio.ab_fa_id = Convert.ToInt32(ds.Tables[0].Rows[0]["ab_fa_id"]); }
				if (ds.Tables[0].Rows[0]["ab_fecha_inicio"] != DBNull.Value && ds.Tables[0].Rows[0]["ab_fecha_inicio"].ToString().Trim() != "") { _bs_asignacion_beneficio.ab_fecha_inicio = Convert.ToString(ds.Tables[0].Rows[0]["ab_fecha_inicio"]); }
				if (ds.Tables[0].Rows[0]["ab_fecha_fin"] != DBNull.Value && ds.Tables[0].Rows[0]["ab_fecha_fin"].ToString().Trim() != "") { _bs_asignacion_beneficio.ab_fecha_fin = Convert.ToString(ds.Tables[0].Rows[0]["ab_fecha_fin"]); }
				if (ds.Tables[0].Rows[0]["ab_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["ab_estado"].ToString().Trim() != "") { _bs_asignacion_beneficio.ab_estado = Convert.ToString(ds.Tables[0].Rows[0]["ab_estado"]); }
				if (ds.Tables[0].Rows[0]["ab_tipo_beneficiario"] != DBNull.Value && ds.Tables[0].Rows[0]["ab_tipo_beneficiario"].ToString().Trim() != "") { _bs_asignacion_beneficio.ab_tipo_beneficiario = Convert.ToString(ds.Tables[0].Rows[0]["ab_tipo_beneficiario"]); }
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaGrilla__bs_asignacion_beneficio(string ab_id, 
						string ab_aeb_id, 
						string ab_fa_id, 
						string ab_fecha_inicio, 
						string ab_fecha_fin, 
						string ab_estado, 
						string ab_tipo_beneficiario,
                        string pf_per_id)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

				if (ab_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ab_id", DbType.Int32, Convert.ToInt32(ab_id)); }
				if (ab_aeb_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ab_aeb_id", DbType.Int32, Convert.ToInt32(ab_aeb_id)); }
				if (ab_fa_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ab_fa_id", DbType.Int32, Convert.ToInt32(ab_fa_id)); }
				if (ab_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ab_fecha_inicio", DbType.DateTime, Convert.ToDateTime(ab_fecha_inicio)); }
				if (ab_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ab_fecha_fin", DbType.DateTime, Convert.ToDateTime(ab_fecha_fin)); }
				if (ab_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ab_estado", DbType.String, Convert.ToString(ab_estado)); }
				if (ab_tipo_beneficiario.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ab_tipo_beneficiario", DbType.String, Convert.ToString(ab_tipo_beneficiario)); }
                if (pf_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, Convert.ToInt32(pf_per_id)); }

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__bs_asignacion_beneficio()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


        public override DataSet VerificarSubsidioenMes__bs_asignacion_beneficio(
                        string ab_aeb_id,
                        string ab_fa_id,
                        string ab_fecha_inicio,
                        string ab_fecha_fin)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                if (ab_aeb_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ab_aeb_id", DbType.Int32, Convert.ToInt32(ab_aeb_id)); }
                if (ab_fa_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ab_fa_id", DbType.Int32, Convert.ToInt32(ab_fa_id)); }
                if (ab_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "fecha1", DbType.String, ab_fecha_inicio); }
                if (ab_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "fecha2", DbType.String, ab_fecha_fin); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // (JQC)
        // (JQC)
        public override DataSet listaFiltradoTipoBeneficio()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet listaFiltradoTipoMes()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet listaFiltradoTipoParentesco()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet listaFiltradoTipoGenero()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet listaFiltradoEstadoVivo()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFamiliar(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.String, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.String, _bs_asignacion_beneficio.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ListarFamiliares(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.String, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarDatosFamiliar(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.Int32, _bs_asignacion_beneficio.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_fecha_nac", DbType.DateTime, _bs_asignacion_beneficio.pf_fecha_nac);
                CNXSIGRH3.AddInParameter(icom, "p_pf_estado_vivo", DbType.String, _bs_asignacion_beneficio.pf_estado_vivo);
                CNXSIGRH3.AddInParameter(icom, "p_pf_fecha_defuncion", DbType.DateTime, _bs_asignacion_beneficio.pf_fecha_defuncion);
                CNXSIGRH3.AddInParameter(icom, "p_pf_sexo", DbType.String, _bs_asignacion_beneficio.pf_sexo);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTiempoMeses(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_ab_fecha_inicio", DbType.DateTime, _bs_asignacion_beneficio.ab_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_ab_fecha_fin", DbType.DateTime, _bs_asignacion_beneficio.ab_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ListarFamiliarEsposa(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.String, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.String, _bs_asignacion_beneficio.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C12");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ListarFamiliaresBeneficiarios(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.String, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C13");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerIdBeneficio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_ab_aeb_id", DbType.Int32, _bs_asignacion_beneficio.ab_aeb_id);
                CNXSIGRH3.AddInParameter(icom, "p_ab_fa_id", DbType.Int32, _bs_asignacion_beneficio.ab_fa_id);
                CNXSIGRH3.AddInParameter(icom, "p_ab_fecha_inicio", DbType.DateTime, _bs_asignacion_beneficio.ab_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_ab_fecha_fin", DbType.DateTime, _bs_asignacion_beneficio.ab_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDatosDetalleFuncionario(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _bs_asignacion_beneficio.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C15");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet listaFiltradoCajaAseguradora()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C16");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet listaFiltradoPoliclinico()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C17");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarFamiliaresAfiliados(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.String, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C18");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarDatosAfiliacion(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _bs_asignacion_beneficio.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_matricula", DbType.String, _bs_asignacion_beneficio.ae_matricula);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_egs_id", DbType.Int32, _bs_asignacion_beneficio.ae_egs_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_form", DbType.DateTime, _bs_asignacion_beneficio.ae_fecha_form);
                CNXSIGRH3.AddInParameter(icom, "p_ae_tipo_ingreso", DbType.String, _bs_asignacion_beneficio.ae_tipo_ingreso);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet obtenerIdAfiliacionEGS(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _bs_asignacion_beneficio.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C19");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerAfiliacionX(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _bs_asignacion_beneficio.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C20");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet obtenerIdEmpleador(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C21");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool AdicionarPoliclinico(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _bs_asignacion_beneficio.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_policlinico", DbType.Int32, _bs_asignacion_beneficio.ae_policlinico);
                CNXSIGRH3.AddInParameter(icom, "p_ae_em_id", DbType.Int32, _bs_asignacion_beneficio.ae_em_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerDomicilio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _bs_asignacion_beneficio.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C15");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool AdicionarAfiliacionFamiliar(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_aeb_ae_id", DbType.Int32, _bs_asignacion_beneficio.aeb_ae_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.Int32, _bs_asignacion_beneficio.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_aeb_afi_por", DbType.String, _bs_asignacion_beneficio.aeb_afi_por);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para Adicionar benef_egs
        /// </summary>
        /// <param name="_bs_asignacion_beneficio"></param>
        /// <returns></returns>
        public override bool AdicionarAfiliacionFamiliarNuevo(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_aeb_ae_id", DbType.Int32, _bs_asignacion_beneficio.aeb_ae_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.Int32, _bs_asignacion_beneficio.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_aeb_afi_por", DbType.String, _bs_asignacion_beneficio.aeb_afi_por);
                CNXSIGRH3.AddInParameter(icom, "matricula", DbType.String, _bs_asignacion_beneficio.nro_matri);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A4");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public override bool EliminarAfiliacionFamiliar(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_aeb_id", DbType.Int32, _bs_asignacion_beneficio.aeb_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarFamiliaresAfiliadosEGS(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.String, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C22");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarDatosDomicilio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_perd_ciudad_residencia", DbType.Int32, _bs_asignacion_beneficio.perd_ciudad_residencia);
                CNXSIGRH3.AddInParameter(icom, "p_perd_zona", DbType.Int32, _bs_asignacion_beneficio.perd_zona);
                CNXSIGRH3.AddInParameter(icom, "p_perd_tipo_via", DbType.Int32, _bs_asignacion_beneficio.perd_tipo_via);
                CNXSIGRH3.AddInParameter(icom, "p_perd_descripcion_via", DbType.String, _bs_asignacion_beneficio.perd_descripcion_via);
                CNXSIGRH3.AddInParameter(icom, "p_perd_numero", DbType.String, _bs_asignacion_beneficio.perd_numero);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U4");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet VerificarAfiliacion(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_aeb_ae_id", DbType.Int32, _bs_asignacion_beneficio.aeb_ae_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.Int32, _bs_asignacion_beneficio.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C23");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFechaNacFamiliar(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.Int32, _bs_asignacion_beneficio.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C24");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet listaFiltradoEstadoAfiliacion()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C25");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet listaFiltradoTipoAvc()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C26");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet listaFiltradoTipoDocEsp()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C27");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool AdicionarFamiliar(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_tipo_parentesco", DbType.String, _bs_asignacion_beneficio.pf_tipo_parentesco);
                CNXSIGRH3.AddInParameter(icom, "p_pf_paterno", DbType.String, _bs_asignacion_beneficio.pf_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_pf_materno", DbType.String, _bs_asignacion_beneficio.pf_materno);
                CNXSIGRH3.AddInParameter(icom, "p_pf_nombres", DbType.String, _bs_asignacion_beneficio.pf_nombres);
                CNXSIGRH3.AddInParameter(icom, "p_pf_fecha_nac", DbType.DateTime, _bs_asignacion_beneficio.pf_fecha_nac);
                CNXSIGRH3.AddInParameter(icom, "p_pf_sexo", DbType.String, _bs_asignacion_beneficio.pf_sexo);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ListarGrillaBajas(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C28");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFuncionarioBajaX(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _bs_asignacion_beneficio.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C29");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarFechaBajaForm(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _bs_asignacion_beneficio.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_baja_elab", DbType.DateTime, _bs_asignacion_beneficio.ae_fecha_baja_elab);
                CNXSIGRH3.AddInParameter(icom, "p_ae_tipo_proceso_baja", DbType.String, _bs_asignacion_beneficio.ae_tipo_proceso_baja);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet obtenerIdAsignacionEGS(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C30");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerCantidadBajasEGS(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_param", DbType.String, _bs_asignacion_beneficio.param);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C31");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet listaFiltradoFamiliarBeneficio()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C32");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerSubsidio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.String, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ab_id", DbType.String, _bs_asignacion_beneficio.ab_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C33");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool CancelarSubsidio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_ab_id", DbType.Int32, _bs_asignacion_beneficio.ab_id);
                CNXSIGRH3.AddInParameter(icom, "p_ab_estado", DbType.String, _bs_asignacion_beneficio.ab_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U6");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ListarGrillaValidacionBajas(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C34");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarFechaRecepcionBaja(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _bs_asignacion_beneficio.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ae_fecha_baja_form", DbType.DateTime, _bs_asignacion_beneficio.ae_fecha_baja_form);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U7");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerFuncionarioValBajaX(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _bs_asignacion_beneficio.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C35");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerCantidadRecepBajasEGS(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_param", DbType.String, _bs_asignacion_beneficio.param);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C36");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDatosAfiliacion(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _bs_asignacion_beneficio.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C37");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool AdicionarFamiliarNuevo(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);

                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_tipo_parentesco", DbType.String, _bs_asignacion_beneficio.pf_tipo_parentesco);
                CNXSIGRH3.AddInParameter(icom, "p_pf_paterno", DbType.String, _bs_asignacion_beneficio.pf_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_pf_materno", DbType.String, _bs_asignacion_beneficio.pf_materno);
                CNXSIGRH3.AddInParameter(icom, "p_pf_nombres", DbType.String, _bs_asignacion_beneficio.pf_nombres);
                CNXSIGRH3.AddInParameter(icom, "p_pf_fecha_nac", DbType.DateTime, _bs_asignacion_beneficio.pf_fecha_nac);
                CNXSIGRH3.AddInParameter(icom, "p_pf_sexo", DbType.String, _bs_asignacion_beneficio.pf_sexo);
                CNXSIGRH3.AddInParameter(icom, "p_ci", DbType.String, _bs_asignacion_beneficio.pf_ci);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public override bool AdicionarFamiliarEGS()
        //{
        //    try
        //    {
        //        DbCommand icom = null;
        //        icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_ASIGNACION_BENEFICIO);
        //        CNXSIGRH3.AddInParameter(icom, "");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion

        #region _BS_AFP
        public override bool Adicionar__bs_afp(cls_bs_afp _bs_afp)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFP);
                
				CNXSIGRH3.AddInParameter(icom, "p_afp_per_id", DbType.Int32, _bs_afp.afp_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_afp_previsora", DbType.String, _bs_afp.afp_previsora);
				CNXSIGRH3.AddInParameter(icom, "p_afp_nua", DbType.String, _bs_afp.afp_nua);
				CNXSIGRH3.AddInParameter(icom, "p_afp_fecha_filiacion", DbType.DateTime, _bs_afp.afp_fecha_filiacion);
				CNXSIGRH3.AddInParameter(icom, "p_afp_fecha_modificacion", DbType.DateTime, _bs_afp.afp_fecha_modificacion);
				CNXSIGRH3.AddInParameter(icom, "p_afp_motivo_modificacion", DbType.String, _bs_afp.afp_motivo_modificacion);
				CNXSIGRH3.AddInParameter(icom, "p_afp_estado_carnet", DbType.String, _bs_afp.afp_estado_carnet);
				CNXSIGRH3.AddInParameter(icom, "p_afp_fecha_carnet", DbType.DateTime, _bs_afp.afp_fecha_carnet);
				CNXSIGRH3.AddInParameter(icom, "p_afp_usuario", DbType.Int32, _bs_afp.afp_usuario);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool CompletarDatosAFP(cls_bs_afp _bs_afp)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFP);

                CNXSIGRH3.AddInParameter(icom, "p_afp_id", DbType.Int32, _bs_afp.afp_id);
                CNXSIGRH3.AddInParameter(icom, "p_afp_per_id", DbType.Int32, _bs_afp.afp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_afp_previsora", DbType.String, _bs_afp.afp_previsora);
                CNXSIGRH3.AddInParameter(icom, "p_afp_nua", DbType.String, _bs_afp.afp_nua);
                CNXSIGRH3.AddInParameter(icom, "p_afp_fecha_filiacion", DbType.DateTime, _bs_afp.afp_fecha_filiacion);
                CNXSIGRH3.AddInParameter(icom, "p_afp_fecha_modificacion", DbType.DateTime, _bs_afp.afp_fecha_modificacion);
                CNXSIGRH3.AddInParameter(icom, "p_afp_motivo_modificacion", DbType.String, _bs_afp.afp_motivo_modificacion);
                CNXSIGRH3.AddInParameter(icom, "p_afp_estado_carnet", DbType.String, _bs_afp.afp_estado_carnet);
                CNXSIGRH3.AddInParameter(icom, "p_afp_fecha_carnet", DbType.DateTime, _bs_afp.afp_fecha_carnet);
                CNXSIGRH3.AddInParameter(icom, "p_afp_usuario", DbType.Int32, _bs_afp.afp_usuario);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar__bs_afp(cls_bs_afp _bs_afp)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFP);

				CNXSIGRH3.AddInParameter(icom, "p_afp_id", DbType.Int32, _bs_afp.afp_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool ActualizarEstadoAFP(cls_bs_afp _bs_afp)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFP);

                CNXSIGRH3.AddInParameter(icom, "p_afp_id", DbType.Int32, _bs_afp.afp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Actualizar__bs_afp(cls_bs_afp _bs_afp)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFP);

				CNXSIGRH3.AddInParameter(icom, "p_afp_id", DbType.Int32, _bs_afp.afp_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerRegistro__bs_afp(cls_bs_afp _bs_afp)
		{
			try
			{
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFP);

                CNXSIGRH3.AddInParameter(icom, "p_afp_per_id", DbType.Int32, _bs_afp.afp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaGrilla__bs_afp(string afp_id, 
						string afp_per_id, 
						string afp_previsora, 
						string afp_fecha_filiacion, 
						string afp_fecha_modificacion, 
						string afp_motivo_modificacion, 
						string afp_fecha_registro, 
						string afp_estado_carnet, 
						string afp_fecha_carnet, 
						string afp_usuario, 
						string afp_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFP);

				if (afp_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_afp_id", DbType.Int32, Convert.ToInt32(afp_id)); }
				if (afp_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_afp_per_id", DbType.Int32, Convert.ToInt32(afp_per_id)); }
				if (afp_previsora.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_afp_previsora", DbType.String, Convert.ToString(afp_previsora)); }
				if (afp_fecha_filiacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_afp_fecha_filiacion", DbType.DateTime, Convert.ToDateTime(afp_fecha_filiacion)); }
				if (afp_fecha_modificacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_afp_fecha_modificacion", DbType.DateTime, Convert.ToDateTime(afp_fecha_modificacion)); }
				if (afp_motivo_modificacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_afp_motivo_modificacion", DbType.String, Convert.ToString(afp_motivo_modificacion)); }
				if (afp_fecha_registro.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_afp_fecha_registro", DbType.DateTime, Convert.ToDateTime(afp_fecha_registro)); }
				if (afp_estado_carnet.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_afp_estado_carnet", DbType.String, Convert.ToString(afp_estado_carnet)); }
				if (afp_fecha_carnet.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_afp_fecha_carnet", DbType.DateTime, Convert.ToDateTime(afp_fecha_carnet)); }
				if (afp_usuario.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_afp_usuario", DbType.Int32, Convert.ToInt32(afp_usuario)); }
				if (afp_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_afp_estado", DbType.String, Convert.ToString(afp_estado)); }
 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__bs_afp()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFP);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerDetalleFuncionario(cls_bs_afp _bs_afp)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFP);

                CNXSIGRH3.AddInParameter(icom, "p_afp_per_id", DbType.String, _bs_afp.afp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.String, _bs_afp.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrillaAFP(cls_bs_afp _bs_afp)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFP);

                CNXSIGRH3.AddInParameter(icom, "p_afp_per_id", DbType.String, _bs_afp.afp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarCuaNua(cls_bs_afp _bs_afp)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFP);
                CNXSIGRH3.AddInParameter(icom, "p_afp_nua", DbType.String, _bs_afp.afp_nua);
                CNXSIGRH3.AddInParameter(icom, "p_afp_per_id", DbType.String, _bs_afp.afp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarAfp(cls_bs_afp _bs_afp)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__BS_AFP);
                CNXSIGRH3.AddInParameter(icom, "p_afp_previsora", DbType.String, _bs_afp.afp_previsora);
                CNXSIGRH3.AddInParameter(icom, "p_afp_per_id", DbType.String, _bs_afp.afp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BS_SUBSIDIO
        public override DataSet BuscarAfiliacionEGS(string per_id, string per_num_doc, string per_ap_paterno, string per_ap_materno, string per_nombres, string per_ap_casada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_aux_subsidio");
                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
                if (per_num_doc.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, Convert.ToString(per_num_doc)); }
                if (per_ap_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, Convert.ToString(per_ap_paterno)); }
                if (per_ap_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, Convert.ToString(per_ap_materno)); }
                if (per_nombres.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, Convert.ToString(per_nombres)); }
                if (per_ap_casada.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_casada", DbType.String, Convert.ToString(per_ap_casada)); }
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ActualizarDatosFamiliarNuevo(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_aux_subsidio");
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.Int32, _bs_asignacion_beneficio.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_fecha_nac", DbType.DateTime, _bs_asignacion_beneficio.pf_fecha_nac);
                CNXSIGRH3.AddInParameter(icom, "p_pf_sexo", DbType.String, _bs_asignacion_beneficio.pf_sexo);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ListarFamiliaresNuevo(cls_bs_asignacion_beneficio _bs_asignacion_beneficio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_aux_subsidio");
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.String, _bs_asignacion_beneficio.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EditarDatosFamiliar(Subsidio familiar)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_bs_Subsidio");
                CNXSIGRH3.AddInParameter(icom, "pf_ap_esposo", DbType.String, familiar.ap_esposo);
                CNXSIGRH3.AddInParameter(icom, "pf_ap_pat", DbType.String, familiar.ap_paterno);
                CNXSIGRH3.AddInParameter(icom, "pf_ap_mat", DbType.String, familiar.ap_materno);
                CNXSIGRH3.AddInParameter(icom, "pf_nombre", DbType.String, familiar.pf_nombre);
                CNXSIGRH3.AddInParameter(icom, "pf_ci", DbType.String, familiar.pf_ci);
                CNXSIGRH3.AddInParameter(icom, "pf_sexo", DbType.String, familiar.pf_sexo);
                CNXSIGRH3.AddInParameter(icom, "pf_fecha_nac", DbType.String, familiar.fecha_nac);
                CNXSIGRH3.AddInParameter(icom, "pf_parentesco", DbType.Int32, familiar.tipo_parentesco);
                CNXSIGRH3.AddInParameter(icom, "pf_id", DbType.Int32, familiar.pf_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "U");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerDatosPersona(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_aux_subsidio");
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C2");
                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, per_id);
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerDatosBeneficiario(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_aux_subsidio");
                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C3");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int VerificarAfiliacionFamiliar(int pf_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_aux_subsidio");
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C4");
                CNXSIGRH3.AddInParameter(icom, "pf_id", DbType.Int32, pf_id);
                int x = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom));
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
