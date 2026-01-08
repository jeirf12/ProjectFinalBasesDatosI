namespace appRegistroEmpresaDomiciliaria.logica {
    
    using System.Data;
    using appRegistroEmpresaDomiciliaria.acessoDatos;

    static class Valida {

        public static int ExisteEmpresa(this string nit) {
            int resultado = 0;
            string consulta= $"select emp_nit from empresa_domiciliaria where emp_nit = '{nit}'";
            resultado += Buscar(consulta, "EMP_NIT", nit);
            return resultado;
        }

        public static int ExisteDomiciliario(this double id) {
            int resultado = 0;
            string consulta = $"select dom_id from domiciliario where dom_id = {id}";
            resultado += Buscar(consulta, "DOM_ID", "" + id);
            return resultado;
        }

        public static int ExisteCamaraComercio(this string nit) {
            int resultado = 0;
            string consulta = $"select cam_nit from camara_comercio where cam_nit = '{nit}'";
            resultado += Buscar(consulta, "CAM_NIT", nit);
            return resultado;
        }

        public static int ExisteContrato(this string nit, string id, string fechaInicio, string fechaFin) {
            int resultado = 0;
            string consulta = $"select * from trabaja where emp_nit = '{nit}' and dom_id = {int.Parse(id)} and trab_fecha_inicio in ('{fechaInicio}') and trab_fecha_fin in ('{fechaFin}')";
            resultado += Buscar(consulta, "EMP_NIT", nit);
            resultado += Buscar(consulta, "DOM_ID", id);
            resultado += Buscar(consulta, "TRAB_FECHA_INICIO", fechaInicio);
            resultado += Buscar(consulta, "TRAB_FECHA_FIN", fechaFin);
            return resultado;
        }

        private static int Buscar(string consulta, string nomColumna, string dato) {
            int resultado = 0;
            DataSet ds = Datos.EjecutarSelect(consulta);
            DataRowCollection dataRowCollectionResult = ds.Tables[0].Rows;
            if (dataRowCollectionResult.Count > 0) {
                for (int j = 0; j < dataRowCollectionResult.Count; j++) {
                    if (dato.Equals(dataRowCollectionResult[j][nomColumna].ToString()))
                        resultado += 1;
                }
            }
            return resultado;
        }
    }
}