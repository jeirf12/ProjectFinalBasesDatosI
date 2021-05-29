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
    public partial class GestionarCamaraComercio : Form
    {
        public GestionarCamaraComercio()
        {
            InitializeComponent();
        }

        private CamaraComercio camara = new CamaraComercio();

        private void btnGuardaCamaraComercio_Click(object sender, EventArgs e)
        {
            int resultadoCam;
            string nitCam, NomCam;
            nitCam = txtNitCam.Text;
            NomCam = txtNomCam.Text;
            if (Valida.estalleno(nitCam) && Valida.estalleno(NomCam))
            {
                if (Valida.existeCamaraComercio(nitCam) == 0)
                {
                    resultadoCam = camara.ingresarCamaraComercio(nitCam, NomCam);
                    if (resultadoCam > 0)
                    {
                        MessageBox.Show("Información Camara Comercio registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNitCam.Text = "";
                        txtNomCam.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Información no registrada por duplicidad de nit", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ninguno de los campos puede quedar vacio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnMostrarCamaraComercio_Click(object sender, EventArgs e)
        {
            DataSet ds =camara.consultarCamaraComercio();
            dgvCamaraComercio.DataSource = ds;
            dgvCamaraComercio.DataMember = "ResultadoDatos";
        }
    }
}
