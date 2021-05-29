using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;

namespace appRegistroEmpresaDomiciliaria.acessoDatos
{
    class Datos
    {
        //Paso 0: Agregar en referencias la ddl de Oracle.DataAcess
        //incluir en using la referencia a oracle

        //Paso 1: Creo la cadena de conexion
        static string cadenaConexion = "Data Source = localhost:1522; User ID = proyectobases1; Password = oracle";

        //Paso 2: Creo el método que ejecuta una consulta DML(insert,update,delete,etc)
        public static int ejecutarDML(string consulta)
        {
            int filasAfectadas = 0;
            //Paso 1: Creo la conexion
            OracleConnection miConexion = new OracleConnection(cadenaConexion);

            //Paso 2: Creo un objeto comando
            OracleCommand miComando = new OracleCommand(consulta, miConexion);

            //Paso 3: Abro la conexión 
            miConexion.Open();

            /*Paso 4: Ejecuto el comando. Al ejecutar un objeto de tipo comando, este devuelve un valor entero
             * que significa las filas que se afectaron con la operación DML(insert,update,delete)
             * que llega en la consulta*/
            filasAfectadas = miComando.ExecuteNonQuery();

            //Paso 5: Cierro la conexión
            miConexion.Close();

            return filasAfectadas;
        }

        //Paso 3: Creo el método que ejecuta una consulta SELECT
        public static DataSet ejecutarSelect(string consulta)
        {
            //Paso 1: Crear un Data set vacio
            DataSet ds = new DataSet();

            //Paso 2: Creo un adaptador
            OracleDataAdapter miAdaptador = new OracleDataAdapter(consulta, cadenaConexion);

            //Paso 3: El adaptador llena el Data Set
            miAdaptador.Fill(ds, "ResultadoDatos");
            return ds;
        }
    }
}
