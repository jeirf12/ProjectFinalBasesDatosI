using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appRegistroEmpresaDomiciliaria.dominio
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnGestionarCamara_Click(object sender, EventArgs e)
        {
            GestionarCamaraComercio varGestionCamaraComercio = new GestionarCamaraComercio();
            varGestionCamaraComercio.Show();
        }

        private void btnGestionarEmpresa_Click(object sender, EventArgs e)
        {
            GestionarEmpresaDomiciliaria varGestionEmpresaDomiciliaria = new GestionarEmpresaDomiciliaria();
            varGestionEmpresaDomiciliaria.Show();
        }

        private void bntGestionarDomiciliario_Click(object sender, EventArgs e)
        {
            GestionarDomiciliario varGestionDomiciliario = new GestionarDomiciliario();
            varGestionDomiciliario.Show();
        }

        private void btnVinculacionEmpresa_Click(object sender, EventArgs e)
        {
            VinculacionEmpresaDomiciliario varVinculaEmpresaDomiciliario = new VinculacionEmpresaDomiciliario();
            varVinculaEmpresaDomiciliario.Show();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            GestionarConsulta varGestionConsulta = new GestionarConsulta();
            varGestionConsulta.Show();
        }
    }
}
