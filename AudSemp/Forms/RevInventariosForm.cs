


namespace AudSemp.Forms
{

    #region Libraries (libreriras)
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
    public partial class RevInventariosForm : Form, IInventario
    {
        #region Context

        private DataContext db;
        IConectionHelper conectionHelper;
        public User user;
        public string cadena;



        // private SEMP2013_Context db;
        public RevInventariosForm(string _cadena)
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
        public List<string> tipos { get; set; }
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
        DataTable dt = new DataTable("Inventarios");
        #endregion

        #region Methods (Metodos)
        public void load()
        {
            dt.Columns.AddRange(new DataColumn[46]
        {
          new DataColumn("no"),
          new DataColumn("contrato"),
          new DataColumn("fecha"),
          new DataColumn("bolsa"),
          new DataColumn("noinv"),
          new DataColumn("noserie"),
          new DataColumn("descripcion"),
          new DataColumn("detalles"),
          new DataColumn("preciosugerido"),
          new DataColumn("precioventa",typeof(double)),
          new DataColumn("kilates"),
          new DataColumn("peso_real"),
          new DataColumn("condiciones"),
          new DataColumn("tipo"),
          new DataColumn("status"),
          new DataColumn("mov"),
          new DataColumn("rematado"),
          new DataColumn("rematado_por"),
          new DataColumn("mod_extemporanea"),
          new DataColumn("transferido"),
          new DataColumn("sucursal"),
          new DataColumn("status_transferido"),
          new DataColumn("fecha_trans"),
          new DataColumn("actualizacion"),
          new DataColumn("codigotrans"),
          new DataColumn("pneto"),
          new DataColumn("NOTAS"),
          new DataColumn("AOM"),
          new DataColumn("rematadoEJ",typeof(DateTime)),
          new DataColumn("precio_promocion"),
          new DataColumn("fechaPP"),
          new DataColumn("precioPromo2"),
          new DataColumn("fechaPP2"),
          new DataColumn("precioPromo3"),
          new DataColumn("fechaPP3"),
          new DataColumn("precioRemate"),
          new DataColumn("fechaPRem"),
          new DataColumn("precio_origen"),
          new DataColumn("actualizo"),
          new DataColumn("actualizo2"),
          new DataColumn("actualizo3"),
          new DataColumn("prestamo"),
          new DataColumn("contrato2"),
          new DataColumn("fecha_contrato"),
          new DataColumn("indice"),
          new DataColumn("Antiguedad")


        });

            InventarioPresenter inventarioPresenter = new InventarioPresenter(this,db);
            inventarioPresenter.TiposEstatus();
            inventarioPresenter.TiposPrenda();
            inventarioPresenter.timeInicio();
            inventarioPresenter.timeFin();
            inventarioPresenter.tiposOrden();
            inventarioPresenter.modosOrden();

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

            this.Text = this.Text + " -Localidad Actual: " + user.Loc;
        }

        public void Excel(string ruta)
        {
            string fechaInicio, fechaFin, tipoOrden = "reg", orden = "Ascendente";
            List<categorias> tipoPrendas = new List<categorias>();
            List<Estatus> tipoStatus = new List<Estatus>();
            leyendaTipos = "";
            leyendaEstatus = "";

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
                tipoOrden = "Indice";
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


            Export(fechaInicio, fechaFin, tipoOrden, orden, tipoPrendas, tipoStatus);

        }



        public void Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden,
         List<categorias> tipos, List<Estatus> Estatus)
        {


            //DataTable dt = new DataTable("Inventarios");
        

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);


            int i = 0;
            int totalDays;


            if (dt.Rows.Count == 0)
            {


                foreach (var items in tipos)
                {


                    foreach (var itemEstatus in Estatus)
                    {
                        var result = from s in db.Artventas.Where(p => p.rematadoEJ >= Inicio &&
                                          p.rematadoEJ <= Fin &&
                                          p.tipo == items.categoria &&
                                          p.status == itemEstatus.estatu).ToList()
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


                            TimeSpan t = DateTime.Now - DateTime.Parse(item.rematadoEJ.ToString());
                            totalDays = Convert.ToInt32(t.TotalDays);

                            dt.Rows.Add(item.no, item.contrato, item.fecha,
                                item.bolsa, item.noinv, item.noserie, item.descripcion,
                                item.detalles, item.preciosugerido, item.precioventa, item.kilates, item.peso_real,
                                item.condiciones, item.tipo, item.status, item.mov,
                                item.rematado, item.rematado_por, item.mod_extemporanea, item.transferido, item.sucursal,
                                item.status_transferido, item.fecha_trans, item.actualizacion,
                                item.codigotrans, item.pneto, item.NOTAS, item.AOM, item.rematadoEJ,
                                item.precio_promocion, item.fechaPP, item.precioPromo2, item.fechaPP2, item.precioPromo3, item.fechaPP3,
                                item.precioRemate, item.fechaPRem, item.precio_origen, item.actualizo, item.actualizo2, item.actualizo3,
                                item.prestamo, item.contrato2, item.fecha_contrato, item.indice, totalDays);


                        }
                        i = 0;

                    }



                }

            }


            DataView dataView = new DataView(dt);
           // dt = new DataTable();

            //ORDER MODE
            mode = tipoOrden + modoOrden;
            switch (mode)
            {
                default:
                    dataView.Sort = "Indice asc";
                    break;
                case "InventarioAscendente":
                    dataView.Sort = "noinv asc";
                    break;
                case "InventarioDescendente":
                    dataView.Sort = "noinv desc";
                    break;
                case "FechaRemateAscendente":
                    dataView.Sort = "rematadoEJ asc";
                    break;
                case "FechaRemateDescendente":
                    dataView.Sort = "rematadoEJ desc";
                    break;
                case "TipoAscendente":
                    dataView.Sort = "tipo asc";
                    break;
                case "TipoDescendente":
                    dataView.Sort = "tipo desc";
                    break;
                case "StatusAscendente":
                    dataView.Sort = "status asc";
                    break;
                case "StatusDescendente":
                    dataView.Sort = "status desc";
                    break;
                case "PrecioAscendente":
                    dataView.Sort = "precioventa asc";
                    break;
                case "PrecioDescendente":
                    dataView.Sort = "precioventa desc";
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


                dt.WriteXml("C:/SEMP2013/AudSemp/AudSemp/XML/audInventariosII.xml", XmlWriteMode.WriteSchema);



            }

        }


        #endregion

        #region Events
        private void RevInventariosForm_Load(object sender, EventArgs e)
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

                InvIIRPT ob = new InvIIRPT();
                //LocalidadModel localidadModel = new LocalidadModel();
                //localidadModel.localidadResult(loc);
                ob.SetParameterValue("tipos", leyendaTipos);
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
