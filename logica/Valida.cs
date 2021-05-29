using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using appRegistroEmpresaDomiciliaria.acessoDatos;

namespace appRegistroEmpresaDomiciliaria.logica
{
    class Valida
    {
        
        public static int existeEmpresa(string nit)
        {
            int resultado = 0;
            string consulta= "select emp_nit from empresa_domiciliaria where emp_nit = '" + nit + "'";
            resultado += buscar(consulta, "EMP_NIT", nit);
            return resultado;
        }
        public static int existeDomiciliario(double id)
        {
            int resultado = 0;
            string consulta = "select dom_id from domiciliario where dom_id=" + id;
            resultado += buscar(consulta, "DOM_ID", ""+id);
            return resultado;
        }
        public static int existeCamaraComercio(string nit)
        {
            int resultado = 0;
            string consulta = "select cam_nit from camara_comercio where cam_nit= '" + nit + "'";
            resultado += buscar(consulta, "CAM_NIT", nit);
            return resultado;
        }
        /*Valida las fechas que son primary key, debido a que su formato es tipo date en SQL*/
        public static int existeContrato(string nit, string id, string fechaInicio, string fechaFin)
        {
            int resultado = 0;
            string consulta="select * from trabaja where  emp_nit='" + nit + "' and dom_id= " + int.Parse(id)+" and trab_fecha_inicio in ('" + fechaInicio + "') and trab_fecha_fin in('" + fechaFin + "')";
            resultado += buscar(consulta, "EMP_NIT", nit);
            resultado += buscar(consulta, "DOM_ID", id);
            resultado += buscar(consulta, "TRAB_FECHA_INICIO", fechaInicio);
            resultado += buscar(consulta, "TRAB_FECHA_FIN", fechaFin);
            return resultado;
        }
        /*Buscar: Su funcionalidad es encontrar las coincidencias recibiendo como parametros una consulta, el 
         * nombre de la columna a buscar, y el elemento que se va a comparar con los elementos de un data set
         * al hallar tal coincidencia sumara 1 y retornara ese valor en la varibale resultado*/
        public static int buscar(string consulta, string nomColumna, string dato)
        {
            int resultado = 0;
            DataSet ds = Datos.ejecutarSelect(consulta);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    if (dato.Equals(ds.Tables[0].Rows[j][nomColumna].ToString()))
                    {
                        resultado += 1;
                    }
                }
            }
            return resultado;
        }
        /* Este metodo lo que hace es modo bandera el cual indica cuando un string puede ser entero
         * en caso contrario mandara un false utilizando el try catch*/
        public static Boolean esNumerico(string dato)
        {
            Boolean resultado = true;
            try
            {
                int.Parse(dato);
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }
        public static Boolean estalleno(string dato)
        {
            if (!dato.Contains(" ") && dato.Length>0)
            {
                return true;
            }
            return false;
        }
    }
}
