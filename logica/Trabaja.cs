using appRegistroEmpresaDomiciliaria.acessoDatos;
using System.Data;

namespace appRegistroEmpresaDomiciliaria.logica {
    class Trabaja {
        public int ingresarTrabajo(string nit, double id, string fechaIni, string fechaFin) {
            int resultado;
            string consulta = "insert into Trabaja(emp_nit,dom_id,trab_fecha_inicio,trab_fecha_fin)values('" + nit + "'," + id + ",to_date('" + fechaIni + "', 'dd/mm/yyyy'),to_date('" + fechaFin + "', 'dd/mm/yyyy'))";
            resultado = Datos.ejecutarDML(consulta);
            return resultado;
        }

        public DataSet consultaTrabajo() {
            string consulta = "select e.emp_nit as \"Nit Empresa\", emp_nombre as \"Nombre Empresa\", emp_fechaoperar as \"Fecha Operación\", d.dom_id as \"Id Domiciliario\", dom_nombre as \"Nombre Domiciliario\", dom_apellido as \"Apellido Domiciliario\", dom_anioexperiencia as \"Experiencia\", dom_estado as \"Estado\", trab_fecha_inicio as \"Fecha Inicio\", trab_fecha_fin as \"Fecha Fin\" from empresa_domiciliaria e inner join trabaja t on e.emp_nit = t.emp_nit inner join domiciliario d on d.dom_id = t.dom_id";
            DataSet ds = Datos.ejecutarSelect(consulta);
            return ds;
        }

        public int domiciliariosInactivos() {
            int resultado = 0;
            string consulta = "select count(t.dom_id) from trabaja t inner join domiciliario d on t.dom_id=d.dom_id where dom_estado = 'inactivo' or trab_fecha_fin >= sysdate";
            DataSet ds = Datos.ejecutarSelect(consulta);
            if (ds.Tables[0].Rows.Count > 0) {
                resultado = int.Parse("" + ds.Tables[0].Rows[0].ItemArray[0]);
            }
            return resultado;
        }

        public DataSet consultaTrabajo(string fecha) {
            string consultaFecha = "select cam_nombre as \"Nombre Camara Comercio\",e.emp_nit as \"Nit Empresa\", emp_nombre as \"Nombre Empresa\", d.dom_id as \"Id Domiciliario\", dom_nombre as \"Nombre Domiciliario\", dom_apellido as \"Apellido Domiciliario\" from camara_comercio c inner join empresa_domiciliaria e on c.cam_nit=e.cam_nit inner join trabaja t on e.emp_nit = t.emp_nit inner join domiciliario d on d.dom_id = t.dom_id where trab_fecha_inicio in (to_date('" + fecha + "', 'dd/mm/yyyy'))";
            DataSet ds = Datos.ejecutarSelect(consultaFecha);
            return ds;
        }
    }
}