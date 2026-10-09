using Solution_Framework_General.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_General.BussinessLogicLayer
{
    /// <summary>
	/// Proporciona funcionalidad para manejo de tbl_glosa.
	/// </summary>
	public class cls_glosa
    {
        #region PROPIEDADES
        public int gl_id { get; set; }
        public string gl_valor_pk { get; set; }
        public string gl_nombre_pk { get; set; }
        public string gl_tabla { get; set; }
        public int gl_tipo_mov { get; set; }
        public int gl_tipo_doc { get; set; }
        public string gl_glosa { get; set; }
        public string gl_numero_doc { get; set; }
        public DateTime gl_fecha_doc { get; set; }
        public string gl_estado { get; set; }
        public int gl_usuario { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_glosa
        /// </summary>
        public bool Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar__glosa(this);
        }

        /// <summary>
        /// Método que actualiza datos en la tabla tbl_glosa
        /// </summary>
        public bool Actualizar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__glosa(this);
        }

        /// <summary>
        /// Método que elimina datos en la tabla tbl_glosa
        /// </summary>
        public bool Eliminar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar__glosa(this);
        }

        /// <summary>
        /// Método que obtiene un registro de tbl_glosa
        /// </summary>
        /// <param name="gl_id">
        /// Clave primaria de la tabla _glosa
        /// </param>
        public DataSet ObtenerRegistro(int p_gl_id)
        {
            gl_id = p_gl_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro__glosa(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_glosa para llenar una grilla
        /// </summary>
        /// <param name="gl_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="gl_valor_pk">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="gl_nombre_pk">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="gl_tabla">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="gl_tipo_mov">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="gl_fecha_doc">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="gl_tipo_doc">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="gl_glosa">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="gl_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        public DataSet ObtenerTablaGrilla(
            string p_gl_id,
            string p_gl_valor_pk,
            string p_gl_nombre_pk,
            string p_gl_tabla,
            string p_gl_tipo_mov,
            string p_gl_tipo_doc,
            string p_gl_glosa,
            string p_gl_numero_doc,
            string p_gl_fecha_doc,
            string p_gl_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__glosa(p_gl_id, p_gl_valor_pk, p_gl_nombre_pk, p_gl_tabla, p_gl_tipo_mov, p_gl_tipo_doc, p_gl_glosa, p_gl_numero_doc, p_gl_fecha_doc, p_gl_estado);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_glosa para llenar un combo
        /// </summary>
        public DataSet ObtenerTablaCombo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaCombo__glosa();
        }

        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla para llenar una grilla
        public DataSet ObtenerTablaGrillaC(
            string p_gl_id,
            string p_gl_valor_pk,
            string p_gl_nombre_pk,
            string p_gl_tabla,
            string p_gl_tipo_mov,
            string p_gl_tipo_doc,
            string p_gl_glosa,
            string p_gl_numero_doc,
            string p_gl_fecha_doc,
            string p_gl_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaC__glosa(p_gl_id, p_gl_valor_pk, p_gl_nombre_pk, p_gl_tabla, p_gl_tipo_mov, p_gl_tipo_doc, p_gl_glosa, p_gl_numero_doc, p_gl_fecha_doc, p_gl_estado);
        }
        #endregion
    }
}
