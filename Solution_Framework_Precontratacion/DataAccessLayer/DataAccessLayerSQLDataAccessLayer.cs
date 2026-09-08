using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

using Solution_Framework_Precontratacion.BussinessLogicLayer;
using Solution_Framework_Precontratacion.DataAccessLayer;

namespace Solution_Framework_Precontratacion.BussinessLogicLayer
{
	public class DataAccessLayerSQLDataAccessLayer : DataAccessLayerDataAccessLayer
	{
		#region CONSTANTES
		private string SP__PERMISO_CATEGORIA_PROGRAMATICA = "sp_permiso_categoria_programatica";
		private string SP__PC_PRECONTRATADO = "sp_pc_precontratado";
		private string SP__PC_FRECUENCIA = "sp_pc_frecuencia";
		#endregion

		//INTERFACES
		#region _PERMISO_CATEGORIA_PROGRAMATICA
		public override bool Adicionar__permiso_categoria_programatica(cls_permiso_categoria_programatica _permiso_categoria_programatica)
		{
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERMISO_CATEGORIA_PROGRAMATICA);
                CNXSIGRH3.AddInParameter(icom, "p_pcp_id", DbType.Int32, _permiso_categoria_programatica.pcp_id);
                CNXSIGRH3.AddInParameter(icom, "p_pcp_rol", DbType.Int32, _permiso_categoria_programatica.pcp_rol);
                CNXSIGRH3.AddInParameter(icom, "p_pcp_ue", DbType.Int32, _permiso_categoria_programatica.pcp_ue);
                CNXSIGRH3.AddInParameter(icom, "p_pcp_cp_id", DbType.Int32, _permiso_categoria_programatica.pcp_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_pcp_estado", DbType.String, _permiso_categoria_programatica.pcp_estado);
                CNXSIGRH3.AddInParameter(icom, "p_pcp_us_id", DbType.Int32, _permiso_categoria_programatica.pcp_us_id);
                CNXSIGRH3.AddInParameter(icom, "p_pcp_pr_id", DbType.Int32, _permiso_categoria_programatica.pcp_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
		}

		public override bool Eliminar__permiso_categoria_programatica(cls_permiso_categoria_programatica _permiso_categoria_programatica)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PERMISO_CATEGORIA_PROGRAMATICA);
				CNXSIGRH3.AddInParameter(icom, "p_pcp_id", DbType.Int32, _permiso_categoria_programatica.pcp_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Actualizar__permiso_categoria_programatica(cls_permiso_categoria_programatica _permiso_categoria_programatica)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PERMISO_CATEGORIA_PROGRAMATICA);
				CNXSIGRH3.AddInParameter(icom, "p_pcp_id", DbType.Int32, _permiso_categoria_programatica.pcp_id);
				CNXSIGRH3.AddInParameter(icom, "p_pcp_rol", DbType.Int32, _permiso_categoria_programatica.pcp_rol);
				CNXSIGRH3.AddInParameter(icom, "p_pcp_ue", DbType.Int32, _permiso_categoria_programatica.pcp_ue);
				CNXSIGRH3.AddInParameter(icom, "p_pcp_cp_id", DbType.Int32, _permiso_categoria_programatica.pcp_cp_id);
				CNXSIGRH3.AddInParameter(icom, "p_pcp_estado", DbType.String, _permiso_categoria_programatica.pcp_estado);
				CNXSIGRH3.AddInParameter(icom, "p_pcp_us_id", DbType.Int32, _permiso_categoria_programatica.pcp_us_id);
				CNXSIGRH3.AddInParameter(icom, "p_pcp_pr_id", DbType.Int32, _permiso_categoria_programatica.pcp_pr_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerRegistro__permiso_categoria_programatica(cls_permiso_categoria_programatica _permiso_categoria_programatica)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PERMISO_CATEGORIA_PROGRAMATICA);
				CNXSIGRH3.AddInParameter(icom, "p_pcp_id", DbType.Int32, _permiso_categoria_programatica.pcp_id);
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaGrilla__permiso_categoria_programatica(
            string pcp_id, 
			string pcp_rol, 
			string pcp_ue, 
			string pcp_cp_id, 
			string pcp_estado, 
			string pcp_us_id, 
			string pcp_pr_id)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PERMISO_CATEGORIA_PROGRAMATICA);

				if (pcp_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pcp_id", DbType.Int32, Convert.ToInt32(pcp_id)); }
				if (pcp_rol.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pcp_rol", DbType.Int32, Convert.ToInt32(pcp_rol)); }
				if (pcp_ue.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pcp_ue", DbType.Int32, Convert.ToInt32(pcp_ue)); }
				if (pcp_cp_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pcp_cp_id", DbType.Int32, Convert.ToInt32(pcp_cp_id)); }
				if (pcp_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pcp_estado", DbType.String, Convert.ToString(pcp_estado)); }
				if (pcp_us_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pcp_us_id", DbType.Int32, Convert.ToInt32(pcp_us_id)); }
				if (pcp_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pcp_pr_id", DbType.Int32, Convert.ToInt32(pcp_pr_id)); } 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__permiso_categoria_programatica(cls_permiso_categoria_programatica _permiso_categoria_programatica)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERMISO_CATEGORIA_PROGRAMATICA);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                CNXSIGRH3.AddInParameter(icom, "p_pcp_us_id", DbType.Int32, _permiso_categoria_programatica.pcp_us_id);
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _PC_PRECONTRATADO
        public override bool Adicionar__pc_precontratado(cls_pc_precontratado _pc_precontratado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
				CNXSIGRH3.AddInParameter(icom, "p_pre_paterno", DbType.String, _pc_precontratado.pre_paterno);
				CNXSIGRH3.AddInParameter(icom, "p_pre_materno", DbType.String, _pc_precontratado.pre_materno);
				CNXSIGRH3.AddInParameter(icom, "p_pre_nombres", DbType.String, _pc_precontratado.pre_nombres);
				CNXSIGRH3.AddInParameter(icom, "p_pre_ap_casada", DbType.String, _pc_precontratado.pre_ap_casada);
				CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_inicio", DbType.String, _pc_precontratado.pre_fecha_inicio);
				CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_fin", DbType.String, _pc_precontratado.pre_fecha_fin);
				CNXSIGRH3.AddInParameter(icom, "p_pre_tiempo", DbType.Int32, _pc_precontratado.pre_tiempo);
				CNXSIGRH3.AddInParameter(icom, "p_pre_val_aceptado_RRHH", DbType.Boolean, _pc_precontratado.pre_val_aceptado_RRHH);
				CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
				CNXSIGRH3.AddInParameter(icom, "p_pre_fr_id", DbType.Int32, _pc_precontratado.pre_fr_id);
				CNXSIGRH3.AddInParameter(icom, "p_pre_pu_id", DbType.Int32, _pc_precontratado.pre_pu_id);
				CNXSIGRH3.AddInParameter(icom, "p_pre_presenta_djbr", DbType.Boolean, _pc_precontratado.pre_presenta_djbr);
				CNXSIGRH3.AddInParameter(icom, "p_pre_cod_carpeta", DbType.Int32, _pc_precontratado.pre_cod_carpeta);
				CNXSIGRH3.AddInParameter(icom, "p_pre_afp", DbType.String, _pc_precontratado.pre_afp);
				CNXSIGRH3.AddInParameter(icom, "p_pre_obj_puesto", DbType.String, _pc_precontratado.pre_obj_puesto);
				CNXSIGRH3.AddInParameter(icom, "p_pre_tareas", DbType.String, _pc_precontratado.pre_tareas);
				CNXSIGRH3.AddInParameter(icom, "p_pre_numero_item", DbType.Int32, _pc_precontratado.pre_numero_item);
				CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool AdicionarSeguimiento(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_seg_pk_id", DbType.Int32, _pc_precontratado.seg_pk_id);
                CNXSIGRH3.AddInParameter(icom, "p_seg_us_id_remitente", DbType.Int32, _pc_precontratado.seg_us_id_remitente);
                CNXSIGRH3.AddInParameter(icom, "p_seg_accion", DbType.String, _pc_precontratado.seg_accion);
                CNXSIGRH3.AddInParameter(icom, "p_seg_us_id_recepcion", DbType.Int32, _pc_precontratado.seg_us_id_recepcion);
                CNXSIGRH3.AddInParameter(icom, "p_seg_observaciones", DbType.String, _pc_precontratado.seg_observaciones);
                CNXSIGRH3.AddInParameter(icom, "p_seg_tabla", DbType.String, _pc_precontratado.seg_tabla);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Eliminar__pc_precontratado(cls_pc_precontratado _pc_precontratado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

				CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
				CNXSIGRH3.AddInParameter(icom, "p_pre_fr_id", DbType.Int32, _pc_precontratado.pre_fr_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B1");
                CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Actualizar__pc_precontratado(cls_pc_precontratado _pc_precontratado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

				CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
				CNXSIGRH3.AddInParameter(icom, "p_pre_paterno", DbType.String, _pc_precontratado.pre_paterno);
				CNXSIGRH3.AddInParameter(icom, "p_pre_materno", DbType.String, _pc_precontratado.pre_materno);
				CNXSIGRH3.AddInParameter(icom, "p_pre_nombres", DbType.String, _pc_precontratado.pre_nombres);
				CNXSIGRH3.AddInParameter(icom, "p_pre_ap_casada", DbType.String, _pc_precontratado.pre_ap_casada);
				CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_inicio", DbType.String, _pc_precontratado.pre_fecha_inicio);
				CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_fin", DbType.String, _pc_precontratado.pre_fecha_fin);
				CNXSIGRH3.AddInParameter(icom, "p_pre_tiempo", DbType.Int32, _pc_precontratado.pre_tiempo);
				CNXSIGRH3.AddInParameter(icom, "p_pre_val_aceptado_RRHH", DbType.Boolean, _pc_precontratado.pre_val_aceptado_RRHH);
				CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
				CNXSIGRH3.AddInParameter(icom, "p_pre_fr_id", DbType.Int32, _pc_precontratado.pre_fr_id);
				CNXSIGRH3.AddInParameter(icom, "p_pre_pu_id", DbType.Int32, _pc_precontratado.pre_pu_id);
				CNXSIGRH3.AddInParameter(icom, "p_pre_presenta_djbr", DbType.Boolean, _pc_precontratado.pre_presenta_djbr);
				CNXSIGRH3.AddInParameter(icom, "p_pre_cod_carpeta", DbType.Int32, _pc_precontratado.pre_cod_carpeta);
				CNXSIGRH3.AddInParameter(icom, "p_pre_afp", DbType.String, _pc_precontratado.pre_afp);
				CNXSIGRH3.AddInParameter(icom, "p_pre_obj_puesto", DbType.String, _pc_precontratado.pre_obj_puesto);
				CNXSIGRH3.AddInParameter(icom, "p_pre_tareas", DbType.String, _pc_precontratado.pre_tareas);
				CNXSIGRH3.AddInParameter(icom, "p_pre_numero_item", DbType.Int32, _pc_precontratado.pre_numero_item);
				CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override bool ActualizarFecha(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_inicio", DbType.String, _pc_precontratado.pre_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C55");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId__pc_precontratado(cls_pc_precontratado _pc_precontratado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_pc_precontratado.pre_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pre_id"]);
		
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerRegistro__pc_precontratado(cls_pc_precontratado _pc_precontratado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

				CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				if (ds.Tables[0].Rows[0]["pre_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_id"].ToString().Trim() != "") { _pc_precontratado.pre_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pre_id"]); }
				if (ds.Tables[0].Rows[0]["pre_paterno"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_paterno"].ToString().Trim() != "") { _pc_precontratado.pre_paterno = Convert.ToString(ds.Tables[0].Rows[0]["pre_paterno"]); }
				if (ds.Tables[0].Rows[0]["pre_materno"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_materno"].ToString().Trim() != "") { _pc_precontratado.pre_materno = Convert.ToString(ds.Tables[0].Rows[0]["pre_materno"]); }
				if (ds.Tables[0].Rows[0]["pre_nombres"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_nombres"].ToString().Trim() != "") { _pc_precontratado.pre_nombres = Convert.ToString(ds.Tables[0].Rows[0]["pre_nombres"]); }
				if (ds.Tables[0].Rows[0]["pre_ap_casada"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_ap_casada"].ToString().Trim() != "") { _pc_precontratado.pre_ap_casada = Convert.ToString(ds.Tables[0].Rows[0]["pre_ap_casada"]); }
				if (ds.Tables[0].Rows[0]["pre_fecha_inicio"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_fecha_inicio"].ToString().Trim() != "") { _pc_precontratado.pre_fecha_inicio = Convert.ToString(ds.Tables[0].Rows[0]["pre_fecha_inicio"]); }
				if (ds.Tables[0].Rows[0]["pre_fecha_fin"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_fecha_fin"].ToString().Trim() != "") { _pc_precontratado.pre_fecha_fin = Convert.ToString(ds.Tables[0].Rows[0]["pre_fecha_fin"]); }
				if (ds.Tables[0].Rows[0]["pre_tiempo"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_tiempo"].ToString().Trim() != "") { _pc_precontratado.pre_tiempo = Convert.ToInt32(ds.Tables[0].Rows[0]["pre_tiempo"]); }
				if (ds.Tables[0].Rows[0]["pre_val_aceptado_RRHH"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_val_aceptado_RRHH"].ToString().Trim() != "") { _pc_precontratado.pre_val_aceptado_RRHH = Convert.ToBoolean(ds.Tables[0].Rows[0]["pre_val_aceptado_RRHH"]); }
				if (ds.Tables[0].Rows[0]["pre_pl_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_pl_id"].ToString().Trim() != "") { _pc_precontratado.pre_pl_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pre_pl_id"]); }
				if (ds.Tables[0].Rows[0]["pre_fr_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_fr_id"].ToString().Trim() != "") { _pc_precontratado.pre_fr_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pre_fr_id"]); }
				if (ds.Tables[0].Rows[0]["pre_pu_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_pu_id"].ToString().Trim() != "") { _pc_precontratado.pre_pu_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pre_pu_id"]); }
				if (ds.Tables[0].Rows[0]["pre_cod_carpeta"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_cod_carpeta"].ToString().Trim() != "") { _pc_precontratado.pre_cod_carpeta = Convert.ToInt32(ds.Tables[0].Rows[0]["pre_cod_carpeta"]); }
				if (ds.Tables[0].Rows[0]["pre_afp"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_afp"].ToString().Trim() != "") { _pc_precontratado.pre_afp = Convert.ToString(ds.Tables[0].Rows[0]["pre_afp"]); }
				if (ds.Tables[0].Rows[0]["pre_obj_puesto"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_obj_puesto"].ToString().Trim() != "") { _pc_precontratado.pre_obj_puesto = Convert.ToString(ds.Tables[0].Rows[0]["pre_obj_puesto"]); }
				if (ds.Tables[0].Rows[0]["pre_tareas"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_tareas"].ToString().Trim() != "") { _pc_precontratado.pre_tareas = Convert.ToString(ds.Tables[0].Rows[0]["pre_tareas"]); }
				if (ds.Tables[0].Rows[0]["pre_numero_item"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_numero_item"].ToString().Trim() != "") { _pc_precontratado.pre_numero_item = Convert.ToInt32(ds.Tables[0].Rows[0]["pre_numero_item"]); }
				if (ds.Tables[0].Rows[0]["pre_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["pre_estado"].ToString().Trim() != "") { _pc_precontratado.pre_estado = Convert.ToString(ds.Tables[0].Rows[0]["pre_estado"]); }
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerRegistroTipoItem(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C56");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerTablaGrilla__pc_precontratado(string pre_id, 
						string pre_paterno, 
						string pre_materno, 
						string pre_nombres, 
						string pre_ap_casada, 
						string pre_fecha_inicio, 
						string pre_fecha_fin, 
						string pre_tiempo, 
						string pre_val_aceptado_RRHH, 
						string pre_pl_id, 
						string pre_fr_id, 
						string pre_pu_id, 
						string pre_as_id, 
						string pre_presenta_djbr, 
						string pre_cod_carpeta, 
						string pre_afp, 
						string pre_obj_puesto, 
						string pre_tareas, 
						string pre_numero_item, 
						string pre_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

				if (pre_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, Convert.ToInt32(pre_id)); }
				if (pre_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_paterno", DbType.String, Convert.ToString(pre_paterno)); }
				if (pre_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_materno", DbType.String, Convert.ToString(pre_materno)); }
				if (pre_nombres.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_nombres", DbType.String, Convert.ToString(pre_nombres)); }
				if (pre_ap_casada.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_ap_casada", DbType.String, Convert.ToString(pre_ap_casada)); }
				if (pre_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_inicio", DbType.String, Convert.ToString(pre_fecha_inicio)); }
				if (pre_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_fin", DbType.String, Convert.ToString(pre_fecha_fin)); }
				if (pre_tiempo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_tiempo", DbType.Int32, Convert.ToInt32(pre_tiempo)); }
				if (pre_val_aceptado_RRHH.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_val_aceptado_RRHH", DbType.Boolean, Convert.ToBoolean(pre_val_aceptado_RRHH)); }
				if (pre_pl_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, Convert.ToInt32(pre_pl_id)); }
				if (pre_fr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_fr_id", DbType.Int32, Convert.ToInt32(pre_fr_id)); }
				if (pre_pu_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_pu_id", DbType.Int32, Convert.ToInt32(pre_pu_id)); }
				if (pre_as_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_as_id", DbType.Int32, Convert.ToInt32(pre_as_id)); }
				if (pre_presenta_djbr.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_presenta_djbr", DbType.Boolean, Convert.ToBoolean(pre_presenta_djbr)); }
				if (pre_cod_carpeta.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_cod_carpeta", DbType.Int32, Convert.ToInt32(pre_cod_carpeta)); }
				if (pre_afp.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_afp", DbType.String, Convert.ToString(pre_afp)); }
				if (pre_obj_puesto.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_obj_puesto", DbType.String, Convert.ToString(pre_obj_puesto)); }
				if (pre_tareas.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_tareas", DbType.String, Convert.ToString(pre_tareas)); }
				if (pre_numero_item.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_numero_item", DbType.Int32, Convert.ToInt32(pre_numero_item)); }
				if (pre_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, Convert.ToString(pre_estado)); }

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__pc_precontratado()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ListarPlanillas(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_usuario_per_id", DbType.Int32, _pc_precontratado.usuario_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_correlativo", DbType.Int32, _pc_precontratado.pl_correlativo);
                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_pl_estado", DbType.String, _pc_precontratado.pl_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet DetallePlanilla(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_id", DbType.Int32, _pc_precontratado.pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C12");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarUE(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_usuario_per_id", DbType.Int32, _pc_precontratado.usuario_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pr_id", DbType.Int32, _pc_precontratado.pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet AdicionarPlanilla(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_estado", DbType.String, _pc_precontratado.pl_estado);
                CNXSIGRH3.AddInParameter(icom, "p_pl_observaciones", DbType.String, _pc_precontratado.pl_observaciones);
                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet EliminarPlanilla(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_id", DbType.Int32, Convert.ToInt32(_pc_precontratado.pl_id));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet AdicionarPreContratadoPuesto(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fr_id", DbType.Int32, _pc_precontratado.pre_fr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_pu_id", DbType.Int32, _pc_precontratado.pre_pu_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_obj_puesto", DbType.String, _pc_precontratado.pre_obj_puesto);
                CNXSIGRH3.AddInParameter(icom, "p_pre_tareas", DbType.String, _pc_precontratado.pre_tareas);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarPrecontratos(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, _pc_precontratado.es_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_paterno", DbType.String, _pc_precontratado.pre_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet DetallePrecontrato(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C16");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet DatosDetallePrecontrato(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C17");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet BuscarFuncionario(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_ci", DbType.String, _pc_precontratado.pre_ci);
                CNXSIGRH3.AddInParameter(icom, "p_pre_paterno", DbType.String, _pc_precontratado.pre_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_pre_materno", DbType.String, _pc_precontratado.pre_materno);
                CNXSIGRH3.AddInParameter(icom, "p_pre_nombres", DbType.String, _pc_precontratado.pre_nombres);
                CNXSIGRH3.AddInParameter(icom, "p_pre_per_id", DbType.Int32, _pc_precontratado.pre_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_param", DbType.String, _pc_precontratado.param);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGestion(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pr_id", DbType.Int32, _pc_precontratado.pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerContrato(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_per_id", DbType.Int32, _pc_precontratado.pre_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerContratoEditar(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_per_id", DbType.Int32, _pc_precontratado.pre_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C29");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerUltimaFrec(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fr_id", DbType.Int32, _pc_precontratado.pre_fr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerUltimaFrecEditar(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fr_id", DbType.Int32, _pc_precontratado.pre_fr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C30");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerPrecontrato(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_ci", DbType.String, _pc_precontratado.pre_ci);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerPrecontratoEditar(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_ci", DbType.String, _pc_precontratado.pre_ci);
                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C28");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet AsignarPersona(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item", DbType.String, _pc_precontratado.ti_item);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_per_id", DbType.Int32, _pc_precontratado.pre_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_inicio", DbType.DateTime, _pc_precontratado.pre_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_fin", DbType.DateTime, _pc_precontratado.pre_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_pre_tiempo", DbType.Decimal, _pc_precontratado.pre_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_pre_presenta_djbr", DbType.Boolean, _pc_precontratado.pre_presenta_djbr);
                CNXSIGRH3.AddInParameter(icom, "p_pre_numero_item", DbType.Int32, _pc_precontratado.pre_numero_item);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");

                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_sipasse", DbType.DateTime, _pc_precontratado.pre_fecha_sipasse);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_djbr", DbType.DateTime, _pc_precontratado.pre_fecha_djbr);

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ModificarPersona(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item", DbType.String, _pc_precontratado.ti_item);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_per_id", DbType.Int32, _pc_precontratado.pre_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_inicio", DbType.DateTime, _pc_precontratado.pre_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_fin", DbType.DateTime, _pc_precontratado.pre_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_pre_tiempo", DbType.Decimal, _pc_precontratado.pre_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_pre_presenta_djbr", DbType.Boolean, _pc_precontratado.pre_presenta_djbr);
                CNXSIGRH3.AddInParameter(icom, "p_pre_numero_item", DbType.Int32, _pc_precontratado.pre_numero_item);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);

                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_sipasse", DbType.DateTime, _pc_precontratado.pre_fecha_sipasse);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_djbr", DbType.DateTime, _pc_precontratado.pre_fecha_djbr);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C32");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet AsignarPersonaNueva(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item", DbType.String, _pc_precontratado.ti_item);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_inicio", DbType.DateTime, _pc_precontratado.pre_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_fin", DbType.DateTime, _pc_precontratado.pre_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_pre_tiempo", DbType.Decimal, _pc_precontratado.pre_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_pre_presenta_djbr", DbType.Boolean, _pc_precontratado.pre_presenta_djbr);
                CNXSIGRH3.AddInParameter(icom, "p_pre_numero_item", DbType.Int32, _pc_precontratado.pre_numero_item);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);

                CNXSIGRH3.AddInParameter(icom, "p_tmp_ci", DbType.String, _pc_precontratado.tmp_ci);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_ap_paterno", DbType.String, _pc_precontratado.tmp_ap_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_ap_materno", DbType.String, _pc_precontratado.tmp_ap_materno);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_nombres", DbType.String, _pc_precontratado.tmp_nombres);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_ap_casada", DbType.String, _pc_precontratado.tmp_ap_casada);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_mostrar_materno", DbType.Boolean, _pc_precontratado.tmp_mostrar_materno);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_sexo", DbType.String, _pc_precontratado.tmp_sexo);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_afp", DbType.String, _pc_precontratado.tmp_afp);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_estado", DbType.String, _pc_precontratado.tmp_estado);

                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_sipasse", DbType.DateTime, _pc_precontratado.pre_fecha_sipasse);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_djbr", DbType.DateTime, _pc_precontratado.pre_fecha_djbr);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ActualizarPersonaNueva(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item", DbType.String, _pc_precontratado.ti_item);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_inicio", DbType.DateTime, _pc_precontratado.pre_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_fin", DbType.DateTime, _pc_precontratado.pre_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_pre_tiempo", DbType.Decimal, _pc_precontratado.pre_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_pre_presenta_djbr", DbType.Boolean, _pc_precontratado.pre_presenta_djbr);
                CNXSIGRH3.AddInParameter(icom, "p_pre_numero_item", DbType.Int32, _pc_precontratado.pre_numero_item);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);

                CNXSIGRH3.AddInParameter(icom, "p_tmp_id", DbType.String, _pc_precontratado.tmp_id);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_ci", DbType.String, _pc_precontratado.tmp_ci);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_ap_paterno", DbType.String, _pc_precontratado.tmp_ap_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_ap_materno", DbType.String, _pc_precontratado.tmp_ap_materno);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_nombres", DbType.String, _pc_precontratado.tmp_nombres);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_ap_casada", DbType.String, _pc_precontratado.tmp_ap_casada);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_mostrar_materno", DbType.Boolean, _pc_precontratado.tmp_mostrar_materno);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_sexo", DbType.String, _pc_precontratado.tmp_sexo);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_afp", DbType.String, _pc_precontratado.tmp_afp);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_estado", DbType.String, _pc_precontratado.tmp_estado);

                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_sipasse", DbType.DateTime, _pc_precontratado.pre_fecha_sipasse);
                CNXSIGRH3.AddInParameter(icom, "p_pre_fecha_djbr", DbType.DateTime, _pc_precontratado.pre_fecha_djbr);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C31");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarUsuarios(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_perm_us_id", DbType.Int32, _pc_precontratado.us_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C13");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ActualizarEstadoPlanilla(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_id", DbType.Int32, _pc_precontratado.pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_estado", DbType.String, _pc_precontratado.pl_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ActualizarEstadoPlanillaUDEP(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_id", DbType.Int32, _pc_precontratado.pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C54");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarEstadoPrecontrato(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado_x", DbType.String, _pc_precontratado.pre_estado_x);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C15");
                CNXSIGRH3.ExecuteDataSet(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarEstadoPrecontratoEnvio(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado_x", DbType.String, _pc_precontratado.pre_estado_x);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C33");
                CNXSIGRH3.ExecuteDataSet(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarAsignacion(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B2");
                CNXSIGRH3.ExecuteDataSet(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarAsignacionNuevo(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B3");
                CNXSIGRH3.ExecuteDataSet(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarPuesto(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_pu_id", DbType.Int32, _pc_precontratado.pre_pu_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_obj_puesto", DbType.String, _pc_precontratado.pre_obj_puesto);
                CNXSIGRH3.AddInParameter(icom, "p_pre_tareas", DbType.String, _pc_precontratado.pre_tareas);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C18");
                CNXSIGRH3.ExecuteDataSet(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarPuestoDJBR(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_afp", DbType.String, _pc_precontratado.pre_afp);
                CNXSIGRH3.AddInParameter(icom, "p_pre_presenta_djbr", DbType.Boolean, _pc_precontratado.pre_presenta_djbr);
                CNXSIGRH3.AddInParameter(icom, "p_pre_pu_id", DbType.Int32, _pc_precontratado.pre_pu_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_obj_puesto", DbType.String, _pc_precontratado.pre_obj_puesto);
                CNXSIGRH3.AddInParameter(icom, "p_pre_tareas", DbType.String, _pc_precontratado.pre_tareas);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C38");
                CNXSIGRH3.ExecuteDataSet(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet DatosPuestoX(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerNroItem(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item", DbType.String, _pc_precontratado.ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C19");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerListaFiltradoPlanilla(cls_pc_precontratado _pc_precontratado, string q)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, _pc_precontratado.es_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_paterno", DbType.String, _pc_precontratado.pre_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_param", DbType.String, q);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, _pc_precontratado.accion);
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarPlanillasAprobar(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_usuario_per_id", DbType.Int32, _pc_precontratado.usuario_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_correlativo", DbType.Int32, _pc_precontratado.pl_correlativo);
                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_pl_estado", DbType.String, _pc_precontratado.pl_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C22");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerEstadoPlanilla(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C23");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerCambiarEstadoPlanilla(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);
                CNXSIGRH3.AddInParameter(icom, "p_pre_estado_x", DbType.String, _pc_precontratado.pre_estado_x);
                CNXSIGRH3.AddInParameter(icom, "p_pl_estado", DbType.String, _pc_precontratado.pl_estado);
                CNXSIGRH3.AddInParameter(icom, "p_pl_estado_x", DbType.String, _pc_precontratado.pl_estado_x);
                CNXSIGRH3.AddInParameter(icom, "p_pl_observaciones", DbType.String, _pc_precontratado.pl_observaciones);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C24");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarAnulados(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, _pc_precontratado.es_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_paterno", DbType.String, _pc_precontratado.pre_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C25");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarPlanillasValidar(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_usuario_per_id", DbType.Int32, _pc_precontratado.usuario_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_correlativo", DbType.Int32, _pc_precontratado.pl_correlativo);
                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_pl_estado", DbType.String, _pc_precontratado.pl_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C26");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerValidacionFechas(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C34");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerCambiarFechas(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C27");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarPlanillasUDEP(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_usuario_per_id", DbType.Int32, _pc_precontratado.usuario_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_correlativo", DbType.Int32, _pc_precontratado.pl_correlativo);
                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_pl_mes", DbType.Int32, _pc_precontratado.pl_mes);
                CNXSIGRH3.AddInParameter(icom, "p_pl_estado", DbType.String, _pc_precontratado.pl_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C35");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet DatosPrecontratoUDEP(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C36");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool PrecontratoEstadoUDEP(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_estado", DbType.String, _pc_precontratado.pre_estado);
                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C37");
                CNXSIGRH3.ExecuteDataSet(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarPlanillasObservadas(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_usuario_per_id", DbType.Int32, _pc_precontratado.usuario_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_correlativo", DbType.Int32, _pc_precontratado.pl_correlativo);
                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_pl_estado", DbType.String, _pc_precontratado.pl_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C39");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarPlanillasBusqueda(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_usuario_per_id", DbType.Int32, _pc_precontratado.usuario_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_correlativo", DbType.Int32, _pc_precontratado.pl_correlativo);
                CNXSIGRH3.AddInParameter(icom, "p_pl_ue", DbType.Int32, _pc_precontratado.pl_ue);
                CNXSIGRH3.AddInParameter(icom, "p_pl_estado", DbType.String, _pc_precontratado.pl_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C40");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet StockCargosUE(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_id", DbType.Int32, _pc_precontratado.pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C42");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet DetalleCargo(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.Int32, _pc_precontratado.cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, _pc_precontratado.es_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C43");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet DetallePreFuncionario(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C44");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDescendencia(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.Int32, _pc_precontratado.cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C45");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarPrecontratosValidados(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pre_pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, _pc_precontratado.es_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_paterno", DbType.String, _pc_precontratado.pre_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C46");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet DetallePreFuncionarioNuevo(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C47");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet EliminarPreFuncionarioNuevo(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_per_id", DbType.Int32, _pc_precontratado.pre_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C48");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerResumenPlanilla(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_pl_id", DbType.Int32, _pc_precontratado.pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C49");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ActualizarDatosPersonaUDEP(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_per_id", DbType.Int32, _pc_precontratado.pre_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_id", DbType.Int32, _pc_precontratado.tmp_id);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_ci", DbType.String, _pc_precontratado.tmp_ci);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_ap_paterno", DbType.String, _pc_precontratado.tmp_ap_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_ap_materno", DbType.String, _pc_precontratado.tmp_ap_materno);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_nombres", DbType.String, _pc_precontratado.tmp_nombres);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_ap_casada", DbType.String, _pc_precontratado.tmp_ap_casada);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_sexo", DbType.String, _pc_precontratado.tmp_sexo);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_afp", DbType.String, _pc_precontratado.tmp_afp);
                CNXSIGRH3.AddInParameter(icom, "p_tmp_estado", DbType.String, _pc_precontratado.tmp_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, _pc_precontratado.accion);
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet DetalleRestriccion(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_precontratado.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C52");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet DetalleContratados(cls_pc_precontratado _pc_precontratado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_PRECONTRATADO);

                CNXSIGRH3.AddInParameter(icom, "p_pl_id", DbType.Int32, _pc_precontratado.pl_id);
                CNXSIGRH3.AddInParameter(icom, "p_pl_pr_id", DbType.Int32, _pc_precontratado.pl_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C53");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _PC_FRECUENCIA
        public override DataSet Adicionar__pc_frecuencia(cls_pc_frecuencia _pc_frecuencia)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.Int32, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_cod_poa", DbType.Int32, _pc_frecuencia.fr_cod_poa);
				CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.Int32, _pc_frecuencia.fr_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tipo_jornada", DbType.String, _pc_frecuencia.fr_tipo_jornada);
                CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_inicio", DbType.DateTime, _pc_frecuencia.fr_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_fin", DbType.DateTime, _pc_frecuencia.fr_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tiempo", DbType.Decimal, _pc_frecuencia.fr_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pu_id", DbType.String, _pc_frecuencia.fr_descrip_puesto);
                CNXSIGRH3.AddInParameter(icom, "p_fr_obj_puesto", DbType.String, _pc_frecuencia.fr_obj_puesto);
                CNXSIGRH3.AddInParameter(icom, "p_fr_observaciones", DbType.String, _pc_frecuencia.fr_observaciones);
                CNXSIGRH3.AddInParameter(icom, "p_fr_estado", DbType.String, _pc_frecuencia.fr_estado);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Eliminar__pc_frecuencia(cls_pc_frecuencia _pc_frecuencia)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

				CNXSIGRH3.AddInParameter(icom, "p_fr_id", DbType.Int32, _pc_frecuencia.fr_id);
				CNXSIGRH3.AddInParameter(icom, "p_fr_observaciones", DbType.String, _pc_frecuencia.fr_observaciones);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet Actualizar__pc_frecuencia(cls_pc_frecuencia _pc_frecuencia)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

				CNXSIGRH3.AddInParameter(icom, "p_fr_id", DbType.Int32, _pc_frecuencia.fr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.Int32, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_cod_poa", DbType.Int32, _pc_frecuencia.fr_cod_poa);
                CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.Int32, _pc_frecuencia.fr_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tipo_jornada", DbType.String, _pc_frecuencia.fr_tipo_jornada);
                CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_inicio", DbType.DateTime, _pc_frecuencia.fr_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_fin", DbType.DateTime, _pc_frecuencia.fr_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tiempo", DbType.Decimal, _pc_frecuencia.fr_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pu_id", DbType.String, _pc_frecuencia.fr_descrip_puesto);
                CNXSIGRH3.AddInParameter(icom, "p_fr_obj_puesto", DbType.String, _pc_frecuencia.fr_obj_puesto);
                CNXSIGRH3.AddInParameter(icom, "p_fr_observaciones", DbType.String, _pc_frecuencia.fr_observaciones);
                CNXSIGRH3.AddInParameter(icom, "p_fr_estado", DbType.String, _pc_frecuencia.fr_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerId__pc_frecuencia(cls_pc_frecuencia _pc_frecuencia)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_pc_frecuencia.fr_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fr_id"]);
		
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerRegistro__pc_frecuencia(cls_pc_frecuencia _pc_frecuencia)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

				CNXSIGRH3.AddInParameter(icom, "p_fr_id", DbType.Int32, _pc_frecuencia.fr_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				if (ds.Tables[0].Rows[0]["fr_id"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_id"].ToString().Trim() != "") { _pc_frecuencia.fr_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fr_id"]); }
				if (ds.Tables[0].Rows[0]["fr_pr_id"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_pr_id"].ToString().Trim() != "") { _pc_frecuencia.fr_pr_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fr_pr_id"]); }
				if (ds.Tables[0].Rows[0]["fr_es_id"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_es_id"].ToString().Trim() != "") { _pc_frecuencia.fr_es_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fr_es_id"]); }
				if (ds.Tables[0].Rows[0]["fr_tiempo"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_tiempo"].ToString().Trim() != "") { _pc_frecuencia.fr_tiempo = Convert.ToInt32(ds.Tables[0].Rows[0]["fr_tiempo"]); }
				if (ds.Tables[0].Rows[0]["fr_cp_id"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_cp_id"].ToString().Trim() != "") { _pc_frecuencia.fr_cp_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fr_cp_id"]); }
				if (ds.Tables[0].Rows[0]["fr_fecha_creacion"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_fecha_creacion"].ToString().Trim() != "") { _pc_frecuencia.fr_fecha_creacion = Convert.ToString(ds.Tables[0].Rows[0]["fr_fecha_creacion"]); }
				if (ds.Tables[0].Rows[0]["fr_fecha_modificacion"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_fecha_modificacion"].ToString().Trim() != "") { _pc_frecuencia.fr_fecha_modificacion = Convert.ToString(ds.Tables[0].Rows[0]["fr_fecha_modificacion"]); }
				if (ds.Tables[0].Rows[0]["fr_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_estado"].ToString().Trim() != "") { _pc_frecuencia.fr_estado = Convert.ToString(ds.Tables[0].Rows[0]["fr_estado"]); }
				if (ds.Tables[0].Rows[0]["fr_descrip_puesto"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_descrip_puesto"].ToString().Trim() != "") { _pc_frecuencia.fr_descrip_puesto = Convert.ToString(ds.Tables[0].Rows[0]["fr_descrip_puesto"]); }
				if (ds.Tables[0].Rows[0]["fr_cod_poa"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_cod_poa"].ToString().Trim() != "") { _pc_frecuencia.fr_cod_poa = Convert.ToInt32(ds.Tables[0].Rows[0]["fr_cod_poa"]); }
				if (ds.Tables[0].Rows[0]["fr_fecha_inicio"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_fecha_inicio"].ToString().Trim() != "") { _pc_frecuencia.fr_fecha_inicio = Convert.ToString(ds.Tables[0].Rows[0]["fr_fecha_inicio"]); }
				if (ds.Tables[0].Rows[0]["fr_fecha_fin"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_fecha_fin"].ToString().Trim() != "") { _pc_frecuencia.fr_fecha_fin = Convert.ToString(ds.Tables[0].Rows[0]["fr_fecha_fin"]); }
				if (ds.Tables[0].Rows[0]["fr_id_anterior"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_id_anterior"].ToString().Trim() != "") { _pc_frecuencia.fr_id_anterior = Convert.ToInt32(ds.Tables[0].Rows[0]["fr_id_anterior"]); }
				if (ds.Tables[0].Rows[0]["fr_tiempooriginal"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_tiempooriginal"].ToString().Trim() != "") { _pc_frecuencia.fr_tiempooriginal = Convert.ToInt32(ds.Tables[0].Rows[0]["fr_tiempooriginal"]); }
				if (ds.Tables[0].Rows[0]["fr_tipo_jornada"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_tipo_jornada"].ToString().Trim() != "") { _pc_frecuencia.fr_tipo_jornada = Convert.ToString(ds.Tables[0].Rows[0]["fr_tipo_jornada"]); }
				if (ds.Tables[0].Rows[0]["fr_obj_puesto"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_obj_puesto"].ToString().Trim() != "") { _pc_frecuencia.fr_obj_puesto = Convert.ToString(ds.Tables[0].Rows[0]["fr_obj_puesto"]); }
				if (ds.Tables[0].Rows[0]["fr_observaciones"] != DBNull.Value && ds.Tables[0].Rows[0]["fr_observaciones"].ToString().Trim() != "") { _pc_frecuencia.fr_observaciones = Convert.ToString(ds.Tables[0].Rows[0]["fr_observaciones"]); }
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaGrilla__pc_frecuencia(string fr_id, 
						string fr_pr_id, 
						string fr_es_id, 
						string fr_tiempo, 
						string fr_cp_id, 
						string fr_fecha_creacion, 
						string fr_fecha_modificacion, 
						string fr_estado, 
						string fr_descrip_puesto, 
						string fr_cod_poa, 
						string fr_fecha_inicio, 
						string fr_fecha_fin, 
						string fr_id_anterior, 
						string fr_tiempooriginal, 
						string fr_tipo_jornada, 
						string fr_obj_puesto, 
						string fr_observaciones)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

				if (fr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_id", DbType.Int32, Convert.ToInt32(fr_id)); }
				if (fr_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, Convert.ToInt32(fr_pr_id)); }
				if (fr_es_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.Int32, Convert.ToInt32(fr_es_id)); }
				if (fr_tiempo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_tiempo", DbType.Int32, Convert.ToInt32(fr_tiempo)); }
				if (fr_cp_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.Int32, Convert.ToInt32(fr_cp_id)); }
				if (fr_fecha_creacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_creacion", DbType.DateTime, Convert.ToString(fr_fecha_creacion)); }
				if (fr_fecha_modificacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_modificacion", DbType.DateTime, Convert.ToString(fr_fecha_modificacion)); }
				if (fr_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_estado", DbType.String, Convert.ToString(fr_estado)); }
				if (fr_descrip_puesto.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_pu_id", DbType.String, Convert.ToString(fr_descrip_puesto)); }
				if (fr_cod_poa.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_cod_poa", DbType.Int32, Convert.ToInt32(fr_cod_poa)); }
				if (fr_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_inicio", DbType.DateTime, Convert.ToString(fr_fecha_inicio)); }
				if (fr_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_fin", DbType.DateTime, Convert.ToString(fr_fecha_fin)); }
				if (fr_id_anterior.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_id_anterior", DbType.Int32, Convert.ToInt32(fr_id_anterior)); }
				if (fr_tiempooriginal.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_tiempooriginal", DbType.Int32, Convert.ToInt32(fr_tiempooriginal)); }
				if (fr_tipo_jornada.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_tipo_jornada", DbType.String, Convert.ToString(fr_tipo_jornada)); }
				if (fr_obj_puesto.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_obj_puesto", DbType.String, Convert.ToString(fr_obj_puesto)); }
				if (fr_observaciones.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fr_observaciones", DbType.String, Convert.ToString(fr_observaciones)); }
 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__pc_frecuencia()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerEscalafonNS(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_ns_id", DbType.Int32, _pc_frecuencia.ns_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C44");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFiltradoGestion()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet BuscarCategorias(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_perm_us_id", DbType.Int32, _pc_frecuencia.perm_us_id);
                CNXSIGRH3.AddInParameter(icom, "p_cp_da", DbType.Int32, _pc_frecuencia.cp_da);
                CNXSIGRH3.AddInParameter(icom, "p_cp_ue", DbType.Int32, _pc_frecuencia.cp_ue);
                CNXSIGRH3.AddInParameter(icom, "p_cp_programa", DbType.Int32, _pc_frecuencia.cp_programa);
                CNXSIGRH3.AddInParameter(icom, "p_cp_proyecto", DbType.Int32, _pc_frecuencia.cp_proyecto);
                CNXSIGRH3.AddInParameter(icom, "p_cp_actividad", DbType.Int32, _pc_frecuencia.cp_actividad);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarrCategorias(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_perm_us_id", DbType.Int32, _pc_frecuencia.perm_us_id);
                CNXSIGRH3.AddInParameter(icom, "p_cp_da", DbType.Int32, _pc_frecuencia.cp_da);
                CNXSIGRH3.AddInParameter(icom, "p_cp_ue", DbType.Int32, _pc_frecuencia.cp_ue);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C19");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarOperaciones(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_json", DbType.String, _pc_frecuencia.json);
                CNXSIGRH3.AddInParameter(icom, "p_cp_da", DbType.Int32, _pc_frecuencia.cp_da);
                CNXSIGRH3.AddInParameter(icom, "p_cp_ue", DbType.Int32, _pc_frecuencia.cp_ue);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C35");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ActualizarFrecuencia(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_id", DbType.Int32, _pc_frecuencia.fr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.Int32, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_cod_poa", DbType.Int32, _pc_frecuencia.fr_cod_poa);
                CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.Int32, _pc_frecuencia.fr_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tipo_jornada", DbType.String, _pc_frecuencia.fr_tipo_jornada);
                CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_inicio", DbType.DateTime, _pc_frecuencia.fr_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_fin", DbType.DateTime, _pc_frecuencia.fr_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tiempo", DbType.Decimal, _pc_frecuencia.fr_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pu_id", DbType.String, _pc_frecuencia.fr_descrip_puesto);
                CNXSIGRH3.AddInParameter(icom, "p_fr_obj_puesto", DbType.String, _pc_frecuencia.fr_obj_puesto);
                CNXSIGRH3.AddInParameter(icom, "p_fr_estado", DbType.String, _pc_frecuencia.fr_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C21");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet EliminarFrecuencia(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_id", DbType.Int32, _pc_frecuencia.fr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet VerEstadoCategoria(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.Int32, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C20");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFrecuenciasCategorias(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.Int32, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.Int32, _pc_frecuencia.fr_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tiempo", DbType.Decimal, _pc_frecuencia.fr_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_fr_estado", DbType.String, _pc_frecuencia.fr_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFrecuenciasOperacion(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cod_poa", DbType.Int32, _pc_frecuencia.fr_cod_poa);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.Int32, _pc_frecuencia.fr_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tiempo", DbType.Decimal, _pc_frecuencia.fr_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_fr_estado", DbType.String, _pc_frecuencia.fr_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C36");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerResumenFrecuenciasCategorias(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.String, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerResumenFrecuenciasCategoriasF(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.String, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C23");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerResumenFrecuenciasOperacion(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cod_poa", DbType.Int32, _pc_frecuencia.fr_cod_poa);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.String, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C38");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerResumenPresup(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerComprometidoOperacion(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C30");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerComprometidoPorOperacion(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cod_poa", DbType.String, _pc_frecuencia.fr_cod_poa);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C39");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerInformacionCategoria(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerHaberBasico(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.String, _pc_frecuencia.es_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerListaFiltradoPuesto(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.String, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.String, _pc_frecuencia.fr_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C33");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerTiempoMeses(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_inicio", DbType.String, _pc_frecuencia.fr_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_fin", DbType.String, _pc_frecuencia.fr_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFrecuenciaX(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_id", DbType.String, _pc_frecuencia.fr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerCategorias(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_perm_us_id", DbType.Int32, _pc_frecuencia.perm_us_id);
                CNXSIGRH3.AddInParameter(icom, "p_perm_ue", DbType.Int32, _pc_frecuencia.perm_ue);
                CNXSIGRH3.AddInParameter(icom, "p_perm_pr_id", DbType.Int32, _pc_frecuencia.perm_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C13");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFrecuenciasLibres(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.Int32, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.Int32, _pc_frecuencia.fr_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pu_id", DbType.String, _pc_frecuencia.fr_descrip_puesto);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tiempo", DbType.Decimal, _pc_frecuencia.fr_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C12");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFrecuenciasLibresX(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.Int32, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_id", DbType.Int32, _pc_frecuencia.fr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerListaFiltradoFrec(cls_pc_frecuencia _pc_frecuencia, string q = "")
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.String, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.Int32, _pc_frecuencia.fr_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pu_id", DbType.String, _pc_frecuencia.fr_descrip_puesto);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tiempo", DbType.Decimal, _pc_frecuencia.fr_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_param", DbType.String, q);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, _pc_frecuencia.accion);
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerListaFiltradoFrecuencia(cls_pc_frecuencia _pc_frecuencia, string q = "")
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.String, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.Int32, _pc_frecuencia.fr_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tiempo", DbType.Decimal, _pc_frecuencia.fr_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_fr_estado", DbType.String, _pc_frecuencia.fr_estado);
                CNXSIGRH3.AddInParameter(icom, "p_param", DbType.String, q);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, _pc_frecuencia.accion);
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerListaFiltradoFrecuenciaOperacion(cls_pc_frecuencia _pc_frecuencia, string q = "")
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.String, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_cod_poa", DbType.Int32, _pc_frecuencia.fr_cod_poa);
                CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.Int32, _pc_frecuencia.fr_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tiempo", DbType.Decimal, _pc_frecuencia.fr_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_fr_estado", DbType.String, _pc_frecuencia.fr_estado);
                CNXSIGRH3.AddInParameter(icom, "p_param", DbType.String, q);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, _pc_frecuencia.accion);
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFrecuenciasLibresES(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.Int32, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.Int32, _pc_frecuencia.fr_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C16");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFrecuenciaOcupadoX(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_id", DbType.Int32, _pc_frecuencia.fr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C17");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFrecuenciaOcupadoX2(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_id", DbType.Int32, _pc_frecuencia.fr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _pc_frecuencia.fr_pu_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C28");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleReplicaX(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.Int32, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_es_id", DbType.Int32, _pc_frecuencia.fr_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tipo_jornada", DbType.String, _pc_frecuencia.fr_tipo_jornada);
                CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_inicio", DbType.DateTime, _pc_frecuencia.fr_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_fr_fecha_fin", DbType.DateTime, _pc_frecuencia.fr_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_fr_tiempo", DbType.Decimal, _pc_frecuencia.fr_tiempo);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C24");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerTiempoUso(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_id", DbType.Int32, _pc_frecuencia.fr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C45");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerUsuarios(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.Int32, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.Int32, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_perm_us_id", DbType.Int32, _pc_frecuencia.perm_us_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C25");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerRemitente(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C26");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerListaFiltradoTipoItem(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C27");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerCategoriasPresup(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.String, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C29");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerCategoriasUE(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.String, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C31");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerPresupuestoUE(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C32");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerPermisosUE(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_perm_us_id", DbType.String, _pc_frecuencia.perm_us_id);
                CNXSIGRH3.AddInParameter(icom, "p_fr_pr_id", DbType.String, _pc_frecuencia.fr_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C34");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerResumenGral(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C41");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarOperacion(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cod_poa", DbType.Int32, _pc_frecuencia.fr_cod_poa);
                CNXSIGRH3.AddInParameter(icom, "p_fr_estado", DbType.String, _pc_frecuencia.fr_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C42");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerSaldoCategoria(cls_pc_frecuencia _pc_frecuencia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PC_FRECUENCIA);

                CNXSIGRH3.AddInParameter(icom, "p_fr_cp_id", DbType.String, _pc_frecuencia.fr_cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C43");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _PRECONTRATACIONES_CS

        private const string SP__PRECONTRATACIONES_CS = "SP_Precontrataciones_CS";

        /// <summary>
        /// Verifica el estado de una persona (E1)
        /// </summary>
        public override DataSet VerificarEstadoPersona__precontrataciones_cs(cls_precontrataciones_cs obj)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PRECONTRATACIONES_CS);

                CNXSIGRH3.AddInParameter(icom, "pp_us_id", DbType.Int32, obj.pp_us_id);
                CNXSIGRH3.AddInParameter(icom, "pp_per_id", DbType.Int32, obj.pp_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "E1");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Crea un nuevo contrato (A2) y para (U1)
        /// </summary>
        public override int CrearContrato__precontrataciones_cs(cls_precontrataciones_cs obj)
        {
            try
            {
                DbCommand icom = CNXSIGRH3.GetStoredProcCommand(SP__PRECONTRATACIONES_CS);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, obj.p_accion);
                CNXSIGRH3.AddInParameter(icom, "pp_us_id", DbType.Int32, obj.pp_us_id);
                CNXSIGRH3.AddInParameter(icom, "pp_per_id", DbType.Int32, obj.pp_per_id);
                CNXSIGRH3.AddInParameter(icom, "pp_es_id", DbType.Int32, obj.pp_es_id);
                CNXSIGRH3.AddInParameter(icom, "pp_eo_id", DbType.Int32, obj.pp_eo_id);
                CNXSIGRH3.AddInParameter(icom, "pp_haber_basico", DbType.Decimal, obj.pp_haber_basico);
                CNXSIGRH3.AddInParameter(icom, "pp_fecha_inicio", DbType.String, obj.pp_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "pp_fecha_fin", DbType.String, obj.pp_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "pp_p_descripcion", DbType.String, obj.pp_p_descripcion);
                CNXSIGRH3.AddInParameter(icom, "pp_pu_objetivo", DbType.String, obj.pp_pu_objetivo);
                CNXSIGRH3.AddInParameter(icom, "pp_p_funciones", DbType.String, obj.pp_p_funciones);
                CNXSIGRH3.AddInParameter(icom, "pp_cite", DbType.String, obj.pp_cite);
                CNXSIGRH3.AddInParameter(icom, "pp_as_id", DbType.Int32, obj.pp_as_id);
                CNXSIGRH3.AddInParameter(icom, "pp_as_tipo_baja", DbType.String, obj.pp_as_tipo_baja);
                CNXSIGRH3.AddInParameter(icom, "pp_as_memo_baja", DbType.Int32, obj.pp_as_memo_baja);
                CNXSIGRH3.AddInParameter(icom, "p_ca_id_actual", DbType.Int32, obj.p_ca_id_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_estado", DbType.String, obj.p_ca_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, obj.p_ca_num_item);

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                if (ds != null &&
                    ds.Tables.Count > 0 &&
                    ds.Tables[0].Rows.Count > 0 &&
                    ds.Tables[0].Columns.Contains("nuevo_as_id"))
                {
                    return Convert.ToInt32(
                        ds.Tables[0].Rows[0]["nuevo_as_id"]
                    );
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error al crear/modificar contrato: " + ex.Message,
                    ex
                );
            }
        }

        /// <summary>
        /// Obtiene lista de contratos (PC1)
        /// </summary>
        public override DataSet ObtenerListaContratos__precontrataciones_cs(int us_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PRECONTRATACIONES_CS);

                CNXSIGRH3.AddInParameter(icom, "pp_us_id", DbType.Int32, us_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "PC1");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Obtiene lista de escalas salariales (PC2)
        /// </summary>
        public override DataSet ObtenerEscalasSalariales__precontrataciones_cs()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PRECONTRATACIONES_CS);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "PC2");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Obtiene los datos del contrato de una persona (C3)
        /// </summary>
        public override DataSet ObtenerContratoPorPersona__precontrataciones_cs(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PRECONTRATACIONES_CS);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                CNXSIGRH3.AddInParameter(icom, "pp_per_id", DbType.Int32, per_id);

                CNXSIGRH3.AddInParameter(icom, "pp_us_id", DbType.Int32, DBNull.Value);
                CNXSIGRH3.AddInParameter(icom, "pp_es_id", DbType.Int32, DBNull.Value);
                CNXSIGRH3.AddInParameter(icom, "pp_eo_id", DbType.Int32, DBNull.Value);
                CNXSIGRH3.AddInParameter(icom, "pp_haber_basico", DbType.Decimal, DBNull.Value);
                CNXSIGRH3.AddInParameter(icom, "pp_fecha_inicio", DbType.String, DBNull.Value);
                CNXSIGRH3.AddInParameter(icom, "pp_fecha_fin", DbType.String, DBNull.Value);
                CNXSIGRH3.AddInParameter(icom, "pp_p_descripcion", DbType.String, DBNull.Value);
                CNXSIGRH3.AddInParameter(icom, "pp_pu_objetivo", DbType.String, DBNull.Value);
                CNXSIGRH3.AddInParameter(icom, "pp_p_funciones", DbType.String, DBNull.Value);
                CNXSIGRH3.AddInParameter(icom, "pp_cite", DbType.String, DBNull.Value);

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener contrato por persona: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene el nivel y clase de una escala salarial
        /// </summary>
        public DataSet ObtenerNivelClaseEscala__precontrataciones_cs(int esId)
        {
            try
            {
                string query = @"
                SELECT ns.ns_nivel, ns.ns_clase
                FROM tbl_mp_escala_salarial es
                INNER JOIN tbl_mp_nivel_salarial ns ON es.es_ns_id = ns.ns_id
                WHERE es.es_id = @es_id";

                DbCommand cmd = CNXSIGRH3.GetSqlStringCommand(query);
                CNXSIGRH3.AddInParameter(cmd, "@es_id", DbType.Int32, esId);

                DataSet ds = CNXSIGRH3.ExecuteDataSet(cmd);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener nivel y clase: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Da de baja una asignación (U1) - Para Modificación de Contrato
        /// </summary>
        public override bool ActualizarBajaAsignacion__precontrataciones_cs(cls_precontrataciones_cs obj)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PRECONTRATACIONES_CS);

                // Parámetros del SP
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U1");
                CNXSIGRH3.AddInParameter(icom, "pp_us_id", DbType.Int32, obj.pp_us_id);
                CNXSIGRH3.AddInParameter(icom, "pp_as_id", DbType.Int32, obj.pp_as_id);
                CNXSIGRH3.AddInParameter(icom, "pp_fecha_inicio", DbType.String, obj.pp_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "pp_fecha_fin", DbType.String, obj.pp_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "pp_as_tipo_baja", DbType.String, obj.pp_as_tipo_baja);
                CNXSIGRH3.AddInParameter(icom, "pp_as_memo_baja", DbType.Int32, obj.pp_as_memo_baja);

                // --- AGREGA ESTA LÍNEA (EL PARÁMETRO FALTANTE) ---
                CNXSIGRH3.AddInParameter(icom, "pp_per_id", DbType.Int32, obj.pp_per_id);
                // --------------------------------------------------

                // ... (El resto del método sigue igual)
                int numItem = obj.p_ca_num_item > 0 ? obj.p_ca_num_item : 0;
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, numItem);

                int caIdActual = obj.p_ca_id_actual > 0 ? obj.p_ca_id_actual : 0;
                CNXSIGRH3.AddInParameter(icom, "p_ca_id_actual", DbType.Int32, caIdActual);

                CNXSIGRH3.ExecuteNonQuery(icom); // Solo ejecuta el SP

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja la asignación: " + ex.Message, ex);
            }
        }

        #endregion
    }
}