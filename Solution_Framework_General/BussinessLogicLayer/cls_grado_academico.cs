using System;
using System.Collections.Generic;
 
using System.Text;
using System.Threading.Tasks;
using Solution_Framework_General.DataAccessLayer;
using System.Data;

namespace Solution_Framework_General.BussinessLogicLayer
{
    public class cls_grado_academico
    {
        #region PROPIEDADES
        public int ga_id { get; set; }
        public string ga_nombre { get; set; }
        public string ga_estado { get; set; }
        #endregion
        #region METODOS
        public  DataSet ObtenerGradoAcademico()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGradoAcademico();
        }
        public  DataSet ComboFormacion(string accion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ComboFormacion(accion);
        }
        public  DataSet ComboFormacionCarreras(string accion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ComboFormacionCarreras(accion);
        }
        #endregion
    }
}
