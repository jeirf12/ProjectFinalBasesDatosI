namespace appRegistroEmpresaDomiciliaria.Utilidades {
    
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class Utilidad {

        public static void MostrarMensajeInformativo(string mensaje) =>
            MessageBox.Show(mensaje, "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void MostrarMensajeError(string mensaje) =>
            MessageBox.Show(mensaje, "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool EsNumerico(string dato) =>
            Regex.IsMatch(dato, @"^[+-]?\d*(\.\d+)?$");

        public static bool Estalleno(string dato) => 
            !string.IsNullOrWhiteSpace(dato) && !string.IsNullOrEmpty(dato);
    }
}