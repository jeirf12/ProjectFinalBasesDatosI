namespace appRegistroEmpresaDomiciliaria.dominio {

    using System;
    using System.Windows.Forms;

    public partial class Principal : Form {

        public Principal() {
            this.InitializeComponent();
        }

        private void BtnGestionarCamara_Click(object sender, EventArgs e) {
            GestionarCamaraComercio varGestionCamaraComercio = new GestionarCamaraComercio();
            varGestionCamaraComercio.Show();
        }

        private void BtnGestionarEmpresa_Click(object sender, EventArgs e) {
            GestionarEmpresaDomiciliaria varGestionEmpresaDomiciliaria = new GestionarEmpresaDomiciliaria();
            varGestionEmpresaDomiciliaria.Show();
        }

        private void BntGestionarDomiciliario_Click(object sender, EventArgs e) {
            GestionarDomiciliario varGestionDomiciliario = new GestionarDomiciliario();
            varGestionDomiciliario.Show();
        }

        private void BtnVinculacionEmpresa_Click(object sender, EventArgs e) {
            VinculacionEmpresaDomiciliario varVinculaEmpresaDomiciliario = new VinculacionEmpresaDomiciliario();
            varVinculaEmpresaDomiciliario.Show();
        }

        private void BtnConsulta_Click(object sender, EventArgs e) {
            GestionarConsulta varGestionConsulta = new GestionarConsulta();
            varGestionConsulta.Show();
        }
    }
}