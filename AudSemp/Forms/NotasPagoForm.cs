

namespace AudSemp.Forms
{
    #region Libraries (libreriras)
    using AudSemp.Classes;
    using AudSemp.Context;
    using AudSemp.Models;
    using AudSemp.Presenter;
    using AudSemp.Views;
    using ClosedXML.Excel;
    using System;
    using System.Collections.Generic;
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using DocumentFormat.OpenXml.Spreadsheet;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    #endregion
    public partial class NotasPagoForm : Form,InotasPago
    {

        #region Context

        private SEMP2013_Context db;
        public NotasPagoForm()
        {
            InitializeComponent();
            db = new SEMP2013_Context();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

        }


        #endregion

        #region Attributes (atributos)
        public DateTime dateTimeInicio { get; set; }
        public DateTime dateTimeFin { get; set; }
        public List<string> tiposrd { get; set; }
        public List<string> status { get; set; }
        public List<TiposOrden> tiposOrden { get; set; }
        public List<ModoOrdenes> modosOrden { get; set; }
        #endregion


        #region Properties (propiedades)

        public int decision;
        public string leyendaTipos;
        public string leyendaEstatus;
        public string leyendaRango;
        public string loc;
        public string mode;
        string ruta;
        int cantidad = 0;
        #endregion


        #region Methods (Metodos)
        public void load()
        {
            NotaPagoPresenter notaPagoPresenter = new NotaPagoPresenter(this);
            notaPagoPresenter.TiposEstatus();
            notaPagoPresenter.TiposRd();
            notaPagoPresenter.timeInicio();
            notaPagoPresenter.timeFin();
            notaPagoPresenter.tiposOrden();
            notaPagoPresenter.modosOrden();

            foreach (var item in tiposrd)
            {
                chkPrendas.Items.Add(item, CheckState.Checked);
            }

            foreach (var item in status)
            {
                chkContratos.Items.Add(item, CheckState.Checked);
            }


            dtInicio.Value = dateTimeInicio;
            dtFin.Value = dateTimeFin;

            cmbOrden.DataSource = modosOrden;
            cmbTipoOrden.DataSource = tiposOrden;
            btnCancel.Visible = false;

            this.Text = this.Text + " -Localidad Actual: " + loc;
        }

        public void Excel(string ruta)
        {
            leyendaRango = "";
            leyendaEstatus = "";
            leyendaTipos = "";



            string fechaInicio, fechaFin, tipoOrden = "NO", orden = "Ascendente";
            List<rd> tipord = new List<rd>();
            List<Estatus> tipoStatus = new List<Estatus>();


            if (checkFechas.Checked == true)
            {
                fechaInicio = dtInicio.Value.ToString();
                fechaFin = dtFin.Value.ToString();
            }
            else
            {
                fechaInicio = dateTimeInicio.ToString();
                fechaFin = dateTimeFin.ToString();

            }

            leyendaRango = Convert.ToDateTime(fechaInicio).ToString("dd-MMM-yyyy") +
                " - " + Convert.ToDateTime(fechaFin).ToString("dd-MMM-yyyy");


            //
            if (checkOrden.Checked == true)
            {
                tipoOrden = cmbTipoOrden.Text;
            }
            else
            {
                tipoOrden = "NO";
            }

            if (checkModo.Checked == true)
            {
                orden = cmbOrden.Text;
            }
            else
            {
                orden = "Ascendente";
            }


            //


            //stastus

            if (checkContratos.Checked == false)
            {




                if (chkContratos.CheckedItems.Count > 0)
                {
                    foreach (var item in chkContratos.CheckedItems)
                    {
                        tipoStatus.Add(new Estatus() { estatu = item.ToString() }
                             );
                        leyendaEstatus += item.ToString() + " - ";
                    }

                }
                else
                {
                    foreach (var item in chkContratos.Items)
                    {
                        tipoStatus.Add(new Estatus() { estatu = item.ToString() }
                             );
                        leyendaEstatus += item.ToString() + " - ";
                    }
                }






            }
            else
            {

                foreach (var item in chkContratos.CheckedItems)
                {
                    tipoStatus.Add(new Estatus() { estatu = item.ToString() }
                         );
                    leyendaEstatus += item.ToString() + " - ";
                }

            }


            //RD
            if (checkPrendas.Checked == false)
            {


                if (chkPrendas.CheckedItems.Count > 0)
                {

                    foreach (var item in chkPrendas.CheckedItems)
                    {
                        tipord.Add(
                             new rd() { categoria = item.ToString() }
                             );
                        leyendaTipos += item.ToString() + " - ";
                    }
                }
                else
                {
                    foreach (var item in chkPrendas.Items)
                    {
                        tipord.Add(
                             new rd() { categoria = item.ToString() }
                             );
                        leyendaTipos += item.ToString() + " - ";
                    }
                }



            }
            else
            {

                foreach (var item in chkPrendas.CheckedItems)
                {
                    tipord.Add(
                         new rd() { categoria = item.ToString() }
                         );
                    leyendaTipos += item.ToString() + " - ";
                }

            }


            Export(fechaInicio, fechaFin, tipoOrden, orden, tipord, tipoStatus);

        }



        public void Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden,
         List<rd> tipos, List<Estatus> Estatus)
        {


            DataTable dt = new DataTable("Facturas");
            dt.Columns.AddRange(new DataColumn[40]
            {
              
                    new DataColumn("Factura"),
                    new DataColumn("FechaFact",typeof(DateTime)),
                    new DataColumn("HoraFact"),
                    new DataColumn("Contrato",typeof(Int32)),
                    new DataColumn("Bolsa"),
                    new DataColumn("Folio"),
                    new DataColumn("DescripcionFact"),
                    new DataColumn("ImporteFact"),
                    new DataColumn("IVAFact"),
                    new DataColumn("TotalFact"),
                    new DataColumn("IdCliente"),
                    new DataColumn("Comentario"),
                    new DataColumn("Abono"),
                    new DataColumn("R-D"),
                    new DataColumn("NO"),
                    new DataColumn("caja"),
                    new DataColumn("Gastos_Operacion"),
                    new DataColumn("gastos"),
                    new DataColumn("descuento_gastos_op"),
                    new DataColumn("total gastos_op"),
                    new DataColumn("leyendas"),
                    new DataColumn("leyenda2"),
                    new DataColumn("leyenda3"),
                    new DataColumn("STATUS"),
                    new DataColumn("origen"),
                    new DataColumn("cliente_Promocion"),
                    new DataColumn("Nota"),
                    new DataColumn("antes_refrendo"),
                    new DataColumn("ahora_refrendo"),
                    new DataColumn("antes_desempeño"),
                    new DataColumn("ahora_desempeño"),
                    new DataColumn("descuento_preferente"),
                    new DataColumn("leyendag"),
                    new DataColumn("leyendadescg"),
                    new DataColumn("leyendatotalg"),
                    new DataColumn("leyendaA"),
                    new DataColumn("plazo"),
                    new DataColumn("interes_N"),
                    new DataColumn("interes_A"),
                    new DataColumn("realizo")
                    
            });

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);


            int i = 0;

            foreach (var items in tipos)
            {


                foreach (var itemEstatus in Estatus)
                {
                    var result = from s in db.facturas.Where(p => p.FechaFact >= Inicio &&
                                      p.FechaFact <= Fin &&
                                      p.R_D == items.categoria &&
                                      p.STATUS == itemEstatus.estatu).ToList()
                                 select s;



                    foreach (var item in result)
                    {
                        cantidad = result.Count();
                        i++;
                        backgroundWorker1.ReportProgress(i);

                        dt.Rows.Add(item.Factura, DateTime.Parse(item.FechaFact.ToString()), item.HoraFact,
                            int.Parse(item.Contrato.ToString()), int.Parse(item.Bolsa.ToString()), item.Folio, item.DescripcionFact,
                           decimal.Parse(item.ImporteFact.ToString()), decimal.Parse(item.IVAFact.ToString()), decimal.Parse(item.TotalFact.ToString()), item.IdCliente, item.Comentario,
                            item.Abono, item.R_D, item.NO, item.caja,
                            item.Gastos_Operacion, item.gastos, item.descuento_gastos_op, item.total_gastos_op, item.leyendas,
                            item.leyenda2, item.leyenda3, item.STATUS,
                            item.origen, item.cliente_Promocion, item.Nota, item.antes_refrendo, item.ahora_refrendo,
                            item.antes_desempeño, item.ahora_desempeño, item.descuento_preferente, item.leyendag, item.leyendadescg, item.leyendatotalg,
                            item.leyendaA, item.plazo, item.interes_N, item.interes_A, item.realizo);


                    }
                    i = 0;
                }



            }

            DataView dataView = new DataView(dt);
            dt = new DataTable();

            //ORDER MODE
            mode = tipoOrden + modoOrden;
            switch (mode)
            {
                
                default:
                    dataView.Sort = "NO asc";
                    break;
                case "FechaAscendente":
                    dataView.Sort = "FechaFact asc";
                    break;
                case "FechaDescendente":
                    dataView.Sort = "FechaFact desc";
                    break;
                case "ContratoAscendente":
                    dataView.Sort = "Contrato asc";
                    break;
                case "ContratoDescendente":
                    dataView.Sort = "Contrato desc";
                    break;
                case "StatusAscendente":
                    dataView.Sort = "STATUS asc";
                    break;
                case "StatusDescendente":
                    dataView.Sort = "STATUS desc";
                    break;
                case "Nota de PagoAscendente":
                    dataView.Sort = "Factura asc";
                    break;
                case "Nota de PagoDescendente":
                    dataView.Sort = "Factura desc";
                    break;

            }

            dt = dataView.ToTable();

            if (decision == 1)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt);
                    wb.SaveAs(ruta);

                }
            }
            else if (decision == 2)
            {


                dt.WriteXml("C:/SEMP2013/AudSemp/AudSemp/XML/audNP.xml", XmlWriteMode.WriteSchema);



            }

        }


        #endregion



        #region Events (Eventos)
        private void NotasPagoForm_Load(object sender, EventArgs e)
        {
            load();
        }

        private void checkPrendas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPrendas.Checked == false)
            {
                //chkPrendas
                for (int i = 0; i < chkPrendas.Items.Count; i++)
                {
                    chkPrendas.SetItemChecked(i, false);
                }



            }
            else
            {
                for (int i = 0; i < chkPrendas.Items.Count; i++)
                {
                    chkPrendas.SetItemChecked(i, true);
                }


            }
        }

        private void checkContratos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkContratos.Checked == false)
            {
                //chkPrendas
                for (int i = 0; i < chkContratos.Items.Count; i++)
                {
                    chkContratos.SetItemChecked(i, false);
                }



            }
            else
            {
                for (int i = 0; i < chkContratos.Items.Count; i++)
                {
                    chkContratos.SetItemChecked(i, true);
                }


            }
        }

        private void checkFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFechas.Checked == false)
            {
                dtInicio.Enabled = false;
                dtFin.Enabled = false;
            }
            else
            {
                dtInicio.Enabled = true;
                dtFin.Enabled = true;
            }
        }

        private void checkOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOrden.Checked == false)
            {
                cmbTipoOrden.Enabled = false;
            }
            else
            {
                cmbTipoOrden.Enabled = true;
            }
        }

        private void checkModo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkModo.Checked == false)
            {
                cmbOrden.Enabled = false;
            }
            else
            {
                cmbOrden.Enabled = true;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                ruta = saveFileDialog1.FileName;

                if (string.IsNullOrEmpty(ruta))
                {
                    MessageBox.Show("No hay directorio Seleccionado",
                        "Auditoria SEMP", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {

                    //if (backgroundWorker1.IsBusy != true)
                    //{
                    //    backgroundWorker1.RunWorkerAsync();
                    //}

                    decision = 1;

                    backgroundWorker1.RunWorkerAsync();
                    btnExportar.Enabled = false;
                    btnReporte.Enabled = false;
                    btnRegresar.Enabled = false;
                    btnCancel.Visible = true;

                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Crear Reporte", "Auditoria SEMP",
          MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.OK:
                    {
                        decision = 2;



                        btnReporte.Enabled = false;
                        btnRegresar.Enabled = false;
                        btnExportar.Enabled = false;
                        btnCancel.Visible = true;
                        backgroundWorker1.RunWorkerAsync();

                        break;
                    }
                case DialogResult.Cancel:
                    {

                        break;
                    }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
                btnExportar.Enabled = true;
                btnReporte.Enabled = true;
                btnRegresar.Enabled = true;
                btnCancel.Visible = false;



                MessageBox.Show("Exportacion CANCELADA",
                 "Auditoria Semp", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
                prg1.Value = 0;
                lblProgress.Text = "-";


            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Excel(ruta);
            Thread.Sleep(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this is updated from dowork. Its where GUI components are update
            prg1.Maximum = cantidad;
            prg1.Value = e.ProgressPercentage;
            lblProgress.Text = (e.ProgressPercentage.ToString() + " / " + cantidad + " # Registros Completados...");

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //called when the heavy operation in bg is over . can also accept GUI compponents

            if (decision == 2)
            {
                //creamos los para metros

                notasPagoRPT ob = new notasPagoRPT();
                LocalidadModel localidadModel = new LocalidadModel();
                localidadModel.localidadResult(loc);
                ob.SetParameterValue("tipos", leyendaTipos);
                ob.SetParameterValue("estatus", leyendaEstatus);
                ob.SetParameterValue("rangos", leyendaRango);
                ob.SetParameterValue("modoOrden", mode);

                ob.SetParameterValue("sucursal", localidadModel.sucursal);
                ob.SetParameterValue("marca", localidadModel.marca);
                ob.SetParameterValue("empresa", localidadModel.empresa);
                ob.SetParameterValue("localidad", localidadModel.localidad);
                ob.SetParameterValue("encargado", localidadModel.encargado);
                ob.SetParameterValue("logo", localidadModel.logotipo);



                crystalReportViewer1.ReportSource = ob;
                crystalReportViewer1.Refresh();


            }

            MessageBox.Show("Operación Realizada con Exito",
                   "Auditoria Semp", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            prg1.Value = 0;
            lblProgress.Text = "-";

            btnExportar.Enabled = true;
            btnReporte.Enabled = true;
            btnRegresar.Enabled = true;
            btnCancel.Visible = false;
        } 
        #endregion
    }
}
