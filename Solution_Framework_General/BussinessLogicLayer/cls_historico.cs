using Solution_Framework_General.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_General.BussinessLogicLayer
{
    /// <summary>
	/// Proporciona funcionalidad para manejo de historico.
	/// </summary>
	public class cls_historico
    {
        #region PROPIEDADES
        public int his_id { get; set; }
        public string his_tipo_abm { get; set; }
        public string his_nom_tabla { get; set; }
        public string his_nom_pk { get; set; }
        public string his_valor_pk { get; set; }
        public string his_campos { get; set; }
        public int his_usuario_creacion { get; set; }
        public DateTime his_fecha_creacion { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en historico
        /// </summary>
        public bool Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar_historico(this);
        }

        /// <summary>
        /// Método que obtiene ID para registros de historico
        /// </summary>
        public bool ObtenerId()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerId_historico(this);
        }

        /// <summary>
        /// Método que obtiene un registro de historico
        /// </summary>
        /// <param name="his_id">
        /// Clave primaria de la tabla historico
        /// </param>
        public DataSet ObtenerRegistro(int p_his_id)
        {
            his_id = p_his_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro_historico(this);
        }

        /// <summary>
        /// Método que obtiene la tabla historico para llenar una grilla
        /// </summary>
        /// <param name="his_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="his_tipo_abm">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="his_nom_tabla">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="his_nom_pk">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="his_valor_pk">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="his_campos">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="his_fecha_creacion">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="his_usuario_creacion">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        public DataSet ObtenerTablaGrilla(
            string his_id,
            string his_tipo_abm,
            string his_nom_tabla,
            string his_nom_pk,
            string his_valor_pk,
            string his_campos,
            string his_fecha_creacion,
            string his_usuario_creacion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla_historico(his_id, his_tipo_abm, his_nom_tabla, his_nom_pk, his_valor_pk, his_campos, his_fecha_creacion, his_usuario_creacion);
        }
        #endregion
    }
}
