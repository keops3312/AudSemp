using AudSemp.Classes;
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
    public partial class VistaPreviaForm : DevComponents.DotNetBar.OfficeForm
    {


        public string leyenda;
        public DataTable vistaM;
      

        public VistaPreviaForm()
        {
            InitializeComponent();
            
        }

        private void VistaPreviaForm_Load(object sender, EventArgs e)
        {
            this.Text = leyenda;
            labelX1.Text = leyenda;
          
            
            dataGridViewX1.DataSource = vistaM;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
