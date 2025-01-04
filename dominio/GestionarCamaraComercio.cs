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

            if (!Utilidad.Estalleno(nitCam) || !Utilidad.Estalleno(NomCam)) {
                Utilidad.MostrarMensajeError("Ninguno de los campos puede quedar vacio");
                return;
            }

            if (Valida.ExisteCamaraComercio(nitCam) != 0) {
                Utilidad.MostrarMensajeError("Información no registrada por duplicidad de nit");
                return;
            }
            
            resultadoCam = this.Camara.IngresarCamaraComercio(nitCam, NomCam);
            
            if (resultadoCam > 0) {
                Utilidad.MostrarMensajeInformativo("Información Camara Comercio registrada");
                txtNitCam.Text = string.Empty;
                txtNomCam.Text = string.Empty;
            }    
        }

        private void BtnMostrarCamaraComercio_Click(object sender, EventArgs e) {
            DataSet ds = this.Camara.ConsultarCamaraComercio();

            if (ds.Tables[0].Rows.Count == 0)
            {
                Utilidad.MostrarMensajeInformativo("No se ha encontrado información sobre las camaras de comercio, " +
                    "si cree que es un error; por favor comuniquesé con soporte técnico o el administrador");
                return;
            }

            dgvCamaraComercio.DataSource = ds;
            dgvCamaraComercio.DataMember = ds.Tables[0].TableName;
        }
    }
}