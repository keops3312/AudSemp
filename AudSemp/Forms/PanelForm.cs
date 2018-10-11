
//Panel form to control Auditory System Panel Principal
namespace AudSemp.Forms
{
  
    #region Libraries (librerias)
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using AudSemp.Models;
    using AudSemp.Presenter;
    using AudSemp.Views;
    #endregion


    public partial class PanelForm : Form,IPanel
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

       
    }
}
