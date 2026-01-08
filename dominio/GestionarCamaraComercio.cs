namespace appRegistroEmpresaDomiciliaria.dominio {

    using System;
    using System.Data;
    using System.Windows.Forms;
    using appRegistroEmpresaDomiciliaria.logica;
    using appRegistroEmpresaDomiciliaria.Utilidades;

    public partial class GestionarCamaraComercio : Form {

        private CamaraComercio Camara;

        public GestionarCamaraComercio() {
            this.InitializeComponent();
            this.Camara = new CamaraComercio();
        }

        private void BtnGuardaCamaraComercio_Click(object sender, EventArgs e) {
            int resultadoCam;
            string nitCam, NomCam;
            nitCam = txtNitCam.Text;
            NomCam = txtNomCam.Text;

            if (!nitCam.Estalleno() || !NomCam.Estalleno()) {
                ("Ninguno de los campos puede quedar vacio").MostrarMensajeError();
                return;
            }

            if (nitCam.ExisteCamaraComercio() != 0) {
                ("Información no registrada por duplicidad de nit").MostrarMensajeError();
                return;
            }
            
            resultadoCam = this.Camara.IngresarCamaraComercio(nitCam, NomCam);
            
            if (resultadoCam > 0) {
                ("Información Camara Comercio registrada").MostrarMensajeInformativo();
                txtNitCam.Text = string.Empty;
                txtNomCam.Text = string.Empty;
            }    
        }

        private void BtnMostrarCamaraComercio_Click(object sender, EventArgs e) {
            DataSet ds = this.Camara.ConsultarCamaraComercio();

            if (ds.Tables[0].Rows.Count == 0)
            {
                ("No se ha encontrado información sobre las camaras de comercio, " +
                    "si cree que es un error; por favor comuniquesé con soporte técnico o el administrador").MostrarMensajeInformativo();
                return;
            }

            dgvCamaraComercio.DataSource = ds;
            dgvCamaraComercio.DataMember = ds.Tables[0].TableName;
        }
    }
}