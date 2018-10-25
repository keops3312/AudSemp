namespace AudSemp.Forms
{
    partial class BolsasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BolsasForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
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
            this.chkPrendas = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(178, 23);
            this.labelX1.TabIndex = 91;
            this.labelX1.Text = "Seleccionar tipo de Operacion";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(-1, 246);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReuseParameterValuesOnRefresh = true;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(936, 399);
            this.crystalReportViewer1.TabIndex = 90;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Image = global::AudSemp.Properties.Resources.close1;
            this.btnCancel.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnCancel.Location = new System.Drawing.Point(837, 81);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 54);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 89;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lblProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblProgress.Location = new System.Drawing.Point(695, 218);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(213, 23);
            this.lblProgress.TabIndex = 88;
            this.lblProgress.Text = "-";
            // 
            // btnRegresar
            // 
            this.btnRegresar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRegresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegresar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRegresar.Image = global::AudSemp.Properties.Resources.Back;
            this.btnRegresar.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnRegresar.Location = new System.Drawing.Point(844, 161);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(64, 51);
            this.btnRegresar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRegresar.TabIndex = 87;
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
            this.cmbOrden.Location = new System.Drawing.Point(613, 52);
            this.cmbOrden.Name = "cmbOrden";
            this.cmbOrden.Size = new System.Drawing.Size(134, 23);
            this.cmbOrden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbOrden.TabIndex = 86;
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
            this.cmbTipoOrden.Location = new System.Drawing.Point(462, 52);
            this.cmbTipoOrden.Name = "cmbTipoOrden";
            this.cmbTipoOrden.Size = new System.Drawing.Size(134, 23);
            this.cmbTipoOrden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbTipoOrden.TabIndex = 85;
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
            this.dtFin.Location = new System.Drawing.Point(262, 98);
            // 
            // 
            // 
            this.dtFin.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
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
            this.dtFin.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtFin.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtFin.MonthCalendar.TodayButtonVisible = true;
            this.dtFin.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(168, 20);
            this.dtFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtFin.TabIndex = 84;
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
            this.dtInicio.Location = new System.Drawing.Point(262, 55);
            // 
            // 
            // 
            this.dtInicio.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
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
            this.dtInicio.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtInicio.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInicio.MonthCalendar.TodayButtonVisible = true;
            this.dtInicio.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(168, 20);
            this.dtInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtInicio.TabIndex = 83;
            // 
            // btnReporte
            // 
            this.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReporte.Image = global::AudSemp.Properties.Resources.crystal_reports_logo1;
            this.btnReporte.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnReporte.Location = new System.Drawing.Point(837, 23);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(71, 52);
            this.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReporte.TabIndex = 82;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExportar.Image = global::AudSemp.Properties.Resources.excelfile_29;
            this.btnExportar.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnExportar.Location = new System.Drawing.Point(760, 23);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(71, 52);
            this.btnExportar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExportar.TabIndex = 81;
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
            this.checkModo.Location = new System.Drawing.Point(613, 23);
            this.checkModo.Name = "checkModo";
            this.checkModo.Size = new System.Drawing.Size(82, 23);
            this.checkModo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkModo.TabIndex = 80;
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
            this.checkOrden.Location = new System.Drawing.Point(462, 23);
            this.checkOrden.Name = "checkOrden";
            this.checkOrden.Size = new System.Drawing.Size(88, 23);
            this.checkOrden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkOrden.TabIndex = 79;
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
            this.checkFechas.Location = new System.Drawing.Point(262, 23);
            this.checkFechas.Name = "checkFechas";
            this.checkFechas.Size = new System.Drawing.Size(113, 23);
            this.checkFechas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkFechas.TabIndex = 78;
            this.checkFechas.Text = "Rango de Fecchas";
            this.checkFechas.CheckedChanged += new System.EventHandler(this.checkFechas_CheckedChanged);
            // 
            // checkContratos
            // 
            // 
            // 
            // 
            this.checkContratos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkContratos.Location = new System.Drawing.Point(127, 24);
            this.checkContratos.Name = "checkContratos";
            this.checkContratos.Size = new System.Drawing.Size(97, 51);
            this.checkContratos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkContratos.TabIndex = 77;
            this.checkContratos.Text = "Bolsas Otros";
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
            this.checkPrendas.Location = new System.Drawing.Point(12, 24);
            this.checkPrendas.Name = "checkPrendas";
            this.checkPrendas.Size = new System.Drawing.Size(99, 51);
            this.checkPrendas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkPrendas.TabIndex = 76;
            this.checkPrendas.Text = "Bolsas Joyeria";
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
            this.prg1.Location = new System.Drawing.Point(3, 217);
            this.prg1.Name = "prg1";
            this.prg1.Size = new System.Drawing.Size(687, 23);
            this.prg1.TabIndex = 75;
            this.prg1.Text = "progressBarX1";
            // 
            // chkPrendas
            // 
            this.chkPrendas.FormattingEnabled = true;
            this.chkPrendas.Location = new System.Drawing.Point(12, 67);
            this.chkPrendas.Name = "chkPrendas";
            this.chkPrendas.Size = new System.Drawing.Size(212, 139);
            this.chkPrendas.TabIndex = 92;
            // 
            // BolsasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 645);
            this.Controls.Add(this.chkPrendas);
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
            this.MinimumSize = new System.Drawing.Size(951, 684);
            this.Name = "BolsasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auditoria Bolsas";
            this.Load += new System.EventHandler(this.BolsasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevComponents.DotNetBar.LabelX labelX1;
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
        private System.Windows.Forms.CheckedListBox chkPrendas;
    }
}