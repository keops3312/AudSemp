
//Panel form to control Auditory System Panel Principal
namespace AudSemp.Forms
{
    #region Libraries (librerias)
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


    public partial class PanelForm : Form
    {

        #region Events (eventos)
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form=new LoginForm();
            form.Show();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public PanelForm()
        {
            InitializeComponent();
        }


        //Panel Control

         private void PanelContratos_Click(object sender, EventArgs e)
        {
            ContratosForm contratosForm = new ContratosForm();
            contratosForm.WindowState = FormWindowState.Maximized;
            contratosForm.ShowDialog();
            
        }

        #endregion


        #region Properties (propiedades)

        #endregion

        #region Methods (metodos)

        #endregion


        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {

        }

        private void expandablePanel4_Click(object sender, EventArgs e)
        {

        }

        private void metroTilePanel1_ItemClick(object sender, EventArgs e)
        {

        }

        private void PanelForm_Load(object sender, EventArgs e)
        {

        }
    }
}
