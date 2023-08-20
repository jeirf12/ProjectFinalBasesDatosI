using System;
using System.Data;
using System.Windows.Forms;
using appRegistroEmpresaDomiciliaria.logica;
using appRegistroEmpresaDomiciliaria.acessoDatos;

namespace appRegistroEmpresaDomiciliaria.dominio {
    public partial class GestionarConsulta : Form {
        private Trabaja trabajo;
        private DataSet ds;

        public GestionarConsulta() {
            this.InitializeComponent();
            this.trabajo = new Trabaja();
            this.ds = new DataSet();
        }
        
        private void btnConsultaEmp_Click(object sender, EventArgs e) {
            ds = this.trabajo.consultaTrabaja();
            dgvDatosEmp.DataSource = ds;
            dgvDatosEmp.DataMember = "ResultadoDatos";
        }

        private void btnConsultaXfecha_Click(object sender, EventArgs e) {
            string consultaFecha = "select cam_nombre as \"Nombre Camara Comercio\",e.emp_nit as \"Nit Empresa\", emp_nombre as \"Nombre Empresa\", d.dom_id as \"Id Domiciliario\", dom_nombre as \"Nombre Domiciliario\", dom_apellido as \"Apellido Domiciliario\" from camara_comercio c inner join empresa_domiciliaria e on c.cam_nit=e.cam_nit inner join trabaja t on e.emp_nit = t.emp_nit inner join domiciliario d on d.dom_id = t.dom_id where trab_fecha_inicio in (to_date('" + dtpConsulFecha.Value.Date.Day + " / " + dtpConsulFecha.Value.Date.Month + "/" + dtpConsulFecha.Value.Year + "', 'DD/MM/YYYY'))";
            ds = Datos.ejecutarSelect(consultaFecha);
            dgvConsultaXfecha.DataSource = ds;
            dgvConsultaXfecha.DataMember = "ResultadoDatos";
        }

        private void btnDomiciliarioInactivo_Click(object sender, EventArgs e) {
            string consulta = "select count(t.dom_id) from trabaja t inner join domiciliario d on t.dom_id=d.dom_id where dom_estado = 'inactivo' or trab_fecha_fin >= sysdate";
            ds = Datos.ejecutarSelect(consulta);
            if (ds.Tables[0].Rows.Count > 0) {
                lbContDomInactivo.Text = "" + ds.Tables[0].Rows[0].ItemArray[0];
            }
        }
    }
}