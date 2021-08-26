
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
    public partial class Aleattorios2Form : Form, IContratos
    {


        #region Context

        private SEMP2013_Context db;
        public Aleattorios2Form()
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


        #endregion

        #region Properties

        int decision;
        public string leyendaTipos;
        public string leyendaEstatus;
        public string leyendaRango;
        public string loc;
        public string mode;
        string ruta;
        int cantidad = 0;
        int counCOntratos;
        //variable to cancel progress
        public int cancelEjercicio;

        DataTable dt = new DataTable("AudContratos");
        DataTable dt2 = new DataTable("AudContratosBolsas");
       
        #endregion

        #region Events (Eventos)

        private void btnReporte_Click(object sender, EventArgs e)
        {

            DateTime Inicio = DateTime.Parse(dtInicio.Value.ToString());
            DateTime Fin = DateTime.Parse(dtFin.Value.ToString());

            counCOntratos = db.contratos.Count(p => p.FechaCons >= Inicio
                                                    && p.FechaCons <= Fin);

            if (integerInput1.Value > counCOntratos)
            {

                MessageBox.Show("No cuento con ese numero de Aleatorios!" +
                    "El numero de contratos en ese rango de fecha es de: " + counCOntratos,
                       "Auditoria SEMP", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(integerInput1.Value.ToString()) || integerInput1.Value < 20
                || string.IsNullOrWhiteSpace(integerInput1.Value.ToString()))
            {
                MessageBox.Show("Ingrese una cantidad coherente por favor el minimode de aleatarios es 20",
                       "Auditoria SEMP", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                return;
            }


            if (dt.Rows.Count > 0)
            {
                DialogResult resulta = MessageBox.Show("¿Crear Ejercicio Anterior?" +
                    "Si(Crea) No(Para Generar uno Nuevo)", "Auditoria SEMP",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (resulta == DialogResult.No)
                {

                    dt.Clear();


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
        private void btnExportar_Click(object sender, EventArgs e)
        {


            DateTime Inicio = DateTime.Parse(dtInicio.Value.ToString());
            DateTime Fin = DateTime.Parse(dtFin.Value.ToString());

            counCOntratos = db.contratos.Count(p => p.FechaCons >= Inicio
                                                    && p.FechaCons <= Fin);

            if (integerInput1.Value > counCOntratos)
            {

                MessageBox.Show("No cuento con ese numero de Aleatorios!" +
                    "El numero de contratos en ese rango de fecha es de: " + counCOntratos,
                       "Auditoria SEMP", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(integerInput1.Value.ToString()) || integerInput1.Value < 20
                || string.IsNullOrWhiteSpace(integerInput1.Value.ToString()))
            {
                MessageBox.Show("Ingrese una cantidad coherente por favor el minimode de aleatarios es 20",
                       "Auditoria SEMP", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                return;
            }




            if (dt.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Exportar Ejercicio Anterior?" +
                    "Si(Exporta) No(Para Generar uno Nuevo)", "Auditoria SEMP",
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

                AleatorioRPT ob = new AleatorioRPT();
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

        private void dtFin_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime Inicio = DateTime.Parse(dtInicio.Value.ToString());
                DateTime Fin = DateTime.Parse(dtFin.Value.ToString());

                counCOntratos = db.contratos.Count(p => p.FechaCons >= Inicio
                                                        && p.FechaCons <= Fin);

                integerInput1.Value = counCOntratos;
                integerInput1.MinValue = 20;
                integerInput1.MaxValue = counCOntratos;
            }
            catch (Exception ex)
            {

            }

        }

        private void dtInicio_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime Inicio = DateTime.Parse(dtInicio.Value.ToString());
                DateTime Fin = DateTime.Parse(dtFin.Value.ToString());

                counCOntratos = db.contratos.Count(p => p.FechaCons >= Inicio
                                                        && p.FechaCons <= Fin);

                integerInput1.Value = counCOntratos;
                integerInput1.MinValue = 20;
                integerInput1.MaxValue = counCOntratos;
            }
            catch (Exception ex)
            {

            }
        }

        private void integerInput1_ValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Methods (metodos)

        private void Aleattorios2Form_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {


            dt.Columns.AddRange(new DataColumn[12]
             {
                    new DataColumn("Contrato"),
                    new DataColumn("Bolsa"),
                    new DataColumn("Fecha"),
                    new DataColumn("Avaluo"),
                    new DataColumn("Prestamo"),
                    new DataColumn("Tipo"),
                    new DataColumn("Status"),
                    new DataColumn("Plazo"),
                    new DataColumn("AvaluoOriginal"),
                    new DataColumn("PrestamoOriginal"),
                    new DataColumn("PrendasOriginal"),
                    new DataColumn("PrendasRaiz")




             });

            dt2.Columns.AddRange(new DataColumn[10]
           {
                    new DataColumn("Contrato"),
                    new DataColumn("Bolsa"),
                    new DataColumn("Fecha"),
                    new DataColumn("Descripcion"),
                    new DataColumn("SubDescripcion"),
                    new DataColumn("kt"),
                    new DataColumn("Peso"),
                    new DataColumn("Avaluo"),
                    new DataColumn("Prestamo"),  
                    new DataColumn("Status"),
              
           });


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

            this.Text = this.Text + " -Localidad Actual: " + loc;
        }

        public void Excel(string ruta)
        {
            string fechaInicio, fechaFin, tipoOrden = "reg", orden = "Ascendente";
            List<categorias> tipoPrendas = new List<categorias>();
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

            if (checkOrden.Checked == true)
            {
                tipoOrden = cmbTipoOrden.Text;
            }
            else
            {
                tipoOrden = "reg";
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



            if (checkPrendas.Checked == false)
            {


                if (chkPrendas.CheckedItems.Count > 0)
                {

                    foreach (var item in chkPrendas.CheckedItems)
                    {
                        tipoPrendas.Add(
                             new categorias() { categoria = item.ToString() }
                             );
                        leyendaTipos += item.ToString() + " - ";
                    }
                }
                else
                {
                    foreach (var item in chkPrendas.Items)
                    {
                        tipoPrendas.Add(
                             new categorias() { categoria = item.ToString() }
                             );
                        leyendaTipos += item.ToString() + " - ";
                    }
                }



            }
            else
            {

                foreach (var item in chkPrendas.CheckedItems)
                {
                    tipoPrendas.Add(
                         new categorias() { categoria = item.ToString() }
                         );
                    leyendaTipos += item.ToString() + " - ";
                }

            }

            Export(fechaInicio, fechaFin, tipoOrden, orden, tipoPrendas, tipoStatus, chkPrendas.CheckedItems.Count);

        }



        public void Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden,
         List<categorias> tipos, List<Estatus> Estatus, int noTipos)
        {





            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);


            int i = 0;
            int cuantos = integerInput1.Value;// / noTipos;
       


            if (dt.Rows.Count == 0)
            {

                
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
                            cantidad = result.Count();
                            i++;
                            backgroundWorker1.ReportProgress(i);

                            if (cancelEjercicio == 1)
                            {
                                break;
                            }


                            //*buscamos el prestamo inicial, valuacion inicial,*//
                            var vPInicial = db.contratos.Where(u => u.Bolsa == item.Bolsa).OrderBy(u => u.reg).FirstOrDefault();


                            if (item.valuacion_tipo != "Joyeria")
                            {

                                int conteoOrignal = db.bolsas_OTROS.Where(P => P.Contrato == vPInicial.Contrato).Count();
                                int conteoActual = db.bolsas_OTROS.Where(P => P.Contrato == item.Contrato).Count();

                                var contenido = db.bolsas_OTROS.Where(P => P.Contrato == item.Contrato).ToList().OrderBy(p=>p.Estatus_Prenda);

                                dt.Rows.Add(
                                    item.Contrato, item.Bolsa,
                             DateTime.Parse(item.FechaCons.ToString()).ToString("dd-MM-yyyy"),
                             item.avaluo,
                             item.Prestamo,
                             item.valuacion_tipo,
                             item.Status,
                             item.Plazo,
                             vPInicial.avaluo,
                             vPInicial.Prestamo,
                             conteoOrignal,
                             conteoActual
                             );

                                

                                if (contenido != null)
                                {
                                    foreach (var contenidos in contenido)
                                    {

                                        dt2.Rows.Add(
                                            contenidos.Contrato,
                                            contenidos.Bolsa,
                                            contenidos.Fecha,
                                            contenidos.Descripcion,
                                            contenidos.SubDescripcion,
                                            "0",
                                            "0",
                                            contenidos.Avaluo,
                                            contenidos.prestamo,
                                            contenidos.Estatus_Prenda
                                            );
                                    }

                                }
                              

                            }
                            else
                            {


                                int conteoOrignal = db.bolsas_ORO.Where(P => P.Contrato == vPInicial.Contrato).Count();
                                int conteoActual = db.bolsas_ORO.Where(P => P.Contrato == item.Contrato).Count();

                                var contenido = db.bolsas_ORO.Where(P => P.Contrato == item.Contrato).ToList().OrderBy(p => p.EstatusPrenda);

                                dt.Rows.Add(
                                    item.Contrato,
                                    item.Bolsa,
                             DateTime.Parse(item.FechaCons.ToString()).ToString("dd-MM-yyyy"),
                             item.avaluo,
                             item.Prestamo,
                             item.valuacion_tipo,
                             item.Status,
                             item.Plazo,
                             vPInicial.avaluo,
                             vPInicial.Prestamo,
                               conteoOrignal,
                             conteoActual
                             );



                                if (contenido != null)
                                {
                                    foreach (var contenidos in contenido)
                                    {

                                        dt2.Rows.Add(
                                            contenidos.Contrato,
                                            contenidos.Bolsa,
                                            contenidos.Fecha,
                                            contenidos.Descripcion,
                                            contenidos.SubDescripcion,
                                            contenidos.Kilates,
                                            contenidos.PesoReal,
                                            contenidos.Avaluo,
                                            contenidos.Prestamo,
                                            contenidos.EstatusPrenda
                                            );
                                    }

                                }


                            }





                        }

                        i = 0;
                    }



                }



                Random r = new Random();
                while (dt.Rows.Count > cuantos)
                {
                    int j = r.Next(0, dt.Rows.Count);
                    dt.Rows.RemoveAt(j);
                }

            }

            DataView dataView = new DataView(dt);
            //dt = new DataTable();

            ////ORDER MODE
            mode = tipoOrden + modoOrden;

          

            switch (mode)
            {
                default:
                    dataView.Sort = "Contrato ASC";
                    break;
                case "FechaAscendente":
                    dataView.Sort = "Tipo ASC ,Fecha ASC";
                    break;
                case "FechaDescendente":
                    dataView.Sort = "Tipo DESC ,Fecha DESC";
                    break;
                case "ContratoAscendente":
                    dataView.Sort = "Tipo ASC ,Contrato ASC";
                    break;
                case "ContratoDescendente":
                    dataView.Sort = "Tipo DESC ,Contrato DESC";
                    break;
                case "BolsaAscendente":
                    dataView.Sort = "Tipo ASC ,Bolsa ASC";
                    break;
                case "BolsaDescendente":
                    dataView.Sort = "Tipo DESC ,Bolsa DESC";
                    break;
                case "StatusAscendente":
                    dataView.Sort = "Tipo ASC ,Status ASC";
                    break;
                case "StatusDescendente":
                    dataView.Sort = "Tipo DESC ,Status DESC";
                    break;
                case "PrestamoAscendente":
                    dataView.Sort = "Tipo ASC ,Prestamo ASC";
                    break;
                case "PrestamoDescendente":
                    dataView.Sort = "Tipo DESC ,Prestamo DESC";
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


                dt.WriteXml("C:/SEMP2013/AudSemp/AudSemp/XML/audRandomContratos.xml", XmlWriteMode.WriteSchema);

                dt2.WriteXml("C:/SEMP2013/AudSemp/AudSemp/XML/audRandomContratosB.xml", XmlWriteMode.WriteSchema);



            }

        }







        #endregion

       
    }
}
