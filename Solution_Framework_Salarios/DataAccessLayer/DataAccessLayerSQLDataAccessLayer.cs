using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

using Solution_Framework_Salarios.BussinessLogicLayer;
using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
	public class DataAccessLayerSQLDataAccessLayer : DataAccessLayerDataAccessLayer
	{
		#region CONSTANTES
		private string SP__PLA_TRANSACCIONES_ACREEDOR = "sp_pla_transacciones_acreedor";
		private string GenerarAsistencia_Indiv = "GenararAsistencia_Individual";
		private string SP__PLA_ACREEDOR_RETENCION = "sp_pla_acreedor_retencion";
		private string SP__MP_ASIGNACION_TIPO_APORTANTE = "sp_mp_asignacion_tipo_aportante";
		private string SP__PLA_CAS = "sp_pla_cas";
		private string SP__PLA_PROCESO = "sp_pla_proceso";
		private string SP__ACREEDORES = "sp_acreedores";
		private string SP__PLA_TRANSACCIONES_CUOTAS = "sp_pla_transacciones_cuotas";
		private string SP__PLA_TRANSACCIONES = "sp_pla_transacciones";
		private string SP__PLA_FACTOR = "sp_pla_factor";
		private string SP_RETROACTIVO = "SP_PLA_SUELDO_RETROACTIVO";
		#endregion

		//INTERFACES
		#region _PLA_TRANSACCIONES_ACREEDOR
		public override bool Adicionar__pla_transacciones_acreedor(cls_pla_transacciones_acreedor _pla_transacciones_acreedor)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES_ACREEDOR);
				CNXSIGRH3.AddInParameter(icom, "p_tra_acr_id", DbType.Int32, _pla_transacciones_acreedor.tra_acr_id);
				CNXSIGRH3.AddInParameter(icom, "p_tra_tr_id", DbType.Int32, _pla_transacciones_acreedor.tra_tr_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override bool Eliminar__pla_transacciones_acreedor(cls_pla_transacciones_acreedor _pla_transacciones_acreedor)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES_ACREEDOR);
				CNXSIGRH3.AddInParameter(icom, "p_tra_acr_id", DbType.Int32, _pla_transacciones_acreedor.tra_acr_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override bool Actualizar__pla_transacciones_acreedor(cls_pla_transacciones_acreedor _pla_transacciones_acreedor)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES_ACREEDOR);
				CNXSIGRH3.AddInParameter(icom, "p_tra_acr_id", DbType.Int32, _pla_transacciones_acreedor.tra_acr_id);
				CNXSIGRH3.AddInParameter(icom, "p_tra_tr_id", DbType.Int32, _pla_transacciones_acreedor.tra_tr_id);
				CNXSIGRH3.AddInParameter(icom, "p_tra_estado", DbType.String, _pla_transacciones_acreedor.tra_estado);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override DataSet ObtenerRegistro__pla_transacciones_acreedor(cls_pla_transacciones_acreedor _pla_transacciones_acreedor)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES_ACREEDOR);
				CNXSIGRH3.AddInParameter(icom, "p_tra_acr_id", DbType.Int32, _pla_transacciones_acreedor.tra_acr_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		public override DataSet ObtenerTablaGrilla__pla_transacciones_acreedor(
			string tra_acr_id,
			string tra_tr_id,
			string tra_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES_ACREEDOR);

				if (tra_acr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tra_acr_id", DbType.Int32, Convert.ToInt32(tra_acr_id)); }
				if (tra_tr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tra_tr_id", DbType.Int32, Convert.ToInt32(tra_tr_id)); }
				if (tra_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tra_estado", DbType.String, Convert.ToString(tra_estado)); }
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		public override DataSet ObtenerTablaCombo__pla_transacciones_acreedor()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES_ACREEDOR);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}
		#endregion

		#region _PLA_ACREEDOR_RETENCION
		public override int Adicionar__pla_acreedor_retencion(cls_pla_acreedor_retencion _pla_acreedor_retencion)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_ACREEDOR_RETENCION);
				CNXSIGRH3.AddInParameter(icom, "p_acr_tipo_entidad", DbType.String, _pla_acreedor_retencion.acr_tipo_entidad);
				CNXSIGRH3.AddInParameter(icom, "p_acr_descripcion", DbType.String, _pla_acreedor_retencion.acr_descripcion);
				CNXSIGRH3.AddInParameter(icom, "p_acr_documento", DbType.String, _pla_acreedor_retencion.acr_documento);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				int id = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom).ToString());
				return id;
			}
			catch (Exception ex) { throw ex; }
		}

		public override bool Eliminar__pla_acreedor_retencion(cls_pla_acreedor_retencion _pla_acreedor_retencion)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_ACREEDOR_RETENCION);
				CNXSIGRH3.AddInParameter(icom, "p_acr_id", DbType.Int32, _pla_acreedor_retencion.acr_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override bool Actualizar__pla_acreedor_retencion(cls_pla_acreedor_retencion _pla_acreedor_retencion)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_ACREEDOR_RETENCION);
				CNXSIGRH3.AddInParameter(icom, "p_acr_id", DbType.Int32, _pla_acreedor_retencion.acr_id);
				CNXSIGRH3.AddInParameter(icom, "p_acr_tipo_entidad", DbType.String, _pla_acreedor_retencion.acr_tipo_entidad);
				CNXSIGRH3.AddInParameter(icom, "p_acr_descripcion", DbType.String, _pla_acreedor_retencion.acr_descripcion);
				CNXSIGRH3.AddInParameter(icom, "p_acr_documento", DbType.String, _pla_acreedor_retencion.acr_documento);
				CNXSIGRH3.AddInParameter(icom, "p_acr_estado", DbType.String, _pla_acreedor_retencion.acr_estado);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override DataSet ObtenerRegistro__pla_acreedor_retencion(cls_pla_acreedor_retencion _pla_acreedor_retencion)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_ACREEDOR_RETENCION);
				CNXSIGRH3.AddInParameter(icom, "p_acr_id", DbType.Int32, _pla_acreedor_retencion.acr_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		public override DataSet ObtenerTablaGrilla__pla_acreedor_retencion(
			string acr_id,
			string acr_tipo_entidad,
			string acr_descripcion,
			string acr_documento,
			string acr_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_ACREEDOR_RETENCION);

				if (acr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_acr_id", DbType.Int32, Convert.ToInt32(acr_id)); }
				if (acr_tipo_entidad.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_acr_tipo_entidad", DbType.String, Convert.ToString(acr_tipo_entidad)); }
				if (acr_descripcion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_acr_descripcion", DbType.String, Convert.ToString(acr_descripcion)); }
				if (acr_documento.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_acr_documento", DbType.String, Convert.ToString(acr_documento)); }
				if (acr_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_acr_estado", DbType.String, Convert.ToString(acr_estado)); }
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		public override DataSet ObtenerTablaCombo__pla_acreedor_retencion()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_ACREEDOR_RETENCION);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		// (KCPB) 
		public override DataSet ObtenerTablaGrillaF__pla_acreedor_retencion(string acr_per_id)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_ACREEDOR_RETENCION);

				if (acr_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_acr_per_id", DbType.Int32, Convert.ToInt32(acr_per_id)); }
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}
		#endregion

		#region _MP_ASIGNACION_TIPO_APORTANTE
		public override bool Adicionar__mp_asignacion_tipo_aportante(cls_mp_asignacion_tipo_aportante _mp_asignacion_tipo_aportante)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_TIPO_APORTANTE);
				CNXSIGRH3.AddInParameter(icom, "p_at_id", DbType.Int32, _mp_asignacion_tipo_aportante.at_id);
				CNXSIGRH3.AddInParameter(icom, "p_at_per_id", DbType.Int32, _mp_asignacion_tipo_aportante.at_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_at_ta_id", DbType.Int32, _mp_asignacion_tipo_aportante.at_ta_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override bool Eliminar__mp_asignacion_tipo_aportante(cls_mp_asignacion_tipo_aportante _mp_asignacion_tipo_aportante)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_TIPO_APORTANTE);
				CNXSIGRH3.AddInParameter(icom, "p_at_id", DbType.Int32, _mp_asignacion_tipo_aportante.at_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override bool Actualizar__mp_asignacion_tipo_aportante(cls_mp_asignacion_tipo_aportante _mp_asignacion_tipo_aportante)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_TIPO_APORTANTE);
				CNXSIGRH3.AddInParameter(icom, "p_at_id", DbType.Int32, _mp_asignacion_tipo_aportante.at_id);
				CNXSIGRH3.AddInParameter(icom, "p_at_per_id", DbType.Int32, _mp_asignacion_tipo_aportante.at_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_at_ta_id", DbType.Int32, _mp_asignacion_tipo_aportante.at_ta_id);
				CNXSIGRH3.AddInParameter(icom, "p_at_estado", DbType.String, _mp_asignacion_tipo_aportante.at_estado);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override bool ObtenerId__mp_asignacion_tipo_aportante(cls_mp_asignacion_tipo_aportante _mp_asignacion_tipo_aportante)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_TIPO_APORTANTE);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				_mp_asignacion_tipo_aportante.at_id = Convert.ToInt32(ds.Tables[0].Rows[0]["at_id"]);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override DataSet ObtenerRegistro__mp_asignacion_tipo_aportante(cls_mp_asignacion_tipo_aportante _mp_asignacion_tipo_aportante)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_TIPO_APORTANTE);
				CNXSIGRH3.AddInParameter(icom, "p_at_id", DbType.Int32, _mp_asignacion_tipo_aportante.at_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		public override DataSet ObtenerTablaGrilla__mp_asignacion_tipo_aportante(
			string at_id,
			string at_per_id,
			string at_ta_id,
			string at_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_TIPO_APORTANTE);

				if (at_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_at_id", DbType.Int32, Convert.ToInt32(at_id)); }
				if (at_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_at_per_id", DbType.Int32, Convert.ToInt32(at_per_id)); }
				if (at_ta_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_at_ta_id", DbType.Int32, Convert.ToInt32(at_ta_id)); }
				if (at_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_at_estado", DbType.String, Convert.ToString(at_estado)); }
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		public override DataSet ObtenerTablaCombo__mp_asignacion_tipo_aportante()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_TIPO_APORTANTE);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		// (KCPB)
		public override DataSet ObtenerTablaGrillaC__mp_asignacion_tipo_aportante(
			string at_id,
			string at_per_id,
			string at_ta_id,
			string at_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_TIPO_APORTANTE);

				if (at_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_at_id", DbType.Int32, Convert.ToInt32(at_id)); }
				if (at_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_at_per_id", DbType.Int32, Convert.ToInt32(at_per_id)); }
				if (at_ta_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_at_ta_id", DbType.Int32, Convert.ToInt32(at_ta_id)); }
				if (at_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_at_estado", DbType.String, Convert.ToString(at_estado)); }
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		// (KCPB)
		public override DataSet ObtenerRegistroTA__mp_asignacion_tipo_aportante(cls_mp_asignacion_tipo_aportante _mp_asignacion_tipo_aportante)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_TIPO_APORTANTE);
				CNXSIGRH3.AddInParameter(icom, "p_at_ta_id", DbType.Int32, _mp_asignacion_tipo_aportante.at_ta_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		// (KCPB)
		public override DataSet ObtenerTablaComboTA__mp_asignacion_tipo_aportante(
			int at_edad,
			bool at_jubilado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_TIPO_APORTANTE);
				CNXSIGRH3.AddInParameter(icom, "p_at_edad", DbType.Int32, Convert.ToInt32(at_edad));
				CNXSIGRH3.AddInParameter(icom, "p_at_jubilado", DbType.Boolean, Convert.ToBoolean(at_jubilado));
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}
		#endregion

		#region _PLA_CAS
		public override bool Adicionar__pla_cas(cls_pla_cas _pla_cas)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_CAS);
				CNXSIGRH3.AddInParameter(icom, "p_cs_id", DbType.Int32, _pla_cas.cs_id);
				CNXSIGRH3.AddInParameter(icom, "p_cs_per_id", DbType.Int32, _pla_cas.cs_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_cs_res_adm", DbType.String, _pla_cas.cs_res_adm);
				CNXSIGRH3.AddInParameter(icom, "p_cs_nro_cas", DbType.String, _pla_cas.cs_nro_cas);
				CNXSIGRH3.AddInParameter(icom, "p_cs_fecha_cas", DbType.DateTime, _pla_cas.cs_fecha_cas);
				CNXSIGRH3.AddInParameter(icom, "p_cs_anos", DbType.Int32, _pla_cas.cs_anos);
				CNXSIGRH3.AddInParameter(icom, "p_cs_meses", DbType.Int32, _pla_cas.cs_meses);
				CNXSIGRH3.AddInParameter(icom, "p_cs_dias", DbType.Int32, _pla_cas.cs_dias);
				CNXSIGRH3.AddInParameter(icom, "p_cs_tipo_reg", DbType.String, _pla_cas.cs_tipo_reg);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override bool Eliminar__pla_cas(cls_pla_cas _pla_cas)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_CAS);
				CNXSIGRH3.AddInParameter(icom, "p_cs_id", DbType.Int32, _pla_cas.cs_id);
				CNXSIGRH3.AddInParameter(icom, "p_cs_estado", DbType.String, _pla_cas.cs_estado);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override bool Actualizar__pla_cas(cls_pla_cas _pla_cas)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_CAS);
				CNXSIGRH3.AddInParameter(icom, "p_cs_id", DbType.Int32, _pla_cas.cs_id);
				CNXSIGRH3.AddInParameter(icom, "p_cs_res_adm", DbType.String, _pla_cas.cs_res_adm);
				CNXSIGRH3.AddInParameter(icom, "p_cs_nro_cas", DbType.String, _pla_cas.cs_nro_cas);
				CNXSIGRH3.AddInParameter(icom, "p_cs_fecha_cas", DbType.DateTime, _pla_cas.cs_fecha_cas);
				CNXSIGRH3.AddInParameter(icom, "p_cs_anos", DbType.Int32, _pla_cas.cs_anos);
				CNXSIGRH3.AddInParameter(icom, "p_cs_meses", DbType.Int32, _pla_cas.cs_meses);
				CNXSIGRH3.AddInParameter(icom, "p_cs_dias", DbType.Int32, _pla_cas.cs_dias);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override bool ObtenerId__pla_cas(cls_pla_cas _pla_cas)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_CAS);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				_pla_cas.cs_id = Convert.ToInt32(ds.Tables[0].Rows[0]["cs_id"]);
				return true;
			}
			catch (Exception ex) { throw ex; }
		}

		public override DataSet ObtenerRegistro__pla_cas(cls_pla_cas _pla_cas)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_CAS);
				CNXSIGRH3.AddInParameter(icom, "p_cs_id", DbType.Int32, _pla_cas.cs_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		public override DataSet ObtenerTablaGrilla__pla_cas(
			string cs_id,
			string cs_per_id,
			string cs_res_adm,
			string cs_nro_cas,
			string cs_fecha_cas,
			string cs_anos,
			string cs_meses,
			string cs_dias,
			string cs_tipo_reg,
			string cs_procesado,
			string cs_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_CAS);

				if (cs_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_id", DbType.Int32, Convert.ToInt32(cs_id)); }
				if (cs_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_per_id", DbType.Int32, Convert.ToInt32(cs_per_id)); }
				if (cs_res_adm.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_res_adm", DbType.String, Convert.ToString(cs_res_adm)); }
				if (cs_nro_cas.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_nro_cas", DbType.String, Convert.ToString(cs_nro_cas)); }
				if (cs_fecha_cas.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_fecha_cas", DbType.DateTime, Convert.ToDateTime(cs_fecha_cas)); }
				if (cs_anos.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_anos", DbType.Int32, Convert.ToInt32(cs_anos)); }
				if (cs_meses.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_meses", DbType.Int32, Convert.ToInt32(cs_meses)); }
				if (cs_dias.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_dias", DbType.Int32, Convert.ToInt32(cs_dias)); }
				if (cs_tipo_reg.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_tipo_reg", DbType.String, Convert.ToString(cs_tipo_reg)); }
				if (cs_procesado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_procesado", DbType.String, Convert.ToString(cs_procesado)); }
				if (cs_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_estado", DbType.String, Convert.ToString(cs_estado)); }
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		public override DataSet ObtenerTablaCombo__pla_cas()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_CAS);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		// (KCPB)
		public override DataSet ObtenerTablaGrillaC__pla_cas(
			string cs_id,
			string cs_per_id,
			string cs_res_adm,
			string cs_nro_cas,
			string cs_fecha_cas,
			string cs_anos,
			string cs_meses,
			string cs_dias,
			string cs_tipo_reg,
			string cs_procesado,
			string cs_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_CAS);

				if (cs_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_id", DbType.Int32, Convert.ToInt32(cs_id)); }
				if (cs_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_per_id", DbType.Int32, Convert.ToInt32(cs_per_id)); }
				if (cs_res_adm.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_res_adm", DbType.String, Convert.ToString(cs_res_adm)); }
				if (cs_nro_cas.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_nro_cas", DbType.String, Convert.ToString(cs_nro_cas)); }
				if (cs_fecha_cas.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_fecha_cas", DbType.DateTime, Convert.ToDateTime(cs_fecha_cas)); }
				if (cs_anos.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_anos", DbType.Int32, Convert.ToInt32(cs_anos)); }
				if (cs_meses.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_meses", DbType.Int32, Convert.ToInt32(cs_meses)); }
				if (cs_dias.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_dias", DbType.Int32, Convert.ToInt32(cs_dias)); }
				if (cs_tipo_reg.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_tipo_reg", DbType.String, Convert.ToString(cs_tipo_reg)); }
				if (cs_procesado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_procesado", DbType.String, Convert.ToString(cs_procesado)); }
				if (cs_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cs_estado", DbType.String, Convert.ToString(cs_estado)); }
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		// (KCPB)
		public override DataSet ObtenerRegistroPB__pla_cas(cls_pla_cas _pla_cas)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_CAS);
				CNXSIGRH3.AddInParameter(icom, "p_cs_anos", DbType.Int32, _pla_cas.cs_anos);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}
        public override double ObtenerHaberBasico_3Minimos()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_CAS);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
				return Convert.ToDouble( CNXSIGRH3.ExecuteDataSet(icom).Tables[0].Rows[0]["minimos_bonos"].ToString());
			}
			catch (Exception ex) { throw ex; }
		}
		#endregion

		#region _PLA_PROCESO
		public override bool Procesar_Sanciones(int codigo)
        {
            try
            {
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SANCIONES_NUEVO");
				CNXSIGRH3.AddInParameter(icom, "CODIGO_PROCESO", DbType.Int32, codigo);
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Procesar_Sanciones_Adicional(int secuencial, int pc_id, int tipo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SANCIONES_NUEVO_ADICIONAL_X");
                CNXSIGRH3.AddInParameter(icom, "PLANILLA", DbType.Int32, secuencial);
				CNXSIGRH3.AddInParameter(icom, "CODIGO_PROCESO", DbType.Int32, pc_id);
				CNXSIGRH3.AddInParameter(icom, "TIPO", DbType.Int32, tipo);
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Adicionar__pla_proceso(cls_pla_proceso_salarios _pla_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				CNXSIGRH3.AddInParameter(icom, "p_pc_id", DbType.Int32, _pla_proceso.pc_id);
				CNXSIGRH3.AddInParameter(icom, "p_pc_pr_id", DbType.Int32, _pla_proceso.pc_pr_id);
				CNXSIGRH3.AddInParameter(icom, "p_pc_titulo", DbType.String, _pla_proceso.pc_titulo);
				CNXSIGRH3.AddInParameter(icom, "p_pc_fecha_inicio", DbType.DateTime, _pla_proceso.pc_fecha_inicio);
				CNXSIGRH3.AddInParameter(icom, "p_pc_fecha_fin", DbType.DateTime, _pla_proceso.pc_fecha_fin);
				CNXSIGRH3.AddInParameter(icom, "p_pc_mn_id", DbType.Int32, _pla_proceso.pc_mn_id);
				CNXSIGRH3.AddInParameter(icom, "p_pc_ufv", DbType.Double, _pla_proceso.pc_ufv);
				CNXSIGRH3.AddInParameter(icom, "p_pc_ufv_fecha", DbType.DateTime, _pla_proceso.pc_ufv_fecha);
				CNXSIGRH3.AddInParameter(icom, "p_pc_estado", DbType.String, _pla_proceso.pc_estado);
				CNXSIGRH3.AddInParameter(icom, "p_pc_prefijo", DbType.String, _pla_proceso.pc_prefijo);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Eliminar__pla_proceso(cls_pla_proceso_salarios _pla_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				CNXSIGRH3.AddInParameter(icom, "p_pc_id", DbType.Int32, _pla_proceso.pc_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Actualizar__pla_proceso(cls_pla_proceso_salarios _pla_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				CNXSIGRH3.AddInParameter(icom, "p_pc_ufv", DbType.Double, _pla_proceso.pc_ufv);
				CNXSIGRH3.AddInParameter(icom, "p_pc_ufv_fecha", DbType.String, _pla_proceso.pc_ufv_fecha);
				CNXSIGRH3.AddInParameter(icom, "p_pc_id", DbType.Int32, _pla_proceso.pc_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U1");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerId__pla_proceso(cls_pla_proceso_salarios _pla_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_pla_proceso.pc_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pc_id"]);

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerRegistro__pla_proceso(cls_pla_proceso_salarios _pla_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				CNXSIGRH3.AddInParameter(icom, "p_pc_id", DbType.Int32, _pla_proceso.pc_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				if (ds.Tables[0].Rows[0]["pc_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pc_id"].ToString().Trim() != "") { _pla_proceso.pc_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pc_id"]); }
				if (ds.Tables[0].Rows[0]["pc_pr_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pc_pr_id"].ToString().Trim() != "") { _pla_proceso.pc_pr_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pc_pr_id"]); }
				if (ds.Tables[0].Rows[0]["pc_titulo"] != DBNull.Value && ds.Tables[0].Rows[0]["pc_titulo"].ToString().Trim() != "") { _pla_proceso.pc_titulo = Convert.ToString(ds.Tables[0].Rows[0]["pc_titulo"]); }
				if (ds.Tables[0].Rows[0]["pc_fecha_inicio"] != DBNull.Value && ds.Tables[0].Rows[0]["pc_fecha_inicio"].ToString().Trim() != "") { _pla_proceso.pc_fecha_inicio = Convert.ToString(ds.Tables[0].Rows[0]["pc_fecha_inicio"]); }
				if (ds.Tables[0].Rows[0]["pc_fecha_fin"] != DBNull.Value && ds.Tables[0].Rows[0]["pc_fecha_fin"].ToString().Trim() != "") { _pla_proceso.pc_fecha_fin = Convert.ToString(ds.Tables[0].Rows[0]["pc_fecha_fin"]); }
				if (ds.Tables[0].Rows[0]["pc_mn_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pc_mn_id"].ToString().Trim() != "") { _pla_proceso.pc_mn_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pc_mn_id"]); }
				if (ds.Tables[0].Rows[0]["pc_ufv"] != DBNull.Value && ds.Tables[0].Rows[0]["pc_ufv"].ToString().Trim() != "") { _pla_proceso.pc_ufv = Convert.ToDouble(ds.Tables[0].Rows[0]["pc_ufv"]); }
				if (ds.Tables[0].Rows[0]["pc_ufv_fecha"] != DBNull.Value && ds.Tables[0].Rows[0]["pc_ufv_fecha"].ToString().Trim() != "") { _pla_proceso.pc_ufv_fecha = Convert.ToString(ds.Tables[0].Rows[0]["pc_ufv_fecha"]); }
				if (ds.Tables[0].Rows[0]["pc_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["pc_estado"].ToString().Trim() != "") { _pla_proceso.pc_estado = Convert.ToString(ds.Tables[0].Rows[0]["pc_estado"]); }
				if (ds.Tables[0].Rows[0]["pc_prefijo"] != DBNull.Value && ds.Tables[0].Rows[0]["pc_prefijo"].ToString().Trim() != "") { _pla_proceso.pc_prefijo = Convert.ToString(ds.Tables[0].Rows[0]["pc_prefijo"]); }
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaGrilla__pla_proceso(string pc_id,
						string pc_pr_id,
						string pc_titulo,
						string pc_fecha_inicio,
						string pc_fecha_fin,
						string pc_mn_id,
						string pc_ufv,
						string pc_ufv_fecha,
						string pc_estado,
						string pc_prefijo)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				if (pc_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pc_id", DbType.Int32, Convert.ToInt32(pc_id)); }
				if (pc_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pc_pr_id", DbType.Int32, Convert.ToInt32(pc_pr_id)); }
				if (pc_titulo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pc_titulo", DbType.String, Convert.ToString(pc_titulo)); }
				if (pc_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pc_fecha_inicio", DbType.DateTime, Convert.ToDateTime(pc_fecha_inicio)); }
				if (pc_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pc_fecha_fin", DbType.DateTime, Convert.ToDateTime(pc_fecha_fin)); }
				if (pc_mn_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pc_mn_id", DbType.Int32, Convert.ToInt32(pc_mn_id)); }
				if (pc_ufv.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pc_ufv", DbType.Double, Convert.ToDouble(pc_ufv)); }
				if (pc_ufv_fecha.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pc_ufv_fecha", DbType.DateTime, Convert.ToDateTime(pc_ufv_fecha)); }
				if (pc_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pc_estado", DbType.String, Convert.ToString(pc_estado)); }
				if (pc_prefijo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pc_prefijo", DbType.String, Convert.ToString(pc_prefijo)); }

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__pla_proceso()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet ObtenerUFVAnterior(cls_pla_proceso_salarios _pla_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				CNXSIGRH3.AddInParameter(icom, "p_pc_pr_id", DbType.Int32, _pla_proceso.pc_pr_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet ObtenerSalarioMinimo(cls_pla_proceso_salarios _pla_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				CNXSIGRH3.AddInParameter(icom, "p_pc_pr_id", DbType.Int32, _pla_proceso.pc_pr_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet ObtenerSalarioMinimoAdicional(cls_pla_proceso_salarios _pla_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				CNXSIGRH3.AddInParameter(icom, "p_pc_id", DbType.Int32, _pla_proceso.pc_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerUFVActual(cls_pla_proceso_salarios _pla_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				CNXSIGRH3.AddInParameter(icom, "p_pc_pr_id", DbType.Int32, _pla_proceso.pc_pr_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerMesesProceso()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet ObtenerMesesProceso_Liquidos()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet EjecutarProceso1(int cod_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO");

				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, cod_proceso);

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet EjecutarProceso2(int cod_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_COTIZABLES");
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, cod_proceso);
				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet EjecutarProceso3(int cod_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_AFP");
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, cod_proceso);
				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet EjecutarProceso4(int cod_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_DESCUENTOS");
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, cod_proceso);

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public override DataSet EjecutarProceso1_adicional(int cod_proceso, int secuencial)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_ADICIONAL");

				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, cod_proceso);
				CNXSIGRH3.AddInParameter(icom, "SECUENCIAL", DbType.Int32, secuencial);

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet EjecutarProceso2_adicional(int cod_proceso, int secuencial)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_COTIZABLES_ADICIONAL");
				CNXSIGRH3.AddInParameter(icom, "SECUENCIAL", DbType.Int32, secuencial);
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, cod_proceso);
				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet EjecutarProceso3_adicional(int cod_proceso, int secuencial)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_AFP_ADICIONAL");
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, cod_proceso);
				CNXSIGRH3.AddInParameter(icom, "SECUENCIAL", DbType.Int32, secuencial);
				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet EjecutarProceso4_adicional(int cod_proceso, int secuencial)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_DESCUENTOS_ADICIONAL");
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, cod_proceso);
				CNXSIGRH3.AddInParameter(icom, "SECUENCIAL", DbType.Int32, secuencial);

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet VerificarCasosDoblePercepcion(int cod_proceso, string accion)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_D_PERCEPCION");
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, cod_proceso);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, accion);

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet VerificarCasosDoblePercepcion_adicional(int cod_proceso, string accion, string secuencial)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_D_PERCEPCION_ADICIONAL");
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "SECUENCIAL", DbType.Int32, Convert.ToInt32(secuencial));

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, accion);

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet AjusteDoblePercepcion_adicional(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_D_PERCEPCION_AJUSTE_ADICIONAL");
				CNXSIGRH3.AddInParameter(icom, "TI_TIPO", DbType.String, ti_tipo);
				CNXSIGRH3.AddInParameter(icom, "CBH_ID", DbType.Int32, cbh_id);
				CNXSIGRH3.AddInParameter(icom, "HORAS", DbType.Int32, horas);
				CNXSIGRH3.AddInParameter(icom, "GANADO", DbType.Double, ganado);
				CNXSIGRH3.AddInParameter(icom, "ESC_POR", DbType.Double, esc_por);
				CNXSIGRH3.AddInParameter(icom, "ESC", DbType.Double, esc);
				CNXSIGRH3.AddInParameter(icom, "BONO_A", DbType.Double, bono_a);
				CNXSIGRH3.AddInParameter(icom, "BONO_F", DbType.Double, bono_f);

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet AjusteDoblePercepcion(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_D_PERCEPCION_AJUSTE");
				CNXSIGRH3.AddInParameter(icom, "TI_TIPO", DbType.String, ti_tipo);
				CNXSIGRH3.AddInParameter(icom, "CBH_ID", DbType.Int32, cbh_id);
				CNXSIGRH3.AddInParameter(icom, "HORAS", DbType.Int32, horas);
				CNXSIGRH3.AddInParameter(icom, "GANADO", DbType.Double, ganado);
				CNXSIGRH3.AddInParameter(icom, "ESC_POR", DbType.Double,  esc_por);
				CNXSIGRH3.AddInParameter(icom, "ESC", DbType.Double, esc);
				CNXSIGRH3.AddInParameter(icom, "BONO_A", DbType.Double, bono_a);
				CNXSIGRH3.AddInParameter(icom, "BONO_F", DbType.Double, bono_f);

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override bool AplicarAjusteDoblePercepcion_adicional(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_D_PERCEPCION_APLICAR_ADICIONAL");
				CNXSIGRH3.AddInParameter(icom, "TI_TIPO", DbType.String, ti_tipo);
				CNXSIGRH3.AddInParameter(icom, "CBH_ID", DbType.Int32, cbh_id);
				CNXSIGRH3.AddInParameter(icom, "HORAS", DbType.Int32, horas);
				CNXSIGRH3.AddInParameter(icom, "GANADO", DbType.Double, ganado);
				CNXSIGRH3.AddInParameter(icom, "ESC_POR", DbType.Double, esc_por);
				CNXSIGRH3.AddInParameter(icom, "ESC", DbType.Double, esc);
				CNXSIGRH3.AddInParameter(icom, "BONO_A", DbType.Double, bono_a);
				CNXSIGRH3.AddInParameter(icom, "BONO_F", DbType.Double, bono_f);

				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool AplicarAjusteDoblePercepcion(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_D_PERCEPCION_APLICAR");
				CNXSIGRH3.AddInParameter(icom, "TI_TIPO", DbType.String, ti_tipo);
				CNXSIGRH3.AddInParameter(icom, "CBH_ID", DbType.Int32, cbh_id);
				CNXSIGRH3.AddInParameter(icom, "HORAS", DbType.Int32, horas);
				CNXSIGRH3.AddInParameter(icom, "GANADO", DbType.Double, ganado);
				CNXSIGRH3.AddInParameter(icom, "ESC_POR", DbType.Double, esc_por);
				CNXSIGRH3.AddInParameter(icom, "ESC", DbType.Double, esc);
				CNXSIGRH3.AddInParameter(icom, "BONO_A", DbType.Double, bono_a);
				CNXSIGRH3.AddInParameter(icom, "BONO_F", DbType.Double, bono_f);

				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool GenerarCarpetas_C31(int cod_proceso)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("GenerarC31");
				CNXSIGRH3.AddInParameter(icom, "CODIGO_PROCESO", DbType.Int32, cod_proceso);

				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet Combos_C31(int cod_proceso, string accion)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_min_eco");
				CNXSIGRH3.AddInParameter(icom, "p_cod_proceso", DbType.Int32, cod_proceso);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, accion);
				return CNXSIGRH3.ExecuteDataSet(icom);
				
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet GenerarRegistroC31_4(string tipo_planilla, string archivos, int cod_proceso, string tipo_archivo)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("GenerarRegistroC31-4");
				CNXSIGRH3.AddInParameter(icom, "TIPO_PLANILLA", DbType.String, tipo_planilla);
				CNXSIGRH3.AddInParameter(icom, "ARCHIVOS", DbType.String, archivos);
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.String, cod_proceso);
				CNXSIGRH3.AddInParameter(icom, "TIPO_ARCHIVO", DbType.String, tipo_archivo);

				return CNXSIGRH3.ExecuteDataSet(icom);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override int ActualizarMesProceso(string cod_proceso)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_proceso");
				CNXSIGRH3.AddInParameter(icom, "p_pc_id", DbType.Int32, cod_proceso);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U3");

				return CNXSIGRH3.ExecuteNonQuery(icom);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool FinalizarProcesoPlanilla(string cod_proceso, string secuencial)
        { try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_LIQUIDOS");
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "SECUENCIAL", DbType.Int32, Convert.ToInt32(secuencial));

				//CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U3");

				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet VerificarPlanillasAdicionales(string cod_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_PROCESO");
				CNXSIGRH3.AddInParameter(icom, "p_pc_id", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");

				return CNXSIGRH3.ExecuteDataSet(icom);	
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet VerificarPlanillasRetroactivo()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_retroactivo");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet PlanillasMigradas_Retroactivo()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_retroactivo");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override bool MigrarPlanilla_Retroactivo(string cod_proceso, string nro, string id_usuario)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_retroactivo");
				CNXSIGRH3.AddInParameter(icom, "p_ret_pc_id", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "p_ret_nro", DbType.Int32, Convert.ToInt32(nro));
				CNXSIGRH3.AddInParameter(icom, "p_ret_aux1", DbType.Int32, Convert.ToInt32(id_usuario));
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				CNXSIGRH3.ExecuteNonQuery(icom);
                return true;

            }
            catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool FinalizarMigracion_Retroactivo()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_retroactivo");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool InsertarIncremento_Retroactivo(double incremento)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_retroactivo");
				CNXSIGRH3.AddInParameter(icom, "p_ret_porcentaje", DbType.Double, incremento);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U2");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override string ObtenerConsultores_NumeroPlanilla(string cod_proceso)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_mp_cargo");
				CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "P12");
				return CNXSIGRH3.ExecuteDataSet(icom).Tables[0].Rows[0][0].ToString();

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet Insertar_MostrarCasos_Consultores(string cod_proceso, string secuencial)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_mp_cargo");
				CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, Convert.ToInt32(secuencial));

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "P13");
				return CNXSIGRH3.ExecuteDataSet(icom);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool ProcesarConsultores_Paso1(string cod_proceso, string secuencial, string list_as_id)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_CONSULTORES");
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "SECUENCIAL", DbType.Int32, Convert.ToInt32(secuencial));
				CNXSIGRH3.AddInParameter(icom, "LIST_CA_ID", DbType.String, list_as_id);
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override bool ProcesarConsultores_Paso2(string cod_proceso, string secuencial)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_COTIZABLES_CONSULTORES");
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "SECUENCIAL", DbType.Int32, Convert.ToInt32(secuencial));
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override bool ProcesarConsultores_Paso3(string cod_proceso, string secuencial)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_DESCUENTOS_CONSULTORES");
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "SECUENCIAL", DbType.Int32, Convert.ToInt32(secuencial));
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override bool ProcesarConsultores_Paso4(string cod_proceso, string secuencial)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("SP_PLA_SUELDO_LIQUIDOS_CONSULTORES");
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "SECUENCIAL", DbType.Int32, Convert.ToInt32(secuencial));
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet VerificarPlanilla_Consultores(string cod_proceso, string secuencial)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_mp_cargo");
				CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, Convert.ToInt32(secuencial));
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "P14");

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet NumeroPlanilla_Combo(string cod_proceso)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_mp_cargo");
				CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "P15");

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet NumeroPlanilla_ComboReportesAdicionales(string cod_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_proceso");
				CNXSIGRH3.AddInParameter(icom, "p_pc_id", DbType.Int32, Convert.ToInt32(cod_proceso));
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C15");

				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region _ACREEDORES
		public override bool Adicionar__acreedores(cls_acreedores _acreedores)
		{
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__ACREEDORES);
                CNXSIGRH3.AddInParameter(icom, "p_ac_per_id", DbType.Int32, _acreedores.ac_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ac_descripcion", DbType.String, _acreedores.ac_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_ac_tipo", DbType.Int32, _acreedores.ac_tipo);
                CNXSIGRH3.AddInParameter(icom, "p_ac_documento", DbType.String, _acreedores.ac_documento);
                CNXSIGRH3.AddInParameter(icom, "p_ac_usuario_creacion", DbType.String, _acreedores.ac_usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
		}

		public override bool Eliminar__acreedores(cls_acreedores _acreedores)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__ACREEDORES);
				CNXSIGRH3.AddInParameter(icom, "p_ac_id", DbType.Int32, _acreedores.ac_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Actualizar__acreedores(cls_acreedores _acreedores)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__ACREEDORES);
				CNXSIGRH3.AddInParameter(icom, "p_ac_id", DbType.Int32, _acreedores.ac_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerRegistro__acreedores(cls_acreedores _acreedores)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__ACREEDORES);
				CNXSIGRH3.AddInParameter(icom, "p_ac_id", DbType.Int32, _acreedores.ac_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaGrilla__acreedores(
            string ac_id, 
            string ac_per_id,
			string ac_descripcion, 
			string ac_tipo, 
			string ac_documento, 
			string ac_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__ACREEDORES);

				if (ac_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ac_id", DbType.Int32, Convert.ToInt32(ac_id)); }
				if (ac_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ac_per_id", DbType.Int32, Convert.ToInt32(ac_per_id)); }
				if (ac_descripcion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ac_descripcion", DbType.String, Convert.ToString(ac_descripcion)); }
				if (ac_tipo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ac_tipo", DbType.Int32, Convert.ToInt32(ac_tipo)); }
				if (ac_documento.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ac_documento", DbType.String, Convert.ToString(ac_documento)); }
				if (ac_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ac_estado", DbType.String, Convert.ToString(ac_estado)); } 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaCombo__acreedores()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__ACREEDORES);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }
		#endregion 

		#region _PLA_TRANSACCIONES_CUOTAS
		public override bool Adicionar__pla_transacciones_cuotas(cls_pla_transacciones_cuotas _pla_transacciones_cuotas)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES_CUOTAS);
				CNXSIGRH3.AddInParameter(icom, "p_tc_tr_id", DbType.Int32, _pla_transacciones_cuotas.tc_tr_id);
				CNXSIGRH3.AddInParameter(icom, "p_tc_cant_cuotas", DbType.Int32, _pla_transacciones_cuotas.tc_cant_cuotas);
				CNXSIGRH3.AddInParameter(icom, "p_tc_monto", DbType.String, _pla_transacciones_cuotas.tc_monto);

				//if (_pla_transacciones_cuotas.tr_fecha_fin.ToString() == "")
				//	CNXSIGRH3.AddInParameter(icom, "p_tr_fecha_fin", DbType.DateTime, DBNull.Value);
				//else
				//	CNXSIGRH3.AddInParameter(icom, "p_tr_fecha_fin", DbType.DateTime, _pla_transacciones.tr_fecha_fin);


				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Eliminar__pla_transacciones_cuotas(cls_pla_transacciones_cuotas _pla_transacciones_cuotas)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES_CUOTAS);
				CNXSIGRH3.AddInParameter(icom, "p_tc_id", DbType.Int32, _pla_transacciones_cuotas.tc_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Actualizar__pla_transacciones_cuotas(cls_pla_transacciones_cuotas _pla_transacciones_cuotas)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES_CUOTAS);
				CNXSIGRH3.AddInParameter(icom, "p_tc_id", DbType.Int32, _pla_transacciones_cuotas.tc_id);
				CNXSIGRH3.AddInParameter(icom, "p_tc_tr_id", DbType.Int32, _pla_transacciones_cuotas.tc_tr_id);
				CNXSIGRH3.AddInParameter(icom, "p_tc_cant_cuotas", DbType.Int32, _pla_transacciones_cuotas.tc_cant_cuotas);
				CNXSIGRH3.AddInParameter(icom, "p_tc_monto", DbType.Double, _pla_transacciones_cuotas.tc_monto);
				CNXSIGRH3.AddInParameter(icom, "p_tc_estado", DbType.String, _pla_transacciones_cuotas.tc_estado);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerRegistro__pla_transacciones_cuotas(cls_pla_transacciones_cuotas _pla_transacciones_cuotas)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES_CUOTAS);
				CNXSIGRH3.AddInParameter(icom, "p_tc_id", DbType.Int32, _pla_transacciones_cuotas.tc_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaGrilla__pla_transacciones_cuotas(
            string tc_id, 
			string tc_tr_id, 
			string tc_cant_cuotas, 
			string tc_monto, 
			string tc_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES_CUOTAS);

				if (tc_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tc_id", DbType.Int32, Convert.ToInt32(tc_id)); }
				if (tc_tr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tc_tr_id", DbType.Int32, Convert.ToInt32(tc_tr_id)); }
				if (tc_cant_cuotas.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tc_cant_cuotas", DbType.Int32, Convert.ToInt32(tc_cant_cuotas)); }
				if (tc_monto.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tc_monto", DbType.Double, Convert.ToDouble(tc_monto)); }
				if (tc_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tc_estado", DbType.String, Convert.ToString(tc_estado)); } 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaCombo__pla_transacciones_cuotas()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES_CUOTAS);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }
		#endregion 

		#region _PLA_TRANSACCIONES
		public override int Adicionar__pla_transacciones(cls_pla_transacciones _pla_transacciones)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES);
				CNXSIGRH3.AddInParameter(icom, "p_tr_pc_id", DbType.Int32, _pla_transacciones.tr_pc_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, _pla_transacciones.tr_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_fa_id", DbType.Int32, _pla_transacciones.tr_fa_id);

                ////if (_pla_transacciones.tr_fecha_fin.ToString()=="")
                CNXSIGRH3.AddInParameter(icom, "p_tr_fecha_fin", DbType.DateTime, DBNull.Value);
                ////else
                //CNXSIGRH3.AddInParameter(icom, "p_tr_fecha_fin", DbType.DateTime, _pla_transacciones.tr_fecha_fin);

                CNXSIGRH3.AddInParameter(icom, "p_tr_monto", DbType.String, _pla_transacciones.tr_monto);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                int id = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom).ToString());
				return id;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Eliminar__pla_transacciones(cls_pla_transacciones _pla_transacciones)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES);
				CNXSIGRH3.AddInParameter(icom, "p_tr_id", DbType.Int32, _pla_transacciones.tr_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Actualizar__pla_transacciones(cls_pla_transacciones _pla_transacciones)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES);
				CNXSIGRH3.AddInParameter(icom, "p_tr_id", DbType.Int32, _pla_transacciones.tr_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_pc_id", DbType.Int32, _pla_transacciones.tr_pc_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, _pla_transacciones.tr_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_fa_id", DbType.Int32, _pla_transacciones.tr_fa_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_fecha_inicio", DbType.DateTime, _pla_transacciones.tr_fecha_inicio);
				CNXSIGRH3.AddInParameter(icom, "p_tr_fecha_fin", DbType.DateTime, _pla_transacciones.tr_fecha_fin);
				CNXSIGRH3.AddInParameter(icom, "p_tr_monto", DbType.Double, _pla_transacciones.tr_monto);
				CNXSIGRH3.AddInParameter(icom, "p_tr_estado", DbType.String, _pla_transacciones.tr_estado);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerRegistro__pla_transacciones(cls_pla_transacciones _pla_transacciones)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES);
				CNXSIGRH3.AddInParameter(icom, "p_tr_id", DbType.Int32, _pla_transacciones.tr_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaGrilla__pla_transacciones(
            string tr_id, 
            string tr_pc_id, 
			string tr_per_id, 
			string tr_fa_id, 
			string tr_fecha_inicio, 
			string tr_fecha_fin, 
			string tr_monto, 
			string tr_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES);

				if (tr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_id", DbType.Int32, Convert.ToInt32(tr_id)); }
				if (tr_pc_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_pc_id", DbType.Int32, Convert.ToInt32(tr_pc_id)); }
				if (tr_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, Convert.ToInt32(tr_per_id)); }
				if (tr_fa_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_fa_id", DbType.Int32, Convert.ToInt32(tr_fa_id)); }
				if (tr_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_fecha_inicio", DbType.DateTime, Convert.ToDateTime(tr_fecha_inicio)); }
				if (tr_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_fecha_fin", DbType.DateTime, Convert.ToDateTime(tr_fecha_fin)); }
				if (tr_monto.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_monto", DbType.Double, Convert.ToDouble(tr_monto)); }
				if (tr_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_estado", DbType.String, Convert.ToString(tr_estado)); } 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaCombo__pla_transacciones()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

        // (KCPB)
        public override DataSet ObtenerTablaGrillaRR__pla_transacciones(
            string tr_id, 
            string tr_pc_id, 
            string tr_per_id, 
            string tr_fa_id, 
            string tr_fecha_inicio, 
            string tr_fecha_fin, 
            string tr_monto, 
            string tr_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES);

                if (tr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_id", DbType.Int32, Convert.ToInt32(tr_id)); }
                if (tr_pc_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_pc_id", DbType.Int32, Convert.ToInt32(tr_pc_id)); }
                if (tr_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, Convert.ToInt32(tr_per_id)); }
                if (tr_fa_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_fa_id", DbType.Int32, Convert.ToInt32(tr_fa_id)); }
                if (tr_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_fecha_inicio", DbType.DateTime, Convert.ToDateTime(tr_fecha_inicio)); }
                if (tr_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_fecha_fin", DbType.DateTime, Convert.ToDateTime(tr_fecha_fin)); }
                if (tr_monto.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_monto", DbType.Double, Convert.ToDouble(tr_monto)); }
                if (tr_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_estado", DbType.String, Convert.ToString(tr_estado)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTransaccionesRetenciones(string as_id,
			string as_per_id,
			string as_ca_id,
			string as_fecha_inicio,
			string as_fecha_fin,
			string as_estado,
			string as_tipo_reg,
			string as_tipo_mov,
			string as_tipo_baja,
			string as_validacion,
			string as_fecha_validacion,
			string as_memo,
			string as_memo_baja,
			string as_pr_id)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES);

				if (as_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, Convert.ToInt32(as_pr_id)); }
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}
        public override DataSet ListarTotalCuotas()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
		}

		//Elimina el descuento que se haya cumplido
		public override bool QuitarDescuento(int tr_id)
        {
            try
            {
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_TRANSACCIONES);
				CNXSIGRH3.AddInParameter(icom, "p_tr_id", DbType.Int32, tr_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B1");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		#endregion

		#region _PLA_FACTOR
		public override bool Adicionar__pla_factor(cls_pla_factor _pla_factor)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
				CNXSIGRH3.AddInParameter(icom, "p_fa_id", DbType.Int32, _pla_factor.fa_id);
				CNXSIGRH3.AddInParameter(icom, "p_fa_descripcion", DbType.String, _pla_factor.fa_descripcion);
				CNXSIGRH3.AddInParameter(icom, "p_fa_signo", DbType.String, _pla_factor.fa_signo);
				CNXSIGRH3.AddInParameter(icom, "p_fa_ac_id", DbType.Int32, _pla_factor.fa_ac_id);
				CNXSIGRH3.AddInParameter(icom, "p_fa_tipo_calculo", DbType.String, _pla_factor.fa_tipo_calculo);
				CNXSIGRH3.AddInParameter(icom, "p_fa_valor", DbType.Double, _pla_factor.fa_valor);
				CNXSIGRH3.AddInParameter(icom, "p_fa_estado", DbType.String, _pla_factor.fa_estado);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Eliminar__pla_factor(cls_pla_factor _pla_factor)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
				CNXSIGRH3.AddInParameter(icom, "p_fa_id", DbType.Int32, _pla_factor.fa_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Actualizar__pla_factor(cls_pla_factor _pla_factor)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
				CNXSIGRH3.AddInParameter(icom, "p_fa_id", DbType.Int32, _pla_factor.fa_id);
				CNXSIGRH3.AddInParameter(icom, "p_fa_descripcion", DbType.String, _pla_factor.fa_descripcion);
				CNXSIGRH3.AddInParameter(icom, "p_fa_signo", DbType.String, _pla_factor.fa_signo);
				CNXSIGRH3.AddInParameter(icom, "p_fa_ac_id", DbType.Int32, _pla_factor.fa_ac_id);
				CNXSIGRH3.AddInParameter(icom, "p_fa_tipo_calculo", DbType.String, _pla_factor.fa_tipo_calculo);
				CNXSIGRH3.AddInParameter(icom, "p_fa_valor", DbType.Double, _pla_factor.fa_valor);
				CNXSIGRH3.AddInParameter(icom, "p_fa_estado", DbType.String, _pla_factor.fa_estado);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool ObtenerId__pla_factor(cls_pla_factor _pla_factor)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				_pla_factor.fa_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fa_id"]);		
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerRegistro__pla_factor(cls_pla_factor _pla_factor)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
				CNXSIGRH3.AddInParameter(icom, "p_fa_id", DbType.Int32, _pla_factor.fa_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaGrilla__pla_factor(
            string fa_id, 
			string fa_descripcion, 
			string fa_signo, 
			string fa_ac_id, 
			string fa_tipo_calculo, 
			string fa_valor, 
			string fa_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

				if (fa_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fa_id", DbType.Int32, Convert.ToInt32(fa_id)); }
				if (fa_descripcion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fa_descripcion", DbType.String, Convert.ToString(fa_descripcion)); }
				if (fa_signo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fa_signo", DbType.String, Convert.ToString(fa_signo)); }
				if (fa_ac_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fa_ac_id", DbType.Int32, Convert.ToInt32(fa_ac_id)); }
				if (fa_tipo_calculo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fa_tipo_calculo", DbType.String, Convert.ToString(fa_tipo_calculo)); }
				if (fa_valor.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fa_valor", DbType.Double, Convert.ToDouble(fa_valor)); }
				if (fa_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fa_estado", DbType.String, Convert.ToString(fa_estado)); } 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaCombo__pla_factor()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

        // (KCPB)
        public override DataSet ObtenerTablaComboX__pla_factor(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_fa_descripcion", DbType.String, _pla_factor.fa_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (JQC)
        public override DataSet ObtenerTipoTrans(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_fa_id", DbType.String, _pla_factor.fa_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerNroHorasExtras(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _pla_factor.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.String, _pla_factor.es_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerCategoriaProg(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _pla_factor.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _pla_factor.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerPresupuesto(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _pla_factor.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.String, _pla_factor.cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerPagadoDevengado(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.String, _pla_factor.cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerProceso(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarTransaccion(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_tr_pc_id", DbType.Int32, _pla_factor.tr_pc_id);
                CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, _pla_factor.tr_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_tr_ac_id", DbType.Int32, _pla_factor.tr_ac_id);
                CNXSIGRH3.AddInParameter(icom, "p_tr_fa_id", DbType.Int32, _pla_factor.tr_fa_id);
                CNXSIGRH3.AddInParameter(icom, "p_tr_monto", DbType.String, _pla_factor.tr_monto);
                CNXSIGRH3.AddInParameter(icom, "p_tr_estado", DbType.String, _pla_factor.tr_estado);
                CNXSIGRH3.AddInParameter(icom, "p_tr_usuario_creacion", DbType.Int32, _pla_factor.tr_usuario_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		public override bool AdicionarTransaccionPorCuotas(cls_pla_factor _pla_factor)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

				CNXSIGRH3.AddInParameter(icom, "p_tr_pc_id", DbType.Int32, _pla_factor.tr_pc_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, _pla_factor.tr_per_id);
				//CNXSIGRH3.AddInParameter(icom, "p_tr_ac_id", DbType.Int32, _pla_factor.tr_ac_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_fa_id", DbType.Int32, _pla_factor.tr_fa_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_monto", DbType.String, _pla_factor.tr_monto);
				//CNXSIGRH3.AddInParameter(icom, "p_tr_estado", DbType.String, _pla_factor.tr_estado);
				CNXSIGRH3.AddInParameter(icom, "p_tr_usuario_creacion", DbType.Int32, _pla_factor.tr_usuario_creacion);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A1");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet ObtenerTransaccion(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _pla_factor.tr_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaHE(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, _pla_factor.tr_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_tr_fecha_creacion_nro", DbType.Int32, _pla_factor.tr_fecha_creacion_nro);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarTransaccion(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_tr_id", DbType.Int32, (_pla_factor.tr_id));
                CNXSIGRH3.AddInParameter(icom, "p_tr_usuario_creacion", DbType.Int32, (_pla_factor.tr_usuario_creacion));

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarTransaccionIVA(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_tr_id", DbType.Int32, (_pla_factor.tr_id));
                CNXSIGRH3.AddInParameter(icom, "p_tr_usuario_creacion", DbType.Int32, (_pla_factor.tr_usuario_creacion));

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerAporteIva(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.String, _pla_factor.tr_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C12");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaAporteIVA(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, _pla_factor.tr_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C13");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaMontoPresentar(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, _pla_factor.tr_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTipoSindicato(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C15");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ListarGrillaAporteSindicato(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, _pla_factor.tr_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C16");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTipoEstadoAporte(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C17");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrillaAporteSindicato(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, _pla_factor.tr_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_tr_fecha_creacion_nro", DbType.Int32, _pla_factor.tr_fecha_creacion_nro);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C18");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaAsignacionHE(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.Int32, _pla_factor.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C19");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTipoEscalafon(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C20");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarAsigHorasExtras(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_lhx_id ", DbType.Int32, (_pla_factor.lhx_id));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarLimiteHorasExtras(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, _pla_factor.es_id);
                CNXSIGRH3.AddInParameter(icom, "p_lhx_cat_id", DbType.Int32, _pla_factor.lhx_cat_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaLimiteHE(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, _pla_factor.es_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C21");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet listaFiltradoTipoDocHE(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C22");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaFactores(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C23");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFactorX(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_fa_id", DbType.String, _pla_factor.fa_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C24");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ActualizarFactor(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
                CNXSIGRH3.AddInParameter(icom, "p_fa_id", DbType.Int32, _pla_factor.fa_id);
                CNXSIGRH3.AddInParameter(icom, "p_fa_descripcion", DbType.String, _pla_factor.fa_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_fa_signo", DbType.String, _pla_factor.fa_signo);
                CNXSIGRH3.AddInParameter(icom, "p_fa_tipo_calculo", DbType.String, _pla_factor.fa_tipo_calculo);
                CNXSIGRH3.AddInParameter(icom, "p_fa_valor", DbType.Double, _pla_factor.fa_valor);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerGrillaHorasExtras(cls_pla_factor _pla_factor)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

                CNXSIGRH3.AddInParameter(icom, "p_tr_pc_id", DbType.Int32, _pla_factor.tr_pc_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C25");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerComboCovenios()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C26");
				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ListarGrillaConvenios(cls_pla_factor _pla_factor)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

				CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, _pla_factor.tr_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C27");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool AdicionarTransaccionConvenios(cls_pla_factor _pla_factor)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

				CNXSIGRH3.AddInParameter(icom, "p_tr_pc_id", DbType.Int32, _pla_factor.tr_pc_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, _pla_factor.tr_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_ac_id", DbType.Int32, _pla_factor.tr_ac_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_fa_id", DbType.Int32, _pla_factor.tr_fa_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_monto", DbType.String, _pla_factor.tr_monto);
				CNXSIGRH3.AddInParameter(icom, "p_tr_estado", DbType.String, _pla_factor.tr_estado);
				CNXSIGRH3.AddInParameter(icom, "p_tr_usuario_creacion", DbType.Int32, _pla_factor.tr_usuario_creacion);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A3");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override int AdicionarTransaccionMontoUnico(cls_pla_factor _pla_factor)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

				CNXSIGRH3.AddInParameter(icom, "p_tr_pc_id", DbType.Int32, _pla_factor.tr_pc_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_per_id", DbType.Int32, _pla_factor.tr_per_id);
				//CNXSIGRH3.AddInParameter(icom, "p_tr_ac_id", DbType.Int32, _pla_factor.tr_ac_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_fa_id", DbType.Int32, _pla_factor.tr_fa_id);
				CNXSIGRH3.AddInParameter(icom, "p_tr_monto", DbType.String, _pla_factor.tr_monto);
				//CNXSIGRH3.AddInParameter(icom, "p_tr_estado", DbType.String, _pla_factor.tr_estado);
				CNXSIGRH3.AddInParameter(icom, "p_tr_usuario_creacion", DbType.Int32, _pla_factor.tr_usuario_creacion);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A3");
				int id = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom).ToString());
				return id;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ListarGrillaDescuentos(cls_pla_factor _pla_factor)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C28");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerComboOtrosDescuentos()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C29");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ListaGrillaOtrosDescuentos(cls_pla_factor _pla_factor)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C30");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ListarDescuentosMontosCuotas()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C31");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool ActivarDesactivarFNTUB(string estado, double valor, int fa_id)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_FACTOR);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B4");
				CNXSIGRH3.AddInParameter(icom, "p_fa_estado", DbType.String, estado);
				CNXSIGRH3.AddInParameter(icom, "p_fa_valor", DbType.Double, valor);
				CNXSIGRH3.AddInParameter(icom, "p_fa_id", DbType.Int32, fa_id);

				CNXSIGRH3.ExecuteNonQuery(icom);

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region PLA DOCENTE HORAS
		public override bool Estadoimpreso(cls_pla_docentes_adicional adicional)
        {
            try
            {
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docentes_adicional");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
				CNXSIGRH3.AddInParameter(icom, "p_td_periodo", DbType.String, adicional.td_periodo);
				CNXSIGRH3.AddInParameter(icom, "p_td_tipo_docente", DbType.String, adicional.td_tipo_docente);
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public override DataSet ListarGrillaDocentesMes()
		{
			//try
			//{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docente_horas");

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
				return CNXSIGRH3.ExecuteDataSet(icom);
			//}
			//catch (Exception ex)
			//{
			//	throw ex;
			//}
		}
        public override bool AdicionarHorasDocentes(cls_pla_docente_horas _pla_docentes)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docente_horas");
				CNXSIGRH3.AddInParameter(icom, "p_pdh_per_id", DbType.Int32, _pla_docentes.pdh_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_pdh_horas", DbType.Int32, _pla_docentes.pdh_horas);
				CNXSIGRH3.AddInParameter(icom, "p_pdh_as_id", DbType.Int32, _pla_docentes.pdh_as_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom); 
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override bool ModificarHorasDocentes(cls_pla_docente_horas _pla_docentes)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docente_horas");
				CNXSIGRH3.AddInParameter(icom, "p_pdh_id", DbType.Int32, _pla_docentes.pdh_id);
				CNXSIGRH3.AddInParameter(icom, "p_pdh_horas", DbType.Int32, _pla_docentes.pdh_horas);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet ObtenerUnidadesOrganizacionales()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docente_horas");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");				
				return CNXSIGRH3.ExecuteDataSet(icom); ;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public override DataSet ObtenerUnidadesOrganizacionales_filtrado(int per_id)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docente_horas");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "TV");
				CNXSIGRH3.AddInParameter(icom, "p_pdh_per_id", DbType.Int32, per_id);
				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ListarGrillaDocentesMesPorUnidad(int eo_id)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docente_horas");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
				CNXSIGRH3.AddInParameter(icom, "p_pdh_per_id", DbType.Int32, eo_id);

				return CNXSIGRH3.ExecuteDataSet(icom); ;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerAsignacionAdicionalDocentes()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docentes_adicional");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool AdicionarAsignacionAdicionalDocentes(cls_pla_docentes_adicional _Pla_Docentes_Adicional)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docentes_adicional");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.AddInParameter(icom, "p_td_per_id", DbType.Int32, _Pla_Docentes_Adicional.td_per_id);
				CNXSIGRH3.AddInParameter(icom, "p_td_tipo_docente", DbType.String, _Pla_Docentes_Adicional.td_tipo_docente);
				CNXSIGRH3.AddInParameter(icom, "p_td_eo_id", DbType.Int32, _Pla_Docentes_Adicional.td_eo_id);
				CNXSIGRH3.AddInParameter(icom, "p_td_carrera", DbType.String, _Pla_Docentes_Adicional.td_carrera);
				CNXSIGRH3.AddInParameter(icom, "p_td_fecha_inicio", DbType.DateTime, _Pla_Docentes_Adicional.td_fecha_inicio);
				CNXSIGRH3.AddInParameter(icom, "p_td_fecha_fin", DbType.DateTime, _Pla_Docentes_Adicional.td_fecha_fin);
				CNXSIGRH3.AddInParameter(icom, "p_td_horas", DbType.Double, _Pla_Docentes_Adicional.td_horas);
				CNXSIGRH3.AddInParameter(icom, "p_td_total_ganado", DbType.Double, _Pla_Docentes_Adicional.td_total_ganado);
				CNXSIGRH3.AddInParameter(icom, "p_td_iue", DbType.Double, _Pla_Docentes_Adicional.td_iue);
				CNXSIGRH3.AddInParameter(icom, "p_td_desc_asistencia", DbType.Double, _Pla_Docentes_Adicional.td_desc_asistencia);
				CNXSIGRH3.AddInParameter(icom, "p_td_desc_otros", DbType.Double, _Pla_Docentes_Adicional.td_desc_otros);
				CNXSIGRH3.AddInParameter(icom, "p_td_periodo", DbType.String, _Pla_Docentes_Adicional.td_periodo);
				CNXSIGRH3.AddInParameter(icom, "p_td_fecha_proceso", DbType.DateTime, null);
				CNXSIGRH3.AddInParameter(icom, "p_td_glosa", DbType.String, _Pla_Docentes_Adicional.td_glosa);
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ListarAsignacionesAdicionalesDocentes(cls_pla_docentes_adicional _Pla_Docentes_Adicional)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docentes_adicional");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
				CNXSIGRH3.AddInParameter(icom, "p_td_per_id", DbType.Int32, _Pla_Docentes_Adicional.td_per_id);
				//CNXSIGRH3.AddInParameter(icom, "p_td_carrera", DbType.String, _Pla_Docentes_Adicional.td_carrera);
				//CNXSIGRH3.AddInParameter(icom, "p_td_fecha_inicio", DbType.DateTime, _Pla_Docentes_Adicional.td_fecha_inicio);
				//CNXSIGRH3.AddInParameter(icom, "p_td_fecha_fin", DbType.DateTime, _Pla_Docentes_Adicional.td_fecha_fin);
				return CNXSIGRH3.ExecuteDataSet(icom);				
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool EliminarAsignacionAdicional(int td_id)
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docentes_adicional");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.AddInParameter(icom, "p_td_id", DbType.Int32, td_id);
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override string ObtenerIdEstructuraBaseParaAsignacionesadicionalesDocentes()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_estructura_docentes_adicional");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				return CNXSIGRH3.ExecuteDataSet(icom).Tables[0].Rows[0][0].ToString();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerPeriodoAsignacionesAdicionales()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docentes_adicional");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerTodasAsignacionesAdicionalesDocentes()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docentes_adicional");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool ProcesarAsignacionesAdicionales()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docentes_adicional");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet UnidadesOrganizacionalesAltasBajas()
        {
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("sp_pla_docente_horas");
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
				return CNXSIGRH3.ExecuteDataSet(icom);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        #endregion

        #region REFIGERIO
		public override DataSet ObtenerNroPlanilla(int pc_id)
        {
            try
            {
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand("Sp_Refrigerio");
				CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C");
				CNXSIGRH3.AddInParameter(icom, "pc_id", DbType.Int32, pc_id);
				return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ASISTENCIA
        public override bool GenerarAsistenciaIndiv(cls_asistencia asisten)
        {
            try
            {
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(GenerarAsistencia_Indiv);
				CNXSIGRH3.AddInParameter(icom, "@cod_persona", DbType.Int32, asisten.x);
				CNXSIGRH3.AddInParameter(icom, "@FECHA_INICIO", DbType.DateTime, asisten.date);
				CNXSIGRH3.AddInParameter(icom, "@FECHA_FIN", DbType.DateTime, asisten.tim);
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public override DataSet LlenarCombo()
        {
            try
            {
				DbCommand icom = null;
				icom = CNXSIGRH3.GetSqlStringCommand("Select pr_id, CONCAT([pr_gestion] , '-' , [pr_secuencial]) as GESTION from tbl_periodo order by pr_gestion desc, pr_secuencial");
				return CNXSIGRH3.ExecuteDataSet(icom);
			}
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public override DataSet CargarGestiones(cls_asistencia asisten)
        {
            try
            {
				DbCommand icom = null;
				icom = CNXSIGRH3.GetSqlStringCommand("SELECT pc_id, pc_pr_id, pc_titulo FROM[sigrh3].[dbo].[tbl_pla_proceso] where pc_pr_id = " + asisten.gestion.ToString() + " order by pc_id);");
				return CNXSIGRH3.ExecuteDataSet(icom);
			}
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region RETROACTIVO
		public override bool ProcesoRetroactivo1(int pc_id, int secuencial)
        {
            try
            {
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP_RETROACTIVO);
				CNXSIGRH3.AddInParameter(icom, "COD_PROCESO", DbType.Int32, pc_id);
				CNXSIGRH3.AddInParameter(icom, "SECUENCIAL", DbType.Int32, secuencial);
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}
