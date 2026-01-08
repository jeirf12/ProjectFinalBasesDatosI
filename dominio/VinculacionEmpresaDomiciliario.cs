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
                !txtNitEmpDom.Text.Estalleno()
                || !txtIdDomEmp.Text.Estalleno()
                ) {
                ("Ninguno de los campos puede quedar vacío").MostrarMensajeError();
                return;
            }

            if (!txtIdDomEmp.Text.EsNumerico()) {
                ("Dígite una id numerica válida").MostrarMensajeError();
                return;
            }

            idDom = int.Parse(txtIdDomEmp.Text);
            nitEmp = txtNitEmpDom.Text;

            if (
                nitEmp.ExisteEmpresa() != 1
                || idDom.ExisteDomiciliario() != 1
                ) {
                ("Información no registrada porque no existe nit empresa o id domiciliario").MostrarMensajeError();
                return;
            }

            id += idDom;
            fecIniTrab = $"{ dtpFecIniDom.Value.Date.Day }/{ dtpFecIniDom.Value.Date.Month }/{ dtpFecFinDom.Value.Date.Year }";
            fecFinTrab = $"{ dtpFecFinDom.Value.Date.Day }/{ dtpFecFinDom.Value.Date.Month }/{ dtpFecFinDom.Value.Date.Year }";

            if (nitEmp.ExisteContrato(id, fecIniTrab, fecFinTrab) != 0) {
                ("Información no registrada porque ya existe la vinculación").MostrarMensajeError();
                return;
            }

            resultadoTrab = this.Trabajo.IngresarTrabajo(nitEmp, idDom, fecIniTrab, fecFinTrab);
            if (resultadoTrab > 0) {
                ("Información Vinculación registrada").MostrarMensajeInformativo();
                txtIdDomEmp.Text = string.Empty;
                txtNitEmpDom.Text = string.Empty;
                dtpFecIniDom.ResetText();
                dtpFecFinDom.ResetText();
            }
        }
    }
}