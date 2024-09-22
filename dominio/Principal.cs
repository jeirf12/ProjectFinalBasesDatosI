namespace appRegistroEmpresaDomiciliaria.dominio {

    using System;
    using System.Windows.Forms;

    public partial class Principal : Form {

        public Principal() {
            this.InitializeComponent();
        }

        private void btnGestionarCamara_Click(object sender, EventArgs e) {
            GestionarCamaraComercio varGestionCamaraComercio = new GestionarCamaraComercio();
            varGestionCamaraComercio.Show();
        }

        private void btnGestionarEmpresa_Click(object sender, EventArgs e) {
            GestionarEmpresaDomiciliaria varGestionEmpresaDomiciliaria = new GestionarEmpresaDomiciliaria();
            varGestionEmpresaDomiciliaria.Show();
        }

        private void bntGestionarDomiciliario_Click(object sender, EventArgs e) {
            GestionarDomiciliario varGestionDomiciliario = new GestionarDomiciliario();
            varGestionDomiciliario.Show();
        }

        private void btnVinculacionEmpresa_Click(object sender, EventArgs e) {
            VinculacionEmpresaDomiciliario varVinculaEmpresaDomiciliario = new VinculacionEmpresaDomiciliario();
            varVinculaEmpresaDomiciliario.Show();
        }

        private void btnConsulta_Click(object sender, EventArgs e) {
            GestionarConsulta varGestionConsulta = new GestionarConsulta();
            varGestionConsulta.Show();
        }
    }
}