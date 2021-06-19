namespace OperSemp.Forms
{
    partial class RevisarMNLAutorizarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RevisarMNLAutorizarForm));
            this.dtgResult = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgResult
            // 
            this.dtgResult.AllowUserToAddRows = false;
            this.dtgResult.AllowUserToDeleteRows = false;
            this.dtgResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResult.Location = new System.Drawing.Point(12, 12);
            this.dtgResult.Name = "dtgResult";
            this.dtgResult.ReadOnly = true;
            this.dtgResult.RowTemplate.Height = 24;
            this.dtgResult.Size = new System.Drawing.Size(1303, 520);
            this.dtgResult.TabIndex = 0;
            this.dtgResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgResult_CellContentClick);
            // 
            // RevisarMNLAutorizarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 544);
            this.Controls.Add(this.dtgResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RevisarMNLAutorizarForm";
            this.Text = "AUTORIZACIONES DE VENTAS";
            this.Load += new System.EventHandler(this.RevisarMNLAutorizarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgResult;
    }
}