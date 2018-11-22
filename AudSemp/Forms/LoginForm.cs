
//Form To Controlled for Logical Login (MVP) 
namespace AudSemp
{
  
    #region Libraries(librerias)
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using AudSemp.Forms;
    using AudSemp.Views;
    using AudSemp.Presenter;
    using AudSemp.Classes;  
    #endregion

    public partial class LoginForm : Form,IRectangle,ILogin
    {
        #region Context
        private LocationConexion locationConexion;
        private BuscarLocalidad buscarLocalidad;
        public LoginForm()
        {

            InitializeComponent();
            locationConexion = new LocationConexion();
          
            backgroundWorker1.WorkerReportsProgress = true;

            backgroundWorker1.WorkerSupportsCancellation = true;


        }

        #endregion



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
        public int valor;
        String[] result;

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
            
            if (valor == 1)
            {
                buscarLocalidad = new BuscarLocalidad();
                circularProgress1.Visible =false;
                circularProgress1.IsRunning = false;
                circularProgress1.ProgressText = "";
                String[] find =  buscarLocalidad.LocalidadBuscada();
                    labelX2.Text = "Conexion Encontrada...\n" +
                     "Nom: " + find[0].ToString() + "\n" +
                     "Localidad: " + find[1].ToString() + "\n" +
                     "Direccion: " + find[2].ToString();
                    //backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                btnAcces.Enabled = false;
                circularProgress1.Visible = true;
                circularProgress1.IsRunning = true;
                circularProgress1.ProgressText = "Buscando...";
                backgroundWorker1.RunWorkerAsync();
            }
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



        public void buscar()
        {
            result = locationConexion.Scan();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            buscar();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            circularProgress1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            circularProgress1.Visible = false;
            circularProgress1.IsRunning = false;
            btnAcces.Enabled = true;
            labelX2.Text = "Conexion Encontrada...\n" +
            "Nom: " + result[0].ToString() + "\n" +
            "Localidad: " + result[1].ToString() + "\n" +
            "Direccion: " + result[2].ToString();
        }


        #endregion

        #region Methods (Metodos)

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
