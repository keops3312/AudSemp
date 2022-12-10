﻿

namespace AudSemp.Forms
{
    #region Libraries
    using DocumentFormat.OpenXml.EMMA;
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using ClosedXML.Excel;
    using AudSemp.Models;
    using AudSemp.Classes;
    using AudSemp.Helpers;
   // using AudSemp.Context;
    using OperSemp.Commons.Data;
    using OperSemp.Commons.Entities;
    using OperSemp.Commons.Helper;
    #endregion

    public partial class NotasDeDescuentoForm : Form
    {


        #region Properties
        private NotasDeDescuentoModel model;
        //private BuscarLocalidad buscarLocalidad;
        private localidad _localidadUser;
        DataTable dt = new DataTable();

        List<NotasDescuento> lista;
        NotasDeDescuentoRPT rpt;

        public DateTime dateTimeInicio { get; set; }
        public DateTime dateTimeFin { get; set; }

        #endregion

        #region Attributes
        public string empresa;
        public string sucursal;
        public string nombreSucursal;
        public string encargado;
        public string logo;

        public string NombreOperaciones;

        string ruta;

        public int cancelEjercicio;
        public int desicion;




        //-----------------------------------//
        private string fechaInicio, fechaFin, tipoOrden = "consec", orden = "Ascendente";
        string[] categorias;
        string[] auditados;
        string[] autorizados;

        string _tipos = "";
        string _auditados = "";
        string _autorizados = "";
        #endregion

        #region Leyendas Reportes
        public int cantidad;
        public int decision;
        public string leyendaTipos;
        public string leyendaAuditados;
        public string leyendaAutorizados;
        public string leyendaRango;
        public string loc;
        public string mode;

        private int tipoFecha;
        #endregion

        #region Context

        private DataContext db;
        IConectionHelper conectionHelper;
        public User user;
        public string cadena;



        // private SEMP2013_Context db;
        public NotasDeDescuentoForm(string _cadena)
        {
            InitializeComponent();

            conectionHelper = new ConectionHelper();
            db = new DataContext(conectionHelper.SQLConectionAsync(_cadena));

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;



        }

        #endregion


        private void NotasDeDescuentoForm_Load(object sender, EventArgs e)
        {
            Cargar();
        }




        private void chkTodosAuditados_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkTodosAuditados.Checked)
            {
                for (int i = 0; i < chkListAuditados.Items.Count; i++)
                {
                    chkListAuditados.SetItemChecked(i, true);

                }

            }
            else
            {
                for (int i = 0; i < chkListAuditados.Items.Count; i++)
                {
                    chkListAuditados.SetItemChecked(i, false);

                }


            }
        }

        private void chkTodosAutorizados_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkTodosAutorizados.Checked)
            {
                for (int i = 0; i < chkListAutorizados.Items.Count; i++)
                {
                    chkListAutorizados.SetItemChecked(i, true);

                }

            }
            else
            {
                for (int i = 0; i < chkListAutorizados.Items.Count; i++)
                {
                    chkListAutorizados.SetItemChecked(i, false);

                }


            }
        }

        private void chkTipos_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkTipos.Checked)
            {
                for (int i = 0; i < chkListTipos.Items.Count; i++)
                {
                    chkListTipos.SetItemChecked(i, true);

                }

            }
            else
            {
                for (int i = 0; i < chkListTipos.Items.Count; i++)
                {
                    chkListTipos.SetItemChecked(i, false);

                }


            }
        }

        private void chkFechas_CheckedChanged(object sender, EventArgs e)
        {

            if (chkFechas.Checked == false)
            {
                dtInicial.Enabled = false;
                dtFinal.Enabled = false;
            }
            else
            {
                dtInicial.Enabled = true;
                dtFinal.Enabled = true;
            }
        }

        private void chkOrdenPor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOrdenPor.Checked == false)
            {
                cboOrden.Enabled = false;
            }
            else
            {
                cboOrden.Enabled = true;
            }
        }

        private void chkModoOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModoOrden.Checked == false)
            {
                cboOrdenModo.Enabled = false;
            }
            else
            {
                cboOrdenModo.Enabled = true;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
                backgroundWorker1.ReportProgress(0);
                cancelEjercicio = 1;



                btnExportarExcel.Enabled = true;
                btnReporte.Enabled = true;
                btnRegresar.Enabled = true;
                btnCancelar.Visible = false;


                MessageBox.Show("Exportacion CANCELADA",
                 "Aud Semp", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);



            }
        }

        private void btnRevisar_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Genere un Ejercicio Primero de tipo excel o reporte comenzar a Revisar",
                    "Aud SEMP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RevisarNDForm form = new RevisarNDForm();
            form.dt = dt;
            form.db = db;
            form.lista = lista;
            form._oString = cadena;
            form.nombreOperaciones = user.Name;
            form.ShowDialog();
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Genere un Ejercicio Primero de tipo excel o reporte para ver vista completa",
                    "Aud SEMP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            VistaPreviaNDForm form = new VistaPreviaNDForm();
            form.dt = dt;
            form.ShowDialog();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            //verify
            int ax;
            ax = chkListAuditados.CheckedIndices.Count;
            if (ax == 0)
            {
                MessageBox.Show("Selecciona un tipo de status Auditado", "Aud SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            ax = chkListAutorizados.CheckedIndices.Count;
            if (ax == 0)
            {
                MessageBox.Show("Selecciona un tipo de status Autorizado", "Aud SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }


            ax = chkListTipos.CheckedIndices.Count;
            if (ax == 0)
            {
                MessageBox.Show("Selecciona un tipo de prenda", "Aud SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }




            if (chkFechas.Checked == true)
            {
                fechaInicio = dtInicial.Value.ToString();
                fechaFin = dtFinal.Value.ToString();


                leyendaRango = Convert.ToDateTime(fechaInicio).ToString("dd-MMM-yyyy") +
                    " - " + Convert.ToDateTime(fechaFin).ToString("dd-MMM-yyyy");
            }
            else
            {
                // fechaInicio = dateTimeInicio.ToString();
                //fechaFin = dateTimeFin.ToString();
                fechaInicio = model.inicial().ToString("dd-MMM-yyyy");
                fechaFin = model.final().ToString("dd-MMM-yyyy");
                leyendaRango = "Todos los tiempos";
            }


            if (chkOrdenPor.Checked == true)
            {
                tipoOrden = cboOrden.SelectedValue.ToString();
            }
            else
            {
                tipoOrden = "consec";
            }

            if (chkModoOrden.Checked == true)
            {
                orden = cboOrdenModo.SelectedValue.ToString();
            }
            else
            {
                orden = "Ascendente";
            }


            leyendaTipos = "";
            leyendaAuditados = "";
            leyendaAutorizados = "";





            int marcados;
            marcados = chkListTipos.CheckedItems.Count;
            categorias = new string[marcados];
            leyendaTipos = string.Empty;

            int i = 0;
            int a = 0;
            while (i <= chkListTipos.Items.Count - 1)
            {

                if (chkListTipos.GetItemChecked(i))
                {
                    categorias[a] = "'" + chkListTipos.Items[i].ToString() + "'";
                    leyendaTipos += chkListTipos.Items[i].ToString() + "-";
                    a++;
                }
                i++;

            }




            i = 0;
            a = 0;
            marcados = chkListAuditados.CheckedItems.Count;
            auditados = new string[marcados];
            leyendaAuditados = string.Empty;
            while (i <= (chkListAuditados.Items.Count - 1))
            {
                if (chkListAuditados.GetItemChecked(i))
                {
                    auditados[a] = "'" + chkListAuditados.Items[i].ToString() + "'";
                    leyendaAuditados += chkListAuditados.Items[i].ToString() + "-";
                    a++;
                }
                i++;
            }



            i = 0;
            a = 0;
            marcados = chkListAutorizados.CheckedItems.Count;
            autorizados = new string[marcados];
            leyendaAutorizados = string.Empty;
            while (i <= (chkListAutorizados.Items.Count - 1))
            {
                if (chkListAutorizados.GetItemChecked(i))
                {
                    autorizados[a] = "'" + chkListAutorizados.Items[i].ToString() + "'";
                    leyendaAutorizados += chkListAutorizados.Items[i].ToString() + "-";
                    a++;
                }
                i++;
            }

            if (radioButton1.Checked == true)//fecha revision
            {
                tipoFecha = 1;
            }

            if (radioButton2.Checked == true)//fecha Aud
            {
                tipoFecha = 2;
            }

            if (radioButton3.Checked == true)//fecha autorizacion
            {
                tipoFecha = 3;
            }



            desicion = 2;
            btnExportarExcel.Enabled = false;
            btnReporte.Enabled = false;
            btnRegresar.Enabled = false;

            btnCancelar.Enabled = true;

            circularProgress1.Visible = true;
            circularProgress1.IsRunning = true;
            backgroundWorker1.RunWorkerAsync();


        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            //verify
            int ax;
            ax = chkListAuditados.CheckedIndices.Count;
            if (ax == 0)
            {
                MessageBox.Show("Selecciona un tipo de status Auditado", "Aud SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            ax = chkListAutorizados.CheckedIndices.Count;
            if (ax == 0)
            {
                MessageBox.Show("Selecciona un tipo de status Autorizado", "Aud SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }


            ax = chkListTipos.CheckedIndices.Count;
            if (ax == 0)
            {
                MessageBox.Show("Selecciona un tipo de prenda", "Aud SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }




            if (chkFechas.Checked == true)
            {
                fechaInicio = dtInicial.Value.ToString();
                fechaFin = dtFinal.Value.ToString();


                leyendaRango = Convert.ToDateTime(fechaInicio).ToString("dd-MMM-yyyy") +
                    " - " + Convert.ToDateTime(fechaFin).ToString("dd-MMM-yyyy");
            }
            else
            {
                // fechaInicio = dateTimeInicio.ToString();
                //fechaFin = dateTimeFin.ToString();
                fechaInicio = model.inicial().ToString("dd-MMM-yyyy");
                fechaFin = model.final().ToString("dd-MMM-yyyy");
                leyendaRango = "Todos los tiempos";
            }


            if (chkOrdenPor.Checked == true)
            {
                tipoOrden = cboOrden.SelectedValue.ToString();
            }
            else
            {
                tipoOrden = "Id";
            }

            if (chkModoOrden.Checked == true)
            {
                orden = cboOrdenModo.SelectedValue.ToString();
            }
            else
            {
                orden = "Ascendente";
            }


            leyendaTipos = "";
            leyendaAuditados = "";
            leyendaAutorizados = "";


            int marcados;
            marcados = chkListTipos.CheckedItems.Count;
            categorias = new string[marcados];
            leyendaTipos = string.Empty;

            int i = 0;
            int a = 0;
            while (i <= chkListTipos.Items.Count - 1)
            {

                if (chkListTipos.GetItemChecked(i))
                {
                    categorias[a] = "'" + chkListTipos.Items[i].ToString() + "'";
                    leyendaTipos += chkListTipos.Items[i].ToString() + "-";
                    a++;
                }
                i++;

            }




            i = 0;
            a = 0;
            marcados = chkListAuditados.CheckedItems.Count;
            auditados = new string[marcados];
            leyendaAuditados = string.Empty;
            while (i <= (chkListAuditados.Items.Count - 1))
            {
                if (chkListAuditados.GetItemChecked(i))
                {
                    auditados[a] = "'" + chkListAuditados.Items[i].ToString() + "'";
                    leyendaAuditados += chkListAuditados.Items[i].ToString() + "-";
                    a++;
                }
                i++;
            }



            i = 0;
            a = 0;
            marcados = chkListAutorizados.CheckedItems.Count;
            autorizados = new string[marcados];
            leyendaAutorizados = string.Empty;
            while (i <= (chkListAutorizados.Items.Count - 1))
            {
                if (chkListAutorizados.GetItemChecked(i))
                {
                    autorizados[a] = "'" + chkListAutorizados.Items[i].ToString() + "'";
                    leyendaAutorizados += chkListAutorizados.Items[i].ToString() + "-";
                    a++;
                }
                i++;
            }




            if (radioButton1.Checked == true)//fecha revision
            {
                tipoFecha = 1;
            }

            if (radioButton2.Checked == true)//fecha Aud
            {
                tipoFecha = 2;
            }

            if (radioButton3.Checked == true)//fecha autorizacion
            {
                tipoFecha = 3;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                desicion = 1;
                ruta = saveFileDialog1.FileName;

                if (string.IsNullOrEmpty(ruta))
                {
                    MessageBox.Show("No hay directorio Seleccionado",
                        "Aud SEMP", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {

                    btnExportarExcel.Enabled = false;
                    btnReporte.Enabled = false;
                    btnRegresar.Enabled = false;

                    btnCancelar.Enabled = true;

                    circularProgress1.Visible = true;
                    circularProgress1.IsRunning = true;
                    backgroundWorker1.RunWorkerAsync();





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

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            circularProgress1.Visible = false;
            circularProgress1.IsRunning = false;
            btnCancelar.Enabled = false;
            btnRegresar.Enabled = true;

            if (desicion == 2)
            {
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                //rpt.SetParameterValue("logo", logo);

                MessageBox.Show("Reporte Exitoso", "Aud SEMP",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }



        #region Methods
        private void Cargar()
        {
            try
            {
                List<string> listGenerica;

                model = new NotasDeDescuentoModel(cadena);

                listGenerica = new List<string>();
                listGenerica = model.AuditoriaTipo();

                foreach (var item in listGenerica)
                {
                    chkListAuditados.Items.Add(item, CheckState.Checked);
                }


                listGenerica = new List<string>();
                listGenerica = model.AutorizaTipo();

                foreach (var item in listGenerica)
                {
                    chkListAutorizados.Items.Add(item, CheckState.Checked);
                }


                listGenerica = new List<string>();
                listGenerica = model.TipoPrenda();
                foreach (var item in listGenerica)
                {
                    chkListTipos.Items.Add(item, CheckState.Checked);
                }




                cboOrden.DataSource = model.TiposOrden();
                cboOrden.ValueMember = "Tipo";
                cboOrden.SelectedValue = "Tipo";
                cboOrden.SelectedIndex = 0;

                cboOrdenModo.DataSource = model.Ordenes();
                cboOrdenModo.ValueMember = "modo";
                cboOrdenModo.SelectedValue = "modo";
                cboOrdenModo.SelectedIndex = 0;


                dtInicial.Value = model.inicial();
                dtFinal.Value = model.final();



                chkFechas.Checked = true;
                chkTodosAuditados.Checked = true;
                chkTodosAutorizados.Checked = true;
                chkTipos.Checked = true;
                chkModoOrden.Checked = true;
                chkOrdenPor.Checked = true;

                btnCancelar.Enabled = false;



                //buscarLocalidad = new BuscarLocalidad();
                //String[] find = buscarLocalidad.LocalidadBuscada();
                //nombreSucursal = find[1].ToString();
                //sucursal = find[0].ToString();
                //empresa = find[3].ToString();

                //encargado = find[4].ToString();
                //logo = find[5].ToString();

               // var data = buscarLocalidad.localidades();
                _localidadUser = new localidad();
                _localidadUser._direccion = user.Adress;
                _localidadUser._empresa = user.Empresa;
                _localidadUser._encargado = user.Boss;
                _localidadUser._logotipo = user.Logotipo;
                _localidadUser._nombreSucursal = user.NameLoc;
                _localidadUser._tablaInventarios = user.lugar_conta;
                _localidadUser._usuarioEnOperacion =user.Name;
                _localidadUser._localidad = user.Loc;




                circularProgress1.Visible = false;
                circularProgress1.IsRunning = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Fallo al cargar ventana!" + ex.Message.ToString(), "Aud SEMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public void Excel(string ruta)
        {


            Export(fechaInicio, fechaFin, tipoOrden, orden, categorias, auditados, autorizados, tipoFecha);

        }


        public void Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden,
           string[] tipos, string[] statusAudita, string[] statusAutorizado, int tipoFecha)
        {

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);
            DataView dataView;



            if (model.listaRevisionND( Inicio, Fin, tipos, statusAudita, statusAutorizado, tipoFecha) == true)
            {
                dataView = new DataView(model.dtNotasDescuento);
                lista = model.listaNotasDescuento;
            }
            else
            {


                MessageBox.Show("Exportacion Fallida Vuelva a Intentarlo",
                 "Aud Semp", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
                return;

            }




            //ORDER MODE

            
            mode = tipoOrden + modoOrden;
            switch (mode)
            {
                default:
                    dataView.Sort = "Id asc";
                    break;
                case "TipoOperacionAscendente":
                    dataView.Sort = "TipOperacion asc";
                    break;
                case "TipoOperacionDescendente":
                    dataView.Sort = "TipOperacion desc";
                    break;
                case "FechaAscendente":
                    dataView.Sort = "FechaDescuento asc";
                    break;
                case "FechaDescendente":
                    dataView.Sort = "FechaDescuento desc";
                    break;
                case "CajaAscendente":
                    dataView.Sort = "Caja asc";
                    break;
                case "CajaDescendente":
                    dataView.Sort = "Caja desc";
                    break;
                case "DescuentoAscendente":
                    dataView.Sort = "ImporteDescuento asc";
                    break;
                case "DescuentoDescendente":
                    dataView.Sort = "ImporteDescuento desc";
                    break;

                case "Status AuditadoAscendente":
                    dataView.Sort = "Auditado asc";
                    break;
                case "Status AuditadoDescendente":
                    dataView.Sort = "Auditado desc";
                    break;
                case "Status AutorizadoAscendente":
                    dataView.Sort = "GOAutorizado asc";
                    break;
                case "Status AutorizadoDescendente":
                    dataView.Sort = "GOAutorizado desc";
                    break;

            }

            dt = dataView.ToTable();
          
            if (desicion == 1)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {

                    wb.Worksheets.Add(dt);
                    wb.SaveAs(ruta);

                }


                MessageBox.Show("Exportación Exitosa", "Aud SEMP",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (desicion == 2)
            {


                dt.WriteXml("C:/SEMP2013/OperSemp/OperSemp/XML/oNotasDescuentoRPT.xml", XmlWriteMode.WriteSchema);

                _tipos = "";
                _auditados = "";
                _autorizados = "";

                int ii = 0;
                while (ii <= tipos.Length - 1)
                {
                    _tipos += tipos[ii].ToString() + "-";
                    ii++;
                }


                ii = 0;
                while (ii <= statusAudita.Length - 1)
                {
                    _auditados += statusAudita[ii].ToString() + "-";
                    ii++;
                }


                ii = 0;
                while (ii <= statusAutorizado.Length - 1)
                {
                    _autorizados += statusAutorizado[ii].ToString() + "-";
                    ii++;
                }



                rpt = new NotasDeDescuentoRPT();


                rpt.SetParameterValue("tipos", _tipos);
                rpt.SetParameterValue("estatus", _auditados);
                rpt.SetParameterValue("rangos", "del " + DateTime.Parse(fechaInicio).ToString("ddd dd MMMM yyyy") +
                                                   " al " + DateTime.Parse(fechaFin).ToString("ddd dd MMMM yyyy"));
                rpt.SetParameterValue("statusOperaciones", _autorizados);
                rpt.SetParameterValue("sucursal", user.NameLoc);
                rpt.SetParameterValue("empresa", user.Empresa);
                rpt.SetParameterValue("localidad", user.Loc);
                rpt.SetParameterValue("encargado", user.Boss);

                if (tipoFecha == 1)//fecha revision
                {
                    rpt.SetParameterValue("operaciones", user.Name);
                    rpt.SetParameterValue("leyendaCargo", "Auditoria");
                }

                if (tipoFecha == 2)//fecha auditoria
                {
                    rpt.SetParameterValue("operaciones", NombreOperaciones);
                    rpt.SetParameterValue("leyendaCargo", "Auditoria");
                }

                if (tipoFecha == 3)//fecha autorizacion
                {

                    rpt.SetParameterValue("operaciones", model.empleado());
                    rpt.SetParameterValue("leyendaCargo", "Autorización Dirección");
                }





            }


        }

        #endregion
    }
}
