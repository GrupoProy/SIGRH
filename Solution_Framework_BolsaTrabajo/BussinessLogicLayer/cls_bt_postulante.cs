using Solution_Framework_BolsaTrabajo.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_BolsaTrabajo.BussinessLogicLayer
{
    /// <summary>
	/// Proporciona funcionalidad para manejo de tbl_bt_postulante.
	/// </summary>
	public class cls_bt_postulante
    {
        #region PROPIEDADES
        public int po_id { get; set; }
        public int po_tipo_doc { get; set; }
        public string po_num_doc { get; set; }
        public int po_lugar_exp { get; set; }
        public string po_paterno { get; set; }
        public string po_materno { get; set; }
        public string po_primer_nombre { get; set; }
        public string po_segundo_nombre { get; set; }
        public string po_ap_casada { get; set; }
        public string po_sexo { get; set; }
        public DateTime po_fecha_nacimiento { get; set; }
        public int? po_nacionalidad { get; set; }
        public string po_num_libreta_militar { get; set; }
        public int? po_lugar_nacimiento { get; set; }
        public string po_estado_civil { get; set; }
        // domicilio
        public int po_ciudad_residencia { get; set; }
        public int po_zona { get; set; }
        public int po_tipo_via { get; set; }
        public string po_descripcion_via { get; set; }
        public string po_numero { get; set; }
        public string po_telefono { get; set; }
        public string po_celular { get; set; }
        public string po_correo { get; set; }
        public string po_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_bt_postulante
        /// </summary>
        public bool Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar__bt_postulante(this);
        }

        /// <summary>
        /// Método que actualiza datos en la tabla tbl_bt_postulante
        /// </summary>
        public bool Actualizar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__bt_postulante(this);
        }

        /// <summary>
        /// Método que elimina datos en la tabla tbl_bt_postulante
        /// </summary>
        public bool Eliminar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar__bt_postulante(this);
        }

        /// <summary>
        /// Método que obtiene ID para registros de tbl_bt_postulante
        /// </summary>
        public bool ObtenerId()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerId__bt_postulante(this);
        }

        /// <summary>
        /// Método que obtiene un registro de tbl_bt_postulante
        /// </summary>
        /// <param name="po_id">
        /// Clave primaria de la tabla _bt_postulante
        /// </param>
        public DataSet ObtenerRegistros(int p_po_id)
        {
            po_id = p_po_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistros__bt_postulante(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_bt_postulante para llenar una grilla
        /// </summary>
        /// <param name="po_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_primer_nombre">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_segundo_nombre">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_paterno">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_materno">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_ap_casada">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_correo">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_tipo_doc">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_num_doc">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_lugar_exp">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_estado_civil">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_fecha_nacimiento">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_lugar_nacimiento">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_nacionalidad">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_sexo">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_zona">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_tipo_via">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_descripcion_via">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_numero">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_telefono">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_celular">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_ciudad_residencia">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_num_libreta_militar">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="po_codigo_fun">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        public DataSet ObtenerTablaGrilla(
            string p_po_id,
            string p_po_primer_nombre,
            string p_po_segundo_nombre,
            string p_po_paterno,
            string p_po_materno,
            string p_po_ap_casada,
            string p_po_correo,
            string p_po_tipo_doc,
            string p_po_num_doc,
            string p_po_lugar_exp,
            string p_po_estado_civil,
            string p_po_fecha_nacimiento,
            string p_po_lugar_nacimiento,
            string p_po_nacionalidad,
            string p_po_sexo,
            string p_po_zona,
            string p_po_tipo_via,
            string p_po_descripcion_via,
            string p_po_numero,
            string p_po_telefono,
            string p_po_celular,
            string p_po_ciudad_residencia,
            string p_po_num_libreta_militar,
            string p_po_estado,
            string p_po_codigo_fun,
            string p_po_nro_libro)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__bt_postulante(p_po_id, p_po_primer_nombre, p_po_segundo_nombre, p_po_paterno, p_po_materno, p_po_ap_casada, p_po_correo, p_po_tipo_doc, p_po_num_doc, p_po_lugar_exp, p_po_estado_civil, p_po_fecha_nacimiento, p_po_lugar_nacimiento, p_po_nacionalidad, p_po_sexo, p_po_zona, p_po_tipo_via, p_po_descripcion_via, p_po_numero, p_po_telefono, p_po_celular, p_po_ciudad_residencia, p_po_num_libreta_militar, p_po_estado, p_po_codigo_fun, p_po_nro_libro);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_bt_postulante para llenar un combo
        /// </summary>
        public DataSet ObtenerTablaCombo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaCombo__bt_postulante();
        }
        #endregion

    }
}
