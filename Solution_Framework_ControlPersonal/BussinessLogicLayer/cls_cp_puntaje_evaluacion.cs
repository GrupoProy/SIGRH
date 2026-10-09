using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
    public class cls_cp_puntaje_evaluacion
    {
        #region METODOS
        public decimal puntaje_evaluacion(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.puntaje_evaluacion(per_id);
        }
        #endregion
    }
}
