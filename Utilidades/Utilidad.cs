namespace appRegistroEmpresaDomiciliaria.Utilidades {
    
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    class Utilidad {

        public static void mostrarMensajeInformativo(string mensaje) =>
            MessageBox.Show(mensaje, "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void mostrarMensajeError(string mensaje) =>
            MessageBox.Show(mensaje, "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool esNumerico(string dato) =>
            Regex.IsMatch(dato, @"[+-]?\\d*(\\.\\d+)?");

        public static bool estalleno(string dato) => 
            !dato.Contains(" ") && !string.IsNullOrEmpty(dato);
    }
}