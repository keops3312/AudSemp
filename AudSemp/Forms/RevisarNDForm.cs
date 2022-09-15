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

namespace AudSemp.Forms
{
    public partial class RevisarNDForm : Form
    {


        public DataTable dt;
        public List<NotasDescuento> lista;
        public string nombreOperaciones;
        private NotasDeDescuentoModel model;

        public string _status;
        public string _comentario;
        public string _inventario;


        public RevisarNDForm()
        {
            InitializeComponent();
        }

        private void RevisarNDForm_Load(object sender, EventArgs e)
        {
            try
            {

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Genere un Ejercicio Primero de tipo excel o reporte comenzar a Revisar",
                        "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                if (dtgResult.Columns.Count == 0)
                {
                    dtgResult.Columns.Add("Id", "Id");
                    dtgResult.Columns.Add("ND", "ND");
                    dtgResult.Columns.Add("IdCliente", "FolioOP");
                    dtgResult.Columns.Add("Cliente", "Cliente");
                    dtgResult.Columns.Add("TipoOperacion", "TipoOperacion");//4
                    dtgResult.Columns.Add("NP", "NP");//5
                    dtgResult.Columns.Add("Remision", "Remision");//6
                    dtgResult.Columns.Add("Contrato", "Contrato");
                    dtgResult.Columns.Add("Prestamo", "Prestamo");
                    dtgResult.Columns.Add("SubTotal", "SubTotal");
                    dtgResult.Columns.Add("Iva", "Iva" );
                    dtgResult.Columns.Add("Total", "Total");//11
                    dtgResult.Columns.Add("SubTotalR", "SubTotalR");
                    dtgResult.Columns.Add("IvaR", "IvaR");
                    dtgResult.Columns.Add("TotalR", "TotalR");//14
                    dtgResult.Columns.Add("Estatus", "Estatus");
                    dtgResult.Columns.Add("CantidadDescuento", "Cant.Desc.");
                    dtgResult.Columns.Add("ImporteDescuento", "Desc.");
                    dtgResult.Columns.Add("Caja", "Caja");
                    dtgResult.Columns.Add("ArgumentoUsuario", "ArgumentoUsuario");
                    dtgResult.Columns.Add("Usuario", "Usuario");
                    dtgResult.Columns.Add("JefeAutorizo", "JefeAutorizo");
                    dtgResult.Columns.Add("FechaDescuento", "FechaDescuento");
                    dtgResult.Columns.Add("GOAutorizo", "GOAutorizo");//23
                    dtgResult.Columns.Add("GOAutorizado", "Click Detalle GO");//24
                    dtgResult.Columns.Add("GOArgumento", "GOArgumento");//25
                    dtgResult.Columns.Add("GOAutorizadoFecha", "GOAutorizadoFecha");//26
                    dtgResult.Columns.Add("Auditor", "Auditor");
                    dtgResult.Columns.Add("Auditado", "Auditado");
                    dtgResult.Columns.Add("AuditorArgumento", "AuditorArgumento");
                    dtgResult.Columns.Add("AuditadoFecha", "AuditadoFecha");
                    dtgResult.Columns.Add("Sucursal", "Sucursal");




                }

                dtgResult.Columns[0].Visible = false;
                dtgResult.Columns[31].Visible = false;
                dtgResult.Columns[7].Visible = false;
                dtgResult.Columns[16].Visible = false;
                dtgResult.Columns[9].Visible = false;
                dtgResult.Columns[10].Visible = false;
                dtgResult.Columns[12].Visible = false;
                dtgResult.Columns[13].Visible = false;
                dtgResult.Columns[4].Visible = false;
                dtgResult.Columns[3].Visible = false;
                dtgResult.Columns[23].Visible = false;

                dtgResult.Columns[21].Visible = false;
                dtgResult.Columns[20].Visible = false;
                dtgResult.Columns[19].Visible = false;
                dtgResult.Columns[5].Visible = false;
                dtgResult.Columns[6].Visible = false;
                dtgResult.Columns[8].Visible = false;
                dtgResult.Columns[14].Visible = false;

               

                foreach (var item in lista)
                {
                    if (item.TipOperacion == "NP")
                    {
                      

                        dtgResult.Rows.Add(item.Id, item.ND, item.NP, item.Cliente, item.NP, item.NP,
                                          item.Remision, item.Contrato, item.Prestamo, item.SubTotal, item.Iva, item.Total, item.SubTotalR,
                                          item.IvaR, item.TotalR, item.Estatus, item.CantidadDescuento, item.ImporteDescuento, item.Caja, item.ArgumentoUsuario,
                                          item.Usuario, item.JefeAutorizo, item.FechaDescuento, item.GOAutorizo, item.GOAutorizado, item.GOArgumento, item.GOAutorizadoFecha,
                                          item.Auditor, item.Auditado, item.AuditorArgumento, item.AuditadoFecha, item.Sucursal);

                    }

                    if (item.TipOperacion == "R")
                    {
                       
                        dtgResult.Rows.Add(item.Id, item.ND, item.Remision, item.Cliente, item.Remision, item.NP,
                                            item.Remision, item.Contrato, item.Prestamo, item.SubTotal, item.Iva, item.TotalR, item.SubTotalR,
                                            item.IvaR, item.TotalR, item.Estatus, item.CantidadDescuento, item.ImporteDescuento, item.Caja, item.ArgumentoUsuario,
                                            item.Usuario, item.JefeAutorizo, item.FechaDescuento, item.GOAutorizo, item.GOAutorizado, item.GOArgumento, item.GOAutorizadoFecha,
                                            item.Auditor, item.Auditado, item.AuditorArgumento, item.AuditadoFecha, item.Sucursal);
                    }


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


                    fila.Cells["RevAuditoria"].Value =
                   System.Drawing.Image.FromFile("C:\\SEMP2013\\OperSemp\\OperSemp\\Resources\\verSmall.fw.png");


                    fila.Cells["Autorizar"].Value =

                    System.Drawing.Image.FromFile("C:\\SEMP2013\\OperSemp\\OperSemp\\Resources\\UpdateSmall.fw.png");
                }

                dtgResult.Columns["Autorizar"].Width = 100;

                dtgResult.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgResult.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);


                dtgResult.Columns[8].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[8].DefaultCellStyle.ForeColor = Color.DarkBlue;
                dtgResult.Columns[8].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);

                //
                dtgResult.Columns[9].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[9].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[9].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[10].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[10].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[10].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[11].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[11].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[11].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);

                //
                dtgResult.Columns[12].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[12].DefaultCellStyle.ForeColor = Color.DarkOrange;
                dtgResult.Columns[12].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[13].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[13].DefaultCellStyle.ForeColor = Color.DarkOrange;
                dtgResult.Columns[13].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[14].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[14].DefaultCellStyle.ForeColor = Color.DarkOrange;
                dtgResult.Columns[14].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);


                dtgResult.Columns[16].DefaultCellStyle.Format = "N0";
                dtgResult.Columns[16].DefaultCellStyle.ForeColor = Color.DarkSlateBlue;
                dtgResult.Columns[16].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[17].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[17].DefaultCellStyle.ForeColor = Color.DarkSlateBlue;
                dtgResult.Columns[17].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);




                dtgResult.Columns[22].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[22].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[22].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[26].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[26].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[26].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[30].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dtgResult.Columns[30].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[30].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);


                dtgResult.Columns[24].DefaultCellStyle.BackColor =Color.BlueViolet;
                dtgResult.Columns[24].DefaultCellStyle.ForeColor = Color.White;
                dtgResult.Columns[24].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);


                dtgResult.Columns[28].DefaultCellStyle.BackColor = Color.IndianRed;
                dtgResult.Columns[28].DefaultCellStyle.ForeColor = Color.White;
                dtgResult.Columns[28].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);



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
                string inventario;
                //auditar
                if (e.ColumnIndex == 24)//boton informacion raiz
                {

                    inventario = dtgResult.Rows[fila].Cells[0].Value.ToString();
                    var datosAuditoria = lista.Where(p => p.Id == int.Parse(inventario)).FirstOrDefault();

                    MessageBox.Show("Detalles de Operaciones:\n" +
                        "Auditor: " + datosAuditoria.GOAutorizo + "\n" +
                        "Status: " + datosAuditoria.GOAutorizado + "\n" +
                        "Fecha: " + DateTime.Parse(datosAuditoria.GOAutorizadoFecha.ToString()).ToString("ddd dd MMMM yyyy") + "\n" +
                        "Comentario: " + datosAuditoria.GOArgumento + "\n", "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }


                //ver Detalles de Inventario
                if (e.ColumnIndex == 32)//boton informacion raiz
                {

                    inventario = dtgResult.Rows[fila].Cells[0].Value.ToString();
                    var datos = lista.Where(p => p.Id == int.Parse(inventario)).FirstOrDefault();

                    if (datos.TipOperacion == "NP")
                    {
                        MessageBox.Show("Detalles de Operación:\n" +
                                             "Nota de Descuento: " + datos.ND + "\n" +
                                             "Cliente: " + datos.Cliente + "\n" +
                                             "Tipo de Operación: " + datos.TipOperacion + "\n" +
                                             "Fecha: " + DateTime.Parse(datos.FechaDescuento.ToString()).ToString("ddd dd MMMM yyyy") + "\n" +
                                             "Status: " + datos.Estatus + "\n" +
                                             "Folio NP: " + datos.NP + "\n" +
                                             "Caja: " + datos.Caja + "\n" +
                                             "Cajero: " + datos.Usuario + "\n" +
                                             "Mot. Descuento: " + datos.ArgumentoUsuario + "\n" +
                                             "Jefe que Autorizo: " + datos.JefeAutorizo + "\n" +
                                             "------------------------ " + "\n" +
                                             "TOTAL NP: " + decimal.Parse(datos.Total.ToString()).ToString("C2") + "\n" +
                                             "DESCUENTO: -" + decimal.Parse(datos.ImporteDescuento.ToString()).ToString("C2") + "\n"
                                            , "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Detalles de Operación:\n" +
                                            "Nota de Descuento: " + datos.ND + "\n" +
                                            "Cliente: " + datos.Cliente + "\n" +
                                            "Tipo de Operación: " + datos.TipOperacion + "\n" +
                                            "Fecha: " + DateTime.Parse(datos.FechaDescuento.ToString()).ToString("ddd dd MMMM yyyy") + "\n" +
                                            "Status: " + datos.Estatus + "\n" +
                                            "Folio R: " + datos.Remision + "\n" +
                                            "Caja: " + datos.Caja + "\n" +
                                            "Cajero: " + datos.Usuario + "\n" +
                                            "Mot. Descuento: " + datos.ArgumentoUsuario + "\n" +
                                            "Jefe que Autorizo: " + datos.JefeAutorizo + "\n" +
                                            "------------------------ " + "\n" +
                                            "TOTAL NP: " + decimal.Parse(datos.TotalR.ToString()).ToString("C2") + "\n" +
                                            "DESCUENTO: -" + decimal.Parse(datos.ImporteDescuento.ToString()).ToString("C2") + "\n"
                                           , "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                 



                }

                //actualizar
                if (e.ColumnIndex == 33)//boton informacion raiz
                {
                    inventario = dtgResult.Rows[fila].Cells[0].Value.ToString();
                    var datos = lista.Where(p => p.Id == int.Parse(inventario)).FirstOrDefault();

                    MNLAutorizarForm form = new MNLAutorizarForm();
                    form._optionUpdate = 2;
                    form._comentario = "";
                    form.MyFormND = this;
                    form._status = dtgResult.Rows[fila].Cells[11].Value.ToString(); //consec
                    form._inventario = datos.Id.ToString();

                    //--------------------------------------//
                    form._inv = "Nota de Descuento: " + datos.ND;
                    form._desc = "Descuento Tipo : " + datos.TipOperacion;  
                    form._fec = "Fecha: " + DateTime.Parse(datos.FechaDescuento.ToString()).ToString("ddd dd MMMM yyyy");
                    form._sta = "Status: " + datos.Estatus;
                    form._cli = "Cliente: " + datos.Cliente;
                    form._ven = "Cajero: " + datos.Usuario;
                    form._caj = "Caja: " + datos.Caja;
                    form._tip = "Folio de Operación: " + datos.NP;
                    form._precioOriginal = "Importe Total Original: " + decimal.Parse(datos.Total.ToString()).ToString("C2");
                    form._rem = "Descuento: " + decimal.Parse(datos.ImporteDescuento.ToString()).ToString("C2");

                    if (datos.NP == ".")
                    {
                        form._tip = "Folio de Operación: " + datos.Remision;
                        form._precioOriginal = "Importe Total Original: " + decimal.Parse(datos.TotalR.ToString()).ToString("C2");
                    }
                   
                  
                  
                    form._remate = "Argumento Auditor: " + datos.AuditorArgumento;
                    form._promocion = "Estatus que declara auditor " + datos.Auditado;
                    form._man = "------";
                    form._importeTotal = "--------";
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
            model = new NotasDeDescuentoModel();
            var id = lista.Where(u => u.Id == int.Parse(consec)).FirstOrDefault();

            if (model.updateAutorizaND(id.Id, nombreOperaciones, status, DateTime.Now, comentario.ToUpper().Trim()) == true)
            {
                foreach (DataGridViewRow fila in dtgResult.Rows)
                {
                    if (fila.Cells[0].Value.ToString() == consec)
                    {
                        //dtgResult.Columns.Add("GOAutorizo", "GOAutorizo");//23
                        //dtgResult.Columns.Add("GOAutorizado", "GOAutorizado");//24
                        //dtgResult.Columns.Add("GOArgumento", "GOArgumento");//25
                        //dtgResult.Columns.Add("GOAutorizadoFecha", "GOAutorizadoFecha");//26
                        fila.Cells[28].Value = status.Substring(0, 3);

                    }

                }

                MessageBox.Show("AUTORIZACION DE ND ACTUALIZADO!"
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
