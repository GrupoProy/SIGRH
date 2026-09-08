using Solution_Framework_General.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_General.BussinessLogicLayer
{
    /// <summary>
	/// Proporciona funcionalidad para manejo de tbl_catalogo.
	/// </summary>
	public class cls_catalogo
    {
        #region PROPIEDADES
        public int cat_id { get; set; }
        public string cat_tabla { get; set; }
        public int cat_secuencial { get; set; }
        public string cat_secuencial_op { get; set; }
        public string cat_descripcion { get; set; }
        public string cat_descripcion_op { get; set; }
        public string cat_abreviacion { get; set; }
        public int cat_id_superior { get; set; }
        public string cat_adicional { get; set; }
        public string cat_tabla_aux { get; set; }
        public string cat_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_catalogo
        /// </summary>
        public bool Adicionar(string cat_tabla, string cat_descripcion, string cat_abreviacion, string id_superior)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar__catalogo(cat_tabla, cat_descripcion, cat_abreviacion, id_superior);
        }
        public bool AdicionarCatalogoSecuencial()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarCatalogoSecuencial(this);
        }

        /// <summary>
        /// Método que actualiza datos en la tabla tbl_catalogo
        /// </summary>
        public bool Actualizar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__catalogo(this);
        }

        /// <summary>
        /// Método que elimina datos en la tabla tbl_catalogo
        /// </summary>
        public bool Eliminar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar__catalogo(this);
        }

        /// <summary>
        /// Método que obtiene ID para registros de tbl_catalogo
        /// </summary>
        public bool ObtenerId()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerId__catalogo(this);
        }

        /// <summary>
        /// Método que obtiene un registro de tbl_catalogo
        /// </summary>
        /// <param name="cat_id">
        /// Clave primaria de la tabla _catalogo
        /// </param>
        public DataSet ObtenerRegistro(int p_cat_id)
        {
            cat_id = p_cat_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro__catalogo(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_catalogo para llenar una grilla
        /// </summary>
        /// <param name="cat_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="cat_tabla">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="cat_secuencial">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="cat_descripcion">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="cat_abreviacion">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="cat_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="cat_id_superior">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="cat_adicional">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        public DataSet ObtenerTablaGrilla(
            string p_cat_id,
            string p_cat_tabla,
            string p_cat_secuencial,
            string p_cat_secuencial_op,
            string p_cat_descripcion,
            string p_cat_descripcion_op,
            string p_cat_abreviacion,
            string p_cat_id_superior,
            string p_cat_adicional,
            string p_cat_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__catalogo(p_cat_id, p_cat_tabla, p_cat_secuencial, p_cat_secuencial_op, p_cat_descripcion, p_cat_descripcion_op, p_cat_abreviacion, p_cat_id_superior, p_cat_adicional, p_cat_estado);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_catalgo para llenar un combo
        /// </summary>
        public DataSet ObtenerTablaCombo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaCombo__catalogo(this);
        }
        public DataSet ObtenerTablaComboSoloComision()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaComboSoloComision(this);
        }
        // (KCPB) Ayuda a obtener el lugar de nacimiento
        public DataSet ObtenerLugarNacimiento()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerLugarNacimiento__catalogo();
        }

        // (MICM) Ayuda a obtener el banco autorizado vigente
        public DataSet ObtenerBancoAutorizadoVigente()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerBancoAutorizadoVigente__catalogo();
        }

        // (MICM)
        public DataSet ObtenerSancionesAisaVigente()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerSancionesAisaVigente__catalogo();
        }
        public DataSet ObtenerRegistroPadre()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistroPadre(this);
        }
        public DataSet ObtenerCat_TablaPando()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCat_TablaPando(this);
        }
        public  DataSet ObtenerTablaComboFuncionario()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaCombo__catalogoFuncionario(this);
        }
        public  DataSet ObtenerDptoProvincia()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDptoProvincia();
        }
        public static (string modo, string control) ExtraerModoControl(string catAdicional)
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
    }
}
