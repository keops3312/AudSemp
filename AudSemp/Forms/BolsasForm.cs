

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
    using OperSemp.Commons.Data;
    using OperSemp.Commons.Entities;
    using OperSemp.Commons.Helper;
    #endregion
    public partial class BolsasForm : Form, IBolsas
    {


        #region Context

        private DataContext db;
        IConectionHelper conectionHelper;
        public User user;
        public string cadena;



        // private SEMP2013_Context db;
        public BolsasForm(string _cadena)
        {
            InitializeComponent();

            conectionHelper = new ConectionHelper();
            db = new DataContext(conectionHelper.SQLConectionAsync(_cadena));

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;



        }

        #endregion
      

        #region attributtes (atributos)
        public DateTime dateTimeInicio { get; set; }
        public DateTime dateTimeFin { get; set; }
        public List<TiposOrden> tiposOrden { get; set; }
        public List<ModoOrdenes> modosOrden { get; set; }
        public int OpcionDR { get; set; }
        public List<string> tipos { get; set; }

        #endregion

        #region Properties

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


        #region Events
        private void BolsasForm_Load(object sender, EventArgs e)
        {
            load();
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                VistaPreviaForm vista = new VistaPreviaForm();
                vista.leyenda = this.Text + "- Previo -Localidad Actual: " + user.Loc;
                vista.vistaM = dt;
                vista.Show();

            }
            else
            {
                MessageBox.Show("NO hay resultados cargados!", "Aud Semp", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                 "Aud Semp", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
                prg1.Value = 0;
                lblProgress.Text = "-";


            }
        }
        private void btnReporte_Click(object sender, EventArgs e)
        {


            if (dt.Rows.Count > 0)
            {
                DialogResult resulta = MessageBox.Show("¿Crear Ejercicio Anterior?" +
                    "Si(Crea) No(Para Generar uno Nuevo)", "Aud SEMP",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (resulta == DialogResult.No)
                {

                    dt.Clear();
                    dt.Reset();

                }


            }


            DialogResult result = MessageBox.Show("Crear Reporte", "Aud SEMP",
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
        private void btnExportar_Click(object sender, EventArgs e)
        {


            if (dt.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Exportar Ejercicio Anterior?" +
                    "Si(Exporta) No(Para Generar uno Nuevo)", "Aud SEMP",
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
                        "Aud SEMP", MessageBoxButtons.OK,
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
        private void checkPrendas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPrendas.Checked == true)
            {
                ChekMode(1);
            }
            
        }
        private void checkContratos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkContratos.Checked == true)
            {
                ChekMode(2);
            }

          


        }
        #endregion

        #region Methods (metodos)
        public void load()
        {
            checkPrendas.Checked = true;
            checkContratos.Checked = false;

            OpcionDR = 1;

            BolsasPresenter bolsasPresenter = new BolsasPresenter(this,db);
            bolsasPresenter.timeInicio();
            bolsasPresenter.timeFin();
            bolsasPresenter.tiposOrden();
            bolsasPresenter.TiposPrenda();
            //
            bolsasPresenter.modosOrden();


            foreach (var item in tipos)
            {
                chkPrendas.Items.Add(item, CheckState.Checked);
            }
            //
            dtInicio.Value = dateTimeInicio;
            dtFin.Value = dateTimeFin;

            cmbOrden.DataSource = modosOrden;
            cmbTipoOrden.DataSource = tiposOrden;
            btnCancel.Visible = false;

            this.Text = this.Text + " -Localidad Actual: " + user.Loc;
        }

        private void ChekMode(int opcion)
        {
            if (opcion == 1)
            {
                OpcionDR = 1;
                BolsasPresenter bolsasPresenter = new BolsasPresenter(this,db);
                bolsasPresenter.TiposPrenda();
                bolsasPresenter.timeInicio();
                bolsasPresenter.timeFin();
                bolsasPresenter.tiposOrden();
                bolsasPresenter.modosOrden();
                //
                checkContratos.Checked = false;
                checkPrendas.Checked = true;


                dtInicio.Value = dateTimeInicio;
                dtFin.Value = dateTimeFin;

                chkPrendas.Items.Clear();

                cmbOrden.DataSource = modosOrden;
                cmbTipoOrden.DataSource = tiposOrden;

                foreach (var item in tipos)
                {

                    chkPrendas.Items.Add(item, CheckState.Checked);
                }

            }
            else
            {
                OpcionDR = 2;
                BolsasPresenter bolsasPresenter = new BolsasPresenter(this,db);
                bolsasPresenter.TiposPrenda();
                bolsasPresenter.timeInicio();
                bolsasPresenter.timeFin();
                bolsasPresenter.tiposOrden();
                bolsasPresenter.modosOrden();
                //   
                checkPrendas.Checked = false;
                checkContratos.Checked = true;

                chkPrendas.Items.Clear();

                cmbOrden.DataSource = modosOrden;
                cmbTipoOrden.DataSource = tiposOrden;

                foreach (var item in tipos)
                {
                    chkPrendas.Items.Add(item, CheckState.Checked);
                }



            }
        }

        public void Excel(string ruta)
        {

            string fechaInicio, fechaFin, tipoOrden = "INT", orden = "Ascendente";
            List<categorias> tipoPrendas = new List<categorias>();
          

            int a = chkPrendas.CheckedIndices.Count;
           
            if (a == 0)
            {
                for (int i = 0; i < chkPrendas.Items.Count; i++)
                {
                    chkPrendas.SetItemChecked(i, true);
                }

            }
           


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

            if (checkOrden.Checked == true)
            {
                tipoOrden = cmbTipoOrden.Text;
            }
            else
            {
                tipoOrden = "INT";
            }

            if (checkModo.Checked == true)
            {
                orden = cmbOrden.Text;
            }
            else
            {
                orden = "Ascendente";
            }

            leyendaTipos = "";
            leyendaEstatus = "";

            //if (checkPrendas.Checked == false)
            //{
            //    checkPrendas.Checked = true;

            //}

            //if (checkContratos.Checked == false)
            //{
            //    checkContratos.Checked = true;
            //}


            foreach (var item in chkPrendas.CheckedItems)
            {
                tipoPrendas.Add(
                     new categorias() { categoria = item.ToString() }
                     );
                leyendaTipos += item.ToString() + " - ";
            }



            Export(fechaInicio, fechaFin, tipoOrden, orden, tipoPrendas,OpcionDR);

        }


        public void Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden,
           List<categorias> tipos, int opcion)
        {

          // DataTable dt = new DataTable();

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);
            int i = 0;


            if (dt.Rows.Count == 0)
            {

                if (opcion == 2)
                {
                    dt.TableName = "BolsasOtros";
                    dt.Columns.AddRange(new DataColumn[25]
                    {

                     new DataColumn("Contrato",typeof(Int32)),
                     new DataColumn("Fecha"),
                     new DataColumn("Bolsa",typeof(Int32)),
                     new DataColumn("Descripcion"),
                     new DataColumn("SubDescripcion"),
                     new DataColumn("Tipo"),
                     new DataColumn("Avaluo"),
                     new DataColumn("Estatus_Prenda"),
                     new DataColumn("Condiciones"),
                     new DataColumn("Cantidad"),
                     new DataColumn("Localidad"),
                     new DataColumn("Ubicacion"),
                     new DataColumn("Posicion"),
                     new DataColumn("sucursal"),
                     new DataColumn("registro"),
                     new DataColumn("NO"),
                     new DataColumn("folio"),
                     new DataColumn("origen"),
                     new DataColumn("Prestamo",typeof(double)),
                     new DataColumn("INT"),
                     new DataColumn("detalles"),
                     new DataColumn("caja"),
                     new DataColumn("detalles_art"),
                     new DataColumn("modelo"),
                     new DataColumn("noserie")

                    });

                    foreach (var items in tipos)
                    {

                        var result = from s in db.Bolsas_OTROS.Where(p => p.Fecha >= Inicio &&
                                      p.Fecha <= Fin &&
                                      p.Tipo == items.categoria).ToList()
                                     select s;

                        foreach (var item in result)
                        {
                            cantidad = result.Count();
                            i++;
                            backgroundWorker1.ReportProgress(i);

                            if (cancelEjercicio == 1)
                            {
                                break;
                            }

                            dt.Rows.Add(item.Contrato, Convert.ToDateTime(item.Fecha).ToString("dd-MM-yyyy"), item.Bolsa,
                                item.Descripcion, item.SubDescripcion,
                                item.Tipo, Convert.ToDecimal(item.Avaluo), item.Estatus_Prenda, item.Condiciones,
                                item.Cantidad, item.Localidad, item.Ubicacion, item.Posicion,
                                item.sucursal, item.registro, item.NO,
                                item.folio, item.origen, Convert.ToDecimal(item.prestamo), item.INT, item.detalles, item.caja,
                                item.detalles_art, item.modelo, item.noserie);


                        }
                        i = 0;



                    }

                }
                else
                {

                    dt.TableName = "BolsasOro";
                    dt.Columns.AddRange(new DataColumn[22]
                    {

                 new DataColumn("Contrato",typeof(Int32)),
                 new DataColumn("Fecha"),
                 new DataColumn("Bolsa",typeof(Int32)),
                 new DataColumn("Descripcion"),
                 new DataColumn("SubDescripcion"),
                 new DataColumn("Kilates"),
                 new DataColumn("PesoReal"),
                 new DataColumn("Tipo"),
                 new DataColumn("Avaluo"),
                 new DataColumn("Prestamo",typeof(double)),
                 new DataColumn("EstatusPrenda"),
                 new DataColumn("Cantidad"),
                 new DataColumn("Localidad"),
                 new DataColumn("Ubicacion"),
                 new DataColumn("Posicion"),
                 new DataColumn("registro"),
                 new DataColumn("folio"),
                 new DataColumn("origen"),
                 new DataColumn("INT"),
                 new DataColumn("condiciones"),
                 new DataColumn("caja"),
                 new DataColumn("pneto")

                    });

                    foreach (var items in tipos)
                    {

                        var result = from s in db.Bolsas_ORO.Where(p => p.Fecha >= Inicio &&
                                      p.Fecha <= Fin &&
                                      p.Tipo == items.categoria).ToList()
                                     select s;

                        foreach (var item in result)
                        {
                            cantidad = result.Count();
                            i++;
                            backgroundWorker1.ReportProgress(i);

                            if (cancelEjercicio == 1)
                            {
                                break;
                            }

                            dt.Rows.Add(item.Contrato, Convert.ToDateTime(item.Fecha).ToString("dd-MM-yyyy"), item.Bolsa,
                                item.Descripcion, item.SubDescripcion, item.Kilates, item.PesoReal,
                                item.Tipo, Convert.ToDecimal(item.Avaluo), Convert.ToDecimal(item.Prestamo), item.EstatusPrenda, item.Cantidad,
                                item.Localidad, item.Ubicacion, item.Posicion, item.registro,
                                item.folio, item.origen, item.INT, item.condiciones, item.caja,
                                item.pneto);


                        }

                        i = 0;


                    }


                }


            }
            DataView dataView = new DataView(dt);


            //ORDER MODE
            mode = tipoOrden + modoOrden;
            switch (mode)
            {
                default:
                    dataView.Sort = "INT asc";
                    break;
                case "ContratoAscendente":
                    dataView.Sort = "Contrato asc";
                    break;
                case "ContratoDescendente":
                    dataView.Sort = "Contrato desc";
                    break;
                case "BolsaAscendente":
                    dataView.Sort = "Bolsa asc";
                    break;
                case "BolsaDescendente":
                    dataView.Sort = "Bolsa desc";
                    break;
                case "PrestamoAscendente":
                    dataView.Sort = "Prestamo asc";
                    break;
                case "PrestamoDescendente":
                    dataView.Sort = "Prestamo desc";
                    break;
                case "TipoAscendente":
                    dataView.Sort = "Tipo asc";
                    break;
                case "TipoDescendente":
                    dataView.Sort = "Tipo desc";
                    break;
                case "CajaAscendente":
                    dataView.Sort = "caja asc";
                    break;
                case "CajaDescendente":
                    dataView.Sort = "caja desc";
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
                if (OpcionDR == 2)
                {
                    dt.WriteXml("C:/SEMP2013/AudSemp/AudSemp/XML/audBotros.xml", XmlWriteMode.WriteSchema);
                }
                else
                {
                    dt.WriteXml("C:/SEMP2013/AudSemp/AudSemp/XML/audBoro.xml", XmlWriteMode.WriteSchema);

                }

            }


        }


        #endregion
     
        #region background
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
                if (OpcionDR == 1)
                {
                    BolsasJoyeriaRPT ob = new BolsasJoyeriaRPT();
                    //LocalidadModel localidadModel = new LocalidadModel();
                    //localidadModel.localidadResult(loc);
                    ob.SetParameterValue("tipos", leyendaTipos);
                    ob.SetParameterValue("estatus", "Todos");
                    ob.SetParameterValue("rangos", leyendaRango);
                    ob.SetParameterValue("modoOrden", mode);

                    ob.SetParameterValue("sucursal", user.NameLoc);
                    ob.SetParameterValue("marca", user.Marca);
                    ob.SetParameterValue("empresa", user.Empresa);
                    ob.SetParameterValue("localidad", user.Loc);
                    ob.SetParameterValue("encargado",user.Boss);
                    ob.SetParameterValue("logo", user.Boss);
                    crystalReportViewer1.ReportSource = ob;
                }
                else
                {
                    BolsasOtrosRPT ob = new BolsasOtrosRPT();
                    //LocalidadModel localidadModel = new LocalidadModel();
                    //localidadModel.localidadResult(loc);
                    ob.SetParameterValue("tipos", leyendaTipos);
                    ob.SetParameterValue("estatus", "Todos");
                    ob.SetParameterValue("rangos", leyendaRango);
                    ob.SetParameterValue("modoOrden", mode);

                    ob.SetParameterValue("sucursal", user.NameLoc);
                    ob.SetParameterValue("marca", user.Marca);
                    ob.SetParameterValue("empresa", user.Empresa);
                    ob.SetParameterValue("localidad", user.Loc);
                    ob.SetParameterValue("encargado", user.Boss);
                    ob.SetParameterValue("logo", user.Logotipo);

                    crystalReportViewer1.ReportSource = ob;

                }

                crystalReportViewer1.Refresh();


            }

            MessageBox.Show("Operación Realizada con Exito",
                   "Aud Semp", MessageBoxButtons.OK,
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
