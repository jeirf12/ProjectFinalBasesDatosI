using System;
using System.Data;
using System.Windows.Forms;
using appRegistroEmpresaDomiciliaria.logica;
using appRegistroEmpresaDomiciliaria.Utilidades;

namespace appRegistroEmpresaDomiciliaria.dominio {
    public partial class GestionarCamaraComercio : Form {
        private CamaraComercio camara;

        public GestionarCamaraComercio() {
            this.InitializeComponent();
            this.camara = new CamaraComercio();
        }

        private void btnGuardaCamaraComercio_Click(object sender, EventArgs e) {
            int resultadoCam;
            string nitCam, NomCam;
            nitCam = txtNitCam.Text;
            NomCam = txtNomCam.Text;
            if (Utilidad.estalleno(nitCam) && Utilidad.estalleno(NomCam)) {
                if (Valida.existeCamaraComercio(nitCam) == 0) {
                    resultadoCam = this.camara.ingresarCamaraComercio(nitCam, NomCam);
                    if (resultadoCam > 0) {
                        Utilidad.mostrarMensajeInformativo("Información Camara Comercio registrada");
                        txtNitCam.Text = "";
                        txtNomCam.Text = "";
                    }
                } else {
                    Utilidad.mostrarMensajeError("Información no registrada por duplicidad de nit");
                }
            } else {
                Utilidad.mostrarMensajeError("Ninguno de los campos puede quedar vacio");
            }
        }

        private void btnMostrarCamaraComercio_Click(object sender, EventArgs e) {
            DataSet ds = this.camara.consultarCamaraComercio();

            if (ds.Tables.Count == 0) return;

            dgvCamaraComercio.DataSource = ds;
            dgvCamaraComercio.DataMember = ds.Tables[0].TableName;
        }
    }
}