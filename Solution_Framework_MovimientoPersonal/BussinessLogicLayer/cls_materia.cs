using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
    public class cls_materia
    {
        public int gestion { get; set; }
        public string area { get; set; }
        public string carrera { get; set; }
        public string estado { get; set; }
        public int id { get; set; }
        public int mat_id { get; set; }
        public int p_id { get; set; }
        public string sigla { get; set; }
        public string mat_nombre { get; set; }
        public int hrs_asig { get; set; }
        public int mat_nivel { get; set; }
        public int mat_grupo { get; set; }
        public int car_id { get; set; }
        public int tip_ad { get; set; }
        public int mat_per_id { get; set; }
        public string jornada { get; set; }
        public string tipo_doc { get; set; }
        public int eo_id { get; set; }
        public int us_id { get; set; }
        public int ca_doc { get; set; }
        public int aed_ed_id { get; set; }
        public DateTime fecha_ini { get; set; }
        public string fecha_fin { get; set; }
        public string tipo_ing { get; set; }
        public int mat_as_id { get; set; }

        public int ht_pc_ic { get; set; }
        public int ht_hrs_mes { get; set; }
        public int ht_faltas { get; set; }
        public int ht_atrasos { get; set; }
        public int ht_as_id { get; set; }

        public int mat_mc_id { get; set; }

        #region PLAN

        public DataSet ObtenerArea()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerArea__plan();
        }
        public bool AdicionarPlan()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarPlan__nuevo(this);
        }
        public DataSet ObtenerCarrera()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCarrera__plan(this);
        }

        public DataSet ObtenerPlan()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPlan__G();
        }

        public DataSet C_ObtenerPlan()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPlan_C(this);
        }
        public bool CambiarEstadoPlan()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.CambiarEstadoPlan(this);
        }
        #endregion

        #region MATERIA
        public bool AdicionarHoras()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarHoras(this);
        }
        public bool AddicionarMatCa()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AddicionarMatCa(this);
        }
        public bool AdicionarMateria()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarMateria(this);
        }
        public DataSet BuscarMateria2()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.BuscarMateria2(this);
        }
        public DataSet Listar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.BuscarMateria(this);
        }
        public bool EliminarMateria__()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarMateria(this);
        }
        public DataSet ObtenerEO(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerEO(per_id);
        }
        public string AdicionarAsignacion__()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarAsignacion(this);
        }
        public string horas_(int mat_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.horas(mat_id);
        }
        public DataSet GetEstructura(int asig, string carre)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Estructura(asig, carre);
        }

        public DataSet ListarCargosDocente()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarCargosDocente(this);
        }

        public int ObtenerTablaGrilla__Doc(string as_per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__Doc(as_per_id);
        }

        public int ObtenerEscalafon(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerEscalafon(per_id);
        }
        #endregion

        #region FALTAS Y ATRASOS
        public DataSet ObtenerUnidadesOrganizacionales_filtrado_docentes(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerUnidadesOrganizacionales_filtrado_docentes(per_id);
        }

        public DataSet DOCENTES_ListarGrillaDocentesMesPorUnidad(int eo_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DOCENTES_ListarGrillaDocentesMesPorUnidad(eo_id);
        }

        public DataSet Docente_ModificarHorasFaltasAtrasos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Docente_ModificarHorasFaltasAtrasos(this);
        }

        public string btnValidar(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.btnValidar(per_id);
        }

        public bool CambiarEstadoHT(int eo_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.CambiarEstadoHT(eo_id);
        }

        public bool CambiarEstadoHT2(int eo_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.CambiarEstadoHT2(eo_id);
        }
        public bool CambiarEstadoHT3(int eo_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.CambiarEstadoHT3(eo_id);
        }
        public bool CambiarEstadoAsig(int as_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.CambiarEstadoAsig(as_id);
        }
        public bool CambiarEstadoAsig2(int as_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.CambiarEstadoAsig2(as_id);
        }

        #endregion
    }
}
