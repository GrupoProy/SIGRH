using Solution_Framework_MovimientoPersonal.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
    /// <summary>
	/// Proporciona funcionalidad para manejo de tbl_persona_familiares.
	/// </summary>
	public class cls_persona_familiares
    {
        #region PROPIEDADES
        public int pf_id { get; set; }
        public int pf_per_id { get; set; }
        public string pf_tipo_parentesco { get; set; }
        public string pf_paterno { get; set; }
        public string pf_materno { get; set; }
        public string pf_nombres { get; set; }
        public string pf_ap_esposo { get; set; }
        public string pf_fecha_nac { get; set; }
        public string pf_estado { get; set; }
        public string pf_estado_vivo { get; set; }
        public DateTime pf_fecha_defuncion { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_persona_familiares
        /// </summary>
        public bool Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar__persona_familiares(this);
        }

        /// <summary>
        /// Método que actualiza datos en la tabla tbl_persona_familiares
        /// </summary>
        public bool Actualizar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__persona_familiares(this);
        }

        /// <summary>
        /// Método que elimina datos en la tabla tbl_persona_familiares
        /// </summary>
        public bool Eliminar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar__persona_familiares(this);
        }

        /// <summary>
        /// Método que obtiene ID para registros de tbl_persona_familiares
        /// </summary>
        public bool ObtenerId()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerId__persona_familiares(this);
        }

        /// <summary>
        /// Método que obtiene un registro de tbl_persona_familiares
        /// </summary>
        /// <param name="pf_id">
        /// Clave primaria de la tabla _persona_familiares
        /// </param>
        public bool ObtenerRegistro(int p_pf_id)
        {
            p_pf_id = pf_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro__persona_familiares(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_persona_familiares para llenar una grilla
        /// </summary>
        /// <param name="pf_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pf_per_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pf_tipo_parentesco">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pf_paterno">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pf_materno">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pf_nombres">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pf_ap_esposo">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pf_fecha_nac">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pf_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pf_estado_vivo">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pf_fecha_defuncion">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        public DataSet ObtenerTablaGrilla(
            string p_pf_id,
            string p_pf_per_id,
            string p_pf_tipo_parentesco,
            string p_pf_paterno,
            string p_pf_materno,
            string p_pf_nombres,
            string p_pf_ap_esposo,
            string p_pf_fecha_nac,
            string p_pf_estado,
            string p_pf_estado_vivo,
            string p_pf_fecha_defuncion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__persona_familiares(p_pf_id, p_pf_per_id, p_pf_tipo_parentesco, p_pf_paterno, p_pf_materno, p_pf_nombres, p_pf_ap_esposo, p_pf_fecha_nac, p_pf_estado, p_pf_estado_vivo, p_pf_fecha_defuncion);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_persona_familiares para llenar un combo
        /// </summary>
        public DataSet ObtenerTablaCombo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaCombo__persona_familiares();
        }
        public DataSet ObtenerGrillaFamiliares()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaFamiliares(this);
        }
        public DataSet ObtenerFamilarX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFamilarX(this);
        }
        public bool ActualizarEstadoFam()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarEstadoFam(this);
        }
        public DataSet ObtenerPersonaFamilarX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPersonaFamilarX(this);
        }
        #endregion
    }
}
