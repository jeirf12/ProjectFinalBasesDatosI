namespace appRegistroEmpresaDomiciliaria.logica {
    
    using System.Data;
    using appRegistroEmpresaDomiciliaria.acessoDatos;

    static class Valida {

        public static int ExisteEmpresa(this string nit) {
            int resultado = 0;
            string consulta= $"select emp_nit from empresa_domiciliaria where emp_nit = '{ nit }'";
            DataRowCollection resultadoConsulta = EjecutarConsulta(consulta);
            resultado += Buscar(resultadoConsulta, "EMP_NIT", nit);
            return resultado;
        }

        public static int ExisteDomiciliario(this double id) {
            int resultado = 0;
            string consulta = $"select dom_id from domiciliario where dom_id = { id }";
            DataRowCollection resultadoConsulta = EjecutarConsulta(consulta);
            resultado += Buscar(resultadoConsulta, "DOM_ID", id.ToString());
            return resultado;
        }

        public static int ExisteCamaraComercio(this string nit) {
            int resultado = 0;
            string consulta = $"select cam_nit from camara_comercio where cam_nit = '{ nit }'";
            DataRowCollection resultadoConsulta = EjecutarConsulta(consulta);
            resultado += Buscar(resultadoConsulta, "CAM_NIT", nit);
            return resultado;
        }

        public static int ExisteContrato(this string nit, string id, string fechaInicio, string fechaFin) {
            int resultado = 0;
            string consulta = $"select * from trabaja where emp_nit = '{ nit }' and " +
                $"dom_id = { int.Parse(id) } and " +
                $"trab_fecha_inicio in to_date('{ fechaInicio }', 'dd/mm/yyyy') and " +
                $"trab_fecha_fin in to_date('{ fechaFin }', 'dd/mm/yyyy')";
            DataRowCollection resultadoConsulta = EjecutarConsulta(consulta);
            resultado += Buscar(resultadoConsulta, "EMP_NIT", nit);
            resultado += Buscar(resultadoConsulta, "DOM_ID", id);
            resultado += Buscar(resultadoConsulta, "TRAB_FECHA_INICIO", fechaInicio);
            resultado += Buscar(resultadoConsulta, "TRAB_FECHA_FIN", fechaFin);
            return resultado;
        }

        private static int Buscar(DataRowCollection resultadoConsulta, string nomColumna, string dato) {
            int resultado = 0;
            if (resultadoConsulta?.Count > 0) {
                for (int j = 0; j < resultadoConsulta.Count; j++) {
                    if (dato.Equals(resultadoConsulta[j][nomColumna].ToString()))
                        resultado += 1;
                }
            }
            return resultado;
        }

        private static DataRowCollection EjecutarConsulta(string consulta)
        {
            DataSet ds = Datos.EjecutarSelect(consulta);
            return ds.Tables.Count == 0 
                ? null 
                : ds.Tables[0].Rows;
        }
    }
}