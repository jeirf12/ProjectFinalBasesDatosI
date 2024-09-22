namespace appRegistroEmpresaDomiciliaria.dominio {

    using System;
    using System.Data;
    using System.Windows.Forms;
    using appRegistroEmpresaDomiciliaria.logica;
    using appRegistroEmpresaDomiciliaria.Utilidades;

    public partial class GestionarEmpresaDomiciliaria : Form {

        private EmpresaDomiciliaria empresa;

        public GestionarEmpresaDomiciliaria() {
            this.InitializeComponent();
            this.empresa = new EmpresaDomiciliaria();
        }

        private void btnGuardarEmpresa_Click(object sender, EventArgs e) {
            int resultadoEmp;
            string nitEmp, nomEmp, fecOpeEmp, nitCamEmp;
            nitEmp = txtNitEmp.Text;
            nomEmp = txtNomEmp.Text;
            fecOpeEmp = $"{dtpFecOpeEmp.Value.Date.Day }/{ dtpFecOpeEmp.Value.Date.Month }/{ dtpFecOpeEmp.Value.Date.Year }";
            nitCamEmp = txtNitCamEmp.Text;

            if (
                !Utilidad.estalleno(nitEmp) 
                || !Utilidad.estalleno(nomEmp) 
                || !Utilidad.estalleno(nitCamEmp)
                ) {
                Utilidad.mostrarMensajeError("Alguno de los campos no puede quedar vacio");
                return;
            }

            if (Valida.existeEmpresa(nitEmp) != 0 || Valida.existeCamaraComercio(nitCamEmp) != 1) {
                Utilidad.mostrarMensajeError("Información no registrada por duplicidad de nit empresa o no existe nit de camara comercio");
                return;
            }
            
            resultadoEmp = this.empresa.ingresarEmpresa(nitEmp, nomEmp, fecOpeEmp, nitCamEmp);
            if (resultadoEmp > 0) {
                Utilidad.mostrarMensajeInformativo("Información empresa registrada");
                txtNitEmp.Text = string.Empty;
                txtNomEmp.Text = string.Empty;
                dtpFecOpeEmp.ResetText();
                txtNitCamEmp.Text = string.Empty;
            }
        }

        private void btnBuscarEmpresa_Click(object sender, EventArgs e) {
            DataSet ds;
            string nitEmp = txtBuscarNitEmp.Text;

            if (!Utilidad.estalleno(nitEmp)) {
                Utilidad.mostrarMensajeError("El campo id de la empresa no puede quedar vacio");
                return;
            }

            ds = this.empresa.consultarEmpresa(nitEmp);
            if (ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0) {
                Utilidad.mostrarMensajeError("No se encuentra registrada la empresa con ese nit");
                return;
            }

            lbActualizaNitEmp.Text = ds.Tables[0].Rows[0]["EMP_NIT"].ToString();
            txtActualizaNomEmp.Text = ds.Tables[0].Rows[0]["EMP_NOMBRE"].ToString();
            dtpActualizaFecOpeEmpresa.Text = ds.Tables[0].Rows[0]["EMP_FECHAOPERAR"].ToString();
            txtActualizaNitCamComercio.Text = ds.Tables[0].Rows[0]["CAM_NIT"].ToString();
            txtBuscarNitEmp.Text = string.Empty;
        }

        private void btnActualizarEmpresa_Click(object sender, EventArgs e) {
            int resultado;
            string nitEmp, nitCam, nomEmp, fechaOpe;
            nitEmp = lbActualizaNitEmp.Text;
            nitCam = txtActualizaNitCamComercio.Text;
            nomEmp = txtActualizaNomEmp.Text;
            fechaOpe = $"{ dtpActualizaFecOpeEmpresa.Value.Date.Day }/{ dtpActualizaFecOpeEmpresa.Value.Date.Month }/{ dtpActualizaFecOpeEmpresa.Value.Date.Year }";
            if (
                !Utilidad.estalleno(nomEmp) 
                || !Utilidad.estalleno(nitCam)
                ) {
                Utilidad.mostrarMensajeError("Alguno de los campos no puede quedar vacio");
                return;
            }

            if (
                Valida.existeEmpresa(nitEmp) != 1 
                || Valida.existeCamaraComercio(nitCam) != 1
                ) {
                Utilidad.mostrarMensajeError("Información empresa no actualizada porque no existe la nit empresa o la nit de camara comercio");
                return;
            }
            resultado = this.empresa.actualizarEmpresa(nitEmp, nitCam, nomEmp, fechaOpe);
            if (resultado > 0)
            {
                Utilidad.mostrarMensajeInformativo("Información empresa actualizada");
                lbActualizaNitEmp.Text = "~";
                txtActualizaNitCamComercio.Text = string.Empty;
                txtActualizaNomEmp.Text = string.Empty;
                dtpActualizaFecOpeEmpresa.ResetText();
            }
        }

        private void btnEliminarXnitEmpresa_Click(object sender, EventArgs e) {
            int resultado;
            string nit = txtEliminaXnitEmpresa.Text;
            if (!Utilidad.estalleno(nit)) {
                Utilidad.mostrarMensajeError("El campo Digite el nit no puede quedar vacio");
                return;
            }
            if (Valida.existeEmpresa(nit) != 1) {
                Utilidad.mostrarMensajeError("Información empresa domiciliaria no eliminada porque no existe el nit");
                return;
            }
            resultado = this.empresa.eliminarEmpresa(nit);
            if (resultado > 0)
                Utilidad.mostrarMensajeInformativo("Información empresa domiciliaria eliminada");

            txtEliminaXnitEmpresa.Text = string.Empty;
        }

        private void btnMostrarEmpresa_Click(object sender, EventArgs e) {
            DataSet ds = this.empresa.consultarEmpresa();

            if (ds.Tables.Count == 0) 
                return;

            dgvEmpresaDomiciliaria.DataSource = ds;
            dgvEmpresaDomiciliaria.DataMember = ds.Tables[0].TableName;
        }
    }
}