﻿


namespace AudSemp.Forms
{
    #region Libraries (libreriras) 
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
    public partial class ApartadosHistorialForm : Form, IHistorialApartado
    {

        #region Context

        private DataContext db;
        IConectionHelper conectionHelper;
        public User user;
        public string cadena;
        private string cnn;



        // private SEMP2013_Context db;
        public ApartadosHistorialForm(string _cadena)
        {
            InitializeComponent();

            conectionHelper = new ConectionHelper();
            db = new DataContext(conectionHelper.SQLConectionAsync(_cadena));
            cnn = conectionHelper.SQLConectionAsync(_cadena);
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

        //variable to cancel progress
        public int cancelEjercicio;
        //table to report
        DataTable dt = new DataTable("CajaAuxiliar");


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
                //LocalidadModel localidadModel = new LocalidadModel();
                //localidadModel.localidadResult(loc);
                ob.SetParameterValue("tipos", ".");
                ob.SetParameterValue("estatus", leyendaEstatus);
                ob.SetParameterValue("rangos", leyendaRango);
                ob.SetParameterValue("modoOrden", mode);



                ob.SetParameterValue("sucursal", user.NameLoc);
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
        #endregion

        #region Methods (metodos)

     
        public void load()
        {
          
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

            HistorialApartadosPresenter HistorialApPresenter = new HistorialApartadosPresenter(this,db);
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

          

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);


            int i = 0;


            if (dt.Rows.Count == 0)
            {

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

                        if (cancelEjercicio == 1)
                        {
                            break;
                        }


                        using (SqlConnection cnx = new SqlConnection(cnn))
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
                                if (compare == itemEstatus.estatu)
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

            }

          


            DataView dataView = new DataView(dt);
           // dt = new DataTable();


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
                MessageBox.Show("NO hay resultados cargados!", "Auditoria Semp", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        #endregion


    }
}
