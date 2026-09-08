using Solution_Framework_BolsaTrabajo.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
 
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_BolsaTrabajo.DataAccessLayer
{
    public class DataAccessLayerSQLDataAccessLayer : DataAccessLayerDataAccessLayer
    {
        #region CONSTANTES
        private string SP__BT_POSTULANTE = "sp_bt_postulante";
        #endregion

        //INTERFACES
        #region _BT_POSTULANTE
        public override bool Adicionar__bt_postulante(cls_bt_postulante _bt_postulante)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXBOLSA.GetStoredProcCommand(SP__BT_POSTULANTE);
                CNXBOLSA.AddInParameter(icom, "p_po_primer_nombre", DbType.String, _bt_postulante.po_primer_nombre);
                CNXBOLSA.AddInParameter(icom, "p_po_segundo_nombre", DbType.String, _bt_postulante.po_segundo_nombre);
                CNXBOLSA.AddInParameter(icom, "p_po_paterno", DbType.String, _bt_postulante.po_paterno);
                CNXBOLSA.AddInParameter(icom, "p_po_materno", DbType.String, _bt_postulante.po_materno);
                CNXBOLSA.AddInParameter(icom, "p_po_tipo_doc", DbType.Int32, _bt_postulante.po_tipo_doc);
                CNXBOLSA.AddInParameter(icom, "p_po_num_doc", DbType.String, _bt_postulante.po_num_doc);
                CNXBOLSA.AddInParameter(icom, "p_po_lugar_exp", DbType.Int32, _bt_postulante.po_lugar_exp);
                CNXBOLSA.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXBOLSA.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__bt_postulante(cls_bt_postulante _bt_postulante)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXBOLSA.GetStoredProcCommand(SP__BT_POSTULANTE);
                CNXBOLSA.AddInParameter(icom, "p_po_id", DbType.Int32, _bt_postulante.po_id);
                CNXBOLSA.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXBOLSA.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__bt_postulante(cls_bt_postulante _bt_postulante)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXBOLSA.GetStoredProcCommand(SP__BT_POSTULANTE);
                CNXBOLSA.AddInParameter(icom, "p_po_id", DbType.Int32, _bt_postulante.po_id);
                CNXBOLSA.AddInParameter(icom, "p_po_primer_nombre", DbType.String, _bt_postulante.po_primer_nombre);
                CNXBOLSA.AddInParameter(icom, "p_po_segundo_nombre", DbType.String, _bt_postulante.po_segundo_nombre);
                CNXBOLSA.AddInParameter(icom, "p_po_paterno", DbType.String, _bt_postulante.po_paterno);
                CNXBOLSA.AddInParameter(icom, "p_po_materno", DbType.String, _bt_postulante.po_materno);
                CNXBOLSA.AddInParameter(icom, "p_po_ap_casada", DbType.String, _bt_postulante.po_ap_casada);
                CNXBOLSA.AddInParameter(icom, "p_po_correo", DbType.String, _bt_postulante.po_correo);
                CNXBOLSA.AddInParameter(icom, "p_po_tipo_doc", DbType.Int32, _bt_postulante.po_tipo_doc);
                CNXBOLSA.AddInParameter(icom, "p_po_num_doc", DbType.String, _bt_postulante.po_num_doc);
                CNXBOLSA.AddInParameter(icom, "p_po_lugar_exp", DbType.Int32, _bt_postulante.po_lugar_exp);
                CNXBOLSA.AddInParameter(icom, "p_po_estado_civil", DbType.String, _bt_postulante.po_estado_civil);
                CNXBOLSA.AddInParameter(icom, "p_po_fecha_nacimiento", DbType.Date, _bt_postulante.po_fecha_nacimiento);
                CNXBOLSA.AddInParameter(icom, "p_po_lugar_nacimiento", DbType.Int32, _bt_postulante.po_lugar_nacimiento);
                CNXBOLSA.AddInParameter(icom, "p_po_nacionalidad", DbType.Int32, _bt_postulante.po_nacionalidad);
                CNXBOLSA.AddInParameter(icom, "p_po_sexo", DbType.String, _bt_postulante.po_sexo);
                CNXBOLSA.AddInParameter(icom, "p_po_zona", DbType.Int32, _bt_postulante.po_zona);
                CNXBOLSA.AddInParameter(icom, "p_po_tipo_via", DbType.Int32, _bt_postulante.po_tipo_via);
                CNXBOLSA.AddInParameter(icom, "p_po_descripcion_via", DbType.String, _bt_postulante.po_descripcion_via);
                CNXBOLSA.AddInParameter(icom, "p_po_numero", DbType.String, _bt_postulante.po_numero);
                CNXBOLSA.AddInParameter(icom, "p_po_telefono", DbType.String, _bt_postulante.po_telefono);
                CNXBOLSA.AddInParameter(icom, "p_po_celular", DbType.String, _bt_postulante.po_celular);
                CNXBOLSA.AddInParameter(icom, "p_po_ciudad_residencia", DbType.Int32, _bt_postulante.po_ciudad_residencia);
                CNXBOLSA.AddInParameter(icom, "p_po_num_libreta_militar", DbType.String, _bt_postulante.po_num_libreta_militar);
                CNXBOLSA.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXBOLSA.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool ObtenerId__bt_postulante(cls_bt_postulante _bt_postulante)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXBOLSA.GetStoredProcCommand(SP__BT_POSTULANTE);
                CNXBOLSA.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CNXBOLSA.ExecuteDataSet(icom);
                _bt_postulante.po_id = Convert.ToInt32(ds.Tables[0].Rows[0]["po_id"]);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistros__bt_postulante(cls_bt_postulante _bt_postulante)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXBOLSA.GetStoredProcCommand(SP__BT_POSTULANTE);
                CNXBOLSA.AddInParameter(icom, "p_po_id", DbType.Int32, _bt_postulante.po_id);
                CNXBOLSA.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXBOLSA.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__bt_postulante(
            string po_id,
            string po_primer_nombre,
            string po_segundo_nombre,
            string po_paterno,
            string po_materno,
            string po_ap_casada,
            string po_correo,
            string po_tipo_doc,
            string po_num_doc,
            string po_lugar_exp,
            string po_estado_civil,
            string po_fecha_nacimiento,
            string po_lugar_nacimiento,
            string po_nacionalidad,
            string po_sexo,
            string po_zona,
            string po_tipo_via,
            string po_descripcion_via,
            string po_numero,
            string po_telefono,
            string po_celular,
            string po_ciudad_residencia,
            string po_num_libreta_militar,
            string po_estado,
            string po_codigo_fun,
            string po_nro_libro)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXBOLSA.GetStoredProcCommand(SP__BT_POSTULANTE);

                if (po_id.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_id", DbType.Int32, Convert.ToInt32(po_id)); }
                if (po_primer_nombre.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_primer_nombre", DbType.String, Convert.ToString(po_primer_nombre)); }
                if (po_segundo_nombre.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_segundo_nombre", DbType.String, Convert.ToString(po_segundo_nombre)); }
                if (po_paterno.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_paterno", DbType.String, Convert.ToString(po_paterno)); }
                if (po_materno.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_materno", DbType.String, Convert.ToString(po_materno)); }
                if (po_ap_casada.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_ap_casada", DbType.String, Convert.ToString(po_ap_casada)); }
                if (po_correo.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_correo", DbType.String, Convert.ToString(po_correo)); }
                if (po_tipo_doc.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_tipo_doc", DbType.Int32, Convert.ToInt32(po_tipo_doc)); }
                if (po_num_doc.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_num_doc", DbType.String, Convert.ToString(po_num_doc)); }
                if (po_lugar_exp.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_lugar_exp", DbType.Int32, Convert.ToInt32(po_lugar_exp)); }
                if (po_estado_civil.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_estado_civil", DbType.String, Convert.ToString(po_estado_civil)); }
                if (po_fecha_nacimiento.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_fecha_nacimiento", DbType.DateTime, Convert.ToDateTime(po_fecha_nacimiento)); }
                if (po_lugar_nacimiento.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_lugar_nacimiento", DbType.Int32, Convert.ToInt32(po_lugar_nacimiento)); }
                if (po_nacionalidad.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_nacionalidad", DbType.Int32, Convert.ToInt32(po_nacionalidad)); }
                if (po_sexo.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_sexo", DbType.String, Convert.ToString(po_sexo)); }
                if (po_zona.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_zona", DbType.Int32, Convert.ToInt32(po_zona)); }
                if (po_tipo_via.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_tipo_via", DbType.Int32, Convert.ToInt32(po_tipo_via)); }
                if (po_descripcion_via.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_descripcion_via", DbType.String, Convert.ToString(po_descripcion_via)); }
                if (po_numero.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_numero", DbType.String, Convert.ToString(po_numero)); }
                if (po_telefono.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_telefono", DbType.String, Convert.ToString(po_telefono)); }
                if (po_celular.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_celular", DbType.String, Convert.ToString(po_celular)); }
                if (po_ciudad_residencia.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_ciudad_residencia", DbType.Int32, Convert.ToInt32(po_ciudad_residencia)); }
                if (po_num_libreta_militar.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_num_libreta_militar", DbType.String, Convert.ToString(po_num_libreta_militar)); }
                if (po_estado.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_estado", DbType.String, Convert.ToString(po_estado)); }
                if (po_codigo_fun.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_po_codigo_fun", DbType.Int32, Convert.ToInt32(po_codigo_fun)); }
                if (po_nro_libro.ToString().Trim() != "") { CNXBOLSA.AddInParameter(icom, "p_nro_libro", DbType.Int32, Convert.ToInt32(po_nro_libro)); }
                CNXBOLSA.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXBOLSA.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__bt_postulante()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXBOLSA.GetStoredProcCommand(SP__BT_POSTULANTE);
                CNXBOLSA.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXBOLSA.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

    }
}
