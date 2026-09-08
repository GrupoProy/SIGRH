using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Precontratacion.DataAccessLayer;

namespace Solution_Framework_Precontratacion.BussinessLogicLayer
{
    /// <summary>
    /// Proporciona funcionalidad para manejo de tbl_permiso_categoria_programatica.
    /// </summary>
    public class cls_permiso_categoria_programatica
    {
        #region PROPIEDADES
        public int pcp_id { get; set; }
        public int pcp_rol { get; set; }
        public int pcp_ue { get; set; }
        public int pcp_cp_id { get; set; }
        public string pcp_estado { get; set; }
        public int pcp_us_id { get; set; }
        public int pcp_pr_id { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_permiso_categoria_programatica
        /// </summary>
        public bool Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar__permiso_categoria_programatica(this);
        }

        /// <summary>
        /// Método que actualiza datos en la tabla tbl_permiso_categoria_programatica
        /// </summary>
        public bool Actualizar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__permiso_categoria_programatica(this);
        }

        /// <summary>
        /// Método que elimina datos en la tabla tbl_permiso_categoria_programatica
        /// </summary>
        public bool Eliminar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar__permiso_categoria_programatica(this);
        }

        /// <summary>
        /// Método que obtiene un registro de tbl_permiso_categoria_programatica
        /// </summary>
        /// <param name="pcp_id">
        /// Clave primaria de la tabla _permiso_categoria_programatica
        /// </param>
        public DataSet ObtenerRegistro(int p_pcp_id)
        {
            pcp_id = p_pcp_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro__permiso_categoria_programatica(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_permiso_categoria_programatica para llenar una grilla
        /// </summary>
        /// <param name="pcp_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pcp_rol">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pcp_ue">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pcp_cp_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pcp_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pcp_us_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pcp_pr_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        public DataSet ObtenerTablaGrilla(
            string pcp_id,
            string pcp_rol,
            string pcp_ue,
            string pcp_cp_id,
            string pcp_estado,
            string pcp_us_id,
            string pcp_pr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__permiso_categoria_programatica(pcp_id, pcp_rol, pcp_ue, pcp_cp_id, pcp_estado, pcp_us_id, pcp_pr_id);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_permiso_categoria_programatica para llenar un combo
        /// </summary>
        public DataSet ObtenerTablaCombo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaCombo__permiso_categoria_programatica(this);
        }
        #endregion
    }
}
