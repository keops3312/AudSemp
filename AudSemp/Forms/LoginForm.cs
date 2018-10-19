
//Form To Controlled for Logical Login (MVP) 
namespace AudSemp
{
  
    #region Libraries(librerias)
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using AudSemp.Forms;
    using AudSemp.Views;
    using AudSemp.Presenter;
    using System.IO;
    using AudSemp.Classes;
    using System.Threading;
    #endregion

    public partial class LoginForm : Form,IRectangle,ILogin
    {

        #region Example
        public string LengthText
        {
            get { return txtLenght.Text; }
            set { txtLenght.Text = value; }
        }
        public string BreadthText
        {
            get { return txtBreadth.Text; }
            set { txtBreadth.Text = value; }
        }
        public string AreaText
        {

            get
            {
                return txtArea.Text;

            }
            set
            {
                txtArea.Text = value + "sq";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RectanglePresenter presenter = new RectanglePresenter(this);
            presenter.CalculateArea();

        }
        #endregion

        #region Attributes
        private int Response;
        private string Clave;
        private string NombreAuditor;

        public string userText
        {
            get { return txtUser.Text; }
            set { txtUser.Text = value; }
        }
        public string passwordText
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
        public int response
        {

            get
            {
                return Response;

            }
            set
            {
                Response = value;
            }
        }

        public string clave {
            get
            {
                return Clave;
            }
            set
            {
                Clave = value;
            }
        }

        public string nombreAuditor {
            get
            {
                return NombreAuditor;
            }
            set
            {
                NombreAuditor = value;
            }
        }



        #endregion

        #region Events (Eventos)
        private void Form1_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
            //Search of local
            LocationConexion locationConexion = new LocationConexion();

            String[] result;
            result = locationConexion.Scan();
            labelX2.Text = "Conexion Encontrada...\n" +
            "Nom: " + result[0].ToString() + "\n" +
            "Localidad: " + result[1].ToString() + "\n" +
            "Direccion: " + result[2].ToString();
        }

        

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnAcces_Click(object sender, EventArgs e)
        {
            AccessLogin();
        }

        #endregion

        #region Methods (Metodos)
        public LoginForm()
        {
            InitializeComponent();
        }
        private void AccessLogin()
        {
            LoginPresenter presenter = new LoginPresenter(this);
            presenter.Acces();
            Response = response;
            presenter.Claves();
            Clave = clave;
            presenter.Nombre();
            NombreAuditor = nombreAuditor;

            switch (Response)
            {
                case 1:
                    MessageBox.Show("Ingrese Usuario", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUser.Focus();
                    break;
                case 2:
                    MessageBox.Show("Ingrese Password", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Focus();
                    break;
                case 3:
                    MessageBox.Show("Complete los Campos Por favor", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUser.Focus();
                    break;
                case 4:
                    MessageBox.Show("Usuario y/o Contraseña Incorrectos", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUser.Focus();
                    break;
                case 5:
                    MessageBox.Show("No Tienes Nivel Suficiente para esta Aplicacion", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUser.Focus();
                    break;
                case 6:
                    MessageBox.Show("Tu usuario esta en USO / Bloqueado", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUser.Focus();
                    break;
                case 404:
                    MessageBox.Show("Error de Sistema", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                    break;
                case 9000:
                    //Acces 

                    PanelForm form = new PanelForm();
                    form.codigo = Clave;
                    form.NombreAuditor = NombreAuditor;
                    this.Hide();
                    form.Show();


                    break;

                default:
                    break;
            }


            //1 Empty User
            //2 Empty password
            //3 Empty all field
            //4 user or password incorrect
            //5 Incompatible level user
            //6 bloqued user
            // 9000 Acces ok!
            // 404 Failed Connection
        }


        #endregion

       
    }
}
