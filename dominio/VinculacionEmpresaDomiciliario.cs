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
using appRegistroEmpresaDomiciliaria.acessoDatos;

namespace appRegistroEmpresaDomiciliaria.dominio
{
    public partial class VinculacionEmpresaDomiciliario : Form
    {
        public VinculacionEmpresaDomiciliario()
        {
            InitializeComponent();
        }
        private Trabaja trab = new Trabaja();
        
        private void btnRegistraVinculacion_Click(object sender, EventArgs e)
        {
            int resultadoTrab;
            double idDom;
            string nitEmp, fecIniTrab, fecFinTrab, id = "";
            if (Valida.estalleno(txtNitEmpDom.Text) && Valida.estalleno(txtIdDomEmp.Text))
            {
                if (Valida.esNumerico(txtIdDomEmp.Text))
                {
                    idDom = int.Parse(txtIdDomEmp.Text);
                    id += idDom;
                    nitEmp = txtNitEmpDom.Text;
                    fecIniTrab = dtpFecIniDom.Value.Date.Day + "/" + dtpFecIniDom.Value.Date.Month + "/" + dtpFecFinDom.Value.Date.Year;
                    fecFinTrab = dtpFecFinDom.Value.Date.Day + "/" + dtpFecFinDom.Value.Date.Month + "/" + dtpFecFinDom.Value.Date.Year;
                    if (Valida.existeEmpresa(nitEmp) == 1 && Valida.existeDomiciliario(idDom) == 1)
                    {
                        if (Valida.existeContrato(nitEmp, id, fecIniTrab, fecFinTrab) ==0)
                        {
                            resultadoTrab = trab.ingresarTrabajo(nitEmp, idDom, fecIniTrab, fecFinTrab);
                            if (resultadoTrab > 0)
                            {
                                MessageBox.Show("Información Vinculación registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtIdDomEmp.Text = "";
                                txtNitEmpDom.Text = "";
                                dtpFecIniDom.ResetText();
                                dtpFecFinDom.ResetText();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Información no registrada porque ya existe la vinculación", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Información no registrada porque no existe nit empresa o id domiciliario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dígite una id numerica válida","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ninguno de los campos puede quedar vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
