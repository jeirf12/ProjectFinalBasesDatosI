using Oracle.DataAccess.Client;
using System.Data;

namespace appRegistroEmpresaDomiciliaria.acessoDatos {
    class Datos {
        static string cadenaConexion = "Data Source = localhost:1521; User ID = proyectobases1; Password = oracle";

        public static int ejecutarDML(string consulta) {
            int filasAfectadas = 0;
            OracleConnection miConexion = new OracleConnection(cadenaConexion);

            OracleCommand miComando = new OracleCommand(consulta, miConexion);

            miConexion.Open();

            filasAfectadas = miComando.ExecuteNonQuery();

            miConexion.Close();

            return filasAfectadas;
        }

        public static DataSet ejecutarSelect(string consulta) {
            DataSet ds = new DataSet();

            OracleDataAdapter miAdaptador = new OracleDataAdapter(consulta, cadenaConexion);

            miAdaptador.Fill(ds, "ResultadoDatos");
            return ds;
        }
    }
}