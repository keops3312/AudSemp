using AudSemp.Classes;
using AudSemp.Context;
using AudSemp.Presenter;
using AudSemp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudSemp.Forms
{
    public partial class AutPrestForm : Form,IAutPrest
    {


        #region Context

        private SEMP2013_Context db;
        public AutPrestForm()
        {
            InitializeComponent();
            db = new SEMP2013_Context();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

        }
        #endregion

        #region attributtes (atributos)
      
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
            AutPrestPresenter autPrestPresenter = new AutPrestPresenter(this);

            autPrestPresenter.tiposOrden();
            autPrestPresenter.modosOrden();

          
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


            DataTable dt = new DataTable("AutPrestamos");
            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("NO"),
                    new DataColumn("FECHA"),
                    new DataColumn("HORA"),
                    new DataColumn("USUARIO"),
                    new DataColumn("ANTERIOR"),
                    new DataColumn("NUEVO"),
                    new DataColumn("MOTIVO"),
                    new DataColumn("CONTRATO"),
                    
            });

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);


            int i = 0;

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








      

        private void AutPrestForm_Load(object sender, EventArgs e)
        {

        }
    }
}
