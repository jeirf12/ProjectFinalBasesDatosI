using appRegistroEmpresaDomiciliaria.Utilidades;
using Oracle.DataAccess.Client;
using System;
using System.Data;

namespace appRegistroEmpresaDomiciliaria.acessoDatos {
    class Datos {
        static string cadenaConexion = "Data Source = localhost:1521; User ID = proyectobases1; Password = oracle";

        public static int ejecutarDML(string consulta) {
            int filasAfectadas = 0;
            try {
                OracleConnection miConexion = new OracleConnection(cadenaConexion);
                OracleCommand miComando = new OracleCommand(consulta, miConexion);

                miConexion.Open();
                filasAfectadas = miComando.ExecuteNonQuery();
                miConexion.Close();
            } catch (Exception ex) {
                Utilidad.mostrarMensajeError("Hubo un error con la base de datos al ejecutar la setencia DML, Comuniquese con soporte tecnico o el administrador");
            }
            return filasAfectadas;
        }

        public static DataSet ejecutarSelect(string consulta) {
            DataSet ds = new DataSet();
            try {
                OracleDataAdapter miAdaptador = new OracleDataAdapter(consulta, cadenaConexion);
                miAdaptador.Fill(ds, "ResultadoDatos");
            } catch (Exception ex) {
                Utilidad.mostrarMensajeError("Hubo un error con la base de datos al ejecutar la sentencia select, Por favor comuniquese con soporte tecnico o el administrador");
            }
            return ds;
        }
    }
}