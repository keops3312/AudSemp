using AudSemp.Context;
using AudSemp.Models;
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
    public partial class RevisarNPconDepositoForm : Form
    {


        public DataTable dt;
        public List<facturas> lista;
        public string nombreOperaciones;
        private AutorizaNotaPagoConDepositoModel model;

        public string _status;
        public string _comentario;
        public string _inventario;
        public RevisarNPconDepositoForm()
        {
            InitializeComponent();
        }

        private void RevisarNPconDepositoForm_Load(object sender, EventArgs e)
        {
            try
            {

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Genere un Ejercicio Primero de tipo excel o reporte comenzar a Revisar",
                        "Operaciones SEMP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                if (dtgResult.Columns.Count == 0)
                {
                    dtgResult.Columns.Add("Factura", "NP");
                    dtgResult.Columns.Add("Fecha", "FechaFact");
                    dtgResult.Columns.Add("Contrato", "Contrato");//clic y muestra datos
                    dtgResult.Columns.Add("Total", "Total");
                    dtgResult.Columns.Add("GastoOp", "GastosOperacion");
                    dtgResult.Columns.Add("Abono", "Abono");
                    dtgResult.Columns.Add("DescPreferente", "DescPreferente");
                    dtgResult.Columns.Add("Auditado", "ST.Auditado");//click y muestra datos
                    dtgResult.Columns.Add("Autorizado", "ST.Autorizado");//click y muestra datos
                    dtgResult.Columns.Add("Id", "ID");//click y muestra datos



                }
                dtgResult.Columns[9].Visible = false; //click y muestra datos

                foreach (var item in lista)
                {
                    dtgResult.Rows.Add(item.Factura, item.FechaFact, item.Contrato, item.TotalFact, item.total_gastos_op,
                        item.Abono, item.descuento_preferente + "%", item.auditado, item.autorizado, item.NO);
                }


                DataGridViewImageColumn btnA = new DataGridViewImageColumn();
                btnA.Name = "RevAuditoria";
                btnA.HeaderText = "Rev. Auditoria";
                dtgResult.Columns.Add(btnA);



                DataGridViewImageColumn btnB = new DataGridViewImageColumn();
                btnB.Name = "Autorizar";
                btnB.HeaderText = "Autorizar";
                dtgResult.Columns.Add(btnB);


                foreach (DataGridViewRow fila in dtgResult.Rows)
                {
                    //fila.Cells["ImagenL"].Value =
                    //System.Drawing.Image.FromFile("C:\\SEMP2013\\OperSemp\\OperSemp\\Resources\\UpdateSmall.fw.png");


                    fila.Cells["Autorizar"].Value =
                  System.Drawing.Image.FromFile("C:\\SEMP2013\\AudSemp\\AudSemp\\Resources\\verSmall.fw.png");


                    fila.Cells["RevAuditoria"].Value =

                    System.Drawing.Image.FromFile("C:\\SEMP2013\\AudSemp\\AudSemp\\Resources\\UpdateSmall.fw.png");
                }

                dtgResult.Columns["Autorizar"].Width = 100;

                dtgResult.Columns[3].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[3].DefaultCellStyle.ForeColor = Color.DarkRed;
                dtgResult.Columns[3].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);


                dtgResult.Columns[4].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[4].DefaultCellStyle.ForeColor = Color.DodgerBlue;
                dtgResult.Columns[4].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[5].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[5].DefaultCellStyle.ForeColor = Color.DarkRed;
                dtgResult.Columns[5].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);


               
                dtgResult.Columns[6].DefaultCellStyle.ForeColor = Color.DarkRed;
                dtgResult.Columns[6].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);



                dtgResult.Columns[1].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[1].DefaultCellStyle.ForeColor = Color.OrangeRed;
                dtgResult.Columns[1].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[1].Width = 100;

            }
            catch (Exception ex)
            {
                string _error = ex.Message;
            }
        }

        private void dtgResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int fila;
                fila = e.RowIndex;
                string Factura;
                string abono;
                //auditar
                if (e.ColumnIndex == 0)//boton informacion raiz
                {

                    Factura = dtgResult.Rows[fila].Cells[0].Value.ToString();
                    var datosAuditoria = lista.Where(p => p.Factura == Factura).FirstOrDefault();

                    MessageBox.Show("Detalles de Auditoria:\n" +
                        "Auditor: " + datosAuditoria.audita + "\n" +
                        "Status: " + datosAuditoria.auditado + "\n" +
                        "Fecha: " + DateTime.Parse(datosAuditoria.fechaAuditado.ToString()).ToString("ddd dd MMMM yyyy") + "\n" +
                        "Comentario: " + datosAuditoria.comentarioAuditado + "\n", "Operaciones SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }


                //ver Detalles de Inventario
                if (e.ColumnIndex == 10)//boton informacion raiz
                {

                    Factura = dtgResult.Rows[fila].Cells[0].Value.ToString();
                    var datos = lista.Where(p => p.Factura == Factura).FirstOrDefault();
                  
                 

                    if (datos.Abono.ToString() == null || datos.Abono.ToString().Length==0)
                    {
                        abono = "0";
                    }
                    else
                    {
                        abono = datos.Abono.ToString();
                    }


                    MessageBox.Show("Detalles de Nota de Pago:\n" +
                        "Factura: " + datos.Factura + "\n" +
                        "Contrato: " + datos.Contrato + "\n" +
                        "Bolsa: " + datos.Bolsa + "\n" +
                        "Fecha de Nota: " + DateTime.Parse(datos.FechaFact.ToString()).ToString("ddd dd MMMM yyyy") + "\n" +
                        "Status: " + datos.STATUS + "\n" +
                        "Cliente: " + datos.IdCliente + "\n" +
                        "Cajero: " + datos.realizo + "\n" +
                        "Caja: " + datos.caja + "\n" +
                        "Tipo: " + datos.R_D + "\n" +
                        "------Conceptos---- " + "\n" +
                        "TOTAL FACTURA: " + decimal.Parse(datos.TotalFact.ToString()).ToString("C2") + "\n" +
                        "ABONOS: " +  decimal.Parse(abono).ToString("C2")+ "\n" +
                        "GASTOS OPERACION: " + decimal.Parse(datos.total_gastos_op.ToString()).ToString("C2") + "\n" +
                        "DESC. PREFERENTE: " + datos.descuento_preferente + "%" + "\n" 
                        , "Operaciones SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }

                //actualizar
                if (e.ColumnIndex == 11)//boton informacion raiz
                {
                    Factura = dtgResult.Rows[fila].Cells[9].Value.ToString();
                    var datos = lista.Where(p => p.NO == int.Parse(Factura)).FirstOrDefault();

                    if (datos.Abono.ToString() == null || datos.Abono.ToString().Length == 0)
                    {
                        abono = "0";
                    }
                    else
                    {
                        abono = datos.Abono.ToString();
                    }


                    MNLAutorizarForm form = new MNLAutorizarForm();
                    form._comentario = "";
                    form.MyFormNP = this;
                    form._status = datos.STATUS; //consec
                    form._inventario = datos.NO.ToString();
                    form._optionUpdate = 1;
                    //--------------------------------------//
                    form._inv = "Factura: " + datos.Factura;
                    form._desc = "Contrato: " + datos.Contrato;
                    form._rem = "Bolsa: " + datos.Bolsa;
                    form._fec = "Fecha: " + DateTime.Parse(datos.FechaFact.ToString()).ToString("ddd dd MMMM yyyy");
                    form._sta = "Status: " + datos.STATUS;
                    form._cli = "Cliente: " + datos.IdCliente;
                    form._ven = "Cajero: " + datos.realizo;
                    form._caj = "Caja: " + datos.caja;
                    form._tip = "Tipo: " + datos.R_D;
                    form._precioOriginal = "TOTAL FACT: " + decimal.Parse(datos.TotalFact.ToString()).ToString("C2");
                    form._remate = "ABONOS: " + decimal.Parse(abono).ToString("C2");
                    form._promocion = "GASTOS DE OPERACION: " + decimal.Parse(datos.total_gastos_op.ToString()).ToString("C2");
                    form._man = "DESC. PREFERENTE" +  decimal.Parse(datos.descuento_preferente.ToString()).ToString("C2");
                    form._importeTotal = "-----------";
                    //--------------------------------------///
                    form.ShowDialog();

                }
            }
            catch (Exception ex)
            {

                string _error = ex.Message;

            }
        }

        public void Update(string inventario, string comentario, string status, string consec)
        {
            model = new AutorizaNotaPagoConDepositoModel();
            var id = lista.Where(u => u.NO == int.Parse(consec)).FirstOrDefault();

            if (model.updateAutorizafact(id.NO, nombreOperaciones, status, DateTime.Now, comentario.ToUpper().Trim()) == true)
            {
                foreach (DataGridViewRow fila in dtgResult.Rows)
                {
                    if (fila.Cells[9].Value.ToString() == consec)
                    {

                        fila.Cells[8].Value = status.Substring(0, 3);

                    }

                }

                MessageBox.Show("AUTORIZACION DE DEPOSITO ACTUALIZADO!"
                 , "Operaciones SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("ERROR INESPERADO!"
                  , "Operaciones SEMP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }
        }
    }
}
