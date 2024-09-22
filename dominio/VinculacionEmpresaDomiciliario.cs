namespace appRegistroEmpresaDomiciliaria.dominio {

    using System;
    using System.Windows.Forms;
    using appRegistroEmpresaDomiciliaria.logica;
    using appRegistroEmpresaDomiciliaria.Utilidades;

    public partial class VinculacionEmpresaDomiciliario : Form {

        private Trabaja trabajo;

        public VinculacionEmpresaDomiciliario() {
            this.InitializeComponent();
            this.trabajo = new Trabaja();
        }

        private void btnRegistraVinculacion_Click(object sender, EventArgs e)
        {
            int resultadoTrab;
            double idDom;
            string nitEmp, fecIniTrab, fecFinTrab, id = string.Empty;
            if (
                !Utilidad.estalleno(txtNitEmpDom.Text)
                || !Utilidad.estalleno(txtIdDomEmp.Text)
                ) {
                Utilidad.mostrarMensajeError("Ninguno de los campos puede quedar vacío");
                return;
            }

            if (!Utilidad.esNumerico(txtIdDomEmp.Text)) {
                Utilidad.mostrarMensajeError("Dígite una id numerica válida");
                return;
            }

            idDom = int.Parse(txtIdDomEmp.Text);
            nitEmp = txtNitEmpDom.Text;

            if (
                Valida.existeEmpresa(nitEmp) != 1
                || Valida.existeDomiciliario(idDom) != 1
                ) {
                Utilidad.mostrarMensajeError("Información no registrada porque no existe nit empresa o id domiciliario");
                return;
            }

            id += idDom;
            fecIniTrab = $"{ dtpFecIniDom.Value.Date.Day }/{ dtpFecIniDom.Value.Date.Month }/{ dtpFecFinDom.Value.Date.Year }";
            fecFinTrab = $"{ dtpFecFinDom.Value.Date.Day }/{ dtpFecFinDom.Value.Date.Month }/{ dtpFecFinDom.Value.Date.Year }";

            if (Valida.existeContrato(nitEmp, id, fecIniTrab, fecFinTrab) != 0) {
                Utilidad.mostrarMensajeError("Información no registrada porque ya existe la vinculación");
                return;
            }

            resultadoTrab = this.trabajo.ingresarTrabajo(nitEmp, idDom, fecIniTrab, fecFinTrab);
            if (resultadoTrab > 0) {
                Utilidad.mostrarMensajeInformativo("Información Vinculación registrada");
                txtIdDomEmp.Text = string.Empty;
                txtNitEmpDom.Text = string.Empty;
                dtpFecIniDom.ResetText();
                dtpFecFinDom.ResetText();
            }
        }
    }
}