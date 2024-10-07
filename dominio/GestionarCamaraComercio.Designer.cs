namespace appRegistroEmpresaDomiciliaria.dominio {
    partial class GestionarCamaraComercio {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tbcGestionCamara = new System.Windows.Forms.TabControl();
            this.tbpRegistroCamara = new System.Windows.Forms.TabPage();
            this.pnlRegistroCamara = new System.Windows.Forms.Panel();
            this.btnGuardaCamaraComercio = new System.Windows.Forms.Button();
            this.txtNomCam = new System.Windows.Forms.TextBox();
            this.lbNomCam = new System.Windows.Forms.Label();
            this.txtNitCam = new System.Windows.Forms.TextBox();
            this.lbNitCam = new System.Windows.Forms.Label();
            this.lbMenCam = new System.Windows.Forms.Label();
            this.tbpMostrarCamara = new System.Windows.Forms.TabPage();
            this.pnlMostrarCamara = new System.Windows.Forms.Panel();
            this.dgvCamaraComercio = new System.Windows.Forms.DataGridView();
            this.btnMostrarCamaraComercio = new System.Windows.Forms.Button();
            this.tbcGestionCamara.SuspendLayout();
            this.tbpRegistroCamara.SuspendLayout();
            this.pnlRegistroCamara.SuspendLayout();
            this.tbpMostrarCamara.SuspendLayout();
            this.pnlMostrarCamara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamaraComercio)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcGestionCamara
            // 
            this.tbcGestionCamara.Controls.Add(this.tbpRegistroCamara);
            this.tbcGestionCamara.Controls.Add(this.tbpMostrarCamara);
            this.tbcGestionCamara.Location = new System.Drawing.Point(12, 12);
            this.tbcGestionCamara.Name = "tbcGestionCamara";
            this.tbcGestionCamara.SelectedIndex = 0;
            this.tbcGestionCamara.Size = new System.Drawing.Size(334, 360);
            this.tbcGestionCamara.TabIndex = 1;
            // 
            // tbpRegistroCamara
            // 
            this.tbpRegistroCamara.Controls.Add(this.pnlRegistroCamara);
            this.tbpRegistroCamara.Location = new System.Drawing.Point(4, 22);
            this.tbpRegistroCamara.Name = "tbpRegistroCamara";
            this.tbpRegistroCamara.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRegistroCamara.Size = new System.Drawing.Size(326, 334);
            this.tbpRegistroCamara.TabIndex = 0;
            this.tbpRegistroCamara.Text = "Registro";
            this.tbpRegistroCamara.UseVisualStyleBackColor = true;
            // 
            // pnlRegistroCamara
            // 
            this.pnlRegistroCamara.Controls.Add(this.btnGuardaCamaraComercio);
            this.pnlRegistroCamara.Controls.Add(this.txtNomCam);
            this.pnlRegistroCamara.Controls.Add(this.lbNomCam);
            this.pnlRegistroCamara.Controls.Add(this.txtNitCam);
            this.pnlRegistroCamara.Controls.Add(this.lbNitCam);
            this.pnlRegistroCamara.Controls.Add(this.lbMenCam);
            this.pnlRegistroCamara.Location = new System.Drawing.Point(6, 6);
            this.pnlRegistroCamara.Name = "pnlRegistroCamara";
            this.pnlRegistroCamara.Size = new System.Drawing.Size(310, 322);
            this.pnlRegistroCamara.TabIndex = 0;
            // 
            // btnGuardaCamaraComercio
            // 
            this.btnGuardaCamaraComercio.Location = new System.Drawing.Point(84, 221);
            this.btnGuardaCamaraComercio.Name = "btnGuardaCamaraComercio";
            this.btnGuardaCamaraComercio.Size = new System.Drawing.Size(133, 48);
            this.btnGuardaCamaraComercio.TabIndex = 21;
            this.btnGuardaCamaraComercio.Text = "Guardar";
            this.btnGuardaCamaraComercio.UseVisualStyleBackColor = true;
            this.btnGuardaCamaraComercio.Click += new System.EventHandler(this.BtnGuardaCamaraComercio_Click);
            // 
            // txtNomCam
            // 
            this.txtNomCam.Location = new System.Drawing.Point(123, 157);
            this.txtNomCam.Name = "txtNomCam";
            this.txtNomCam.Size = new System.Drawing.Size(111, 20);
            this.txtNomCam.TabIndex = 20;
            // 
            // lbNomCam
            // 
            this.lbNomCam.AutoSize = true;
            this.lbNomCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomCam.Location = new System.Drawing.Point(28, 157);
            this.lbNomCam.Name = "lbNomCam";
            this.lbNomCam.Size = new System.Drawing.Size(76, 20);
            this.lbNomCam.TabIndex = 19;
            this.lbNomCam.Text = "Nombre:";
            // 
            // txtNitCam
            // 
            this.txtNitCam.Location = new System.Drawing.Point(123, 100);
            this.txtNitCam.Name = "txtNitCam";
            this.txtNitCam.Size = new System.Drawing.Size(111, 20);
            this.txtNitCam.TabIndex = 18;
            // 
            // lbNitCam
            // 
            this.lbNitCam.AutoSize = true;
            this.lbNitCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNitCam.Location = new System.Drawing.Point(49, 100);
            this.lbNitCam.Name = "lbNitCam";
            this.lbNitCam.Size = new System.Drawing.Size(36, 20);
            this.lbNitCam.TabIndex = 7;
            this.lbNitCam.Text = "Nit:";
            // 
            // lbMenCam
            // 
            this.lbMenCam.AutoSize = true;
            this.lbMenCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMenCam.Location = new System.Drawing.Point(28, 34);
            this.lbMenCam.Name = "lbMenCam";
            this.lbMenCam.Size = new System.Drawing.Size(259, 24);
            this.lbMenCam.TabIndex = 6;
            this.lbMenCam.Text = "Registra Camara Comercio";
            // 
            // tbpMostrarCamara
            // 
            this.tbpMostrarCamara.Controls.Add(this.pnlMostrarCamara);
            this.tbpMostrarCamara.Location = new System.Drawing.Point(4, 22);
            this.tbpMostrarCamara.Name = "tbpMostrarCamara";
            this.tbpMostrarCamara.Size = new System.Drawing.Size(326, 334);
            this.tbpMostrarCamara.TabIndex = 1;
            this.tbpMostrarCamara.Text = "Mostrar Informacion";
            this.tbpMostrarCamara.UseVisualStyleBackColor = true;
            // 
            // pnlMostrarCamara
            // 
            this.pnlMostrarCamara.Controls.Add(this.dgvCamaraComercio);
            this.pnlMostrarCamara.Controls.Add(this.btnMostrarCamaraComercio);
            this.pnlMostrarCamara.Location = new System.Drawing.Point(14, 13);
            this.pnlMostrarCamara.Name = "pnlMostrarCamara";
            this.pnlMostrarCamara.Size = new System.Drawing.Size(291, 304);
            this.pnlMostrarCamara.TabIndex = 0;
            // 
            // dgvCamaraComercio
            // 
            this.dgvCamaraComercio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCamaraComercio.Location = new System.Drawing.Point(14, 63);
            this.dgvCamaraComercio.Name = "dgvCamaraComercio";
            this.dgvCamaraComercio.Size = new System.Drawing.Size(251, 216);
            this.dgvCamaraComercio.TabIndex = 1;
            // 
            // btnMostrarCamaraComercio
            // 
            this.btnMostrarCamaraComercio.Location = new System.Drawing.Point(14, 12);
            this.btnMostrarCamaraComercio.Name = "btnMostrarCamaraComercio";
            this.btnMostrarCamaraComercio.Size = new System.Drawing.Size(152, 45);
            this.btnMostrarCamaraComercio.TabIndex = 0;
            this.btnMostrarCamaraComercio.Text = "Mostrar Camara Comercio";
            this.btnMostrarCamaraComercio.UseVisualStyleBackColor = true;
            this.btnMostrarCamaraComercio.Click += new System.EventHandler(this.BtnMostrarCamaraComercio_Click);
            // 
            // GestionarCamaraComercio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 384);
            this.Controls.Add(this.tbcGestionCamara);
            this.MaximizeBox = false;
            this.Name = "GestionarCamaraComercio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionarCamaraComercio";
            this.tbcGestionCamara.ResumeLayout(false);
            this.tbpRegistroCamara.ResumeLayout(false);
            this.pnlRegistroCamara.ResumeLayout(false);
            this.pnlRegistroCamara.PerformLayout();
            this.tbpMostrarCamara.ResumeLayout(false);
            this.pnlMostrarCamara.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamaraComercio)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TabControl tbcGestionCamara;
        private System.Windows.Forms.TabPage tbpRegistroCamara;
        private System.Windows.Forms.Panel pnlRegistroCamara;
        private System.Windows.Forms.Button btnGuardaCamaraComercio;
        private System.Windows.Forms.TextBox txtNomCam;
        private System.Windows.Forms.Label lbNomCam;
        private System.Windows.Forms.TextBox txtNitCam;
        private System.Windows.Forms.Label lbNitCam;
        private System.Windows.Forms.Label lbMenCam;
        private System.Windows.Forms.TabPage tbpMostrarCamara;
        private System.Windows.Forms.Panel pnlMostrarCamara;
        private System.Windows.Forms.DataGridView dgvCamaraComercio;
        private System.Windows.Forms.Button btnMostrarCamaraComercio;
    }
}