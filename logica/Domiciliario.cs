using appRegistroEmpresaDomiciliaria.acessoDatos;
using System.Data;

namespace appRegistroEmpresaDomiciliaria.logica {
    class Domiciliario {
        public int ingresarDomiciliario(double id, string nom, string ape, string anio, string estado) {
            int resultado;
            string consulta = "insert into Domiciliario (dom_id,dom_nombre,dom_apellido,dom_anioexperiencia,dom_estado)values(" + id + ",'" + nom + "','" + ape + "','" + anio + "','" + estado + "')";
            resultado = Datos.ejecutarDML(consulta);
            return resultado;
        }

        public int actualizarDomiciliario(double id,string nom,string ape,string experiencia,string estado) {
            int resultado;
            string consulta = "Update domiciliario set dom_nombre = '" + nom + "', dom_apellido = '" + ape + "', dom_anioexperiencia = '" + experiencia + "', dom_estado = '" + estado+ "' where dom_id= " + id;
            resultado = Datos.ejecutarDML(consulta);
            return resultado;
        }

        public int eliminarDomiciliario(double id) {
            int resultado = 0;
            string consultaDependencia,consulta;
            consulta = "Delete domiciliario where dom_id =" + id;
            consultaDependencia = "delete trabaja where dom_id =" + id;
            resultado += Datos.ejecutarDML(consultaDependencia);
            resultado += Datos.ejecutarDML(consulta);
            return resultado;
        }

        public DataSet consultarDomiciliario() {
            string consulta = "select dom_id as \"Id Domiciliario\", dom_nombre as \"Nombre Domiciliario\", dom_apellido as \"Apellido Domiciliario\", dom_anioexperiencia as \"Experiencia\",dom_estado as \"Estado\" from domiciliario";
            DataSet ds = Datos.ejecutarSelect(consulta);
            return ds;
        }

        public DataSet consultarDomiciliario(double id) {
            string consulta = "select * from domiciliario where dom_id= " + id;
            return Datos.ejecutarSelect(consulta);
        }
    }
}