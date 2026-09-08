using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Solution_Framework_ManualPuestos.BussinessLogicLayer
{
     public class cls_mp_descriptor_puestos
    {

        public string result_indicador { get; set; }
        public decimal result_ponderacion { get; set; }
        public string result_resultado { get; set; }
        public int des_p_result_id { get; set; }
       // public int des_p_result_id { get; set; }
        public byte[] descrip_pdf { get; set; }

        public string Nom_Comp { get; set; }

        public bool Adicionar_descriptor_puestos(int perso_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar_descriptor_puestos(perso_id);
        }

        public DataSet Listar_Supervisores()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Listar_Supervisores();

        }

        public bool Add_descriptor_puestos(int per_id, int superv_id, String descrip_pu_objetivo)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.Add_descriptor_puestos(per_id, superv_id, descrip_pu_objetivo);
        }
        public int Verificar_ca_id(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Verificar_ca_id(per_id);

        }

        public DataSet ObtenerRegistro_DescriptorPuesto(int descrip_pu_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro_DescriptorPuesto(descrip_pu_id);

        }

        public bool Add_DPR(string result_indicador, decimal result_ponderacion, String result_resultado, int dpr)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Add_DPR(result_indicador, result_ponderacion, result_resultado, dpr);
        }

        public DataSet ListarTareaEspecifica(int dpr, string result_tipo)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarTareaEspecifica(dpr, result_tipo);

        }

        public DataSet DevolverDatosResultadosEspecificos(int dpr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.DevolverDatosResultadosEspecificos(dpr_id);
        }
       

        /*public bool ActualizarTE(int des_p_result_id, string result_indicador, decimal result_ponderacion, String result_resultado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarTE(des_p_result_id, result_indicador, result_ponderacion, result_resultado);
        }*/

       /* public bool Eliminar_TE(int des_p_result_id)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.Eliminar_TE(des_p_result_id);
        }*/

        public decimal TotalE(int descrip_pu_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.TotalE(descrip_pu_id);
        }

        public DataSet ListarTareaE(int id_r)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarTareaE(id_r);

        }

        public DataSet ListarResltaE(int id_r)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarResltaE(id_r);

        }

        public bool Update_DPR(int des_p_result_id, string result_indicador, decimal result_ponderacion, string result_resultado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Update_DPR(des_p_result_id, result_indicador, result_ponderacion, result_resultado);
        }

        public bool Actualizar_UPR()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar_UPR(this);
        }

        public bool Eliminar_DPR(int des_p_result_id, string result_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar_DPR(des_p_result_id, result_estado);
        }
        public string Add_TareaEspecifica(string result_indicador, decimal result_ponderacion, String result_resultado, int dpr)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Add_TareaEspecifica(result_indicador, result_ponderacion, result_resultado, dpr);
        }

        public bool Update_DPEE(int des_p_result_id, string result_indicador, decimal result_ponderacion, string result_resultado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Update_DPEE(des_p_result_id, result_indicador, result_ponderacion, result_resultado);
        }


        //============================ TAREAS RECURRENTES ================================================
        /*
        public bool Add_TareaRecurrente(decimal result_ponderacion, String result_resultado, int dpr)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Add_TareaRecurrente(result_ponderacion, result_resultado, dpr);
        }*/

        public decimal TotalER(int descrip_pu_id, string result_tipo)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.TotalER(descrip_pu_id, result_tipo);
        }

        public string Add_TareaRecurrente(decimal result_ponderacion, String result_resultado, int dpr)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Add_TareaRecurrente(result_ponderacion, result_resultado, dpr);
        }

        public bool Update_DPER(int des_p_result_id, string result_indicador, decimal result_ponderacion, string result_resultado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Update_DPER(des_p_result_id, result_indicador, result_ponderacion, result_resultado);
        }

        public int UpdateTER_PDF(int des_p_result_id, byte[] descrip_pdf)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.UpdateTER_PDF(des_p_result_id, descrip_pdf);

        }
        //===================== SUPERVISOR ========================
        public int supervisor_id(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.supervisor_id(per_id);

        }

        public int Obtener_idSuperv(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Obtener_idSuperv(per_id);

        }
        public DataSet ListarTareaSuper(int superv_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarTareaSuper(superv_id);

        }

        public DataSet ListarTareaER(int dpr)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarTareaER(dpr);

        }

        /* public byte[] ObtenerPdf(int descrip_pu_id)
         {
             DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
             return DBLayer.ObtenerPdf(descrip_pu_id);

         }*/
        public DataSet ObtenerPdf(int des_p_result_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPdf(des_p_result_id);

        }

        //============================== EVALUACION ==========================================
        public string Add_Eva(decimal ponderacion, int prdo, int result_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Add_Eva(ponderacion, prdo, result_id);
        }

        public decimal result_PonderacionTarea(int des_p_result_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.result_PonderacionTarea(des_p_result_id);
        }
        public bool Update_EstadoResultado(int des_p_result_id, string result_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Update_EstadoResultado(des_p_result_id, result_estado);

        }
        public DataSet Listar_EvaluacionesCa(int des_p_result_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Listar_EvaluacionesCa(des_p_result_id);

        }

        public DataSet ResultEva(int evalua_dp_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ResultEva(evalua_dp_id);

        }
        public int devuelver_Si_hayPDF(int des_p_result_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.devuelver_Si_hayPDF(des_p_result_id);

        }

        public int ne_secuencial(int ca_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ne_secuencial(ca_id);

        }

        public int ca_per(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ca_per(per_id);

        }


        public int devuelver_ca_id(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.devuelver_ca_id(per_id);

        }


        public int ne_id(int ca_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ne_id(ca_id);

        }

        public int result(int ca_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.result(ca_id);

        }

        public bool Update_DP(int pu_id, string pu_objetivo)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Update_DP(pu_id, pu_objetivo);
        }

        public string  Nom_Com(int pu_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Nom_Com(pu_id);
        }

        public DataSet ObtenerTablaGrillaC__mp_asignacion(string per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaC__mp_asignacion(per_id);
        }

    }
}
