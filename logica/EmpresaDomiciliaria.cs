namespace appRegistroEmpresaDomiciliaria.logica {

    using appRegistroEmpresaDomiciliaria.acessoDatos;
    using System.Data;

    class EmpresaDomiciliaria {

        public int ingresarEmpresa(string nit,string nombre,string fecha,string nitCam) {
            int resultado;
            string consulta = "insert into Empresa_Domiciliaria (emp_nit, cam_nit, emp_nombre, emp_fechaoperar) " +
                $"values ('{ nit }','{ nitCam }','{ nombre }','{ fecha }')";
            resultado = Datos.ejecutarDML(consulta);
            return resultado;
        }

        public int actualizarEmpresa(string nit, string nitCam, string nombre, string fechaOpe) {
            int resultado;
            string consulta = $"update empresa_domiciliaria set cam_nit = '{ nitCam }', emp_nombre = '{ nombre }', " +
                $"emp_fechaoperar = '{ fechaOpe }' where emp_nit = '{ nit }'";
            resultado = Datos.ejecutarDML(consulta);
            return resultado;
        }

        public int eliminarEmpresa(string nit) {
            int resultado = 0;
            string consulta,consultaDependencia;
            consulta = $"delete empresa_domiciliaria where emp_nit = '{ nit }'";
            consultaDependencia = $"delete trabaja where emp_nit = '{ nit }'";
            resultado += Datos.ejecutarDML(consultaDependencia);
            resultado += Datos.ejecutarDML(consulta);
            return resultado;
        }

        public DataSet consultarEmpresa() {
            string consulta = "select emp_nit as \"Nit Empresa\", emp_nombre as \"Nombre Empresa\", emp_fechaoperar as \"Fecha Operación\", " +
                "cam_nit as \"Nit Camara Comercio\" from empresa_domiciliaria";
            DataSet ds = Datos.ejecutarSelect(consulta);
            return ds;
        }

        public DataSet consultarEmpresa(string nit) {
            string consulta = $"select * from empresa_domiciliaria where emp_nit = '{ nit }'";
            return Datos.ejecutarSelect(consulta);
        }
    }
}