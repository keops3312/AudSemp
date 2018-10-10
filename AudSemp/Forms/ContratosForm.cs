﻿//Form to logical to function Auditory to Contracts

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
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    #endregion
    public partial class ContratosForm : Form, IContratos
    {
        #region Context

        private SEMP2013_Context db;
        public ContratosForm()
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
        public List<string> tipos { get; set; }
        public List<string> status { get; set; }
        public List<TiposOrden> tiposOrden { get; set; }
        public List<ModoOrdenes> modosOrden { get; set; }

        public int decision;
        public string leyendaTipos;
        public string leyendaEstatus;
        public string leyendaRango;
        #endregion

        #region Properties
        string ruta;
        int cantidad;
        #endregion

        #region Events (Eventos)

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Crear Reporte", "Auditoria SEMP",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.OK:
                    {
                        decision = 2;
                        Excel("...");
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

                    int a = chkPrendas.CheckedIndices.Count;
                    int b = chkContratos.CheckedIndices.Count;
                    if (a == 0)
                    {
                        for (int i = 0; i < chkPrendas.Items.Count; i++)
                        {
                            chkPrendas.SetItemChecked(i, true);
                        }

                    }
                    if (b == 0)
                    {
                        for (int i = 0; i < chkContratos.Items.Count; i++)
                        {
                            chkContratos.SetItemChecked(i, true);
                        }

                    }

                    decision = 1;

                    backgroundWorker1.RunWorkerAsync();
                    btnExportar.Enabled = false;
                    btnCancel.Visible = true;

                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
                btnExportar.Enabled = true;
                btnCancel.Visible = false;

                MessageBox.Show("Exportacion CANCELADA",
                 "Auditoria Semp", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
                prg1.Value = 0;
                lblProgress.Text = "-";
              
               
            }
        }

        private void terminado(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Exportacion Realizada con Exito",
                   "Auditoria Semp", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            prg1.Value = 0;
        }

        private void Hazlo(object sender, DoWorkEventArgs e)
        {
            
            //Excel(ruta);
            
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Excel(ruta);
            Thread.Sleep(100);

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this is updated from dowork. Its where GUI components are update        
            prg1.Value = e.ProgressPercentage;
            lblProgress.Text = (e.ProgressPercentage.ToString() + " / " + cantidad + " # Registros Completados...");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //called when the heavy operation in bg is over . can also accept GUI compponents
            MessageBox.Show("Exportacion Realizada con Exito",
                   "Auditoria Semp", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            prg1.Value = 0;
            lblProgress.Text = "-";
            btnExportar.Enabled = true;
            btnCancel.Visible = false;

        }


        #endregion

        #region Methods (metodos)

        private void ContratosForm_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            ContratosPresenter contratosPresenter = new ContratosPresenter(this);
            contratosPresenter.TiposEstatus();
            contratosPresenter.TiposPrenda();
            contratosPresenter.timeInicio();
            contratosPresenter.timeFin();
            contratosPresenter.tiposOrden();
            contratosPresenter.modosOrden();

            foreach (var item in tipos)
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
        }

        public void Excel(string ruta)
        {
            string fechaInicio, fechaFin,tipoOrden="reg",orden="Ascendente";
            List<categorias> tipoPrendas = new List<categorias>();
            List<Estatus> tipoStatus = new List<Estatus>();


            if (checkFechas.Checked == true)
            {
                fechaInicio = dtInicio.Value.ToString();
                fechaFin = dtFin.Value.ToString();
            }
            else
            {
                fechaInicio =dateTimeInicio.ToString();
                fechaFin =dateTimeFin.ToString();

            }

            leyendaRango = fechaInicio + " - " + fechaFin;
          
            if(checkOrden.Checked==true)
            {
                tipoOrden = cmbTipoOrden.Text;
            }

            if (checkModo.Checked == true)
            {
                orden = cmbOrden.Text;
            }

          
            foreach (var item in chkPrendas.CheckedItems)
                {
                    tipoPrendas.Add(
                         new categorias() { categoria = item.ToString() }
                         );
                leyendaTipos = item.ToString() + " - ";
                }
         
               
            foreach (var item in chkContratos.CheckedItems)
                {
                    tipoStatus.Add(new Estatus() { estatu = item.ToString() }
                         );
                leyendaEstatus = item.ToString() + " - ";
                }

            Export(fechaInicio, fechaFin, tipoOrden, orden, tipoPrendas, tipoStatus);

        }

       

        public void Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden,
         List<categorias> tipos, List<Estatus> Estatus)
        {
           

            DataTable dt = new DataTable("Contratos");
            dt.Columns.AddRange(new DataColumn[40]
            {
            new DataColumn("Folio"),
            new DataColumn("Contrato"),
            new DataColumn("Fecha"),
            new DataColumn("Bolsa"),
            new DataColumn("IdClientes"),
            new DataColumn("NCliente"),
            new DataColumn("AutorizoA"),
            new DataColumn("Plazo"),
            new DataColumn("Status"),
            new DataColumn("FechaDesemp"),
            new DataColumn("Comentario"),
            new DataColumn("Dias"),
            new DataColumn("FechaCons"),
            new DataColumn("Prestamo"),
            new DataColumn("Interes"),
            new DataColumn("seguro"),
            new DataColumn("almacenaje"),
            new DataColumn("plazo1"),
            new DataColumn("plazo2"),
            new DataColumn("plazo3"),
            new DataColumn("avaluo"),
            new DataColumn("valuacion_tipo"),
            new DataColumn("cancelado"),
            new DataColumn("comentariocancelado"),
            new DataColumn("prestamoprom"),
            new DataColumn("origen"),
            new DataColumn("folioavaluo"),
            new DataColumn("clasificacion"),
            new DataColumn("santerior"),
            new DataColumn("caja"),
            new DataColumn("pension"),
            new DataColumn("Rev"),
            new DataColumn("reg"),
            new DataColumn("temp"),
            new DataColumn("VenOVig"),
            new DataColumn("realizo"),
            new DataColumn("CobroOriginal"),
            new DataColumn("BLOQUEADO_COMENTARIO"),
             new DataColumn("NoPrendas"),
             new DataColumn("DescPrendas")



            });

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);


            int i = 0;
            int cantidad=0;
            string descbolsa="";

            foreach (var items in tipos)
            {


                foreach (var itemEstatus in Estatus)
                {
                    var result = from s in db.contratos.Where(p => p.FechaCons >= Inicio &&
                                      p.FechaCons <= Fin &&
                                      p.valuacion_tipo == items.categoria &&
                                      p.Status == itemEstatus.estatu).ToList()
                                 select s;



                    foreach (var item in result)
                    {
                        cantidad= result.Count();
                        i++;
                        backgroundWorker1.ReportProgress(i);


                        if (item.valuacion_tipo == "Joyeria")
                        {
                            cantidad = db.bolsas_ORO.Count(a => a.Contrato == item.Contrato);
                            //var descrp = db.bolsas_ORO
                            //    .Where(a => a.Contrato == item.Contrato)
                            //    .First();
                            //descbolsa = descrp.Descripcion + " " + descrp.SubDescripcion;
                        }
                        else
                        {
                            cantidad = db.bolsas_OTROS.Count(a => a.Contrato == item.Contrato);
                            //var descrp1 = db.bolsas_OTROS
                            //    .Where(a => a.Contrato == item.Contrato)
                            //    .First();
                            //descbolsa = descrp1.Descripcion + " " + descrp1.SubDescripcion;




                        }
                       

                        dt.Rows.Add(item.Folio, item.Contrato, item.Fecha,
                            item.Bolsa, item.IdClientes, item.NCliente, item.AutorizoA,
                            item.Plazo, item.Status, item.FechaDesemp, item.Comentario, item.Dias,
                            Convert.ToDateTime(item.FechaCons).ToString("yyyy-MM-dd"), item.Prestamo, item.Interes, item.seguro,
                            item.almacenaje, item.plazo1, item.plazo2, item.plazo3, item.avaluo,
                            item.valuacion_tipo, item.cancelado, item.comentariocancelado,
                            item.prestamoprom, item.origen, item.folioavaluo, item.clasificacion, item.santerior,
                            item.caja, item.pension, item.Rev, item.reg, item.temp, item.VenOVig,
                            item.realizo, item.CobroOriginal, item.BLOQUEADO_COMENTARIO, cantidad,descbolsa);


                    }

                    i =0;
                }



            }


            DataView dataView = new DataView(dt);
            dt = new DataTable();
           
            //ORDER MODE
            string mode = tipoOrden + modoOrden;
            switch (mode)
            {
                default:
                    dataView.Sort = "reg ASC";
                    break;
                case "FechaConsAscendente":
                    dataView.Sort = "FechaCons ASC";
                    break;
                case "FechaConsDescendente":
                    dataView.Sort = "FechaCons DESC";
                    break;
                case "ContratoAscendente":
                    dataView.Sort = "Contrato ASC";
                    break;
                case "ContratoDescendente":
                    dataView.Sort = "Contrato DESC";
                    break;
                case "BolsaAscendente":
                    dataView.Sort = "Bolsa ASC";
                    break;
                case "BolsaDescendente":
                    dataView.Sort = "Bolsa DESC";
                    break;
                case "StatusAscendente":
                    dataView.Sort = "Status ASC";
                    break;
                case "StatusDescendente":
                    dataView.Sort = "Status DESC";
                    break;
                case "PrestamoAscendente":
                    dataView.Sort = "Prestamo ASC";
                    break;
                case "PrestamoDescendente":
                    dataView.Sort = "Prestamo DESC";
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
            else if(decision==2)
            {
                
                
                dt.WriteXml("C:/SEMP2013/AudSemp/AudSemp/XML/audContratos.xml", XmlWriteMode.WriteSchema);
                //creamos los para metros
               
                contratos ob = new contratos();
                LocalidadModel localidadModel = new LocalidadModel();
                localidadModel.localidadResult("TLX_2");
                ob.SetParameterValue("tipos", leyendaTipos);
                ob.SetParameterValue("estatus",leyendaEstatus);
                ob.SetParameterValue("rangos", leyendaRango);
                ob.SetParameterValue("modoOrden", mode);

                ob.SetParameterValue("sucursal", localidadModel.sucursal);
                ob.SetParameterValue("marca", localidadModel.marca);
                ob.SetParameterValue("empresa", localidadModel.empresa);
                ob.SetParameterValue("localidad", localidadModel.localidad);
                ob.SetParameterValue("encargado", localidadModel.encargado);



                crystalReportViewer1.ReportSource = ob;
                crystalReportViewer1.Refresh();
                

            }

        }






        #endregion

       
    }
}