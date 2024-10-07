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

            if (!Utilidad.Estalleno(txtIdDom.Text) 
                || cbxAnioExpDom.SelectedItem == null 
                || !Utilidad.Estalleno(nomDom) 
                || !Utilidad.Estalleno(apeDom) 
                || !Utilidad.Estalleno(estDom)
                ) {
                Utilidad.MostrarMensajeError("Ninguno de los campos puede quedar vacío");
                return;
            }
            
            if (!Utilidad.EsNumerico(txtIdDom.Text)) {
                Utilidad.MostrarMensajeError("Dígite de nuevo una id válida");
                return;
            }

            idDom = int.Parse(txtIdDom.Text);
            
            if (idDom <= 0) {
                Utilidad.MostrarMensajeError("El campo id del domiciliario no puede ser negativa o igual a cero");
                return;
            }
            
            if (Valida.ExisteDomiciliario(idDom) != 0) {
                Utilidad.MostrarMensajeError("Información no registrada por duplicidad de id");
                return;
            }

            anioExpDom = cbxAnioExpDom.SelectedItem.ToString();

            resultadoDom = this.Domiciliario.IngresarDomiciliario(idDom, nomDom, apeDom, anioExpDom, estDom);

            if (resultadoDom > 0) {
                Utilidad.MostrarMensajeInformativo("Información domiciliario registrada");
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

            if (!Utilidad.Estalleno(txtBuscarIdDomiciliario.Text)) {
                Utilidad.MostrarMensajeError("El campo no puede quedar vacío");
                return;
            }
            
            if (!Utilidad.EsNumerico(txtBuscarIdDomiciliario.Text)) {
                Utilidad.MostrarMensajeError("Dígite una id válida");
                return;
            }
                
            id = int.Parse(txtBuscarIdDomiciliario.Text);
            ds = this.Domiciliario.ConsultarDomiciliario(id);
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                Utilidad.MostrarMensajeError("No se encuentra registrado el domiciliario con esa id");
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
                !Utilidad.Estalleno(lbActualizaIdDomiciliario.Text)
                || !Utilidad.Estalleno(txtActualizaNomDomiciliario.Text)
                || !Utilidad.Estalleno(txtActualizaApeDomiciliario.Text)
                || cbxActualizaExpDomiciliario.SelectedItem == null
                || !Utilidad.Estalleno(estado)
                ) {
                Utilidad.MostrarMensajeError("Ninguno de los campos puede quedar vacío");
                return;
            }
            
            id = int.Parse(lbActualizaIdDomiciliario.Text);

            if (Valida.ExisteDomiciliario(id) != 1) {
                Utilidad.MostrarMensajeError("Información no actualizada porque no se encuentra registrado el domiciliario con esa id");
                return;
            }

            nombre = txtActualizaNomDomiciliario.Text;
            apellido = txtActualizaApeDomiciliario.Text;
            experiencia = cbxActualizaExpDomiciliario.SelectedItem.ToString();

            resultado = this.Domiciliario.ActualizarDomiciliario(id, nombre, apellido, experiencia, estado);
            if (resultado > 0) {
                Utilidad.MostrarMensajeInformativo("Información domiciliario actualizada");
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
            if (!Utilidad.Estalleno(txtEliminaIdDomiciliario.Text)) {
                Utilidad.MostrarMensajeError("El campo no puede quedar vacío");
                return;
            }

            if (!Utilidad.EsNumerico(txtEliminaIdDomiciliario.Text)) {
                Utilidad.MostrarMensajeError("Dígite un valor válido numerico");
                return;
            }

            id = int.Parse(txtEliminaIdDomiciliario.Text);
            
            if (Valida.ExisteDomiciliario(id) != 1) {
                Utilidad.MostrarMensajeError("Información domiciliario no eliminada porque no existe el domiciliario con esa id");
                return;
            }
            
            resultado = this.Domiciliario.EliminarDomiciliario(id);
            if (resultado > 0) {
                Utilidad.MostrarMensajeInformativo("Información domiciliario eliminada");
            }
            txtEliminaIdDomiciliario.Text = string.Empty;
        }

        private void BtnConsultarDomiciliario_Click(object sender, EventArgs e) {
            DataSet ds = this.Domiciliario.ConsultarDomiciliario();

            if (ds.Tables.Count == 0) 
                return;

            dgvDomiciliario.DataSource = ds;
            dgvDomiciliario.DataMember = ds.Tables[0].TableName;
        }
    }
}