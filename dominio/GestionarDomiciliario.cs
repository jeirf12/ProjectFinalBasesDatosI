namespace appRegistroEmpresaDomiciliaria.dominio {

    using System;
    using System.Data;
    using System.Windows.Forms;
    using appRegistroEmpresaDomiciliaria.logica;
    using appRegistroEmpresaDomiciliaria.Utilidades;

    public partial class GestionarDomiciliario : Form {

        private Domiciliario Domiciliario;

        public GestionarDomiciliario() {
            this.InitializeComponent();
            this.Domiciliario = new Domiciliario();
        }
        
        private void BtnGuardaDomiciliario_Click(object sender, EventArgs e) {
            int resultadoDom;
            double idDom;
            string nomDom, apeDom, anioExpDom, estDom = string.Empty;
            
            nomDom = txtNomDom.Text;
            apeDom = txtApeDom.Text;
            if (rbActivo.Checked) 
                estDom = "activo";
            else if (rbInactivo.Checked) 
                estDom = "inactivo";

            if (!txtIdDom.Text.Estalleno()
                || cbxAnioExpDom.SelectedItem is null 
                || !nomDom.Estalleno()
                || !apeDom.Estalleno()
                || !estDom.Estalleno()
                ) {
                ("Ninguno de los campos puede quedar vacío").MostrarMensajeError();
                return;
            }
            
            if (!txtIdDom.Text.EsNumerico()) {
                ("Dígite de nuevo una id válida").MostrarMensajeError();
                return;
            }

            idDom = int.Parse(txtIdDom.Text);
            
            if (idDom <= 0) {
                ("El campo id del domiciliario no puede ser negativa o igual a cero").MostrarMensajeError();
                return;
            }

            if (idDom.ExisteDomiciliario() != 0) {
                ("Información no registrada por duplicidad de id").MostrarMensajeError();
                return;
            }

            anioExpDom = cbxAnioExpDom.SelectedItem.ToString();

            resultadoDom = this.Domiciliario.IngresarDomiciliario(idDom, nomDom, apeDom, anioExpDom, estDom);

            if (resultadoDom > 0) {
                ("Información domiciliario registrada").MostrarMensajeInformativo();
                txtIdDom.Text = string.Empty;
                txtNomDom.Text = string.Empty;
                txtApeDom.Text = string.Empty;
                cbxAnioExpDom.ResetText();
                rbActivo.Checked = false;
                rbInactivo.Checked = false;
            }                  
            
        }

        private void BtnBuscarDomiciliario_Click(object sender, EventArgs e) {
            DataSet ds;
            string estado;
            double id;

            if (!txtBuscarIdDomiciliario.Text.Estalleno()) {
                ("El campo no puede quedar vacío").MostrarMensajeError();
                return;
            }

            if (!txtBuscarIdDomiciliario.Text.EsNumerico()) {
                ("Dígite una id válida").MostrarMensajeError();
                return;
            }
                
            id = int.Parse(txtBuscarIdDomiciliario.Text);
            ds = this.Domiciliario.ConsultarDomiciliario(id);
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                ("No se encuentra registrado el domiciliario con esa id").MostrarMensajeError();
                return;
            }
            
            lbActualizaIdDomiciliario.Text = ds.Tables[0].Rows[0]["DOM_ID"].ToString();
            txtActualizaNomDomiciliario.Text = ds.Tables[0].Rows[0]["DOM_NOMBRE"].ToString();
            txtActualizaApeDomiciliario.Text = ds.Tables[0].Rows[0]["DOM_APELLIDO"].ToString();
            cbxActualizaExpDomiciliario.Text = ds.Tables[0].Rows[0]["DOM_ANIOEXPERIENCIA"].ToString();
            estado = ds.Tables[0].Rows[0]["DOM_ESTADO"].ToString();

            if (estado.Equals("activo")) 
                rbActualizaActivo.Select();
            else if (estado.Equals("inactivo"))
                rbActualizaInactivo.Select();
        }

        private void BtnActualizarDomiciliario_Click(object sender, EventArgs e) {
            int resultado;
            double id;
            string nombre, apellido, experiencia, estado = string.Empty;
            if (rbActualizaActivo.Checked)
                estado = "activo";
            else if (rbActualizaInactivo.Checked)
                estado = "inactivo";

            if (
                !lbActualizaIdDomiciliario.Text.Estalleno()
                || !txtActualizaNomDomiciliario.Text.Estalleno()
                || !txtActualizaApeDomiciliario.Text.Estalleno()
                || cbxActualizaExpDomiciliario.SelectedItem is null
                || !estado.Estalleno()
                ) {
                ("Ninguno de los campos puede quedar vacío").MostrarMensajeError();
                return;
            }
            
            id = int.Parse(lbActualizaIdDomiciliario.Text);

            if (id.ExisteDomiciliario() != 1) {
                ("Información no actualizada porque no se encuentra registrado el domiciliario con esa id").MostrarMensajeError();
                return;
            }

            nombre = txtActualizaNomDomiciliario.Text;
            apellido = txtActualizaApeDomiciliario.Text;
            experiencia = cbxActualizaExpDomiciliario.SelectedItem.ToString();

            resultado = this.Domiciliario.ActualizarDomiciliario(id, nombre, apellido, experiencia, estado);
            if (resultado > 0) {
                ("Información domiciliario actualizada").MostrarMensajeInformativo();
                lbActualizaIdDomiciliario.Text = "~";
                txtActualizaNomDomiciliario.Text = string.Empty;
                txtActualizaApeDomiciliario.Text = string.Empty;
                cbxActualizaExpDomiciliario.ResetText();
                rbActualizaActivo.Checked = false;
                rbActualizaInactivo.Checked = false;
            }
        }

        private void BtnEliminarXidDomiciliario_Click(object sender, EventArgs e) {
            int resultado;
            double id;
            if (!txtEliminaIdDomiciliario.Text.Estalleno()) {
                ("El campo no puede quedar vacío").MostrarMensajeError();
                return;
            }

            if (!txtEliminaIdDomiciliario.Text.EsNumerico()) {
                ("Dígite un valor válido numerico").MostrarMensajeError();
                return;
            }

            id = int.Parse(txtEliminaIdDomiciliario.Text);

            if (id.ExisteDomiciliario() != 1) {
                ("Información domiciliario no eliminada porque no existe el domiciliario con esa id").MostrarMensajeError();
                return;
            }
            
            resultado = this.Domiciliario.EliminarDomiciliario(id);
            if (resultado > 0) {
                ("Información domiciliario eliminada").MostrarMensajeInformativo();
            }
            txtEliminaIdDomiciliario.Text = string.Empty;
        }

        private void BtnConsultarDomiciliario_Click(object sender, EventArgs e) {
            DataSet ds = this.Domiciliario.ConsultarDomiciliario();

            if (ds.Tables[0].Rows.Count == 0)
            {
                ("No se ha encontrado información sobre los domiciliarios, " +
                    "si cree que es un error; por favor comuniquesé con soporte técnico o el administrador").MostrarMensajeInformativo();
                return;
            }

            dgvDomiciliario.DataSource = ds;
            dgvDomiciliario.DataMember = ds.Tables[0].TableName;
        }
    }
}