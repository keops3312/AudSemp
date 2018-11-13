

namespace AudSemp.Forms
{
    using AudSemp.Classes;
    using AudSemp.Context;

    #region Libraries (libreria)
    using System;
    using System.Windows.Forms;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;
    #endregion
    public partial class TomaFisicaForm : Form
    {
        #region Context
        private SEMP2013_Context db;
        public TomaFisicaForm()
        {
            db = new SEMP2013_Context();
            InitializeComponent();
        }







        #endregion

        #region Events (Eventos)
        private void TomaFisicaForm_Load(object sender, EventArgs e)
        {
            cmbTypeOfAud.Items.Add("Auditar Contratos");
            cmbTypeOfAud.Items.Add("Auditar Bolsas");
            cmbTypeOfAud.Items.Add("Auditar Inventarios");

        }

        #endregion

        #region Methods (Metodos)

        #endregion

        private void buttonX3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();


                openFD.Title = "Seleccionar archivos";
                openFD.Filter = "Todos los archivos (*.xlsx)|*.xlsx";
                openFD.Multiselect = false;
                DialogResult result = openFD.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                txtRuta.Text = openFD.FileName;
                }





        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            Audtoma toma = new Audtoma();
            int option=0;
            if (cmbTypeOfAud.Text == "Auditar Contratos") { option = 1; };
            if (cmbTypeOfAud.Text == "Auditar Bolsas") { option = 2; };
            if (cmbTypeOfAud.Text == "Auditar Inventarios") { option = 3; }; 




            ResGrid.DataSource = toma.AudPhisycal(txtRuta.Text, txtHoja.Text, option);
        }
    }
}
