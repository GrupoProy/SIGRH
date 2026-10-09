using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;


namespace Solution_Framework_Cheques.DataAccessLayer
{
    public abstract class DataAccessLayerDataAccessLayer
    {
        #region INSTANCIA PRINCIPAL DE CONEXION A UNA BD
        public Database CNXSIGRH3 = DatabaseFactory.CreateDatabase("CnxSigrh3");
        #endregion
    }
    #region _CP_CONTROLES_PERSONAL
   
    #endregion
}
