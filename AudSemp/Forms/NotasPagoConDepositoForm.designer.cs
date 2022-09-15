namespace AudSemp.Forms
{
    partial class NotasPagoConDepositoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotasPagoConDepositoForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.chkListAuditados = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkListAutorizados = new System.Windows.Forms.CheckedListBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.chkTodosAuditados = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkTodosAutorizados = new System.Windows.Forms.CheckBox();
            this.btnVistaPrevia = new System.Windows.Forms.Button();
            this.dtInicial = new System.Windows.Forms.DateTimePicker();
            this.btnReporte = new System.Windows.Forms.Button();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.chkFechas = new System.Windows.Forms.CheckBox();
            this.chkOrdenPor = new System.Windows.Forms.CheckBox();
            this.chkTipos = new System.Windows.Forms.CheckBox();
            this.chkModoOrden = new System.Windows.Forms.CheckBox();
            this.chkListTipos = new System.Windows.Forms.CheckedListBox();
            this.cboOrdenModo = new System.Windows.Forms.ComboBox();
            this.cboOrden = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.circularProgress1);
            this.groupBox1.Controls.Add(this.btnRevisar);
            this.groupBox1.Controls.Add(this.chkListAuditados);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkListAutorizados);
            this.groupBox1.Controls.Add(this.btnRegresar);
            this.groupBox1.Controls.Add(this.chkTodosAuditados);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.chkTodosAutorizados);
            this.groupBox1.Controls.Add(this.btnVistaPrevia);
            this.groupBox1.Controls.Add(this.dtInicial);
            this.groupBox1.Controls.Add(this.btnReporte);
            this.groupBox1.Controls.Add(this.dtFinal);
            this.groupBox1.Controls.Add(this.btnExportarExcel);
            this.groupBox1.Controls.Add(this.chkFechas);
            this.groupBox1.Controls.Add(this.chkOrdenPor);
            this.groupBox1.Controls.Add(this.chkTipos);
            this.groupBox1.Controls.Add(this.chkModoOrden);
            this.groupBox1.Controls.Add(this.chkListTipos);
            this.groupBox1.Controls.Add(this.cboOrdenModo);
            this.groupBox1.Controls.Add(this.cboOrden);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(966, 262);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuración Inicial";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(477, 51);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(116, 17);
            this.radioButton3.TabIndex = 25;
            this.radioButton3.Text = "Fecha Autorización";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(617, 51);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(99, 17);
            this.radioButton2.TabIndex = 24;
            this.radioButton2.Text = "Fecha Auditoria";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(477, 84);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(99, 17);
            this.radioButton1.TabIndex = 23;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Fecha Revisión";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // circularProgress1
            // 
            this.circularProgress1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.Location = new System.Drawing.Point(790, 106);
            this.circularProgress1.Margin = new System.Windows.Forms.Padding(2);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.ProgressColor = System.Drawing.Color.DeepSkyBlue;
            this.circularProgress1.Size = new System.Drawing.Size(68, 72);
            this.circularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress1.TabIndex = 22;
            // 
            // btnRevisar
            // 
            this.btnRevisar.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnRevisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevisar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRevisar.Image = global::AudSemp.Properties.Resources.contratosSmall;
            this.btnRevisar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRevisar.Location = new System.Drawing.Point(347, 178);
            this.btnRevisar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(109, 75);
            this.btnRevisar.TabIndex = 20;
            this.btnRevisar.Text = "Comenz&ar a Revisar";
            this.btnRevisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRevisar.UseVisualStyleBackColor = false;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // chkListAuditados
            // 
            this.chkListAuditados.CheckOnClick = true;
            this.chkListAuditados.FormattingEnabled = true;
            this.chkListAuditados.Location = new System.Drawing.Point(5, 51);
            this.chkListAuditados.Margin = new System.Windows.Forms.Padding(2);
            this.chkListAuditados.Name = "chkListAuditados";
            this.chkListAuditados.Size = new System.Drawing.Size(126, 94);
            this.chkListAuditados.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 141);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "y";
            // 
            // chkListAutorizados
            // 
            this.chkListAutorizados.CheckOnClick = true;
            this.chkListAutorizados.FormattingEnabled = true;
            this.chkListAutorizados.Location = new System.Drawing.Point(150, 51);
            this.chkListAutorizados.Margin = new System.Windows.Forms.Padding(2);
            this.chkListAutorizados.Name = "chkListAutorizados";
            this.chkListAutorizados.Size = new System.Drawing.Size(128, 94);
            this.chkListAutorizados.TabIndex = 1;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegresar.BackColor = System.Drawing.Color.Maroon;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Image = global::AudSemp.Properties.Resources.BackSmall;
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegresar.Location = new System.Drawing.Point(826, 199);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(124, 55);
            this.btnRegresar.TabIndex = 18;
            this.btnRegresar.Text = "&Regresar";
            this.btnRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // chkTodosAuditados
            // 
            this.chkTodosAuditados.AutoSize = true;
            this.chkTodosAuditados.Location = new System.Drawing.Point(8, 27);
            this.chkTodosAuditados.Margin = new System.Windows.Forms.Padding(2);
            this.chkTodosAuditados.Name = "chkTodosAuditados";
            this.chkTodosAuditados.Size = new System.Drawing.Size(139, 17);
            this.chkTodosAuditados.TabIndex = 2;
            this.chkTodosAuditados.Text = "Todos Status Auditados";
            this.chkTodosAuditados.UseVisualStyleBackColor = true;
            this.chkTodosAuditados.CheckedChanged += new System.EventHandler(this.chkTodosAuditados_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::AudSemp.Properties.Resources.cancelSmall;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(710, 199);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 55);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "&Cancelar\r\nEjercicio";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // chkTodosAutorizados
            // 
            this.chkTodosAutorizados.AutoSize = true;
            this.chkTodosAutorizados.Location = new System.Drawing.Point(153, 27);
            this.chkTodosAutorizados.Margin = new System.Windows.Forms.Padding(2);
            this.chkTodosAutorizados.Name = "chkTodosAutorizados";
            this.chkTodosAutorizados.Size = new System.Drawing.Size(142, 17);
            this.chkTodosAutorizados.TabIndex = 3;
            this.chkTodosAutorizados.Text = "Todos Status Autorizado";
            this.chkTodosAutorizados.UseVisualStyleBackColor = true;
            this.chkTodosAutorizados.CheckedChanged += new System.EventHandler(this.chkTodosAutorizados_CheckedChanged);
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.BackColor = System.Drawing.Color.DarkOrange;
            this.btnVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVistaPrevia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVistaPrevia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVistaPrevia.Image = global::AudSemp.Properties.Resources.cameraSamll_fw;
            this.btnVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVistaPrevia.Location = new System.Drawing.Point(234, 178);
            this.btnVistaPrevia.Margin = new System.Windows.Forms.Padding(2);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Size = new System.Drawing.Size(109, 75);
            this.btnVistaPrevia.TabIndex = 16;
            this.btnVistaPrevia.Text = "&Vista Completa";
            this.btnVistaPrevia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVistaPrevia.UseVisualStyleBackColor = false;
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // dtInicial
            // 
            this.dtInicial.Location = new System.Drawing.Point(484, 119);
            this.dtInicial.Margin = new System.Windows.Forms.Padding(2);
            this.dtInicial.Name = "dtInicial";
            this.dtInicial.Size = new System.Drawing.Size(232, 20);
            this.dtInicial.TabIndex = 4;
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.ForeColor = System.Drawing.Color.White;
            this.btnReporte.Image = global::AudSemp.Properties.Resources.crystalSmall;
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReporte.Location = new System.Drawing.Point(121, 178);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(2);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(109, 75);
            this.btnReporte.TabIndex = 15;
            this.btnReporte.Text = "Crear &Informe";
            this.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // dtFinal
            // 
            this.dtFinal.Location = new System.Drawing.Point(484, 156);
            this.dtFinal.Margin = new System.Windows.Forms.Padding(2);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(232, 20);
            this.dtFinal.TabIndex = 5;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.LimeGreen;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Image = global::AudSemp.Properties.Resources.excelSmall;
            this.btnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportarExcel.Location = new System.Drawing.Point(9, 178);
            this.btnExportarExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(109, 75);
            this.btnExportarExcel.TabIndex = 14;
            this.btnExportarExcel.Text = "&Exportar Excel";
            this.btnExportarExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // chkFechas
            // 
            this.chkFechas.AutoSize = true;
            this.chkFechas.Location = new System.Drawing.Point(545, 27);
            this.chkFechas.Margin = new System.Windows.Forms.Padding(2);
            this.chkFechas.Name = "chkFechas";
            this.chkFechas.Size = new System.Drawing.Size(111, 17);
            this.chkFechas.TabIndex = 6;
            this.chkFechas.Text = "Rango de Fechas";
            this.chkFechas.UseVisualStyleBackColor = true;
            this.chkFechas.CheckedChanged += new System.EventHandler(this.chkFechas_CheckedChanged);
            // 
            // chkOrdenPor
            // 
            this.chkOrdenPor.AutoSize = true;
            this.chkOrdenPor.Location = new System.Drawing.Point(742, 27);
            this.chkOrdenPor.Margin = new System.Windows.Forms.Padding(2);
            this.chkOrdenPor.Name = "chkOrdenPor";
            this.chkOrdenPor.Size = new System.Drawing.Size(83, 17);
            this.chkOrdenPor.TabIndex = 7;
            this.chkOrdenPor.Text = "Ordenar Por";
            this.chkOrdenPor.UseVisualStyleBackColor = true;
            this.chkOrdenPor.CheckedChanged += new System.EventHandler(this.chkOrdenPor_CheckedChanged);
            // 
            // chkTipos
            // 
            this.chkTipos.AutoSize = true;
            this.chkTipos.Location = new System.Drawing.Point(300, 27);
            this.chkTipos.Margin = new System.Windows.Forms.Padding(2);
            this.chkTipos.Name = "chkTipos";
            this.chkTipos.Size = new System.Drawing.Size(190, 17);
            this.chkTipos.TabIndex = 12;
            this.chkTipos.Text = "Todos los Tipos de Notas de Pago";
            this.chkTipos.UseVisualStyleBackColor = true;
            this.chkTipos.CheckedChanged += new System.EventHandler(this.chkTipos_CheckedChanged);
            // 
            // chkModoOrden
            // 
            this.chkModoOrden.AutoSize = true;
            this.chkModoOrden.Location = new System.Drawing.Point(853, 27);
            this.chkModoOrden.Margin = new System.Windows.Forms.Padding(2);
            this.chkModoOrden.Name = "chkModoOrden";
            this.chkModoOrden.Size = new System.Drawing.Size(100, 17);
            this.chkModoOrden.TabIndex = 8;
            this.chkModoOrden.Text = "Modo de Orden";
            this.chkModoOrden.UseVisualStyleBackColor = true;
            this.chkModoOrden.CheckedChanged += new System.EventHandler(this.chkModoOrden_CheckedChanged);
            // 
            // chkListTipos
            // 
            this.chkListTipos.CheckOnClick = true;
            this.chkListTipos.FormattingEnabled = true;
            this.chkListTipos.Location = new System.Drawing.Point(300, 51);
            this.chkListTipos.Margin = new System.Windows.Forms.Padding(2);
            this.chkListTipos.Name = "chkListTipos";
            this.chkListTipos.Size = new System.Drawing.Size(138, 94);
            this.chkListTipos.TabIndex = 11;
            // 
            // cboOrdenModo
            // 
            this.cboOrdenModo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdenModo.FormattingEnabled = true;
            this.cboOrdenModo.Location = new System.Drawing.Point(853, 48);
            this.cboOrdenModo.Margin = new System.Windows.Forms.Padding(2);
            this.cboOrdenModo.Name = "cboOrdenModo";
            this.cboOrdenModo.Size = new System.Drawing.Size(92, 21);
            this.cboOrdenModo.TabIndex = 9;
            // 
            // cboOrden
            // 
            this.cboOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrden.FormattingEnabled = true;
            this.cboOrden.Location = new System.Drawing.Point(742, 48);
            this.cboOrden.Margin = new System.Windows.Forms.Padding(2);
            this.cboOrden.Name = "cboOrden";
            this.cboOrden.Size = new System.Drawing.Size(92, 21);
            this.cboOrden.TabIndex = 10;
            this.cboOrden.SelectedIndexChanged += new System.EventHandler(this.cboOrden_SelectedIndexChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(-7, 278);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(995, 263);
            this.crystalReportViewer1.TabIndex = 23;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // NotasPagoConDepositoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 541);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotasPagoConDepositoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notas de Pago con Deposito Bancario";
            this.Load += new System.EventHandler(this.NotasPagoConDepositoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress1;
        private System.Windows.Forms.Button btnRevisar;
        private System.Windows.Forms.CheckedListBox chkListAuditados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chkListAutorizados;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.CheckBox chkTodosAuditados;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkTodosAutorizados;
        private System.Windows.Forms.Button btnVistaPrevia;
        private System.Windows.Forms.DateTimePicker dtInicial;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.DateTimePicker dtFinal;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.CheckBox chkFechas;
        private System.Windows.Forms.CheckBox chkOrdenPor;
        private System.Windows.Forms.CheckBox chkTipos;
        private System.Windows.Forms.CheckBox chkModoOrden;
        private System.Windows.Forms.CheckedListBox chkListTipos;
        private System.Windows.Forms.ComboBox cboOrdenModo;
        private System.Windows.Forms.ComboBox cboOrden;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}