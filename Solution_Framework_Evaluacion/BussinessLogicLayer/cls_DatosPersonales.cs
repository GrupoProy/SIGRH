using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Solution_Framework_Evaluacion.DataAccessLayer;

namespace Solution_Framework_Evaluacion.BussinessLogicLayer
{
    public class cls_DatosPersonales
    {
        #region PROPIEDADES
        public int per_id { get; set; }
        public string ci { get; set; }
        public string ext { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string nombres { get; set; }
        public int ca_id { get; set; }
        public int ca_id_evaluador { get; set; }
        public string item { get; set; }
        public string cargo { get; set; }
        public string puesto { get; set; }
        public string unidad { get; set; }
        public string estado { get; set; }
        public int id_gestion { get; set; }
        public int id_evaluacion { get; set; }

        #endregion
        #region METODOS
        #region GESTIÓN
        public static DataSet GestionActual(int per_id, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.GestionActual(per_id.ToString(), tipo);
        }
        #endregion
        public static DataSet FuncionariosDependientes(int per_id, string unidad, int pr_id, int periodo, string tipo, int ca_id)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.FuncionariosDependientes(per_id, unidad, pr_id, periodo, tipo, ca_id);
        }
        public static DataSet FuncionarioDatosPersonales(int per_id, int periodo, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.FuncionarioDatosPersonales(per_id, periodo, tipo);
        }
        public static DataSet FuncionarioDatosPersonalesEvaluador(int per_id, int periodo, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.FuncionarioDatosPersonalesEvaluador(per_id, periodo, tipo);
        }


        #endregion
    }
    }
