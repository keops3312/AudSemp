
namespace AudSemp.Forms
{

    #region Libraries
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    #endregion


    public partial class VistaPreviaDepoNpForm : Form
    {
        #region Properties
        public DataTable dt;
        #endregion

        #region Constructor
        public VistaPreviaDepoNpForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events
        private void VistaPreviaDepoNpForm_Load(object sender, EventArgs e)
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

                //Factura
                //dtgResult.Columns[0].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[0].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[0].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                //Fecha
                dtgResult.Columns[1].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[1].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[1].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);


                //contrato bolsa folio
                dtgResult.Columns[3].DefaultCellStyle.ForeColor = Color.DarkRed;
                dtgResult.Columns[3].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[4].DefaultCellStyle.ForeColor = Color.DarkRed;
                dtgResult.Columns[4].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[5].DefaultCellStyle.ForeColor = Color.DarkRed;
                dtgResult.Columns[5].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                //imp iva total
                dtgResult.Columns[6].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[6].DefaultCellStyle.ForeColor = Color.DarkBlue;
                dtgResult.Columns[6].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[7].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[7].DefaultCellStyle.ForeColor = Color.DarkBlue;
                dtgResult.Columns[7].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[8].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[8].DefaultCellStyle.ForeColor = Color.DarkBlue;
                dtgResult.Columns[8].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                //abono r-d
                dtgResult.Columns[10].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[10].DefaultCellStyle.ForeColor = Color.Purple;
                dtgResult.Columns[10].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[11].DefaultCellStyle.ForeColor = Color.Purple;
                dtgResult.Columns[11].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);


                //gastos, desc, total gastos
                dtgResult.Columns[15].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[15].DefaultCellStyle.ForeColor = Color.DarkOrange;
                dtgResult.Columns[15].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[16].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[16].DefaultCellStyle.ForeColor = Color.DarkOrange;
                dtgResult.Columns[16].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[17].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[17].DefaultCellStyle.ForeColor = Color.DarkOrange;
                dtgResult.Columns[17].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);


                //desc preferente
                dtgResult.Columns[18].DefaultCellStyle.ForeColor = Color.Blue;
                dtgResult.Columns[18].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                //fecha auditado
                dtgResult.Columns[21].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[21].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[21].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                //fecha revisado
                dtgResult.Columns[25].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[25].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[25].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

            }
            catch (Exception ex)
            {
                string _error = ex.Message;

            }
        }
        #endregion

    }
}
