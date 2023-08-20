using System;
using System.Windows.Forms;

namespace appRegistroEmpresaDomiciliaria.Utilidades {
    class Utilidad {
        public static void mostrarMensajeInformativo(string mensaje) {
            MessageBox.Show(mensaje, "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void mostrarMensajeError(string mensaje) {
            MessageBox.Show(mensaje, "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static Boolean esNumerico(string dato) {
            Boolean resultado = true;
            try {
                int.Parse(dato);
            } catch (Exception) {
                resultado = false;
            }
            return resultado;
        }

        public static Boolean estalleno(string dato) {
            return !dato.Contains(" ") && dato.Length > 0;
        }
    }
}