

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
    #endregion
    public partial class ApartadosForm : Form,IApartados
    {

        #region Context

        private SEMP2013_Context db;
        public ApartadosForm()
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
            ApartadosPresenter apartadosPresenter = new ApartadosPresenter(this);
            apartadosPresenter.TiposEstatus();
            apartadosPresenter.TiposPrenda();
            apartadosPresenter.timeInicio();
            apartadosPresenter.timeFin();
            apartadosPresenter.tiposOrden();
            apartadosPresenter.modosOrden();

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
            leyendaRango = "";
            leyendaEstatus = "";
            leyendaTipos = "";
           


            string fechaInicio, fechaFin, tipoOrden = "no", orden = "Ascendente";
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


            DataTable dt = new DataTable("Apartados");
            dt.Columns.AddRange(new DataColumn[48]
            {
                    new DataColumn("no",typeof(Int32)),
                    new DataColumn("FOLIO_REM"),
                    new DataColumn("bolsa"),
                    new DataColumn("noinv"),
                    new DataColumn("noserie"),
                    new DataColumn("descripcion"),
                    new DataColumn("detalles"),
                    new DataColumn("preciosugerido"),
                    new DataColumn("precioventa"),
                    new DataColumn("kilates"),
                    new DataColumn("peso_real"),
                    new DataColumn("condiciones"),
                    new DataColumn("tipo"),
                    new DataColumn("status"),
                    new DataColumn("apartado_con"),
                    new DataColumn("apartado_cantidad"),
                    new DataColumn("aparto"),
                    new DataColumn("idcliente"),
                    new DataColumn("resta_por_pagar"),
                    new DataColumn("fecha_de_apartado",typeof(DateTime)),
                    new DataColumn("usuario"),
                    new DataColumn("realizado_en"),
                    new DataColumn("comentario"),
                    new DataColumn("liquido_fecha"),
                    new DataColumn("nota_liquido"),
                    new DataColumn("penalizado"),
                    new DataColumn("penalizado_precio"),
                    new DataColumn("Fecha_de_penalizacion"),
                    new DataColumn("mot_penalizacion"),
                    new DataColumn("cancelo"),
                    new DataColumn("fecha_cancelo"),
                    new DataColumn("mot_cancelo"),
                    new DataColumn("folio_apartado"),
                    new DataColumn("promocion"),
                    new DataColumn("vigencia"),
                    new DataColumn("precio_origen"),
                    new DataColumn("descuento"),
                    new DataColumn("tipo_desc"),
                    new DataColumn("precio_remate"),
                    new DataColumn("penalizacion_por"),
                    new DataColumn("cancelacion_por"),
                    new DataColumn("dias_minimo"),
                    new DataColumn("dias_normal"),
                    new DataColumn("dias_tolerancia"),
                    new DataColumn("apartado_min"),
                    new DataColumn("apartado_norm"),
                    new DataColumn("nombre_plazo"),
                    new DataColumn("tipo_apartado")
            });

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);


            int i = 0;

            foreach (var items in tipos)
            {


                foreach (var itemEstatus in Estatus)
                {
                    var result = from s in db.Apartados.Where(p => p.fecha_de_apartado >= Inicio &&
                                      p.fecha_de_apartado <= Fin &&
                                      p.tipo == items.categoria &&
                                      p.status == itemEstatus.estatu).ToList()
                                 select s;



                    foreach (var item in result)
                    {
                        cantidad = result.Count();
                        i++;
                        backgroundWorker1.ReportProgress(i);

                        dt.Rows.Add(item.no, item.FOLIO_REM, item.bolsa,
                            item.noinv, item.noserie, item.descripcion, item.detalles,
                            item.preciosugerido, item.precioventa, item.kilates, item.peso_real, item.condiciones,
                            item.tipo, item.status, item.apartado_con, item.apartado_cantidad,
                            item.aparto, item.idcliente, item.resta_por_pagar, Convert.ToDateTime(item.fecha_de_apartado).ToString("yyyy-MM-dd"), item.usuario,
                            item.realizado_en, item.comentario, item.liquido_fecha,
                            item.nota_liquido, item.penalizado, item.penalizado_precio, item.Fecha_de_penalizacion, item.mot_penalizacion,
                            item.cancelo, item.fecha_cancelo, item.mot_cancelo, item.folio_apartado, item.promocion, item.vigencia,
                            item.precio_origen, item.descuento, item.tipo_desc, item.precio_remate, item.penalizacion_por,
                            item.cancelacion_por, item.dias_minimo, item.dias_normal, item.dias_tolerancia, item.apartado_min,
                            item.apartado_norm, item.nombre_plazo, item.tipo_apartado);


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
                    dataView.Sort = "no asc";
                    break;
                case "No.InventarioAscendente":
                    dataView.Sort = "noinv asc";
                    break;
                case "No.InventarioDescendente":
                    dataView.Sort = "noinv desc";
                    break;
                case "FechaApartadoAscendente":
                    dataView.Sort = "fecha_de_apartado asc";
                    break;
                case "FechaApartadoDescendente":
                    dataView.Sort = "fecha_de_apartado desc";
                    break;
                case "StatusAscendente":
                    dataView.Sort = "status asc";
                    break;
                case "StatusDescendente":
                    dataView.Sort = "status desc";
                    break;
                case "CategoriaAscendente":
                    dataView.Sort = "tipo asc";
                    break;
                case "CategoriaDescendente":
                    dataView.Sort = "tipo desc";
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


                dt.WriteXml("C:/SEMP2013/AudSemp/AudSemp/XML/audApartados.xml", XmlWriteMode.WriteSchema);



            }

        }


        #endregion

        #region Events (Eventos)
        private void ApartadosForm_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
                backgroundWorker1.ReportProgress(0);
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
            else
            {
                for (int i = 0; i < chkContratos.Items.Count; i++)
                {
                    chkContratos.SetItemChecked(i, true);
                }


            }
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

                apartados ob = new apartados();
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
