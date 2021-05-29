namespace appRegistroEmpresaDomiciliaria.dominio
{
    partial class GestionarConsulta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbcGestion = new System.Windows.Forms.TabControl();
            this.tbpConsultaCompleta = new System.Windows.Forms.TabPage();
            this.pnlConsulta = new System.Windows.Forms.Panel();
            this.dgvDatosEmp = new System.Windows.Forms.DataGridView();
            this.btnConsultaEmp = new System.Windows.Forms.Button();
            this.tbpConsultaFecha = new System.Windows.Forms.TabPage();
            this.pnlConsultaFecha = new System.Windows.Forms.Panel();
            this.dgvConsultaXfecha = new System.Windows.Forms.DataGridView();
            this.lbMensa = new System.Windows.Forms.Label();
            this.btnConsultaXfecha = new System.Windows.Forms.Button();
            this.dtpConsulFecha = new System.Windows.Forms.DateTimePicker();
            this.tbpDomiciliariosInactivos = new System.Windows.Forms.TabPage();
            this.pnlDomInactivo = new System.Windows.Forms.Panel();
            this.btnDomiciliarioInactivo = new System.Windows.Forms.Button();
            this.lbContDomInactivo = new System.Windows.Forms.Label();
            this.lbMenInact = new System.Windows.Forms.Label();
            this.tbcGestion.SuspendLayout();
            this.tbpConsultaCompleta.SuspendLayout();
            this.pnlConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosEmp)).BeginInit();
            this.tbpConsultaFecha.SuspendLayout();
            this.pnlConsultaFecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaXfecha)).BeginInit();
            this.tbpDomiciliariosInactivos.SuspendLayout();
            this.pnlDomInactivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcGestion
            // 
            this.tbcGestion.Controls.Add(this.tbpConsultaCompleta);
            this.tbcGestion.Controls.Add(this.tbpConsultaFecha);
            this.tbcGestion.Controls.Add(this.tbpDomiciliariosInactivos);
            this.tbcGestion.Location = new System.Drawing.Point(28, 23);
            this.tbcGestion.Name = "tbcGestion";
            this.tbcGestion.SelectedIndex = 0;
            this.tbcGestion.Size = new System.Drawing.Size(473, 382);
            this.tbcGestion.TabIndex = 2;
            // 
            // tbpConsultaCompleta
            // 
            this.tbpConsultaCompleta.Controls.Add(this.pnlConsulta);
            this.tbpConsultaCompleta.Location = new System.Drawing.Point(4, 22);
            this.tbpConsultaCompleta.Name = "tbpConsultaCompleta";
            this.tbpConsultaCompleta.Padding = new System.Windows.Forms.Padding(3);
            this.tbpConsultaCompleta.Size = new System.Drawing.Size(465, 356);
            this.tbpConsultaCompleta.TabIndex = 1;
            this.tbpConsultaCompleta.Text = "Consulta Informacion";
            this.tbpConsultaCompleta.UseVisualStyleBackColor = true;
            // 
            // pnlConsulta
            // 
            this.pnlConsulta.Controls.Add(this.dgvDatosEmp);
            this.pnlConsulta.Controls.Add(this.btnConsultaEmp);
            this.pnlConsulta.Location = new System.Drawing.Point(15, 6);
            this.pnlConsulta.Name = "pnlConsulta";
            this.pnlConsulta.Size = new System.Drawing.Size(435, 344);
            this.pnlConsulta.TabIndex = 0;
            // 
            // dgvDatosEmp
            // 
            this.dgvDatosEmp.AllowUserToDeleteRows = false;
            this.dgvDatosEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosEmp.Location = new System.Drawing.Point(28, 91);
            this.dgvDatosEmp.Name = "dgvDatosEmp";
            this.dgvDatosEmp.ReadOnly = true;
            this.dgvDatosEmp.Size = new System.Drawing.Size(393, 230);
            this.dgvDatosEmp.TabIndex = 1;
            // 
            // btnConsultaEmp
            // 
            this.btnConsultaEmp.Location = new System.Drawing.Point(28, 19);
            this.btnConsultaEmp.Name = "btnConsultaEmp";
            this.btnConsultaEmp.Size = new System.Drawing.Size(160, 43);
            this.btnConsultaEmp.TabIndex = 0;
            this.btnConsultaEmp.Text = "Consultar Empresas";
            this.btnConsultaEmp.UseVisualStyleBackColor = true;
            this.btnConsultaEmp.Click += new System.EventHandler(this.btnConsultaEmp_Click);
            // 
            // tbpConsultaFecha
            // 
            this.tbpConsultaFecha.Controls.Add(this.pnlConsultaFecha);
            this.tbpConsultaFecha.Location = new System.Drawing.Point(4, 22);
            this.tbpConsultaFecha.Name = "tbpConsultaFecha";
            this.tbpConsultaFecha.Size = new System.Drawing.Size(465, 356);
            this.tbpConsultaFecha.TabIndex = 2;
            this.tbpConsultaFecha.Text = "Consulta por Fecha";
            this.tbpConsultaFecha.UseVisualStyleBackColor = true;
            // 
            // pnlConsultaFecha
            // 
            this.pnlConsultaFecha.Controls.Add(this.dgvConsultaXfecha);
            this.pnlConsultaFecha.Controls.Add(this.lbMensa);
            this.pnlConsultaFecha.Controls.Add(this.btnConsultaXfecha);
            this.pnlConsultaFecha.Controls.Add(this.dtpConsulFecha);
            this.pnlConsultaFecha.Location = new System.Drawing.Point(12, 11);
            this.pnlConsultaFecha.Name = "pnlConsultaFecha";
            this.pnlConsultaFecha.Size = new System.Drawing.Size(425, 326);
            this.pnlConsultaFecha.TabIndex = 0;
            // 
            // dgvConsultaXfecha
            // 
            this.dgvConsultaXfecha.AllowUserToAddRows = false;
            this.dgvConsultaXfecha.AllowUserToDeleteRows = false;
            this.dgvConsultaXfecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultaXfecha.Location = new System.Drawing.Point(38, 113);
            this.dgvConsultaXfecha.Name = "dgvConsultaXfecha";
            this.dgvConsultaXfecha.ReadOnly = true;
            this.dgvConsultaXfecha.Size = new System.Drawing.Size(348, 190);
            this.dgvConsultaXfecha.TabIndex = 4;
            // 
            // lbMensa
            // 
            this.lbMensa.AutoSize = true;
            this.lbMensa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensa.Location = new System.Drawing.Point(34, 15);
            this.lbMensa.Name = "lbMensa";
            this.lbMensa.Size = new System.Drawing.Size(276, 20);
            this.lbMensa.TabIndex = 3;
            this.lbMensa.Text = "Ingrese la fecha inicio de trabajo:";
            // 
            // btnConsultaXfecha
            // 
            this.btnConsultaXfecha.Location = new System.Drawing.Point(265, 47);
            this.btnConsultaXfecha.Name = "btnConsultaXfecha";
            this.btnConsultaXfecha.Size = new System.Drawing.Size(121, 38);
            this.btnConsultaXfecha.TabIndex = 1;
            this.btnConsultaXfecha.Text = "Consultar";
            this.btnConsultaXfecha.UseVisualStyleBackColor = true;
            this.btnConsultaXfecha.Click += new System.EventHandler(this.btnConsultaXfecha_Click);
            // 
            // dtpConsulFecha
            // 
            this.dtpConsulFecha.Location = new System.Drawing.Point(38, 65);
            this.dtpConsulFecha.Name = "dtpConsulFecha";
            this.dtpConsulFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpConsulFecha.TabIndex = 0;
            // 
            // tbpDomiciliariosInactivos
            // 
            this.tbpDomiciliariosInactivos.Controls.Add(this.pnlDomInactivo);
            this.tbpDomiciliariosInactivos.Location = new System.Drawing.Point(4, 22);
            this.tbpDomiciliariosInactivos.Name = "tbpDomiciliariosInactivos";
            this.tbpDomiciliariosInactivos.Size = new System.Drawing.Size(465, 356);
            this.tbpDomiciliariosInactivos.TabIndex = 6;
            this.tbpDomiciliariosInactivos.Text = "Domiciliarios Inactivos";
            this.tbpDomiciliariosInactivos.UseVisualStyleBackColor = true;
            // 
            // pnlDomInactivo
            // 
            this.pnlDomInactivo.Controls.Add(this.btnDomiciliarioInactivo);
            this.pnlDomInactivo.Controls.Add(this.lbContDomInactivo);
            this.pnlDomInactivo.Controls.Add(this.lbMenInact);
            this.pnlDomInactivo.Location = new System.Drawing.Point(39, 26);
            this.pnlDomInactivo.Name = "pnlDomInactivo";
            this.pnlDomInactivo.Size = new System.Drawing.Size(354, 143);
            this.pnlDomInactivo.TabIndex = 0;
            // 
            // btnDomiciliarioInactivo
            // 
            this.btnDomiciliarioInactivo.Location = new System.Drawing.Point(25, 19);
            this.btnDomiciliarioInactivo.Name = "btnDomiciliarioInactivo";
            this.btnDomiciliarioInactivo.Size = new System.Drawing.Size(151, 41);
            this.btnDomiciliarioInactivo.TabIndex = 2;
            this.btnDomiciliarioInactivo.Text = "Consulta N° Inactivos";
            this.btnDomiciliarioInactivo.UseVisualStyleBackColor = true;
            this.btnDomiciliarioInactivo.Click += new System.EventHandler(this.btnDomiciliarioInactivo_Click);
            // 
            // lbContDomInactivo
            // 
            this.lbContDomInactivo.AutoSize = true;
            this.lbContDomInactivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContDomInactivo.Location = new System.Drawing.Point(255, 81);
            this.lbContDomInactivo.Name = "lbContDomInactivo";
            this.lbContDomInactivo.Size = new System.Drawing.Size(18, 20);
            this.lbContDomInactivo.TabIndex = 1;
            this.lbContDomInactivo.Text = "~";
            // 
            // lbMenInact
            // 
            this.lbMenInact.AutoSize = true;
            this.lbMenInact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMenInact.Location = new System.Drawing.Point(22, 81);
            this.lbMenInact.Name = "lbMenInact";
            this.lbMenInact.Size = new System.Drawing.Size(227, 20);
            this.lbMenInact.TabIndex = 0;
            this.lbMenInact.Text = "Los domiciliarios inactivos son: ";
            // 
            // GestionarConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 435);
            this.Controls.Add(this.tbcGestion);
            this.MaximizeBox = false;
            this.Name = "GestionarConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionarConsulta";
            this.tbcGestion.ResumeLayout(false);
            this.tbpConsultaCompleta.ResumeLayout(false);
            this.pnlConsulta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosEmp)).EndInit();
            this.tbpConsultaFecha.ResumeLayout(false);
            this.pnlConsultaFecha.ResumeLayout(false);
            this.pnlConsultaFecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaXfecha)).EndInit();
            this.tbpDomiciliariosInactivos.ResumeLayout(false);
            this.pnlDomInactivo.ResumeLayout(false);
            this.pnlDomInactivo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcGestion;
        private System.Windows.Forms.TabPage tbpConsultaCompleta;
        private System.Windows.Forms.Panel pnlConsulta;
        private System.Windows.Forms.DataGridView dgvDatosEmp;
        private System.Windows.Forms.Button btnConsultaEmp;
        private System.Windows.Forms.TabPage tbpConsultaFecha;
        private System.Windows.Forms.Panel pnlConsultaFecha;
        private System.Windows.Forms.DataGridView dgvConsultaXfecha;
        private System.Windows.Forms.Label lbMensa;
        private System.Windows.Forms.Button btnConsultaXfecha;
        private System.Windows.Forms.DateTimePicker dtpConsulFecha;
        private System.Windows.Forms.TabPage tbpDomiciliariosInactivos;
        private System.Windows.Forms.Panel pnlDomInactivo;
        private System.Windows.Forms.Button btnDomiciliarioInactivo;
        private System.Windows.Forms.Label lbContDomInactivo;
        private System.Windows.Forms.Label lbMenInact;
    }
}