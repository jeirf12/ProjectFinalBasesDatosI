using System;
using System.Windows.Forms;
using appRegistroEmpresaDomiciliaria.logica;

namespace appRegistroEmpresaDomiciliaria.dominio {
    public partial class GestionarConsulta : Form {
        private Trabaja trabajo;

        public GestionarConsulta() {
            this.InitializeComponent();
            this.trabajo = new Trabaja();
        }
        
        private void btnConsultaEmp_Click(object sender, EventArgs e) {
            dgvDatosEmp.DataSource = this.trabajo.consultaTrabajo();
            dgvDatosEmp.DataMember = "ResultadoDatos";
        }

        private void btnConsultaXfecha_Click(object sender, EventArgs e) {
            string fechaIngresada = dtpConsulFecha.Value.Date.Day + " / " + dtpConsulFecha.Value.Date.Month + " / " + dtpConsulFecha.Value.Year;
            dgvConsultaXfecha.DataSource = this.trabajo.consultaTrabajo(fechaIngresada);
            dgvConsultaXfecha.DataMember = "ResultadoDatos";
        }

        private void btnDomiciliarioInactivo_Click(object sender, EventArgs e) {
            lbContDomInactivo.Text = "" + this.trabajo.domiciliariosInactivos();
        }
    }
}