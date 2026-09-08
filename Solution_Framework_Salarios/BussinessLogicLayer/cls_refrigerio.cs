using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
    public class cls_refrigerio
    {
        public DataSet ObtenerNroPlanilla(int pc_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNroPlanilla(pc_id);
        }
    }
}
