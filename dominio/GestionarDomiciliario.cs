using System;
using System.Data;
using System.Windows.Forms;
using appRegistroEmpresaDomiciliaria.logica;
using appRegistroEmpresaDomiciliaria.Utilidades;

namespace appRegistroEmpresaDomiciliaria.dominio {
    public partial class GestionarDomiciliario : Form {
        private Domiciliario domiciliario;

        public GestionarDomiciliario() {
            this.InitializeComponent();
            this.domiciliario = new Domiciliario();
        }
        
        private void btnGuardaDomiciliario_Click(object sender, EventArgs e) {
            int resultadoDom;
            double idDom;
            string nomDom, apeDom, anioExpDom, estDom = "";
            
            nomDom = txtNomDom.Text;
            apeDom = txtApeDom.Text;
            if (rbActivo.Checked) estDom = "activo";
            else if (rbInactivo.Checked) estDom = "inactivo";

            if (Utilidad.estalleno(txtIdDom.Text) && cbxAnioExpDom.SelectedItem != null && Utilidad.estalleno(nomDom) && Utilidad.estalleno(apeDom) && Utilidad.estalleno(estDom)) {
                anioExpDom = cbxAnioExpDom.SelectedItem.ToString();
                if (Utilidad.esNumerico(txtIdDom.Text)) {
                    idDom = int.Parse(txtIdDom.Text);
                    if (idDom > 0) {
                        if (Valida.existeDomiciliario(idDom) == 0) {
                            resultadoDom = this.domiciliario.ingresarDomiciliario(idDom, nomDom, apeDom, anioExpDom, estDom);
                            if (resultadoDom > 0) {
                                Utilidad.mostrarMensajeInformativo("Información domiciliario registrada");
                                txtIdDom.Text = "";
                                txtNomDom.Text = "";
                                txtApeDom.Text = "";
                                cbxAnioExpDom.ResetText();
                                rbActivo.Checked = false;
                                rbInactivo.Checked = false;
                            }
                        } else {
                            Utilidad.mostrarMensajeError("Información no registrada por duplicidad de id");
                        }
                    } else {
                        Utilidad.mostrarMensajeError("Información no registrada por la id negativa");
                    }
                } else {
                    Utilidad.mostrarMensajeError("Dígite de nuevo una id válida");
                }
                txtIdDom.Text = "";
            } else {
                Utilidad.mostrarMensajeError("Ninguno de los campos puede quedar vacío");
            }
        }

        private void btnBuscarDomiciliario_Click(object sender, EventArgs e) {
            DataSet ds;
            string estado;
            double id;
            if (Utilidad.estalleno(txtBuscarIdDomiciliario.Text)) {
                if (Utilidad.esNumerico(txtBuscarIdDomiciliario.Text)) {
                    id = int.Parse(txtBuscarIdDomiciliario.Text);
                    ds = this.domiciliario.consultarDomiciliario(id);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                        lbActualizaIdDomiciliario.Text = ds.Tables[0].Rows[0]["DOM_ID"].ToString();
                        txtActualizaNomDomiciliario.Text = ds.Tables[0].Rows[0]["DOM_NOMBRE"].ToString();
                        txtActualizaApeDomiciliario.Text = ds.Tables[0].Rows[0]["DOM_APELLIDO"].ToString();
                        cbxActualizaExpDomiciliario.Text = ds.Tables[0].Rows[0]["DOM_ANIOEXPERIENCIA"].ToString();
                        estado = ds.Tables[0].Rows[0]["DOM_ESTADO"].ToString();
                        if (estado.Equals("activo")) {
                            rbActualizaActivo.Select();
                        } else if (estado.Equals("inactivo")) {
                            rbActualizaInactivo.Select();
                        }
                    } else {
                        Utilidad.mostrarMensajeError("No se encuentra registrado el domiciliario con esa id");
                    }
                } else {
                    Utilidad.mostrarMensajeError("Dígite una id válida");
                }
                txtBuscarIdDomiciliario.Text = "";
            } else {
                Utilidad.mostrarMensajeError("El campo no puede quedar vacío");
            }
        }

        private void btnActualizarDomiciliario_Click(object sender, EventArgs e) {
            int resultado;
            double id;
            string nombre, apellido, experiencia, estado = "";
            if (rbActualizaActivo.Checked) {
                estado = "activo";
            } else if (rbActualizaInactivo.Checked) {
                estado = "inactivo";
            }
            if (Utilidad.estalleno(lbActualizaIdDomiciliario.Text) && Utilidad.estalleno(txtActualizaNomDomiciliario.Text) && Utilidad.estalleno(txtActualizaApeDomiciliario.Text) && cbxActualizaExpDomiciliario.SelectedItem != null && Utilidad.estalleno(estado)) {
                id = int.Parse(lbActualizaIdDomiciliario.Text);
                nombre = txtActualizaNomDomiciliario.Text;
                apellido = txtActualizaApeDomiciliario.Text;
                experiencia = cbxActualizaExpDomiciliario.SelectedItem.ToString();
                if (Valida.existeDomiciliario(id) == 1) {
                    resultado = this.domiciliario.actualizarDomiciliario(id, nombre, apellido, experiencia, estado);
                    if (resultado > 0) {
                        Utilidad.mostrarMensajeInformativo("Información domiciliario actualizada");
                        lbActualizaIdDomiciliario.Text = "~";
                        txtActualizaNomDomiciliario.Text = "";
                        txtActualizaApeDomiciliario.Text = "";
                        cbxActualizaExpDomiciliario.ResetText();
                        rbActualizaActivo.Checked = false;
                        rbActualizaInactivo.Checked = false;
                    }
                } else {
                    Utilidad.mostrarMensajeError("Información no actualizada porque no se encuentra registrado el domiciliario con esa id");
                }
            } else {
                Utilidad.mostrarMensajeError("Ninguno de los campos puede quedar vacío");
            }
        }

        private void btnEliminarXidDomiciliario_Click(object sender, EventArgs e) {
            int resultado;
            double id;
            if (Utilidad.estalleno(txtEliminaIdDomiciliario.Text)) {
                if (Utilidad.esNumerico(txtEliminaIdDomiciliario.Text)) {
                    id = int.Parse(txtEliminaIdDomiciliario.Text);
                    if (Valida.existeDomiciliario(id) == 1) {
                        resultado = this.domiciliario.eliminarDomiciliario(id);
                        if (resultado > 0) {
                            Utilidad.mostrarMensajeInformativo("Información domiciliario eliminada");
                        }
                    } else {
                        Utilidad.mostrarMensajeError("Información domiciliario no eliminada porque no existe el domiciliario con esa id");
                    }
                } else {
                    Utilidad.mostrarMensajeError("Dígite un valor válido numerico");
                }
            } else {
                Utilidad.mostrarMensajeError("El campo no puede quedar vacío");
            }
            txtEliminaIdDomiciliario.Text = "";
        }

        private void btnConsultarDomiciliario_Click(object sender, EventArgs e) {
            DataSet ds = this.domiciliario.consultarDomiciliario();

            if (ds.Tables.Count == 0) return;

            dgvDomiciliario.DataSource = ds;
            dgvDomiciliario.DataMember = ds.Tables[0].TableName;
        }
    }
}