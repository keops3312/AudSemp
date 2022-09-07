

namespace OperSemp.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    public partial class VistaPreviaMNLForm : Form
    {

        public DataTable dt;


        public VistaPreviaMNLForm()
        {
            InitializeComponent();
        }

        private void VistaPreviaMNLForm_Load(object sender, EventArgs e)
        {

            try
            {
                if (dt.Rows.Count == 0)
                {


                    MessageBox.Show("No Existe Resultado Previo!", "Operaciones SEMP",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                dtgResult.DataSource = dt;

                dtgResult.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgResult.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);


                dtgResult.Columns[4].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[4].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[4].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[5].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[5].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[5].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[6].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[6].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[6].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);


                dtgResult.Columns[21].DefaultCellStyle.Format = "N0";
                dtgResult.Columns[21].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[21].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[22].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[22].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[22].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[23].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[23].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[23].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[25].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[25].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[25].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);


                dtgResult.Columns[29].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[29].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[29].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[33].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[33].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[33].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[1].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[1].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[1].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);


                
              

            }
            catch (Exception ex)
            {
                string _error = ex.Message;
                
            }
        }
    }
}
