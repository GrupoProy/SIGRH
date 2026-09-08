using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
    public class cls_pla_retroactivo
    {
        public bool ProcesoRetroactivo1(int pc_id, int secuencial)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ProcesoRetroactivo1(pc_id, secuencial);
        }
    }
}
