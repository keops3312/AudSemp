namespace AudSemp.Forms
{
    partial class TomaFisicaForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TomaFisicaForm));
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.txtRuta = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbTypeOfAud = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtHoja = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.ResGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRegresar = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.command2 = new DevComponents.DotNetBar.Command(this.components);
            this.command1 = new DevComponents.DotNetBar.Command(this.components);
            this.command3 = new DevComponents.DotNetBar.Command(this.components);
            this.command4 = new DevComponents.DotNetBar.Command(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ResGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(38, 16);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(116, 40);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.Symbol = "";
            this.buttonX3.TabIndex = 0;
            this.buttonX3.Text = "Cargar Archivo";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // txtRuta
            // 
            // 
            // 
            // 
            this.txtRuta.Border.Class = "TextBoxBorder";
            this.txtRuta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.txtRuta.Enabled = false;
            this.txtRuta.Location = new System.Drawing.Point(258, 28);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.PreventEnterBeep = true;
            this.txtRuta.Size = new System.Drawing.Size(279, 28);
            this.txtRuta.TabIndex = 1;
            // 
            // cmbTypeOfAud
            // 
            this.cmbTypeOfAud.DisplayMember = "Text";
            this.cmbTypeOfAud.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTypeOfAud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeOfAud.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypeOfAud.FormattingEnabled = true;
            this.cmbTypeOfAud.ItemHeight = 25;
            this.cmbTypeOfAud.Location = new System.Drawing.Point(258, 71);
            this.cmbTypeOfAud.Name = "cmbTypeOfAud";
            this.cmbTypeOfAud.Size = new System.Drawing.Size(279, 31);
            this.cmbTypeOfAud.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbTypeOfAud.TabIndex = 1;
            // 
            // txtHoja
            // 
            // 
            // 
            // 
            this.txtHoja.Border.Class = "TextBoxBorder";
            this.txtHoja.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.txtHoja.Location = new System.Drawing.Point(258, 120);
            this.txtHoja.Name = "txtHoja";
            this.txtHoja.PreventEnterBeep = true;
            this.txtHoja.Size = new System.Drawing.Size(279, 28);
            this.txtHoja.TabIndex = 2;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(152, 128);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(100, 23);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "Nombre de Hoja =";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(168, 33);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(84, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "Ruta Archivo =";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(161, 79);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(91, 23);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "Tipo Auditoria =";
            // 
            // circularProgress1
            // 
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.Location = new System.Drawing.Point(342, 169);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.circularProgress1.ProgressColor = System.Drawing.SystemColors.Highlight;
            this.circularProgress1.Size = new System.Drawing.Size(115, 65);
            this.circularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress1.TabIndex = 7;
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Location = new System.Drawing.Point(185, 244);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(142, 44);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.Symbol = "";
            this.buttonX4.TabIndex = 4;
            this.buttonX4.Text = "Imprimir Resultado";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX5.Location = new System.Drawing.Point(360, 243);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(145, 44);
            this.buttonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX5.Symbol = "";
            this.buttonX5.TabIndex = 5;
            this.buttonX5.Text = "Exportar Resultado";
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX6.Location = new System.Drawing.Point(38, 243);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(116, 45);
            this.buttonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX6.Symbol = "";
            this.buttonX6.TabIndex = 3;
            this.buttonX6.Text = "Auditar Ahora";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // ResGrid
            // 
            this.ResGrid.AllowUserToAddRows = false;
            this.ResGrid.AllowUserToDeleteRows = false;
            this.ResGrid.AllowUserToOrderColumns = true;
            this.ResGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ResGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.ResGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.ResGrid.Location = new System.Drawing.Point(38, 323);
            this.ResGrid.Name = "ResGrid";
            this.ResGrid.ReadOnly = true;
            this.ResGrid.Size = new System.Drawing.Size(747, 218);
            this.ResGrid.TabIndex = 7;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // line1
            // 
            this.line1.Location = new System.Drawing.Point(38, 293);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(747, 23);
            this.line1.TabIndex = 15;
            this.line1.Text = "line1";
            this.line1.Thickness = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::AudSemp.Properties.Resources.fisica_toma;
            this.pictureBox1.Location = new System.Drawing.Point(594, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // btnRegresar
            // 
            this.btnRegresar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRegresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegresar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRegresar.Image = global::AudSemp.Properties.Resources.Back;
            this.btnRegresar.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnRegresar.Location = new System.Drawing.Point(721, 28);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(64, 51);
            this.btnRegresar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRegresar.TabIndex = 53;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Image = global::AudSemp.Properties.Resources.close1;
            this.btnCancel.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnCancel.Location = new System.Drawing.Point(669, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 40);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.Symbol = "";
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // command2
            // 
            this.command2.Image = global::AudSemp.Properties.Resources.ElecQuestion_fw;
            this.command2.Name = "command2";
            this.command2.Text = "<font size=\"+2\"><font color=\"#456287\">Bolsas Otros</font></font><br/><font color=" +
    "\"#1F497D\">Computo, Electronicos, Herramientas ...</font>";
            this.command2.Executed += new System.EventHandler(this.command2_Executed);
            // 
            // command1
            // 
            this.command1.Image = global::AudSemp.Properties.Resources.joyQuestion;
            this.command1.Name = "command1";
            this.command1.Text = "<font size=\"+2\"><font color=\"#456287\">Bolsas Oro</font></font><br/><font color=\"#" +
    "1F497D\">Cadenas, pulseras, aretes...</font>";
            this.command1.Executed += new System.EventHandler(this.command1_Executed);
            // 
            // command3
            // 
            this.command3.Image = global::AudSemp.Properties.Resources.joyQuestion;
            this.command3.Name = "command3";
            this.command3.Text = "<font size=\"+2\"><font color=\"#456287\">Joyeria</font></font><br/><font color=\"#1F4" +
    "97D\">Cadenas, pulseras, aretes...</font>";
            this.command3.Executed += new System.EventHandler(this.command3_Executed);
            // 
            // command4
            // 
            this.command4.Image = global::AudSemp.Properties.Resources.ElecQuestion_fw;
            this.command4.Name = "command4";
            this.command4.Text = "<font size=\"+2\"><font color=\"#456287\">Otros</font></font><br/><font color=\"#1F497" +
    "D\">Computo, Electronicos, Herramientas ...</font>\r\n";
            this.command4.Executed += new System.EventHandler(this.command4_Executed);
            // 
            // TomaFisicaForm
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(822, 553);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ResGrid);
            this.Controls.Add(this.buttonX6);
            this.Controls.Add(this.buttonX5);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.circularProgress1);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtHoja);
            this.Controls.Add(this.cmbTypeOfAud);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.buttonX3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(838, 592);
            this.Name = "TomaFisicaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auditoria fisica";
            this.Load += new System.EventHandler(this.TomaFisicaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRuta;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbTypeOfAud;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHoja;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress1;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private DevComponents.DotNetBar.Controls.DataGridViewX ResGrid;
        private DevComponents.DotNetBar.Command command1;
        private DevComponents.DotNetBar.Command command2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.ButtonX btnRegresar;
        private DevComponents.DotNetBar.Command command3;
        private DevComponents.DotNetBar.Command command4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}