namespace appRegistroEmpresaDomiciliaria.acessoDatos {

    using appRegistroEmpresaDomiciliaria.Utilidades;
    using Oracle.DataAccess.Client;
    using System;
    using System.Data;

    class Datos {

        private static string CadenaConexion = "Data Source = localhost:1521; User ID = proyectobases1; Password = oracle";

        public static int EjecutarDML(string consulta) {
            int filasAfectadas = 0;
            try {
                OracleConnection miConexion = new OracleConnection(CadenaConexion);
                OracleCommand miComando = new OracleCommand(consulta, miConexion);

                miConexion.Open();
                filasAfectadas = miComando.ExecuteNonQuery();
                miConexion.Close();
            } catch (Exception ex) {
                Utilidad.MostrarMensajeError("Hubo un error con la base de datos al ejecutar la setencia DML, Comuniquese con soporte tecnico o el administrador");
            }
            return filasAfectadas;
        }

        public static DataSet EjecutarSelect(string consulta) {
            DataSet ds = new DataSet();
            try {
                OracleDataAdapter miAdaptador = new OracleDataAdapter(consulta, CadenaConexion);
                miAdaptador.Fill(ds, "ResultadoDatos");
            } catch (Exception ex) {
                Utilidad.MostrarMensajeError("Hubo un error con la base de datos al ejecutar la sentencia select, Por favor comuniquese con soporte tecnico o el administrador");
                Console.WriteLine(ex.Message);
            }
            return ds;
        }
    }
}