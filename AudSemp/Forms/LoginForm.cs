
//Form To Controlled for Logical Login (MVP) 
namespace AudSemp
{

    #region Libraries(librerias)  
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using AudSemp.Forms;
    using OperSemp.Commons.Entities;
    using OperSemp.Commons.Helper;
    #endregion

    public partial class LoginForm : Form//,//IRectangle,ILogin
    {
      

        #region Attributes
        ILoginHelper loginHelper;
        IConectionHelper conectionHelper;
        User _userAcces;
        #endregion

        #region Constructor
        public LoginForm()
        {

            InitializeComponent();
            loginHelper = new OperSemp.Commons.Helper.LoginHelper();
        }

        #endregion


        #region Properties
        private string user = string.Empty;
        private string password = string.Empty;
        private bool response;
        private string _stringValue;
        private Response _response;

        private string serverId;
        private string databaseId;
        private string userId;
        private string passwordId;
        private string _MySqlstringValue;
        private string _MySqlstringValueLoc;
        int changeCombo = 0;

        #endregion

    

        #region Events (Eventos)
        private async void Form1_Load(object sender, EventArgs e)
        {


            try
            {
                circularProgress1.Visible = false;
                _MySqlstringValue = await MySQLTestConnection();

                if (_MySqlstringValue.Contains("400"))
                {
                    MessageBox.Show("La conexión fallo! ó no es autentica", "Aud Semp",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (cmbSucursales.Items.Count == 0)
                {
                    cmbSucursales.DataSource = MySQLPlaces(_MySqlstringValue);
                    cmbSucursales.SelectedIndex = cmbSucursales.Items.Count - 1;
                    changeCombo = 1;
                }

                txtUser.Focus();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Fallo al cargar sistema " + ex.Message, "Aud Semp",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
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
            CheckAcces();
           
        }

        private void cmbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changeCombo > 0)
            {

                response = cmbSucursales.Text != "Seleccione Sucursal" ? true : false;
                if (response)
                {

                    circularProgress1.Visible = true;
                    circularProgress1.IsRunning = true;
                    this.Enabled = false;
                    serverId = "";
                    userId = "";
                    passwordId = "";
                    databaseId = "";


                    conectionHelper = new ConectionHelper();
                    Finder finder = new Finder();
                    finder = conectionHelper.finder(_MySqlstringValue, cmbSucursales.Text.Trim());
                    serverId = finder.FinderA;
                    databaseId = finder.FinderB;
                    userId = finder.FinderC;
                    passwordId = finder.FinderD;
                    _MySqlstringValueLoc = string.Empty;

                    _MySqlstringValueLoc = conectionHelper.MySqlGetConnectionNotAsync(false, serverId, userId, passwordId, databaseId);

                    if (_MySqlstringValueLoc == "400")
                    {
                        MessageBox.Show("Posibles Causas: \n" +
                                          "La conexión fallo! \n" +
                                          "Seleccionaste mal la sucursal \n" +
                                          "No te conectaste al modem del servidor \n", "Aud Semp",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                        _MySqlstringValueLoc = string.Empty;
                        //return;
                    }
                    this.Enabled = true;
                    circularProgress1.Visible = false;
                    circularProgress1.IsRunning = false;



                }

            }
        }
        #endregion



        #region Methods
        private async void CheckAcces()
        {
            try
            {



                response = string.IsNullOrEmpty(txtUser.Text) ? true : false;


                if (response)
                {
                    MessageBox.Show("Ingresa el usuario por favor", "Aud Semp",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }



                response = string.IsNullOrEmpty(txtPassword.Text) ? true : false;

                if (response)
                {
                    MessageBox.Show("Ingresa tu contraseña por favor", "Aud Semp",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                response = cmbSucursales.Text.Contains("Seleccione Sucursal") ? true : false;

                if (response)
                {
                    MessageBox.Show("Seleccione la sucursal por favor", "Aud Semp",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }







                user = txtUser.Text.Trim();
                password = txtPassword.Text.Trim();


                _stringValue = await TestConnection();

                if (_stringValue.Contains("400"))
                {
                    MessageBox.Show("La conexión fallo! ó no es autentica", "Aud Semp",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }



                _response = new Response();
                _response = await CheckUser(_stringValue);

                if (_response.userResponse == "400")
                {
                    MessageBox.Show("Error en usuario / Contraseña o no tiene el nivel para entrar", "Aud Semp",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                //Catch Data Employee
                _userAcces = new User();
                _userAcces = await Employee(_response);

                if (_userAcces == null)
                {
                    MessageBox.Show("No encuentro datos del usuario y/o de la localidad", "Aud Semp",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                MessageBox.Show("Bienvenido: " + _userAcces.Name + "!", "Aud Semp",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);




                PanelForm panelForm = new PanelForm();
                panelForm.user = _userAcces;
                panelForm._value = _stringValue;
                panelForm.ShowDialog();





            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Oper Semp",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> TestConnection()
        {

            conectionHelper = new ConectionHelper();

            return await conectionHelper.ConectionAsync(serverId, userId, passwordId, databaseId);
        }

        private async Task<string> MySQLTestConnection()
        {
            conectionHelper = new ConectionHelper();
            return await conectionHelper.MySqlGetConnection(true, null, null, null, null);
        }

        private List<string> MySQLPlaces(string value)
        {


            conectionHelper = new ConectionHelper();
            List<string> strings = new List<string>();
            strings = conectionHelper.MySqlPlaces(value);
            if (strings != null)
            {
                strings.Add("Seleccione Sucursal");
                return strings;
            }
            return null;


        }

        private async Task<Response> CheckUser(string _value)
        {
            loginHelper.PutConnection(_value);
            return await loginHelper.LoginAsync(user, password);
        }

        private async Task<User> Employee(Response response)
        {

            return await loginHelper.DataUserAsync(response);
        }

        #endregion




        #region trash
        #region Context
        //private LocationConexion locationConexion;
        //private BuscarLocalidad buscarLocalidad;

        #endregion
        #region Example
        //public string LengthText
        //{
        //    get { return txtLenght.Text; }
        //    set { txtLenght.Text = value; }
        //}
        //public string BreadthText
        //{
        //    get { return txtBreadth.Text; }
        //    set { txtBreadth.Text = value; }
        //}
        //public string AreaText
        //{

        //    get
        //    {
        //        return txtArea.Text;

        //    }
        //    set
        //    {
        //        txtArea.Text = value + "sq";
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    RectanglePresenter presenter = new RectanglePresenter(this);
        //    presenter.CalculateArea();

        //}
        #endregion

        #region Attributes
        //private int Response;
        //private string Clave;
        //private string NombreAuditor;
        //public int valor;
        //String[] result;

        //public string userText
        //{
        //    get { return txtUser.Text; }
        //    set { txtUser.Text = value; }
        //}
        //public string passwordText
        //{
        //    get { return txtPassword.Text; }
        //    set { txtPassword.Text = value; }
        //}
        //public int response
        //{

        //    get
        //    {
        //        return Response;

        //    }
        //    set
        //    {
        //        Response = value;
        //    }
        //}

        //public string clave
        //{
        //    get
        //    {
        //        return Clave;
        //    }
        //    set
        //    {
        //        Clave = value;
        //    }
        //}

        //public string nombreAuditor
        //{
        //    get
        //    {
        //        return NombreAuditor;
        //    }
        //    set
        //    {
        //        NombreAuditor = value;
        //    }
        //}



        #endregion

        //private void AccessLogin()
        //{
        //    //LoginPresenter presenter = new LoginPresenter(this);
        //    //presenter.Acces();
        //    //Response = response;
        //    //presenter.Claves();
        //    //Clave = clave;
        //    //presenter.Nombre();
        //    //NombreAuditor = nombreAuditor;

        //    //switch (Response)
        //    //{
        //    //    case 1:
        //    //        MessageBox.Show("Ingrese Usuario", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //        txtUser.Focus();
        //    //        break;
        //    //    case 2:
        //    //        MessageBox.Show("Ingrese Password", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //        txtPassword.Focus();
        //    //        break;
        //    //    case 3:
        //    //        MessageBox.Show("Complete los Campos Por favor", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //        txtUser.Focus();
        //    //        break;
        //    //    case 4:
        //    //        MessageBox.Show("Usuario y/o Contraseña Incorrectos", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //        txtUser.Focus();
        //    //        break;
        //    //    case 5:
        //    //        MessageBox.Show("No Tienes Nivel Suficiente para esta Aplicacion", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    //        txtUser.Focus();
        //    //        break;
        //    //    case 6:
        //    //        MessageBox.Show("Tu usuario esta en USO / Bloqueado", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    //        txtUser.Focus();
        //    //        break;
        //    //    case 404:
        //    //        MessageBox.Show("Error de Sistema", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //        Application.Exit();
        //    //        break;
        //    //    case 9000:
        //    //        //Acces 

        //    //        PanelForm form = new PanelForm();
        //    //        form.codigo = Clave;
        //    //        form.NombreAuditor = NombreAuditor;
        //    //        this.Hide();
        //    //        form.Show();


        //    //        break;

        //    //    default:
        //    //        break;
        //    //}


        //    //1 Empty User
        //    //2 Empty password
        //    //3 Empty all field
        //    //4 user or password incorrect
        //    //5 Incompatible level user
        //    //6 bloqued user
        //    // 9000 Acces ok!
        //    // 404 Failed Connection
        //}

        //public void buscar()
        //{
        //    result = locationConexion.Scan();
        //}

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            //buscar();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           // circularProgress1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //circularProgress1.Visible = false;
            //circularProgress1.IsRunning = false;
            //btnAcces.Enabled = true;
            //labelX2.Text = "Conexion Encontrada...\n" +
            //"Nom: " + result[0].ToString() + "\n" +
            //"Localidad: " + result[1].ToString() + "\n" +
            //"Direccion: " + result[2].ToString();
        }


        #endregion

     
    }
}
