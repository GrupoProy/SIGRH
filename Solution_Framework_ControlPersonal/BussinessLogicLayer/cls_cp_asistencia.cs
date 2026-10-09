using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ControlPersonal.DataAccessLayer;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
    public class cls_cp_asistencia
    {
        #region PROPIEDADES
        public int cod_persona { get; set; }
        public string f_ini { get; set; }
        public string f_fin { get; set; }
        public string fecha1 { get; set; }
        #endregion

        #region METODOS
        public DataSet ObtenerPersonalC()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPersonal__cp_asistencia(this.fecha1);
        }

        public DataSet ObtenerReporteAsistencia()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerReporteAsistencia__cp_asistencia(this.cod_persona, this.f_ini, this.f_fin);
        }
        #endregion
    }
}