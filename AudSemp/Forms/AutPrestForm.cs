

namespace AudSemp.Forms
{
    #region Libraries (librerias)
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
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
    public partial class AutPrestForm : Form,IAutPrest
    {


        #region Context

        private DataContext db;
        IConectionHelper conectionHelper;
        public User user;
        public string cadena;



        // private SEMP2013_Context db;
        public AutPrestForm(string _cadena)
        {
            InitializeComponent();

            conectionHelper = new ConectionHelper();
            db = new DataContext(conectionHelper.SQLConectionAsync(_cadena));

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;



        }

        #endregion

        #region attributtes (atributos)

        public List<TiposOrden> tiposOrden { get; set; }
        public List<ModoOrdenes> modosOrden { get; set; }
        public DateTime dateTimeInicio { get ; set; }
        public DateTime dateTimeFin { get ; set ; }

        #endregion

        #region Properties

        public int decision;
        public string leyendaTipos;
        public string leyendaEstatus;
        public string leyendaRango;
        public string loc;
        public string mode;
        string ruta;
        int cantidad = 0;
        //variable to cancel progress
        public int cancelEjercicio;
        //table to report
        DataTable dt = new DataTable("AutPrestamos");



        #endregion

        #region Methods (Metodos)
        public void load()
        {


          
            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("NO"),
                    new DataColumn("FECHA",typeof(DateTime)),
                    new DataColumn("HORA"),
                    new DataColumn("USUARIO"),
                    new DataColumn("ANTERIOR"),
                    new DataColumn("NUEVO"),
                    new DataColumn("MOTIVO"),
                    new DataColumn("CONTRATO",typeof(Int32)),

            });



            AutPrestPresenter autPrestPresenter = new AutPrestPresenter(this,db);
          

            autPrestPresenter.tiposOrden();
            autPrestPresenter.modosOrden();


            dtInicio.Value= autPrestPresenter.timeInicio();
            dtFin.Value= autPrestPresenter.timeFin();
          
            cmbOrden.DataSource = modosOrden;
            cmbTipoOrden.DataSource = tiposOrden;
            btnCancel.Visible = false;

            this.Text = this.Text + " -Localidad Actual: " + user.Loc;
        }

        public void Excel(string ruta)
        {
            leyendaRango = "";
            leyendaEstatus = "";
            leyendaTipos = "";



            string fechaInicio, fechaFin, tipoOrden = "NO", orden = "Ascendente";
         


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
                tipoOrden = "no";
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


     

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);


            int i = 0;

                 var result = from s in db.autorizaciones_prestamos
                              .Where(p => p.fecha >= Inicio &&
                                      p.fecha <= Fin).ToList()
                                 select s;

            if (dt.Rows.Count == 0)
            {


                foreach (var item in result)
                {
                    cantidad = result.Count();
                    i++;
                    backgroundWorker1.ReportProgress(i);

                    if (cancelEjercicio == 1)
                    {
                        break;
                    }

                    dt.Rows.Add(item.no, DateTime.Parse(item.fecha.ToString()).ToString("dd-MM-yyyy"),
                        item.hora, item.usuario, item.anterior, item.nuevo, item.motivo, item.paraelcontrato);


                }
                i = 0;


            }

           

            DataView dataView = new DataView(dt);
          //  dt = new DataTable();

            //ORDER MODE
            mode = tipoOrden + modoOrden;
            switch (mode)
            {
                default:
                    dataView.Sort = "NO asc";
                    break;
                case "ContratoAscendente":
                    dataView.Sort = "CONTRATO asc";
                    break;
                case "ContratoDescendente":
                    dataView.Sort = "CONTRATO desc";
                    break;
                case "FechaAscendente":
                    dataView.Sort = "FECHA asc";
                    break;
                case "FechaDescendente":
                    dataView.Sort = "FECHA desc";
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


                dt.WriteXml("C:/SEMP2013/AudSemp/AudSemp/XML/audAutPrest.xml", XmlWriteMode.WriteSchema);



            }

        }


        #endregion

        #region Events (eventos)
        private void AutPrestForm_Load(object sender, EventArgs e)
        {
            load();
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
                 "Aud Semp", MessageBoxButtons.OK,
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

                AutPrestRPT ob = new AutPrestRPT();
                //LocalidadModel localidadModel = new LocalidadModel();

                //localidadModel.localidadResult(loc);
             
                ob.SetParameterValue("rangos", leyendaRango);
                ob.SetParameterValue("modoOrden", mode);

                ob.SetParameterValue("sucursal",user.NameLoc);
                ob.SetParameterValue("marca", user.Marca);
                ob.SetParameterValue("empresa", user.Empresa);
                ob.SetParameterValue("localidad", user.Loc);
                ob.SetParameterValue("encargado", user.Boss);
                ob.SetParameterValue("logo", user.Logotipo);



                crystalReportViewer1.ReportSource = ob;
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

        #endregion


    }
}
