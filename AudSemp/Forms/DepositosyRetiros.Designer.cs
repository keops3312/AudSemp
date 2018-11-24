﻿namespace AudSemp.Forms
{
    partial class DepositosyRetiros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepositosyRetiros));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.lblProgress = new DevComponents.DotNetBar.LabelX();
            this.btnRegresar = new DevComponents.DotNetBar.ButtonX();
            this.cmbOrden = new DevComponents.DotNetBar.Controls.ComboTree();
            this.cmbTipoOrden = new DevComponents.DotNetBar.Controls.ComboTree();
            this.dtFin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtInicio = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnReporte = new DevComponents.DotNetBar.ButtonX();
            this.btnExportar = new DevComponents.DotNetBar.ButtonX();
            this.checkModo = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkOrden = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkFechas = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkContratos = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkPrendas = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.prg1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(-1, 310);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReuseParameterValuesOnRefresh = true;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1247, 482);
            this.crystalReportViewer1.TabIndex = 73;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Image = global::AudSemp.Properties.Resources.close1;
            this.btnCancel.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnCancel.Location = new System.Drawing.Point(1116, 107);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 66);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 72;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lblProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblProgress.Location = new System.Drawing.Point(927, 276);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(284, 28);
            this.lblProgress.TabIndex = 71;
            this.lblProgress.Text = "-";
            // 
            // btnRegresar
            // 
            this.btnRegresar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRegresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegresar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRegresar.Image = global::AudSemp.Properties.Resources.Back;
            this.btnRegresar.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnRegresar.Location = new System.Drawing.Point(1125, 206);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(85, 63);
            this.btnRegresar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRegresar.TabIndex = 70;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // cmbOrden
            // 
            this.cmbOrden.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cmbOrden.BackgroundStyle.Class = "TextBoxBorder";
            this.cmbOrden.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cmbOrden.ButtonDropDown.Visible = true;
            this.cmbOrden.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.cmbOrden.Location = new System.Drawing.Point(817, 66);
            this.cmbOrden.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbOrden.Name = "cmbOrden";
            this.cmbOrden.Size = new System.Drawing.Size(179, 28);
            this.cmbOrden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbOrden.TabIndex = 67;
            // 
            // cmbTipoOrden
            // 
            this.cmbTipoOrden.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cmbTipoOrden.BackgroundStyle.Class = "TextBoxBorder";
            this.cmbTipoOrden.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cmbTipoOrden.ButtonDropDown.Visible = true;
            this.cmbTipoOrden.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.cmbTipoOrden.Location = new System.Drawing.Point(597, 66);
            this.cmbTipoOrden.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTipoOrden.Name = "cmbTipoOrden";
            this.cmbTipoOrden.Size = new System.Drawing.Size(179, 28);
            this.cmbTipoOrden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbTipoOrden.TabIndex = 66;
            // 
            // dtFin
            // 
            // 
            // 
            // 
            this.dtFin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtFin.ButtonDropDown.Visible = true;
            this.dtFin.IsPopupCalendarOpen = false;
            this.dtFin.Location = new System.Drawing.Point(300, 126);
            this.dtFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtFin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtFin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtFin.MonthCalendar.DisplayMonth = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtFin.MonthCalendar.TodayButtonVisible = true;
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(224, 22);
            this.dtFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtFin.TabIndex = 65;
            // 
            // dtInicio
            // 
            // 
            // 
            // 
            this.dtInicio.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtInicio.ButtonDropDown.Visible = true;
            this.dtInicio.IsPopupCalendarOpen = false;
            this.dtInicio.Location = new System.Drawing.Point(300, 66);
            this.dtInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInicio.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtInicio.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInicio.MonthCalendar.DisplayMonth = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInicio.MonthCalendar.TodayButtonVisible = true;
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(224, 22);
            this.dtInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtInicio.TabIndex = 64;
            // 
            // btnReporte
            // 
            this.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReporte.Image = global::AudSemp.Properties.Resources.crystal_reports_logo1;
            this.btnReporte.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnReporte.Location = new System.Drawing.Point(1116, 36);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(95, 64);
            this.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReporte.TabIndex = 63;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExportar.Image = global::AudSemp.Properties.Resources.excelfile_29;
            this.btnExportar.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnExportar.Location = new System.Drawing.Point(1013, 36);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(95, 64);
            this.btnExportar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExportar.TabIndex = 62;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // checkModo
            // 
            // 
            // 
            // 
            this.checkModo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkModo.Checked = true;
            this.checkModo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkModo.CheckValue = "Y";
            this.checkModo.Location = new System.Drawing.Point(817, 15);
            this.checkModo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkModo.Name = "checkModo";
            this.checkModo.Size = new System.Drawing.Size(109, 28);
            this.checkModo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkModo.TabIndex = 61;
            this.checkModo.Text = "Modo Orden";
            this.checkModo.CheckedChanged += new System.EventHandler(this.checkModo_CheckedChanged);
            // 
            // checkOrden
            // 
            // 
            // 
            // 
            this.checkOrden.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkOrden.Checked = true;
            this.checkOrden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkOrden.CheckValue = "Y";
            this.checkOrden.Location = new System.Drawing.Point(597, 15);
            this.checkOrden.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkOrden.Name = "checkOrden";
            this.checkOrden.Size = new System.Drawing.Size(117, 28);
            this.checkOrden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkOrden.TabIndex = 60;
            this.checkOrden.Text = "Ordernar Por";
            this.checkOrden.CheckedChanged += new System.EventHandler(this.checkOrden_CheckedChanged);
            // 
            // checkFechas
            // 
            // 
            // 
            // 
            this.checkFechas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkFechas.Checked = true;
            this.checkFechas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkFechas.CheckValue = "Y";
            this.checkFechas.Location = new System.Drawing.Point(300, 15);
            this.checkFechas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkFechas.Name = "checkFechas";
            this.checkFechas.Size = new System.Drawing.Size(151, 28);
            this.checkFechas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkFechas.TabIndex = 59;
            this.checkFechas.Text = "Rango de Fecchas";
            this.checkFechas.CheckedChanged += new System.EventHandler(this.checkFechas_CheckedChanged);
            // 
            // checkContratos
            // 
            // 
            // 
            // 
            this.checkContratos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkContratos.Checked = true;
            this.checkContratos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkContratos.CheckValue = "Y";
            this.checkContratos.Location = new System.Drawing.Point(52, 102);
            this.checkContratos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkContratos.Name = "checkContratos";
            this.checkContratos.Size = new System.Drawing.Size(173, 63);
            this.checkContratos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkContratos.TabIndex = 58;
            this.checkContratos.Text = "Retiros";
            this.checkContratos.CheckedChanged += new System.EventHandler(this.checkContratos_CheckedChanged);
            // 
            // checkPrendas
            // 
            // 
            // 
            // 
            this.checkPrendas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkPrendas.Checked = true;
            this.checkPrendas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPrendas.CheckValue = "Y";
            this.checkPrendas.Location = new System.Drawing.Point(52, 37);
            this.checkPrendas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkPrendas.Name = "checkPrendas";
            this.checkPrendas.Size = new System.Drawing.Size(173, 63);
            this.checkPrendas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkPrendas.TabIndex = 57;
            this.checkPrendas.Text = "Depositos";
            this.checkPrendas.CheckedChanged += new System.EventHandler(this.checkPrendas_CheckedChanged);
            // 
            // prg1
            // 
            this.prg1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.prg1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.prg1.Location = new System.Drawing.Point(4, 274);
            this.prg1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.prg1.Name = "prg1";
            this.prg1.Size = new System.Drawing.Size(916, 28);
            this.prg1.TabIndex = 56;
            this.prg1.Text = "progressBarX1";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(28, 15);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(237, 28);
            this.labelX1.TabIndex = 74;
            this.labelX1.Text = "Seleccionar tipo de Operacion";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // DepositosyRetiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 794);
            this.ControlBox = false;
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.cmbOrden);
            this.Controls.Add(this.cmbTipoOrden);
            this.Controls.Add(this.dtFin);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.checkModo);
            this.Controls.Add(this.checkOrden);
            this.Controls.Add(this.checkFechas);
            this.Controls.Add(this.checkContratos);
            this.Controls.Add(this.checkPrendas);
            this.Controls.Add(this.prg1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DepositosyRetiros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auditoria Depositos y Retiros";
            this.Load += new System.EventHandler(this.DepositosyRetiros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX lblProgress;
        private DevComponents.DotNetBar.ButtonX btnRegresar;
        private DevComponents.DotNetBar.Controls.ComboTree cmbOrden;
        private DevComponents.DotNetBar.Controls.ComboTree cmbTipoOrden;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtFin;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtInicio;
        private DevComponents.DotNetBar.ButtonX btnReporte;
        private DevComponents.DotNetBar.ButtonX btnExportar;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkModo;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkOrden;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkFechas;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkContratos;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkPrendas;
        private DevComponents.DotNetBar.Controls.ProgressBarX prg1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}