namespace appRegistroEmpresaDomiciliaria.dominio {
    
    using System;
    using System.Data;
    using System.Windows.Forms;
    using appRegistroEmpresaDomiciliaria.logica;
    using appRegistroEmpresaDomiciliaria.Utilidades;

    public partial class GestionarConsulta : Form {

        private Trabaja Trabajo;

        public GestionarConsulta() {
            this.InitializeComponent();
            this.Trabajo = new Trabaja();
        }
        
        private void BtnConsultaEmp_Click(object sender, EventArgs e) {
            DataSet ds = this.Trabajo.ConsultaTrabajo();
            
            if (ds.Tables[0].Rows.Count == 0)
            {
                ("No se ha encontrado información sobre el trabajo de los domiciliarios, " +
                    "si cree que es un error; por favor comuniquesé con soporte técnico o el administrador").MostrarMensajeInformativo();
                return;
            }

            dgvDatosEmp.DataSource = ds;
            dgvDatosEmp.DataMember = ds.Tables[0].TableName;
        }

        private void BtnConsultaXfecha_Click(object sender, EventArgs e) {
            string fechaIngresada = $"{ dtpConsulFecha.Value.Date.Day } / { dtpConsulFecha.Value.Date.Month } / { dtpConsulFecha.Value.Year}";
            DataSet ds = this.Trabajo.ConsultaTrabajo(fechaIngresada);

            if (ds.Tables[0].Rows.Count == 0)
            {
                ("No se ha encontrado información de los domiciliarios con esa fecha, " +
                    "si cree que es un error; por favor comuniquesé con soporte técnico o el administrador").MostrarMensajeInformativo();
                return;
            }

            dgvConsultaXfecha.DataSource = ds;
            dgvConsultaXfecha.DataMember = ds.Tables[0].TableName;
        }

        private void BtnDomiciliarioInactivo_Click(object sender, EventArgs e) =>
            lbContDomInactivo.Text = $"{ this.Trabajo.DomiciliariosInactivos() }";

    }
}