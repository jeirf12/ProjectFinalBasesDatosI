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
    public partial class GestionarEmpresaDomiciliaria : Form
    {
        public GestionarEmpresaDomiciliaria()
        {
            InitializeComponent();
        }
        private EmpresaDomiciliaria empresa = new EmpresaDomiciliaria();

        private void btnGuardarEmpresa_Click(object sender, EventArgs e)
        {
            int resultadoEmp;
            string nitEmp, nomEmp, fecOpeEmp, nitCamEmp;
            nitEmp = txtNitEmp.Text;
            nomEmp = txtNomEmp.Text;
            fecOpeEmp = dtpFecOpeEmp.Value.Date.Day + "/" + dtpFecOpeEmp.Value.Date.Month + "/" + dtpFecOpeEmp.Value.Date.Year;
            nitCamEmp = txtNitCamEmp.Text;
            if (Valida.estalleno(nitEmp) && Valida.estalleno(nomEmp) && Valida.estalleno(nitCamEmp))
            {
                if (Valida.existeEmpresa(nitEmp) == 0 && Valida.existeCamaraComercio(nitCamEmp)== 1)
                {
                    resultadoEmp = empresa.ingresarEmpresa(nitEmp, nomEmp, fecOpeEmp, nitCamEmp);
                    if (resultadoEmp > 0)
                    {
                        MessageBox.Show("Información empresa registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNitEmp.Text = "";
                        txtNomEmp.Text = "";
                        dtpFecOpeEmp.ResetText();
                        txtNitCamEmp.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Información no registrada por duplicidad de nit empresa o no existe nit de camara comercio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Alguno de los campos no puede quedar vacio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnBuscarEmpresa_Click(object sender, EventArgs e)
        {
            DataSet ds;
            string nitEmp = txtBuscarNitEmp.Text;
            if (Valida.estalleno(nitEmp))
            {
                ds = empresa.consultarEmpresa(nitEmp);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbActualizaNitEmp.Text = ds.Tables[0].Rows[0]["EMP_NIT"].ToString();
                    txtActualizaNomEmp.Text = ds.Tables[0].Rows[0]["EMP_NOMBRE"].ToString();
                    dtpActualizaFecOpeEmpresa.Text = ds.Tables[0].Rows[0]["EMP_FECHAOPERAR"].ToString();
                    txtActualizaNitCamComercio.Text = ds.Tables[0].Rows[0]["CAM_NIT"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encuentra registrada la empresa con ese nit", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El campo no puede quedar vacio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtBuscarNitEmp.Text = "";

        }
        private void btnActualizarEmpresa_Click(object sender, EventArgs e)
        {
            int resultado;
            string nitEmp, nitCam, nomEmp, fechaOpe;
            nitEmp = lbActualizaNitEmp.Text;
            nitCam = txtActualizaNitCamComercio.Text;
            nomEmp = txtActualizaNomEmp.Text;
            fechaOpe = dtpActualizaFecOpeEmpresa.Value.Date.Day + "/" + dtpActualizaFecOpeEmpresa.Value.Date.Month + "/" + dtpActualizaFecOpeEmpresa.Value.Date.Year;
            if (Valida.estalleno(nomEmp) && Valida.estalleno(nitCam))
            {
                /*Valida que exista la empresa y su camara de comercio para así actualizar la empresa o no*/
                if (Valida.existeEmpresa(nitEmp) == 1 && Valida.existeCamaraComercio(nitCam) == 1)
                {
                    resultado = empresa.actualizarEmpresa(nitEmp, nitCam, nomEmp, fechaOpe);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Información empresa actualizada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbActualizaNitEmp.Text = "~";
                        txtActualizaNitCamComercio.Text = "";
                        txtActualizaNomEmp.Text = "";
                        dtpActualizaFecOpeEmpresa.ResetText();
                    }
                }
                else
                {
                    MessageBox.Show("Información empresa no actualizada porque no existe la nit empresa o la nit de camara comercio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Alguno de los campos no puede quedar vacio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnEliminarXnitEmpresa_Click(object sender, EventArgs e)
        {
            int resultado;
            string nit = txtEliminaXnitEmpresa.Text;
            if (Valida.estalleno(nit))
            {
                if (Valida.existeEmpresa(nit) == 1)
                {
                    resultado = empresa.eliminarEmpresa(nit);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Información empresa domiciliaria eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Información empresa domiciliaria no eliminada porque no existe el nit", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El campo Digite el nit no puede quedar vacio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtEliminaXnitEmpresa.Text = "";
        }

        private void btnMostrarEmpresa_Click(object sender, EventArgs e)
        {
            dgvEmpresaDomiciliaria.DataSource= empresa.consultarEmpresa();
            dgvEmpresaDomiciliaria.DataMember = "ResultadoDatos";
        }
    }
}
