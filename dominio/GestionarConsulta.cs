namespace appRegistroEmpresaDomiciliaria.dominio {
    
    using System;
    using System.Data;
    using System.Windows.Forms;
    using appRegistroEmpresaDomiciliaria.logica;

    public partial class GestionarConsulta : Form {
        private Trabaja trabajo;

        public GestionarConsulta() {
            this.InitializeComponent();
            this.trabajo = new Trabaja();
        }
        
        private void btnConsultaEmp_Click(object sender, EventArgs e) {
            DataSet ds = this.trabajo.consultaTrabajo();
            
            if (ds.Tables.Count == 0) 
                return;

            dgvDatosEmp.DataSource = ds;
            dgvDatosEmp.DataMember = ds.Tables[0].TableName;
        }

        private void btnConsultaXfecha_Click(object sender, EventArgs e) {
            string fechaIngresada = $"{ dtpConsulFecha.Value.Date.Day } / { dtpConsulFecha.Value.Date.Month } / { dtpConsulFecha.Value.Year}";
            DataSet ds = this.trabajo.consultaTrabajo(fechaIngresada);

            if (ds.Tables.Count == 0) 
                return;

            dgvConsultaXfecha.DataSource = ds;
            dgvConsultaXfecha.DataMember = ds.Tables[0].TableName;
        }

        private void btnDomiciliarioInactivo_Click(object sender, EventArgs e) {
            lbContDomInactivo.Text = $"{ this.trabajo.domiciliariosInactivos() }";
        }
    }
}