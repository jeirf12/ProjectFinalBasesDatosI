using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appRegistroEmpresaDomiciliaria.acessoDatos;
using System.Data;

namespace appRegistroEmpresaDomiciliaria.logica
{
    class Trabaja
    {
        public int ingresarTrabajo(string nit, double id, string fechaIni, string fechaFin)
        {
            int resultado;
            string consulta = "insert into Trabaja(emp_nit,dom_id,trab_fecha_inicio,trab_fecha_fin)values('" + nit + "'," + id + ",'" + fechaIni + "','" + fechaFin + "')";
            resultado = Datos.ejecutarDML(consulta);
            return resultado;
        }
        public DataSet consultaTrabaja()
        {
            string consulta = "select e.emp_nit as \"Nit Empresa\", emp_nombre as \"Nombre Empresa\", emp_fechaoperar as \"Fecha Operación\", d.dom_id as \"Id Domiciliario\", dom_nombre as \"Nombre Domiciliario\", dom_apellido as \"Apellido Domiciliario\", dom_anioexperiencia as \"Experiencia\",dom_estado as \"Estado\",trab_fecha_inicio as \"Fecha Inicio\",trab_fecha_fin as \"Fecha Fin\" from empresa_domiciliaria e inner join trabaja t on e.emp_nit=t.emp_nit inner join domiciliario d on d.dom_id=t.dom_id";
            DataSet ds = Datos.ejecutarSelect(consulta);
            return ds;
        }
    }
}
