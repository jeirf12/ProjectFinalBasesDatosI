using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appRegistroEmpresaDomiciliaria.logica;

namespace appRegistroEmpresaDomiciliaria.dominio
{
    public partial class GestionarDomiciliario : Form
    {
        public GestionarDomiciliario()
        {
            InitializeComponent();
        }
        private Domiciliario dom = new Domiciliario();
        private void btnGuardaDomiciliario_Click(object sender, EventArgs e)
        {
            int resultadoDom;
            double idDom;
            string nomDom, apeDom, anioExpDom, estDom = "";
            
            nomDom = txtNomDom.Text;
            apeDom = txtApeDom.Text;
            if (rbActivo.Checked)
            {
                estDom = "activo";
            }
            else if (rbInactivo.Checked)
            {
                estDom = "inactivo";
            }
            if (Valida.estalleno(txtIdDom.Text) && cbxAnioExpDom.SelectedItem!=null && Valida.estalleno(nomDom) && Valida.estalleno(apeDom) && Valida.estalleno(estDom))
            {
                anioExpDom = cbxAnioExpDom.SelectedItem.ToString();
                if (Valida.esNumerico(txtIdDom.Text))
                {
                    idDom = int.Parse(txtIdDom.Text);
                    if (idDom > 0)
                    {
                        if (Valida.existeDomiciliario(idDom) == 0)
                        {
                            resultadoDom = dom.ingresarDomiciliario(idDom, nomDom, apeDom, anioExpDom, estDom);
                            if (resultadoDom > 0)
                            {
                                MessageBox.Show("Información domiciliario registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtIdDom.Text = "";
                                txtNomDom.Text = "";
                                txtApeDom.Text = "";
                                cbxAnioExpDom.ResetText();
                                rbActivo.Checked = false;
                                rbInactivo.Checked = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Información no registrada por duplicidad de id", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Información no registrada por la id negativa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dígite de nuevo una id válida", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtIdDom.Text = "";
            }
            else
            {
                MessageBox.Show("Ninguno de los campos puede quedar vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnBuscarDomiciliario_Click(object sender, EventArgs e)
        {
            DataSet ds;
            string estado;
            double id;
            if (Valida.estalleno(txtBuscarIdDomiciliario.Text))
            {
                if (Valida.esNumerico(txtBuscarIdDomiciliario.Text))
                {
                    id = int.Parse(txtBuscarIdDomiciliario.Text);
                    ds = dom.consultarDomiciliario(id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lbActualizaIdDomiciliario.Text = ds.Tables[0].Rows[0]["DOM_ID"].ToString();
                        txtActualizaNomDomiciliario.Text = ds.Tables[0].Rows[0]["DOM_NOMBRE"].ToString();
                        txtActualizaApeDomiciliario.Text = ds.Tables[0].Rows[0]["DOM_APELLIDO"].ToString();
                        cbxActualizaExpDomiciliario.Text = ds.Tables[0].Rows[0]["DOM_ANIOEXPERIENCIA"].ToString();
                        estado = ds.Tables[0].Rows[0]["DOM_ESTADO"].ToString();
                        if (estado.Equals("activo"))
                        {
                            rbActualizaActivo.Select();
                        }
                        else if (estado.Equals("inactivo"))
                        {
                            rbActualizaInactivo.Select();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encuentra registrado el domiciliario con esa id", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dígite una id válida", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtBuscarIdDomiciliario.Text = "";
            }
            else
            {
                MessageBox.Show("El campo no puede quedar vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnActualizarDomiciliario_Click(object sender, EventArgs e)
        {
            int resultado;
            double id;
            string nombre, apellido, experiencia, estado = "";
            if (rbActualizaActivo.Checked)
            {
                estado = "activo";
            }
            else if (rbActualizaInactivo.Checked)
            {
                estado = "inactivo";
            }
            if (Valida.estalleno(lbActualizaIdDomiciliario.Text) && Valida.estalleno(txtActualizaNomDomiciliario.Text) && Valida.estalleno(txtActualizaApeDomiciliario.Text) && cbxActualizaExpDomiciliario.SelectedItem!=null && Valida.estalleno(estado))
            {
                id = int.Parse(lbActualizaIdDomiciliario.Text);
                nombre = txtActualizaNomDomiciliario.Text;
                apellido = txtActualizaApeDomiciliario.Text;
                experiencia = cbxActualizaExpDomiciliario.SelectedItem.ToString();
                /*El metodo buscar valida que el id del domiciliario exista, para poder actualizar, si no
                     * lo encuentra lanza un messabox explicando al usuario que no en verdad no existe*/
                if (Valida.existeDomiciliario(id)== 1)
                {
                    resultado = dom.actualizarDomiciliario(id, nombre, apellido, experiencia, estado);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Información domiciliario actualizada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbActualizaIdDomiciliario.Text = "~";
                        txtActualizaNomDomiciliario.Text = "";
                        txtActualizaApeDomiciliario.Text = "";
                        cbxActualizaExpDomiciliario.ResetText();
                        rbActualizaActivo.Checked = false;
                        rbActualizaInactivo.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("Información no actualizada porque no se encuentra registrado el domiciliario con esa id", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ninguno de los campos puede quedar vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnEliminarXidDomiciliario_Click(object sender, EventArgs e)
        {
            int resultado;
            double id;
            if (Valida.estalleno(txtEliminaIdDomiciliario.Text))
            {
                if (Valida.esNumerico(txtEliminaIdDomiciliario.Text))
                {
                    id = int.Parse(txtEliminaIdDomiciliario.Text);
                    if (Valida.existeDomiciliario(id) == 1)
                    {
                        resultado = dom.eliminarDomiciliario(id);
                        if (resultado > 0)
                        {
                            MessageBox.Show("Información domiciliario eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Información domiciliario no eliminada porque no existe el domiciliario con esa id", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dígite un valor válido numerico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El campo no puede quedar vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtEliminaIdDomiciliario.Text = "";
        }

        private void btnConsultarDomiciliario_Click(object sender, EventArgs e)
        {
            dgvDomiciliario.DataSource = dom.consultarDomiciliario();
            dgvDomiciliario.DataMember = "ResultadoDatos";
        }
    }
}
