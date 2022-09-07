
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
    #endregion


    public partial class PanelForm :Form,IPanel
    {


        #region Attributes (atributos)
        public string codigo;
        public string NombreAuditor;

        private string Sucursal;
        private string Marca;
        private string Empresa;
        private string Encargado;
        private string Logotipo;
        private string Localidad;
        private string Clave;
        #endregion

        #region Properties (propiedades)


        public string sucursalText { get { return Sucursal; } set { Sucursal = value; } }
        public string marcaText { get { return Marca; } set { Marca = value; } }
        public string empresaText { get { return Empresa; } set { Empresa = value; } }
        public string encargadoText { get { return Encargado; } set { Encargado = value; } }
        public string localidadText { get { return Localidad; } set { Localidad = value; } }
        public string logotipoText { get { return Logotipo; } set { Logotipo = value; } }
        public string claveText { get { return Clave; } set { Clave = value; } }


        #endregion

        #region Events (eventos)
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form = new LoginForm();
            form.valor = 1;
            form.Show();
            
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
            ContratosForm contratosForm = new ContratosForm();
            contratosForm.loc = codigo;
            contratosForm.WindowState = FormWindowState.Maximized;
            contratosForm.ShowDialog();

        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
            InventariosForm inventariosForm = new InventariosForm();
            inventariosForm.loc = codigo;
            inventariosForm.WindowState = FormWindowState.Maximized;
            inventariosForm.ShowDialog();
        }
        private void metroTileItem3_Click(object sender, EventArgs e)
        {
            ApartadosForm apartadosForm = new ApartadosForm();
            apartadosForm.loc = codigo;
            apartadosForm.WindowState = FormWindowState.Maximized;
            apartadosForm.ShowDialog();

        }
        private void metroTileItem4_Click(object sender, EventArgs e)
        {
            ApartadosHistorialForm apartadosHistorialForm = new ApartadosHistorialForm();
            apartadosHistorialForm.loc = codigo;
            apartadosHistorialForm.WindowState = FormWindowState.Maximized;
            apartadosHistorialForm.ShowDialog();
        }
        private void metroTileItem5_Click(object sender, EventArgs e)
        {
            DepositosyRetiros depositosyRetiros = new DepositosyRetiros();
            depositosyRetiros.loc = codigo;
            depositosyRetiros.WindowState = FormWindowState.Maximized;
            depositosyRetiros.ShowDialog();
        }

        private void metroTileItem6_Click(object sender, EventArgs e)
        {
            BolsasForm bolsasForm = new BolsasForm();
            bolsasForm.loc = codigo;
            bolsasForm.WindowState = FormWindowState.Maximized;
            bolsasForm.ShowDialog();
        }

        //notas pago
        private void metroTileItem7_Click(object sender, EventArgs e)
        {
            NotasPagoForm notasPagoForm = new NotasPagoForm();
            notasPagoForm.loc = codigo;
            notasPagoForm.WindowState = FormWindowState.Maximized;
            notasPagoForm.ShowDialog();
        }

        //contratos aleatorios
        private void metroTileItem11_Click(object sender, EventArgs e)
        {
            Aleattorios2Form aleatoriosForm = new Aleattorios2Form();
            aleatoriosForm.loc = codigo;
            aleatoriosForm.WindowState = FormWindowState.Maximized;
            aleatoriosForm.ShowDialog();



          
        }
     
        //toma fisica
        private void metroTileItem10_Click(object sender, EventArgs e)
        {
            TomaFisicaForm tomaFisicaForm = new TomaFisicaForm();
            tomaFisicaForm.loc = codigo;
            tomaFisicaForm.WindowState = FormWindowState.Maximized;
            tomaFisicaForm.ShowDialog();
        }

        //inventario rev
        private void metroTileItem12_Click(object sender, EventArgs e)
        {
            RevInventariosForm revInventariosForm = new RevInventariosForm();
            revInventariosForm.loc = codigo;
            revInventariosForm.WindowState = FormWindowState.Maximized;
            revInventariosForm.ShowDialog();
        }


        //revision autpretamos
        private void metroTileItem9_Click(object sender, EventArgs e)
        {
            AutPrestForm autPrestForm = new AutPrestForm();
            autPrestForm.loc = codigo;
            autPrestForm.WindowState = FormWindowState.Maximized;
            autPrestForm.ShowDialog();
        }

        //promociones y descuento
        private void metroTileItem8_Click(object sender, EventArgs e)
        {
            PromDescForm promDescForm = new PromDescForm();
            promDescForm.loc = codigo;
            promDescForm.WindowState = FormWindowState.Maximized;
            promDescForm.ShowDialog();
        }
     
        #endregion

        #region Methods (metodos)
        public PanelForm()
        {
            InitializeComponent();
            
        }

        public void LoadForm()
        {
          
            PanelPresenter presenter = new PanelPresenter(this);
            presenter.LocalidadResult(codigo);
           
            //Data Localidad
            labelX1.Text = "Sucursal: " + Sucursal;
            labelX2.Text = "Marca: "+ Marca;
            labelX3.Text = "Empresa: " + Empresa;    
            labelX4.Text = "Localidad:" + Localidad;


            FileStream fs = new System.IO.FileStream(Logotipo, FileMode.Open, FileAccess.Read);
            pictureBox1.Image = Image.FromStream(fs);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            fs.Close();

            //Encargado auditado
            labelX5.Text = "Jefe de Sucursal: " + Encargado;
            //Nombre auditor
            labelX6.Text = "Auditor: " + NombreAuditor;
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
            ReporteRemisionesMNLForm form = new ReporteRemisionesMNLForm();
            form.empresa = Empresa;
            form.sucursal = Sucursal;
            form.nombreSucursal = Sucursal;
            form.encargado = Encargado;
            form.logo = Logotipo;
            form.NombreOperaciones = NombreAuditor;
            form.ShowDialog();
        }

        private void metroTileItem13_Click(object sender, EventArgs e)
        {
            NotasPagoConDepositoForm form = new NotasPagoConDepositoForm();
            form.empresa = Empresa;
            form.sucursal = Sucursal;
            form.nombreSucursal = Sucursal;
            form.encargado = Encargado;
            form.logo = Logotipo;
            form.NombreOperaciones = NombreAuditor;
            form.ShowDialog();
        }
    }
}
