namespace AudSemp
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.txtUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLenght = new System.Windows.Forms.TextBox();
            this.txtBreadth = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new DevComponents.DotNetBar.ButtonX();
            this.btnMin = new DevComponents.DotNetBar.ButtonX();
            this.btnAcces = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            // 
            // 
            // 
            this.txtUser.Border.BackColor = System.Drawing.Color.Transparent;
            this.txtUser.Border.Class = "TextBoxBorder";
            this.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(78, 216);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(241, 34);
            this.txtUser.TabIndex = 0;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUser.WatermarkText = "usuario";
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.Border.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(78, 287);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(241, 35);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.WatermarkText = "password";
            // 
            // txtLenght
            // 
            this.txtLenght.Location = new System.Drawing.Point(396, 509);
            this.txtLenght.Name = "txtLenght";
            this.txtLenght.Size = new System.Drawing.Size(100, 20);
            this.txtLenght.TabIndex = 7;
            // 
            // txtBreadth
            // 
            this.txtBreadth.Location = new System.Drawing.Point(421, 506);
            this.txtBreadth.Name = "txtBreadth";
            this.txtBreadth.Size = new System.Drawing.Size(100, 20);
            this.txtBreadth.TabIndex = 8;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(396, 535);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(100, 20);
            this.txtArea.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 523);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(156, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "By";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::AudSemp.Properties.Resources.password_check;
            this.pictureBox4.Location = new System.Drawing.Point(12, 271);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(60, 51);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 17;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::AudSemp.Properties.Resources.user;
            this.pictureBox3.Location = new System.Drawing.Point(12, 201);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(60, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AudSemp.Properties.Resources.semplogo2016;
            this.pictureBox2.Location = new System.Drawing.Point(177, 72);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(159, 111);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AudSemp.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCerrar.Image = global::AudSemp.Properties.Resources.close;
            this.btnCerrar.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnCerrar.Location = new System.Drawing.Point(295, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnCerrar.Size = new System.Drawing.Size(41, 39);
            this.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMin
            // 
            this.btnMin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnMin.Image = global::AudSemp.Properties.Resources.minimizar;
            this.btnMin.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnMin.Location = new System.Drawing.Point(252, 11);
            this.btnMin.Name = "btnMin";
            this.btnMin.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnMin.Size = new System.Drawing.Size(37, 39);
            this.btnMin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMin.TabIndex = 3;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnAcces
            // 
            this.btnAcces.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAcces.BackColor = System.Drawing.Color.Transparent;
            this.btnAcces.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAcces.Image = global::AudSemp.Properties.Resources._lock;
            this.btnAcces.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnAcces.Location = new System.Drawing.Point(273, 339);
            this.btnAcces.Name = "btnAcces";
            this.btnAcces.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnAcces.Size = new System.Drawing.Size(46, 47);
            this.btnAcces.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnAcces.TabIndex = 2;
            this.btnAcces.Click += new System.EventHandler(this.btnAcces_Click);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(5, 1);
            this.labelX1.Name = "labelX1";
            this.labelX1.SingleLineColor = System.Drawing.Color.Transparent;
            this.labelX1.Size = new System.Drawing.Size(166, 50);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "<font color=\"#FFFFFF\">Auditoria <font color=\"#000000\"></font><font color=\"#00B7EF" +
    "\"></font>SEMP\r\n</font>";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelX2.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground2;
            this.labelX2.BackgroundStyle.CornerDiameter = 10;
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.labelX2.ForeColor = System.Drawing.Color.White;
            this.labelX2.Location = new System.Drawing.Point(12, 401);
            this.labelX2.Name = "labelX2";
            this.labelX2.PaddingBottom = 5;
            this.labelX2.PaddingLeft = 5;
            this.labelX2.PaddingRight = 5;
            this.labelX2.PaddingTop = 5;
            this.labelX2.Size = new System.Drawing.Size(328, 93);
            this.labelX2.Symbol = "";
            this.labelX2.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelX2.TabIndex = 19;
            this.labelX2.Text = "labelX2";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // circularProgress1
            // 
            this.circularProgress1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.Location = new System.Drawing.Point(130, 328);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.ProgressColor = System.Drawing.Color.Aqua;
            this.circularProgress1.ProgressTextColor = System.Drawing.Color.White;
            this.circularProgress1.ProgressTextVisible = true;
            this.circularProgress1.Size = new System.Drawing.Size(82, 74);
            this.circularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress1.TabIndex = 20;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(347, 509);
            this.Controls.Add(this.circularProgress1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.txtBreadth);
            this.Controls.Add(this.txtLenght);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnAcces);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(347, 509);
            this.MinimumSize = new System.Drawing.Size(347, 509);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnAcces;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUser;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassword;
        private DevComponents.DotNetBar.ButtonX btnMin;
        private DevComponents.DotNetBar.ButtonX btnCerrar;
        private System.Windows.Forms.TextBox txtLenght;
        private System.Windows.Forms.TextBox txtBreadth;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress1;
    }
}

