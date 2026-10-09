using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ControlPersonal.DataAccessLayer;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_cp_licencia_justificada.
	/// </summary>
	public class cls_cp_licencia_justificada
	{
		#region PROPIEDADES
		public int lj_id { get; set; }
		public int lj_per_id { get; set; }
        public int lj_tipo_licencia { get; set; }
        public DateTime? lj_fecha_inicial { get; set; }
        public DateTime? lj_fecha_final { get; set; }
        public DateTime? lj_fecha_emision { get; set; }
        public DateTime? lj_hora_salida { get; set; }
        public DateTime? lj_hora_retorno { get; set; }
        public string lj_motivo { get; set; }
        public string lj_lugar { get; set; }
        public string lj_per_id_autoriza { get; set; }
        public string lj_estado { get; set; }


        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_cp_licencia_justificada
        /// </summary>
        public int Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar__cp_licencia_justificada(this);
        }

        /// <summary>
        /// Método que actualiza datos en la tabla tbl_cp_licencia_justificada
        /// </summary>
        public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__cp_licencia_justificada(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_cp_licencia_justificada
		/// </summary>
		public int Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__cp_licencia_justificada(this);
        }

        /// <summary>
        /// Método que obtiene un registro de tbl_cp_licencia_justificada
        /// </summary>
        /// <param name="lj_id">
        /// Clave primaria de la tabla _cp_licencia_justificada
        /// </param>
        public DataSet ObtenerRegistro(int p_lj_id)
		{
			lj_id = p_lj_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__cp_licencia_justificada(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_licencia_justificada para llenar una grilla
		/// </summary>
		/// <param name="lj_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="lj_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="lj_tipo_licencia">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="lj_fecha_inicial">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="lj_fecha_final">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="lj_fecha_emision">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="lj_hora_salida">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="lj_hora_retorno">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="lj_motivo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="lj_lugar">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="lj_per_id_autoriza">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="lj_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
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
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__cp_licencia_justificada(lj_id, lj_per_id, lj_tipo_licencia, lj_fecha_inicial, lj_fecha_final, lj_fecha_emision, lj_hora_salida, lj_hora_retorno, lj_motivo, lj_lugar, lj_per_id_autoriza, lj_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_licencia_justificada para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__cp_licencia_justificada();
		}

        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla para llenar una grilla
        public DataSet ObtenerTablaGrillaC(
            string p_lj_id,
            string p_lj_per_id,
            string p_per_num_doc,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_lj_tipo_licencia,
            string p_lj_fecha_inicial,
            string p_lj_fecha_final,
            string p_lj_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaC__cp_licencia_justificada(p_lj_id, p_lj_per_id, p_per_num_doc, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_lj_tipo_licencia, p_lj_fecha_inicial, p_lj_fecha_final, p_lj_estado);
        }
        public DataSet ObtenerTablaGrillaC__VALIDAR_COMISION(
            string p_lj_id,
            string p_lj_per_id,
            string p_per_num_doc,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_lj_tipo_licencia,
            string p_lj_fecha_inicial,
            string p_lj_fecha_final,
            string p_lj_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaC__VALIDAR_COMISION(p_lj_id, p_lj_per_id, p_per_num_doc, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_lj_tipo_licencia, p_lj_fecha_inicial, p_lj_fecha_final, p_lj_estado);
        }
        // (Kevin Carlos Prado Bustillos) Lista de inmediatos superiores
        public DataSet ObtenerTablaComboIS()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaComboIS__cp_licencia_justificada(this);
        }

        // (JQC)
        public bool AdicionarLicenciaVacacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarLicenciaVacacion(this);
        }
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla (licencias y suspensión sin goce de haberes)
        public DataSet ObtenerTablaGrillaLS()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaLS__cp_licencia_justificada();
        }
        // (Kevin Carlos Prado Bustillos) Modificación de licencia / suspensión sin goce de haberes, bajas médicas
        public bool ActualizarLSBM()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarLSBM__cp_licencia_justificada(this);
        }
        public DataSet ObtenerLicenciasSGHFun()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerLicenciasSGHFun(this);
        }
        public DataSet ObtenerRegistroFun()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistroFun(this);
        }
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla (bajas médicas)
        public DataSet ObtenerTablaGrillaBM(
            string p_lj_per_id,
            string p_per_num_doc,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaBM__cp_licencia_justificada(p_lj_per_id, p_per_num_doc, p_per_ap_paterno, p_per_ap_materno, p_per_nombres);
        }
        //// (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla (validación licencias)
        //public DataSet ObtenerTablaGrillaVLJ(
        //    string p_lj_id,
        //    string p_lj_per_id,
        //    string p_per_num_doc,
        //    string p_per_ap_paterno,
        //    string p_per_ap_materno,
        //    string p_per_nombres,
        //    string p_lj_estado)
        //{
        //    DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
        //    return DBLayer.ObtenerTablaGrillaVLJ__cp_licencia_justificada(p_lj_id, p_lj_per_id, p_per_num_doc, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_lj_estado);
        //}
        public  DataSet VerificarSiCorrespondeBoletaComision(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.VerificarSiCorrespondeBoletaComision(per_id);
        }
        public  DataSet AutoridadesParaValidarComisiones()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AutoridadesParaValidarComisiones();
        }
        public  DataSet Grilla_ComisionesSolicitadas(int autoridad_per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Grilla_ComisionesSolicitadas(autoridad_per_id);
        }
        public  bool GenerarAsistencia_UpdateFaltas___LicenciasJustificadas(int per_id, string fecha_inicio, string fecha_fin)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.GenerarAsistencia_UpdateFaltas___LicenciasJustificadas(per_id, fecha_inicio, fecha_fin);
        }
        public bool ActualizarLC(int codigoComisionInput)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarLC(codigoComisionInput);
        }
        public DataSet ObtenerSaldoLicencia(int perId, int tipoLicencia)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerSaldoLicencia(perId, tipoLicencia);
        }
        #endregion
    }
}
