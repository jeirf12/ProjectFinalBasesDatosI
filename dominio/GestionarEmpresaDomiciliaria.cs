namespace appRegistroEmpresaDomiciliaria.dominio {

    using System;
    using System.Data;
    using System.Windows.Forms;
    using appRegistroEmpresaDomiciliaria.logica;
    using appRegistroEmpresaDomiciliaria.Utilidades;

    public partial class GestionarEmpresaDomiciliaria : Form {

        private EmpresaDomiciliaria Empresa;

        public GestionarEmpresaDomiciliaria() {
            this.InitializeComponent();
            this.Empresa = new EmpresaDomiciliaria();
        }

        private void BtnGuardarEmpresa_Click(object sender, EventArgs e) {
            int resultadoEmp;
            string nitEmp, nomEmp, fecOpeEmp, nitCamEmp;
            nitEmp = txtNitEmp.Text;
            nomEmp = txtNomEmp.Text;
            fecOpeEmp = $"{dtpFecOpeEmp.Value.Date.Day }/{ dtpFecOpeEmp.Value.Date.Month }/{ dtpFecOpeEmp.Value.Date.Year }";
            nitCamEmp = txtNitCamEmp.Text;

            if (
                !Utilidad.Estalleno(nitEmp) 
                || !Utilidad.Estalleno(nomEmp) 
                || !Utilidad.Estalleno(nitCamEmp)
                ) {
                Utilidad.MostrarMensajeError("Alguno de los campos no puede quedar vacio");
                return;
            }

            if (Valida.ExisteEmpresa(nitEmp) != 0 || Valida.ExisteCamaraComercio(nitCamEmp) != 1) {
                Utilidad.MostrarMensajeError("Información no registrada por duplicidad de nit empresa o no existe nit de camara comercio");
                return;
            }
            
            resultadoEmp = this.Empresa.IngresarEmpresa(nitEmp, nomEmp, fecOpeEmp, nitCamEmp);
            if (resultadoEmp > 0) {
                Utilidad.MostrarMensajeInformativo("Información empresa registrada");
                txtNitEmp.Text = string.Empty;
                txtNomEmp.Text = string.Empty;
                dtpFecOpeEmp.ResetText();
                txtNitCamEmp.Text = string.Empty;
            }
        }

        private void BtnBuscarEmpresa_Click(object sender, EventArgs e) {
            DataSet ds;
            string nitEmp = txtBuscarNitEmp.Text;

            if (!Utilidad.Estalleno(nitEmp)) {
                Utilidad.MostrarMensajeError("El campo id de la empresa no puede quedar vacio");
                return;
            }

            ds = this.Empresa.ConsultarEmpresa(nitEmp);
            if (ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0) {
                Utilidad.MostrarMensajeError("No se encuentra registrada la empresa con ese nit");
                return;
            }

            lbActualizaNitEmp.Text = ds.Tables[0].Rows[0]["EMP_NIT"].ToString();
            txtActualizaNomEmp.Text = ds.Tables[0].Rows[0]["EMP_NOMBRE"].ToString();
            dtpActualizaFecOpeEmpresa.Text = ds.Tables[0].Rows[0]["EMP_FECHAOPERAR"].ToString();
            txtActualizaNitCamComercio.Text = ds.Tables[0].Rows[0]["CAM_NIT"].ToString();
            txtBuscarNitEmp.Text = string.Empty;
        }

        private void BtnActualizarEmpresa_Click(object sender, EventArgs e) {
            int resultado;
            string nitEmp, nitCam, nomEmp, fechaOpe;
            nitEmp = lbActualizaNitEmp.Text;
            nitCam = txtActualizaNitCamComercio.Text;
            nomEmp = txtActualizaNomEmp.Text;
            fechaOpe = $"{ dtpActualizaFecOpeEmpresa.Value.Date.Day }/{ dtpActualizaFecOpeEmpresa.Value.Date.Month }/{ dtpActualizaFecOpeEmpresa.Value.Date.Year }";
            if (
                !Utilidad.Estalleno(nomEmp) 
                || !Utilidad.Estalleno(nitCam)
                ) {
                Utilidad.MostrarMensajeError("Alguno de los campos no puede quedar vacio");
                return;
            }

            if (
                Valida.ExisteEmpresa(nitEmp) != 1 
                || Valida.ExisteCamaraComercio(nitCam) != 1
                ) {
                Utilidad.MostrarMensajeError("Información empresa no actualizada porque no existe la nit empresa o la nit de camara comercio");
                return;
            }
            resultado = this.Empresa.ActualizarEmpresa(nitEmp, nitCam, nomEmp, fechaOpe);
            if (resultado > 0)
            {
                Utilidad.MostrarMensajeInformativo("Información empresa actualizada");
                lbActualizaNitEmp.Text = "~";
                txtActualizaNitCamComercio.Text = string.Empty;
                txtActualizaNomEmp.Text = string.Empty;
                dtpActualizaFecOpeEmpresa.ResetText();
            }
        }

        private void BtnEliminarXnitEmpresa_Click(object sender, EventArgs e) {
            int resultado;
            string nit = txtEliminaXnitEmpresa.Text;
            if (!Utilidad.Estalleno(nit)) {
                Utilidad.MostrarMensajeError("El campo Digite el nit no puede quedar vacio");
                return;
            }
            if (Valida.ExisteEmpresa(nit) != 1) {
                Utilidad.MostrarMensajeError("Información empresa domiciliaria no eliminada porque no existe el nit");
                return;
            }
            resultado = this.Empresa.EliminarEmpresa(nit);
            if (resultado > 0)
                Utilidad.MostrarMensajeInformativo("Información empresa domiciliaria eliminada");

            txtEliminaXnitEmpresa.Text = string.Empty;
        }

        private void BtnMostrarEmpresa_Click(object sender, EventArgs e) {
            DataSet ds = this.Empresa.ConsultarEmpresa();

            if (ds.Tables.Count == 0) 
                return;

            dgvEmpresaDomiciliaria.DataSource = ds;
            dgvEmpresaDomiciliaria.DataMember = ds.Tables[0].TableName;
        }
    }
}