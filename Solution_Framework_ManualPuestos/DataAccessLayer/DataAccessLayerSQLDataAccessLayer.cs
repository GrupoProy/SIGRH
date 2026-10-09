using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using Solution_Framework_ManualPuestos.DataAccessLayer;

namespace Solution_Framework_ManualPuestos.BussinessLogicLayer
{
    public class DataAccessLayerSQLDataAccessLayer : DataAccessLayerDataAccessLayer
    {
        #region CONSTANTES
        private string SP__MDP_FORMACION = "sp_mdp_formacion";
        private string SP__MDP_CARACTER_INDIVIDUAL = "sp_mdp_caracter_individual";
        private string SP__MDP_CONOCIMIENTO = "sp_mdp_conocimiento";
        private string SP__MDP_DISPOSICION_JURIDICA = "sp_mdp_disposicion_juridica";
        private string SP_SI_UDEP_IDIOMAORIG = "spSI_UDEP_IdiomaOrig";
        private string SP__MDP_RESULTADOS_ESPECIFICOS = "sp_mdp_resultados_especificos";
        private string SP__MDP_PUESTO = "sp_mdp_puesto";
        private string SP__DESCRIPTOR_PUESTOS = "SP_mp_DescriptorPuestos";
        private string sp_poais = "SP_mp_DescriptorPuestos";
        #endregion

        //INTERFACES
        #region SI_UDEP_IDIOMAORIG
        public override bool Adicionar_SI_UDEP_IdiomaOrig(clsSI_UDEP_IdiomaOrig SI_UDEP_IdiomaOrig)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP_SI_UDEP_IDIOMAORIG);

                CnxSigrh3.AddInParameter(icom, "p_id", DbType.Int32, SI_UDEP_IdiomaOrig.id);
                CnxSigrh3.AddInParameter(icom, "p_Cod_fun", DbType.Int32, SI_UDEP_IdiomaOrig.Cod_fun);
                CnxSigrh3.AddInParameter(icom, "p_P1_1", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_1);
                CnxSigrh3.AddInParameter(icom, "p_P1_2", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_2);
                CnxSigrh3.AddInParameter(icom, "p_P1_3", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_3);
                CnxSigrh3.AddInParameter(icom, "p_P1_4", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_4);
                CnxSigrh3.AddInParameter(icom, "p_P1_5", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_5);
                CnxSigrh3.AddInParameter(icom, "p_P1_6", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_6);
                CnxSigrh3.AddInParameter(icom, "p_P1_7", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_7);
                CnxSigrh3.AddInParameter(icom, "p_P1_8", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_8);
                CnxSigrh3.AddInParameter(icom, "p_P1_9", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_9);
                CnxSigrh3.AddInParameter(icom, "p_P1_10", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_10);
                CnxSigrh3.AddInParameter(icom, "p_P1_11", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_11);
                CnxSigrh3.AddInParameter(icom, "p_P1_12", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_12);
                CnxSigrh3.AddInParameter(icom, "p_P2", DbType.String, SI_UDEP_IdiomaOrig.P2);
                CnxSigrh3.AddInParameter(icom, "p_P3", DbType.Boolean, SI_UDEP_IdiomaOrig.P3);
                CnxSigrh3.AddInParameter(icom, "p_P3_1", DbType.String, SI_UDEP_IdiomaOrig.P3_1);
                CnxSigrh3.AddInParameter(icom, "p_P3_2", DbType.Int32, SI_UDEP_IdiomaOrig.P3_2);
                CnxSigrh3.AddInParameter(icom, "p_P4", DbType.Boolean, SI_UDEP_IdiomaOrig.P4);
                CnxSigrh3.AddInParameter(icom, "p_P4_1", DbType.String, SI_UDEP_IdiomaOrig.P4_1);
                CnxSigrh3.AddInParameter(icom, "p_P4_2", DbType.Int32, SI_UDEP_IdiomaOrig.P4_2);
                CnxSigrh3.AddInParameter(icom, "p_P5", DbType.Boolean, SI_UDEP_IdiomaOrig.P5);
                CnxSigrh3.AddInParameter(icom, "p_P5_1", DbType.String, SI_UDEP_IdiomaOrig.P5_1);
                CnxSigrh3.AddInParameter(icom, "p_P6_1_Cual_Idioma", DbType.String, SI_UDEP_IdiomaOrig.P6_1_Cual_Idioma);
                CnxSigrh3.AddInParameter(icom, "p_P6_1_Donde", DbType.String, SI_UDEP_IdiomaOrig.P6_1_Donde);
                CnxSigrh3.AddInParameter(icom, "p_P6_2", DbType.Boolean, SI_UDEP_IdiomaOrig.P6_2);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar_SI_UDEP_IdiomaOrig(clsSI_UDEP_IdiomaOrig SI_UDEP_IdiomaOrig)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP_SI_UDEP_IDIOMAORIG);

                CnxSigrh3.AddInParameter(icom, "p_id", DbType.Int32, SI_UDEP_IdiomaOrig.id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Actualizar_SI_UDEP_IdiomaOrig(clsSI_UDEP_IdiomaOrig SI_UDEP_IdiomaOrig)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP_SI_UDEP_IDIOMAORIG);

                CnxSigrh3.AddInParameter(icom, "p_id", DbType.Int32, SI_UDEP_IdiomaOrig.id);
                CnxSigrh3.AddInParameter(icom, "p_Cod_fun", DbType.Int32, SI_UDEP_IdiomaOrig.Cod_fun);
                CnxSigrh3.AddInParameter(icom, "p_P1_1", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_1);
                CnxSigrh3.AddInParameter(icom, "p_P1_2", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_2);
                CnxSigrh3.AddInParameter(icom, "p_P1_3", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_3);
                CnxSigrh3.AddInParameter(icom, "p_P1_4", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_4);
                CnxSigrh3.AddInParameter(icom, "p_P1_5", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_5);
                CnxSigrh3.AddInParameter(icom, "p_P1_6", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_6);
                CnxSigrh3.AddInParameter(icom, "p_P1_7", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_7);
                CnxSigrh3.AddInParameter(icom, "p_P1_8", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_8);
                CnxSigrh3.AddInParameter(icom, "p_P1_9", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_9);
                CnxSigrh3.AddInParameter(icom, "p_P1_10", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_10);
                CnxSigrh3.AddInParameter(icom, "p_P1_11", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_11);
                CnxSigrh3.AddInParameter(icom, "p_P1_12", DbType.Boolean, SI_UDEP_IdiomaOrig.P1_12);
                CnxSigrh3.AddInParameter(icom, "p_P2", DbType.String, SI_UDEP_IdiomaOrig.P2);
                CnxSigrh3.AddInParameter(icom, "p_P3", DbType.Boolean, SI_UDEP_IdiomaOrig.P3);
                CnxSigrh3.AddInParameter(icom, "p_P3_1", DbType.String, SI_UDEP_IdiomaOrig.P3_1);
                CnxSigrh3.AddInParameter(icom, "p_P3_2", DbType.Int32, SI_UDEP_IdiomaOrig.P3_2);
                CnxSigrh3.AddInParameter(icom, "p_P4", DbType.Boolean, SI_UDEP_IdiomaOrig.P4);
                CnxSigrh3.AddInParameter(icom, "p_P4_1", DbType.String, SI_UDEP_IdiomaOrig.P4_1);
                CnxSigrh3.AddInParameter(icom, "p_P4_2", DbType.Int32, SI_UDEP_IdiomaOrig.P4_2);
                CnxSigrh3.AddInParameter(icom, "p_P5", DbType.Boolean, SI_UDEP_IdiomaOrig.P5);
                CnxSigrh3.AddInParameter(icom, "p_P5_1", DbType.String, SI_UDEP_IdiomaOrig.P5_1);
                CnxSigrh3.AddInParameter(icom, "p_P6_1_Cual_Idioma", DbType.String, SI_UDEP_IdiomaOrig.P6_1_Cual_Idioma);
                CnxSigrh3.AddInParameter(icom, "p_P6_1_Donde", DbType.String, SI_UDEP_IdiomaOrig.P6_1_Donde);
                CnxSigrh3.AddInParameter(icom, "p_P6_2", DbType.Boolean, SI_UDEP_IdiomaOrig.P6_2);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId_SI_UDEP_IdiomaOrig(clsSI_UDEP_IdiomaOrig SI_UDEP_IdiomaOrig)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP_SI_UDEP_IDIOMAORIG);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                SI_UDEP_IdiomaOrig.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerRegistro_SI_UDEP_IdiomaOrig(clsSI_UDEP_IdiomaOrig SI_UDEP_IdiomaOrig)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP_SI_UDEP_IDIOMAORIG);

                CnxSigrh3.AddInParameter(icom, "p_id", DbType.Int32, SI_UDEP_IdiomaOrig.id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["id"] != DBNull.Value && ds.Tables[0].Rows[0]["id"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]); }
                if (ds.Tables[0].Rows[0]["Cod_fun"] != DBNull.Value && ds.Tables[0].Rows[0]["Cod_fun"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.Cod_fun = Convert.ToInt32(ds.Tables[0].Rows[0]["Cod_fun"]); }
                if (ds.Tables[0].Rows[0]["P1_1"] != DBNull.Value && ds.Tables[0].Rows[0]["P1_1"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P1_1 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P1_1"]); }
                if (ds.Tables[0].Rows[0]["P1_2"] != DBNull.Value && ds.Tables[0].Rows[0]["P1_2"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P1_2 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P1_2"]); }
                if (ds.Tables[0].Rows[0]["P1_3"] != DBNull.Value && ds.Tables[0].Rows[0]["P1_3"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P1_3 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P1_3"]); }
                if (ds.Tables[0].Rows[0]["P1_4"] != DBNull.Value && ds.Tables[0].Rows[0]["P1_4"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P1_4 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P1_4"]); }
                if (ds.Tables[0].Rows[0]["P1_5"] != DBNull.Value && ds.Tables[0].Rows[0]["P1_5"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P1_5 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P1_5"]); }
                if (ds.Tables[0].Rows[0]["P1_6"] != DBNull.Value && ds.Tables[0].Rows[0]["P1_6"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P1_6 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P1_6"]); }
                if (ds.Tables[0].Rows[0]["P1_7"] != DBNull.Value && ds.Tables[0].Rows[0]["P1_7"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P1_7 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P1_7"]); }
                if (ds.Tables[0].Rows[0]["P1_8"] != DBNull.Value && ds.Tables[0].Rows[0]["P1_8"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P1_8 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P1_8"]); }
                if (ds.Tables[0].Rows[0]["P1_9"] != DBNull.Value && ds.Tables[0].Rows[0]["P1_9"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P1_9 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P1_9"]); }
                if (ds.Tables[0].Rows[0]["P1_10"] != DBNull.Value && ds.Tables[0].Rows[0]["P1_10"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P1_10 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P1_10"]); }
                if (ds.Tables[0].Rows[0]["P1_11"] != DBNull.Value && ds.Tables[0].Rows[0]["P1_11"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P1_11 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P1_11"]); }
                if (ds.Tables[0].Rows[0]["P1_12"] != DBNull.Value && ds.Tables[0].Rows[0]["P1_12"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P1_12 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P1_12"]); }
                if (ds.Tables[0].Rows[0]["P2"] != DBNull.Value && ds.Tables[0].Rows[0]["P2"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P2 = Convert.ToString(ds.Tables[0].Rows[0]["P2"]); }
                if (ds.Tables[0].Rows[0]["P3"] != DBNull.Value && ds.Tables[0].Rows[0]["P3"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P3 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P3"]); }
                if (ds.Tables[0].Rows[0]["P3_1"] != DBNull.Value && ds.Tables[0].Rows[0]["P3_1"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P3_1 = Convert.ToString(ds.Tables[0].Rows[0]["P3_1"]); }
                if (ds.Tables[0].Rows[0]["P3_2"] != DBNull.Value && ds.Tables[0].Rows[0]["P3_2"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P3_2 = Convert.ToInt32(ds.Tables[0].Rows[0]["P3_2"]); }
                if (ds.Tables[0].Rows[0]["P4"] != DBNull.Value && ds.Tables[0].Rows[0]["P4"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P4 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P4"]); }
                if (ds.Tables[0].Rows[0]["P4_1"] != DBNull.Value && ds.Tables[0].Rows[0]["P4_1"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P4_1 = Convert.ToString(ds.Tables[0].Rows[0]["P4_1"]); }
                if (ds.Tables[0].Rows[0]["P4_2"] != DBNull.Value && ds.Tables[0].Rows[0]["P4_2"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P4_2 = Convert.ToInt32(ds.Tables[0].Rows[0]["P4_2"]); }
                if (ds.Tables[0].Rows[0]["P5"] != DBNull.Value && ds.Tables[0].Rows[0]["P5"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P5 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P5"]); }
                if (ds.Tables[0].Rows[0]["P5_1"] != DBNull.Value && ds.Tables[0].Rows[0]["P5_1"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P5_1 = Convert.ToString(ds.Tables[0].Rows[0]["P5_1"]); }
                if (ds.Tables[0].Rows[0]["P6_1_Cual_Idioma"] != DBNull.Value && ds.Tables[0].Rows[0]["P6_1_Cual_Idioma"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P6_1_Cual_Idioma = Convert.ToString(ds.Tables[0].Rows[0]["P6_1_Cual_Idioma"]); }
                if (ds.Tables[0].Rows[0]["P6_1_Donde"] != DBNull.Value && ds.Tables[0].Rows[0]["P6_1_Donde"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P6_1_Donde = Convert.ToString(ds.Tables[0].Rows[0]["P6_1_Donde"]); }
                if (ds.Tables[0].Rows[0]["P6_2"] != DBNull.Value && ds.Tables[0].Rows[0]["P6_2"].ToString().Trim() != "") { SI_UDEP_IdiomaOrig.P6_2 = Convert.ToBoolean(ds.Tables[0].Rows[0]["P6_2"]); }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaGrilla_SI_UDEP_IdiomaOrig(string id,
                        string Cod_fun,
                        string P1_1,
                        string P1_2,
                        string P1_3,
                        string P1_4,
                        string P1_5,
                        string P1_6,
                        string P1_7,
                        string P1_8,
                        string P1_9,
                        string P1_10,
                        string P1_11,
                        string P1_12,
                        string P2,
                        string P3,
                        string P3_1,
                        string P3_2,
                        string P4,
                        string P4_1,
                        string P4_2,
                        string P5,
                        string P5_1,
                        string P6_1_Cual_Idioma,
                        string P6_1_Donde,
                        string P6_2)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP_SI_UDEP_IDIOMAORIG);

                if (id.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_id", DbType.Int32, Convert.ToInt32(id)); }
                if (Cod_fun.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_Cod_fun", DbType.Int32, Convert.ToInt32(Cod_fun)); }
                if (P1_1.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P1_1", DbType.Boolean, Convert.ToBoolean(P1_1)); }
                if (P1_2.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P1_2", DbType.Boolean, Convert.ToBoolean(P1_2)); }
                if (P1_3.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P1_3", DbType.Boolean, Convert.ToBoolean(P1_3)); }
                if (P1_4.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P1_4", DbType.Boolean, Convert.ToBoolean(P1_4)); }
                if (P1_5.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P1_5", DbType.Boolean, Convert.ToBoolean(P1_5)); }
                if (P1_6.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P1_6", DbType.Boolean, Convert.ToBoolean(P1_6)); }
                if (P1_7.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P1_7", DbType.Boolean, Convert.ToBoolean(P1_7)); }
                if (P1_8.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P1_8", DbType.Boolean, Convert.ToBoolean(P1_8)); }
                if (P1_9.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P1_9", DbType.Boolean, Convert.ToBoolean(P1_9)); }
                if (P1_10.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P1_10", DbType.Boolean, Convert.ToBoolean(P1_10)); }
                if (P1_11.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P1_11", DbType.Boolean, Convert.ToBoolean(P1_11)); }
                if (P1_12.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P1_12", DbType.Boolean, Convert.ToBoolean(P1_12)); }
                if (P2.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P2", DbType.String, Convert.ToString(P2)); }
                if (P3.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P3", DbType.Boolean, Convert.ToBoolean(P3)); }
                if (P3_1.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P3_1", DbType.String, Convert.ToString(P3_1)); }
                if (P3_2.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P3_2", DbType.Int32, Convert.ToInt32(P3_2)); }
                if (P4.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P4", DbType.Boolean, Convert.ToBoolean(P4)); }
                if (P4_1.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P4_1", DbType.String, Convert.ToString(P4_1)); }
                if (P4_2.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P4_2", DbType.Int32, Convert.ToInt32(P4_2)); }
                if (P5.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P5", DbType.Boolean, Convert.ToBoolean(P5)); }
                if (P5_1.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P5_1", DbType.String, Convert.ToString(P5_1)); }
                if (P6_1_Cual_Idioma.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P6_1_Cual_Idioma", DbType.String, Convert.ToString(P6_1_Cual_Idioma)); }
                if (P6_1_Donde.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P6_1_Donde", DbType.String, Convert.ToString(P6_1_Donde)); }
                if (P6_2.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_P6_2", DbType.Boolean, Convert.ToBoolean(P6_2)); }

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo_SI_UDEP_IdiomaOrig()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP_SI_UDEP_IDIOMAORIG);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _MDP_FORMACION
        public override bool Adicionar__mdp_formacion(cls_mdp_formacion _mdp_formacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_FORMACION);

                CnxSigrh3.AddInParameter(icom, "p_fo_id", DbType.Int32, _mdp_formacion.fo_id);
                CnxSigrh3.AddInParameter(icom, "p_fo_tipo", DbType.String, _mdp_formacion.fo_tipo);
                CnxSigrh3.AddInParameter(icom, "p_fo_descripcion", DbType.String, _mdp_formacion.fo_descripcion);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar__mdp_formacion(cls_mdp_formacion _mdp_formacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_FORMACION);

                CnxSigrh3.AddInParameter(icom, "p_fo_id", DbType.Int32, _mdp_formacion.fo_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Actualizar__mdp_formacion(cls_mdp_formacion _mdp_formacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_FORMACION);

                CnxSigrh3.AddInParameter(icom, "p_fo_id", DbType.Int32, _mdp_formacion.fo_id);
                CnxSigrh3.AddInParameter(icom, "p_fo_tipo", DbType.String, _mdp_formacion.fo_tipo);
                CnxSigrh3.AddInParameter(icom, "p_fo_descripcion", DbType.String, _mdp_formacion.fo_descripcion);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId__mdp_formacion(cls_mdp_formacion _mdp_formacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_FORMACION);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                _mdp_formacion.fo_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fo_id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerRegistro__mdp_formacion(cls_mdp_formacion _mdp_formacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_FORMACION);

                CnxSigrh3.AddInParameter(icom, "p_fo_id", DbType.Int32, _mdp_formacion.fo_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["fo_id"] != DBNull.Value && ds.Tables[0].Rows[0]["fo_id"].ToString().Trim() != "") { _mdp_formacion.fo_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fo_id"]); }
                if (ds.Tables[0].Rows[0]["fo_tipo"] != DBNull.Value && ds.Tables[0].Rows[0]["fo_tipo"].ToString().Trim() != "") { _mdp_formacion.fo_tipo = Convert.ToString(ds.Tables[0].Rows[0]["fo_tipo"]); }
                if (ds.Tables[0].Rows[0]["fo_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["fo_descripcion"].ToString().Trim() != "") { _mdp_formacion.fo_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["fo_descripcion"]); }
                if (ds.Tables[0].Rows[0]["fo_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["fo_estado"].ToString().Trim() != "") { _mdp_formacion.fo_estado = Convert.ToString(ds.Tables[0].Rows[0]["fo_estado"]); }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaGrilla__mdp_formacion(string fo_id,
                        string fo_tipo,
                        string fo_descripcion,
                        string fo_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_FORMACION);

                if (fo_id.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_fo_id", DbType.Int32, Convert.ToInt32(fo_id)); }
                if (fo_tipo.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_fo_tipo", DbType.String, Convert.ToString(fo_tipo)); }
                if (fo_descripcion.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_fo_descripcion", DbType.String, Convert.ToString(fo_descripcion)); }
                if (fo_estado.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_fo_estado", DbType.String, Convert.ToString(fo_estado)); }

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo__mdp_formacion()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_FORMACION);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaFormacion()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_FORMACION);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarFormacion(cls_mdp_formacion _mdp_formacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_FORMACION);

                CnxSigrh3.AddInParameter(icom, "p_fo_id", DbType.Int32, _mdp_formacion.fo_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerFormacionP(cls_mdp_formacion _mdp_formacion)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_FORMACION);

                CnxSigrh3.AddInParameter(icom, "p_fo_id", DbType.Int32, Convert.ToInt32(_mdp_formacion.fo_id));

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["fo_id"] != DBNull.Value && ds.Tables[0].Rows[0]["fo_id"].ToString().Trim() != "") { _mdp_formacion.fo_id = Convert.ToInt32(ds.Tables[0].Rows[0]["fo_id"]); }
                if (ds.Tables[0].Rows[0]["fo_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["fo_descripcion"].ToString().Trim() != "") { _mdp_formacion.fo_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["fo_descripcion"]); }
                if (ds.Tables[0].Rows[0]["fo_tipo"] != DBNull.Value && ds.Tables[0].Rows[0]["fo_tipo"].ToString().Trim() != "") { _mdp_formacion.fo_tipo = Convert.ToString(ds.Tables[0].Rows[0]["fo_tipo"]); }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _MDP_CARACTER_INDIVIDUAL
        public override bool Adicionar__mdp_caracter_individual(cls_mdp_caracter_individual _mdp_caracter_individual)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CARACTER_INDIVIDUAL);

                CnxSigrh3.AddInParameter(icom, "p_ci_id", DbType.Int32, _mdp_caracter_individual.ci_id);
                CnxSigrh3.AddInParameter(icom, "p_ci_orden", DbType.Int32, _mdp_caracter_individual.ci_orden);
                CnxSigrh3.AddInParameter(icom, "p_ci_factor", DbType.String, _mdp_caracter_individual.ci_factor);
                CnxSigrh3.AddInParameter(icom, "p_ci_descripcion", DbType.String, _mdp_caracter_individual.ci_descripcion);
                CnxSigrh3.AddInParameter(icom, "p_ci_puntaje", DbType.Int32, _mdp_caracter_individual.ci_puntaje);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar__mdp_caracter_individual(cls_mdp_caracter_individual _mdp_caracter_individual)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CARACTER_INDIVIDUAL);

                CnxSigrh3.AddInParameter(icom, "p_ci_id", DbType.Int32, _mdp_caracter_individual.ci_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Actualizar__mdp_caracter_individual(cls_mdp_caracter_individual _mdp_caracter_individual)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CARACTER_INDIVIDUAL);

                CnxSigrh3.AddInParameter(icom, "p_ci_id", DbType.Int32, _mdp_caracter_individual.ci_id);
                CnxSigrh3.AddInParameter(icom, "p_ci_orden", DbType.Int32, _mdp_caracter_individual.ci_orden);
                CnxSigrh3.AddInParameter(icom, "p_ci_factor", DbType.String, _mdp_caracter_individual.ci_factor);
                CnxSigrh3.AddInParameter(icom, "p_ci_descripcion", DbType.String, _mdp_caracter_individual.ci_descripcion);
                CnxSigrh3.AddInParameter(icom, "p_ci_puntaje", DbType.Int32, _mdp_caracter_individual.ci_puntaje);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId__mdp_caracter_individual(cls_mdp_caracter_individual _mdp_caracter_individual)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CARACTER_INDIVIDUAL);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                _mdp_caracter_individual.ci_id = Convert.ToInt32(ds.Tables[0].Rows[0]["ci_id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerRegistro__mdp_caracter_individual(cls_mdp_caracter_individual _mdp_caracter_individual)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CARACTER_INDIVIDUAL);

                CnxSigrh3.AddInParameter(icom, "p_ci_id", DbType.Int32, _mdp_caracter_individual.ci_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["ci_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ci_id"].ToString().Trim() != "") { _mdp_caracter_individual.ci_id = Convert.ToInt32(ds.Tables[0].Rows[0]["ci_id"]); }
                if (ds.Tables[0].Rows[0]["ci_orden"] != DBNull.Value && ds.Tables[0].Rows[0]["ci_orden"].ToString().Trim() != "") { _mdp_caracter_individual.ci_orden = Convert.ToInt32(ds.Tables[0].Rows[0]["ci_orden"]); }
                if (ds.Tables[0].Rows[0]["ci_factor"] != DBNull.Value && ds.Tables[0].Rows[0]["ci_factor"].ToString().Trim() != "") { _mdp_caracter_individual.ci_factor = Convert.ToString(ds.Tables[0].Rows[0]["ci_factor"]); }
                if (ds.Tables[0].Rows[0]["ci_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["ci_descripcion"].ToString().Trim() != "") { _mdp_caracter_individual.ci_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["ci_descripcion"]); }
                if (ds.Tables[0].Rows[0]["ci_puntaje"] != DBNull.Value && ds.Tables[0].Rows[0]["ci_puntaje"].ToString().Trim() != "") { _mdp_caracter_individual.ci_puntaje = Convert.ToInt32(ds.Tables[0].Rows[0]["ci_puntaje"]); }
                if (ds.Tables[0].Rows[0]["ci_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["ci_estado"].ToString().Trim() != "") { _mdp_caracter_individual.ci_estado = Convert.ToString(ds.Tables[0].Rows[0]["ci_estado"]); }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaGrilla__mdp_caracter_individual(string ci_id,
                        string ci_orden,
                        string ci_factor,
                        string ci_descripcion,
                        string ci_puntaje,
                        string ci_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CARACTER_INDIVIDUAL);

                if (ci_id.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_ci_id", DbType.Int32, Convert.ToInt32(ci_id)); }
                if (ci_orden.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_ci_orden", DbType.Int32, Convert.ToInt32(ci_orden)); }
                if (ci_factor.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_ci_factor", DbType.String, Convert.ToString(ci_factor)); }
                if (ci_descripcion.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_ci_descripcion", DbType.String, Convert.ToString(ci_descripcion)); }
                if (ci_puntaje.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_ci_puntaje", DbType.Int32, Convert.ToInt32(ci_puntaje)); }
                if (ci_estado.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_ci_estado", DbType.String, Convert.ToString(ci_estado)); }

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo__mdp_caracter_individual()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CARACTER_INDIVIDUAL);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaCaracterIndividual()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CARACTER_INDIVIDUAL);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarCaracterInd(cls_mdp_caracter_individual _mdp_caracter_individual)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CARACTER_INDIVIDUAL);

                CnxSigrh3.AddInParameter(icom, "p_ci_id", DbType.Int32, _mdp_caracter_individual.ci_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerCaracterIndividualP(cls_mdp_caracter_individual _mdp_caracter_individual)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CARACTER_INDIVIDUAL);

                CnxSigrh3.AddInParameter(icom, "p_ci_id", DbType.Int32, Convert.ToInt32(_mdp_caracter_individual.ci_id));

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["ci_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ci_id"].ToString().Trim() != "") { _mdp_caracter_individual.ci_id = Convert.ToInt32(ds.Tables[0].Rows[0]["ci_id"]); }
                if (ds.Tables[0].Rows[0]["ci_orden"] != DBNull.Value && ds.Tables[0].Rows[0]["ci_orden"].ToString().Trim() != "") { _mdp_caracter_individual.ci_orden = Convert.ToInt32(ds.Tables[0].Rows[0]["ci_orden"]); }
                if (ds.Tables[0].Rows[0]["ci_factor"] != DBNull.Value && ds.Tables[0].Rows[0]["ci_factor"].ToString().Trim() != "") { _mdp_caracter_individual.ci_factor = Convert.ToString(ds.Tables[0].Rows[0]["ci_factor"]); }
                if (ds.Tables[0].Rows[0]["ci_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["ci_descripcion"].ToString().Trim() != "") { _mdp_caracter_individual.ci_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["ci_descripcion"]); }
                if (ds.Tables[0].Rows[0]["ci_puntaje"] != DBNull.Value && ds.Tables[0].Rows[0]["ci_puntaje"].ToString().Trim() != "") { _mdp_caracter_individual.ci_puntaje = Convert.ToInt32(ds.Tables[0].Rows[0]["ci_puntaje"]); }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _MDP_CONOCIMIENTO
        public override bool Adicionar__mdp_conocimiento(cls_mdp_conocimiento _mdp_conocimiento)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CONOCIMIENTO);

                CnxSigrh3.AddInParameter(icom, "p_co_id", DbType.Int32, _mdp_conocimiento.co_id);
                CnxSigrh3.AddInParameter(icom, "p_co_descripcion", DbType.String, _mdp_conocimiento.co_descripcion);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar__mdp_conocimiento(cls_mdp_conocimiento _mdp_conocimiento)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CONOCIMIENTO);

                CnxSigrh3.AddInParameter(icom, "p_co_id", DbType.Int32, _mdp_conocimiento.co_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Actualizar__mdp_conocimiento(cls_mdp_conocimiento _mdp_conocimiento)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CONOCIMIENTO);

                CnxSigrh3.AddInParameter(icom, "p_co_id", DbType.Int32, _mdp_conocimiento.co_id);
                CnxSigrh3.AddInParameter(icom, "p_co_descripcion", DbType.String, _mdp_conocimiento.co_descripcion);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId__mdp_conocimiento(cls_mdp_conocimiento _mdp_conocimiento)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CONOCIMIENTO);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                _mdp_conocimiento.co_id = Convert.ToInt32(ds.Tables[0].Rows[0]["co_id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerRegistro__mdp_conocimiento(cls_mdp_conocimiento _mdp_conocimiento)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CONOCIMIENTO);

                CnxSigrh3.AddInParameter(icom, "p_co_id", DbType.Int32, _mdp_conocimiento.co_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["co_id"] != DBNull.Value && ds.Tables[0].Rows[0]["co_id"].ToString().Trim() != "") { _mdp_conocimiento.co_id = Convert.ToInt32(ds.Tables[0].Rows[0]["co_id"]); }
                if (ds.Tables[0].Rows[0]["co_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["co_descripcion"].ToString().Trim() != "") { _mdp_conocimiento.co_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["co_descripcion"]); }
                if (ds.Tables[0].Rows[0]["co_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["co_estado"].ToString().Trim() != "") { _mdp_conocimiento.co_estado = Convert.ToString(ds.Tables[0].Rows[0]["co_estado"]); }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaGrilla__mdp_conocimiento(string co_id,
                        string co_descripcion,
                        string co_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CONOCIMIENTO);

                if (co_id.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_co_id", DbType.Int32, Convert.ToInt32(co_id)); }
                if (co_descripcion.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_co_descripcion", DbType.String, Convert.ToString(co_descripcion)); }
                if (co_estado.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_co_estado", DbType.String, Convert.ToString(co_estado)); }

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo__mdp_conocimiento()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CONOCIMIENTO);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaConocimiento()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CONOCIMIENTO);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarConocimiento(cls_mdp_conocimiento _mdp_conocimiento)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CONOCIMIENTO);

                CnxSigrh3.AddInParameter(icom, "p_co_id", DbType.Int32, _mdp_conocimiento.co_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerConocimientoP(cls_mdp_conocimiento _mdp_conocimiento)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_CONOCIMIENTO);

                CnxSigrh3.AddInParameter(icom, "p_co_id", DbType.Int32, Convert.ToInt32(_mdp_conocimiento.co_id));

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["co_id"] != DBNull.Value && ds.Tables[0].Rows[0]["co_id"].ToString().Trim() != "") { _mdp_conocimiento.co_id = Convert.ToInt32(ds.Tables[0].Rows[0]["co_id"]); }
                if (ds.Tables[0].Rows[0]["co_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["co_descripcion"].ToString().Trim() != "") { _mdp_conocimiento.co_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["co_descripcion"]); }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _MDP_DISPOSICION_JURIDICA
        public override bool Adicionar__mdp_disposicion_juridica(cls_mdp_disposicion_juridica _mdp_disposicion_juridica)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_DISPOSICION_JURIDICA);

                CnxSigrh3.AddInParameter(icom, "p_dj_id", DbType.Int32, _mdp_disposicion_juridica.dj_id);
                CnxSigrh3.AddInParameter(icom, "p_dj_descripcion", DbType.String, _mdp_disposicion_juridica.dj_descripcion);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar__mdp_disposicion_juridica(cls_mdp_disposicion_juridica _mdp_disposicion_juridica)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_DISPOSICION_JURIDICA);

                CnxSigrh3.AddInParameter(icom, "p_dj_id", DbType.Int32, _mdp_disposicion_juridica.dj_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Actualizar__mdp_disposicion_juridica(cls_mdp_disposicion_juridica _mdp_disposicion_juridica)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_DISPOSICION_JURIDICA);
                CnxSigrh3.AddInParameter(icom, "p_dj_descripcion", DbType.String, _mdp_disposicion_juridica.dj_descripcion);
                CnxSigrh3.AddInParameter(icom, "p_dj_id", DbType.Int32, _mdp_disposicion_juridica.dj_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId__mdp_disposicion_juridica(cls_mdp_disposicion_juridica _mdp_disposicion_juridica)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_DISPOSICION_JURIDICA);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                _mdp_disposicion_juridica.dj_id = Convert.ToInt32(ds.Tables[0].Rows[0]["dj_id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerRegistro__mdp_disposicion_juridica(cls_mdp_disposicion_juridica _mdp_disposicion_juridica)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_DISPOSICION_JURIDICA);

                CnxSigrh3.AddInParameter(icom, "p_dj_id", DbType.Int32, _mdp_disposicion_juridica.dj_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["dj_id"] != DBNull.Value && ds.Tables[0].Rows[0]["dj_id"].ToString().Trim() != "") { _mdp_disposicion_juridica.dj_id = Convert.ToInt32(ds.Tables[0].Rows[0]["dj_id"]); }
                if (ds.Tables[0].Rows[0]["dj_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["dj_descripcion"].ToString().Trim() != "") { _mdp_disposicion_juridica.dj_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["dj_descripcion"]); }
                if (ds.Tables[0].Rows[0]["dj_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["dj_estado"].ToString().Trim() != "") { _mdp_disposicion_juridica.dj_estado = Convert.ToString(ds.Tables[0].Rows[0]["dj_estado"]); }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaGrilla__mdp_disposicion_juridica(string dj_id,
                        string dj_descripcion,
                        string dj_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_DISPOSICION_JURIDICA);

                if (dj_id.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_dj_id", DbType.Int32, Convert.ToInt32(dj_id)); }
                if (dj_descripcion.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_dj_descripcion", DbType.String, Convert.ToString(dj_descripcion)); }
                if (dj_estado.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_dj_estado", DbType.String, Convert.ToString(dj_estado)); }

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo__mdp_disposicion_juridica()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_DISPOSICION_JURIDICA);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaDisposicion()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_DISPOSICION_JURIDICA);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarDisposicion(cls_mdp_disposicion_juridica _mdp_disposicion_juridica)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_DISPOSICION_JURIDICA);

                CnxSigrh3.AddInParameter(icom, "p_dj_id", DbType.Int32, _mdp_disposicion_juridica.dj_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerDisposicionP(cls_mdp_disposicion_juridica _mdp_disposicion_juridica)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_DISPOSICION_JURIDICA);

                CnxSigrh3.AddInParameter(icom, "p_dj_id", DbType.Int32, Convert.ToInt32(_mdp_disposicion_juridica.dj_id));

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["dj_id"] != DBNull.Value && ds.Tables[0].Rows[0]["dj_id"].ToString().Trim() != "") { _mdp_disposicion_juridica.dj_id = Convert.ToInt32(ds.Tables[0].Rows[0]["dj_id"]); }
                if (ds.Tables[0].Rows[0]["dj_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["dj_descripcion"].ToString().Trim() != "") { _mdp_disposicion_juridica.dj_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["dj_descripcion"]); }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region _MDP_RESULTADOS_ESPECIFICOS
        public override bool Adicionar__mdp_resultados_especificos(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                //CnxSigrh3.AddInParameter(icom, "p_res_id", DbType.Int32, _mdp_resultados_especificos.res_id);
                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_res_descripcion", DbType.String, _mdp_resultados_especificos.res_descripcion);
                CnxSigrh3.AddInParameter(icom, "p_res_indicador", DbType.String, _mdp_resultados_especificos.res_indicador);
                CnxSigrh3.AddInParameter(icom, "p_res_puntaje", DbType.Int32, _mdp_resultados_especificos.res_puntaje);
                //CnxSigrh3.AddInParameter(icom, "p_res_estado", DbType.String, _mdp_resultados_especificos.res_estado);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarConocimiento(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_ico_co_id", DbType.Int32, _mdp_resultados_especificos.ico_co_id);
                CnxSigrh3.AddInParameter(icom, "p_ico_poai_id", DbType.String, _mdp_resultados_especificos.ico_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A5");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarDisposicion(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_idj_dj_id", DbType.Int32, _mdp_resultados_especificos.idj_dj_id);
                CnxSigrh3.AddInParameter(icom, "p_idj_poai_id", DbType.String, _mdp_resultados_especificos.idj_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A6");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarCaracterIndividual(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_ici_ci_id", DbType.Int32, _mdp_resultados_especificos.ici_ci_id);
                CnxSigrh3.AddInParameter(icom, "p_ici_poai_id", DbType.String, _mdp_resultados_especificos.ici_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_ici_cat_abreviacion", DbType.String, _mdp_resultados_especificos.ici_cat_abreviacion);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A7");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarTarea(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.tar_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_tar_descripcion", DbType.String, _mdp_resultados_especificos.tar_descripcion);


                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A1");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarItem(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.pu_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_pu_nro_puesto", DbType.String, _mdp_resultados_especificos.pu_nro_puesto);
                CnxSigrh3.AddInParameter(icom, "p_pu_nombre_puesto", DbType.String, _mdp_resultados_especificos.puesto);
                CnxSigrh3.AddInParameter(icom, "p_pu_pref_puesto", DbType.String, _mdp_resultados_especificos.pu_pref_puesto);
                CnxSigrh3.AddInParameter(icom, "p_pu_objetivo", DbType.String, _mdp_resultados_especificos.objetivo);
                CnxSigrh3.AddInParameter(icom, "p_pu_id_puesto_anterior", DbType.String, _mdp_resultados_especificos.pu_id_puesto_anterior);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A4");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarFormacionO(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.ifo_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_ifo_fo_id", DbType.String, _mdp_resultados_especificos.ifo_fo_id);


                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A2");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarFormacionC(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.ifo_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_ifo_fo_id", DbType.String, _mdp_resultados_especificos.ifo_fo_comp_id);


                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A2");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarResponsabilidad(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.irespons_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_irespons_cat_id", DbType.String, _mdp_resultados_especificos.irespons_cat_id);


                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A3");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar__mdp_resultados_especificos(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_id", DbType.Int32, _mdp_resultados_especificos.res_id);
                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.res_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Actualizar__mdp_resultados_especificos(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_id", DbType.Int32, _mdp_resultados_especificos.res_id);
                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.res_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ActualizarTarea(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_tar_id", DbType.Int32, _mdp_resultados_especificos.tar_id);
                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.tar_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "U");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ActualizarItem(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_pu_id", DbType.Int32, _mdp_resultados_especificos.pu_id);
                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.pu_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "U3");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ActualizarFormacionO(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_ifo_fo_id", DbType.Int32, _mdp_resultados_especificos.ifo_fo_id_before);
                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.ifo_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "U1");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ActualizarFormacionC(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_ifo_fo_id", DbType.Int32, _mdp_resultados_especificos.ifo_fo_comp_id_before);
                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.ifo_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "U1");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ActualizarResponsabilidad(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.irespons_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "U2");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override bool ObtenerId__mdp_resultados_especificos(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                _mdp_resultados_especificos.res_id = Convert.ToInt32(ds.Tables[0].Rows[0]["res_id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerRegistro__mdp_resultados_especificos(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_id", DbType.Int32, _mdp_resultados_especificos.res_id);
                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.res_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["res_id"] != DBNull.Value && ds.Tables[0].Rows[0]["res_id"].ToString().Trim() != "") { _mdp_resultados_especificos.res_id = Convert.ToInt32(ds.Tables[0].Rows[0]["res_id"]); }
                if (ds.Tables[0].Rows[0]["res_poai_id"] != DBNull.Value && ds.Tables[0].Rows[0]["res_poai_id"].ToString().Trim() != "") { _mdp_resultados_especificos.res_poai_id = Convert.ToInt32(ds.Tables[0].Rows[0]["res_poai_id"]); }
                if (ds.Tables[0].Rows[0]["res_descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["res_descripcion"].ToString().Trim() != "") { _mdp_resultados_especificos.res_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["res_descripcion"]); }
                if (ds.Tables[0].Rows[0]["res_indicador"] != DBNull.Value && ds.Tables[0].Rows[0]["res_indicador"].ToString().Trim() != "") { _mdp_resultados_especificos.res_indicador = Convert.ToString(ds.Tables[0].Rows[0]["res_indicador"]); }
                if (ds.Tables[0].Rows[0]["res_puntaje"] != DBNull.Value && ds.Tables[0].Rows[0]["res_puntaje"].ToString().Trim() != "") { _mdp_resultados_especificos.res_puntaje = Convert.ToInt32(ds.Tables[0].Rows[0]["res_puntaje"]); }
                if (ds.Tables[0].Rows[0]["res_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["res_estado"].ToString().Trim() != "") { _mdp_resultados_especificos.res_estado = Convert.ToString(ds.Tables[0].Rows[0]["res_estado"]); }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaGrilla__mdp_resultados_especificos(string res_id,
                        string res_poai_id,
                        string res_descripcion,
                        string res_indicador,
                        string res_puntaje,
                        string res_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                if (res_id.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_res_id", DbType.Int32, Convert.ToInt32(res_id)); }
                if (res_poai_id.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, Convert.ToInt32(res_poai_id)); }
                if (res_descripcion.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_res_descripcion", DbType.String, Convert.ToString(res_descripcion)); }
                if (res_indicador.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_res_indicador", DbType.String, Convert.ToString(res_indicador)); }
                if (res_puntaje.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_res_puntaje", DbType.Int32, Convert.ToInt32(res_puntaje)); }
                if (res_estado.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_res_estado", DbType.String, Convert.ToString(res_estado)); }

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo__mdp_resultados_especificos()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool ObtenerFicha(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, Convert.ToInt32(_mdp_resultados_especificos.res_poai_id));


                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["poai_id"] != DBNull.Value && ds.Tables[0].Rows[0]["poai_id"].ToString().Trim() != "") { _mdp_resultados_especificos.res_poai_id = Convert.ToInt32(ds.Tables[0].Rows[0]["poai_id"]); }
                if (ds.Tables[0].Rows[0]["prefijo"] != DBNull.Value && ds.Tables[0].Rows[0]["prefijo"].ToString().Trim() != "") { _mdp_resultados_especificos.prefijo = Convert.ToString(ds.Tables[0].Rows[0]["prefijo"]); }
                if (ds.Tables[0].Rows[0]["item"] != DBNull.Value && ds.Tables[0].Rows[0]["item"].ToString().Trim() != "") { _mdp_resultados_especificos.item = Convert.ToString(ds.Tables[0].Rows[0]["item"]); }
                if (ds.Tables[0].Rows[0]["item_anterior"] != DBNull.Value && ds.Tables[0].Rows[0]["item_anterior"].ToString().Trim() != "") { _mdp_resultados_especificos.item_anterior = Convert.ToString(ds.Tables[0].Rows[0]["item_anterior"]); }
                if (ds.Tables[0].Rows[0]["puesto"] != DBNull.Value && ds.Tables[0].Rows[0]["puesto"].ToString().Trim() != "") { _mdp_resultados_especificos.puesto = Convert.ToString(ds.Tables[0].Rows[0]["puesto"]); }
                if (ds.Tables[0].Rows[0]["cargo"] != DBNull.Value && ds.Tables[0].Rows[0]["cargo"].ToString().Trim() != "") { _mdp_resultados_especificos.cargo = Convert.ToString(ds.Tables[0].Rows[0]["cargo"]); }
                if (ds.Tables[0].Rows[0]["est_org"] != DBNull.Value && ds.Tables[0].Rows[0]["est_org"].ToString().Trim() != "") { _mdp_resultados_especificos.est_org = Convert.ToString(ds.Tables[0].Rows[0]["est_org"]); }
                if (ds.Tables[0].Rows[0]["objetivo"] != DBNull.Value && ds.Tables[0].Rows[0]["objetivo"].ToString().Trim() != "") { _mdp_resultados_especificos.objetivo = Convert.ToString(ds.Tables[0].Rows[0]["objetivo"]); }

                if (ds.Tables[0].Rows[0]["pu_nro_puesto"] != DBNull.Value && ds.Tables[0].Rows[0]["pu_nro_puesto"].ToString().Trim() != "") { _mdp_resultados_especificos.pu_nro_puesto = Convert.ToInt32(ds.Tables[0].Rows[0]["pu_nro_puesto"]); }
                if (ds.Tables[0].Rows[0]["pu_pref_puesto"] != DBNull.Value && ds.Tables[0].Rows[0]["pu_pref_puesto"].ToString().Trim() != "") { _mdp_resultados_especificos.pu_pref_puesto = Convert.ToString(ds.Tables[0].Rows[0]["pu_pref_puesto"]); }
                if (ds.Tables[0].Rows[0]["pu_id_puesto_anterior"] != DBNull.Value && ds.Tables[0].Rows[0]["pu_id_puesto_anterior"].ToString().Trim() != "") { _mdp_resultados_especificos.pu_id_puesto_anterior = Convert.ToInt32(ds.Tables[0].Rows[0]["pu_id_puesto_anterior"]); }
                if (ds.Tables[0].Rows[0]["pu_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pu_id"].ToString().Trim() != "") { _mdp_resultados_especificos.pu_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pu_id"]); }

                if (ds.Tables[0].Rows[0]["ne_categoria"] != DBNull.Value && ds.Tables[0].Rows[0]["ne_categoria"].ToString().Trim() != "") { _mdp_resultados_especificos.ne_categoria = Convert.ToString(ds.Tables[0].Rows[0]["ne_categoria"]); }
                if (ds.Tables[0].Rows[0]["ne_nivel_interno"] != DBNull.Value && ds.Tables[0].Rows[0]["ne_nivel_interno"].ToString().Trim() != "") { _mdp_resultados_especificos.ne_nivel_interno = Convert.ToInt32(ds.Tables[0].Rows[0]["ne_nivel_interno"]); }
                if (ds.Tables[0].Rows[0]["pr_gestion"] != DBNull.Value && ds.Tables[0].Rows[0]["pr_gestion"].ToString().Trim() != "") { _mdp_resultados_especificos.gestion = Convert.ToString(ds.Tables[0].Rows[0]["pr_gestion"]); }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaSupervision(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C23");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaResultados(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaTareas(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaConocimiento(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaDisposicion(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerListaRespons()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerResponsItem(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerListaFiltradoFormO()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFormOItem(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C12");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerListaFiltradoFormC()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerListaFiltradoFormRequerida()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C25");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerListaFiltradoAreaFormacion()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C26");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFormRequeridaItem(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C24");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override DataSet ObtenerFiltradoConcocimiento(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.ico_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C18");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoDisposicion(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.idj_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C19");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoCaracterIndividual(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.ici_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C20");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFormCItem(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C13");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaCaracterI(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, _mdp_resultados_especificos.p_Accion);
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerSumaPuntaje(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C21");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerSumaPuntajeEditar(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_id", DbType.String, _mdp_resultados_especificos.res_id);
                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C22");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerTiempoExperiencia(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, Convert.ToInt32(_mdp_resultados_especificos.res_poai_id));
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, _mdp_resultados_especificos.p_Accion);
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["poai_id"] != DBNull.Value && ds.Tables[0].Rows[0]["poai_id"].ToString().Trim() != "") { _mdp_resultados_especificos.res_poai_id = Convert.ToInt32(ds.Tables[0].Rows[0]["poai_id"]); }
                if (ds.Tables[0].Rows[0]["expGeneral"] != DBNull.Value && ds.Tables[0].Rows[0]["expGeneral"].ToString().Trim() != "") { _mdp_resultados_especificos.exp_general = Convert.ToString(ds.Tables[0].Rows[0]["expGeneral"]); }
                if (ds.Tables[0].Rows[0]["expEspecifica"] != DBNull.Value && ds.Tables[0].Rows[0]["expEspecifica"].ToString().Trim() != "") { _mdp_resultados_especificos.exp_especifica = Convert.ToString(ds.Tables[0].Rows[0]["expEspecifica"]); }
                if (ds.Tables[0].Rows[0]["expGralMun"] != DBNull.Value && ds.Tables[0].Rows[0]["expGralMun"].ToString().Trim() != "") { _mdp_resultados_especificos.exp_general_mun = Convert.ToString(ds.Tables[0].Rows[0]["expGralMun"]); }
                if (ds.Tables[0].Rows[0]["expEspMun"] != DBNull.Value && ds.Tables[0].Rows[0]["expEspMun"].ToString().Trim() != "") { _mdp_resultados_especificos.exp_especifica_mun = Convert.ToString(ds.Tables[0].Rows[0]["expEspMun"]); }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarResultado(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_id", DbType.Int32, _mdp_resultados_especificos.res_id);
                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.res_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerResultadoP(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, Convert.ToInt32(_mdp_resultados_especificos.res_poai_id));
                CnxSigrh3.AddInParameter(icom, "p_res_id", DbType.Int32, Convert.ToInt32(_mdp_resultados_especificos.res_id));

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C16");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["res_id"] != DBNull.Value && ds.Tables[0].Rows[0]["res_id"].ToString().Trim() != "") { _mdp_resultados_especificos.res_id = Convert.ToInt32(ds.Tables[0].Rows[0]["res_id"]); }
                if (ds.Tables[0].Rows[0]["res_poai_id"] != DBNull.Value && ds.Tables[0].Rows[0]["res_poai_id"].ToString().Trim() != "") { _mdp_resultados_especificos.res_poai_id = Convert.ToInt32(ds.Tables[0].Rows[0]["res_poai_id"]); }
                if (ds.Tables[0].Rows[0]["descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["descripcion"].ToString().Trim() != "") { _mdp_resultados_especificos.res_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["descripcion"]); }
                if (ds.Tables[0].Rows[0]["indicador"] != DBNull.Value && ds.Tables[0].Rows[0]["indicador"].ToString().Trim() != "") { _mdp_resultados_especificos.res_indicador = Convert.ToString(ds.Tables[0].Rows[0]["indicador"]); }
                if (ds.Tables[0].Rows[0]["puntaje"] != DBNull.Value && ds.Tables[0].Rows[0]["puntaje"].ToString().Trim() != "") { _mdp_resultados_especificos.res_puntaje = Convert.ToInt32(ds.Tables[0].Rows[0]["puntaje"]); }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarTarea(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_id", DbType.Int32, _mdp_resultados_especificos.tar_id);
                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.tar_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B1");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarConocimiento(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_ico_co_id", DbType.Int32, _mdp_resultados_especificos.ico_co_id);
                CnxSigrh3.AddInParameter(icom, "p_ico_poai_id", DbType.Int32, _mdp_resultados_especificos.ico_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B2");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarDisposicion(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_idj_dj_id", DbType.Int32, _mdp_resultados_especificos.idj_dj_id);
                CnxSigrh3.AddInParameter(icom, "p_idj_poai_id", DbType.Int32, _mdp_resultados_especificos.idj_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B3");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarCaracterI(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_ici_poai_id", DbType.Int32, _mdp_resultados_especificos.ici_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_ici_ci_id", DbType.Int32, _mdp_resultados_especificos.ici_ci_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B4");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObteneTareaP(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, Convert.ToInt32(_mdp_resultados_especificos.tar_poai_id));
                CnxSigrh3.AddInParameter(icom, "p_tar_id", DbType.Int32, Convert.ToInt32(_mdp_resultados_especificos.tar_id));

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C17");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["tar_id"] != DBNull.Value && ds.Tables[0].Rows[0]["tar_id"].ToString().Trim() != "") { _mdp_resultados_especificos.tar_id = Convert.ToInt32(ds.Tables[0].Rows[0]["tar_id"]); }
                if (ds.Tables[0].Rows[0]["tar_poai_id"] != DBNull.Value && ds.Tables[0].Rows[0]["tar_poai_id"].ToString().Trim() != "") { _mdp_resultados_especificos.tar_poai_id = Convert.ToInt32(ds.Tables[0].Rows[0]["tar_poai_id"]); }
                if (ds.Tables[0].Rows[0]["descripcion"] != DBNull.Value && ds.Tables[0].Rows[0]["descripcion"].ToString().Trim() != "") { _mdp_resultados_especificos.tar_descripcion = Convert.ToString(ds.Tables[0].Rows[0]["descripcion"]); }


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerSiguienteItem(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);


                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, _mdp_resultados_especificos.res_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C29");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerCodigo(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_eo_id", DbType.String, _mdp_resultados_especificos.eo_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C30");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerSumaPuntajeT(string id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                if (id.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, Convert.ToInt32(id)); }
                
                //CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.String, id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C21");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override bool BusquedaPuestoMP(cls_mdp_resultados_especificos _mdp_resultados_especificos)
        {
           
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_RESULTADOS_ESPECIFICOS);

                CnxSigrh3.AddInParameter(icom, "p_pu_id", DbType.Int32, _mdp_resultados_especificos.pu_id);
                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_resultados_especificos.pu_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_pu_nro_puesto", DbType.String, _mdp_resultados_especificos.pu_nro_puesto);
                CnxSigrh3.AddInParameter(icom, "p_pu_nombre_puesto", DbType.String, _mdp_resultados_especificos.puesto);
                CnxSigrh3.AddInParameter(icom, "p_pu_pref_puesto", DbType.String, _mdp_resultados_especificos.pu_pref_puesto);
                CnxSigrh3.AddInParameter(icom, "p_pu_objetivo", DbType.String, _mdp_resultados_especificos.objetivo);
                CnxSigrh3.AddInParameter(icom, "p_pu_id_puesto_anterior", DbType.String, _mdp_resultados_especificos.pu_id_puesto_anterior);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C31");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }





        #endregion

        #region _MDP_PUESTO
        public override bool Adicionar__mdp_puesto(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_pu_poai_id", DbType.Int32, _mdp_puesto.pu_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_pu_nro_puesto", DbType.Int32, _mdp_puesto.pu_nro_puesto);
                CnxSigrh3.AddInParameter(icom, "p_pu_nombre_puesto", DbType.String, _mdp_puesto.pu_nombre_puesto);
                CnxSigrh3.AddInParameter(icom, "p_pu_pref_puesto", DbType.String, _mdp_puesto.pu_pref_puesto);
                CnxSigrh3.AddInParameter(icom, "p_pu_objetivo", DbType.String, _mdp_puesto.pu_objetivo);
                CnxSigrh3.AddInParameter(icom, "p_pu_id_puesto_anterior", DbType.Int32, _mdp_puesto.pu_id_puesto_anterior);
                CnxSigrh3.AddInParameter(icom, "p_pu_estado", DbType.String, _mdp_puesto.pu_estado);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar__mdp_puesto(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_pu_poai_id", DbType.Int32, _mdp_puesto.pu_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "B");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Actualizar__mdp_puesto(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_pu_poai_id", DbType.Int32, _mdp_puesto.pu_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_pu_nro_puesto", DbType.Int32, _mdp_puesto.pu_nro_puesto);
                CnxSigrh3.AddInParameter(icom, "p_pu_nombre_puesto", DbType.String, _mdp_puesto.pu_nombre_puesto);
                CnxSigrh3.AddInParameter(icom, "p_pu_pref_puesto", DbType.String, _mdp_puesto.pu_pref_puesto);
                CnxSigrh3.AddInParameter(icom, "p_pu_objetivo", DbType.String, _mdp_puesto.pu_objetivo);
                CnxSigrh3.AddInParameter(icom, "p_pu_id_puesto_anterior", DbType.Int32, _mdp_puesto.pu_id_puesto_anterior);
                CnxSigrh3.AddInParameter(icom, "p_pu_estado", DbType.String, _mdp_puesto.pu_estado);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerId__mdp_puesto(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "I");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                _mdp_puesto.pu_poai_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pu_poai_id"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerRegistro__mdp_puesto(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_pu_poai_id", DbType.Int32, _mdp_puesto.pu_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["pu_poai_id"] != DBNull.Value && ds.Tables[0].Rows[0]["pu_poai_id"].ToString().Trim() != "") { _mdp_puesto.pu_poai_id = Convert.ToInt32(ds.Tables[0].Rows[0]["pu_poai_id"]); }
                if (ds.Tables[0].Rows[0]["pu_nro_puesto"] != DBNull.Value && ds.Tables[0].Rows[0]["pu_nro_puesto"].ToString().Trim() != "") { _mdp_puesto.pu_nro_puesto = Convert.ToInt32(ds.Tables[0].Rows[0]["pu_nro_puesto"]); }
                if (ds.Tables[0].Rows[0]["pu_nombre_puesto"] != DBNull.Value && ds.Tables[0].Rows[0]["pu_nombre_puesto"].ToString().Trim() != "") { _mdp_puesto.pu_nombre_puesto = Convert.ToString(ds.Tables[0].Rows[0]["pu_nombre_puesto"]); }
                if (ds.Tables[0].Rows[0]["pu_pref_puesto"] != DBNull.Value && ds.Tables[0].Rows[0]["pu_pref_puesto"].ToString().Trim() != "") { _mdp_puesto.pu_pref_puesto = Convert.ToString(ds.Tables[0].Rows[0]["pu_pref_puesto"]); }
                if (ds.Tables[0].Rows[0]["pu_objetivo"] != DBNull.Value && ds.Tables[0].Rows[0]["pu_objetivo"].ToString().Trim() != "") { _mdp_puesto.pu_objetivo = Convert.ToString(ds.Tables[0].Rows[0]["pu_objetivo"]); }
                if (ds.Tables[0].Rows[0]["pu_id_puesto_anterior"] != DBNull.Value && ds.Tables[0].Rows[0]["pu_id_puesto_anterior"].ToString().Trim() != "") { _mdp_puesto.pu_id_puesto_anterior = Convert.ToInt32(ds.Tables[0].Rows[0]["pu_id_puesto_anterior"]); }
                if (ds.Tables[0].Rows[0]["pu_estado"] != DBNull.Value && ds.Tables[0].Rows[0]["pu_estado"].ToString().Trim() != "") { _mdp_puesto.pu_estado = Convert.ToString(ds.Tables[0].Rows[0]["pu_estado"]); }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaGrilla__mdp_puesto(string pu_poai_id,
                        string pu_nro_puesto,
                        string pu_nombre_puesto,
                        string pu_pref_puesto,
                        string pu_objetivo,
                        string pu_id_puesto_anterior,
                        string pu_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                if (pu_poai_id.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_pu_poai_id", DbType.Int32, Convert.ToInt32(pu_poai_id)); }
                if (pu_nro_puesto.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_pu_nro_puesto", DbType.Int32, Convert.ToInt32(pu_nro_puesto)); }
                if (pu_nombre_puesto.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_pu_nombre_puesto", DbType.String, Convert.ToString(pu_nombre_puesto)); }
                if (pu_pref_puesto.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_pu_pref_puesto", DbType.String, Convert.ToString(pu_pref_puesto)); }
                if (pu_objetivo.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_pu_objetivo", DbType.String, Convert.ToString(pu_objetivo)); }
                if (pu_id_puesto_anterior.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_pu_id_puesto_anterior", DbType.Int32, Convert.ToInt32(pu_id_puesto_anterior)); }
                if (pu_estado.ToString().Trim() != "") { CnxSigrh3.AddInParameter(icom, "p_pu_estado", DbType.String, Convert.ToString(pu_estado)); }

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerTablaCombo__mdp_puesto()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrillaPuesto(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaFiltro(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_parametro1", DbType.String, _mdp_puesto.param1);
                CnxSigrh3.AddInParameter(icom, "p_parametro2", DbType.String, _mdp_puesto.param2);
                CnxSigrh3.AddInParameter(icom, "p_parametro3", DbType.String, _mdp_puesto.param3);
                CnxSigrh3.AddInParameter(icom, "p_parametro4", DbType.String, _mdp_puesto.param4);
                CnxSigrh3.AddInParameter(icom, "p_parametro5", DbType.String, _mdp_puesto.param5);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C8");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrillaFiltroIntervalo(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_parametro1", DbType.String, _mdp_puesto.param1);
                CnxSigrh3.AddInParameter(icom, "p_parametro2", DbType.String, _mdp_puesto.param2);
                CnxSigrh3.AddInParameter(icom, "p_parametro3", DbType.String, _mdp_puesto.param3);
                CnxSigrh3.AddInParameter(icom, "p_parametro4", DbType.String, _mdp_puesto.param4);
                CnxSigrh3.AddInParameter(icom, "p_parametro5", DbType.String, _mdp_puesto.param5);
                CnxSigrh3.AddInParameter(icom, "p_parametro6", DbType.String, _mdp_puesto.param6);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C34");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerGrillaFiltroCM(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_parametro2", DbType.String, _mdp_puesto.param2);
                CnxSigrh3.AddInParameter(icom, "p_parametro3", DbType.String, _mdp_puesto.param3);
                CnxSigrh3.AddInParameter(icom, "p_parametro4", DbType.String, _mdp_puesto.param4);
                CnxSigrh3.AddInParameter(icom, "p_parametro5", DbType.String, _mdp_puesto.param5);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaFiltroConocimientoCM(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_parametro2", DbType.String, _mdp_puesto.param2);
                CnxSigrh3.AddInParameter(icom, "p_parametro3", DbType.String, _mdp_puesto.param3);
                CnxSigrh3.AddInParameter(icom, "p_parametro4", DbType.String, _mdp_puesto.param4);
                CnxSigrh3.AddInParameter(icom, "p_parametro5", DbType.String, _mdp_puesto.param5);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C14");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoCargo(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C4");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerRegistro(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_parametroUser", DbType.String, _mdp_puesto.param1);
                CnxSigrh3.AddInParameter(icom, "p_parametroPass", DbType.String, _mdp_puesto.param2);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "R1");

                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["us_per_id"] != DBNull.Value && ds.Tables[0].Rows[0]["us_per_id"].ToString().Trim() != "") { _mdp_puesto.param1 = Convert.ToString(ds.Tables[0].Rows[0]["us_per_id"]); }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoDirAdm(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C5");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoUnidadEjec(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C7");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoUnidadOrg(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoGestion()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C9");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGestion(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_gestion", DbType.String, _mdp_puesto.gestion);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C10");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet ObtenerHistoricoItem(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, _mdp_puesto.ca_num_item);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C33");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerNombreFun(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_cod_fun", DbType.String, _mdp_puesto.cod_fun_login);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C19");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerDatosItem(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_cargo", DbType.Int32, Convert.ToInt32(_mdp_puesto.ca_cod_cargo));


                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C11");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["fu_nombres"] != DBNull.Value && ds.Tables[0].Rows[0]["fu_nombres"].ToString().Trim() != "") { _mdp_puesto.nombreFun = Convert.ToString(ds.Tables[0].Rows[0]["fu_nombres"]); }
                if (ds.Tables[0].Rows[0]["fu_paterno"] != DBNull.Value && ds.Tables[0].Rows[0]["fu_paterno"].ToString().Trim() != "") { _mdp_puesto.paternoFun = Convert.ToString(ds.Tables[0].Rows[0]["fu_paterno"]); }
                if (ds.Tables[0].Rows[0]["fu_materno"] != DBNull.Value && ds.Tables[0].Rows[0]["fu_materno"].ToString().Trim() != "") { _mdp_puesto.maternoFun = Convert.ToString(ds.Tables[0].Rows[0]["fu_materno"]); }
                if (ds.Tables[0].Rows[0]["fu_num_ident"] != DBNull.Value && ds.Tables[0].Rows[0]["fu_num_ident"].ToString().Trim() != "") { _mdp_puesto.ci = Convert.ToString(ds.Tables[0].Rows[0]["fu_num_ident"]); }
                if (ds.Tables[0].Rows[0]["fu_lugar_exp"] != DBNull.Value && ds.Tables[0].Rows[0]["fu_lugar_exp"].ToString().Trim() != "") { _mdp_puesto.ci_exp = Convert.ToString(ds.Tables[0].Rows[0]["fu_lugar_exp"]); }

                if (ds.Tables[0].Rows[0]["as_fecha_asignacion"] != DBNull.Value && ds.Tables[0].Rows[0]["as_fecha_asignacion"].ToString().Trim() != "") { _mdp_puesto.fecha_inicio = Convert.ToString(ds.Tables[0].Rows[0]["as_fecha_asignacion"]); }
                if (ds.Tables[0].Rows[0]["as_fecha_baja"] != DBNull.Value && ds.Tables[0].Rows[0]["as_fecha_baja"].ToString().Trim() != "") { _mdp_puesto.fecha_final = Convert.ToString(ds.Tables[0].Rows[0]["as_fecha_baja"]); }


                if (ds.Tables[0].Rows[0]["Imagen"] != DBNull.Value && ds.Tables[0].Rows[0]["Imagen"].ToString().Trim() != "")
                {
                    //_mdp_puesto.imagen = Convert.ToString(ds.Tables[0].Rows[0]["Imagen"]);
                    _mdp_puesto.imagen = "data:image/jpg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["Imagen"]);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ObtenerDatosItemAnterior(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_cargo", DbType.Int32, Convert.ToInt32(_mdp_puesto.ca_cod_cargo));
                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.Int32, Convert.ToInt32(_mdp_puesto.gestion_selec));


                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C12");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                if (ds.Tables[0].Rows[0]["fu_nombres"] != DBNull.Value && ds.Tables[0].Rows[0]["fu_nombres"].ToString().Trim() != "") { _mdp_puesto.nombreFun = Convert.ToString(ds.Tables[0].Rows[0]["fu_nombres"]); }
                if (ds.Tables[0].Rows[0]["fu_paterno"] != DBNull.Value && ds.Tables[0].Rows[0]["fu_paterno"].ToString().Trim() != "") { _mdp_puesto.paternoFun = Convert.ToString(ds.Tables[0].Rows[0]["fu_paterno"]); }
                if (ds.Tables[0].Rows[0]["fu_materno"] != DBNull.Value && ds.Tables[0].Rows[0]["fu_materno"].ToString().Trim() != "") { _mdp_puesto.maternoFun = Convert.ToString(ds.Tables[0].Rows[0]["fu_materno"]); }
                if (ds.Tables[0].Rows[0]["fu_num_ident"] != DBNull.Value && ds.Tables[0].Rows[0]["fu_num_ident"].ToString().Trim() != "") { _mdp_puesto.ci = Convert.ToString(ds.Tables[0].Rows[0]["fu_num_ident"]); }
                if (ds.Tables[0].Rows[0]["fu_lugar_exp"] != DBNull.Value && ds.Tables[0].Rows[0]["fu_lugar_exp"].ToString().Trim() != "") { _mdp_puesto.ci_exp = Convert.ToString(ds.Tables[0].Rows[0]["fu_lugar_exp"]); }

                if (ds.Tables[0].Rows[0]["as_fecha_asignacion"] != DBNull.Value && ds.Tables[0].Rows[0]["as_fecha_asignacion"].ToString().Trim() != "") { _mdp_puesto.fecha_inicio = Convert.ToString(ds.Tables[0].Rows[0]["as_fecha_asignacion"]); }
                if (ds.Tables[0].Rows[0]["as_fecha_baja"] != DBNull.Value && ds.Tables[0].Rows[0]["as_fecha_baja"].ToString().Trim() != "") { _mdp_puesto.fecha_final = Convert.ToString(ds.Tables[0].Rows[0]["as_fecha_baja"]); }


                if (ds.Tables[0].Rows[0]["Imagen"] != DBNull.Value && ds.Tables[0].Rows[0]["Imagen"].ToString().Trim() != "")
                {
                    //_mdp_puesto.imagen = Convert.ToString(ds.Tables[0].Rows[0]["Imagen"]);
                    _mdp_puesto.imagen = "data:image/jpg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["Imagen"]);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoConcocimiento(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);


                CnxSigrh3.AddInParameter(icom, "p_ico_poai_id", DbType.String, _mdp_puesto.co_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C17");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarTareaCM(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_res_poai_id", DbType.Int32, _mdp_puesto.pu_poai_id);
                CnxSigrh3.AddInParameter(icom, "p_tar_descripcion", DbType.String, _mdp_puesto.pu_objetivo);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C15");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override bool AdicionarConocimientoCM(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_ico_co_id", DbType.Int32, _mdp_puesto.co_id);
                CnxSigrh3.AddInParameter(icom, "p_ico_poai_id", DbType.String, _mdp_puesto.co_poai_id);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C16");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool validaRegistroConocimiento(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_ico_co_id", DbType.Int32, Convert.ToInt32(_mdp_puesto.co_id));
                CnxSigrh3.AddInParameter(icom, "p_ico_poai_id", DbType.Int32, Convert.ToInt32(_mdp_puesto.co_poai_id));

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C18");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                bool sw = false;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ico_co_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ico_co_id"].ToString().Trim() != "" && ds.Tables[0].Rows[0]["ico_poai_id"] != DBNull.Value && ds.Tables[0].Rows[0]["ico_poai_id"].ToString().Trim() != "")
                    {
                        sw = true;
                    }
                }
                return sw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerNivelOrg(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_eo_id", DbType.String, _mdp_puesto.eo_id);
                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C20");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerNivelOrgItems(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_eo_id", DbType.String, _mdp_puesto.eo_id);
                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C21");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerDetalleitem(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_num_iden", DbType.String, _mdp_puesto.eo_id.ToString());
                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C22");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoCargoUO(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C23");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoTipoItem(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_eo_id", DbType.String, _mdp_puesto.eo_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C24");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerDetalleUO(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_es_cod_esc", DbType.String, _mdp_puesto.es_cod_esc);
                CnxSigrh3.AddInParameter(icom, "p_gestion_selec", DbType.String, _mdp_puesto.gestion_selec);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C25");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerFiltradoTipoDoc()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C26");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerIdCargo()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C27");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerNroItem()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C28");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool AdicionarCargo(cls_mdp_puesto _mdp_puesto)
        {

            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mdp_puesto.ca_id);
                CnxSigrh3.AddInParameter(icom, "p_ca_es_id", DbType.Int32, _mdp_puesto.ca_es_id);
                CnxSigrh3.AddInParameter(icom, "p_ca_eo_id", DbType.Int32, _mdp_puesto.ca_eo_id);
                CnxSigrh3.AddInParameter(icom, "p_ca_ti_item", DbType.String, _mdp_puesto.ca_ti_item);
                CnxSigrh3.AddInParameter(icom, "p_ca_num_item", DbType.Int32, _mdp_puesto.ca_num_item);
                CnxSigrh3.AddInParameter(icom, "p_ca_estado", DbType.String, _mdp_puesto.ca_estado);
                CnxSigrh3.AddInParameter(icom, "p_ca_aplica_incremento", DbType.String, _mdp_puesto.ca_aplica_incremento);
                CnxSigrh3.AddInParameter(icom, "p_ca_tipo_jornada", DbType.String, _mdp_puesto.ca_tipo_jornada);
                CnxSigrh3.AddInParameter(icom, "p_ca_basico_calculado", DbType.String, _mdp_puesto.ca_basico_calculado);
                //CnxSigrh3.AddInParameter(icom, "p_ca_fecha_modificacion", DbType.DateTime, _mdp_puesto.ca_fecha_modificacion);
                CnxSigrh3.AddInParameter(icom, "p_ca_tipo_calculo", DbType.Int32, _mdp_puesto.ca_tipo_calculo);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A1");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool AdicionarGlosa(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_gl_valor_pk", DbType.Int32, _mdp_puesto.gl_valor_pk);
                CnxSigrh3.AddInParameter(icom, "p_gl_nombre_pk", DbType.String, _mdp_puesto.gl_nombre_pk);
                CnxSigrh3.AddInParameter(icom, "p_gl_tabla", DbType.String, _mdp_puesto.gl_tabla);
                CnxSigrh3.AddInParameter(icom, "p_gl_tipo_mov", DbType.Int32, _mdp_puesto.gl_tipo_mov);
                CnxSigrh3.AddInParameter(icom, "p_gl_fecha_doc", DbType.DateTime, _mdp_puesto.gl_fecha_doc);
                CnxSigrh3.AddInParameter(icom, "p_gl_tipo_doc", DbType.Int32, _mdp_puesto.gl_tipo_doc);
                CnxSigrh3.AddInParameter(icom, "p_gl_glosa", DbType.String, _mdp_puesto.gl_glosa);
                CnxSigrh3.AddInParameter(icom, "p_gl_estado", DbType.String, _mdp_puesto.gl_estado);
                CnxSigrh3.AddInParameter(icom, "p_gl_usuario", DbType.Int32, _mdp_puesto.gl_usuario);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "A2");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerGrillaItems(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C29");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerDetalleitemCargo(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_ca_id", DbType.Int32, _mdp_puesto.ca_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C30");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool ActualizarItem(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_ca_id", DbType.Int32, (_mdp_puesto.ca_id_anterior));

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C31");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool EliminarItem(cls_mdp_puesto _mdp_puesto)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__MDP_PUESTO);

                CnxSigrh3.AddInParameter(icom, "p_ca_id", DbType.Int32, (_mdp_puesto.ca_id));

                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C32");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DESCRIPTOR_PUESTO
        public override bool Adicionar_descriptor_puestos(int per_id)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "A3");
                CnxSigrh3.AddInParameter(icom, "per_id", DbType.Int32, per_id);

                CnxSigrh3.ExecuteNonQuery(icom);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet Listar_Supervisores()
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C1");
                return CnxSigrh3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override DataSet ObtenerTablaGrillaC__mp_asignacion(string per_id)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C50");
                CnxSigrh3.AddInParameter(icom, "per_id", DbType.Int32, Convert.ToInt32(per_id));
                return CnxSigrh3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override bool Add_descriptor_puestos(int per_id, int superv_id, String descrip_pu_objetivo)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "A4");
                CnxSigrh3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                CnxSigrh3.AddInParameter(icom, "superv_id", DbType.Int32, superv_id);
                CnxSigrh3.AddInParameter(icom, "descrip_pu_objetivo", DbType.String, descrip_pu_objetivo);


                // CnxSigrh3.AddInParameter(icom, "per_id", DbType.Int32, per_id);

                CnxSigrh3.ExecuteNonQuery(icom);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int Verificar_ca_id(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "A5");
                CnxSigrh3.AddInParameter(icom, "per_id", DbType.Int32, per_id);

                object result = CnxSigrh3.ExecuteScalar(icom);
                Console.WriteLine($"Resultado de la consulta: {result}");
                if (result != null && int.TryParse(result.ToString(), out int descrip_pu_id))
                {
                    return descrip_pu_id;
                }
                else
                {

                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1; // devuelve -1 para indicar que se produjo una excepción
            }
        }


        public override DataSet ObtenerRegistro_DescriptorPuesto(int descrip_pu_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                icom.CommandTimeout = 1200;
                CnxSigrh3.AddInParameter(icom, "descrip_pu_id", DbType.Int32, descrip_pu_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C26");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Add_DPR(string result_indicador, decimal result_ponderacion, String result_resultado, int dpr)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "A6");
                CnxSigrh3.AddInParameter(icom, "result_indicador", DbType.String, result_indicador);
                CnxSigrh3.AddInParameter(icom, "result_ponderacion", DbType.Decimal, Convert.ToDecimal(result_ponderacion));
                CnxSigrh3.AddInParameter(icom, "result_resultado", DbType.String, result_resultado);
                CnxSigrh3.AddInParameter(icom, "dpr", DbType.Int32, dpr);

                // CnxSigrh3.AddInParameter(icom, "per_id", DbType.Int32, per_id);

                CnxSigrh3.ExecuteNonQuery(icom);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ListarTareaEspecifica(int dpr, string result_tipo)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "dpr", DbType.Int32, dpr);
                CnxSigrh3.AddInParameter(icom, "result_tipo", DbType.String, result_tipo);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C27");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet DevolverDatosResultadosEspecificos(int dpr_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "r_id", DbType.Int32, dpr_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C28");
                return CnxSigrh3.ExecuteDataSet(icom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ListarTareaE(int id_r)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "id_r", DbType.Int32, id_r);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C30");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override decimal TotalE(int descrip_pu_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "descrip_pu_id", DbType.Int32, descrip_pu_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C31");
                object result = CnxSigrh3.ExecuteScalar(icom);

                if (result != DBNull.Value)
                {
                    decimal x = Convert.ToDecimal(result);
                    return x;
                }
                else
                {
                    return 0; // o cualquier otro valor que desees devolver en caso de que la consulta devuelva null
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override DataSet ListarResltaE(int id_r)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "id_r", DbType.Int32, id_r);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C32");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override bool Update_DPR(int des_p_result_id, string result_indicador, decimal result_ponderacion, string result_resultado)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "@Accion", DbType.String, "C29");
                CnxSigrh3.AddInParameter(icom, "@ResultIndicador", DbType.String, result_indicador);
                CnxSigrh3.AddInParameter(icom, "@ResultPonderacion", DbType.Decimal, result_ponderacion);
                CnxSigrh3.AddInParameter(icom, "@ResultResultado", DbType.String, result_resultado);
                CnxSigrh3.AddInParameter(icom, "@des_p_result_id", DbType.Int32, des_p_result_id);


                CnxSigrh3.ExecuteNonQuery(icom);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override bool Actualizar_UPR(cls_mp_descriptor_puestos _mp_descriptor_puestos)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "result_indicador", DbType.String, _mp_descriptor_puestos.result_indicador);
                CnxSigrh3.AddInParameter(icom, "result_ponderacion", DbType.Decimal, Convert.ToDecimal(_mp_descriptor_puestos.result_ponderacion));
                CnxSigrh3.AddInParameter(icom, "result_resultado", DbType.String, _mp_descriptor_puestos.result_resultado);
                CnxSigrh3.AddInParameter(icom, "des_p_result_id", DbType.Int32, _mp_descriptor_puestos.des_p_result_id); // Aquí lo usas en la consulta
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C29");

                CnxSigrh3.ExecuteNonQuery(icom);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar_DPR(int des_p_result_id, string result_estado)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "@Accion", DbType.String, "C33");
                CnxSigrh3.AddInParameter(icom, "@result_estado", DbType.String, result_estado);
                CnxSigrh3.AddInParameter(icom, "@des_p_result_id", DbType.Int32, des_p_result_id);


                CnxSigrh3.ExecuteNonQuery(icom);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override string Add_TareaEspecifica(string result_indicador, decimal result_ponderacion, String result_resultado, int dpr)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "A7");
                CnxSigrh3.AddInParameter(icom, "result_indicador", DbType.String, result_indicador);
                CnxSigrh3.AddInParameter(icom, "result_ponderacion", DbType.Decimal, Convert.ToDecimal(result_ponderacion));
                CnxSigrh3.AddInParameter(icom, "result_resultado", DbType.String, result_resultado);
                CnxSigrh3.AddInParameter(icom, "dpr", DbType.Int32, dpr);

                // Ejecuta el procedimiento almacenado y obtén el resultado
                IDataReader reader = CnxSigrh3.ExecuteReader(icom);
                if (reader.Read())
                {
                    return reader["Resultado"].ToString();
                }

                return "Error desconocido";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Update_DPEE(int des_p_result_id, string result_indicador, decimal result_ponderacion, string result_resultado)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "@Accion", DbType.String, "C36");
                CnxSigrh3.AddInParameter(icom, "@ResultIndicador", DbType.String, result_indicador);
                CnxSigrh3.AddInParameter(icom, "@ResultPonderacion", DbType.Decimal, result_ponderacion);
                CnxSigrh3.AddInParameter(icom, "@ResultResultado", DbType.String, result_resultado);
                CnxSigrh3.AddInParameter(icom, "@des_p_result_id", DbType.Int32, des_p_result_id);

                using (IDataReader reader = CnxSigrh3.ExecuteReader(icom))
                {
                    if (reader.Read())
                    {
                        string resultMessage = reader["Resultado"].ToString();
                        if (resultMessage == "Actualización exitosa")
                        {
                            return true;
                        }
                        else if (resultMessage == "El resultado Excede la ponderacion 70")
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        //============================ TAREAS RECURRENTES ================================================
      
        public override string Add_TareaRecurrente(decimal result_ponderacion, String result_resultado, int dpr)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "AA7");
                CnxSigrh3.AddInParameter(icom, "result_ponderacion", DbType.Decimal, Convert.ToDecimal(result_ponderacion));
                CnxSigrh3.AddInParameter(icom, "result_resultado", DbType.String, result_resultado);
                CnxSigrh3.AddInParameter(icom, "dpr", DbType.Int32, dpr);

                // Ejecuta el procedimiento almacenado y obtén el resultado
                IDataReader reader = CnxSigrh3.ExecuteReader(icom);
                if (reader.Read())
                {
                    return reader["Resultado"].ToString();
                }

                return "Error desconocido";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //----------------- SUMA TOTAL TE Y TR ---------------------
        public override decimal TotalER(int descrip_pu_id, string result_tipo)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "descrip_pu_id", DbType.Int32, descrip_pu_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C34");
                CnxSigrh3.AddInParameter(icom, "@result_tipo", DbType.String, @result_tipo);
                object result = CnxSigrh3.ExecuteScalar(icom);

                if (result != DBNull.Value)
                {
                    decimal x = Convert.ToDecimal(result);
                    return x;
                }
                else
                {
                    return 0; // o cualquier otro valor que desees devolver en caso de que la consulta devuelva null
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Update_DPER(int des_p_result_id, string result_indicador, decimal result_ponderacion, string result_resultado )
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "@Accion", DbType.String, "C35");
                CnxSigrh3.AddInParameter(icom, "@ResultIndicador", DbType.String, result_indicador);
                CnxSigrh3.AddInParameter(icom, "@ResultPonderacion", DbType.Decimal, result_ponderacion);
                CnxSigrh3.AddInParameter(icom, "@ResultResultado", DbType.String, result_resultado);
                CnxSigrh3.AddInParameter(icom, "@des_p_result_id", DbType.Int32, des_p_result_id);
               // CnxSigrh3.AddInParameter(icom, "@des_p_result_id", DbType.Int32, dpr);

                using (IDataReader reader = CnxSigrh3.ExecuteReader(icom))
                {
                    if (reader.Read())
                    {
                        string resultMessage = reader["Resultado"].ToString();
                        if (resultMessage == "Actualización exitosa")
                        {
                            return true;
                        }
                        else if (resultMessage == "El resultado Excede la ponderacion 30")
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
            return true;
        }

        //---------------------- AGREGAR PDF A TAREAS ---------------------
        public override int UpdateTER_PDF(int des_p_result_id, byte[] descrip_pdf)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "des_p_result_id", DbType.Int32, des_p_result_id);
                CnxSigrh3.AddInParameter(icom, "descrip_pdf", DbType.Binary, descrip_pdf);

                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "AA8");
                //int id = Convert.ToInt32(CnxSigrh3.ExecuteScalar(icom).ToString());
                return Convert.ToInt32(CnxSigrh3.ExecuteScalar(icom));
            }
            catch (Exception ex) { throw ex; }
        }
        //-------------------- SUPERVISOR -------------------------

        public override int supervisor_id(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C37");
                CnxSigrh3.AddInParameter(icom, "per_id", DbType.Int32, per_id);

                object result = CnxSigrh3.ExecuteScalar(icom);
                Console.WriteLine($"Resultado de la consulta: {result}");
                if (result != null && int.TryParse(result.ToString(), out int superv_id))
                {
                    return superv_id;
                }
                else
                {

                    return -1;
                }
            }
            catch (Exception ex)
            {

                return -1; // devuelve -1 para indicar que se produjo una excepción
            }
        }

        //================================= SUPERVISOR =======================================
        public override int Obtener_idSuperv(int per_id)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C37");
                CnxSigrh3.AddInParameter(icom, "per_id", DbType.Int32, per_id);

                object result = CnxSigrh3.ExecuteScalar(icom);
                Console.WriteLine($"Resultado de la consulta: {result}");
                if (result != null && int.TryParse(result.ToString(), out int superv_id))
                {
                    return superv_id;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Obtener_idSuperv: " + ex.Message, ex);
            }
        }
        

        public override DataSet ListarTareaSuper(int superv_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "i_super_id", DbType.Int32, superv_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C38");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ListarTareaER(int dpr)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "@dpr", DbType.Int32, dpr);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C39");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ObtenerPdf(int des_p_result_id)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C40");
                CnxSigrh3.AddInParameter(icom, "des_p_result_id", DbType.Int32, des_p_result_id);

                DataSet result = CnxSigrh3.ExecuteDataSet(icom);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerPdf: " + ex.Message, ex);
            }
        }

        //============================= EVALUACION =========================
        public override string Add_Eva(decimal ponderacion, int prdo, int result_id)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "M1");
                CnxSigrh3.AddInParameter(icom, "ponderacion", DbType.Decimal, Convert.ToDecimal(ponderacion));
                CnxSigrh3.AddInParameter(icom, "prdo", DbType.Int32, prdo);
                CnxSigrh3.AddInParameter(icom, "result_id", DbType.Int32, result_id);

                // Ejecuta el procedimiento almacenado y obtén el resultado
                IDataReader reader = CnxSigrh3.ExecuteReader(icom);
                if (reader.Read())
                {
                    return reader["Resultado"].ToString();
                }

                return "Error desconocido";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override decimal result_PonderacionTarea(int des_p_result_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "des_p_result_id", DbType.Int32, des_p_result_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "M2");

                object result = CnxSigrh3.ExecuteScalar(icom);

                if (result != DBNull.Value)
                {
                    decimal x = Convert.ToDecimal(result);
                    return x;
                }
                else
                {
                    return 0; // o cualquier otro valor que desees devolver en caso de que la consulta devuelva null
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Update_EstadoResultado(int des_p_result_id, string result_estado)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "M5");
                CnxSigrh3.AddInParameter(icom, "result_estado", DbType.String, result_estado);

                CnxSigrh3.AddInParameter(icom, "des_p_result_id", DbType.Int32, des_p_result_id);


                CnxSigrh3.ExecuteNonQuery(icom);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet Listar_EvaluacionesCa(int descrip_pu_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "descrip_pu_id", DbType.Int32, descrip_pu_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "M6");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet ResultEva(int evalua_dp_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "evalua_dp_id", DbType.Int32, evalua_dp_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "M7");
                DataSet ds = CnxSigrh3.ExecuteDataSet(icom);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int devuelver_Si_hayPDF(int des_p_result_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "des_p_result_id", DbType.Int32, des_p_result_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "K");

                return Convert.ToInt32(CnxSigrh3.ExecuteScalar(icom));
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override int ne_secuencial(int ca_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "ca_id", DbType.Int32, ca_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "K1");

                return Convert.ToInt32(CnxSigrh3.ExecuteScalar(icom));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public override int ca_per(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "K0");

                return Convert.ToInt32(CnxSigrh3.ExecuteScalar(icom));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override int devuelver_ca_id(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "KK3");

                return Convert.ToInt32(CnxSigrh3.ExecuteScalar(icom));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public override int ne_id(int ca_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "ca_id", DbType.Int32, ca_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "K1");

                return Convert.ToInt32(CnxSigrh3.ExecuteScalar(icom));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override int result(int ca_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "ca_id", DbType.Int32, ca_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "K4");

                return Convert.ToInt32(CnxSigrh3.ExecuteScalar(icom));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override bool Update_DP(int pu_id, string pu_objetivo)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "@Accion", DbType.String, "K5");
                CnxSigrh3.AddInParameter(icom, "pu_id", DbType.Int32, pu_id);
                CnxSigrh3.AddInParameter(icom, "pu_objetivo", DbType.String, pu_objetivo);

                CnxSigrh3.ExecuteNonQuery(icom);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }


        public override string Nom_Com(int pu_id)
        {
            try
            {
                DbCommand icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);

                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "K6");

                CnxSigrh3.AddInParameter(icom, "pu_id", DbType.Int32, pu_id);

                // Ejecuta el procedimiento almacenado y obtén el resultado
                using (IDataReader reader = CnxSigrh3.ExecuteReader(icom))
                {
                    if (reader.Read())
                    {
                        // Cambia "Resultado" por "Nom_Completo"
                        return reader["Nom_Completo"].ToString();
                    }
                }

                return "Error desconocido";
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Error while executing Nom_Com method.", ex);
            }
        }











        /*
        public override bool ActualizarTE(cls_mp_descriptor_puestos mp_descriptor_puestos)

        
        public override bool Eliminar_TE(int des_p_result_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "des_p_result_id", DbType.Int32, des_p_result_id);
                CnxSigrh3.AddInParameter(icom, "p_accion", DbType.String, "C30");
                CnxSigrh3.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override decimal TotalE(int result_pu_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "result_pu_id", DbType.Int32, result_pu_id);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "C31");
                decimal x = Convert.ToDecimal(CnxSigrh3.ExecuteScalar(icom));
                return x;
            }
            catch (Exception ex) { throw ex; }
        }
        */

        //cls_mdp_resultados_especificos _mdp_resultados_especificos



        /*
        public override bool Verificar_ca_id(int per_id)
        {
            try
            {
                DbCommand icom = null;
                icom = CnxSigrh3.GetStoredProcCommand(SP__DESCRIPTOR_PUESTOS);
                CnxSigrh3.AddInParameter(icom, "Accion", DbType.String, "A5");
                CnxSigrh3.AddInParameter(icom, "per_id", DbType.Int32, per_id);
                
                CnxSigrh3.ExecuteNonQuery(icom);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }*/


        #endregion
    }
}
