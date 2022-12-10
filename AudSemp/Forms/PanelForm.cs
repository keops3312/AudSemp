
//Panel form to control Auditory System Panel Principal
namespace AudSemp.Forms
{

    #region Libraries (librerias) 
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using AudSemp.Presenter;
    using AudSemp.Views;
    using OperSemp.Commons.Entities;
    #endregion


    public partial class PanelForm :Form//,IPanel
    {


        #region Attributes (atributos)
        public User user;
        public string _value;
        #endregion


        #region Events (eventos)
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }


        //Panel Contratos
        private void PanelContratos_Click(object sender, EventArgs e)
        {
            ContratosForm Form = new ContratosForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();

        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
            InventariosForm Form = new InventariosForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }
        private void metroTileItem3_Click(object sender, EventArgs e)
        {
            ApartadosForm Form = new ApartadosForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();

        }
        private void metroTileItem4_Click(object sender, EventArgs e)
        {
            ApartadosHistorialForm Form = new ApartadosHistorialForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }
        private void metroTileItem5_Click(object sender, EventArgs e)
        {
            DepositosyRetiros Form = new DepositosyRetiros(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }

        private void metroTileItem6_Click(object sender, EventArgs e)
        {
            BolsasForm Form = new BolsasForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }

        //notas pago
        private void metroTileItem7_Click(object sender, EventArgs e)
        {
            NotasPagoForm Form = new NotasPagoForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }

        //contratos aleatorios
        private void metroTileItem11_Click(object sender, EventArgs e)
        {
            Aleattorios2Form Form = new Aleattorios2Form(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();




        }
     
        //toma fisica
        private void metroTileItem10_Click(object sender, EventArgs e)
        {
            TomaFisicaForm Form = new TomaFisicaForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }

        //inventario rev
        private void metroTileItem12_Click(object sender, EventArgs e)
        {
            RevInventariosForm Form = new RevInventariosForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }


        //revision autpretamos
        private void metroTileItem9_Click(object sender, EventArgs e)
        {
            AutPrestForm Form = new AutPrestForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }

        //promociones y descuento
        private void metroTileItem8_Click(object sender, EventArgs e)
        {
            PromDescForm Form = new PromDescForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }
     
        #endregion

        #region Methods (metodos)
        public PanelForm()
        {
            InitializeComponent();
            
        }

        public void LoadForm()
        {
          
      
            try
            {
                labelX1.Text = "Sucursal: " + user.Loc;
                labelX2.Text = "Marca: " + user.Marca;
                labelX3.Text = "Empresa: " + user.Empresa;
                labelX4.Text = "Localidad:" + user.NameLoc;
                labelX5.Text = "Jefe de Sucursal: " + user.Boss;
                labelX6.Text = "Auditor: " + user.Name;


                FileStream fs = new System.IO.FileStream(user.Logotipo, FileMode.Open, FileAccess.Read);
                pictureBox1.Image = Image.FromStream(fs);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                fs.Close();

            }
            catch (Exception)
            {

                MessageBox.Show("Error al cargar panel", "Aud Semp",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region trash
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

      




        #endregion

        private void btnMNLremisiones_Click(object sender, EventArgs e)
        {
         
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            ReporteRemisionesMNLForm Form = new ReporteRemisionesMNLForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }

        private void metroTileItem13_Click(object sender, EventArgs e)
        {
            NotasPagoConDepositoForm Form = new NotasPagoConDepositoForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }

        private void metroTileItem14_Click(object sender, EventArgs e)
        {

        }

        private void metroTileItem14_Click_1(object sender, EventArgs e)
        {
            NotasDeDescuentoForm Form = new NotasDeDescuentoForm(_value);
            Form.user = user;
            Form.cadena = _value;
            Form.WindowState = FormWindowState.Maximized;
            Form.ShowDialog();
        }
    }
}
