using System;
using System.Windows.Forms;
using appRegistroEmpresaDomiciliaria.logica;
using appRegistroEmpresaDomiciliaria.Utilidades;

namespace appRegistroEmpresaDomiciliaria.dominio {
    public partial class VinculacionEmpresaDomiciliario : Form {
        private Trabaja trabajo;

        public VinculacionEmpresaDomiciliario() {
            this.InitializeComponent();
            this.trabajo = new Trabaja();
        }
        
        private void btnRegistraVinculacion_Click(object sender, EventArgs e) {
            int resultadoTrab;
            double idDom;
            string nitEmp, fecIniTrab, fecFinTrab, id = "";
            if (Utilidad.estalleno(txtNitEmpDom.Text) && Utilidad.estalleno(txtIdDomEmp.Text)) {
                if (Utilidad.esNumerico(txtIdDomEmp.Text)) {
                    idDom = int.Parse(txtIdDomEmp.Text);
                    id += idDom;
                    nitEmp = txtNitEmpDom.Text;
                    fecIniTrab = dtpFecIniDom.Value.Date.Day + "/" + dtpFecIniDom.Value.Date.Month + "/" + dtpFecFinDom.Value.Date.Year;
                    fecFinTrab = dtpFecFinDom.Value.Date.Day + "/" + dtpFecFinDom.Value.Date.Month + "/" + dtpFecFinDom.Value.Date.Year;
                    if (Valida.existeEmpresa(nitEmp) == 1 && Valida.existeDomiciliario(idDom) == 1) {
                        if (Valida.existeContrato(nitEmp, id, fecIniTrab, fecFinTrab) ==0) {
                            resultadoTrab = this.trabajo.ingresarTrabajo(nitEmp, idDom, fecIniTrab, fecFinTrab);
                            if (resultadoTrab > 0) {
                                Utilidad.mostrarMensajeInformativo("Información Vinculación registrada");
                                txtIdDomEmp.Text = "";
                                txtNitEmpDom.Text = "";
                                dtpFecIniDom.ResetText();
                                dtpFecFinDom.ResetText();
                            }
                        } else {
                            Utilidad.mostrarMensajeError("Información no registrada porque ya existe la vinculación");
                        }
                    } else {
                        Utilidad.mostrarMensajeError("Información no registrada porque no existe nit empresa o id domiciliario");
                    }
                } else {
                    Utilidad.mostrarMensajeError("Dígite una id numerica válida");
                }
            } else {
                Utilidad.mostrarMensajeError("Ninguno de los campos puede quedar vacío");
            }
        }
    }
}