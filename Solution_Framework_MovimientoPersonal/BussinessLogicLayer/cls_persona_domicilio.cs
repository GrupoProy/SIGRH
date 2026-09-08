using Solution_Framework_MovimientoPersonal.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
    /// <summary>
	/// Proporciona funcionalidad para manejo de tbl_persona_domicilio.
	/// </summary>
	public class cls_persona_domicilio
    {
        #region PROPIEDADES
        public int perd_id { get; set; }
        public int perd_per_id { get; set; }
        public int perd_ciudad_residencia { get; set; }
        public int perd_zona { get; set; }
        public int perd_tipo_via { get; set; }
        public string perd_descripcion_via { get; set; }
        public string perd_numero { get; set; }
       
        public string perd_edificio { get; set; }
        public string perd_bloque { get; set; }
        public string perd_piso { get; set; }
        public string perd_dpto { get; set; }
        public string perd_telefono { get; set; }
        public string perd_celular { get; set; }
        public string perd_email { get; set; }
        public string perd_email_trabajo { get; set; }
        public string perd_fam_emergencia { get; set; }
        public string perd_dir_emergencia { get; set; }
        public string perd_tel_emergencia { get; set; }
        public string perd_coordenadas { get; set; }
        public string perd_estado { get; set; }
        public int perd_usuario_creacion { get; set; }
        public string perd_fecha_creacion { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_persona_domicilio
        /// </summary>
        public bool Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar__persona_domicilio(this);
        }

        /// <summary>
        /// Método que actualiza datos en la tabla tbl_persona_domicilio
        /// </summary>
        public bool Actualizar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__persona_domicilio(this);
        }

        /// <summary>
        /// Método que elimina datos en la tabla tbl_persona_domicilio
        /// </summary>
        public bool Eliminar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar__persona_domicilio(this);
        }

        /// <summary>
        /// Método que obtiene un registro de tbl_persona_domicilio
        /// </summary>
        /// <param name="perd_id">
        /// Clave primaria de la tabla _persona_domicilio
        /// </param>
        public bool ObtenerRegistro(int p_perd_id)
        {
            perd_id = p_perd_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro__persona_domicilio(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_persona_domicilio para llenar una grilla
        /// </summary>
        /// <param name="perd_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="perd_per_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="perd_ciudad_residencia">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="perd_zona">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="perd_tipo_via">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="perd_descripcion_via">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="perd_numero">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="perd_telefono">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="perd_celular">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="perd_email">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="perd_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        public DataSet ObtenerTablaGrilla(
            string p_perd_id,
            string p_perd_per_id,
            string p_perd_ciudad_residencia,
            string p_perd_zona,
            string p_perd_tipo_via,
            string p_perd_descripcion_via,
            string p_perd_numero,
            string p_perd_telefono,
            string p_perd_celular,
            string p_perd_email,
            string p_perd_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__persona_domicilio(p_perd_id, p_perd_per_id, p_perd_ciudad_residencia, p_perd_zona, p_perd_tipo_via, p_perd_descripcion_via, p_perd_numero, p_perd_telefono, p_perd_celular, p_perd_email, p_perd_estado);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_persona_domicilio para llenar un combo
        /// </summary>
        public DataSet ObtenerTablaCombo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaCombo__persona_domicilio();
        }
        public bool AdicionarDomicilioKardex(int file_id_cod, string per_num_lib)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarDomicilioKardex(this, file_id_cod, per_num_lib);
        }
        public DataSet ObtenerDatosFile()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosFile(this);
        }
        public DataSet VerificarExisteFile(int file_id_cod)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.VerificarExisteFile(file_id_cod);
        }
        public bool ActualizarTelefonosFun()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarTelefonosFun(this);
        }
        public bool Actualizar__Informacion_persona_domicilio()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__Informacion_persona_domicilio(this);
        }

        #endregion
    }
}
