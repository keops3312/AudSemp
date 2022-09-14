using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudSemp.Forms
{
    public partial class VistaPreviaNDForm : Form
    {

        public DataTable dt;

        public VistaPreviaNDForm()
        {
            InitializeComponent();
        }

        private void VistaPreviaNDForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (dt.Rows.Count == 0)
                {


                    MessageBox.Show("No Existe Resultado Previo!", "Auditoria SEMP",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                dtgResult.DataSource = dt;

                dtgResult.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgResult.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);


                dtgResult.Columns[8].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[8].DefaultCellStyle.ForeColor = Color.DarkBlue;
                dtgResult.Columns[8].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

              //
                dtgResult.Columns[9].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[9].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[9].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[10].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[10].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[10].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[11].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[11].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[11].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                //
                dtgResult.Columns[12].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[12].DefaultCellStyle.ForeColor = Color.DarkOrange;
                dtgResult.Columns[12].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[13].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[13].DefaultCellStyle.ForeColor = Color.DarkOrange;
                dtgResult.Columns[13].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[14].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[14].DefaultCellStyle.ForeColor = Color.DarkOrange;
                dtgResult.Columns[14].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);


                dtgResult.Columns[16].DefaultCellStyle.Format = "N0";
                dtgResult.Columns[16].DefaultCellStyle.ForeColor = Color.DarkSlateBlue;
                dtgResult.Columns[16].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[17].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[17].DefaultCellStyle.ForeColor = Color.DarkSlateBlue;
                dtgResult.Columns[17].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);



           
                dtgResult.Columns[22].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[22].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[22].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[26].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[26].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[26].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[30].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[30].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[30].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);



            }
            catch (Exception ex)
            {
                string _error = ex.Message;

            }
        }
    }
}
