namespace appRegistroEmpresaDomiciliaria.dominio {
    partial class Principal {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.btnGestionarEmpresa = new System.Windows.Forms.Button();
            this.btnGestionarCamara = new System.Windows.Forms.Button();
            this.bntGestionarDomiciliario = new System.Windows.Forms.Button();
            this.btnVinculacionEmpresa = new System.Windows.Forms.Button();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGestionarEmpresa
            // 
            this.btnGestionarEmpresa.Location = new System.Drawing.Point(104, 111);
            this.btnGestionarEmpresa.Name = "btnGestionarEmpresa";
            this.btnGestionarEmpresa.Size = new System.Drawing.Size(211, 36);
            this.btnGestionarEmpresa.TabIndex = 0;
            this.btnGestionarEmpresa.Text = "Gestionar Empresa Domiciliaria";
            this.btnGestionarEmpresa.UseVisualStyleBackColor = true;
            this.btnGestionarEmpresa.Click += new System.EventHandler(this.BtnGestionarEmpresa_Click);
            // 
            // btnGestionarCamara
            // 
            this.btnGestionarCamara.Location = new System.Drawing.Point(104, 46);
            this.btnGestionarCamara.Name = "btnGestionarCamara";
            this.btnGestionarCamara.Size = new System.Drawing.Size(211, 32);
            this.btnGestionarCamara.TabIndex = 1;
            this.btnGestionarCamara.Text = "Gestionar Camara Comercio";
            this.btnGestionarCamara.UseVisualStyleBackColor = true;
            this.btnGestionarCamara.Click += new System.EventHandler(this.BtnGestionarCamara_Click);
            // 
            // bntGestionarDomiciliario
            // 
            this.bntGestionarDomiciliario.Location = new System.Drawing.Point(104, 181);
            this.bntGestionarDomiciliario.Name = "bntGestionarDomiciliario";
            this.bntGestionarDomiciliario.Size = new System.Drawing.Size(211, 32);
            this.bntGestionarDomiciliario.TabIndex = 2;
            this.bntGestionarDomiciliario.Text = "Gestionar Domiciliario";
            this.bntGestionarDomiciliario.UseVisualStyleBackColor = true;
            this.bntGestionarDomiciliario.Click += new System.EventHandler(this.BntGestionarDomiciliario_Click);
            // 
            // btnVinculacionEmpresa
            // 
            this.btnVinculacionEmpresa.Location = new System.Drawing.Point(104, 243);
            this.btnVinculacionEmpresa.Name = "btnVinculacionEmpresa";
            this.btnVinculacionEmpresa.Size = new System.Drawing.Size(211, 32);
            this.btnVinculacionEmpresa.TabIndex = 3;
            this.btnVinculacionEmpresa.Text = "Vinculación Empresa-Domiciliario";
            this.btnVinculacionEmpresa.UseVisualStyleBackColor = true;
            this.btnVinculacionEmpresa.Click += new System.EventHandler(this.BtnVinculacionEmpresa_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(104, 301);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(211, 33);
            this.btnConsulta.TabIndex = 4;
            this.btnConsulta.Text = "Gestionar Consultas";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.BtnConsulta_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(570, 393);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.btnVinculacionEmpresa);
            this.Controls.Add(this.bntGestionarDomiciliario);
            this.Controls.Add(this.btnGestionarCamara);
            this.Controls.Add(this.btnGestionarEmpresa);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión Empresas Domiciliarias 4.0";
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Button btnGestionarEmpresa;
        private System.Windows.Forms.Button btnGestionarCamara;
        private System.Windows.Forms.Button bntGestionarDomiciliario;
        private System.Windows.Forms.Button btnVinculacionEmpresa;
        private System.Windows.Forms.Button btnConsulta;
    }
}