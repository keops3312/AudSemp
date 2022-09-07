

namespace AudSemp.Forms
{
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
    public partial class RevisarMNLAutorizarForm : Form
    {

        public DataTable dt;
        public List<remisiones> lista;
        public string nombreOperaciones;
        private AutorizaRemisionesMNLModel model;

        public string _status;
        public string _comentario;
        public string _inventario;

        public RevisarMNLAutorizarForm()
        {
            InitializeComponent();
        }

        private void RevisarMNLAutorizarForm_Load(object sender, EventArgs e)
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
                    dtgResult.Columns.Add("NumRemision","Remision");
                    dtgResult.Columns.Add("Fecha","Fecha");
                    dtgResult.Columns.Add("Inventario", "Inventario");//clic y muestra datos
                    dtgResult.Columns.Add("Descripcion", "Descripcion");
                    dtgResult.Columns.Add("Precio", "Precio");
                    dtgResult.Columns.Add("DescRemate", "Desc.Remate");
                    dtgResult.Columns.Add("DescPromocion", "Desc.Promocion");
                    dtgResult.Columns.Add("Descuento", "Desc.MNL");
                    dtgResult.Columns.Add("Importe", "Precio Final");
                    dtgResult.Columns.Add("Auditado", "ST.Auditado");//click y muestra datos
                    dtgResult.Columns.Add("Autorizado", "ST.Autorizado");//click y muestra datos
                    dtgResult.Columns.Add("Id", "ID");//click y muestra datos



                }
                dtgResult.Columns[11].Visible = false; ;//click y muestra datos

                foreach (var item in lista)
                {
                    dtgResult.Rows.Add(item.NumRemision,item.Fecha,item.Inventario,item.Descripcion,item.Precio,
                        item.descRemate,item.descPromocion,item.Descuento,item.Importe,item.auditado,item.autorizado,item.consec);
                }


              


                DataGridViewImageColumn btnB = new DataGridViewImageColumn();
                btnB.Name = "Autorizar";
                btnB.HeaderText = "Autorizar";
                dtgResult.Columns.Add(btnB);


                DataGridViewImageColumn btnA = new DataGridViewImageColumn();
                btnA.Name = "RevAuditoria";
                btnA.HeaderText = "Rev. Auditoria";
                dtgResult.Columns.Add(btnA);



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


                dtgResult.Columns[4].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[4].DefaultCellStyle.ForeColor = Color.DodgerBlue;
                dtgResult.Columns[4].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[5].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[5].DefaultCellStyle.ForeColor = Color.DarkRed;
                dtgResult.Columns[5].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[6].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[6].DefaultCellStyle.ForeColor = Color.DarkRed;
                dtgResult.Columns[6].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[7].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[7].DefaultCellStyle.ForeColor = Color.DarkRed;
                dtgResult.Columns[7].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[8].DefaultCellStyle.Format = "C2";
                dtgResult.Columns[8].DefaultCellStyle.ForeColor = Color.ForestGreen;
                dtgResult.Columns[8].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);


                dtgResult.Columns[1].DefaultCellStyle.Format = "dd/MMMM/yyyy";
                dtgResult.Columns[1].DefaultCellStyle.ForeColor = Color.OrangeRed;
                dtgResult.Columns[1].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

                dtgResult.Columns[1].Width = 100;

            }
            catch ( Exception ex)
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
                if (e.ColumnIndex == 12)//boton informacion raiz
                {


                    inventario = dtgResult.Rows[fila].Cells[11].Value.ToString();
                    var datosAuditoria = lista.Where(p => p.consec == int.Parse(inventario)).FirstOrDefault();

                    MessageBox.Show("Detalles de Autorización:\n"+
                        "Ger.Operaciones: " + datosAuditoria.autoriza + "\n" +
                        "Status: " + datosAuditoria.autorizado + "\n" +
                        "Fecha: " + DateTime.Parse(datosAuditoria.fechaAutoriza.ToString()).ToString("ddd dd MMMM yyyy") + "\n" +
                        "Comentario: " + datosAuditoria.comentarioAutorizado + "\n" ,  "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }


                //ver Detalles de Inventario
                if (e.ColumnIndex == 2)//boton informacion raiz
                {

                    inventario = dtgResult.Rows[fila].Cells[11].Value.ToString();
                    var datos = lista.Where(p => p.consec ==int.Parse( inventario)).FirstOrDefault();

                    MessageBox.Show("Detalles de Venta:\n" +
                        "Inventario: " + datos.Inventario + "\n" +
                        "Descripcíón: " + datos.Descripcion + "\n" +
                        "Remision: " + datos.NumRemision + "\n" +
                        "Fecha de Compra: " + DateTime.Parse(datos.Fecha.ToString()).ToString("ddd dd MMMM yyyy") + "\n" +
                        "Status: " + datos.status + "\n" +
                        "Cliente: " + datos.Cliente + "\n" +
                        "Vendedor: " + datos.vendio + "\n" +
                        "Caja: " + datos.caja + "\n" +
                        "Tipo: " + datos.Tipo_Prenda + "\n" +
                        "------PRECIO Y DESCUENTO---- "+ "\n" +
                        "PRECIO ORIGINAL: " + decimal.Parse(datos.Precio.ToString()).ToString("C2") + "\n"+
                        "DESC. REMATE: " +" no.Remate: " + datos.noRemate + " -" + decimal.Parse(datos.descRemate.ToString()).ToString("C2") + "\n" +
                        "DESC. PROMOCION: "  + datos.conceptPromocion + " -" + decimal.Parse(datos.descPromocion.ToString()).ToString("C2") + "\n" +
                        "DESC. MANUAL: " + datos.conceptopromocion + " -" + decimal.Parse(datos.Descuento.ToString()).ToString("C2") + "\n" +
                        "PRECIO FINAL: " + decimal.Parse(datos.Importe.ToString()).ToString("C2") + "\n" 
                        , "Operaciones SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }

                //actualizar
                if (e.ColumnIndex == 13)//boton informacion raiz
                {
                    inventario = dtgResult.Rows[fila].Cells[11].Value.ToString();
                    var datos = lista.Where(p => p.consec == int.Parse(inventario)).FirstOrDefault();

                    MNLAutorizarForm form = new MNLAutorizarForm();
                    form._comentario = "";
                    form.MyForm=this;
                    form._status = dtgResult.Rows[fila].Cells[11].Value.ToString(); //consec
                    form._inventario = datos.Inventario;

                    //--------------------------------------//
                    form._inv = "Inventario: " + datos.Inventario;
                    form._desc = "Descripcíón: " + datos.Descripcion;
                    form._rem = "Remision: " + datos.NumRemision;
                    form._fec = "Fecha de Compra: " + DateTime.Parse(datos.Fecha.ToString()).ToString("ddd dd MMMM yyyy");
                    form._sta = "Status: " + datos.status;
                    form._cli = "Cliente: " + datos.Cliente;
                    form._ven = "Vendedor: " + datos.vendio;
                    form._caj = "Caja: " + datos.caja;
                    form._tip = "Tipo: " + datos.Tipo_Prenda;
                    form._precioOriginal = "PRECIO ORIGINAL: " + decimal.Parse(datos.Precio.ToString()).ToString("C2");
                    form._remate = "DESC. REMATE: " + " no.Remate: " + datos.noRemate + " -" + decimal.Parse(datos.descRemate.ToString()).ToString("C2");
                    form._promocion = "DESC. PROMOCION: " + datos.conceptPromocion + " -" + decimal.Parse(datos.descPromocion.ToString()).ToString("C2");
                    form._man = "DESC. MANUAL: " + datos.conceptopromocion + " -" + decimal.Parse(datos.Descuento.ToString()).ToString("C2");
                    form._importeTotal = "PRECIO FINAL: " + decimal.Parse(datos.Importe.ToString()).ToString("C2");
                    //--------------------------------------///
                    form.ShowDialog();
                    
                }
            }
            catch (Exception ex)
            {

                string _error = ex.Message;

            }
        }


        public void Update(string inventario,string comentario, string status,string consec)
        {
            model = new AutorizaRemisionesMNLModel();
            var id = lista.Where(u => u.consec == int.Parse(consec)).FirstOrDefault();
            
            if (model.updateAutorizaRem(id.consec, nombreOperaciones, status, DateTime.Now, comentario.ToUpper().Trim())==true)
            {
                foreach (DataGridViewRow fila  in dtgResult.Rows)
                {
                    if (fila.Cells[11].Value.ToString() == consec)
                    {

                        fila.Cells[9].Value = status.Substring(0,3);

                    }

                }

                MessageBox.Show("AUDITORIA ACTUALIZADA!"
                 , "Auditoria SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
