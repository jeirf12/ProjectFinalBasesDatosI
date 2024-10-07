namespace appRegistroEmpresaDomiciliaria.dominio {
    
    using System;
    using System.Data;
    using System.Windows.Forms;
    using appRegistroEmpresaDomiciliaria.logica;

    public partial class GestionarConsulta : Form {

        private Trabaja Trabajo;

        public GestionarConsulta() {
            this.InitializeComponent();
            this.Trabajo = new Trabaja();
        }
        
        private void BtnConsultaEmp_Click(object sender, EventArgs e) {
            DataSet ds = this.Trabajo.ConsultaTrabajo();
            
            if (ds.Tables.Count == 0) 
                return;

            dgvDatosEmp.DataSource = ds;
            dgvDatosEmp.DataMember = ds.Tables[0].TableName;
        }

        private void BtnConsultaXfecha_Click(object sender, EventArgs e) {
            string fechaIngresada = $"{ dtpConsulFecha.Value.Date.Day } / { dtpConsulFecha.Value.Date.Month } / { dtpConsulFecha.Value.Year}";
            DataSet ds = this.Trabajo.ConsultaTrabajo(fechaIngresada);

            if (ds.Tables.Count == 0) 
                return;

            dgvConsultaXfecha.DataSource = ds;
            dgvConsultaXfecha.DataMember = ds.Tables[0].TableName;
        }

        private void BtnDomiciliarioInactivo_Click(object sender, EventArgs e) =>
            lbContDomInactivo.Text = $"{ this.Trabajo.DomiciliariosInactivos() }";

    }
}