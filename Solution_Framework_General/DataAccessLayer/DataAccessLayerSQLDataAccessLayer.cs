using Solution_Framework_General.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
 
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_General.DataAccessLayer
{
    public class DataAccessLayerSQLDataAccessLayer : DataAccessLayerDataAccessLayer
    {
        #region CONSTANTES
		private string SP__PERIODO = "sp_periodo";
		private string SP__PLA_PROCESO = "sp_pla_proceso";
        private string SP_HISTORICO = "sp_historico";
        private string SP__CATALOGO = "sp_catalogo";
        private string SP__GLOSA = "sp_glosa";
        #endregion

        // INTERFACES
		#region _PERIODO
		public override bool Adicionar__periodo(cls_periodo _periodo)
		{
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__PERIODO);
                CNXGENERAL.AddInParameter(icom, "p_pr_id", DbType.Int32, _periodo.pr_id);
                CNXGENERAL.AddInParameter(icom, "p_pr_gestion", DbType.Int32, _periodo.pr_gestion);
                CNXGENERAL.AddInParameter(icom, "p_pr_secuencial", DbType.Int32, _periodo.pr_secuencial);
                CNXGENERAL.AddInParameter(icom, "p_pr_estado", DbType.String, _periodo.pr_estado);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
		}

		public override bool Eliminar__periodo(cls_periodo _periodo)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__PERIODO);
				CNXGENERAL.AddInParameter(icom, "p_pr_id", DbType.Int32, _periodo.pr_id);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXGENERAL.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Actualizar__periodo(cls_periodo _periodo)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__PERIODO);
				CNXGENERAL.AddInParameter(icom, "p_pr_id", DbType.Int32, _periodo.pr_id);
				CNXGENERAL.AddInParameter(icom, "p_pr_gestion", DbType.Int32, _periodo.pr_gestion);
				CNXGENERAL.AddInParameter(icom, "p_pr_secuencial", DbType.Int32, _periodo.pr_secuencial);
				CNXGENERAL.AddInParameter(icom, "p_pr_estado", DbType.String, _periodo.pr_estado);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXGENERAL.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool ObtenerId__periodo(cls_periodo _periodo)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__PERIODO);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "I");
				DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
				_periodo.pr_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pr_id"]);		
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerRegistro__periodo(cls_periodo _periodo)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__PERIODO);
				CNXGENERAL.AddInParameter(icom, "p_pr_id", DbType.Int32, _periodo.pr_id);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaGrilla__periodo(
            string pr_id, 
			string pr_gestion, 
			string pr_secuencial, 
			string pr_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__PERIODO);

				if (pr_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_pr_id", DbType.Int32, Convert.ToInt32(pr_id)); }
				if (pr_gestion.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_pr_gestion", DbType.Int32, Convert.ToInt32(pr_gestion)); }
				if (pr_secuencial.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_pr_secuencial", DbType.Int32, Convert.ToInt32(pr_secuencial)); }
				if (pr_estado.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_pr_estado", DbType.String, Convert.ToString(pr_estado)); } 
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaCombo__periodo()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__PERIODO);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerPeriodoVigente()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__PERIODO);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _PLA_PROCESO
        public override bool Adicionar__pla_proceso(cls_pla_proceso _pla_proceso)
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
            catch (Exception ex) { throw ex; }
		}

		public override bool Eliminar__pla_proceso(cls_pla_proceso _pla_proceso)
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
			catch (Exception ex) { throw ex; }
        }

		public override bool Actualizar__pla_proceso(cls_pla_proceso _pla_proceso)
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
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXSIGRH3.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool ObtenerId__pla_proceso(cls_pla_proceso _pla_proceso)
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
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerRegistro__pla_proceso(cls_pla_proceso _pla_proceso)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXSIGRH3.GetStoredProcCommand(SP__PLA_PROCESO);
                CNXSIGRH3.AddInParameter(icom, "p_pc_id", DbType.Int32, _pla_proceso.pc_id);
                CNXSIGRH3.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXSIGRH3.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaGrilla__pla_proceso(
            string pc_id, 
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
			catch (Exception ex) { throw ex; }
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
			catch (Exception ex) { throw ex; }
        }
		#endregion 

        #region HISTORICO
        public override bool Adicionar_historico(cls_historico historico)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP_HISTORICO);
                CNXGENERAL.AddInParameter(icom, "p_his_tipo_abm", DbType.String, historico.his_tipo_abm);
                CNXGENERAL.AddInParameter(icom, "p_his_nom_tabla", DbType.String, historico.his_nom_tabla);
                CNXGENERAL.AddInParameter(icom, "p_his_nom_pk", DbType.String, historico.his_nom_pk);
                CNXGENERAL.AddInParameter(icom, "p_his_valor_pk", DbType.String, historico.his_valor_pk);
                CNXGENERAL.AddInParameter(icom, "p_his_campos", DbType.String, historico.his_campos);
                CNXGENERAL.AddInParameter(icom, "p_his_usuario_creacion", DbType.Int32, historico.his_usuario_creacion);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerId_historico(cls_historico historico)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP_HISTORICO);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                historico.his_id = Convert.ToInt32(ds.Tables[0].Rows[0]["his_id"]);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro_historico(cls_historico historico)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP_HISTORICO);
                CNXGENERAL.AddInParameter(icom, "p_his_id", DbType.Int32, historico.his_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla_historico(
            string his_id,
            string his_tipo_abm,
            string his_nom_tabla,
            string his_nom_pk,
            string his_valor_pk,
            string his_campos,
            string his_fecha_creacion,
            string his_usuario_creacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP_HISTORICO);

                if (his_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_his_id", DbType.Int32, Convert.ToInt32(his_id)); }
                if (his_tipo_abm.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_his_tipo_abm", DbType.String, Convert.ToString(his_tipo_abm)); }
                if (his_nom_tabla.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_his_nom_tabla", DbType.String, Convert.ToString(his_nom_tabla)); }
                if (his_nom_pk.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_his_nom_pk", DbType.String, Convert.ToString(his_nom_pk)); }
                if (his_valor_pk.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_his_valor_pk", DbType.String, Convert.ToString(his_valor_pk)); }
                if (his_campos.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_his_campos", DbType.String, Convert.ToString(his_campos)); }
                if (his_fecha_creacion.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_his_fecha_creacion", DbType.DateTime, Convert.ToDateTime(his_fecha_creacion)); }
                if (his_usuario_creacion.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_his_usuario_creacion", DbType.String, Convert.ToString(his_usuario_creacion)); }
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _CATALOGO
        public override bool Adicionar__catalogo(string cat_tabla,  string cat_descripcion, string cat_abreviacion, string id_superior)
        {
            //try
            //{
                DbCommand icom = null;
                //icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);
                //CNXGENERAL.AddInParameter(icom, "p_cat_id", DbType.Int32, _catalogo.cat_id);
                //CNXGENERAL.AddInParameter(icom, "p_cat_tabla", DbType.String, _catalogo.cat_tabla);
                //CNXGENERAL.AddInParameter(icom, "p_cat_secuencial", DbType.Int32, _catalogo.cat_secuencial);
                //CNXGENERAL.AddInParameter(icom, "p_cat_descripcion", DbType.String, _catalogo.cat_descripcion);
                //CNXGENERAL.AddInParameter(icom, "p_cat_abreviacion", DbType.String, _catalogo.cat_abreviacion);
                //CNXGENERAL.AddInParameter(icom, "p_cat_id_superior", DbType.Int32, _catalogo.cat_id_superior);
                //CNXGENERAL.AddInParameter(icom, "p_cat_adicional", DbType.String, _catalogo.cat_adicional);
                //CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                //CNXGENERAL.ExecuteNonQuery(icom);
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);
                CNXGENERAL.AddInParameter(icom, "p_cat_tabla", DbType.String, cat_tabla);
                CNXGENERAL.AddInParameter(icom, "p_cat_descripcion", DbType.String, cat_descripcion);
                CNXGENERAL.AddInParameter(icom, "p_cat_abreviacion", DbType.String, cat_abreviacion);
            CNXGENERAL.AddInParameter(icom, "p_cat_id_superior", DbType.Int32,Convert.ToInt32(id_superior));
            CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A2");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            //}
            //catch (Exception ex) { throw ex; }
        }
        public override bool AdicionarCatalogoSecuencial(cls_catalogo _catalogo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);
                CNXGENERAL.AddInParameter(icom, "p_cat_tabla", DbType.String, _catalogo.cat_tabla);
                CNXGENERAL.AddInParameter(icom, "p_cat_tabla_aux", DbType.String, _catalogo.cat_tabla_aux);
                CNXGENERAL.AddInParameter(icom, "p_cat_descripcion", DbType.String, _catalogo.cat_descripcion);
                CNXGENERAL.AddInParameter(icom, "p_cat_id_superior", DbType.Int32, _catalogo.cat_id_superior);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A1");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool Eliminar__catalogo(cls_catalogo _catalogo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);
                CNXGENERAL.AddInParameter(icom, "p_cat_id", DbType.Int32, _catalogo.cat_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__catalogo(cls_catalogo _catalogo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);
                CNXGENERAL.AddInParameter(icom, "p_cat_id", DbType.Int32, _catalogo.cat_id);
                CNXGENERAL.AddInParameter(icom, "p_cat_tabla", DbType.String, _catalogo.cat_tabla);
                CNXGENERAL.AddInParameter(icom, "p_cat_secuencial", DbType.Int32, _catalogo.cat_secuencial);
                CNXGENERAL.AddInParameter(icom, "p_cat_descripcion", DbType.String, _catalogo.cat_descripcion);
                CNXGENERAL.AddInParameter(icom, "p_cat_abreviacion", DbType.String, _catalogo.cat_abreviacion);
                CNXGENERAL.AddInParameter(icom, "p_cat_estado", DbType.String, _catalogo.cat_estado);
                CNXGENERAL.AddInParameter(icom, "p_cat_id_superior", DbType.Int32, _catalogo.cat_id_superior);
                CNXGENERAL.AddInParameter(icom, "p_cat_adicional", DbType.String, _catalogo.cat_adicional);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerId__catalogo(cls_catalogo _catalogo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                _catalogo.cat_id = Convert.ToInt32(ds.Tables[0].Rows[0]["cat_id"]);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__catalogo(cls_catalogo _catalogo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);
                CNXGENERAL.AddInParameter(icom, "p_cat_id", DbType.Int32, _catalogo.cat_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__catalogo(
            string cat_id,
            string cat_tabla,
            string cat_secuencial,
            string cat_secuencial_op,
            string cat_descripcion,
            string cat_descripcion_op,
            string cat_abreviacion,
            string cat_id_superior,
            string cat_adicional,
            string cat_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);

                if (cat_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_cat_id", DbType.Int32, Convert.ToInt32(cat_id)); }
                if (cat_tabla.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_cat_tabla", DbType.String, Convert.ToString(cat_tabla)); }
                if (cat_secuencial.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_cat_secuencial", DbType.Int32, Convert.ToInt32(cat_secuencial)); }
                if (cat_secuencial_op.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_cat_secuencial_op", DbType.String, Convert.ToString(cat_secuencial_op)); }
                if (cat_descripcion.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_cat_descripcion", DbType.String, Convert.ToString(cat_descripcion)); }
                if (cat_descripcion_op.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_cat_descripcion_op", DbType.String, Convert.ToString(cat_descripcion_op)); }
                if (cat_abreviacion.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_cat_abreviacion", DbType.String, Convert.ToString(cat_abreviacion)); }
                if (cat_id_superior.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_cat_id_superior", DbType.Int32, Convert.ToInt32(cat_id_superior)); }
                if (cat_adicional.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_cat_adicional", DbType.String, Convert.ToString(cat_adicional)); }
                if (cat_estado.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_cat_estado", DbType.String, Convert.ToString(cat_estado)); }
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__catalogo(cls_catalogo _catalogo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);
                CNXGENERAL.AddInParameter(icom, "p_cat_tabla", DbType.String, _catalogo.cat_tabla);
                CNXGENERAL.AddInParameter(icom, "p_cat_id_superior", DbType.Int32, _catalogo.cat_id_superior);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
                //CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, accion);

                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerTablaComboSoloComision(cls_catalogo _catalogo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);
                CNXGENERAL.AddInParameter(icom, "p_cat_tabla", DbType.String, _catalogo.cat_tabla);
                CNXGENERAL.AddInParameter(icom, "p_cat_id_superior", DbType.Int32, _catalogo.cat_id_superior);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C7");
                //CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, accion);

                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerLugarNacimiento__catalogo()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerBancoAutorizadoVigente__catalogo()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerSancionesAisaVigente__catalogo()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);

                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerRegistroPadre(cls_catalogo _catalogo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);

                CNXGENERAL.AddInParameter(icom, "p_cat_tabla", DbType.String, _catalogo.cat_tabla);
                CNXGENERAL.AddInParameter(icom, "p_cat_secuencial", DbType.Int32, _catalogo.cat_secuencial);

                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerCat_TablaPando(cls_catalogo _catalogo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);

                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "R7");
                return  CNXGENERAL.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerTablaCombo__catalogoFuncionario(cls_catalogo _catalogo)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);
                CNXGENERAL.AddInParameter(icom, "p_cat_tabla", DbType.String, _catalogo.cat_tabla);
                CNXGENERAL.AddInParameter(icom, "p_cat_id_superior", DbType.Int32, _catalogo.cat_id_superior);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C8");
                //CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, accion);

                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerDptoProvincia()
        {   
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__CATALOGO);

                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C11");
                //CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, accion);

                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _GLOSA
        public override bool Adicionar__glosa(cls_glosa _glosa)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__GLOSA);
                CNXGENERAL.AddInParameter(icom, "p_gl_valor_pk", DbType.String, _glosa.gl_valor_pk);
                CNXGENERAL.AddInParameter(icom, "p_gl_nombre_pk", DbType.String, _glosa.gl_nombre_pk);
                CNXGENERAL.AddInParameter(icom, "p_gl_tabla", DbType.String, _glosa.gl_tabla);
                CNXGENERAL.AddInParameter(icom, "p_gl_tipo_mov", DbType.Int32, _glosa.gl_tipo_mov);
                CNXGENERAL.AddInParameter(icom, "p_gl_numero_doc", DbType.String, _glosa.gl_numero_doc);
                CNXGENERAL.AddInParameter(icom, "p_gl_fecha_doc", DbType.DateTime, _glosa.gl_fecha_doc);
                CNXGENERAL.AddInParameter(icom, "p_gl_tipo_doc", DbType.Int32, _glosa.gl_tipo_doc);
                CNXGENERAL.AddInParameter(icom, "p_gl_glosa", DbType.String, _glosa.gl_glosa);
                CNXGENERAL.AddInParameter(icom, "p_gl_usuario", DbType.Int32, _glosa.gl_usuario);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__glosa(cls_glosa _glosa)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__GLOSA);
                CNXGENERAL.AddInParameter(icom, "p_gl_id", DbType.Int32, _glosa.gl_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__glosa(cls_glosa _glosa)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__GLOSA);
                CNXGENERAL.AddInParameter(icom, "p_gl_id", DbType.Int32, _glosa.gl_id);
                //CNXGENERAL.AddInParameter(icom, "p_gl_valor_pk", DbType.String, _glosa.gl_valor_pk);
                //CNXGENERAL.AddInParameter(icom, "p_gl_nombre_pk", DbType.String, _glosa.gl_nombre_pk);
                //CNXGENERAL.AddInParameter(icom, "p_gl_tabla", DbType.String, _glosa.gl_tabla);
                //CNXGENERAL.AddInParameter(icom, "p_gl_tipo_mov", DbType.Int32, _glosa.gl_tipo_mov);
                CNXGENERAL.AddInParameter(icom, "p_gl_tipo_doc", DbType.Int32, _glosa.gl_tipo_doc);
                CNXGENERAL.AddInParameter(icom, "p_gl_glosa", DbType.String, _glosa.gl_glosa);
                CNXGENERAL.AddInParameter(icom, "p_gl_numero_doc", DbType.String, _glosa.gl_numero_doc);
                CNXGENERAL.AddInParameter(icom, "p_gl_fecha_doc", DbType.DateTime, _glosa.gl_fecha_doc);
                CNXGENERAL.AddInParameter(icom, "p_gl_usuario", DbType.Int32, _glosa.gl_usuario);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__glosa(cls_glosa _glosa)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__GLOSA);
                CNXGENERAL.AddInParameter(icom, "p_gl_id", DbType.Int32, _glosa.gl_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__glosa(
            string gl_id,
            string gl_valor_pk,
            string gl_nombre_pk,
            string gl_tabla,
            string gl_tipo_mov,
            string gl_tipo_doc,
            string gl_glosa,
            string gl_numero_doc,
            string gl_fecha_doc,
            string gl_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__GLOSA);

                if (gl_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_id", DbType.Int32, Convert.ToInt32(gl_id)); }
                if (gl_valor_pk.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_valor_pk", DbType.String, Convert.ToString(gl_valor_pk)); }
                if (gl_nombre_pk.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_nombre_pk", DbType.String, Convert.ToString(gl_nombre_pk)); }
                if (gl_tabla.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_tabla", DbType.String, Convert.ToString(gl_tabla)); }
                if (gl_tipo_mov.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_tipo_mov", DbType.Int32, Convert.ToInt32(gl_tipo_mov)); }
                if (gl_tipo_doc.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_tipo_doc", DbType.Int32, Convert.ToInt32(gl_tipo_doc)); }
                if (gl_glosa.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_glosa", DbType.String, Convert.ToString(gl_glosa)); }
                if (gl_numero_doc.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_numero_doc", DbType.String, Convert.ToString(gl_numero_doc)); }
                if (gl_fecha_doc.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_fecha_doc", DbType.DateTime, Convert.ToDateTime(gl_fecha_doc)); }
                if (gl_estado.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_estado", DbType.String, Convert.ToString(gl_estado)); }
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__glosa()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__GLOSA);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla para llenar una grilla
        public override DataSet ObtenerTablaGrillaC__glosa(
            string gl_id,
            string gl_valor_pk,
            string gl_nombre_pk,
            string gl_tabla,
            string gl_tipo_mov,
            string gl_tipo_doc,
            string gl_glosa,
            string gl_numero_doc,
            string gl_fecha_doc,
            string gl_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__GLOSA);

                if (gl_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_id", DbType.Int32, Convert.ToInt32(gl_id)); }
                if (gl_valor_pk.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_valor_pk", DbType.String, Convert.ToString(gl_valor_pk)); }
                if (gl_nombre_pk.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_nombre_pk", DbType.String, Convert.ToString(gl_nombre_pk)); }
                if (gl_tabla.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_tabla", DbType.String, Convert.ToString(gl_tabla)); }
                if (gl_tipo_mov.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_tipo_mov", DbType.Int32, Convert.ToInt32(gl_tipo_mov)); }
                if (gl_tipo_doc.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_tipo_doc", DbType.Int32, Convert.ToInt32(gl_tipo_doc)); }
                if (gl_glosa.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_glosa", DbType.String, Convert.ToString(gl_glosa)); }
                if (gl_numero_doc.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_numero_doc", DbType.String, Convert.ToString(gl_numero_doc)); }
                if (gl_fecha_doc.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_fecha_doc", DbType.DateTime, Convert.ToDateTime(gl_fecha_doc)); }
                if (gl_estado.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_gl_estado", DbType.String, Convert.ToString(gl_estado)); }
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        //NUEVO AUXILIAR
        private (string modo, string control) ExtraerModoControl(string catAdicional)
        {
            string modo = "D";       // por defecto, días
            string control = "NINGUNO";

            if (!string.IsNullOrWhiteSpace(catAdicional))
            {
                var mModo = System.Text.RegularExpressions.Regex.Match(catAdicional, "\"modo\"\\s*:\\s*\"([^\"]+)\"");
                if (mModo.Success) modo = mModo.Groups[1].Value;

                var mControl = System.Text.RegularExpressions.Regex.Match(catAdicional, "\"control\"\\s*:\\s*\"([^\"]+)\"");
                if (mControl.Success) control = mControl.Groups[1].Value;
            }
            return (modo, control);
        }
        #endregion

        #region GRADO ACADEMICO
        public override DataSet ObtenerGradoAcademico()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand("sp_grado_academico");
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
                return CNXGENERAL.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ComboFormacion(string accion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand("sp_instituciones");
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, accion);
                return CNXGENERAL.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ComboFormacionCarreras(string accion)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand("sp_carreras");
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, accion);
                return CNXGENERAL.ExecuteDataSet(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region BIOMETRICO
        //Metodos del biometrico
        public override int AdicionarDispositivo(string descrip, string ip, int edificio)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_CP_DISPOSITIVOS");
                CNXSIGRH3.AddInParameter(icom, "DESCRIPCION", DbType.String, descrip);
                CNXSIGRH3.AddInParameter(icom, "IP", DbType.String, ip);
                CNXSIGRH3.AddInParameter(icom, "EDIFICIO", DbType.Int32, edificio);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "A1");
                int x = Convert.ToInt32(CNXSIGRH3.ExecuteNonQuery(icom));
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ListarDispositivos()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_CP_DISPOSITIVOS");
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C2");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int EliminarDispositivo(int di_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_CP_DISPOSITIVOS");
                CNXSIGRH3.AddInParameter(icom, "DI_ID", DbType.Int32, di_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "B1");
                int x = Convert.ToInt32(CNXSIGRH3.ExecuteNonQuery(icom));
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int EditarDispositivo(string descripcion, int edifi, string ip, int di_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_CP_DISPOSITIVOS");
                CNXSIGRH3.AddInParameter(icom, "DESCRIPCION", DbType.String, descripcion);
                CNXSIGRH3.AddInParameter(icom, "EDIFICIO", DbType.Int32, edifi);
                CNXSIGRH3.AddInParameter(icom, "IP", DbType.String, ip);
                CNXSIGRH3.AddInParameter(icom, "DI_ID", DbType.Int32, di_id);
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "U1");
                int x = CNXSIGRH3.ExecuteNonQuery(icom);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet MostrarEdificios()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXSIGRH3.GetStoredProcCommand("SP_CP_DISPOSITIVOS");
                CNXSIGRH3.AddInParameter(icom, "ACCION", DbType.String, "C1");
                return CNXSIGRH3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
