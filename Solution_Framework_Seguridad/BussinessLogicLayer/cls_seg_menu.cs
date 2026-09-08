using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Solution_Framework_Seguridad.BussinessLogicLayer
{
    /// <summary>
    /// Proporciona funcionalidad para manejo de tbl_seg_menu.
    /// </summary>
    public class cls_seg_menu
    {
        #region PROPIEDADES
        public int me_id { get; set; }
        public string me_descripcion { get; set; }
        public string me_url { get; set; }
        public string me_icono { get; set; }
        public int me_id_padre { get; set; }
        public string me_estado { get; set; }
        public DateTime me_fecha_creacion { get; set; }
        public string me_usuario_creacion { get; set; }
        public bool me_vista { get; set; }
        public List<cls_seg_menu> me_lista { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_seg_menu
        /// </summary>
        public int Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar__seg_menu(this);
        }

        /// <summary>
        /// Método que actualiza datos en la tabla tbl_seg_menu
        /// </summary>
        public bool Actualizar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__seg_menu(this);
        }

        /// <summary>
        /// Método que elimina datos en la tabla tbl_seg_menu
        /// </summary>
        public bool Eliminar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar__seg_menu(this);
        }

        /// <summary>
        /// Método que obtiene un registro de tbl_seg_menu
        /// </summary>
        /// <param name="me_id">
        /// Clave primaria de la tabla _menu
        /// </param>
        public DataSet ObtenerRegistro(int p_me_id)
        {
            me_id = p_me_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro__seg_menu(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_seg_menu para llenar una grilla
        /// </summary>
        /// <param name="me_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="me_descripcion">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="me_url">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="me_icono">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="me_id_padre">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="me_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        public DataSet ObtenerTablaGrilla(
            string p_me_id,
            string p_me_descripcion,
            string p_me_url,
            string p_me_icono,
            string p_me_id_padre,
            string p_me_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__seg_menu(p_me_id, p_me_descripcion, p_me_url, p_me_icono, p_me_id_padre, p_me_estado);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_seg_menu para llenar un combo
        /// </summary>
        public DataSet ObtenerTablaCombo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaCombo__seg_menu();
        }

        public DataSet ObtenerMenuRol(int p_me_id)
        {
            me_id = p_me_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerMenuRol__seg_menu(this);
        }
        public DataSet ObtenerMenuRolINVITADO(int p_me_id)
        {
            me_id = p_me_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerMenuRol__seg_menuINVITADO(this);
        }
        public bool ActualizarNodo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarNodo__seg_menu(this);
        }
        #endregion
    }
}
