


namespace AudSemp.Forms
{

    #region Libraries (librerias)
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using AudSemp.Classes;
    using AudSemp.Context;
    using AudSemp.Models;
    using AudSemp.Presenter;
    using AudSemp.Views;
    using ClosedXML.Excel;
    #endregion
    public partial class DepositosyRetiros : Form, IDepositosRetiros
    {


        #region Context

        private SEMP2013_Context db;

        public DepositosyRetiros()
        {
            InitializeComponent();
            db = new SEMP2013_Context();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

        }
        #endregion

        #region Properties (propiedades)
        //string Opcion;
        public int cantidad;
        public int decision;
        public string leyendaTipos;
        public string leyendaEstatus;
        public string leyendaRango;
        public string loc;
        public string mode;
        string ruta;
        //variable to cancel progress
        public int cancelEjercicio;
        //table to report
        DataTable dt = new DataTable();

        #endregion

        #region Atributes (atributos)
        public DateTime dateTimeInicio { get; set; }
        public DateTime dateTimeFin { get; set; }
        public List<TiposOrden> tiposOrden { get; set; }
        public List<ModoOrdenes> modosOrden { get; set; }
        public string OpcionDR { get; set; }
        #endregion


        #region Methods (Metodos)
        public void load()
        {
            checkPrendas.Checked = true;
            OpcionDR = "Depositos";

            DepositosRetirosPresenter depositosRetirosPresenter = new DepositosRetirosPresenter(this);
            depositosRetirosPresenter.timeInicio();
            depositosRetirosPresenter.timeFin();
            depositosRetirosPresenter.tiposOrden();
            //
            depositosRetirosPresenter.modosOrden();


            dtInicio.Value = dateTimeInicio;
            dtFin.Value = dateTimeFin;

            cmbOrden.DataSource = modosOrden;
            cmbTipoOrden.DataSource = tiposOrden;
            btnCancel.Visible = false;

            this.Text = this.Text + " -Localidad Actual: " + loc;
        }

        public void Excel(string ruta)
        {
            string fechaInicio, fechaFin, tipoOrden, orden;
          
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
                tipoOrden = "fecha";
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
            Export(fechaInicio, fechaFin, tipoOrden, orden);

        }



        public void Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden)
        {
           // DataTable dt = new DataTable();
            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);


            int i = 0;



            if (dt.Rows.Count == 0)
            {

                if (OpcionDR == "Depositos")
                {
                    dt.TableName = "Depositos";
                    dt.Columns.AddRange(new DataColumn[7]
                    {
                    new DataColumn("no"),
                    new DataColumn("deposito",typeof(double)),
                    new DataColumn("fecha",typeof(DateTime)),
                    new DataColumn("realizo"),
                    new DataColumn("caja"),
                    new DataColumn("comentario"),
                    new DataColumn("tipo_deposito"),

                     });
                    var result = db.depositos.Where(p => p.fecha >= Inicio &&
                                      p.fecha <= Fin
                                      ).ToList();


                    foreach (var item in result)
                    {
                        cantidad = result.Count();
                        i++;
                        backgroundWorker1.ReportProgress(i);

                        if (cancelEjercicio == 1)
                        {
                            break;
                        }



                        dt.Rows.Add(item.no, Convert.ToDecimal(item.deposito),
                            Convert.ToDateTime(item.fecha).ToString("yyyy-MM-dd"),
                            item.realizo, item.caja, item.comentario,
                            item.tipo_deposito
                            );


                    }
                    i = 0;
                }
                else
                {
                    dt.TableName = "Retiros";
                    dt.Columns.AddRange(new DataColumn[14]
                   {
                    new DataColumn("caja"),
                    new DataColumn("numcaja"),
                    new DataColumn("pertenecea"),
                    new DataColumn("cantidad",typeof(double)),
                    new DataColumn("concepto"),
                    new DataColumn("descripcion"),
                    new DataColumn("estatus"),
                    new DataColumn("fecha",typeof(DateTime)),
                    new DataColumn("hora"),
                    new DataColumn("autorizo"),
                    new DataColumn("usuario"),
                    new DataColumn("nooperador"),
                    new DataColumn("comprobacionno"),
                    new DataColumn("folio"),

                    });

                    var result2 = db.Retiros.Where(p => p.fecha >= Inicio &&
                                        p.fecha <= Fin
                                        ).ToList();

                    foreach (var item in result2)
                    {
                        cantidad = result2.Count();
                        i++;
                        backgroundWorker1.ReportProgress(i);

                        if (cancelEjercicio == 1)
                        {
                            break;
                        }




                        dt.Rows.Add(item.caja, item.numcaja, item.pertenecea,
                         Convert.ToDecimal(item.cantidad), item.concepto,
                         item.descripcion, item.estatus, Convert.ToDateTime(item.fecha).ToString("yyyy-MM-dd"),
                         item.hora, item.autorizo, item.usuario, item.nooperador, item.comprobacionno,
                         item.folio
                         );
                    }
                    i = 0;
                }

            }

            DataView dataView = new DataView(dt);
           // dt = new DataTable();

            //ORDER MODE

            mode = tipoOrden + modoOrden + OpcionDR;
            switch (mode)
            {
                default:
                    dataView.Sort = "fecha asc";
                    break;
                case "FechaAscendenteDepositos":
                    dataView.Sort = "fecha asc";
                    break;
                case "FechaDescendenteDepositos":
                    dataView.Sort = "fecha desc";
                    break;
                case "DepositoAscendenteDepositos":
                    dataView.Sort = "deposito asc";
                    break;
                case "DepositoDescendenteDepositos":
                    dataView.Sort = "deposito desc";
                    break;
                case "CajaAscendenteDepositos":
                    dataView.Sort = "caja asc";
                    break;
                case "CajaDescendenteDepositos":
                    dataView.Sort = "caja desc";
                    break;
                case "FechaAscendenteRetiros":
                    dataView.Sort = "fecha asc";
                    break;
                case "FechaDescendenteRetiros":
                    dataView.Sort = "fecha desc";
                    break;        
                case "CajaAscendenteRetiros":
                    dataView.Sort = "caja asc";
                    break;
                case "CajaDescendenteRetiros":
                    dataView.Sort = "caja desc";
                    break;
                case "ConceptoAscendenteRetiros":
                    dataView.Sort = "deposito asc";
                    break;
                case "ConceptoDescendenteRetiros":
                    dataView.Sort = "deposito desc";
                    break;
                case "RetiroAscendenteRetiros":
                    dataView.Sort = "cantidad asc";
                    break;
                case "RetiroDescendenteRetiros":
                    dataView.Sort = "cantidad desc";
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
                if (OpcionDR == "Depositos")
                {
                    dt.WriteXml("C:/SEMP2013/AudSemp/AudSemp/XML/audDepositos.xml", XmlWriteMode.WriteSchema);
                }
                else
                {
                    dt.WriteXml("C:/SEMP2013/AudSemp/AudSemp/XML/audRetiros.xml", XmlWriteMode.WriteSchema);

                }

              



            }

        }
        #endregion

        #region Events (eventos)
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                VistaPreviaForm vista = new VistaPreviaForm();
                vista.leyenda = this.Text + "- Previo -Localidad Actual: " + loc;
                vista.vistaM = dt;
                vista.Show();

            }
            else
            {
                MessageBox.Show("NO hay resultados cargados!", "Auditoria Semp", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void DepositosyRetiros_Load(object sender, EventArgs e)
        {
            load();
            checkPrendas.Checked = true;
            checkContratos.Checked = false;
        }

        private void checkPrendas_CheckedChanged(object sender, EventArgs e)
        {
            
            //Depositos
            if (checkPrendas.Checked == true)
            {
                OpcionDR="Depositos";
                seleccionReport();
                checkContratos.Checked = false;
                
            }
          
        }

        private void seleccionReport()
        {
            DepositosRetirosPresenter depositosRetirosPresenter = new DepositosRetirosPresenter(this);
            depositosRetirosPresenter.timeInicio();
            depositosRetirosPresenter.timeFin();
            depositosRetirosPresenter.tiposOrden();
            //
            depositosRetirosPresenter.modosOrden();


            dtInicio.Value = dateTimeInicio;
            dtFin.Value = dateTimeFin;

            cmbOrden.DataSource = modosOrden;
            cmbTipoOrden.DataSource = tiposOrden;
        }

        private void checkContratos_CheckedChanged(object sender, EventArgs e)
        {
            //Retiros
            if (checkContratos.Checked == true)
            {
                OpcionDR = "Retiros";
                seleccionReport();
                checkPrendas.Checked = false;
            }
           

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            if (dt.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Exportar Ejercicio Anterior?" +
                    "Si(Exporta) No(Para Generar uno Nuevo)", "Auditoria SEMP",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (result == DialogResult.No)
                {

                    dt.Clear();
                    dt.Reset();


                }


            }



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


            if (dt.Rows.Count > 0)
            {
                DialogResult resulta = MessageBox.Show("¿Crear Ejercicio Anterior?" +
                    "Si(Crea) No(Para Generar uno Nuevo)", "Auditoria SEMP",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (resulta == DialogResult.No)
                {

                    dt.Clear();
                    dt.Reset();


                }


            }


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
                backgroundWorker1.ReportProgress(0);
                cancelEjercicio = 1;
                prg1.Value = 0;


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
                if (OpcionDR == "Depositos")
                {
                    depositosRPT ob = new depositosRPT();

                    LocalidadModel localidadModel = new LocalidadModel();
                    localidadModel.localidadResult(loc);
                    ob.SetParameterValue("tipos", "TODOS");
                    ob.SetParameterValue("estatus", "TODOS");
                    ob.SetParameterValue("rangos", leyendaRango);
                    ob.SetParameterValue("modoOrden", mode);

                    ob.SetParameterValue("sucursal", localidadModel.sucursal);
                    ob.SetParameterValue("marca", localidadModel.marca);
                    ob.SetParameterValue("empresa", localidadModel.empresa);
                    ob.SetParameterValue("localidad", localidadModel.localidad);
                    ob.SetParameterValue("encargado", localidadModel.encargado);
                    ob.SetParameterValue("logo", localidadModel.logotipo);



                    crystalReportViewer1.ReportSource = ob;
                }
                else
                {
                    RetirosRPT ob = new RetirosRPT();

                    LocalidadModel localidadModel = new LocalidadModel();
                    localidadModel.localidadResult(loc);
                    ob.SetParameterValue("tipos", "TODOS");
                    ob.SetParameterValue("estatus", "TODOS");
                    ob.SetParameterValue("rangos", leyendaRango);
                    ob.SetParameterValue("modoOrden", mode);

                    ob.SetParameterValue("sucursal", localidadModel.sucursal);
                    ob.SetParameterValue("marca", localidadModel.marca);
                    ob.SetParameterValue("empresa", localidadModel.empresa);
                    ob.SetParameterValue("localidad", localidadModel.localidad);
                    ob.SetParameterValue("encargado", localidadModel.encargado);
                    ob.SetParameterValue("logo", localidadModel.logotipo);



                    crystalReportViewer1.ReportSource = ob;
                }
                //creamos los para metros
               
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
