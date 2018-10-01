

namespace AudSemp
{
    using AudSemp.Views;
    using AudSemp.Presenter;
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
    #endregion

    public partial class LoginForm : Form , IRectangle
    {
        public string LengthText {
            get { return txtLenght.Text; }
            set { txtLenght.Text = value; } 
        }
        public string BreadthText {
            get { return txtBreadth.Text; }
            set { txtBreadth.Text = value; }
        }
        public string AreaText {

            get
            {
                return txtArea.Text;

            }
            set
            {
                txtArea.Text = value +"sq";
            }
        }

        #region Context (Conexion)

        #endregion

        #region Events (Eventos)
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Methods (Metodos)
        public LoginForm()
        {
            InitializeComponent();
        }


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            RectanglePresenter presenter = new RectanglePresenter(this);
            presenter.CalculateArea();

        }
    }
}
