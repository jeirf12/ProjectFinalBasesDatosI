namespace appRegistroEmpresaDomiciliaria.Utilidades {
    
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public static class Utilidad {

        public static void MostrarMensajeInformativo(this string mensaje) =>
            MessageBox.Show(mensaje, "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void MostrarMensajeError(this string mensaje) =>
            MessageBox.Show(mensaje, "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool EsNumerico(this string dato) =>
            Regex.IsMatch(dato, @"^[+-]?\d*(\.\d+)?$");

        public static bool Estalleno(this string dato) =>
            !string.IsNullOrWhiteSpace(dato) && !string.IsNullOrEmpty(dato);
    }
}