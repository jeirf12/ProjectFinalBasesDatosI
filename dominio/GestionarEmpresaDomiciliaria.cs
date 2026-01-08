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
                !nitEmp.Estalleno()
                || !nomEmp.Estalleno() 
                || !nitCamEmp.Estalleno()
                ) {
                ("Alguno de los campos no puede quedar vacio").MostrarMensajeError();
                return;
            }

            if (nitEmp.ExisteEmpresa() != 0 || nitCamEmp.ExisteCamaraComercio() != 1) {
                ("Información no registrada por duplicidad de nit empresa o no existe nit de camara comercio").MostrarMensajeError();
                return;
            }
            
            resultadoEmp = this.Empresa.IngresarEmpresa(nitEmp, nomEmp, fecOpeEmp, nitCamEmp);
            if (resultadoEmp > 0) {
                ("Información empresa registrada").MostrarMensajeInformativo();
                txtNitEmp.Text = string.Empty;
                txtNomEmp.Text = string.Empty;
                dtpFecOpeEmp.ResetText();
                txtNitCamEmp.Text = string.Empty;
            }
        }

        private void BtnBuscarEmpresa_Click(object sender, EventArgs e) {
            DataSet ds;
            string nitEmp = txtBuscarNitEmp.Text;

            if (!nitEmp.Estalleno()) {
                ("El campo id de la empresa no puede quedar vacio").MostrarMensajeError();
                return;
            }

            ds = this.Empresa.ConsultarEmpresa(nitEmp);
            if (ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0) {
                ("No se encuentra registrada la empresa con ese nit").MostrarMensajeError();
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
                !nomEmp.Estalleno() 
                || !nitCam.Estalleno()
                ) {
                ("Alguno de los campos no puede quedar vacio").MostrarMensajeError();
                return;
            }

            if (
                nitEmp.ExisteEmpresa() != 1 
                || nitCam.ExisteCamaraComercio() != 1
                ) {
                ("Información empresa no actualizada porque no existe la nit empresa o la nit de camara comercio").MostrarMensajeError();
                return;
            }
            resultado = this.Empresa.ActualizarEmpresa(nitEmp, nitCam, nomEmp, fechaOpe);
            if (resultado > 0)
            {
                ("Información empresa actualizada").MostrarMensajeInformativo();
                lbActualizaNitEmp.Text = "~";
                txtActualizaNitCamComercio.Text = string.Empty;
                txtActualizaNomEmp.Text = string.Empty;
                dtpActualizaFecOpeEmpresa.ResetText();
            }
        }

        private void BtnEliminarXnitEmpresa_Click(object sender, EventArgs e) {
            int resultado;
            string nit = txtEliminaXnitEmpresa.Text;
            if (!nit.Estalleno()) {
                ("El campo Digite el nit no puede quedar vacio").MostrarMensajeError();
                return;
            }
            if (nit.ExisteEmpresa() != 1) {
                ("Información empresa domiciliaria no eliminada porque no existe el nit").MostrarMensajeError();
                return;
            }
            resultado = this.Empresa.EliminarEmpresa(nit);
            if (resultado > 0)
                ("Información empresa domiciliaria eliminada").MostrarMensajeInformativo();

            txtEliminaXnitEmpresa.Text = string.Empty;
        }

        private void BtnMostrarEmpresa_Click(object sender, EventArgs e) {
            DataSet ds = this.Empresa.ConsultarEmpresa();

            if (ds.Tables[0].Rows.Count == 0)
            {
                ("No se ha encontrado información sobre la empresas domiciliarias, " +
                    "si cree que es un error; por favor comuniquesé con soporte técnico o el administrador").MostrarMensajeInformativo();
                return;
            }

            dgvEmpresaDomiciliaria.DataSource = ds;
            dgvEmpresaDomiciliaria.DataMember = ds.Tables[0].TableName;
        }
    }
}