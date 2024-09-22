namespace appRegistroEmpresaDomiciliaria.logica {

    using appRegistroEmpresaDomiciliaria.acessoDatos;
    using System.Data;

    class CamaraComercio {

        public int ingresarCamaraComercio(string nit, string nombre) {
            int resultado;
            string consulta = $"insert into Camara_Comercio (cam_nit, cam_nombre) values('{ nit }', '{ nombre }')";
            resultado = Datos.ejecutarDML(consulta);
            return resultado;
        }

        public DataSet consultarCamaraComercio() {
            string consulta = "select cam_nit as \"Nit Camara Comercio\", cam_nombre as \"Nombre Camara Comercio\" from camara_comercio";
            DataSet ds = Datos.ejecutarSelect(consulta);
            return ds;
        }
    }
}