namespace appRegistroEmpresaDomiciliaria.dominio {

    using System;
    using System.Windows.Forms;
    using appRegistroEmpresaDomiciliaria.logica;
    using appRegistroEmpresaDomiciliaria.Utilidades;

    public partial class VinculacionEmpresaDomiciliario : Form {

        private Trabaja Trabajo;

        public VinculacionEmpresaDomiciliario() {
            this.InitializeComponent();
            this.Trabajo = new Trabaja();
        }

        private void BtnRegistraVinculacion_Click(object sender, EventArgs e)
        {
            int resultadoTrab;
            double idDom;
            string nitEmp, fecIniTrab, fecFinTrab, id = string.Empty;
            if (
                !Utilidad.Estalleno(txtNitEmpDom.Text)
                || !Utilidad.Estalleno(txtIdDomEmp.Text)
                ) {
                Utilidad.MostrarMensajeError("Ninguno de los campos puede quedar vacío");
                return;
            }

            if (!Utilidad.EsNumerico(txtIdDomEmp.Text)) {
                Utilidad.MostrarMensajeError("Dígite una id numerica válida");
                return;
            }

            idDom = int.Parse(txtIdDomEmp.Text);
            nitEmp = txtNitEmpDom.Text;

            if (
                Valida.ExisteEmpresa(nitEmp) != 1
                || Valida.ExisteDomiciliario(idDom) != 1
                ) {
                Utilidad.MostrarMensajeError("Información no registrada porque no existe nit empresa o id domiciliario");
                return;
            }

            id += idDom;
            fecIniTrab = $"{ dtpFecIniDom.Value.Date.Day }/{ dtpFecIniDom.Value.Date.Month }/{ dtpFecFinDom.Value.Date.Year }";
            fecFinTrab = $"{ dtpFecFinDom.Value.Date.Day }/{ dtpFecFinDom.Value.Date.Month }/{ dtpFecFinDom.Value.Date.Year }";

            if (Valida.ExisteContrato(nitEmp, id, fecIniTrab, fecFinTrab) != 0) {
                Utilidad.MostrarMensajeError("Información no registrada porque ya existe la vinculación");
                return;
            }

            resultadoTrab = this.Trabajo.IngresarTrabajo(nitEmp, idDom, fecIniTrab, fecFinTrab);
            if (resultadoTrab > 0) {
                Utilidad.MostrarMensajeInformativo("Información Vinculación registrada");
                txtIdDomEmp.Text = string.Empty;
                txtNitEmpDom.Text = string.Empty;
                dtpFecIniDom.ResetText();
                dtpFecFinDom.ResetText();
            }
        }
    }
}