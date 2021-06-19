using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperSemp.Forms
{
    public partial class MNLAutorizarForm : Form
    {

        public string _status;
        public string _comentario;
        public string _inventario;
        public string _Data;
        public RevisarMNLAutorizarForm MyForm;



        public string _inv;
        public string _desc;
        public string _rem;
        public string _fec;
        public string _sta;
        public string _cli;
        public string _ven;
        public string _caj;
        public string _tip;
        public string _precioOriginal;
        public string _remate;
        public string _promocion;
        public string _man;
        public string _importeTotal;


        public MNLAutorizarForm()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboStatus.Text))
                {

                    MessageBox.Show("No has Seleccionado Status!" 
                   , "Operaciones SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                if (string.IsNullOrEmpty(txtComentario.Text))
                {

                    MessageBox.Show("No has ingresado un Comentario!"
                   , "Operaciones SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                MyForm.Update(_inventario,txtComentario.Text,cboStatus.Text,_status);

                this.Close();


            }
            catch (Exception ex)
            {

                string _error=ex.Message;
            }
        }

        private void MNLAutorizarForm_Load(object sender, EventArgs e)
        {
           // txtDataInventario.Text = _Data;
            cboStatus.Items.Add("NOA(NO AUDITADO)");
            cboStatus.Items.Add("AUD(AUDITADO)");
            cboStatus.Items.Add("STB(PENDIENTE CON DETALLE)");
            
            label2.Text = _inv;
            label3.Text = _desc;
            label4.Text = _rem;
            label5.Text = _fec;
            label6.Text = _sta;
            label7.Text = _cli;
            label8.Text = _ven;
            label9.Text = _caj;
            label10.Text = _tip;
            label11.Text = _precioOriginal;
            label12.Text = _remate;
            label13.Text = _promocion;
            label14.Text = _importeTotal;
            label16.Text = _man;








        }
    }
}
