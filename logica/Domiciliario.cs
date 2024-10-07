namespace appRegistroEmpresaDomiciliaria.logica {

    using appRegistroEmpresaDomiciliaria.acessoDatos;
    using System.Data;

    class Domiciliario {

        public int IngresarDomiciliario(double id, string nom, string ape, string anio, string estado) {
            int resultado;
            string consulta = "insert into Domiciliario (dom_id, dom_nombre, dom_apellido, dom_anioexperiencia, dom_estado)" +
                $"values({ id },'{ nom }','{ ape }','{ anio }','{ estado }')";
            resultado = Datos.EjecutarDML(consulta);
            return resultado;
        }

        public int ActualizarDomiciliario(double id, string nom, string ape, string experiencia, string estado) {
            int resultado;
            string consulta = $"Update domiciliario set dom_nombre = '{ nom }', dom_apellido = '{ ape }', " +
                $"dom_anioexperiencia = '{ experiencia }', dom_estado = '{ estado }' where dom_id= { id }";
            resultado = Datos.EjecutarDML(consulta);
            return resultado;
        }

        public int EliminarDomiciliario(double id) {
            int resultado = 0;
            string consultaDependencia,consulta;
            consulta = $"Delete domiciliario where dom_id = { id }";
            consultaDependencia = $"delete trabaja where dom_id = { id }";
            resultado += Datos.EjecutarDML(consultaDependencia);
            resultado += Datos.EjecutarDML(consulta);
            return resultado;
        }

        public DataSet ConsultarDomiciliario() {
            string consulta = "select dom_id as \"Id Domiciliario\", dom_nombre as \"Nombre Domiciliario\", " +
                "dom_apellido as \"Apellido Domiciliario\", dom_anioexperiencia as \"Experiencia\",dom_estado as \"Estado\" from domiciliario";
            DataSet ds = Datos.EjecutarSelect(consulta);
            return ds;
        }

        public DataSet ConsultarDomiciliario(double id) {
            string consulta = $"select * from domiciliario where dom_id = { id }";
            return Datos.EjecutarSelect(consulta);
        }
    }
}