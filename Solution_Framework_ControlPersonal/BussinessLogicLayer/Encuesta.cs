using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
    public class Encuesta
    {
        public bool EnviarEncuesta(int per_id, int op1, int op2, int op3, int op4)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EnviarEncuesta(per_id, op1, op2, op3, op4);
        }
    }
}
