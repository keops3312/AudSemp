


namespace AudSemp.Forms
{
    #region Libraries (libreriras)
    using AudSemp.Classes;
    using AudSemp.Context;
    using AudSemp.Models;
    using AudSemp.Presenter;
    using AudSemp.Views;
    using ClosedXML.Excel;
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using DocumentFormat.OpenXml.Spreadsheet;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
   
    #endregion
    public partial class ApartadosHistorialForm : Form, IHistorialApartado
    {

        #region Context

        private string CNX = ConfigurationManager.ConnectionStrings["SEMP2013_CNX"].ToString();

        private SEMP2013_Context db;
        public ApartadosHistorialForm()
        {
            InitializeComponent();
            db = new SEMP2013_Context();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
           

        }

        #endregion

        #region attributtes (atributos)
        public DateTime dateTimeInicio { get; set; }
        public DateTime dateTimeFin { get; set; }
        public List<string> status { get; set; }
        public List<TiposOrden> tiposOrden { get; set; }
        public List<ModoOrdenes> modosOrden { get; set; }


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

      
        #endregion

        #region Events (Eventos)
        private void ApartadosHistorialForm_Load(object sender, EventArgs e)
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

            if (checkContratos.Checked == true)
            {

              
                    for (int i = 0; i < chkContratos.Items.Count; i++)
                    {
                        chkContratos.SetItemChecked(i, true);
                    }
              

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

                HistorialApartadosReport ob = new HistorialApartadosReport();
                LocalidadModel localidadModel = new LocalidadModel();
                localidadModel.localidadResult(loc);
                //ob.SetParameterValue("tipos", leyendaTipos);
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

        #region Methods (metodos)

     
        public void load()
        {
            HistorialApartadosPresenter HistorialApPresenter = new HistorialApartadosPresenter(this);
            HistorialApPresenter.TiposEstatus();
            HistorialApPresenter.timeInicio();
            HistorialApPresenter.timeFin();
            HistorialApPresenter.tiposOrden();
            HistorialApPresenter.modosOrden();

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

            string fechaInicio, fechaFin, tipoOrden = "Fecha", orden = "Ascendente";
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
                tipoOrden = "Fecha";
            }

            if (checkModo.Checked == true)
            {
                orden = cmbOrden.Text;
            }
            else
            {
                orden = "Ascendente";
            }




          

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

           

            Export(fechaInicio, fechaFin, tipoOrden, orden,  tipoStatus);

        }



        public void Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden,
          List<Estatus> Estatus)
        {

            DataTable dt = new DataTable("CajaAuxiliar");
            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("Folio"),
                    new DataColumn("Acumulado",typeof(double)),
                    new DataColumn("FechaPrimMov",typeof(DateTime)),
                    new DataColumn("FechaUltMov",typeof(DateTime)),
                    new DataColumn("Comentario"),
                    new DataColumn("ultimoEstatus"),
                    new DataColumn("ultimaOperacion"),
                    new DataColumn("ultimoMovimiento"),
                    new DataColumn("Descripcion")
                     
            });

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);


            int i = 0;

         
           

                foreach (var itemEstatus in Estatus)
                {

                var result = (from p in db.CAJA_AUXILIAR
                              where p.Folio.Contains("A-") &&
                               p.Fecha >= Inicio &&
                               p.Fecha <= Fin 
                               select p.Folio).Distinct();




                foreach (var item in result)
                {
                    cantidad = result.Count();
                    i++;
                    backgroundWorker1.ReportProgress(i);
                    using (SqlConnection cnx = new SqlConnection(CNX))
                    {
                        cnx.Open();

                        using (SqlDataAdapter command = new SqlDataAdapter(" SELECT folio," +
                                        " SUM(CAST(abono AS decimal))  as Acumulado, " +
                                         " min(fecha) as fechaPrimMov, " +
                                          " max(fecha) as fechaUltMov, " +
                                          " max(Comentario) as Comentario, " +
                                          " max(status) as ultimoEstatus, " +
                                          " max(Apartado_no) as ultimaOperacion, " +
                                         " max(mov) as ultimoMovimiento, " +
                                          " max(concepto) as descripcion " +
                                          " FROM CAJA_AUXILIAR where folio='" + item.ToString() + "' GROUP BY Folio", cnx))
                        {
                            DataTable model = new DataTable();
                            model.Clear();
                            command.Fill(model);

                            string compare = model.Rows[0][5].ToString();
                            if (compare ==itemEstatus.estatu)
                            {
                                dt.Rows.Add(model.Rows[0][0].ToString(),
                              Convert.ToDecimal(model.Rows[0][1].ToString()),
                              Convert.ToDateTime(model.Rows[0][2].ToString()).ToString("yyyy-MM-dd"),
                              Convert.ToDateTime(model.Rows[0][3].ToString()).ToString("yyyy-MM-dd"),
                              model.Rows[0][4].ToString(),
                              model.Rows[0][5].ToString(),
                              model.Rows[0][6].ToString(),
                              model.Rows[0][7].ToString(),
                              model.Rows[0][8].ToString());

                            }






                        }



                    }

                }

                i = 0;
                }



          


            DataView dataView = new DataView(dt);
            dt = new DataTable();


            mode = tipoOrden + modoOrden;
            switch (mode)
            {
                default:
                    dataView.Sort = "Folio ASC";
                    break;
                case "FolioAscendente":
                    dataView.Sort = "Folio ASC";
                    break;
                case "FolioDescendente":
                    dataView.Sort = "Folio DESC";
                    break;
                case "FechaPrimerRegistroAscendente":
                    dataView.Sort = "FechaPrimMov ASC";
                    break;
                case "FechaPrimerRegistroDescendente":
                    dataView.Sort = "FechaPrimMov DESC";
                    break;
                case "FechaUltimoRegistroAscendente":
                    dataView.Sort = "FechaUltMov ASC";
                    break;
                case "FechaUltimoRegistroDescendente":
                    dataView.Sort = "FechaUltMov DESC";
                    break;
                case "AcumuladoAscendente":
                    dataView.Sort = "Acumulado ASC";
                    break;
                case "AcumuladoDescendente":
                    dataView.Sort = "Acumulado DESC";
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


                dt.WriteXml("C:/SEMP2013/AudSemp/AudSemp/XML/audHistApartado.xml", XmlWriteMode.WriteSchema);



            }

        }

        #endregion



    }
}
