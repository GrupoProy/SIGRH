using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Globalization;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
    public class DataAccessLayerSQLDataAccessLayer : DataAccessLayerDataAccessLayer
    {
        #region CONSTANTES
		private string SP__MP_ESTRUCTURA_ORGANIZACIONAL = "sp_mp_estructura_organizacional";
        private string SP__MP_TIPO_ITEM = "sp_mp_tipo_item";
        private string SP__MP_ESCALA_SALARIAL = "sp_mp_escala_salarial";
		private string SP__ESCALA_PUESTO = "sp_escala_puesto";
		private string SP__MP_PRESUPUESTO = "sp_mp_presupuesto";
		private string SP__MP_CATEGORIA_PROGRAMATICA = "sp_mp_categoria_programatica";
		private string SP__MP_CARGO_PUESTO = "sp_mp_cargo_puesto";
		private string SP__PUESTOS = "sp_puestos";
        private string SP__SITUACION_PERSONA = "sp_situacion_persona";
        private string SP__MP_ASIGNACION_COM_INT = "sp_mp_asignacion_com_int";
        private string SP__MP_SEGUIMIENTO_MEMORANDUM = "sp_mp_seguimiento_memorandum";
        private string SP__MP_ASIGNACION = "sp_mp_asignacion";
        private string SP__MP_INCOMPATIBILIDAD_FUN = "sp_mp_incompatibilidad_fun";
        private string SP__MP_TIPO_ABONO = "sp_mp_tipo_abono";
        private string SP__PERSONA = "sp_persona";
        private string SP__PERSONA_DOMICILIO = "sp_persona_domicilio";
        private string SP__PERSONA_FAMILIARES = "sp_persona_familiares";
        private string SP__MP_CARGO = "sp_mp_cargo";
        private string SP_DOC_PLANES_CARRERAS = "SP_DOC_PLANES_CARRERAS";
        #endregion

        //INTERFACES
        #region _MP_ESTRUCTURA_ORGANIZACIONAL
        public override bool Adicionar__mp_estructura_organizacional(cls_mp_estructura_organizacional _mp_estructura_organizacional)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

				CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.Int32, _mp_estructura_organizacional.eo_id);
				CNXSIGRH3.AddInParameter(icom, "p_eo_pr_id", DbType.Int32, _mp_estructura_organizacional.eo_pr_id);
				CNXSIGRH3.AddInParameter(icom, "p_eo_cp_id", DbType.Int32, _mp_estructura_organizacional.eo_cp_id);
				CNXSIGRH3.AddInParameter(icom, "p_eo_prog", DbType.Int32, _mp_estructura_organizacional.eo_prog);
				CNXSIGRH3.AddInParameter(icom, "p_eo_sprog", DbType.Int32, _mp_estructura_organizacional.eo_sprog);
				CNXSIGRH3.AddInParameter(icom, "p_eo_proy", DbType.Int32, _mp_estructura_organizacional.eo_proy);
				CNXSIGRH3.AddInParameter(icom, "p_eo_obract", DbType.Int32, _mp_estructura_organizacional.eo_obract);
				CNXSIGRH3.AddInParameter(icom, "p_eo_unidad", DbType.Int32, _mp_estructura_organizacional.eo_unidad);
				CNXSIGRH3.AddInParameter(icom, "p_eo_descripcion", DbType.String, _mp_estructura_organizacional.eo_descripcion);
				CNXSIGRH3.AddInParameter(icom, "p_eo_estado", DbType.String, _mp_estructura_organizacional.eo_estado);
				CNXSIGRH3.AddInParameter(icom, "p_eo_cod_superior", DbType.Int32, _mp_estructura_organizacional.eo_cod_superior);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Eliminar__mp_estructura_organizacional(cls_mp_estructura_organizacional _mp_estructura_organizacional)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

				CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.Int32, _mp_estructura_organizacional.eo_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Actualizar__mp_estructura_organizacional(cls_mp_estructura_organizacional _mp_estructura_organizacional)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

				CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.Int32, _mp_estructura_organizacional.eo_id);
				//CNXSIGRH3.AddInParameter(icom, "p_eo_pr_id", DbType.Int32, _mp_estructura_organizacional.eo_pr_id);
				CNXSIGRH3.AddInParameter(icom, "p_eo_cp_id", DbType.Int32, _mp_estructura_organizacional.eo_cp_id);
				//CNXSIGRH3.AddInParameter(icom, "p_eo_prog", DbType.Int32, _mp_estructura_organizacional.eo_prog);
				//CNXSIGRH3.AddInParameter(icom, "p_eo_sprog", DbType.Int32, _mp_estructura_organizacional.eo_sprog);
				//CNXSIGRH3.AddInParameter(icom, "p_eo_proy", DbType.Int32, _mp_estructura_organizacional.eo_proy);
				//CNXSIGRH3.AddInParameter(icom, "p_eo_obract", DbType.Int32, _mp_estructura_organizacional.eo_obract);
				//CNXSIGRH3.AddInParameter(icom, "p_eo_unidad", DbType.Int32, _mp_estructura_organizacional.eo_unidad);
				CNXSIGRH3.AddInParameter(icom, "p_eo_descripcion", DbType.String, _mp_estructura_organizacional.eo_descripcion);
				//CNXSIGRH3.AddInParameter(icom, "p_eo_estado", DbType.String, _mp_estructura_organizacional.eo_estado);
				//CNXSIGRH3.AddInParameter(icom, "p_eo_cod_superior", DbType.Int32, _mp_estructura_organizacional.eo_cod_superior);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "CC");
                //CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerId__mp_estructura_organizacional(cls_mp_estructura_organizacional _mp_estructura_organizacional)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_mp_estructura_organizacional.eo_id = Convert.ToInt32(ds.Tables[0].Rows[0]["eo_id"]);
		
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerRegistro__mp_estructura_organizacional(cls_mp_estructura_organizacional _mp_estructura_organizacional)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

				CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.Int32, _mp_estructura_organizacional.eo_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				if (ds.Tables[0].Rows[0]["eo_id"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_id"].ToString().Trim() != "") { _mp_estructura_organizacional.eo_id = Convert.ToInt32(ds.Tables[0].Rows[0]["eo_id"]); }
				if (ds.Tables[0].Rows[0]["eo_pr_id"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_pr_id"].ToString().Trim() != "") { _mp_estructura_organizacional.eo_pr_id = Convert.ToInt32(ds.Tables[0].Rows[0]["eo_pr_id"]); }
				if (ds.Tables[0].Rows[0]["eo_cp_id"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_cp_id"].ToString().Trim() != "") { _mp_estructura_organizacional.eo_cp_id = Convert.ToInt32(ds.Tables[0].Rows[0]["eo_cp_id"]); }
				if (ds.Tables[0].Rows[0]["eo_prog"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_prog"].ToString().Trim() != "") { _mp_estructura_organizacional.eo_prog = Convert.ToInt32(ds.Tables[0].Rows[0]["eo_prog"]); }
				if (ds.Tables[0].Rows[0]["eo_sprog"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_sprog"].ToString().Trim() != "") { _mp_estructura_organizacional.eo_sprog = Convert.ToInt32(ds.Tables[0].Rows[0]["eo_sprog"]); }
				if (ds.Tables[0].Rows[0]["eo_proy"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_proy"].ToString().Trim() != "") { _mp_estructura_organizacional.eo_proy = Convert.ToInt32(ds.Tables[0].Rows[0]["eo_proy"]); }
				if (ds.Tables[0].Rows[0]["eo_obract"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_obract"].ToString().Trim() != "") { _mp_estructura_organizacional.eo_obract = Convert.ToInt32(ds.Tables[0].Rows[0]["eo_obract"]); }
				if (ds.Tables[0].Rows[0]["eo_unidad"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_unidad"].ToString().Trim() != "") { _mp_estructura_organizacional.eo_unidad = Convert.ToInt32(ds.Tables[0].Rows[0]["eo_unidad"]); }
				if (ds.Tables[0].Rows[0]["eo_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_descripcion"].ToString().Trim() != "") { _mp_estructura_organizacional.eo_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["eo_descripcion"]); }
				if (ds.Tables[0].Rows[0]["eo_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_estado"].ToString().Trim() != "") { _mp_estructura_organizacional.eo_estado = Convert.ToString(ds.Tables[0].Rows[0]["eo_estado"]); }
				if (ds.Tables[0].Rows[0]["eo_cod_superior"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_cod_superior"].ToString().Trim() != "") { _mp_estructura_organizacional.eo_cod_superior = Convert.ToInt32(ds.Tables[0].Rows[0]["eo_cod_superior"]); }
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerRegistro(int eo_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.Int32, eo_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                return  CNXSIGRH3.ExecuteDataSet(icom);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerTablaGrilla__mp_estructura_organizacional(string eo_id, 
						string eo_pr_id, 
						string eo_cp_id, 
						string eo_prog, 
						string eo_sprog, 
						string eo_proy, 
						string eo_obract, 
						string eo_unidad, 
						string eo_descripcion, 
						string eo_estado, 
						string eo_cod_superior)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

				if (eo_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.Int32, Convert.ToInt32(eo_id)); }
				if (eo_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_eo_pr_id", DbType.Int32, Convert.ToInt32(eo_pr_id)); }
				if (eo_cp_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_eo_cp_id", DbType.Int32, Convert.ToInt32(eo_cp_id)); }
				if (eo_prog.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_eo_prog", DbType.Int32, Convert.ToInt32(eo_prog)); }
				if (eo_sprog.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_eo_sprog", DbType.Int32, Convert.ToInt32(eo_sprog)); }
				if (eo_proy.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_eo_proy", DbType.Int32, Convert.ToInt32(eo_proy)); }
				if (eo_obract.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_eo_obract", DbType.Int32, Convert.ToInt32(eo_obract)); }
				if (eo_unidad.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_eo_unidad", DbType.Int32, Convert.ToInt32(eo_unidad)); }
				if (eo_descripcion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_eo_descripcion", DbType.String, Convert.ToString(eo_descripcion)); }
				if (eo_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_eo_estado", DbType.String, Convert.ToString(eo_estado)); }
				if (eo_cod_superior.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_eo_cod_superior", DbType.Int32, Convert.ToInt32(eo_cod_superior)); }
 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__mp_estructura_organizacional()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerDescendencia(cls_mp_estructura_organizacional _mp_estructura_organizacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_estructura_organizacional.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerItemsLibres(cls_mp_estructura_organizacional _mp_estructura_organizacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_estructura_organizacional.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_eo_pr_id", DbType.String, _mp_estructura_organizacional.eo_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerListaFiltradoEstOrg(cls_mp_estructura_organizacional _mp_estructura_organizacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_eo_pr_id", DbType.String, _mp_estructura_organizacional.eo_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet BuscarItemUO(cls_mp_estructura_organizacional _mp_estructura_organizacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_eo_pr_id", DbType.String, _mp_estructura_organizacional.eo_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.String, _mp_estructura_organizacional.ca_num_item);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerPOAI(cls_mp_estructura_organizacional _mp_estructura_organizacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.String, _mp_estructura_organizacional.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_eo_pr_id", DbType.String, _mp_estructura_organizacional.eo_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerOrgInicial(cls_mp_estructura_organizacional _mp_estructura_organizacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_eo_pr_id", DbType.String, _mp_estructura_organizacional.eo_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerCpId(cls_mp_estructura_organizacional _mp_estructura_organizacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_estructura_organizacional.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //MP
        public override DataSet ObtenerListaFiltradoEstOrgMP(cls_mp_estructura_organizacional _mp_estructura_organizacional)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESTRUCTURA_ORGANIZACIONAL);

                CNXSIGRH3.AddInParameter(icom, "p_eo_pr_id", DbType.String, _mp_estructura_organizacional.eo_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "CE");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region _MP_TIPO_ITEM
        public override bool Adicionar__mp_tipo_item(cls_mp_tipo_item _mp_tipo_item)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ITEM);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item", DbType.String, _mp_tipo_item.ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ti_descripcion", DbType.String, _mp_tipo_item.ti_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_ti_tipo", DbType.String, _mp_tipo_item.ti_tipo);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item_suplencia", DbType.String, _mp_tipo_item.ti_item_suplencia);
                CNXSIGRH3.AddInParameter(icom, "p_ti_tipo_item_gral", DbType.String, _mp_tipo_item.ti_tipo_item_gral);
                CNXSIGRH3.AddInParameter(icom, "p_ti_tipo_pago", DbType.String, _mp_tipo_item.ti_tipo_pago);
                CNXSIGRH3.AddInParameter(icom, "p_ti_orden", DbType.Int32, _mp_tipo_item.ti_orden);
                //CNXSIGRH3.AddInParameter(icom, "p_ti_control", DbType.Boolean, _mp_tipo_item.ti_control);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__mp_tipo_item(cls_mp_tipo_item _mp_tipo_item)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ITEM);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item", DbType.String, _mp_tipo_item.ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ti_tipo", DbType.String, _mp_tipo_item.ti_tipo);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__mp_tipo_item(cls_mp_tipo_item _mp_tipo_item)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ITEM);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item", DbType.String, _mp_tipo_item.ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ti_descripcion", DbType.String, _mp_tipo_item.ti_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_ti_estado", DbType.String, _mp_tipo_item.ti_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ti_tipo", DbType.String, _mp_tipo_item.ti_tipo);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item_suplencia", DbType.String, _mp_tipo_item.ti_item_suplencia);
                CNXSIGRH3.AddInParameter(icom, "p_ti_orden", DbType.Int32, _mp_tipo_item.ti_orden);
                CNXSIGRH3.AddInParameter(icom, "p_ti_tipo_pago", DbType.String, _mp_tipo_item.ti_tipo_pago);
                CNXSIGRH3.AddInParameter(icom, "p_ti_control", DbType.Boolean, _mp_tipo_item.ti_control);
                CNXSIGRH3.AddInParameter(icom, "p_ti_tipo_item_gral", DbType.String, _mp_tipo_item.ti_tipo_item_gral);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerRegistro__mp_tipo_item(cls_mp_tipo_item _mp_tipo_item)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ITEM);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item", DbType.String, _mp_tipo_item.ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ti_tipo", DbType.String, _mp_tipo_item.ti_tipo);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["ti_item"] != DBNull.Value && ds.Tables[0].Rows[0]["ti_item"].ToString().Trim() != "") { _mp_tipo_item.ti_item = Convert.ToString(ds.Tables[0].Rows[0]["ti_item"]); }
                if (ds.Tables[0].Rows[0]["ti_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["ti_descripcion"].ToString().Trim() != "") { _mp_tipo_item.ti_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["ti_descripcion"]); }
                if (ds.Tables[0].Rows[0]["ti_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["ti_estado"].ToString().Trim() != "") { _mp_tipo_item.ti_estado = Convert.ToString(ds.Tables[0].Rows[0]["ti_estado"]); }
                if (ds.Tables[0].Rows[0]["ti_tipo"] != DBNull.Value && ds.Tables[0].Rows[0]["ti_tipo"].ToString().Trim() != "") { _mp_tipo_item.ti_tipo = Convert.ToString(ds.Tables[0].Rows[0]["ti_tipo"]); }
                if (ds.Tables[0].Rows[0]["ti_item_suplencia"] != DBNull.Value && ds.Tables[0].Rows[0]["ti_item_suplencia"].ToString().Trim() != "") { _mp_tipo_item.ti_item_suplencia = Convert.ToString(ds.Tables[0].Rows[0]["ti_item_suplencia"]); }
                if (ds.Tables[0].Rows[0]["ti_orden"] != DBNull.Value && ds.Tables[0].Rows[0]["ti_orden"].ToString().Trim() != "") { _mp_tipo_item.ti_orden = Convert.ToInt32(ds.Tables[0].Rows[0]["ti_orden"]); }
                if (ds.Tables[0].Rows[0]["ti_tipo_pago"] != DBNull.Value && ds.Tables[0].Rows[0]["ti_tipo_pago"].ToString().Trim() != "") { _mp_tipo_item.ti_tipo_pago = Convert.ToString(ds.Tables[0].Rows[0]["ti_tipo_pago"]); }
                if (ds.Tables[0].Rows[0]["ti_control"] != DBNull.Value && ds.Tables[0].Rows[0]["ti_control"].ToString().Trim() != "") { _mp_tipo_item.ti_control = Convert.ToBoolean(ds.Tables[0].Rows[0]["ti_control"]); }
                if (ds.Tables[0].Rows[0]["ti_tipo_item_gral"] != DBNull.Value && ds.Tables[0].Rows[0]["ti_tipo_item_gral"].ToString().Trim() != "") { _mp_tipo_item.ti_tipo_item_gral = Convert.ToString(ds.Tables[0].Rows[0]["ti_tipo_item_gral"]); }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__mp_tipo_item(
            string ti_item,
            string ti_descripcion,
            string ti_estado,
            string ti_tipo,
            string ti_item_suplencia,
            string ti_orden,
            string ti_tipo_pago,
            string ti_control,
            string ti_tipo_item_gral)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ITEM);

                if (ti_item.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ti_item", DbType.String, Convert.ToString(ti_item)); }
                if (ti_descripcion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ti_descripcion", DbType.String, Convert.ToString(ti_descripcion)); }
                if (ti_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ti_estado", DbType.String, Convert.ToString(ti_estado)); }
                if (ti_tipo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ti_tipo", DbType.String, Convert.ToString(ti_tipo)); }
                if (ti_item_suplencia.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ti_item_suplencia", DbType.String, Convert.ToString(ti_item_suplencia)); }
                if (ti_orden.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ti_orden", DbType.Int32, Convert.ToInt32(ti_orden)); }
                if (ti_tipo_pago.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ti_tipo_pago", DbType.String, Convert.ToString(ti_tipo_pago)); }
                if (ti_control.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ti_control", DbType.Boolean, Convert.ToBoolean(ti_control)); }
                if (ti_tipo_item_gral.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ti_tipo_item_gral", DbType.String, Convert.ToString(ti_tipo_item_gral)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__mp_tipo_item()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ITEM);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de tipo ítem
        public override DataSet ObtenerTablaComboTI__mp_tipo_item()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ITEM);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de ítem suplencia
        public override DataSet ObtenerTablaComboIS__mp_tipo_item()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ITEM);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de tipo ítem general
        public override DataSet ObtenerTablaComboTIG__mp_tipo_item()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ITEM);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Obtiene el orden máximo según el tipo ítem
        public override int ObtenerRegistroOM__mp_tipo_item(cls_mp_tipo_item _mp_tipo_item)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ITEM);
                CNXSIGRH3.AddInParameter(icom, "p_ti_tipo", DbType.String, _mp_tipo_item.ti_tipo);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                int orden = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom));
                return orden;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet TipoItemAltasBajas()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ITEM);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _MP_ESCALA_SALARIAL
        public override bool Adicionar__mp_escala_salarial(cls_mp_escala_salarial _mp_escala_salarial)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESCALA_SALARIAL);

				CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, _mp_escala_salarial.es_id);
				CNXSIGRH3.AddInParameter(icom, "p_es_pr_id", DbType.Int32, _mp_escala_salarial.es_pr_id);
				CNXSIGRH3.AddInParameter(icom, "p_es_ns_id", DbType.Int32, _mp_escala_salarial.es_ns_id);
				CNXSIGRH3.AddInParameter(icom, "p_es_escalafon", DbType.String, _mp_escala_salarial.es_escalafon);
				CNXSIGRH3.AddInParameter(icom, "p_es_descripcion", DbType.String, _mp_escala_salarial.es_descripcion);
				CNXSIGRH3.AddInParameter(icom, "p_es_estado", DbType.String, _mp_escala_salarial.es_estado);
				CNXSIGRH3.AddInParameter(icom, "p_es_ne_id", DbType.Int32, _mp_escala_salarial.es_ne_id);
				CNXSIGRH3.AddInParameter(icom, "p_es_rf_id", DbType.Int32, _mp_escala_salarial.es_rf_id);
				CNXSIGRH3.AddInParameter(icom, "p_es_categoria", DbType.String, _mp_escala_salarial.es_categoria);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Eliminar__mp_escala_salarial(cls_mp_escala_salarial _mp_escala_salarial)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESCALA_SALARIAL);

				CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, _mp_escala_salarial.es_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Actualizar__mp_escala_salarial(cls_mp_escala_salarial _mp_escala_salarial)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESCALA_SALARIAL);

				CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, _mp_escala_salarial.es_id);
				CNXSIGRH3.AddInParameter(icom, "p_es_pr_id", DbType.Int32, _mp_escala_salarial.es_pr_id);
				CNXSIGRH3.AddInParameter(icom, "p_es_ns_id", DbType.Int32, _mp_escala_salarial.es_ns_id);
				CNXSIGRH3.AddInParameter(icom, "p_es_escalafon", DbType.String, _mp_escala_salarial.es_escalafon);
				CNXSIGRH3.AddInParameter(icom, "p_es_descripcion", DbType.String, _mp_escala_salarial.es_descripcion);
				CNXSIGRH3.AddInParameter(icom, "p_es_estado", DbType.String, _mp_escala_salarial.es_estado);
				CNXSIGRH3.AddInParameter(icom, "p_es_ne_id", DbType.Int32, _mp_escala_salarial.es_ne_id);
				CNXSIGRH3.AddInParameter(icom, "p_es_rf_id", DbType.Int32, _mp_escala_salarial.es_rf_id);
				CNXSIGRH3.AddInParameter(icom, "p_es_categoria", DbType.String, _mp_escala_salarial.es_categoria);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerId__mp_escala_salarial(cls_mp_escala_salarial _mp_escala_salarial)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESCALA_SALARIAL);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_mp_escala_salarial.es_id = Convert.ToInt32(ds.Tables[0].Rows[0]["es_id"]);
		
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerRegistro__mp_escala_salarial(cls_mp_escala_salarial _mp_escala_salarial)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESCALA_SALARIAL);

				CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, _mp_escala_salarial.es_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				if (ds.Tables[0].Rows[0]["es_id"] != DBNull.Value && ds.Tables[0].Rows[0]["es_id"].ToString().Trim() != "") { _mp_escala_salarial.es_id = Convert.ToInt32(ds.Tables[0].Rows[0]["es_id"]); }
				if (ds.Tables[0].Rows[0]["es_pr_id"] != DBNull.Value && ds.Tables[0].Rows[0]["es_pr_id"].ToString().Trim() != "") { _mp_escala_salarial.es_pr_id = Convert.ToInt32(ds.Tables[0].Rows[0]["es_pr_id"]); }
				if (ds.Tables[0].Rows[0]["es_ns_id"] != DBNull.Value && ds.Tables[0].Rows[0]["es_ns_id"].ToString().Trim() != "") { _mp_escala_salarial.es_ns_id = Convert.ToInt32(ds.Tables[0].Rows[0]["es_ns_id"]); }
				if (ds.Tables[0].Rows[0]["es_escalafon"] != DBNull.Value && ds.Tables[0].Rows[0]["es_escalafon"].ToString().Trim() != "") { _mp_escala_salarial.es_escalafon = Convert.ToString(ds.Tables[0].Rows[0]["es_escalafon"]); }
				if (ds.Tables[0].Rows[0]["es_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["es_descripcion"].ToString().Trim() != "") { _mp_escala_salarial.es_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["es_descripcion"]); }
				if (ds.Tables[0].Rows[0]["es_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["es_estado"].ToString().Trim() != "") { _mp_escala_salarial.es_estado = Convert.ToString(ds.Tables[0].Rows[0]["es_estado"]); }
				if (ds.Tables[0].Rows[0]["es_ne_id"] != DBNull.Value && ds.Tables[0].Rows[0]["es_ne_id"].ToString().Trim() != "") { _mp_escala_salarial.es_ne_id = Convert.ToInt32(ds.Tables[0].Rows[0]["es_ne_id"]); }
				if (ds.Tables[0].Rows[0]["es_rf_id"] != DBNull.Value && ds.Tables[0].Rows[0]["es_rf_id"].ToString().Trim() != "") { _mp_escala_salarial.es_rf_id = Convert.ToInt32(ds.Tables[0].Rows[0]["es_rf_id"]); }
				if (ds.Tables[0].Rows[0]["es_categoria"] != DBNull.Value && ds.Tables[0].Rows[0]["es_categoria"].ToString().Trim() != "") { _mp_escala_salarial.es_categoria = Convert.ToString(ds.Tables[0].Rows[0]["es_categoria"]); }
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaGrilla__mp_escala_salarial(string es_id, 
						string es_pr_id, 
						string es_ns_id, 
						string es_escalafon, 
						string es_descripcion, 
						string es_estado, 
						string es_ne_id, 
						string es_rf_id, 
						string es_categoria)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESCALA_SALARIAL);

				if (es_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, Convert.ToInt32(es_id)); }
				if (es_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_es_pr_id", DbType.Int32, Convert.ToInt32(es_pr_id)); }
				if (es_ns_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_es_ns_id", DbType.Int32, Convert.ToInt32(es_ns_id)); }
				if (es_escalafon.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_es_escalafon", DbType.String, Convert.ToString(es_escalafon)); }
				if (es_descripcion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_es_descripcion", DbType.String, Convert.ToString(es_descripcion)); }
				if (es_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_es_estado", DbType.String, Convert.ToString(es_estado)); }
				if (es_ne_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_es_ne_id", DbType.Int32, Convert.ToInt32(es_ne_id)); }
				if (es_rf_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_es_rf_id", DbType.Int32, Convert.ToInt32(es_rf_id)); }
				if (es_categoria.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_es_categoria", DbType.String, Convert.ToString(es_categoria)); }
 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__mp_escala_salarial(cls_mp_escala_salarial _mp_escala_salarial)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ESCALA_SALARIAL);

				CNXSIGRH3.AddInParameter(icom, "p_es_pr_id", DbType.String, _mp_escala_salarial.es_pr_id);
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

		#region _ESCALA_PUESTO
		public override bool Adicionar__escala_puesto(cls_escala_puesto _escala_puesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__ESCALA_PUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_epu_es_id", DbType.Int32, _escala_puesto.epu_es_id);
				CNXSIGRH3.AddInParameter(icom, "p_epu_p_id", DbType.Int32, _escala_puesto.epu_p_id);
				CNXSIGRH3.AddInParameter(icom, "p_epu_tipo", DbType.String, _escala_puesto.epu_tipo);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Eliminar__escala_puesto(cls_escala_puesto _escala_puesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__ESCALA_PUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_epu_id", DbType.Int32, _escala_puesto.epu_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Actualizar__escala_puesto(cls_escala_puesto _escala_puesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__ESCALA_PUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_epu_id", DbType.Int32, _escala_puesto.epu_id);
				CNXSIGRH3.AddInParameter(icom, "p_epu_es_id", DbType.Int32, _escala_puesto.epu_es_id);
				CNXSIGRH3.AddInParameter(icom, "p_epu_p_id", DbType.Int32, _escala_puesto.epu_p_id);
				CNXSIGRH3.AddInParameter(icom, "p_epu_tipo", DbType.String, _escala_puesto.epu_tipo);
				CNXSIGRH3.AddInParameter(icom, "p_epu_estado", DbType.String, _escala_puesto.epu_estado);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerId__escala_puesto(cls_escala_puesto _escala_puesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__ESCALA_PUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_escala_puesto.epu_id = Convert.ToInt32(ds.Tables[0].Rows[0]["epu_id"]);
		
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerRegistro__escala_puesto(cls_escala_puesto _escala_puesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__ESCALA_PUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_epu_id", DbType.Int32, _escala_puesto.epu_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				if (ds.Tables[0].Rows[0]["epu_id"] != DBNull.Value && ds.Tables[0].Rows[0]["epu_id"].ToString().Trim() != "") { _escala_puesto.epu_id = Convert.ToInt32(ds.Tables[0].Rows[0]["epu_id"]); }
				if (ds.Tables[0].Rows[0]["epu_es_id"] != DBNull.Value && ds.Tables[0].Rows[0]["epu_es_id"].ToString().Trim() != "") { _escala_puesto.epu_es_id = Convert.ToInt32(ds.Tables[0].Rows[0]["epu_es_id"]); }
				if (ds.Tables[0].Rows[0]["epu_p_id"] != DBNull.Value && ds.Tables[0].Rows[0]["epu_p_id"].ToString().Trim() != "") { _escala_puesto.epu_p_id = Convert.ToInt32(ds.Tables[0].Rows[0]["epu_p_id"]); }
				if (ds.Tables[0].Rows[0]["epu_tipo"] != DBNull.Value && ds.Tables[0].Rows[0]["epu_tipo"].ToString().Trim() != "") { _escala_puesto.epu_tipo = Convert.ToString(ds.Tables[0].Rows[0]["epu_tipo"]); }
				if (ds.Tables[0].Rows[0]["epu_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["epu_estado"].ToString().Trim() != "") { _escala_puesto.epu_estado = Convert.ToString(ds.Tables[0].Rows[0]["epu_estado"]); }
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaGrilla__escala_puesto(string epu_id, 
						string epu_es_id, 
						string epu_p_id, 
						string epu_tipo, 
						string epu_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__ESCALA_PUESTO);

				if (epu_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_epu_id", DbType.Int32, Convert.ToInt32(epu_id)); }
				if (epu_es_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_epu_es_id", DbType.Int32, Convert.ToInt32(epu_es_id)); }
				if (epu_p_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_epu_p_id", DbType.Int32, Convert.ToInt32(epu_p_id)); }
				if (epu_tipo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_epu_tipo", DbType.String, Convert.ToString(epu_tipo)); }
				if (epu_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_epu_estado", DbType.String, Convert.ToString(epu_estado)); }
 
				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__escala_puesto()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__ESCALA_PUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public override DataSet ObtenerGrillaEscalaPuesto(cls_escala_puesto _escala_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__ESCALA_PUESTO);

                CNXSIGRH3.AddInParameter(icom, "p_es_pr_id", DbType.String, _escala_puesto.es_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ValidarEP(cls_escala_puesto _escala_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__ESCALA_PUESTO);

                CNXSIGRH3.AddInParameter(icom, "p_es_pr_id", DbType.String, _escala_puesto.es_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerPuestos(cls_escala_puesto _escala_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__ESCALA_PUESTO);

                CNXSIGRH3.AddInParameter(icom, "p_epu_es_id", DbType.String, _escala_puesto.epu_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _MP_PRESUPUESTO
        public override bool Adicionar__mp_presupuesto(cls_mp_presupuesto _mp_presupuesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_PRESUPUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_pp_cp_id", DbType.Int32, _mp_presupuesto.pp_cp_id);
				CNXSIGRH3.AddInParameter(icom, "p_pp_partida", DbType.Int32, _mp_presupuesto.pp_partida);
				CNXSIGRH3.AddInParameter(icom, "p_pp_entidad_trans", DbType.Int32, _mp_presupuesto.pp_entidad_trans);
				CNXSIGRH3.AddInParameter(icom, "p_pp_monto", DbType.Double, _mp_presupuesto.pp_monto);
				CNXSIGRH3.AddInParameter(icom, "p_pp_saldo", DbType.Double, _mp_presupuesto.pp_saldo);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Eliminar__mp_presupuesto(cls_mp_presupuesto _mp_presupuesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_PRESUPUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_pp_id", DbType.Int32, _mp_presupuesto.pp_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Actualizar__mp_presupuesto(cls_mp_presupuesto _mp_presupuesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_PRESUPUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_pp_id", DbType.Int32, _mp_presupuesto.pp_id);
				CNXSIGRH3.AddInParameter(icom, "p_pp_cp_id", DbType.Int32, _mp_presupuesto.pp_cp_id);
				CNXSIGRH3.AddInParameter(icom, "p_pp_partida", DbType.Int32, _mp_presupuesto.pp_partida);
				CNXSIGRH3.AddInParameter(icom, "p_pp_entidad_trans", DbType.Int32, _mp_presupuesto.pp_entidad_trans);
				CNXSIGRH3.AddInParameter(icom, "p_pp_fecha_calculo", DbType.DateTime, _mp_presupuesto.pp_fecha_calculo);
				CNXSIGRH3.AddInParameter(icom, "p_pp_monto", DbType.Double, _mp_presupuesto.pp_monto);
				CNXSIGRH3.AddInParameter(icom, "p_pp_saldo", DbType.Double, _mp_presupuesto.pp_saldo);
				CNXSIGRH3.AddInParameter(icom, "p_pp_estado", DbType.String, _mp_presupuesto.pp_estado);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerId__mp_presupuesto(cls_mp_presupuesto _mp_presupuesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_PRESUPUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				_mp_presupuesto.pp_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pp_id"]);
		
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool ObtenerRegistro__mp_presupuesto(cls_mp_presupuesto _mp_presupuesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_PRESUPUESTO);

				CNXSIGRH3.AddInParameter(icom, "p_pp_id", DbType.Int32, _mp_presupuesto.pp_id);

				CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

				if (ds.Tables[0].Rows[0]["pp_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pp_id"].ToString().Trim() != "") { _mp_presupuesto.pp_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pp_id"]); }
				if (ds.Tables[0].Rows[0]["pp_cp_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pp_cp_id"].ToString().Trim() != "") { _mp_presupuesto.pp_cp_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pp_cp_id"]); }
				if (ds.Tables[0].Rows[0]["pp_partida"] != DBNull.Value && ds.Tables[0].Rows[0]["pp_partida"].ToString().Trim() != "") { _mp_presupuesto.pp_partida = Convert.ToInt32(ds.Tables[0].Rows[0]["pp_partida"]); }
				if (ds.Tables[0].Rows[0]["pp_entidad_trans"] != DBNull.Value && ds.Tables[0].Rows[0]["pp_entidad_trans"].ToString().Trim() != "") { _mp_presupuesto.pp_entidad_trans = Convert.ToInt32(ds.Tables[0].Rows[0]["pp_entidad_trans"]); }
				if (ds.Tables[0].Rows[0]["pp_fecha_calculo"] != DBNull.Value && ds.Tables[0].Rows[0]["pp_fecha_calculo"].ToString().Trim() != "") { _mp_presupuesto.pp_fecha_calculo = Convert.ToDateTime(ds.Tables[0].Rows[0]["pp_fecha_calculo"]); }
				if (ds.Tables[0].Rows[0]["pp_monto"] != DBNull.Value && ds.Tables[0].Rows[0]["pp_monto"].ToString().Trim() != "") { _mp_presupuesto.pp_monto = Convert.ToDouble(ds.Tables[0].Rows[0]["pp_monto"]); }
				if (ds.Tables[0].Rows[0]["pp_saldo"] != DBNull.Value && ds.Tables[0].Rows[0]["pp_saldo"].ToString().Trim() != "") { _mp_presupuesto.pp_saldo = Convert.ToDouble(ds.Tables[0].Rows[0]["pp_saldo"]); }
				if (ds.Tables[0].Rows[0]["pp_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["pp_estado"].ToString().Trim() != "") { _mp_presupuesto.pp_estado = Convert.ToString(ds.Tables[0].Rows[0]["pp_estado"]); }
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaGrilla__mp_presupuesto(cls_mp_presupuesto _mp_presupuesto)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_PRESUPUESTO);

                CNXSIGRH3.AddInParameter(icom, "p_cp_pr_id", DbType.Int32, _mp_presupuesto.cp_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override DataSet ObtenerTablaCombo__mp_presupuesto()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_PRESUPUESTO);

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

		#region _MP_CATEGORIA_PROGRAMATICA
		public override bool Adicionar__mp_categoria_programatica(cls_mp_categoria_programatica _mp_categoria_programatica)
		{
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CATEGORIA_PROGRAMATICA);
                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.Int32, _mp_categoria_programatica.cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_cp_da", DbType.Int32, _mp_categoria_programatica.cp_da);
                CNXSIGRH3.AddInParameter(icom, "p_cp_da_descripcion", DbType.String, _mp_categoria_programatica.cp_da_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_cp_ue", DbType.Int32, _mp_categoria_programatica.cp_ue);
                CNXSIGRH3.AddInParameter(icom, "p_cp_ue_descripcion", DbType.String, _mp_categoria_programatica.cp_ue_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_cp_programa", DbType.Int32, _mp_categoria_programatica.cp_programa);
                CNXSIGRH3.AddInParameter(icom, "p_cp_proyecto", DbType.String, _mp_categoria_programatica.cp_proyecto);
                CNXSIGRH3.AddInParameter(icom, "p_cp_actividad", DbType.Int32, _mp_categoria_programatica.cp_actividad);
                CNXSIGRH3.AddInParameter(icom, "p_cp_cod_poa", DbType.Int32, _mp_categoria_programatica.cp_cod_poa);
                CNXSIGRH3.AddInParameter(icom, "p_cp_descripcion", DbType.String, _mp_categoria_programatica.cp_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_cp_estado", DbType.String, _mp_categoria_programatica.cp_estado);
                CNXSIGRH3.AddInParameter(icom, "p_cp_tipo_gasto", DbType.String, _mp_categoria_programatica.cp_tipo_gasto);
                CNXSIGRH3.AddInParameter(icom, "p_cp_fuente", DbType.Int32, _mp_categoria_programatica.cp_fuente);
                CNXSIGRH3.AddInParameter(icom, "p_cp_organismo", DbType.Int32, _mp_categoria_programatica.cp_organismo);
                CNXSIGRH3.AddInParameter(icom, "p_cp_pr_id", DbType.Int32, _mp_categoria_programatica.cp_pr_id);
                //CNXSIGRH3.AddInParameter(icom, "p_cp_fecha_modificacion", DbType.DateTime, _mp_categoria_programatica.cp_fecha_modificacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__mp_categoria_programatica(cls_mp_categoria_programatica _mp_categoria_programatica)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CATEGORIA_PROGRAMATICA);
                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.Int32, _mp_categoria_programatica.cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__mp_categoria_programatica(cls_mp_categoria_programatica _mp_categoria_programatica)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CATEGORIA_PROGRAMATICA);
                CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.Int32, _mp_categoria_programatica.cp_id);
                CNXSIGRH3.AddInParameter(icom, "p_cp_da", DbType.Int32, _mp_categoria_programatica.cp_da);
                CNXSIGRH3.AddInParameter(icom, "p_cp_da_descripcion", DbType.String, _mp_categoria_programatica.cp_da_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_cp_ue", DbType.Int32, _mp_categoria_programatica.cp_ue);
                CNXSIGRH3.AddInParameter(icom, "p_cp_ue_descripcion", DbType.String, _mp_categoria_programatica.cp_ue_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_cp_programa", DbType.Int32, _mp_categoria_programatica.cp_programa);
                CNXSIGRH3.AddInParameter(icom, "p_cp_proyecto", DbType.Int32, _mp_categoria_programatica.cp_proyecto);
                CNXSIGRH3.AddInParameter(icom, "p_cp_actividad", DbType.Int32, _mp_categoria_programatica.cp_actividad);
                CNXSIGRH3.AddInParameter(icom, "p_cp_cod_poa", DbType.Int32, _mp_categoria_programatica.cp_cod_poa);
                CNXSIGRH3.AddInParameter(icom, "p_cp_descripcion", DbType.String, _mp_categoria_programatica.cp_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_cp_estado", DbType.String, _mp_categoria_programatica.cp_estado);
                CNXSIGRH3.AddInParameter(icom, "p_cp_tipo_gasto", DbType.String, _mp_categoria_programatica.cp_tipo_gasto);
                CNXSIGRH3.AddInParameter(icom, "p_cp_fuente", DbType.Int32, _mp_categoria_programatica.cp_fuente);
                CNXSIGRH3.AddInParameter(icom, "p_cp_organismo", DbType.Int32, _mp_categoria_programatica.cp_organismo);
                CNXSIGRH3.AddInParameter(icom, "p_cp_pr_id", DbType.Int32, _mp_categoria_programatica.cp_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_cp_fecha_modificacion", DbType.DateTime, _mp_categoria_programatica.cp_fecha_modificacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerId__mp_categoria_programatica(cls_mp_categoria_programatica _mp_categoria_programatica)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CATEGORIA_PROGRAMATICA);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                _mp_categoria_programatica.cp_id = Convert.ToInt32(ds.Tables[0].Rows[0]["cp_id"]);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__mp_categoria_programatica(cls_mp_categoria_programatica _mp_categoria_programatica)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CATEGORIA_PROGRAMATICA);
                CNXSIGRH3.AddInParameter(icom, "p_cp_da", DbType.Int32, _mp_categoria_programatica.cp_da);
                CNXSIGRH3.AddInParameter(icom, "p_cp_ue", DbType.Int32, _mp_categoria_programatica.cp_ue);
                CNXSIGRH3.AddInParameter(icom, "p_cp_programa", DbType.Int32, _mp_categoria_programatica.cp_programa);
                CNXSIGRH3.AddInParameter(icom, "p_cp_proyecto", DbType.Int32, _mp_categoria_programatica.cp_proyecto);
                CNXSIGRH3.AddInParameter(icom, "p_cp_actividad", DbType.Int32, _mp_categoria_programatica.cp_actividad);
                CNXSIGRH3.AddInParameter(icom, "p_cp_fuente", DbType.Int32, _mp_categoria_programatica.cp_fuente);
                CNXSIGRH3.AddInParameter(icom, "p_cp_organismo", DbType.Int32, _mp_categoria_programatica.cp_organismo);
                CNXSIGRH3.AddInParameter(icom, "p_cp_pr_id", DbType.Int32, _mp_categoria_programatica.cp_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__mp_categoria_programatica(
            string cp_id,
            string cp_da,
            string cp_da_descripcion,
            string cp_ue,
            string cp_ue_descripcion,
            string cp_programa,
            string cp_proyecto,
            string cp_actividad,
            string cp_cod_poa,
            string cp_descripcion,
            string cp_estado,
            string cp_tipo_gasto,
            string cp_fuente,
            string cp_organismo,
            string cp_pr_id,
            string cp_fecha_modificacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CATEGORIA_PROGRAMATICA);

                if (cp_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_id", DbType.Int32, Convert.ToInt32(cp_id)); }
                if (cp_da.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_da", DbType.Int32, Convert.ToInt32(cp_da)); }
                if (cp_da_descripcion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_da_descripcion", DbType.String, Convert.ToString(cp_da_descripcion)); }
                if (cp_ue.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_ue", DbType.Int32, Convert.ToInt32(cp_ue)); }
                if (cp_ue_descripcion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_ue_descripcion", DbType.String, Convert.ToString(cp_ue_descripcion)); }
                if (cp_programa.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_programa", DbType.Int32, Convert.ToInt32(cp_programa)); }
                if (cp_proyecto.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_proyecto", DbType.Int32, Convert.ToInt32(cp_proyecto)); }
                if (cp_actividad.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_actividad", DbType.Int32, Convert.ToInt32(cp_actividad)); }
                if (cp_cod_poa.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_cod_poa", DbType.Int32, Convert.ToInt32(cp_cod_poa)); }
                if (cp_descripcion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_descripcion", DbType.String, Convert.ToString(cp_descripcion)); }
                if (cp_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_estado", DbType.String, Convert.ToString(cp_estado)); }
                if (cp_tipo_gasto.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_tipo_gasto", DbType.String, Convert.ToString(cp_tipo_gasto)); }
                if (cp_fuente.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_fuente", DbType.Int32, Convert.ToInt32(cp_fuente)); }
                if (cp_organismo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_organismo", DbType.Int32, Convert.ToInt32(cp_organismo)); }
                if (cp_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_pr_id", DbType.Int32, Convert.ToInt32(cp_pr_id)); }
                if (cp_fecha_modificacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_fecha_modificacion", DbType.DateTime, Convert.ToDateTime(cp_fecha_modificacion)); }

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__mp_categoria_programatica()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CATEGORIA_PROGRAMATICA);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (KCPB) Listado de UE vigentes
        public override DataSet ObtenerTablaComboUE__mp_categoria_programatica(cls_mp_categoria_programatica _mp_categoria_programatica)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CATEGORIA_PROGRAMATICA);
                CNXSIGRH3.AddInParameter(icom, "p_cp_pr_id", DbType.Int32, _mp_categoria_programatica.cp_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override string ObtenerTipoGasto(int eo_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CATEGORIA_PROGRAMATICA);
                CNXSIGRH3.AddInParameter(icom, "p_cp_pr_id", DbType.Int32, eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "");
                return CNXSIGRH3.ExecuteDataSet(icom).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _MP_CARGO_PUESTO
        public override bool Adicionar__mp_cargo_puesto(cls_mp_cargo_puesto _mp_cargo_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO_PUESTO);
                CNXSIGRH3.AddInParameter(icom, "p_cap_ca_id", DbType.Int32, _mp_cargo_puesto.cap_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_cap_p_id", DbType.Int32, _mp_cargo_puesto.cap_p_id);
                //CNXSIGRH3.AddInParameter(icom, "p_cap_estado", DbType.String, _mp_cargo_puesto.cap_estado);
                //CNXSIGRH3.AddInParameter(icom, "p_cap_fecha_modificacion", DbType.DateTime, _mp_cargo_puesto.cap_fecha_modificacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__mp_cargo_puesto(cls_mp_cargo_puesto _mp_cargo_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO_PUESTO);
                CNXSIGRH3.AddInParameter(icom, "p_cap_ca_id", DbType.Int32, _mp_cargo_puesto.cap_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__mp_cargo_puesto(cls_mp_cargo_puesto _mp_cargo_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO_PUESTO);
                CNXSIGRH3.AddInParameter(icom, "p_cap_ca_id", DbType.Int32, _mp_cargo_puesto.cap_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_cap_p_id", DbType.Int32, _mp_cargo_puesto.cap_p_id);
                CNXSIGRH3.AddInParameter(icom, "p_cap_estado", DbType.String, _mp_cargo_puesto.cap_estado);
                CNXSIGRH3.AddInParameter(icom, "p_cap_fecha_modificacion", DbType.DateTime, _mp_cargo_puesto.cap_fecha_modificacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerId__mp_cargo_puesto(cls_mp_cargo_puesto _mp_cargo_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO_PUESTO);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                _mp_cargo_puesto.cap_ca_id = Convert.ToInt32(ds.Tables[0].Rows[0]["cap_ca_id"]);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__mp_cargo_puesto(cls_mp_cargo_puesto _mp_cargo_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO_PUESTO);
                CNXSIGRH3.AddInParameter(icom, "p_cap_ca_id", DbType.Int32, _mp_cargo_puesto.cap_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__mp_cargo_puesto(
            string cap_ca_id,
            string cap_p_id,
            string cap_estado,
            string cap_fecha_modificacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO_PUESTO);

                if (cap_ca_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cap_ca_id", DbType.Int32, Convert.ToInt32(cap_ca_id)); }
                if (cap_p_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cap_p_id", DbType.Int32, Convert.ToInt32(cap_p_id)); }
                if (cap_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cap_estado", DbType.String, Convert.ToString(cap_estado)); }
                if (cap_fecha_modificacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cap_fecha_modificacion", DbType.DateTime, Convert.ToDateTime(cap_fecha_modificacion)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__mp_cargo_puesto()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO_PUESTO);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

		#region _PUESTOS
		public override DataSet Adicionar__puestos(cls_puestos _puestos)
		{
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PUESTOS);
                CNXSIGRH3.AddInParameter(icom, "p_p_descripcion", DbType.String, _puestos.p_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__puestos(cls_puestos _puestos)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PUESTOS);
                CNXSIGRH3.AddInParameter(icom, "p_p_id", DbType.Int32, _puestos.p_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__puestos(cls_puestos _puestos)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PUESTOS);
                CNXSIGRH3.AddInParameter(icom, "p_p_id", DbType.Int32, _puestos.p_id);
                CNXSIGRH3.AddInParameter(icom, "p_p_descripcion", DbType.String, _puestos.p_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_p_estado", DbType.String, _puestos.p_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerId__puestos(cls_puestos _puestos)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PUESTOS);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                _puestos.p_id = Convert.ToInt32(ds.Tables[0].Rows[0]["p_id"]);

                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__puestos(cls_puestos _puestos)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PUESTOS);
                CNXSIGRH3.AddInParameter(icom, "p_p_id", DbType.Int32, _puestos.p_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__puestos(
            string p_id,
            string p_descripcion,
            string p_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PUESTOS);

                if (p_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_p_id", DbType.Int32, Convert.ToInt32(p_id)); }
                if (p_descripcion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_p_descripcion", DbType.String, Convert.ToString(p_descripcion)); }
                if (p_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_p_estado", DbType.String, Convert.ToString(p_estado)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__puestos()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PUESTOS);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerPuestosVigentes()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PUESTOS);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _SITUACION_PERSONA
        public override DataSet Adicionar__situacion_persona(cls_situacion_persona _situacion_persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__SITUACION_PERSONA);

                CNXSIGRH3.AddInParameter(icom, "p_st_per_id", DbType.Int32, _situacion_persona.st_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_st_tipo_situacion", DbType.String, _situacion_persona.st_tipo_situacion);
                CNXSIGRH3.AddInParameter(icom, "p_st_fecha_inicio", DbType.String, _situacion_persona.st_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_st_fecha_fin", DbType.String, _situacion_persona.st_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_st_estado", DbType.String, _situacion_persona.st_estado);
                CNXSIGRH3.AddInParameter(icom, "p_st_usuario_creacion", DbType.Int32, _situacion_persona.st_usuario_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ValidarSituacion(cls_situacion_persona _situacion_persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__SITUACION_PERSONA);

                CNXSIGRH3.AddInParameter(icom, "p_st_per_id", DbType.Int32, _situacion_persona.st_per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar__situacion_persona(cls_situacion_persona _situacion_persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__SITUACION_PERSONA);

                CNXSIGRH3.AddInParameter(icom, "p_st_id", DbType.Int32, _situacion_persona.st_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Actualizar__situacion_persona(cls_situacion_persona _situacion_persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__SITUACION_PERSONA);

                CNXSIGRH3.AddInParameter(icom, "p_st_id", DbType.Int32, _situacion_persona.st_id);
                CNXSIGRH3.AddInParameter(icom, "p_st_per_id", DbType.Int32, _situacion_persona.st_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_st_tipo_situacion", DbType.String, _situacion_persona.st_tipo_situacion);
                CNXSIGRH3.AddInParameter(icom, "p_st_fecha_inicio", DbType.DateTime, _situacion_persona.st_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_st_fecha_fin", DbType.DateTime, _situacion_persona.st_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_st_estado", DbType.String, _situacion_persona.st_estado);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId__situacion_persona(cls_situacion_persona _situacion_persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__SITUACION_PERSONA);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                _situacion_persona.st_id = Convert.ToInt32(ds.Tables[0].Rows[0]["st_id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerRegistro__situacion_persona(cls_situacion_persona _situacion_persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__SITUACION_PERSONA);

                CNXSIGRH3.AddInParameter(icom, "p_st_id", DbType.Int32, _situacion_persona.st_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["st_id"] != DBNull.Value && ds.Tables[0].Rows[0]["st_id"].ToString().Trim() != "") { _situacion_persona.st_id = Convert.ToInt32(ds.Tables[0].Rows[0]["st_id"]); }
                if (ds.Tables[0].Rows[0]["st_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["st_per_id"].ToString().Trim() != "") { _situacion_persona.st_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["st_per_id"]); }
                if (ds.Tables[0].Rows[0]["st_tipo_situacion"] != DBNull.Value && ds.Tables[0].Rows[0]["st_tipo_situacion"].ToString().Trim() != "") { _situacion_persona.st_tipo_situacion = Convert.ToString(ds.Tables[0].Rows[0]["st_tipo_situacion"]); }
                if (ds.Tables[0].Rows[0]["st_fecha_inicio"] != DBNull.Value && ds.Tables[0].Rows[0]["st_fecha_inicio"].ToString().Trim() != "") { _situacion_persona.st_fecha_inicio = Convert.ToString(ds.Tables[0].Rows[0]["st_fecha_inicio"]); }
                if (ds.Tables[0].Rows[0]["st_fecha_fin"] != DBNull.Value && ds.Tables[0].Rows[0]["st_fecha_fin"].ToString().Trim() != "") { _situacion_persona.st_fecha_fin = Convert.ToString(ds.Tables[0].Rows[0]["st_fecha_fin"]); }
                if (ds.Tables[0].Rows[0]["st_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["st_estado"].ToString().Trim() != "") { _situacion_persona.st_estado = Convert.ToString(ds.Tables[0].Rows[0]["st_estado"]); }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaGrilla__situacion_persona(cls_situacion_persona _situacion_persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__SITUACION_PERSONA);

                CNXSIGRH3.AddInParameter(icom, "p_st_per_id", DbType.Int32, Convert.ToInt32(_situacion_persona.st_per_id));

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo__situacion_persona()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__SITUACION_PERSONA);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerListaSituacionPer()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__SITUACION_PERSONA);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _MP_ASIGNACION_COM_INT
        public override bool Adicionar__mp_asignacion_com_int(cls_mp_asignacion_com_int _mp_asignacion_com_int)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_COM_INT);

                CNXSIGRH3.AddInParameter(icom, "p_ci_per_id", DbType.Int32, _mp_asignacion_com_int.ci_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_ca_id", DbType.Int32, _mp_asignacion_com_int.ci_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_inicio", DbType.DateTime, _mp_asignacion_com_int.ci_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_fin", DbType.DateTime, _mp_asignacion_com_int.ci_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_ci_estado", DbType.String, _mp_asignacion_com_int.ci_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ci_tipo_mov", DbType.String, _mp_asignacion_com_int.ci_tipo_mov);
                CNXSIGRH3.AddInParameter(icom, "p_ci_tipo_reg", DbType.String, _mp_asignacion_com_int.ci_tipo_reg);
                CNXSIGRH3.AddInParameter(icom, "p_ci_pr_id", DbType.Int32, _mp_asignacion_com_int.ci_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_tipo_mov_baja", DbType.String, _mp_asignacion_com_int.ci_tipo_mov_baja);
                CNXSIGRH3.AddInParameter(icom, "p_ci_ca_id_ant", DbType.Int32, _mp_asignacion_com_int.ci_ca_id_ant);
                CNXSIGRH3.AddInParameter(icom, "p_ci_ca_id_n", DbType.Int32, _mp_asignacion_com_int.ci_ca_id_n);
                CNXSIGRH3.AddInParameter(icom, "p_ci_es_id_n", DbType.Int32, _mp_asignacion_com_int.ci_es_id_n);
                CNXSIGRH3.AddInParameter(icom, "p_ci_eo_id_n", DbType.Int32, _mp_asignacion_com_int.ci_eo_id_n);
                CNXSIGRH3.AddInParameter(icom, "p_ci_per_id_interinato", DbType.Int32, _mp_asignacion_com_int.ci_per_id_interinato);
                CNXSIGRH3.AddInParameter(icom, "p_ci_usuario_creacion", DbType.Int32, _mp_asignacion_com_int.ci_usuario_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar__mp_asignacion_com_int(cls_mp_asignacion_com_int _mp_asignacion_com_int)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_COM_INT);

                CNXSIGRH3.AddInParameter(icom, "p_ci_per_id", DbType.Int32, _mp_asignacion_com_int.ci_per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet FinalizarAsignacion(cls_mp_asignacion_com_int _mp_asignacion_com_int)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_COM_INT);

                CNXSIGRH3.AddInParameter(icom, "p_ci_id", DbType.Int32, _mp_asignacion_com_int.ci_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_per_id", DbType.Int32, _mp_asignacion_com_int.ci_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_fin", DbType.String, _mp_asignacion_com_int.ci_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U1");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Actualizar__mp_asignacion_com_int(cls_mp_asignacion_com_int _mp_asignacion_com_int)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_COM_INT);

                CNXSIGRH3.AddInParameter(icom, "p_ci_id", DbType.Int32, _mp_asignacion_com_int.ci_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_per_id", DbType.Int32, _mp_asignacion_com_int.ci_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_ca_id", DbType.Int32, _mp_asignacion_com_int.ci_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_secuencial", DbType.Int32, _mp_asignacion_com_int.ci_secuencial);
                CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_inicio", DbType.DateTime, _mp_asignacion_com_int.ci_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_fin", DbType.DateTime, _mp_asignacion_com_int.ci_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_ci_estado", DbType.String, _mp_asignacion_com_int.ci_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_creacion", DbType.DateTime, _mp_asignacion_com_int.ci_fecha_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_ci_tipo_mov", DbType.String, _mp_asignacion_com_int.ci_tipo_mov);
                CNXSIGRH3.AddInParameter(icom, "p_ci_tipo_reg", DbType.String, _mp_asignacion_com_int.ci_tipo_reg);
                CNXSIGRH3.AddInParameter(icom, "p_ci_verificado", DbType.String, _mp_asignacion_com_int.ci_verificado);
                CNXSIGRH3.AddInParameter(icom, "p_ci_pr_id", DbType.Int32, _mp_asignacion_com_int.ci_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_tipo_mov_baja", DbType.String, _mp_asignacion_com_int.ci_tipo_mov_baja);
                CNXSIGRH3.AddInParameter(icom, "p_ci_ca_id_ant", DbType.Int32, _mp_asignacion_com_int.ci_ca_id_ant);
                CNXSIGRH3.AddInParameter(icom, "p_ci_secuencial_ant", DbType.Int32, _mp_asignacion_com_int.ci_secuencial_ant);
                CNXSIGRH3.AddInParameter(icom, "p_ci_nominal", DbType.String, _mp_asignacion_com_int.ci_nominal);
                CNXSIGRH3.AddInParameter(icom, "p_ci_ca_id_n", DbType.Int32, _mp_asignacion_com_int.ci_ca_id_n);
                CNXSIGRH3.AddInParameter(icom, "p_ci_es_id_n", DbType.Int32, _mp_asignacion_com_int.ci_es_id_n);
                CNXSIGRH3.AddInParameter(icom, "p_ci_eo_id_n", DbType.Int32, _mp_asignacion_com_int.ci_eo_id_n);
                CNXSIGRH3.AddInParameter(icom, "p_ci_per_id_interinato", DbType.Int32, _mp_asignacion_com_int.ci_per_id_interinato);
                CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_conclusion", DbType.DateTime, _mp_asignacion_com_int.ci_fecha_conclusion);
                CNXSIGRH3.AddInParameter(icom, "p_ci_cod_valida", DbType.Int32, _mp_asignacion_com_int.ci_cod_valida);
                CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_valida", DbType.DateTime, _mp_asignacion_com_int.ci_fecha_valida);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId__mp_asignacion_com_int(cls_mp_asignacion_com_int _mp_asignacion_com_int)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_COM_INT);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                _mp_asignacion_com_int.ci_id = Convert.ToInt32(ds.Tables[0].Rows[0]["ci_id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerRegistro__mp_asignacion_com_int(cls_mp_asignacion_com_int _mp_asignacion_com_int)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_COM_INT);

                CNXSIGRH3.AddInParameter(icom, "p_ci_per_id", DbType.Int32, _mp_asignacion_com_int.ci_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_ca_id", DbType.Int32, _mp_asignacion_com_int.ci_ca_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDatosFunCI(cls_mp_asignacion_com_int _mp_asignacion_com_int)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_COM_INT);

                CNXSIGRH3.AddInParameter(icom, "p_ci_per_id", DbType.Int32, _mp_asignacion_com_int.ci_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_pr_id", DbType.Int32, _mp_asignacion_com_int.ci_pr_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaGrilla__mp_asignacion_com_int(string ci_id,
                        string ci_per_id,
                        string ci_ca_id,
                        string ci_secuencial,
                        string ci_fecha_inicio,
                        string ci_fecha_fin,
                        string ci_estado,
                        string ci_fecha_creacion,
                        string ci_tipo_mov,
                        string ci_tipo_reg,
                        string ci_verificado,
                        string ci_pr_id,
                        string ci_tipo_mov_baja,
                        string ci_ca_id_ant,
                        string ci_secuencial_ant,
                        string ci_nominal,
                        string ci_ca_id_n,
                        string ci_es_id_n,
                        string ci_eo_id_n,
                        string ci_per_id_interinato,
                        string ci_fecha_conclusion,
                        string ci_cod_valida,
                        string ci_fecha_valida)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_COM_INT);

                if (ci_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_id", DbType.Int32, Convert.ToInt32(ci_id)); }
                if (ci_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_per_id", DbType.Int32, Convert.ToInt32(ci_per_id)); }
                if (ci_ca_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_ca_id", DbType.Int32, Convert.ToInt32(ci_ca_id)); }
                if (ci_secuencial.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_secuencial", DbType.Int32, Convert.ToInt32(ci_secuencial)); }
                if (ci_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_inicio", DbType.DateTime, Convert.ToDateTime(ci_fecha_inicio)); }
                if (ci_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_fin", DbType.DateTime, Convert.ToDateTime(ci_fecha_fin)); }
                if (ci_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_estado", DbType.String, Convert.ToString(ci_estado)); }
                if (ci_fecha_creacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_creacion", DbType.DateTime, Convert.ToDateTime(ci_fecha_creacion)); }
                if (ci_tipo_mov.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_tipo_mov", DbType.String, Convert.ToString(ci_tipo_mov)); }
                if (ci_tipo_reg.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_tipo_reg", DbType.String, Convert.ToString(ci_tipo_reg)); }
                if (ci_verificado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_verificado", DbType.String, Convert.ToString(ci_verificado)); }
                if (ci_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_pr_id", DbType.Int32, Convert.ToInt32(ci_pr_id)); }
                if (ci_tipo_mov_baja.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_tipo_mov_baja", DbType.String, Convert.ToString(ci_tipo_mov_baja)); }
                if (ci_ca_id_ant.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_ca_id_ant", DbType.Int32, Convert.ToInt32(ci_ca_id_ant)); }
                if (ci_secuencial_ant.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_secuencial_ant", DbType.Int32, Convert.ToInt32(ci_secuencial_ant)); }
                if (ci_nominal.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_nominal", DbType.String, Convert.ToString(ci_nominal)); }
                if (ci_ca_id_n.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_ca_id_n", DbType.Int32, Convert.ToInt32(ci_ca_id_n)); }
                if (ci_es_id_n.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_es_id_n", DbType.Int32, Convert.ToInt32(ci_es_id_n)); }
                if (ci_eo_id_n.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_eo_id_n", DbType.Int32, Convert.ToInt32(ci_eo_id_n)); }
                if (ci_per_id_interinato.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_per_id_interinato", DbType.Int32, Convert.ToInt32(ci_per_id_interinato)); }
                if (ci_fecha_conclusion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_conclusion", DbType.DateTime, Convert.ToDateTime(ci_fecha_conclusion)); }
                if (ci_cod_valida.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_cod_valida", DbType.Int32, Convert.ToInt32(ci_cod_valida)); }
                if (ci_fecha_valida.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_valida", DbType.DateTime, Convert.ToDateTime(ci_fecha_valida)); }

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo__mp_asignacion_com_int()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION_COM_INT);

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

        #region _MP_SEGUIMIENTO_MEMORANDUM
        public override bool Adicionar__mp_seguimiento_memorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_mh_qr", DbType.String, _mp_seguimiento_memorandum.mh_qr);
                CNXSIGRH3.AddInParameter(icom, "p_mh_per_id", DbType.Int32, _mp_seguimiento_memorandum.mh_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_mh_te_id", DbType.Int32, _mp_seguimiento_memorandum.mh_te_id);
                CNXSIGRH3.AddInParameter(icom, "p_mh_nro_memo", DbType.Int32, _mp_seguimiento_memorandum.mh_nro_memo);
                CNXSIGRH3.AddInParameter(icom, "p_mh_contenido", DbType.String, _mp_seguimiento_memorandum.mh_contenido);
                CNXSIGRH3.AddInParameter(icom, "p_mh_usuario_creacion", DbType.Int32, _mp_seguimiento_memorandum.mh_usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_mh_pr_id", DbType.Int32, _mp_seguimiento_memorandum.mh_pr_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet AdicionarTenorFunMV(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_mv_per_id", DbType.Int32, _mp_seguimiento_memorandum.mv_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_mv_datos", DbType.String, _mp_seguimiento_memorandum.mv_datos);
                CNXSIGRH3.AddInParameter(icom, "p_mv_usuario_creacion", DbType.Int32, _mp_seguimiento_memorandum.mv_usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_mv_pr_id", DbType.Int32, _mp_seguimiento_memorandum.mv_pr_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Eliminar__mp_seguimiento_memorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_mh_id", DbType.Int32, _mp_seguimiento_memorandum.mh_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarMemoAsignado(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_mv_id", DbType.Int32, _mp_seguimiento_memorandum.mv_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Actualizar__mp_seguimiento_memorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_mh_id", DbType.Int32, _mp_seguimiento_memorandum.mh_id);
                CNXSIGRH3.AddInParameter(icom, "p_mh_qr", DbType.String, _mp_seguimiento_memorandum.mh_qr);
                CNXSIGRH3.AddInParameter(icom, "p_mh_per_id", DbType.Int32, _mp_seguimiento_memorandum.mh_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_mh_te_id", DbType.Int32, _mp_seguimiento_memorandum.mh_te_id);
                CNXSIGRH3.AddInParameter(icom, "p_mh_usuario_creacion", DbType.Int32, _mp_seguimiento_memorandum.mh_usuario_creacion);
                //CNXSIGRH3.AddInParameter(icom, "p_tf_fecha_creacion", DbType.DateTime, _mp_seguimiento_memorandum.tf_fecha_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId__mp_seguimiento_memorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                _mp_seguimiento_memorandum.mh_id = Convert.ToInt32(ds.Tables[0].Rows[0]["mh_id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerRegistro__mp_seguimiento_memorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_mh_id", DbType.Int32, _mp_seguimiento_memorandum.mh_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["mh_id"] != DBNull.Value && ds.Tables[0].Rows[0]["mh_id"].ToString().Trim() != "") { _mp_seguimiento_memorandum.mh_id = Convert.ToInt32(ds.Tables[0].Rows[0]["mh_id"]); }
                if (ds.Tables[0].Rows[0]["mh_qr"] != DBNull.Value && ds.Tables[0].Rows[0]["mh_qr"].ToString().Trim() != "") { _mp_seguimiento_memorandum.mh_qr = Convert.ToString(ds.Tables[0].Rows[0]["mh_qr"]); }
                if (ds.Tables[0].Rows[0]["mh_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["mh_per_id"].ToString().Trim() != "") { _mp_seguimiento_memorandum.mh_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["mh_per_id"]); }
                if (ds.Tables[0].Rows[0]["mh_te_id"] != DBNull.Value && ds.Tables[0].Rows[0]["mh_te_id"].ToString().Trim() != "") { _mp_seguimiento_memorandum.mh_te_id = Convert.ToInt32(ds.Tables[0].Rows[0]["mh_te_id"]); }
                if (ds.Tables[0].Rows[0]["mh_usuario_creacion"] != DBNull.Value && ds.Tables[0].Rows[0]["mh_usuario_creacion"].ToString().Trim() != "") { _mp_seguimiento_memorandum.mh_usuario_creacion = Convert.ToInt32(ds.Tables[0].Rows[0]["mh_usuario_creacion"]); }
                //if (ds.Tables[0].Rows[0]["tf_fecha_creacion"] != DBNull.Value && ds.Tables[0].Rows[0]["tf_fecha_creacion"].ToString().Trim() != "") { _mp_seguimiento_memorandum.tf_fecha_creacion = Convert.ToDateTime(ds.Tables[0].Rows[0]["tf_fecha_creacion"]); }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo__mp_seguimiento_memorandum()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerTenorFuncionario(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_mh_qr", DbType.String, _mp_seguimiento_memorandum.mh_qr);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerSeguimientoMemorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_sm_qr", DbType.String, _mp_seguimiento_memorandum.sm_qr);
                CNXSIGRH3.AddInParameter(icom, "p_sm_validado_por", DbType.String, _mp_seguimiento_memorandum.sm_usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool AdicionarSeguimientoMemorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_sm_qr", DbType.String, _mp_seguimiento_memorandum.sm_qr);
                CNXSIGRH3.AddInParameter(icom, "p_sm_validado_por", DbType.Int32, _mp_seguimiento_memorandum.sm_validado_por);
                CNXSIGRH3.AddInParameter(icom, "p_sm_usuario_creacion", DbType.Int32, _mp_seguimiento_memorandum.sm_usuario_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrillaSM(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_sm_qr", DbType.String, _mp_seguimiento_memorandum.sm_qr);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrillaMemosAsig(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_mh_per_id", DbType.String, _mp_seguimiento_memorandum.mh_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //(JQC)
        public override DataSet listaFiltradoTipoValidacion()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet obtenerDatosInformacionAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarValidacionAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                //CNXSIGRH3.AddInParameter(icom, "p_his_usuario_creacion", DbType.Int32, _mp_seguimiento_memorandum.usuario_creacion);
                //CNXSIGRH3.AddInParameter(icom, "p_as_fecha_inicio", DbType.String, _mp_seguimiento_memorandum.as_fecha_inicio);
                //CNXSIGRH3.AddInParameter(icom, "p_as_fecha_fin", DbType.String, _mp_seguimiento_memorandum.as_fecha_fin);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerDatosInformacionBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerDatosInformacionRPT(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerDatosInformacionAltasCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarValidacionAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_ci_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                //CNXSIGRH3.AddInParameter(icom, "p_his_usuario_creacion", DbType.Int32, _mp_seguimiento_memorandum.usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_inicio", DbType.String, _mp_seguimiento_memorandum.as_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_fin", DbType.String, _mp_seguimiento_memorandum.as_fecha_fin);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerDatosInformacionBajasCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerDatosInformacionMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarValidacionMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_mv_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_mv_per_id", DbType.Int32, _mp_seguimiento_memorandum.mh_per_id);
                //CNXSIGRH3.AddInParameter(icom, "p_his_usuario_creacion", DbType.Int32, _mp_seguimiento_memorandum.usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_mv_fecha_inicio", DbType.String, _mp_seguimiento_memorandum.as_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_mv_fecha_fin", DbType.String, _mp_seguimiento_memorandum.as_fecha_fin);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaAltaRector(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C55");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet obtenerGrillaValidaAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerCantidadValidaAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C17");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaValidaBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C12");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerCantidadValidaBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C18");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaValidaRPT(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C13");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerCantidadValidaRPT(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C19");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaValidaAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.String, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerCantidadValidaAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C20");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaValidaBajaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C15");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerCantidadValidaBajaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C21");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaValidaMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C16");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerCantidadValidaMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C22");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarRegistroValidacion(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_seguimiento_memorandum.mh_per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarRegistroValidacionCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_ci_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_per_id", DbType.Int32, _mp_seguimiento_memorandum.mh_per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarRegistroValidacionMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_mh_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_mh_per_id", DbType.Int32, _mp_seguimiento_memorandum.mh_per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ModificarValidacionAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_seguimiento_memorandum.mh_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_fecha_inicio", DbType.DateTime,  Convert.ToDateTime(_mp_seguimiento_memorandum.as_fecha_inicio));
                if (_mp_seguimiento_memorandum.as_fecha_fin!=null)
                    CNXSIGRH3.AddInParameter(icom, "p_as_fecha_fin", DbType.DateTime, Convert.ToDateTime(_mp_seguimiento_memorandum.as_fecha_fin));

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U4");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ModificarValidacionAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_ci_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_per_id", DbType.Int32, _mp_seguimiento_memorandum.mh_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_inicio", DbType.String, _mp_seguimiento_memorandum.as_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_ci_fecha_fin", DbType.String, _mp_seguimiento_memorandum.as_fecha_fin);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ModificarValidacionMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_mh_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_mh_per_id", DbType.Int32, _mp_seguimiento_memorandum.mh_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_tf_fecha_inicio", DbType.String, _mp_seguimiento_memorandum.as_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_tf_fecha_fin", DbType.String, _mp_seguimiento_memorandum.as_fecha_fin);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U6");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerCantidadReprobarAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C23");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerCantidadReprobarBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C24");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerCantidadReprobarRPT(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C25");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerCantidadReprobarAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C26");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerCantidadReprobarBajaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C27");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerCantidadReprobarMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C28");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerInformacionReprobarAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_seguimiento_memorandum.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C29");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerInformacionReprobarBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_seguimiento_memorandum.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C30");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerInformacionReprobarRPT(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_seguimiento_memorandum.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C31");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerInformacionReprobarAltasCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_seguimiento_memorandum.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C32");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerInformacionReprobarBajasCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_seguimiento_memorandum.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C33");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerInformacionReprobarMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_seguimiento_memorandum.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C34");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaReprobarAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C35");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaReprobarBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C36");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaReprobarRPT(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C37");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaReprobarAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C38");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaReprobarBajaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C39");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerGrillaReprobarMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C40");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarReprobacionAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                //CNXSIGRH3.AddInParameter(icom, "p_his_usuario_creacion", DbType.Int32, _mp_seguimiento_memorandum.usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U7"); 
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarReprobacionAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_ci_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_his_usuario_creacion", DbType.Int32, _mp_seguimiento_memorandum.usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U8");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarReprobacionMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_mv_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_his_usuario_creacion", DbType.Int32, _mp_seguimiento_memorandum.usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U9");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerAltaID(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_seguimiento_memorandum.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C47");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerBajaID(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_seguimiento_memorandum.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C48");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerRPTID(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_seguimiento_memorandum.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C49");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerAltaCIDID(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_seguimiento_memorandum.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C50");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerBajaCIDID(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_seguimiento_memorandum.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C51");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerMemoVarioID(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_seguimiento_memorandum.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C52");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerValidacionBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C53");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerMovimientosValidados(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_his_usuario_creacion", DbType.Int32, _mp_seguimiento_memorandum.usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C54");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerDatosInformacionAltasCIGrilla(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.String, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C44");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerDatosInformacionBajasCIGrilla(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.String, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C45");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerDatosInformacionMemosVariosGrilla(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_seguimiento_memorandum.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_seguimiento_memorandum.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C46");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerInformacionValidar(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C53");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ListarMovimientosParaReprobar(int pr_id, int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_SEGUIMIENTO_MEMORANDUM);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.Int32, pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C54");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _MP_CARGO
        public override bool Adicionar__mp_cargo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_es_id", DbType.Int32, _mp_cargo.ca_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_eo_id", DbType.Int32, _mp_cargo.ca_eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_ti_item", DbType.String, _mp_cargo.ca_ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, _mp_cargo.ca_num_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_estado", DbType.String, _mp_cargo.ca_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_aplica_incremento", DbType.String, _mp_cargo.ca_aplica_incremento);
                CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_jornada", DbType.String, _mp_cargo.ca_tipo_jornada);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar__mp_cargo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Actualizar__mp_cargo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_es_id", DbType.Int32, _mp_cargo.ca_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_eo_id", DbType.Int32, _mp_cargo.ca_eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_ti_item", DbType.String, _mp_cargo.ca_ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, _mp_cargo.ca_num_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_estado", DbType.String, _mp_cargo.ca_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_aplica_incremento", DbType.String, _mp_cargo.ca_aplica_incremento);
                CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_jornada", DbType.String, _mp_cargo.ca_tipo_jornada);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId__mp_cargo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                _mp_cargo.ca_id = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerRegistro__mp_cargo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaGrilla__mp_cargo(string ca_id,
                        string ca_es_id,
                        string ca_eo_id,
                        string ca_ti_item,
                        string ca_num_item,
                        string ca_estado,
                        string ca_aplica_incremento,
                        string ca_tipo_jornada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                if (ca_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, Convert.ToInt32(ca_id)); }
                if (ca_es_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ca_es_id", DbType.Int32, Convert.ToInt32(ca_es_id)); }
                if (ca_eo_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ca_eo_id", DbType.Int32, Convert.ToInt32(ca_eo_id)); }
                if (ca_ti_item.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ca_ti_item", DbType.String, Convert.ToString(ca_ti_item)); }
                if (ca_num_item.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, Convert.ToInt32(ca_num_item)); }
                if (ca_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ca_estado", DbType.String, Convert.ToString(ca_estado)); }
                if (ca_aplica_incremento.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ca_aplica_incremento", DbType.String, Convert.ToString(ca_aplica_incremento)); }
                if (ca_tipo_jornada.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_jornada", DbType.String, Convert.ToString(ca_tipo_jornada)); }

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo__mp_cargo()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // FUNCIONES USADAS JRVS
        public override bool AdicionarTenor(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_te_descripcion", DbType.String, _mp_cargo.te_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_te_contenido", DbType.String, _mp_cargo.te_contenido);
                CNXSIGRH3.AddInParameter(icom, "p_te_tipo_reg", DbType.String, _mp_cargo.te_tipo_reg);
                CNXSIGRH3.AddInParameter(icom, "p_te_usuario_creacion", DbType.Int32, _mp_cargo.te_usuario_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerDetalleTenor(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_te_cod_tenor", DbType.Int32, _mp_cargo.te_cod_tenor);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerDetalleFuncionario(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _mp_cargo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_te_existe", DbType.Int32, _mp_cargo.p_aux);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C12");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleFuncionarioTransicion(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _mp_cargo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_te_existe", DbType.Int32, _mp_cargo.p_aux);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C82");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleFuncionarioSancion(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _mp_cargo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_te_existe", DbType.Int32, _mp_cargo.p_aux);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C85");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet VerificarMemorandum(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_te_cod_tenor", DbType.Int32, _mp_cargo.te_cod_tenor);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C75");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleFuncionarioBajas(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _mp_cargo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_te_existe", DbType.Int32, _mp_cargo.p_aux);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C62");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleFuncionarioPRTAcefalias(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _mp_cargo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_te_existe", DbType.Int32, _mp_cargo.p_aux);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C64");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleFuncionarioPRTCargos(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _mp_cargo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_te_existe", DbType.Int32, _mp_cargo.p_aux);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C63");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleFuncionarioAComInt(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _mp_cargo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_te_existe", DbType.Int32, _mp_cargo.p_aux);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C65");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleFuncionarioBComInt(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _mp_cargo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_te_existe", DbType.Int32, _mp_cargo.p_aux);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C76");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleFuncionarioADispPersonal(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _mp_cargo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_te_existe", DbType.Int32, _mp_cargo.p_aux);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C66");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleFuncionarioBDispPersonal(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _mp_cargo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_te_existe", DbType.Int32, _mp_cargo.p_aux);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C77");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleFuncionarioMemosVarios(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _mp_cargo.p_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_te_existe", DbType.Int32, _mp_cargo.p_aux);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C69");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrillaTenor(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C13");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override DataSet ObtenerDatosTenor(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_te_cod_tenor", DbType.String, _mp_cargo.te_cod_tenor);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizacionTenor(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_te_cod_tenor", DbType.Int32, _mp_cargo.te_cod_tenor);
                CNXSIGRH3.AddInParameter(icom, "p_te_descripcion", DbType.String, _mp_cargo.te_descripcion);
                CNXSIGRH3.AddInParameter(icom, "p_te_contenido", DbType.String, _mp_cargo.te_contenido);
                CNXSIGRH3.AddInParameter(icom, "p_te_tipo_reg", DbType.String, _mp_cargo.te_tipo_reg);
                CNXSIGRH3.AddInParameter(icom, "p_te_usuario_creacion", DbType.Int32, _mp_cargo.te_usuario_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarTenor(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_te_cod_tenor", DbType.Int32, _mp_cargo.te_cod_tenor);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFiltradoTipoMov(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C17");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoTipoItem(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C18");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFiltradoTenor(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_te_tipo_reg", DbType.String, _mp_cargo.te_tipo_reg);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C19");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFiltradoTipoMemoV(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C78");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGestion(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_gestion", DbType.String, _mp_cargo.gestion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaFiltro(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_as_estado", DbType.String, _mp_cargo.as_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_ti_item", DbType.String, _mp_cargo.ca_ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.String, _mp_cargo.ca_num_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item_hasta", DbType.String, _mp_cargo.ca_num_item_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.String, _mp_cargo.ca_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, _mp_cargo.ca_num_consulta);
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerNivelOrg(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C21");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDescripcionNivelOrg(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C71");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerNivelOrgEjecutivo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C51");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoTipoDoc()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C22");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFiltradoEstrucOrg(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C41");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerNivelOrgItems(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C23");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerNivelOrgItemsEjecutivo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C55");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleitem(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_num_iden", DbType.String, _mp_cargo.eo_id.ToString());
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C24");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFiltradoCargoUO(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_ca_ti_item", DbType.String, _mp_cargo.ca_ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C25");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFiltradoTipoItemUO(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C26");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFiltradoTipoItemUOCreacion(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C74");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFiltradoTipoItemUOSuplencia(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.Int32, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C70");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleUO(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_es_cod_esc", DbType.String, _mp_cargo.es_cod_esc);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C27");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerIdCargo()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C28");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerNroItem(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.Int32, _mp_cargo.ca_eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.Int32, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C29");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet AdicionarCargoUO(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_es_id", DbType.Int32, _mp_cargo.ca_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_eo_id", DbType.Int32, _mp_cargo.ca_eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_ti_item", DbType.String, _mp_cargo.ca_ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, _mp_cargo.ca_num_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_estado", DbType.String, _mp_cargo.ca_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_aplica_incremento", DbType.String, _mp_cargo.ca_aplica_incremento);
                CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_jornada", DbType.String, _mp_cargo.ca_tipo_jornada);
                CNXSIGRH3.AddInParameter(icom, "p_ca_basico_calculado", DbType.Double, Convert.ToDouble(_mp_cargo.ca_basico_calculado));
                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.String, _mp_cargo.ca_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_usuario_creacion", DbType.Int32, _mp_cargo.ca_usuario_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool AdicionarGlosa(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_gl_valor_pk", DbType.Int32, _mp_cargo.gl_valor_pk);
                CNXSIGRH3.AddInParameter(icom, "p_gl_nombre_pk", DbType.String, _mp_cargo.gl_nombre_pk);
                CNXSIGRH3.AddInParameter(icom, "p_gl_tabla", DbType.String, _mp_cargo.gl_tabla);
                CNXSIGRH3.AddInParameter(icom, "p_gl_tipo_mov", DbType.Int32, _mp_cargo.gl_tipo_mov);
                CNXSIGRH3.AddInParameter(icom, "p_gl_fecha_doc", DbType.DateTime, _mp_cargo.gl_fecha_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_tipo_doc", DbType.Int32, _mp_cargo.gl_tipo_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_numero_doc", DbType.String, _mp_cargo.gl_numero_doc);
                CNXSIGRH3.AddInParameter(icom, "p_gl_glosa", DbType.String, _mp_cargo.gl_glosa);
                CNXSIGRH3.AddInParameter(icom, "p_gl_estado", DbType.String, _mp_cargo.gl_estado);
                CNXSIGRH3.AddInParameter(icom, "p_gl_usuario", DbType.Int32, _mp_cargo.gl_usuario);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A4");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrillaItems(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C30");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleitemCargo(cls_mp_cargo _mp_cargo, string gestion_selec)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C31");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarItem(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, (_mp_cargo.ca_id_anterior));

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C32");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarItem(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, (_mp_cargo.ca_id));
                CNXSIGRH3.AddInParameter(icom, "p_ca_usuario_creacion", DbType.Int32, (_mp_cargo.ca_usuario_creacion));

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C33");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaItemsCP(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);
                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C34");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (KCPB)
        public override DataSet ObtenerDetalleItemCP(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C35");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerDetalleItemCP_num_item(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, _mp_cargo.num_item);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C96");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerCargoX(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id_anterior);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C42");
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C46");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerDatosDetalleFuncionario(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_cargo.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id_actual);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C68");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerNivelItemsLibres(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.Int32, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.Int32, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C72");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDetalleItemsLibre(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C73");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerTipoJornada()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C95");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // (JRVS) Busqueda funcionario Interinato
        public override DataSet ObtenerTablaGrilla__persona_ejecutivo(
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__persona_gamlp(
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7A");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrilla__persona_FechaIngreso(
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C29");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrilla__gamlp_vigente(
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
        string per_estado_civil,
        int pr_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C12");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrilla__gamlp_vigente_ex_preocupacional(
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
        string per_estado_civil,
        int pr_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C17");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrilla__gamlp_finiquito(
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
         string per_estado_civil,
         int pr_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C18");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet obtenerFiltradoTipoAsignacion()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C50");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet obtenerFiltradoTipoMovInterinato(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_cat_id_superior", DbType.Int32, _mp_cargo.p_cat_id_superior);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C49");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarMemoAsignacion(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_nro_memo", DbType.Int32, _mp_cargo.p_nro_memo);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_cargo.as_id_actual);
                CNXSIGRH3.AddInParameter(icom, "p_as_tipo_mov", DbType.String, _mp_cargo.as_tipo_mov);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C61");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //FUNCIONES JQC
        public override DataSet ObtenerTablaGrilla__persona_concejo(
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
        string per_estado_civil,
        int gestion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, gestion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerIdCargoPlantaC()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C43");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaItemConsejo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C44");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarCargoPlanta(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_es_id", DbType.Int32, _mp_cargo.ca_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_eo_id", DbType.Int32, _mp_cargo.ca_eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_ti_item", DbType.String, _mp_cargo.ca_ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, _mp_cargo.ca_num_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_estado", DbType.String, _mp_cargo.ca_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_aplica_incremento", DbType.String, _mp_cargo.ca_aplica_incremento);
                CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_jornada", DbType.String, _mp_cargo.ca_tipo_jornada);
                CNXSIGRH3.AddInParameter(icom, "p_ca_basico_calculado", DbType.String, _mp_cargo.ca_basico_calculado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_calculo", DbType.Int32, _mp_cargo.ca_tipo_calculo);
                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.String, _mp_cargo.ca_pr_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A7");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool obtenerDatosFuncionarioConsejo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);
                CNXSIGRH3.AddInParameter(icom, "p_num_iden", DbType.String, _mp_cargo.fu_num_ident);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C45");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);


                if (ds.Tables[0].Rows[0]["per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["per_id"].ToString().Trim() != "") { _mp_cargo.as_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["per_id"]); }
                if (ds.Tables[0].Rows[0]["as_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["as_per_id"].ToString().Trim() != "") { _mp_cargo.ca_eo_id = Convert.ToInt32(ds.Tables[0].Rows[0]["as_per_id"]); }
                if (ds.Tables[0].Rows[0]["per_ap_paterno"] != DBNull.Value && ds.Tables[0].Rows[0]["per_ap_paterno"].ToString().Trim() != "") { _mp_cargo.fu_paterno = Convert.ToString(ds.Tables[0].Rows[0]["per_ap_paterno"]); }
                if (ds.Tables[0].Rows[0]["per_ap_materno"] != DBNull.Value && ds.Tables[0].Rows[0]["per_ap_materno"].ToString().Trim() != "") { _mp_cargo.fu_materno = Convert.ToString(ds.Tables[0].Rows[0]["per_ap_materno"]); }
                if (ds.Tables[0].Rows[0]["per_nombres"] != DBNull.Value && ds.Tables[0].Rows[0]["per_nombres"].ToString().Trim() != "") { _mp_cargo.fu_nombres = Convert.ToString(ds.Tables[0].Rows[0]["per_nombres"]); }
                if (ds.Tables[0].Rows[0]["per_num_doc"] != DBNull.Value && ds.Tables[0].Rows[0]["per_num_doc"].ToString().Trim() != "") { _mp_cargo.fu_num_ident = Convert.ToString(ds.Tables[0].Rows[0]["per_num_doc"]); }
                if (ds.Tables[0].Rows[0]["cat_abreviacion"] != DBNull.Value && ds.Tables[0].Rows[0]["cat_abreviacion"].ToString().Trim() != "") { _mp_cargo.fu_tipo_ident = Convert.ToString(ds.Tables[0].Rows[0]["cat_abreviacion"]); }
                if (ds.Tables[0].Rows[0]["haber_basico"] != DBNull.Value && ds.Tables[0].Rows[0]["haber_basico"].ToString().Trim() != "") { _mp_cargo.haber_basico = Convert.ToString(ds.Tables[0].Rows[0]["haber_basico"]); }
                if (ds.Tables[0].Rows[0]["es_escalafon"] != DBNull.Value && ds.Tables[0].Rows[0]["es_escalafon"].ToString().Trim() != "") { _mp_cargo.es_escalafon = Convert.ToString(ds.Tables[0].Rows[0]["es_escalafon"]); }
                if (ds.Tables[0].Rows[0]["ns_clase"] != DBNull.Value && ds.Tables[0].Rows[0]["ns_clase"].ToString().Trim() != "") { _mp_cargo.ns_clase = Convert.ToString(ds.Tables[0].Rows[0]["ns_clase"]); }
                if (ds.Tables[0].Rows[0]["ns_nivel"] != DBNull.Value && ds.Tables[0].Rows[0]["ns_nivel"].ToString().Trim() != "") { _mp_cargo.ns_nivel = Convert.ToString(ds.Tables[0].Rows[0]["ns_nivel"]); }
                if (ds.Tables[0].Rows[0]["as_fecha_asignacion"] != DBNull.Value && ds.Tables[0].Rows[0]["as_fecha_asignacion"].ToString().Trim() != "") { _mp_cargo.as_fecha_asignacion = Convert.ToString(ds.Tables[0].Rows[0]["as_fecha_asignacion"]); }
                if (ds.Tables[0].Rows[0]["as_fecha_baja"] != DBNull.Value && ds.Tables[0].Rows[0]["as_fecha_baja"].ToString().Trim() != "")
                {
                    _mp_cargo.as_fecha_baja = Convert.ToString(ds.Tables[0].Rows[0]["as_fecha_baja"]);
                }
                else
                {
                    _mp_cargo.as_fecha_baja = "";
                }
                if (ds.Tables[0].Rows[0]["eo_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_descripcion"].ToString().Trim() != "") { _mp_cargo.ep_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["eo_descripcion"]); }
                if (ds.Tables[0].Rows[0]["es_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["es_descripcion"].ToString().Trim() != "") { _mp_cargo.es_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["es_descripcion"]); }
                if (ds.Tables[0].Rows[0]["as_id"] != DBNull.Value && ds.Tables[0].Rows[0]["as_id"].ToString().Trim() != "") { _mp_cargo.as_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["as_id"]); }
                if (ds.Tables[0].Rows[0]["ca_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_id"].ToString().Trim() != "") { _mp_cargo.ca_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_id"]); }
                if (ds.Tables[0].Rows[0]["ca_es_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_es_id"].ToString().Trim() != "") { _mp_cargo.ca_es_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_es_id"]); }
                if (ds.Tables[0].Rows[0]["ca_eo_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_eo_id"].ToString().Trim() != "") { _mp_cargo.ca_eo_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_eo_id"]); }
                if (ds.Tables[0].Rows[0]["ca_ti_item"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_ti_item"].ToString().Trim() != "") { _mp_cargo.ca_ti_item_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_ti_item"]); }
                if (ds.Tables[0].Rows[0]["ca_num_item"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_num_item"].ToString().Trim() != "") { _mp_cargo.ca_num_item_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_num_item"]); }
                if (ds.Tables[0].Rows[0]["ca_aplica_incremento"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_aplica_incremento"].ToString().Trim() != "") { _mp_cargo.ca_aplica_incremento_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_aplica_incremento"]); }
                else
                {
                    _mp_cargo.ca_aplica_incremento_actual = "";
                }
                if (ds.Tables[0].Rows[0]["ca_tipo_jornada"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_tipo_jornada"].ToString().Trim() != "") { _mp_cargo.ca_tipo_jornada_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_tipo_jornada"]); }
                if (ds.Tables[0].Rows[0]["ca_basico_calculado"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_basico_calculado"].ToString().Trim() != "") { _mp_cargo.ca_basico_calculado_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_basico_calculado"]); }
                if (ds.Tables[0].Rows[0]["ca_tipo_calculo"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_tipo_calculo"].ToString().Trim() != "") { _mp_cargo.ca_tipo_calculo_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_tipo_calculo"]); }
                if (ds.Tables[0].Rows[0]["ca_pr_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_pr_id"].ToString().Trim() != "") { _mp_cargo.ca_pr_id_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_pr_id"]); }
                if (ds.Tables[0].Rows[0]["per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["per_id"].ToString().Trim() != "") { _mp_cargo.as_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["per_id"]); }
                if (ds.Tables[0].Rows[0]["fp_foto"] != DBNull.Value && ds.Tables[0].Rows[0]["fp_foto"].ToString().Trim() != "") { _mp_cargo.imagen = "data:image/jpg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["fp_foto"]); }
                if (ds.Tables[0].Rows[0]["per_sexo"] != DBNull.Value && ds.Tables[0].Rows[0]["per_sexo"].ToString().Trim() != "") { _mp_cargo.fu_sexo = Convert.ToString(ds.Tables[0].Rows[0]["per_sexo"]); }
                if (ds.Tables[0].Rows[0]["as_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["as_estado"].ToString().Trim() != "") { _mp_cargo.as_estado = Convert.ToString(ds.Tables[0].Rows[0]["as_estado"]); }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerNivelOrganizacional(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ep_cod_estp", DbType.String, _mp_cargo.ep_cod_estp);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerNivelOrganizacionalItems(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ep_cod_estp", DbType.String, _mp_cargo.ep_cod_estp);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerDetalleItem(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_nro_item", DbType.String, _mp_cargo.ep_cod_estp);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerDetalleItemEjecutivo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_nro_item", DbType.String, _mp_cargo.ep_cod_estp);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C53");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool obtenerDatosFuncionario(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);
                CNXSIGRH3.AddInParameter(icom, "p_num_iden", DbType.String, _mp_cargo.fu_num_ident);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);


                if (ds.Tables[0].Rows[0]["per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["per_id"].ToString().Trim() != "") { _mp_cargo.as_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["per_id"]); }
                if (ds.Tables[0].Rows[0]["as_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["as_per_id"].ToString().Trim() != "") { _mp_cargo.ca_eo_id = Convert.ToInt32(ds.Tables[0].Rows[0]["as_per_id"]); }
                if (ds.Tables[0].Rows[0]["per_ap_paterno"] != DBNull.Value && ds.Tables[0].Rows[0]["per_ap_paterno"].ToString().Trim() != "") { _mp_cargo.fu_paterno = Convert.ToString(ds.Tables[0].Rows[0]["per_ap_paterno"]); }
                if (ds.Tables[0].Rows[0]["per_ap_materno"] != DBNull.Value && ds.Tables[0].Rows[0]["per_ap_materno"].ToString().Trim() != "") { _mp_cargo.fu_materno = Convert.ToString(ds.Tables[0].Rows[0]["per_ap_materno"]); }
                if (ds.Tables[0].Rows[0]["per_nombres"] != DBNull.Value && ds.Tables[0].Rows[0]["per_nombres"].ToString().Trim() != "") { _mp_cargo.fu_nombres = Convert.ToString(ds.Tables[0].Rows[0]["per_nombres"]); }
                if (ds.Tables[0].Rows[0]["per_num_doc"] != DBNull.Value && ds.Tables[0].Rows[0]["per_num_doc"].ToString().Trim() != "") { _mp_cargo.fu_num_ident = Convert.ToString(ds.Tables[0].Rows[0]["per_num_doc"]); }
                if (ds.Tables[0].Rows[0]["cat_abreviacion"] != DBNull.Value && ds.Tables[0].Rows[0]["cat_abreviacion"].ToString().Trim() != "") { _mp_cargo.fu_tipo_ident = Convert.ToString(ds.Tables[0].Rows[0]["cat_abreviacion"]); }
                if (ds.Tables[0].Rows[0]["haber_basico"] != DBNull.Value && ds.Tables[0].Rows[0]["haber_basico"].ToString().Trim() != "") { _mp_cargo.haber_basico = Convert.ToString(ds.Tables[0].Rows[0]["haber_basico"]); }
                if (ds.Tables[0].Rows[0]["es_escalafon"] != DBNull.Value && ds.Tables[0].Rows[0]["es_escalafon"].ToString().Trim() != "") { _mp_cargo.es_escalafon = Convert.ToString(ds.Tables[0].Rows[0]["es_escalafon"]); }
                if (ds.Tables[0].Rows[0]["ns_clase"] != DBNull.Value && ds.Tables[0].Rows[0]["ns_clase"].ToString().Trim() != "") { _mp_cargo.ns_clase = Convert.ToString(ds.Tables[0].Rows[0]["ns_clase"]); }
                if (ds.Tables[0].Rows[0]["ns_nivel"] != DBNull.Value && ds.Tables[0].Rows[0]["ns_nivel"].ToString().Trim() != "") { _mp_cargo.ns_nivel = Convert.ToString(ds.Tables[0].Rows[0]["ns_nivel"]); }
                if (ds.Tables[0].Rows[0]["as_fecha_asignacion"] != DBNull.Value && ds.Tables[0].Rows[0]["as_fecha_asignacion"].ToString().Trim() != "") { _mp_cargo.as_fecha_asignacion = Convert.ToString(ds.Tables[0].Rows[0]["as_fecha_asignacion"]); }
                if (ds.Tables[0].Rows[0]["as_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["as_estado"].ToString().Trim() != "") { _mp_cargo.as_estado = Convert.ToString(ds.Tables[0].Rows[0]["as_estado"]); }
                if (ds.Tables[0].Rows[0]["as_fecha_baja"] != DBNull.Value && ds.Tables[0].Rows[0]["as_fecha_baja"].ToString().Trim() != "")
                {
                    _mp_cargo.as_fecha_baja = Convert.ToString(ds.Tables[0].Rows[0]["as_fecha_baja"]);
                }
                else
                {
                    _mp_cargo.as_fecha_baja = "";
                }
                if (ds.Tables[0].Rows[0]["eo_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_descripcion"].ToString().Trim() != "") { _mp_cargo.ep_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["eo_descripcion"]); }
                if (ds.Tables[0].Rows[0]["es_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["es_descripcion"].ToString().Trim() != "") { _mp_cargo.es_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["es_descripcion"]); }
                if (ds.Tables[0].Rows[0]["p_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["p_descripcion"].ToString().Trim() != "") { _mp_cargo.pu_nombre_puesto = Convert.ToString(ds.Tables[0].Rows[0]["p_descripcion"]); } else { _mp_cargo.pu_nombre_puesto = ""; }

                if (ds.Tables[0].Rows[0]["as_id"] != DBNull.Value && ds.Tables[0].Rows[0]["as_id"].ToString().Trim() != "") { _mp_cargo.as_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["as_id"]); }
                if (ds.Tables[0].Rows[0]["ca_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_id"].ToString().Trim() != "") { _mp_cargo.ca_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_id"]); }
                if (ds.Tables[0].Rows[0]["ca_es_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_es_id"].ToString().Trim() != "") { _mp_cargo.ca_es_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_es_id"]); }
                if (ds.Tables[0].Rows[0]["ca_eo_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_eo_id"].ToString().Trim() != "") { _mp_cargo.ca_eo_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_eo_id"]); }
                if (ds.Tables[0].Rows[0]["ca_ti_item"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_ti_item"].ToString().Trim() != "") { _mp_cargo.ca_ti_item_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_ti_item"]); }
                if (ds.Tables[0].Rows[0]["ca_num_item"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_num_item"].ToString().Trim() != "") { _mp_cargo.ca_num_item_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_num_item"]); }
                if (ds.Tables[0].Rows[0]["ca_aplica_incremento"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_aplica_incremento"].ToString().Trim() != "") { _mp_cargo.ca_aplica_incremento_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_aplica_incremento"]); }
                if (ds.Tables[0].Rows[0]["ca_tipo_jornada"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_tipo_jornada"].ToString().Trim() != "") { _mp_cargo.ca_tipo_jornada_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_tipo_jornada"]); }
                if (ds.Tables[0].Rows[0]["ca_basico_calculado"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_basico_calculado"].ToString().Trim() != "") { _mp_cargo.ca_basico_calculado_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_basico_calculado"]); }
                if (ds.Tables[0].Rows[0]["ca_tipo_calculo"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_tipo_calculo"].ToString().Trim() != "") { _mp_cargo.ca_tipo_calculo_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_tipo_calculo"]); }
                if (ds.Tables[0].Rows[0]["ca_pr_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_pr_id"].ToString().Trim() != "") { _mp_cargo.ca_pr_id_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_pr_id"]); }
                if (ds.Tables[0].Rows[0]["cp_id"] != DBNull.Value && ds.Tables[0].Rows[0]["cp_id"].ToString().Trim() != "") { _mp_cargo.cp_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["cp_id"]); }
                if (ds.Tables[0].Rows[0]["fp_foto"] != DBNull.Value && ds.Tables[0].Rows[0]["fp_foto"].ToString().Trim() != "") { _mp_cargo.imagen = "data:image/jpg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["fp_foto"]); }
                if (ds.Tables[0].Rows[0]["per_sexo"] != DBNull.Value && ds.Tables[0].Rows[0]["per_sexo"].ToString().Trim() != "") { _mp_cargo.fu_sexo = Convert.ToString(ds.Tables[0].Rows[0]["per_sexo"]); }
                if (ds.Tables[0].Rows[0]["ti_tipo_item_gral"] != DBNull.Value && ds.Tables[0].Rows[0]["ti_tipo_item_gral"].ToString().Trim() != "") { _mp_cargo.tipo_item = Convert.ToString(ds.Tables[0].Rows[0]["ti_tipo_item_gral"]); }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool obtenerDatosFuncionarioConAsignaciones(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);
                CNXSIGRH3.AddInParameter(icom, "p_num_iden", DbType.String, _mp_cargo.fu_num_ident);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_as_ca_id", DbType.Int32, _mp_cargo.as_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C97");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);


                if (ds.Tables[0].Rows[0]["per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["per_id"].ToString().Trim() != "") { _mp_cargo.as_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["per_id"]); }
                if (ds.Tables[0].Rows[0]["as_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["as_per_id"].ToString().Trim() != "") { _mp_cargo.ca_eo_id = Convert.ToInt32(ds.Tables[0].Rows[0]["as_per_id"]); }
                if (ds.Tables[0].Rows[0]["per_ap_paterno"] != DBNull.Value && ds.Tables[0].Rows[0]["per_ap_paterno"].ToString().Trim() != "") { _mp_cargo.fu_paterno = Convert.ToString(ds.Tables[0].Rows[0]["per_ap_paterno"]); }
                if (ds.Tables[0].Rows[0]["per_ap_materno"] != DBNull.Value && ds.Tables[0].Rows[0]["per_ap_materno"].ToString().Trim() != "") { _mp_cargo.fu_materno = Convert.ToString(ds.Tables[0].Rows[0]["per_ap_materno"]); }
                if (ds.Tables[0].Rows[0]["per_nombres"] != DBNull.Value && ds.Tables[0].Rows[0]["per_nombres"].ToString().Trim() != "") { _mp_cargo.fu_nombres = Convert.ToString(ds.Tables[0].Rows[0]["per_nombres"]); }
                if (ds.Tables[0].Rows[0]["per_num_doc"] != DBNull.Value && ds.Tables[0].Rows[0]["per_num_doc"].ToString().Trim() != "") { _mp_cargo.fu_num_ident = Convert.ToString(ds.Tables[0].Rows[0]["per_num_doc"]); }
                if (ds.Tables[0].Rows[0]["cat_abreviacion"] != DBNull.Value && ds.Tables[0].Rows[0]["cat_abreviacion"].ToString().Trim() != "") { _mp_cargo.fu_tipo_ident = Convert.ToString(ds.Tables[0].Rows[0]["cat_abreviacion"]); }
                if (ds.Tables[0].Rows[0]["haber_basico"] != DBNull.Value && ds.Tables[0].Rows[0]["haber_basico"].ToString().Trim() != "") { _mp_cargo.haber_basico = Convert.ToString(ds.Tables[0].Rows[0]["haber_basico"]); }
                if (ds.Tables[0].Rows[0]["es_escalafon"] != DBNull.Value && ds.Tables[0].Rows[0]["es_escalafon"].ToString().Trim() != "") { _mp_cargo.es_escalafon = Convert.ToString(ds.Tables[0].Rows[0]["es_escalafon"]); }
                if (ds.Tables[0].Rows[0]["ns_clase"] != DBNull.Value && ds.Tables[0].Rows[0]["ns_clase"].ToString().Trim() != "") { _mp_cargo.ns_clase = Convert.ToString(ds.Tables[0].Rows[0]["ns_clase"]); }
                if (ds.Tables[0].Rows[0]["ns_nivel"] != DBNull.Value && ds.Tables[0].Rows[0]["ns_nivel"].ToString().Trim() != "") { _mp_cargo.ns_nivel = Convert.ToString(ds.Tables[0].Rows[0]["ns_nivel"]); }
                if (ds.Tables[0].Rows[0]["as_fecha_asignacion"] != DBNull.Value && ds.Tables[0].Rows[0]["as_fecha_asignacion"].ToString().Trim() != "") { _mp_cargo.as_fecha_asignacion = Convert.ToString(ds.Tables[0].Rows[0]["as_fecha_asignacion"]); }
                if (ds.Tables[0].Rows[0]["as_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["as_estado"].ToString().Trim() != "") { _mp_cargo.as_estado = Convert.ToString(ds.Tables[0].Rows[0]["as_estado"]); }
                if (ds.Tables[0].Rows[0]["as_fecha_baja"] != DBNull.Value && ds.Tables[0].Rows[0]["as_fecha_baja"].ToString().Trim() != "")
                {
                    _mp_cargo.as_fecha_baja = Convert.ToString(ds.Tables[0].Rows[0]["as_fecha_baja"]);
                }
                else
                {
                    _mp_cargo.as_fecha_baja = "";
                }
                if (ds.Tables[0].Rows[0]["eo_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["eo_descripcion"].ToString().Trim() != "") { _mp_cargo.ep_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["eo_descripcion"]); }
                if (ds.Tables[0].Rows[0]["es_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["es_descripcion"].ToString().Trim() != "") { _mp_cargo.es_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["es_descripcion"]); }
                if (ds.Tables[0].Rows[0]["p_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["p_descripcion"].ToString().Trim() != "") { _mp_cargo.pu_nombre_puesto = Convert.ToString(ds.Tables[0].Rows[0]["p_descripcion"]); } else { _mp_cargo.pu_nombre_puesto = ""; }

                if (ds.Tables[0].Rows[0]["as_id"] != DBNull.Value && ds.Tables[0].Rows[0]["as_id"].ToString().Trim() != "") { _mp_cargo.as_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["as_id"]); }
                if (ds.Tables[0].Rows[0]["ca_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_id"].ToString().Trim() != "") { _mp_cargo.ca_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_id"]); }
                if (ds.Tables[0].Rows[0]["ca_es_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_es_id"].ToString().Trim() != "") { _mp_cargo.ca_es_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_es_id"]); }
                if (ds.Tables[0].Rows[0]["ca_eo_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_eo_id"].ToString().Trim() != "") { _mp_cargo.ca_eo_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_eo_id"]); }
                if (ds.Tables[0].Rows[0]["ca_ti_item"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_ti_item"].ToString().Trim() != "") { _mp_cargo.ca_ti_item_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_ti_item"]); }
                if (ds.Tables[0].Rows[0]["ca_num_item"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_num_item"].ToString().Trim() != "") { _mp_cargo.ca_num_item_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_num_item"]); }
                if (ds.Tables[0].Rows[0]["ca_aplica_incremento"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_aplica_incremento"].ToString().Trim() != "") { _mp_cargo.ca_aplica_incremento_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_aplica_incremento"]); }
                if (ds.Tables[0].Rows[0]["ca_tipo_jornada"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_tipo_jornada"].ToString().Trim() != "") { _mp_cargo.ca_tipo_jornada_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_tipo_jornada"]); }
                if (ds.Tables[0].Rows[0]["ca_basico_calculado"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_basico_calculado"].ToString().Trim() != "") { _mp_cargo.ca_basico_calculado_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_basico_calculado"]); }
                if (ds.Tables[0].Rows[0]["ca_tipo_calculo"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_tipo_calculo"].ToString().Trim() != "") { _mp_cargo.ca_tipo_calculo_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["ca_tipo_calculo"]); }
                if (ds.Tables[0].Rows[0]["ca_pr_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ca_pr_id"].ToString().Trim() != "") { _mp_cargo.ca_pr_id_actual = Convert.ToString(ds.Tables[0].Rows[0]["ca_pr_id"]); }
                if (ds.Tables[0].Rows[0]["cp_id"] != DBNull.Value && ds.Tables[0].Rows[0]["cp_id"].ToString().Trim() != "") { _mp_cargo.cp_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["cp_id"]); }
                if (ds.Tables[0].Rows[0]["fp_foto"] != DBNull.Value && ds.Tables[0].Rows[0]["fp_foto"].ToString().Trim() != "") { _mp_cargo.imagen = "data:image/jpg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["fp_foto"]); }
                if (ds.Tables[0].Rows[0]["per_sexo"] != DBNull.Value && ds.Tables[0].Rows[0]["per_sexo"].ToString().Trim() != "") { _mp_cargo.fu_sexo = Convert.ToString(ds.Tables[0].Rows[0]["per_sexo"]); }
                if (ds.Tables[0].Rows[0]["ti_tipo_item_gral"] != DBNull.Value && ds.Tables[0].Rows[0]["ti_tipo_item_gral"].ToString().Trim() != "") { _mp_cargo.tipo_item = Convert.ToString(ds.Tables[0].Rows[0]["ti_tipo_item_gral"]); }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet obtenerNombreUO(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.Int32, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C40");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet obtenerTipoMovPadre(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_cat_id", DbType.Int32, _mp_cargo.p_cat_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet obtenerFiltradoTipoMov(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_cat_id_superior", DbType.Int32, _mp_cargo.p_cat_id_superior);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet obtenerFiltradoTipoDoc()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarPromocion(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_cargo.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_ca_id", DbType.Int32, _mp_cargo.as_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_fecha_inicio", DbType.DateTime, _mp_cargo.as_fecha_inicio);
                //CNXSIGRH3.AddInParameter(icom, "p_as_fecha_fin", DbType.DateTime, _mp_cargo.as_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_as_estado", DbType.String, _mp_cargo.as_estado);
                CNXSIGRH3.AddInParameter(icom, "p_as_tipo_reg", DbType.String, _mp_cargo.as_tipo_reg);
                CNXSIGRH3.AddInParameter(icom, "p_as_tipo_mov", DbType.String, _mp_cargo.as_tipo_mov);
                CNXSIGRH3.AddInParameter(icom, "p_as_tipo_baja", DbType.String, _mp_cargo.as_tipo_baja);
                CNXSIGRH3.AddInParameter(icom, "p_as_usuario_creacion", DbType.String, _mp_cargo.as_usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_cargo.as_pr_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarNuevoCargo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_es_id", DbType.Int32, _mp_cargo.ca_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_eo_id", DbType.Int32, _mp_cargo.ca_eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_ti_item", DbType.String, _mp_cargo.ca_ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, _mp_cargo.ca_num_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_aplica_incremento", DbType.String, _mp_cargo.ca_aplica_incremento);
                CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_jornada", DbType.String, _mp_cargo.ca_tipo_jornada);
                CNXSIGRH3.AddInParameter(icom, "p_ca_basico_calculado", DbType.String, _mp_cargo.ca_basico_calculado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_fecha_modificacion", DbType.DateTime, _mp_cargo.ca_fecha_modificacion);
                CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_calculo", DbType.Int32, _mp_cargo.ca_tipo_calculo);
                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.Int32, _mp_cargo.ca_pr_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ActualizarAsignacion(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_as_fecha_fin_actual", DbType.DateTime, _mp_cargo.as_fecha_fin_actual);
                CNXSIGRH3.AddInParameter(icom, "p_as_id_actual", DbType.Int32, _mp_cargo.as_id_actual);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ActualizarCargoActual(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id_actual", DbType.Int32, _mp_cargo.ca_id_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_estado", DbType.String, _mp_cargo.ca_estado_actual);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarCargoActual(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_es_id", DbType.Int32, _mp_cargo.ca_es_id_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_eo_id", DbType.Int32, _mp_cargo.ca_eo_id_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_ti_item", DbType.String, _mp_cargo.ca_ti_item_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, _mp_cargo.ca_num_item_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_estado", DbType.String, _mp_cargo.ca_estado_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_aplica_incremento", DbType.String, _mp_cargo.ca_aplica_incremento_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_jornada", DbType.String, _mp_cargo.ca_tipo_jornada_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_basico_calculado", DbType.String, _mp_cargo.ca_basico_calculado_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_calculo", DbType.Int32, _mp_cargo.ca_tipo_calculo_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.String, _mp_cargo.ca_pr_id_actual);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerIdCargoA()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C15");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarCargoNuevo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id_actual", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_estado", DbType.String, _mp_cargo.ca_estado);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarCargoNuevo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_es_id", DbType.Int32, _mp_cargo.ca_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_eo_id", DbType.Int32, _mp_cargo.ca_eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_ti_item", DbType.String, _mp_cargo.ca_ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, _mp_cargo.ca_num_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_estado", DbType.String, _mp_cargo.ca_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_aplica_incremento", DbType.String, _mp_cargo.ca_aplica_incremento);
                CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_jornada", DbType.String, _mp_cargo.ca_tipo_jornada);
                CNXSIGRH3.AddInParameter(icom, "p_ca_basico_calculado", DbType.String, _mp_cargo.ca_basico_calculado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_calculo", DbType.Int32, _mp_cargo.ca_tipo_calculo);
                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.String, _mp_cargo.ca_pr_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerAsignacion(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_cargo.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_ca_id", DbType.String, _mp_cargo.as_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C16");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerFiltradoCargoHB(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C37");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerNivelSalarial(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_es_id", DbType.Int32, _mp_cargo.ca_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C38");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerNivelOrgConcejo(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C39");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerBusquedaItem(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, _mp_cargo.ca_num_item);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C47");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerAsignacionX(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.String, _mp_cargo.as_id_actual);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C48");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerNivelOrganizacionalItemsMasAcefalia(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ep_cod_estp", DbType.String, _mp_cargo.ep_cod_estp);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C52");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerDetalleItemPlanta(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_nro_item", DbType.String, _mp_cargo.ep_cod_estp);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C54");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerListaItemPlanta(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.Int32, _mp_cargo.ca_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C86");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerListaCargoPlanta(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.Int32, _mp_cargo.ca_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C87");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerListaPuestoPlanta(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.Int32, _mp_cargo.ca_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C88");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerListaTipoItemPlanta(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C91");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerPuestoPlanta(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.Int32, _mp_cargo.ca_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C89");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrillaItem(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.Int32, _mp_cargo.ca_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C90");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ModificarItemPlanta(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, _mp_cargo.ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_es_id", DbType.Int32, _mp_cargo.ca_es_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_eo_id", DbType.Int32, _mp_cargo.ca_eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_ti_item", DbType.String, _mp_cargo.ca_ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, _mp_cargo.ca_num_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_estado", DbType.String, _mp_cargo.ca_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_aplica_incremento", DbType.String, _mp_cargo.ca_aplica_incremento);
                CNXSIGRH3.AddInParameter(icom, "p_ca_tipo_jornada", DbType.String, _mp_cargo.ca_tipo_jornada);
                CNXSIGRH3.AddInParameter(icom, "p_ca_basico_calculado", DbType.Int32, _mp_cargo.ca_basico_calculado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.Int32, _mp_cargo.ca_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_usuario_creacion", DbType.Int32, _mp_cargo.ca_usuario_creacion);

                CNXSIGRH3.AddInParameter(icom, "p_p_id", DbType.Int32, _mp_cargo.p_id);
                CNXSIGRH3.AddInParameter(icom, "p_p_descripcion", DbType.String, _mp_cargo.p_descripcion);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C92");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerTablaGrilla__persona_plantaContrato(
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
        string per_estado_civil,
        int gestion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, gestion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrilla__persona_gamlpVigente(
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerInfoParaTenorMemorandums(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_as_estado", DbType.String, _mp_cargo.as_estado);
                CNXSIGRH3.AddInParameter(icom, "p_ca_ti_item", DbType.String, _mp_cargo.ca_ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.String, _mp_cargo.ca_num_item);
                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item_hasta", DbType.String, _mp_cargo.ca_num_item_actual);
                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.String, _mp_cargo.ca_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _mp_cargo.gl_numero_doc);
                CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, _mp_cargo.fu_paterno);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, _mp_cargo.ca_num_consulta);

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override string Obtener_CaId(string num_item, string pr_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, Convert.ToInt32(num_item));
                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.Int32, Convert.ToInt32(pr_id));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "F3");

                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerItem_MoverFuente(string ca_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, Convert.ToInt32(ca_id));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "F1");


                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerItem_MoverFuente_Grilla(string num_item, string pr_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, Convert.ToInt32(num_item));
                CNXSIGRH3.AddInParameter(icom, "p_ca_pr_id", DbType.Int32, Convert.ToInt32(pr_id));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "1.3");


                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerUnidades_MoverFuente(string ca_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, Convert.ToInt32(ca_id));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "F2");


                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override int Modificar_FuenteFinanciamiento(string eo_id, string cod_proceso, string ca_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_eo_id", DbType.Int32, Convert.ToInt32(eo_id));
                CNXSIGRH3.AddInParameter(icom, "p_ca_id_actual", DbType.Int32, Convert.ToInt32(ca_id));
                CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, Convert.ToInt32(cod_proceso));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U5");


                return CNXSIGRH3.ExecuteNonQuery(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet TotalesFuenteFinanciamiento(string cod_proceso)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, Convert.ToInt32(cod_proceso));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "F4");


                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ConsultaSiPlanillaEstaEjecutada(string cod_proceso)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, Convert.ToInt32(cod_proceso));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "P6");


                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ConsultaSiPlanillaEstaEjecutada_adicional(string cod_proceso, string secuencial)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, Convert.ToInt32(cod_proceso));
                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, Convert.ToInt32(secuencial));

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "P11");


                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet BuscarParaAdicionales(string ci, string cod_proceso)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, Convert.ToInt32(ci));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "P5");
                CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, Convert.ToInt32(cod_proceso));

                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool InsertarCasosParaAdicionales(string cod_proceso, string as_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, Convert.ToInt32(as_id));
                CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, Convert.ToInt32(cod_proceso));

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "P8");

                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet MostrarCasosAdicionales(string cod_proceso)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, Convert.ToInt32(cod_proceso));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "P9");

                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool EliminarCasosAdicional(string ad_as_id, string cod_proceso, string secuencial)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, Convert.ToInt32(ad_as_id));
                CNXSIGRH3.AddInParameter(icom, "p_ca_id_x", DbType.Int32, Convert.ToInt32(cod_proceso));
                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, Convert.ToInt32(secuencial));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "P10");

                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //MP
        public override DataSet ObtenerNivelOrgMP(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, _mp_cargo.eo_id);
                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mp_cargo.gestion_selec);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "MP1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region _MP_INCOMPATIBILIDAD_FUN
        public override int Adicionar__mp_incompatibilidad_fun(cls_mp_incompatibilidad_fun _mp_incompatibilidad_fun)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_INCOMPATIBILIDAD_FUN);
                CNXSIGRH3.AddInParameter(icom, "p_if_per_id", DbType.Int32, _mp_incompatibilidad_fun.if_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_if_per_id_pariente", DbType.Int32, _mp_incompatibilidad_fun.if_per_id_pariente);
                CNXSIGRH3.AddInParameter(icom, "p_if_parentesco", DbType.Int32, _mp_incompatibilidad_fun.if_parentesco);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                int id = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom).ToString());
                return id;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__mp_incompatibilidad_fun(cls_mp_incompatibilidad_fun _mp_incompatibilidad_fun)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_INCOMPATIBILIDAD_FUN);
                CNXSIGRH3.AddInParameter(icom, "p_if_id", DbType.Int32, _mp_incompatibilidad_fun.if_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__mp_incompatibilidad_fun(cls_mp_incompatibilidad_fun _mp_incompatibilidad_fun)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_INCOMPATIBILIDAD_FUN);
                CNXSIGRH3.AddInParameter(icom, "p_if_id", DbType.Int32, _mp_incompatibilidad_fun.if_id);
                CNXSIGRH3.AddInParameter(icom, "p_if_per_id", DbType.Int32, _mp_incompatibilidad_fun.if_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_if_per_id_pariente", DbType.Int32, _mp_incompatibilidad_fun.if_per_id_pariente);
                CNXSIGRH3.AddInParameter(icom, "p_if_parentesco", DbType.Int32, _mp_incompatibilidad_fun.if_parentesco);
                CNXSIGRH3.AddInParameter(icom, "p_if_estado", DbType.String, _mp_incompatibilidad_fun.if_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerId__mp_incompatibilidad_fun(cls_mp_incompatibilidad_fun _mp_incompatibilidad_fun)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_INCOMPATIBILIDAD_FUN);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                _mp_incompatibilidad_fun.if_id = Convert.ToInt32(ds.Tables[0].Rows[0]["if_id"]);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerRegistro__mp_incompatibilidad_fun(cls_mp_incompatibilidad_fun _mp_incompatibilidad_fun)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_INCOMPATIBILIDAD_FUN);
                CNXSIGRH3.AddInParameter(icom, "p_if_id", DbType.Int32, _mp_incompatibilidad_fun.if_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["if_id"] != DBNull.Value && ds.Tables[0].Rows[0]["if_id"].ToString().Trim() != "") { _mp_incompatibilidad_fun.if_id = Convert.ToInt32(ds.Tables[0].Rows[0]["if_id"]); }
                    if (ds.Tables[0].Rows[0]["if_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["if_per_id"].ToString().Trim() != "") { _mp_incompatibilidad_fun.if_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["if_per_id"]); }
                    if (ds.Tables[0].Rows[0]["if_per_id_pariente"] != DBNull.Value && ds.Tables[0].Rows[0]["if_per_id_pariente"].ToString().Trim() != "") { _mp_incompatibilidad_fun.if_per_id_pariente = Convert.ToInt32(ds.Tables[0].Rows[0]["if_per_id_pariente"]); }
                    if (ds.Tables[0].Rows[0]["if_parentesco"] != DBNull.Value && ds.Tables[0].Rows[0]["if_parentesco"].ToString().Trim() != "") { _mp_incompatibilidad_fun.if_parentesco = Convert.ToInt32(ds.Tables[0].Rows[0]["if_parentesco"]); }
                    if (ds.Tables[0].Rows[0]["if_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["if_estado"].ToString().Trim() != "") { _mp_incompatibilidad_fun.if_estado = Convert.ToString(ds.Tables[0].Rows[0]["if_estado"]); }
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__mp_incompatibilidad_fun(
            string if_id,
            string if_per_id,
            string if_per_id_pariente,
            string if_parentesco,
            string if_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_INCOMPATIBILIDAD_FUN);

                if (if_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_if_id", DbType.Int32, Convert.ToInt32(if_id)); }
                if (if_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_if_per_id", DbType.Int32, Convert.ToInt32(if_per_id)); }
                if (if_per_id_pariente.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_if_per_id_pariente", DbType.Int32, Convert.ToInt32(if_per_id_pariente)); }
                if (if_parentesco.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_if_parentesco", DbType.Int32, Convert.ToInt32(if_parentesco)); }
                if (if_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_if_estado", DbType.String, Convert.ToString(if_estado)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__mp_incompatibilidad_fun()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_INCOMPATIBILIDAD_FUN);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de coincidencias dependiendo del funcionario
        public override DataSet ObtenerTablaGrillaC__mp_incompatibilidad_fun(
            string per_id,
            string per_ap_paterno,
            string per_ap_materno)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_INCOMPATIBILIDAD_FUN);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_if_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
                if (per_ap_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, Convert.ToString(per_ap_paterno)); }
                if (per_ap_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, Convert.ToString(per_ap_materno)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _MP_TIPO_ABONO
        public override DataSet Adicionar__mp_tipo_abono(cls_mp_tipo_abono _mp_tipo_abono)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ABONO);
                CNXSIGRH3.AddInParameter(icom, "p_cb_cod_banco", DbType.Int32, _mp_tipo_abono.cb_cod_banco);
                CNXSIGRH3.AddInParameter(icom, "p_cb_per_id", DbType.Int32, _mp_tipo_abono.cb_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_cb_num_cuenta", DbType.String, _mp_tipo_abono.cb_num_cuenta);
                CNXSIGRH3.AddInParameter(icom, "p_cb_tipo_abono", DbType.String, _mp_tipo_abono.cb_tipo_abono);
                CNXSIGRH3.AddInParameter(icom, "p_cb_fecha_formulario", DbType.DateTime, _mp_tipo_abono.cb_fecha_formulario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__mp_tipo_abono(cls_mp_tipo_abono _mp_tipo_abono)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ABONO);
                CNXSIGRH3.AddInParameter(icom, "p_cb_id", DbType.Int32, _mp_tipo_abono.cb_id);
                CNXSIGRH3.AddInParameter(icom, "p_cb_estado", DbType.String, _mp_tipo_abono.cb_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__mp_tipo_abono(cls_mp_tipo_abono _mp_tipo_abono)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ABONO);
                //CNXSIGRH3.AddInParameter(icom, "p_cb_id", DbType.Int32, _mp_tipo_abono.cb_id);
                //CNXSIGRH3.AddInParameter(icom, "p_cb_cod_banco", DbType.Int32, _mp_tipo_abono.cb_cod_banco);
                CNXSIGRH3.AddInParameter(icom, "p_cb_per_id", DbType.Int32, _mp_tipo_abono.cb_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_cb_num_cuenta", DbType.String, _mp_tipo_abono.cb_num_cuenta);
                //CNXSIGRH3.AddInParameter(icom, "p_cb_tipo_abono", DbType.String, _mp_tipo_abono.cb_tipo_abono);
                //CNXSIGRH3.AddInParameter(icom, "p_cb_fecha_mod", DbType.DateTime, _mp_tipo_abono.cb_fecha_mod);
                //CNXSIGRH3.AddInParameter(icom, "p_cb_estado", DbType.String, _mp_tipo_abono.cb_estado);
                CNXSIGRH3.AddInParameter(icom, "p_cb_secuencial", DbType.Int32, _mp_tipo_abono.cb_secuencial);
                CNXSIGRH3.AddInParameter(icom, "p_cb_fecha_formulario", DbType.DateTime, _mp_tipo_abono.cb_fecha_formulario);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerId__mp_tipo_abono(cls_mp_tipo_abono _mp_tipo_abono)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ABONO);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                _mp_tipo_abono.cb_id = Convert.ToInt32(ds.Tables[0].Rows[0]["cb_id"]);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerRegistro__mp_tipo_abono(cls_mp_tipo_abono _mp_tipo_abono)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ABONO);
                CNXSIGRH3.AddInParameter(icom, "p_cb_id", DbType.Int32, _mp_tipo_abono.cb_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cb_id"] != DBNull.Value && ds.Tables[0].Rows[0]["cb_id"].ToString().Trim() != "") { _mp_tipo_abono.cb_id = Convert.ToInt32(ds.Tables[0].Rows[0]["cb_id"]); }
                    if (ds.Tables[0].Rows[0]["cb_cod_banco"] != DBNull.Value && ds.Tables[0].Rows[0]["cb_cod_banco"].ToString().Trim() != "") { _mp_tipo_abono.cb_cod_banco = Convert.ToInt32(ds.Tables[0].Rows[0]["cb_cod_banco"]); }
                    if (ds.Tables[0].Rows[0]["cb_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["cb_per_id"].ToString().Trim() != "") { _mp_tipo_abono.cb_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["cb_per_id"]); }
                    if (ds.Tables[0].Rows[0]["cb_num_cuenta"] != DBNull.Value && ds.Tables[0].Rows[0]["cb_num_cuenta"].ToString().Trim() != "") { _mp_tipo_abono.cb_num_cuenta = Convert.ToString(ds.Tables[0].Rows[0]["cb_num_cuenta"]); }
                    if (ds.Tables[0].Rows[0]["cb_tipo_abono"] != DBNull.Value && ds.Tables[0].Rows[0]["cb_tipo_abono"].ToString().Trim() != "") { _mp_tipo_abono.cb_tipo_abono = Convert.ToString(ds.Tables[0].Rows[0]["cb_tipo_abono"]); }
                    if (ds.Tables[0].Rows[0]["cb_fecha_mod"] != DBNull.Value && ds.Tables[0].Rows[0]["cb_fecha_mod"].ToString().Trim() != "") { _mp_tipo_abono.cb_fecha_mod = Convert.ToDateTime(ds.Tables[0].Rows[0]["cb_fecha_mod"]); }
                    if (ds.Tables[0].Rows[0]["cb_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["cb_estado"].ToString().Trim() != "") { _mp_tipo_abono.cb_estado = Convert.ToString(ds.Tables[0].Rows[0]["cb_estado"]); }
                    if (ds.Tables[0].Rows[0]["cb_secuencial"] != DBNull.Value && ds.Tables[0].Rows[0]["cb_secuencial"].ToString().Trim() != "") { _mp_tipo_abono.cb_secuencial = Convert.ToInt32(ds.Tables[0].Rows[0]["cb_secuencial"]); }
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerGrillaCuentas(cls_mp_tipo_abono _mp_tipo_abono)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ABONO);

                CNXSIGRH3.AddInParameter(icom, "p_cb_per_id", DbType.Int32, _mp_tipo_abono.cb_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaCombo__mp_tipo_abono()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ABONO);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerUltimoTipoAbono__mp_tipoabono(cls_mp_tipo_abono _mp_tipo_abono)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ABONO);
                CNXSIGRH3.AddInParameter(icom, "p_cb_per_id", DbType.Int32, _mp_tipo_abono.cb_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet VerificarCuentaExistente__mp_tipoabono(cls_mp_tipo_abono _mp_tipo_abono)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ABONO);
                CNXSIGRH3.AddInParameter(icom, "p_cb_per_id", DbType.Int32, _mp_tipo_abono.cb_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_cb_num_cuenta", DbType.String, _mp_tipo_abono.cb_num_cuenta);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObteneTipoAbonoporPersona__mp_tipoabono(cls_mp_tipo_abono _mp_tipo_abono)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ABONO);
                CNXSIGRH3.AddInParameter(icom, "p_cb_per_id", DbType.Int32, _mp_tipo_abono.cb_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObteneTipoAbonoVigente(cls_mp_tipo_abono _mp_tipo_abono)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_TIPO_ABONO);
                CNXSIGRH3.AddInParameter(icom, "p_cb_per_id", DbType.Int32, _mp_tipo_abono.cb_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _PERSONA
        public override bool Adicionar__persona(cls_persona _persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);
                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _persona.per_id);
                CNXSIGRH3.AddInParameter(icom, "p_per_tipo_doc", DbType.Int32, _persona.per_tipo_doc);
                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _persona.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_per_lugar_exp", DbType.Int32, _persona.per_lugar_exp);
                CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, _persona.per_ap_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, _persona.per_ap_materno);
                CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, _persona.per_nombres + " ");
                CNXSIGRH3.AddInParameter(icom, "p_per_ap_casada", DbType.String, _persona.per_ap_casada);
                CNXSIGRH3.AddInParameter(icom, "p_per_sexo", DbType.String, _persona.per_sexo);

                //CNXSIGRH3.AddInParameter(icom, "p_per_fecha_nac", DbType.DateTime, Convert.ToDateTime(_persona.per_fecha_nac));
                CultureInfo ci = new CultureInfo("it-IT", false);
                CNXSIGRH3.AddInParameter(icom, "p_per_fecha_nac", DbType.DateTime, Convert.ToDateTime(_persona.per_fecha_nac.ToString(ci)));
                //CNXSIGRH3.AddInParameter(icom, "p_per_fecha_nac", DbType.String, _persona.per_fecha_nac.ToString("u").Substring(0, _persona.per_fecha_nac.ToString("u").Length-1));

                CNXSIGRH3.AddInParameter(icom, "p_per_procedencia", DbType.Int32, _persona.per_procedencia);
                CNXSIGRH3.AddInParameter(icom, "p_per_serie_libreta_militar", DbType.String, _persona.per_serie_libreta_militar);
                CNXSIGRH3.AddInParameter(icom, "p_per_lugar_nac", DbType.Int32, _persona.per_lugar_nac);
                CNXSIGRH3.AddInParameter(icom, "p_per_estado_civil", DbType.Int32, _persona.per_estado_civil);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool AdicionarFoto(cls_persona _persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);
                //CNXSIGRH3.AddInParameter(icom, "p_fp_id", DbType.Int32, _persona.fp_id);
                CNXSIGRH3.AddInParameter(icom, "p_fp_per_id", DbType.Int32, _persona.per_id);
                CNXSIGRH3.AddInParameter(icom, "p_fp_foto", DbType.Binary, _persona.fp_foto);
                CNXSIGRH3.AddInParameter(icom, "p_fp_estado", DbType.String, _persona.fp_estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C13");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet FileVirtual(int cod_file, byte[] foto, int req_id, string fecha_doc, string fecha_registro, int per_id, string obs, string estado, string accion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_kd_file_virtual");
                CNXSIGRH3.AddInParameter(icom, "fv_file_id", DbType.Int32, cod_file);
                CNXSIGRH3.AddInParameter(icom, "fv_imagen_documento", DbType.Binary, foto);
                CNXSIGRH3.AddInParameter(icom, "fv_rq_id", DbType.Int32, req_id);
                if(fecha_doc!="")
                    CNXSIGRH3.AddInParameter(icom, "fv_fecha_doc", DbType.Date, Convert.ToDateTime(fecha_doc));
                else
                    CNXSIGRH3.AddInParameter(icom, "fv_fecha_doc", DbType.Date, Convert.ToDateTime("1/1/2022"));
                if (fecha_registro!="")
                    CNXSIGRH3.AddInParameter(icom, "fv_fecha_registro", DbType.Date, Convert.ToDateTime(fecha_registro));
                else
                    CNXSIGRH3.AddInParameter(icom, "fv_fecha_registro", DbType.Date, Convert.ToDateTime("1/1/2022"));

                CNXSIGRH3.AddInParameter(icom, "fv_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "fv_observacion", DbType.String, obs);
                CNXSIGRH3.AddInParameter(icom, "fv_estado", DbType.String, estado);
                CNXSIGRH3.AddInParameter(icom, "fv_accion", DbType.String, accion);
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override int AdicionarFileVirtualPDF(int cod_file, byte[] foto, int req_id, string fecha_doc, string fecha_registro, int per_id, string obs, string estado, string nombre, string accion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_kd_file_virtualPDF");
                CNXSIGRH3.AddInParameter(icom, "fv_file_id", DbType.Int32, cod_file);
                CNXSIGRH3.AddInParameter(icom, "fv_imagen_documento", DbType.Binary, foto);
                CNXSIGRH3.AddInParameter(icom, "fv_rq_id", DbType.Int32, req_id);
                if (fecha_doc != "")
                    CNXSIGRH3.AddInParameter(icom, "fv_fecha_doc", DbType.Date, Convert.ToDateTime(fecha_doc));
                else
                    CNXSIGRH3.AddInParameter(icom, "fv_fecha_doc", DbType.Date, Convert.ToDateTime("1/1/2022"));
                if (fecha_registro != "")
                    CNXSIGRH3.AddInParameter(icom, "fv_fecha_registro", DbType.Date, Convert.ToDateTime(fecha_registro));
                else
                    CNXSIGRH3.AddInParameter(icom, "fv_fecha_registro", DbType.Date, Convert.ToDateTime("1/1/2022"));

                CNXSIGRH3.AddInParameter(icom, "fv_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "fv_observacion", DbType.String, obs);
                CNXSIGRH3.AddInParameter(icom, "fv_estado", DbType.String, estado);
                CNXSIGRH3.AddInParameter(icom, "fv_nombre", DbType.String, nombre);
                CNXSIGRH3.AddInParameter(icom, "fv_accion", DbType.String, "A2");
                int id=Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom).ToString());
                return id;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet MostrarFileVirtualPDF(int per_id,  string observacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_kd_file_virtualPDF");
                CNXSIGRH3.AddInParameter(icom, "fv_observacion", DbType.String, observacion);
                CNXSIGRH3.AddInParameter(icom, "fv_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "fv_accion", DbType.String, "C1");
                return CNXSIGRH3.ExecuteDataSet(icom);                
            }
            catch (Exception ex) { throw ex; }
        }
        public override IDataReader MostrarFileVirtualPDF_DR(int per_id, string observacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_kd_file_virtualPDF");
                CNXSIGRH3.AddInParameter(icom, "fv_observacion", DbType.String, observacion);
                CNXSIGRH3.AddInParameter(icom, "fv_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "fv_accion", DbType.String, "C1");
                return CNXSIGRH3.ExecuteReader(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet MostrarFileVirtualPDF_PorPdf_id(int per_id, int pdf_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_kd_file_virtualPDF");
                CNXSIGRH3.AddInParameter(icom, "fv_file_id", DbType.Int32, pdf_id);
                CNXSIGRH3.AddInParameter(icom, "fv_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "fv_accion", DbType.String, "C2");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet MostrarFileVirtualPDF_PorPdf_Per_id(int per_id, int pdf_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_kd_file_virtualPDF");
                CNXSIGRH3.AddInParameter(icom, "fv_file_id", DbType.Int32, pdf_id);
                CNXSIGRH3.AddInParameter(icom, "fv_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "fv_accion", DbType.String, "C5");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet EliminarFileVirtualPDF(int pdf_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_kd_file_virtualPDF");
                CNXSIGRH3.AddInParameter(icom, "fv_file_id", DbType.Int32, pdf_id);
                CNXSIGRH3.AddInParameter(icom, "fv_accion", DbType.String, "B1");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ActualizarFileVirtualPDF(DateTime fecha_doc, string obs, int pdf_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_kd_file_virtualPDF");
                CNXSIGRH3.AddInParameter(icom, "fv_file_id", DbType.Int32, pdf_id);
                CNXSIGRH3.AddInParameter(icom, "fv_fecha_doc", DbType.DateTime, fecha_doc);
                CNXSIGRH3.AddInParameter(icom, "fv_observacion", DbType.String, obs);

                CNXSIGRH3.AddInParameter(icom, "fv_accion", DbType.String, "U");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool Eliminar__persona(cls_persona _persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);
                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _persona.per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__persona(cls_persona _persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);
                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _persona.per_id);
                CNXSIGRH3.AddInParameter(icom, "p_per_tipo_doc", DbType.Int32, _persona.per_tipo_doc);
                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _persona.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_per_lugar_exp", DbType.Int32, _persona.per_lugar_exp);
                CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, _persona.per_ap_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, _persona.per_ap_materno);
                CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, _persona.per_nombres);
                CNXSIGRH3.AddInParameter(icom, "p_per_ap_casada", DbType.String, _persona.per_ap_casada);
                CNXSIGRH3.AddInParameter(icom, "p_per_sexo", DbType.String, _persona.per_sexo);
                CNXSIGRH3.AddInParameter(icom, "p_per_fecha_nac", DbType.DateTime, _persona.per_fecha_nac);
                CNXSIGRH3.AddInParameter(icom, "p_per_procedencia", DbType.Int32, _persona.per_procedencia);
                CNXSIGRH3.AddInParameter(icom, "p_per_serie_libreta_militar", DbType.String, _persona.per_serie_libreta_militar);
                CNXSIGRH3.AddInParameter(icom, "p_per_lugar_nac", DbType.Int32, _persona.per_lugar_nac);
                CNXSIGRH3.AddInParameter(icom, "p_per_estado_civil", DbType.Int32, _persona.per_estado_civil);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerId__persona(cls_persona _persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                _persona.per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["per_id"]);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerRegistroFoto(cls_persona _persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrillaHM__persona(
    string per_id,
    string per_num_doc,
    string per_ap_paterno,
    string per_ap_materno,
    string per_nombres,
    string as_pr_id,
    string eo_id,
    string cp_ue,
    string ti_tipo,
    string as_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
                if (per_num_doc.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, Convert.ToString(per_num_doc)); }
                if (per_ap_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, Convert.ToString(per_ap_paterno)); }
                if (per_ap_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, Convert.ToString(per_ap_materno)); }
                if (per_nombres.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, Convert.ToString(per_nombres)); }
                if (as_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pr_id", DbType.Int32, Convert.ToInt32(as_pr_id)); }
                if (eo_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_eo_id", DbType.String, Convert.ToString(eo_id)); }
                if (cp_ue.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_cp_ue", DbType.String, Convert.ToString(cp_ue)); }
                if (ti_tipo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ti_tipo", DbType.String, Convert.ToString(ti_tipo)); }
                if (as_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_estado", DbType.String, Convert.ToString(as_estado)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (MICM) Consulta un registro de la tabla _persona
        public override bool ObtenerRegistro__persona(cls_persona _persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);
                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _persona.per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["per_id"].ToString().Trim() != "") { _persona.per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["per_id"]); }
                    if (ds.Tables[0].Rows[0]["per_tipo_doc"] != DBNull.Value && ds.Tables[0].Rows[0]["per_tipo_doc"].ToString().Trim() != " ") { _persona.per_tipo_doc = Convert.ToInt32(ds.Tables[0].Rows[0]["per_tipo_doc"]); }
                    if (ds.Tables[0].Rows[0]["per_num_doc"] != DBNull.Value && ds.Tables[0].Rows[0]["per_num_doc"].ToString().Trim() != "") { _persona.per_num_doc = Convert.ToString(ds.Tables[0].Rows[0]["per_num_doc"]); }
                    if (ds.Tables[0].Rows[0]["per_lugar_exp"] != DBNull.Value && ds.Tables[0].Rows[0]["per_lugar_exp"].ToString().Trim() != "") { _persona.per_lugar_exp = Convert.ToInt32(ds.Tables[0].Rows[0]["per_lugar_exp"]); }
                    if (ds.Tables[0].Rows[0]["per_ap_paterno"] != DBNull.Value && ds.Tables[0].Rows[0]["per_ap_paterno"].ToString().Trim() != "") { _persona.per_ap_paterno = Convert.ToString(ds.Tables[0].Rows[0]["per_ap_paterno"]); }
                    if (ds.Tables[0].Rows[0]["per_ap_materno"] != DBNull.Value && ds.Tables[0].Rows[0]["per_ap_materno"].ToString().Trim() != "") { _persona.per_ap_materno = Convert.ToString(ds.Tables[0].Rows[0]["per_ap_materno"]); }
                    if (ds.Tables[0].Rows[0]["per_nombres"] != DBNull.Value && ds.Tables[0].Rows[0]["per_nombres"].ToString().Trim() != "") { _persona.per_nombres = Convert.ToString(ds.Tables[0].Rows[0]["per_nombres"]); }
                    if (ds.Tables[0].Rows[0]["per_ap_casada"] != DBNull.Value && ds.Tables[0].Rows[0]["per_ap_casada"].ToString().Trim() != "") { _persona.per_ap_casada = Convert.ToString(ds.Tables[0].Rows[0]["per_ap_casada"]); }
                    if (ds.Tables[0].Rows[0]["per_sexo"] != DBNull.Value && ds.Tables[0].Rows[0]["per_sexo"].ToString().Trim() != "") { _persona.per_sexo = Convert.ToString(ds.Tables[0].Rows[0]["per_sexo"]); }
                    if (ds.Tables[0].Rows[0]["per_fecha_nac"] != DBNull.Value && ds.Tables[0].Rows[0]["per_fecha_nac"].ToString().Trim() != "") { _persona.per_fecha_nac = Convert.ToDateTime(ds.Tables[0].Rows[0]["per_fecha_nac"]); }
                    if (ds.Tables[0].Rows[0]["per_procedencia"] != DBNull.Value && ds.Tables[0].Rows[0]["per_procedencia"].ToString().Trim() != "") { _persona.per_procedencia = Convert.ToInt32(ds.Tables[0].Rows[0]["per_procedencia"]); }
                    if (ds.Tables[0].Rows[0]["per_serie_libreta_militar"] != DBNull.Value && ds.Tables[0].Rows[0]["per_serie_libreta_militar"].ToString().Trim() != "") { _persona.per_serie_libreta_militar = Convert.ToString(ds.Tables[0].Rows[0]["per_serie_libreta_militar"]); }
                    if (ds.Tables[0].Rows[0]["per_lugar_nac"] != DBNull.Value && ds.Tables[0].Rows[0]["per_lugar_nac"].ToString().Trim() != "") { _persona.per_lugar_nac = Convert.ToInt32(ds.Tables[0].Rows[0]["per_lugar_nac"]); }
                    if (ds.Tables[0].Rows[0]["per_estado_civil"] != DBNull.Value && ds.Tables[0].Rows[0]["per_estado_civil"].ToString().Trim() != "") { _persona.per_estado_civil = Convert.ToInt32(ds.Tables[0].Rows[0]["per_estado_civil"]); }
                    if (ds.Tables[0].Rows[0]["per_tipo_doc_literal"] != DBNull.Value && ds.Tables[0].Rows[0]["per_tipo_doc_literal"].ToString().Trim() != "") { _persona.per_tipo_doc_literal = Convert.ToString(ds.Tables[0].Rows[0]["per_tipo_doc_literal"]); }
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__persona(
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrilla__personaLicencias(
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C28");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaCombo__persona()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (KCPB) Ayuda a obtener la lista de personal sin asignaci�n
        public override DataSet ObtenerTablaGrillaSA__persona(
            string per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
                if (per_num_doc.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, Convert.ToString(per_num_doc)); }
                if (per_ap_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, Convert.ToString(per_ap_paterno)); }
                if (per_ap_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, Convert.ToString(per_ap_materno)); }
                if (per_nombres.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, Convert.ToString(per_nombres)); }
                if (per_ap_casada.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_casada", DbType.String, Convert.ToString(per_ap_casada)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (KCPB) Consulta un registro de la tabla _persona
        public override DataSet ObtenerRegistroX__persona(cls_persona _persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);
                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _persona.per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerRegistroX__personaCV(cls_persona _persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);
                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _persona.per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C24");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrilla__persona_planta(
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrilla__persona_plantaVacaciones(
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C26");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (JQC) Funciones
        public override DataSet ObtenerTablaGrilla__personaGamlp_AfiliacionEGS(
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
            string per_estado_civil,
            string fa_id,
            string ae_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                if (fa_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_fa_id", DbType.Int32, Convert.ToInt32(fa_id)); }
                if (ae_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_ae_estado", DbType.String, Convert.ToString(ae_estado)); }

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__persona_plantaTecLab(
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
            string per_estado_civil,
            int pr_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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

                CNXSIGRH3.AddInParameter(icom, "p_gestion_selec", DbType.String, pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos) Buscador Items Planta - FE, FC, FD
        public override DataSet ObtenerTablaGrillaPCED__persona(
            string per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
                if (per_num_doc.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, Convert.ToString(per_num_doc)); }
                if (per_ap_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, Convert.ToString(per_ap_paterno)); }
                if (per_ap_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, Convert.ToString(per_ap_materno)); }
                if (per_nombres.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, Convert.ToString(per_nombres)); }
                if (per_ap_casada.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_ap_casada", DbType.String, Convert.ToString(per_ap_casada)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C16");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet VerificarNuevoFuncionario(string ci, int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);
                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, ci);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C22");
                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.String, per_id);
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool Actualizar__personaConLibreta(cls_persona _persona)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);
                CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, _persona.per_id);
                CNXSIGRH3.AddInParameter(icom, "p_per_tipo_doc", DbType.Int32, _persona.per_tipo_doc);
                CNXSIGRH3.AddInParameter(icom, "p_per_num_doc", DbType.String, _persona.per_num_doc);
                CNXSIGRH3.AddInParameter(icom, "p_per_lugar_exp", DbType.Int32, _persona.per_lugar_exp);
                CNXSIGRH3.AddInParameter(icom, "p_per_ap_paterno", DbType.String, _persona.per_ap_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_per_ap_materno", DbType.String, _persona.per_ap_materno);
                CNXSIGRH3.AddInParameter(icom, "p_per_nombres", DbType.String, _persona.per_nombres);
                CNXSIGRH3.AddInParameter(icom, "p_per_ap_casada", DbType.String, _persona.per_ap_casada);
                CNXSIGRH3.AddInParameter(icom, "p_per_sexo", DbType.String, _persona.per_sexo);
                CNXSIGRH3.AddInParameter(icom, "p_per_fecha_nac", DbType.DateTime, _persona.per_fecha_nac);
                CNXSIGRH3.AddInParameter(icom, "p_per_procedencia", DbType.Int32, _persona.per_procedencia);
                CNXSIGRH3.AddInParameter(icom, "p_per_serie_libreta_militar", DbType.String, _persona.per_serie_libreta_militar);
                CNXSIGRH3.AddInParameter(icom, "p_per_lugar_nac", DbType.Int32, _persona.per_lugar_nac);
                CNXSIGRH3.AddInParameter(icom, "p_per_estado_civil", DbType.Int32, _persona.per_estado_civil);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "CC");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _PERSONA_DOMICILIO
        public override bool Adicionar__persona_domicilio(cls_persona_domicilio _persona_domicilio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_DOMICILIO);
                CNXSIGRH3.AddInParameter(icom, "p_perd_id", DbType.Int32, _persona_domicilio.perd_id);
                CNXSIGRH3.AddInParameter(icom, "p_perd_per_id", DbType.Int32, _persona_domicilio.perd_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_perd_ciudad_residencia", DbType.Int32, _persona_domicilio.perd_ciudad_residencia);
                CNXSIGRH3.AddInParameter(icom, "p_perd_zona", DbType.Int32, _persona_domicilio.perd_zona);
                CNXSIGRH3.AddInParameter(icom, "p_perd_tipo_via", DbType.Int32, _persona_domicilio.perd_tipo_via);
                CNXSIGRH3.AddInParameter(icom, "p_perd_descripcion_via", DbType.String, _persona_domicilio.perd_descripcion_via);
                CNXSIGRH3.AddInParameter(icom, "p_perd_numero", DbType.String, _persona_domicilio.perd_numero);
                CNXSIGRH3.AddInParameter(icom, "p_perd_telefono", DbType.String, _persona_domicilio.perd_telefono);
                CNXSIGRH3.AddInParameter(icom, "p_perd_celular", DbType.String, _persona_domicilio.perd_celular);
                CNXSIGRH3.AddInParameter(icom, "p_perd_email", DbType.String, _persona_domicilio.perd_email);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool AdicionarDomicilioKardex(cls_persona_domicilio _persona_domicilio, int file_id_cod, string per_num_lib)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_DOMICILIO);
                CNXSIGRH3.AddInParameter(icom, "p_perd_id", DbType.Int32, _persona_domicilio.perd_id);
                CNXSIGRH3.AddInParameter(icom, "p_perd_per_id", DbType.Int32, _persona_domicilio.perd_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_perd_ciudad_residencia", DbType.Int32, _persona_domicilio.perd_ciudad_residencia);
                CNXSIGRH3.AddInParameter(icom, "p_perd_zona", DbType.Int32, _persona_domicilio.perd_zona);
                CNXSIGRH3.AddInParameter(icom, "p_perd_tipo_via", DbType.Int32, _persona_domicilio.perd_tipo_via);
                CNXSIGRH3.AddInParameter(icom, "p_perd_descripcion_via", DbType.String, _persona_domicilio.perd_descripcion_via);
                CNXSIGRH3.AddInParameter(icom, "p_perd_numero", DbType.String, _persona_domicilio.perd_numero);

                CNXSIGRH3.AddInParameter(icom, "p_perd_edificio", DbType.String, _persona_domicilio.perd_edificio);
                CNXSIGRH3.AddInParameter(icom, "p_perd_bloque", DbType.String, _persona_domicilio.perd_bloque);
                CNXSIGRH3.AddInParameter(icom, "p_perd_piso", DbType.String, _persona_domicilio.perd_piso);
                CNXSIGRH3.AddInParameter(icom, "p_perd_dpto", DbType.String, _persona_domicilio.perd_dpto);


                CNXSIGRH3.AddInParameter(icom, "p_perd_telefono", DbType.String, _persona_domicilio.perd_telefono);
                CNXSIGRH3.AddInParameter(icom, "p_perd_celular", DbType.String, _persona_domicilio.perd_celular);
                CNXSIGRH3.AddInParameter(icom, "p_perd_email_trabajo", DbType.String, _persona_domicilio.perd_email_trabajo);
                CNXSIGRH3.AddInParameter(icom, "p_perd_email", DbType.String, _persona_domicilio.perd_email);

                CNXSIGRH3.AddInParameter(icom, "p_perd_fam_emergencia", DbType.String, _persona_domicilio.perd_fam_emergencia);
                CNXSIGRH3.AddInParameter(icom, "p_perd_dir_emergencia", DbType.String, _persona_domicilio.perd_dir_emergencia);
                CNXSIGRH3.AddInParameter(icom, "p_perd_tel_emergencia", DbType.String, _persona_domicilio.perd_tel_emergencia);
                CNXSIGRH3.AddInParameter(icom, "p_perd_coordenadas", DbType.String, _persona_domicilio.perd_coordenadas);

                CNXSIGRH3.AddInParameter(icom, "p_file_id", DbType.Int32, file_id_cod);
                CNXSIGRH3.AddInParameter(icom, "p_per_serie_libreta_militar", DbType.String, per_num_lib);

                CNXSIGRH3.AddInParameter(icom, "p_perd_usuario_creacion", DbType.Int32, _persona_domicilio.perd_usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__persona_domicilio(cls_persona_domicilio _persona_domicilio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_DOMICILIO);
                CNXSIGRH3.AddInParameter(icom, "p_perd_id", DbType.Int32, _persona_domicilio.perd_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__persona_domicilio(cls_persona_domicilio _persona_domicilio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_DOMICILIO);
                CNXSIGRH3.AddInParameter(icom, "p_perd_id", DbType.Int32, _persona_domicilio.perd_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerRegistro__persona_domicilio(cls_persona_domicilio _persona_domicilio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_DOMICILIO);
                CNXSIGRH3.AddInParameter(icom, "p_perd_id", DbType.Int32, _persona_domicilio.perd_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["perd_id"] != DBNull.Value && ds.Tables[0].Rows[0]["perd_id"].ToString().Trim() != "") { _persona_domicilio.perd_id = Convert.ToInt32(ds.Tables[0].Rows[0]["perd_id"]); }
                if (ds.Tables[0].Rows[0]["perd_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["perd_per_id"].ToString().Trim() != "") { _persona_domicilio.perd_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["perd_per_id"]); }
                if (ds.Tables[0].Rows[0]["perd_ciudad_residencia"] != DBNull.Value && ds.Tables[0].Rows[0]["perd_ciudad_residencia"].ToString().Trim() != "") { _persona_domicilio.perd_ciudad_residencia = Convert.ToInt32(ds.Tables[0].Rows[0]["perd_ciudad_residencia"]); }
                if (ds.Tables[0].Rows[0]["perd_zona"] != DBNull.Value && ds.Tables[0].Rows[0]["perd_zona"].ToString().Trim() != "") { _persona_domicilio.perd_zona = Convert.ToInt32(ds.Tables[0].Rows[0]["perd_zona"]); }
                if (ds.Tables[0].Rows[0]["perd_tipo_via"] != DBNull.Value && ds.Tables[0].Rows[0]["perd_tipo_via"].ToString().Trim() != "") { _persona_domicilio.perd_tipo_via = Convert.ToInt32(ds.Tables[0].Rows[0]["perd_tipo_via"]); }
                if (ds.Tables[0].Rows[0]["perd_descripcion_via"] != DBNull.Value && ds.Tables[0].Rows[0]["perd_descripcion_via"].ToString().Trim() != "") { _persona_domicilio.perd_descripcion_via = Convert.ToString(ds.Tables[0].Rows[0]["perd_descripcion_via"]); }
                if (ds.Tables[0].Rows[0]["perd_numero"] != DBNull.Value && ds.Tables[0].Rows[0]["perd_numero"].ToString().Trim() != "") { _persona_domicilio.perd_numero = Convert.ToString(ds.Tables[0].Rows[0]["perd_numero"]); }
                if (ds.Tables[0].Rows[0]["perd_telefono"] != DBNull.Value && ds.Tables[0].Rows[0]["perd_telefono"].ToString().Trim() != "") { _persona_domicilio.perd_telefono = Convert.ToString(ds.Tables[0].Rows[0]["perd_telefono"]); }
                if (ds.Tables[0].Rows[0]["perd_celular"] != DBNull.Value && ds.Tables[0].Rows[0]["perd_celular"].ToString().Trim() != "") { _persona_domicilio.perd_celular = Convert.ToString(ds.Tables[0].Rows[0]["perd_celular"]); }
                if (ds.Tables[0].Rows[0]["perd_email"] != DBNull.Value && ds.Tables[0].Rows[0]["perd_email"].ToString().Trim() != "") { _persona_domicilio.perd_email = Convert.ToString(ds.Tables[0].Rows[0]["perd_email"]); }
                if (ds.Tables[0].Rows[0]["perd_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["perd_estado"].ToString().Trim() != "") { _persona_domicilio.perd_estado = Convert.ToString(ds.Tables[0].Rows[0]["perd_estado"]); }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__persona_domicilio(
            string perd_id,
            string perd_per_id,
            string perd_ciudad_residencia,
            string perd_zona,
            string perd_tipo_via,
            string perd_descripcion_via,
            string perd_numero,
            string perd_telefono,
            string perd_celular,
            string perd_email,
            string perd_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_DOMICILIO);

                if (perd_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_perd_id", DbType.Int32, Convert.ToInt32(perd_id)); }
                if (perd_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_perd_per_id", DbType.Int32, Convert.ToInt32(perd_per_id)); }
                if (perd_ciudad_residencia.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_perd_ciudad_residencia", DbType.Int32, Convert.ToInt32(perd_ciudad_residencia)); }
                if (perd_zona.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_perd_zona", DbType.Int32, Convert.ToInt32(perd_zona)); }
                if (perd_tipo_via.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_perd_tipo_via", DbType.Int32, Convert.ToInt32(perd_tipo_via)); }
                if (perd_descripcion_via.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_perd_descripcion_via", DbType.String, Convert.ToString(perd_descripcion_via)); }
                if (perd_numero.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_perd_numero", DbType.Int32, Convert.ToString(perd_numero)); }
                if (perd_telefono.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_perd_telefono", DbType.String, Convert.ToString(perd_telefono)); }
                if (perd_celular.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_perd_celular", DbType.String, Convert.ToString(perd_celular)); }
                if (perd_email.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_perd_email", DbType.String, Convert.ToString(perd_email)); }
                if (perd_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_perd_estado", DbType.String, Convert.ToString(perd_estado)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__persona_domicilio()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_DOMICILIO);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerDatosFile(cls_persona_domicilio _persona_domicilio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_DOMICILIO);
                CNXSIGRH3.AddInParameter(icom, "p_perd_per_id", DbType.Int32, _persona_domicilio.perd_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet VerificarExisteFile(int file_id_cod)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_DOMICILIO);
                CNXSIGRH3.AddInParameter(icom, "p_file_id", DbType.Int32, file_id_cod);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ActualizarTelefonosFun(cls_persona_domicilio _persona_domicilio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_DOMICILIO);
                CNXSIGRH3.AddInParameter(icom, "p_perd_id", DbType.Int32, _persona_domicilio.perd_id);
                CNXSIGRH3.AddInParameter(icom, "p_perd_celular", DbType.Int32, _persona_domicilio.perd_celular);
                CNXSIGRH3.AddInParameter(icom, "p_perd_telefono", DbType.Int32, _persona_domicilio.perd_telefono);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool Actualizar__Informacion_persona_domicilio(cls_persona_domicilio _persona_domicilio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_DOMICILIO);
                CNXSIGRH3.AddInParameter(icom, "p_perd_zona", DbType.Int32, _persona_domicilio.perd_zona);
                CNXSIGRH3.AddInParameter(icom, "p_perd_tipo_via", DbType.Int32, _persona_domicilio.perd_tipo_via);
                CNXSIGRH3.AddInParameter(icom, "p_perd_descripcion_via", DbType.String, _persona_domicilio.perd_descripcion_via);
                CNXSIGRH3.AddInParameter(icom, "p_perd_numero", DbType.String, _persona_domicilio.perd_numero);

                CNXSIGRH3.AddInParameter(icom, "p_perd_telefono", DbType.String, _persona_domicilio.perd_telefono);
                CNXSIGRH3.AddInParameter(icom, "p_perd_celular", DbType.String, _persona_domicilio.perd_celular);
                CNXSIGRH3.AddInParameter(icom, "p_perd_email", DbType.String, _persona_domicilio.perd_email);

                CNXSIGRH3.AddInParameter(icom, "p_perd_per_id", DbType.Int32, _persona_domicilio.perd_per_id);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "CC");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region _PERSONA_FAMILIARES
        public override bool Adicionar__persona_familiares(cls_persona_familiares _persona_familiares)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_FAMILIARES);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _persona_familiares.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_pf_tipo_parentesco", DbType.String, _persona_familiares.pf_tipo_parentesco);
                CNXSIGRH3.AddInParameter(icom, "p_pf_paterno", DbType.String, _persona_familiares.pf_paterno);
                CNXSIGRH3.AddInParameter(icom, "p_pf_materno", DbType.String, _persona_familiares.pf_materno);
                CNXSIGRH3.AddInParameter(icom, "p_pf_nombres", DbType.String, _persona_familiares.pf_nombres);
                CNXSIGRH3.AddInParameter(icom, "p_pf_ap_esposo", DbType.String, _persona_familiares.pf_ap_esposo);
                CNXSIGRH3.AddInParameter(icom, "p_pf_fecha_nac", DbType.DateTime, _persona_familiares.pf_fecha_nac);
                //CNXSIGRH3.AddInParameter(icom, "p_pf_estado_vivo", DbType.String, _persona_familiares.pf_estado_vivo);
                //CNXSIGRH3.AddInParameter(icom, "p_pf_fecha_defuncion", DbType.DateTime, _persona_familiares.pf_fecha_defuncion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__persona_familiares(cls_persona_familiares _persona_familiares)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_FAMILIARES);
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.Int32, _persona_familiares.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__persona_familiares(cls_persona_familiares _persona_familiares)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_FAMILIARES);
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.Int32, _persona_familiares.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ActualizarEstadoFam(cls_persona_familiares _persona_familiares)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_FAMILIARES);
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.Int32, _persona_familiares.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ObtenerId__persona_familiares(cls_persona_familiares _persona_familiares)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_FAMILIARES);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                _persona_familiares.pf_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pf_id"]);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerRegistro__persona_familiares(cls_persona_familiares _persona_familiares)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_FAMILIARES);
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.Int32, _persona_familiares.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                if (ds.Tables[0].Rows[0]["pf_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pf_id"].ToString().Trim() != "") { _persona_familiares.pf_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pf_id"]); }
                if (ds.Tables[0].Rows[0]["pf_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pf_per_id"].ToString().Trim() != "") { _persona_familiares.pf_per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pf_per_id"]); }
                if (ds.Tables[0].Rows[0]["pf_tipo_parentesco"] != DBNull.Value && ds.Tables[0].Rows[0]["pf_tipo_parentesco"].ToString().Trim() != "") { _persona_familiares.pf_tipo_parentesco = Convert.ToString(ds.Tables[0].Rows[0]["pf_tipo_parentesco"]); }
                if (ds.Tables[0].Rows[0]["pf_paterno"] != DBNull.Value && ds.Tables[0].Rows[0]["pf_paterno"].ToString().Trim() != "") { _persona_familiares.pf_paterno = Convert.ToString(ds.Tables[0].Rows[0]["pf_paterno"]); }
                if (ds.Tables[0].Rows[0]["pf_materno"] != DBNull.Value && ds.Tables[0].Rows[0]["pf_materno"].ToString().Trim() != "") { _persona_familiares.pf_materno = Convert.ToString(ds.Tables[0].Rows[0]["pf_materno"]); }
                if (ds.Tables[0].Rows[0]["pf_nombres"] != DBNull.Value && ds.Tables[0].Rows[0]["pf_nombres"].ToString().Trim() != "") { _persona_familiares.pf_nombres = Convert.ToString(ds.Tables[0].Rows[0]["pf_nombres"]); }
                if (ds.Tables[0].Rows[0]["pf_ap_esposo"] != DBNull.Value && ds.Tables[0].Rows[0]["pf_ap_esposo"].ToString().Trim() != "") { _persona_familiares.pf_ap_esposo = Convert.ToString(ds.Tables[0].Rows[0]["pf_ap_esposo"]); }
                if (ds.Tables[0].Rows[0]["pf_fecha_nac"] != DBNull.Value && ds.Tables[0].Rows[0]["pf_fecha_nac"].ToString().Trim() != "") { _persona_familiares.pf_fecha_nac = Convert.ToString(ds.Tables[0].Rows[0]["pf_fecha_nac"]); }
                if (ds.Tables[0].Rows[0]["pf_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["pf_estado"].ToString().Trim() != "") { _persona_familiares.pf_estado = Convert.ToString(ds.Tables[0].Rows[0]["pf_estado"]); }
                if (ds.Tables[0].Rows[0]["pf_estado_vivo"] != DBNull.Value && ds.Tables[0].Rows[0]["pf_estado_vivo"].ToString().Trim() != "") { _persona_familiares.pf_estado_vivo = Convert.ToString(ds.Tables[0].Rows[0]["pf_estado_vivo"]); }
                if (ds.Tables[0].Rows[0]["pf_fecha_defuncion"] != DBNull.Value && ds.Tables[0].Rows[0]["pf_fecha_defuncion"].ToString().Trim() != "") { _persona_familiares.pf_fecha_defuncion = Convert.ToDateTime(ds.Tables[0].Rows[0]["pf_fecha_defuncion"]); }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__persona_familiares(
            string pf_id,
            string pf_per_id,
            string pf_tipo_parentesco,
            string pf_paterno,
            string pf_materno,
            string pf_nombres,
            string pf_ap_esposo,
            string pf_fecha_nac,
            string pf_estado,
            string pf_estado_vivo,
            string pf_fecha_defuncion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_FAMILIARES);

                if (pf_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.Int32, Convert.ToInt32(pf_id)); }
                if (pf_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, Convert.ToInt32(pf_per_id)); }
                if (pf_tipo_parentesco.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pf_tipo_parentesco", DbType.String, Convert.ToString(pf_tipo_parentesco)); }
                if (pf_paterno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pf_paterno", DbType.String, Convert.ToString(pf_paterno)); }
                if (pf_materno.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pf_materno", DbType.String, Convert.ToString(pf_materno)); }
                if (pf_nombres.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pf_nombres", DbType.String, Convert.ToString(pf_nombres)); }
                if (pf_ap_esposo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pf_ap_esposo", DbType.String, Convert.ToString(pf_ap_esposo)); }
                if (pf_fecha_nac.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pf_fecha_nac", DbType.DateTime, Convert.ToDateTime(pf_fecha_nac)); }
                if (pf_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pf_estado", DbType.String, Convert.ToString(pf_estado)); }
                if (pf_estado_vivo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pf_estado_vivo", DbType.String, Convert.ToString(pf_estado_vivo)); }
                if (pf_fecha_defuncion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_pf_fecha_defuncion", DbType.DateTime, Convert.ToDateTime(pf_fecha_defuncion)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__persona_familiares()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_FAMILIARES);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerGrillaFamiliares(cls_persona_familiares _persona_familiares)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_FAMILIARES);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.Int32, _persona_familiares.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerFamilarX(cls_persona_familiares _persona_familiares)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_FAMILIARES);
                CNXSIGRH3.AddInParameter(icom, "p_pf_id", DbType.String, _persona_familiares.pf_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerPersonaFamilarX(cls_persona_familiares _persona_familiares)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA_FAMILIARES);
                CNXSIGRH3.AddInParameter(icom, "p_pf_per_id", DbType.String, _persona_familiares.pf_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerGrillaItemPlanta(cls_mp_cargo _mp_cargo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_CARGO);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C36");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _MP_ASIGNACION
        public override int Adicionar__mp_asignacion(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_ca_id", DbType.Int32, _mp_asignacion.as_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_fecha_inicio", DbType.DateTime, _mp_asignacion.as_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_as_fecha_fin", DbType.DateTime, _mp_asignacion.as_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_as_tipo_reg", DbType.String, _mp_asignacion.as_tipo_reg);
                CNXSIGRH3.AddInParameter(icom, "p_as_tipo_mov", DbType.String, _mp_asignacion.as_tipo_mov);
                CNXSIGRH3.AddInParameter(icom, "p_as_usuario_creacion", DbType.Int32, _mp_asignacion.as_usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_asignacion.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");

                int id = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom).ToString());
                return id;

            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__mp_asignacion(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__mp_asignacion(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_ca_id", DbType.Int32, _mp_asignacion.as_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_fecha_inicio", DbType.DateTime, _mp_asignacion.as_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "p_as_fecha_fin", DbType.DateTime, _mp_asignacion.as_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_as_estado", DbType.String, _mp_asignacion.as_estado);
                CNXSIGRH3.AddInParameter(icom, "p_as_tipo_reg", DbType.String, _mp_asignacion.as_tipo_reg);
                CNXSIGRH3.AddInParameter(icom, "p_as_tipo_mov", DbType.String, _mp_asignacion.as_tipo_mov);
                CNXSIGRH3.AddInParameter(icom, "p_as_tipo_baja", DbType.String, _mp_asignacion.as_tipo_baja);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__mp_asignacion(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__mp_asignacion(
            string as_id,
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);

                if (as_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, Convert.ToInt32(as_id)); }
                if (as_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, Convert.ToInt32(as_per_id)); }
                if (as_ca_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_ca_id", DbType.Int32, Convert.ToInt32(as_ca_id)); }
                if (as_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_fecha_inicio", DbType.DateTime, Convert.ToDateTime(as_fecha_inicio)); }
                if (as_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_fecha_fin", DbType.DateTime, Convert.ToDateTime(as_fecha_fin)); }
                if (as_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_estado", DbType.String, Convert.ToString(as_estado)); }
                if (as_tipo_reg.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_tipo_reg", DbType.String, Convert.ToString(as_tipo_reg)); }
                if (as_tipo_mov.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_tipo_mov", DbType.String, Convert.ToString(as_tipo_mov)); }
                if (as_tipo_baja.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_tipo_baja", DbType.String, Convert.ToString(as_tipo_baja)); }
                if (as_validacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_validacion", DbType.String, Convert.ToString(as_tipo_baja)); }
                if (as_fecha_validacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_fecha_validacion", DbType.DateTime, Convert.ToDateTime(as_fecha_validacion)); }
                if (as_memo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_memo", DbType.Int32, Convert.ToInt32(as_memo)); }
                if (as_memo_baja.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_memo_baja", DbType.Int32, Convert.ToInt32(as_memo_baja)); }
                if (as_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, Convert.ToInt32(as_pr_id)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__mp_asignacion()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTiempoFuncionario(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.String, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerAsignacionesRealizadas(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.String, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTiempo(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_fecha_inicio", DbType.DateTime, Convert.ToDateTime(_mp_asignacion.as_fecha_inicio));
                CNXSIGRH3.AddInParameter(icom, "p_as_fecha_fin", DbType.DateTime, Convert.ToDateTime(_mp_asignacion.as_fecha_fin));
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerBoleta(cls_mp_asignacion _mp_asignacion, string param)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_param", DbType.String, param);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerInformacionFiniquito(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerCantidadVacacion(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C12");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (MICM)
        public override DataSet ObtenerUltimaAsignacionLaboral_mp_asignacion(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (KCPB)
        public override DataSet ObtenerTablaGrillaC__mp_asignacion(
            string as_id,
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);

                if (as_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, Convert.ToInt32(as_id)); }
                if (as_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, Convert.ToInt32(as_per_id)); }
                if (as_ca_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_ca_id", DbType.Int32, Convert.ToInt32(as_ca_id)); }
                if (as_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_fecha_inicio", DbType.DateTime, Convert.ToDateTime(as_fecha_inicio)); }
                if (as_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_fecha_fin", DbType.DateTime, Convert.ToDateTime(as_fecha_fin)); }
                if (as_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_estado", DbType.String, Convert.ToString(as_estado)); }
                if (as_tipo_reg.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_tipo_reg", DbType.String, Convert.ToString(as_tipo_reg)); }
                if (as_tipo_mov.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_tipo_mov", DbType.String, Convert.ToString(as_tipo_mov)); }
                if (as_tipo_baja.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_tipo_baja", DbType.String, Convert.ToString(as_tipo_baja)); }
                if (as_validacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_validacion", DbType.String, Convert.ToString(as_tipo_baja)); }
                if (as_fecha_validacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_fecha_validacion", DbType.DateTime, Convert.ToDateTime(as_fecha_validacion)); }
                if (as_memo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_memo", DbType.Int32, Convert.ToInt32(as_memo)); }
                if (as_memo_baja.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_memo_baja", DbType.Int32, Convert.ToInt32(as_memo_baja)); }
                if (as_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, Convert.ToInt32(as_pr_id)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrillaC__mp_asignacion2(
            string as_id,
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);

                if (as_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, Convert.ToInt32(as_id)); }
                if (as_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, Convert.ToInt32(as_per_id)); }
                if (as_ca_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_ca_id", DbType.Int32, Convert.ToInt32(as_ca_id)); }
                if (as_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_fecha_inicio", DbType.DateTime, Convert.ToDateTime(as_fecha_inicio)); }
                if (as_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_fecha_fin", DbType.DateTime, Convert.ToDateTime(as_fecha_fin)); }
                if (as_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_estado", DbType.String, Convert.ToString(as_estado)); }
                if (as_tipo_reg.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_tipo_reg", DbType.String, Convert.ToString(as_tipo_reg)); }
                if (as_tipo_mov.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_tipo_mov", DbType.String, Convert.ToString(as_tipo_mov)); }
                if (as_tipo_baja.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_tipo_baja", DbType.String, Convert.ToString(as_tipo_baja)); }
                if (as_validacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_validacion", DbType.String, Convert.ToString(as_tipo_baja)); }
                if (as_fecha_validacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_fecha_validacion", DbType.DateTime, Convert.ToDateTime(as_fecha_validacion)); }
                if (as_memo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_memo", DbType.Int32, Convert.ToInt32(as_memo)); }
                if (as_memo_baja.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_memo_baja", DbType.Int32, Convert.ToInt32(as_memo_baja)); }
                if (as_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, Convert.ToInt32(as_pr_id)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C28");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Realiza el registro de la baja de asignación del funcionario 
        public override bool ActualizarBaja__mp_asignacion(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_fecha_fin", DbType.DateTime, _mp_asignacion.as_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_as_tipo_baja", DbType.String, _mp_asignacion.as_tipo_baja);
                CNXSIGRH3.AddInParameter(icom, "p_as_memo_baja", DbType.Int32, _mp_asignacion.as_memo_baja);
                CNXSIGRH3.AddInParameter(icom, "p_as_usuario_creacion", DbType.Int32, _mp_asignacion.as_usuario_creacion);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "U");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerASignacion(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_ca_id", DbType.Int32, _mp_asignacion.as_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_pre_id", DbType.Int32, _mp_asignacion.pre_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerDetalleValidacion(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C19");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        // (Kevin Carlos Prado Bustillos) Obtiene el detalle del puesto de un precontratado para su asignación
        public override DataSet ObtenerPuestoPreContratado__mp_asignacion(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        //(JQC)
        public override DataSet ListaFiltradoTipoMovimiento()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C13");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerDatosInformacionAlta(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_asignacion.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerDatosInformacionAltaRector(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_asignacion.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C56");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerDatosInformacionBaja(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_asignacion.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C15");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerDatosInformacionRPT(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_asignacion.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C16");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ReprobarAlta(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_asignacion.as_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item", DbType.String, _mp_asignacion.ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ti_tipo", DbType.String, _mp_asignacion.ti_tipo);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ReprobarBaja(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mp_asignacion.as_ca_id);
                CNXSIGRH3.AddInParameter(icom, "p_ti_item", DbType.String, _mp_asignacion.ti_item);
                CNXSIGRH3.AddInParameter(icom, "p_ti_tipo", DbType.String, _mp_asignacion.ti_tipo);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.String, _mp_asignacion.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ReprobarRPT(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ReprobarRPTConcejo(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, _mp_asignacion.as_per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "B4");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerGrillaReprobacionMov(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, _mp_asignacion.as_pr_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C17");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerEscalafonDocente()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C23");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool InsertarEscalafonDocente(int ed_id, int per_id, string accion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_mp_asignacion_escalafon_docente");

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, accion);
                CNXSIGRH3.AddInParameter(icom, "p_aed_ed_id", DbType.Int32, ed_id);
                CNXSIGRH3.AddInParameter(icom, "p_aed_per_id", DbType.Int32, per_id);

                CNXSIGRH3.ExecuteNonQuery(icom); 
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool InsertarTipoAportante(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_mp_asignacion_tipo_aportante");

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.AddInParameter(icom, "p_at_ta_id", DbType.Int32, 1);

                CNXSIGRH3.AddInParameter(icom, "p_at_per_id", DbType.Int32, per_id);
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override string ConsultarValidacion(int as_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, as_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C24");
                return CNXSIGRH3.ExecuteDataSet(icom).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ActualizarFechaInicioYBaja(cls_mp_asignacion _mp_asignacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);
                CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, _mp_asignacion.as_id);
                CNXSIGRH3.AddInParameter(icom, "p_as_fecha_inicio", DbType.DateTime, _mp_asignacion.as_fecha_inicio);
                CNXSIGRH3.AddInParameter(icom, "@p_as_fecha_fin", DbType.DateTime, _mp_asignacion.as_fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "CC");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ActualizarEscalafonDocente(int per_id, int aed_ed_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_mp_asignacion_escalafon_docente");

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.AddInParameter(icom, "p_aed_ed_id", DbType.Int32, aed_ed_id);
                CNXSIGRH3.AddInParameter(icom, "p_aed_per_id", DbType.Int32, per_id);

                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTodasLasAsignacionesVigentes(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_mp_asignacion");

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C25");
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, per_id);
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet VerificarAsignacionEscalafon(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_mp_asignacion_escalafon_docente");

                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                CNXSIGRH3.AddInParameter(icom, "p_aed_per_id", DbType.Int32, per_id);
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet VerificarItemAdministrativo(int ca_id, int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_mp_asignacion");
                CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C26");
                CNXSIGRH3.AddInParameter(icom, "p_ca_id", DbType.Int32, ca_id);
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrilla__AsignacionesPersona(
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C23");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaGrilla__AsignacionesPersona_SoloDocentes(
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__PERSONA);

                if (per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_per_id", DbType.Int32, Convert.ToInt32(per_id)); }
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
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C30");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__AsignacionesPersonaComision(
            string as_id,
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
                icom = CNXSIGRH3.GetStoredProcCommand(SP__MP_ASIGNACION);

                if (as_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_id", DbType.Int32, Convert.ToInt32(as_id)); }
                if (as_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_per_id", DbType.Int32, Convert.ToInt32(as_per_id)); }
                if (as_ca_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_ca_id", DbType.Int32, Convert.ToInt32(as_ca_id)); }
                if (as_fecha_inicio.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_fecha_inicio", DbType.DateTime, Convert.ToDateTime(as_fecha_inicio)); }
                if (as_fecha_fin.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_fecha_fin", DbType.DateTime, Convert.ToDateTime(as_fecha_fin)); }
                if (as_estado.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_estado", DbType.String, Convert.ToString(as_estado)); }
                if (as_tipo_reg.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_tipo_reg", DbType.String, Convert.ToString(as_tipo_reg)); }
                if (as_tipo_mov.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_tipo_mov", DbType.String, Convert.ToString(as_tipo_mov)); }
                if (as_tipo_baja.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_tipo_baja", DbType.String, Convert.ToString(as_tipo_baja)); }
                if (as_validacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_validacion", DbType.String, Convert.ToString(as_tipo_baja)); }
                if (as_fecha_validacion.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_fecha_validacion", DbType.DateTime, Convert.ToDateTime(as_fecha_validacion)); }
                if (as_memo.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_memo", DbType.Int32, Convert.ToInt32(as_memo)); }
                if (as_memo_baja.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_memo_baja", DbType.Int32, Convert.ToInt32(as_memo_baja)); }
                if (as_pr_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "p_as_pr_id", DbType.Int32, Convert.ToInt32(as_pr_id)); }
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C27");
                DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool InsertarFechaIngreso(int per_id, string fecha, string estado )
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_mp_primera_asignacion");
                CNXSIGRH3.AddInParameter(icom, "p_pasig_per_id", DbType.Int32, Convert.ToInt32(per_id));
                CNXSIGRH3.AddInParameter(icom, "p_pasig_fecha_asig", DbType.DateTime, fecha);
                CNXSIGRH3.AddInParameter(icom, "p_pasig_estado", DbType.String, estado);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet MostrarFechasIngreso()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("sp_mp_primera_asignacion");
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");

                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion



        //DOCENTES
        #region PLAN
        public override DataSet ObtenerPlan__G()
        {
            try
            {
                DbCommand icom = null;
                DataSet ds = new DataSet();
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C1");
                ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerArea__plan()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C2");
                return CNXSIGRH3.ExecuteDataSet(icom); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public override bool AdicionarPlan__nuevo(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "GESTION", DbType.Int32, materia.gestion);
                CNXSIGRH3.AddInParameter(icom, "CARRERA", DbType.String, materia.carrera);
                CNXSIGRH3.AddInParameter(icom, "AREA", DbType.String, materia.area);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "A1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerPlan_C(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "AREA", DbType.String, materia.area);
                CNXSIGRH3.AddInParameter(icom, "CARRERA", DbType.String, materia.carrera);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C4");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        
        public override bool CambiarEstadoPlan(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "PLANID", DbType.Int32, materia.id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "B1");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public override DataSet ObtenerCarrera__plan(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "AREA", DbType.String, materia.area);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C3");
                return CNXSIGRH3.ExecuteDataSet(icom); ;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region MATERIA
        public override bool AdicionarHoras(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "HT_PC_ID", DbType.Int32, materia.ht_pc_ic);
                CNXSIGRH3.AddInParameter(icom, "HT_HR_MES", DbType.Int32, materia.ht_hrs_mes);
                CNXSIGRH3.AddInParameter(icom, "HT_FALTAS", DbType.Int32, materia.ht_faltas);
                CNXSIGRH3.AddInParameter(icom, "HT_ATRASOS", DbType.Int32, materia.ht_atrasos);
                CNXSIGRH3.AddInParameter(icom, "HT_AS_ID", DbType.Int32, materia.ht_as_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "A5");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool AddicionarMatCa(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "MATID", DbType.Int32, materia.mat_id);
                CNXSIGRH3.AddInParameter(icom, "CARID", DbType.Int32, materia.car_id);
                CNXSIGRH3.AddInParameter(icom, "HORAS_PLAN", DbType.Int32, materia.hrs_asig);
                CNXSIGRH3.AddInParameter(icom, "TIPAD", DbType.String, materia.tip_ad);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "A3");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ListarCargosDocente(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, materia.mat_per_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C10");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet BuscarMateria2(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                DataSet ds = new DataSet();
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "PLANID", DbType.String, materia.p_id);
                CNXSIGRH3.AddInParameter(icom, "gestion", DbType.Int32, materia.gestion);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C5.1");
                ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override DataSet BuscarMateria(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                DataSet ds = new DataSet();
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "PLANID", DbType.String, materia.p_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C5");
                ds = CNXSIGRH3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public override bool EliminarMateria(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "MATID", DbType.String, materia.mat_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "B2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public override bool AdicionarMateria(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "PLANID", DbType.Int32, materia.p_id);
                CNXSIGRH3.AddInParameter(icom, "SIGLA", DbType.String, materia.sigla);
                CNXSIGRH3.AddInParameter(icom, "MATNOM", DbType.String, materia.mat_nombre);
                CNXSIGRH3.AddInParameter(icom, "HORAS_PLAN", DbType.Int32, materia.hrs_asig);
                CNXSIGRH3.AddInParameter(icom, "NIVEL", DbType.Int32, materia.mat_nivel);
                CNXSIGRH3.AddInParameter(icom, "GRUPO", DbType.Int32, materia.mat_grupo);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "A2");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerEO(int per_id)
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

        public override string AdicionarAsignacion(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "JORNADA", DbType.String, materia.jornada);
                CNXSIGRH3.AddInParameter(icom, "TIPO_DOCENTE", DbType.String, materia.tipo_doc);
                CNXSIGRH3.AddInParameter(icom, "EO_ID", DbType.Int32, materia.eo_id);
                CNXSIGRH3.AddInParameter(icom, "US_ID", DbType.Int32, materia.us_id);
                CNXSIGRH3.AddInParameter(icom, "CA_DOC", DbType.Int32, materia.ca_doc);
                CNXSIGRH3.AddInParameter(icom, "FECHA_INI", DbType.String, materia.fecha_ini.ToShortDateString());
                if(materia.fecha_fin.ToString() != "") CNXSIGRH3.AddInParameter(icom, "FECHA_FIN", DbType.String, materia.fecha_fin);
                CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, materia.mat_per_id);
                CNXSIGRH3.AddInParameter(icom, "MATID", DbType.Int32, materia.mat_id);
                CNXSIGRH3.AddInParameter(icom, "HORAS_PLAN", DbType.Int32, materia.hrs_asig);
                CNXSIGRH3.AddInParameter(icom, "TIPO_INGRESO", DbType.String, materia.tipo_ing);
                CNXSIGRH3.AddInParameter(icom, "aed_ed_id", DbType.Int32, materia.aed_ed_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "A4");
                string x = Convert.ToString(CNXSIGRH3.ExecuteScalar(icom));
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string horas(int mat_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "MATID", DbType.Int32, mat_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C6");
                string x = CNXSIGRH3.ExecuteScalar(icom).ToString();
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public override DataSet Estructura(int asig, string carre)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "PLANTA", DbType.Int32, asig);
                CNXSIGRH3.AddInParameter(icom, "CARRERA", DbType.String, carre.Trim());
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C7");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int ObtenerTablaGrilla__Doc(string as_per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                if (as_per_id.ToString().Trim() != "") { CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, Convert.ToInt32(as_per_id)); }
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "CK1");
                int ds = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom));
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override int ObtenerEscalafon(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C12");
                int x = Convert.ToInt32(CNXSIGRH3.ExecuteScalar(icom));
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FALTAS Y ATRASOS
        public override DataSet ObtenerUnidadesOrganizacionales_filtrado_docentes(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "TV");
                CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet DOCENTES_ListarGrillaDocentesMesPorUnidad(int eo_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "C11");
                CNXSIGRH3.AddInParameter(icom, "EO_ID", DbType.Int32, eo_id);

                return CNXSIGRH3.ExecuteDataSet(icom); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet Docente_ModificarHorasFaltasAtrasos(cls_materia materia)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "HORAS_TRABAJADAS", DbType.Int32, materia.ht_hrs_mes);
                CNXSIGRH3.AddInParameter(icom, "FALTAS", DbType.Int32, materia.ht_faltas);
                CNXSIGRH3.AddInParameter(icom, "ATRASOS", DbType.Int32, materia.ht_atrasos);
                CNXSIGRH3.AddInParameter(icom, "MC_ID", DbType.Int32, materia.mat_mc_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "A5");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string btnValidar(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "M1");
                CNXSIGRH3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                string x = CNXSIGRH3.ExecuteScalar(icom).ToString();
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool CambiarEstadoHT(int eo_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "eo_Cod3", DbType.Int32, eo_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "c12");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override bool CambiarEstadoHT2(int eo_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "eo_Cod3", DbType.Int32, eo_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "c13");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override bool CambiarEstadoHT3(int eo_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "eo_Cod3", DbType.Int32, eo_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "c14");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override bool CambiarEstadoAsig(int as_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "AS_ID", DbType.Int32, as_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "c15");
                CNXSIGRH3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override bool CambiarEstadoAsig2(int as_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand(SP_DOC_PLANES_CARRERAS);
                CNXSIGRH3.AddInParameter(icom, "AS_ID", DbType.Int32, as_id);
                CNXSIGRH3.AddInParameter(icom, "Accion", DbType.String, "c16");
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