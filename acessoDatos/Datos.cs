namespace appRegistroEmpresaDomiciliaria.acessoDatos {

    using appRegistroEmpresaDomiciliaria.Utilidades;
    using Oracle.DataAccess.Client;
    using System;
    using System.Data;

    class Datos {

        private static readonly string FuenteInformacion = "localhost:1521";

        private static readonly string Usuario = "proyectobases1";

        private static readonly string Contrasenia = "oracle";

        private static string CadenaConexion = $"Data Source = { FuenteInformacion }; User ID = { Usuario }; Password = { Contrasenia }";

        public static int EjecutarDML(string consulta) {
            int filasAfectadas = 0;
            try {
                OracleConnection miConexion = new OracleConnection(CadenaConexion);
                OracleCommand miComando = new OracleCommand(consulta, miConexion);

                miConexion.Open();
                filasAfectadas = miComando.ExecuteNonQuery();
                miConexion.Close();
            } catch (Exception ex) {
                Utilidad.MostrarMensajeError("Hubo un error con la base de datos al ejecutar la setencia DML, " +
                    "por favor comuniquesé con soporte técnico o el administrador");
            }
            return filasAfectadas;
        }

        public static DataSet EjecutarSelect(string consulta) {
            DataSet ds = new DataSet();
            try {
                OracleDataAdapter miAdaptador = new OracleDataAdapter(consulta, CadenaConexion);
                miAdaptador.Fill(ds, "ResultadoDatos");
            } catch (Exception ex) {
                Utilidad.MostrarMensajeError("Hubo un error con la base de datos al ejecutar la sentencia select, " +
                    "Por favor comuniquesé con soporte técnico o el administrador");
            }
            return ds;
        }
    }
}