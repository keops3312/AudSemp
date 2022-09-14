namespace AudSemp.Forms
{
    partial class VistaPreviaNDForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaPreviaNDForm));
            this.label1 = new System.Windows.Forms.Label();
            this.dtgResult = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Resultados Notas Descuento";
            // 
            // dtgResult
            // 
            this.dtgResult.AllowUserToAddRows = false;
            this.dtgResult.AllowUserToDeleteRows = false;
            this.dtgResult.AllowUserToOrderColumns = true;
            this.dtgResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResult.Location = new System.Drawing.Point(10, 58);
            this.dtgResult.Margin = new System.Windows.Forms.Padding(2);
            this.dtgResult.Name = "dtgResult";
            this.dtgResult.ReadOnly = true;
            this.dtgResult.RowTemplate.Height = 24;
            this.dtgResult.Size = new System.Drawing.Size(672, 330);
            this.dtgResult.TabIndex = 2;
            // 
            // VistaPreviaNDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 399);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VistaPreviaNDForm";
            this.Text = "Vista Previa Resultados Notas de Descuento";
            this.Load += new System.EventHandler(this.VistaPreviaNDForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgResult;
    }
}