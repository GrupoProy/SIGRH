using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Precontratacion.DataAccessLayer;

namespace Solution_Framework_Precontratacion.BussinessLogicLayer
{
    /// <summary>
    /// Proporciona funcionalidad para manejo de precontrataciones.
    /// </summary>
    public class cls_precontrataciones_cs
    {
        #region PROPIEDADES

        public string p_accion { get; set; }

        public int pp_us_id { get; set; }

        public int pp_per_id { get; set; }

        public int pp_es_id { get; set; }

        public int pp_eo_id { get; set; }

        public decimal pp_haber_basico { get; set; }

        public string pp_fecha_inicio { get; set; }

        public string pp_fecha_fin { get; set; }

        public string pp_p_descripcion { get; set; }

        public string pp_pu_objetivo { get; set; }

        public string pp_p_funciones { get; set; }

        public string pp_cite { get; set; }

        public int ca_id { get; set; }


        // ============================================================
        // PROPIEDADES PARA U1 - BAJA DE ASIGNACIÓN
        // ============================================================

        public int pp_as_id { get; set; }

        public string pp_as_tipo_baja { get; set; }

        public int pp_as_memo_baja { get; set; }

        public int p_ca_id_actual { get; set; }

        public int p_ca_num_item { get; set; }

        public string p_ca_estado { get; set; }


        // ============================================================
        // RESULTADO DE C3
        // ============================================================

        public int per_id { get; set; }

        public string per_num_doc { get; set; }

        public string per_ap_paterno { get; set; }

        public string per_ap_materno { get; set; }

        public string per_nombres { get; set; }

        public int as_id { get; set; }

        public DateTime as_fecha_inicio { get; set; }

        public DateTime as_fecha_fin { get; set; }

        public string ca_ti_item { get; set; }

        public int ca_num_item { get; set; }

        public string ca_aplica_incremento { get; set; }

        public string es_descripcion { get; set; }

        public decimal ns_haber_basico { get; set; }

        public string ns_nivel { get; set; }

        public string ns_clase { get; set; }

        public int p_id { get; set; }

        public string p_descripcion { get; set; }

        public int eo_id { get; set; }

        public string eo_descripcion { get; set; }

        public int cp_id { get; set; }

        public string cp_da { get; set; }

        public string cp_ue { get; set; }

        public string cp_programa { get; set; }

        public string cp_proyecto { get; set; }

        public string cp_actividad { get; set; }

        public int descrip_pu_id { get; set; }

        public string descrip_pu_objetivo { get; set; }

        public string descrip_pu_puesto { get; set; }

        public int des_p_result_id { get; set; }

        public string result_resultado { get; set; }
       

        #endregion


        #region METODOS

        /// <summary>
        /// Método que verifica el estado de una persona (E1)
        /// </summary>
        public DataSet VerificarEstadoPersona()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer =
                new DataAccessLayerSQLDataAccessLayer();

            return DBLayer.VerificarEstadoPersona__precontrataciones_cs(this);
        }


        /// <summary>
        /// Método que crea un nuevo contrato (A2)
        /// </summary>
        /// <returns>El AS_ID del nuevo contrato creado</returns>
        public int CrearContrato()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer =
                new DataAccessLayerSQLDataAccessLayer();

            return DBLayer.CrearContrato__precontrataciones_cs(this);
        }


        /// <summary>
        /// Método que obtiene la tabla de contratos para llenar una grilla (PC1)
        /// </summary>
        public DataSet ObtenerListaContratos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer =
                new DataAccessLayerSQLDataAccessLayer();

            return DBLayer.ObtenerListaContratos__precontrataciones_cs(
                this.pp_us_id);
        }


        /// <summary>
        /// Método que obtiene la escala salarial para contratos (PC2)
        /// </summary>
        public DataSet ObtenerEscalasSalariales()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer =
                new DataAccessLayerSQLDataAccessLayer();

            return DBLayer.ObtenerEscalasSalariales__precontrataciones_cs();
        }


        /// <summary>
        /// Método que obtiene los datos del contrato de una persona (C3)
        /// </summary>
        public DataSet ObtenerContratoPorPersona(int p_per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer =new DataAccessLayerSQLDataAccessLayer();

            return DBLayer.ObtenerContratoPorPersona__precontrataciones_cs(p_per_id);
        }


        /// <summary>
        /// Método que obtiene los datos del contrato de una persona
        /// y los carga en las propiedades.
        /// </summary>
        public bool CargarContratoPorPersona(int p_per_id)
        {
            DataSet ds = ObtenerContratoPorPersona(p_per_id);

            if (ds != null &&
                ds.Tables.Count > 0 &&
                ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                this.per_id = Convert.ToInt32(row["per_id"]);

                per_num_doc =
                    row["per_num_doc"].ToString();

                per_ap_paterno =
                    row["per_ap_paterno"].ToString();

                per_ap_materno =
                    row["per_ap_materno"].ToString();

                per_nombres =
                    row["per_nombres"].ToString();

                as_id =
                    Convert.ToInt32(row["as_id"]);

                as_fecha_inicio =
                    Convert.ToDateTime(row["as_fecha_inicio"]);

                as_fecha_fin =
                    Convert.ToDateTime(row["as_fecha_fin"]);

                ca_id =
                    Convert.ToInt32(row["ca_id"]);

                ca_ti_item =
                    row["ca_ti_item"].ToString();

                ca_num_item =
                    Convert.ToInt32(row["ca_num_item"]);

                // Se carga solamente si C3 devuelve esta columna
                if (ds.Tables[0].Columns.Contains("ca_aplica_incremento"))
                {
                    ca_aplica_incremento =
                        row["ca_aplica_incremento"] != DBNull.Value
                            ? row["ca_aplica_incremento"].ToString()
                            : "";
                }

                es_descripcion =
                    row["es_descripcion"].ToString();

                ns_haber_basico =
                    Convert.ToDecimal(row["ns_haber_basico"]);

                ns_nivel =
                    row["ns_nivel"] != DBNull.Value
                        ? row["ns_nivel"].ToString()
                        : "";

                ns_clase =
                    row["ns_clase"] != DBNull.Value
                        ? row["ns_clase"].ToString()
                        : "";

                p_id =
                    Convert.ToInt32(row["p_id"]);

                p_descripcion =
                    row["p_descripcion"].ToString();

                eo_id =
                    Convert.ToInt32(row["eo_id"]);

                eo_descripcion =
                    row["eo_descripcion"].ToString();

                cp_id =
                    Convert.ToInt32(row["cp_id"]);

                cp_da =
                    row["cp_da"].ToString();

                cp_ue =
                    row["cp_ue"].ToString();

                cp_programa =
                    row["cp_programa"].ToString();

                cp_proyecto =
                    row["cp_proyecto"].ToString();

                cp_actividad =
                    row["cp_actividad"].ToString();

                descrip_pu_id =
                    Convert.ToInt32(row["descrip_pu_id"]);

                descrip_pu_objetivo =
                    row["descrip_pu_objetivo"].ToString();

                descrip_pu_puesto =
                    row["descrip_pu_puesto"].ToString();

                des_p_result_id =
                    Convert.ToInt32(row["des_p_result_id"]);

                result_resultado =
                    row["result_resultado"].ToString();

                return true;
            }

            return false;
        }


        /// <summary>
        /// Obtiene el nivel y clase de una escala salarial.
        /// </summary>
        public DataSet ObtenerNivelClaseEscala(int esId)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer =
                new DataAccessLayerSQLDataAccessLayer();

            return DBLayer.ObtenerNivelClaseEscala__precontrataciones_cs(
                esId);
        }


        // ============================================================
        // MÉTODO PARA U1
        // BAJA DE ASIGNACION - MODIFICACION
        // ============================================================

        /// <summary>
        /// Método que da de baja una asignación (U1).
        /// </summary>
        public bool ActualizarBajaAsignacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarBajaAsignacion__precontrataciones_cs(this);
        }

        #endregion
    }
}