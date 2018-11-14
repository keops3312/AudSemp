

namespace AudSemp.Forms
{


    #region Libraries (libreria)
    using System;
    using System.Data;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using AudSemp.Classes;
    using AudSemp.Context;
    using AudSemp.Models;
    using ClosedXML.Excel;
    using DevComponents.DotNetBar;
    using iTextSharp.text;
    using iTextSharp.text.pdf;  
    #endregion
    public partial class TomaFisicaForm : Form
    {
        #region Context
        private SEMP2013_Context db;
        public TomaFisicaForm()
        {
            db = new SEMP2013_Context();
            InitializeComponent();
        }







        #endregion

        #region Properties
        int Opcion;
        DataTable result = new DataTable();
        Audtoma toma = new Audtoma();
        public string loc;
        #endregion

        #region Events (Eventos)
        private void TomaFisicaForm_Load(object sender, EventArgs e)
        {
            cmbTypeOfAud.Items.Add("Auditar Contratos");
            cmbTypeOfAud.Items.Add("Auditar Bolsas");
            cmbTypeOfAud.Items.Add("Auditar Inventarios");
            btnCancel.Visible = false;
            circularProgress1.Visible = false;
            //buttonX4.Enabled = false;
            buttonX5.Enabled = false;
            buttonX3.Focus();

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();


            openFD.Title = "Seleccionar archivos";
            openFD.Filter = "Todos los archivos (*.xlsx)|*.xlsx";
            openFD.Multiselect = false;
            DialogResult result = openFD.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txtRuta.Text = openFD.FileName;
            }





        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtRuta.Text) || String.IsNullOrEmpty(txtHoja.Text) || String.IsNullOrEmpty(cmbTypeOfAud.Text))
            {

                MessageBox.Show(
                    "Por favor carga Archivo," +
                    " nombre de hoja Excel " +
                    " y selecciona tipo de auditoria para continuar", "AudSemp",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);

                return;
            }


            if (cmbTypeOfAud.Text == "Auditar Contratos")
            {
                Opcion = 1;

               
                accion();
                backgroundWorker1.RunWorkerAsync();
            };
            if (cmbTypeOfAud.Text == "Auditar Bolsas")
            {
                TaskDialogInfo info = CreateTaskDialogInfoInv();
                eTaskDialogResult result = TaskDialog.Show(info);

            };
            if (cmbTypeOfAud.Text == "Auditar Inventarios")
            {
               
              
                TaskDialogInfo info = CreateTaskDialogInfoInv();
                eTaskDialogResult result = TaskDialog.Show(info);

                
            };

         


           
        }

       

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
           
            result =toma.AudPhisycal(txtRuta.Text, txtHoja.Text, Opcion);
            //Thread.Sleep(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

            circularProgress1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ResGrid.DataSource = result;
            circularProgress1.Visible = false;
            circularProgress1.IsRunning = false;
            btnCancel.Visible = false;
            buttonX3.Enabled = true;
            buttonX6.Enabled = true;
            buttonX4.Enabled = true;
            buttonX5.Enabled = true;
            MessageBox.Show(
                                "Terminado", "AudSemp",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
                btnCancel.Visible = false;
                circularProgress1.Visible = false;
                circularProgress1.IsRunning = false;
                MessageBox.Show("Auditoria CANCELADA",
                 "Auditoria Semp", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);

            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }



        private void buttonX4_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {



                if (string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    MessageBox.Show("No hay directorio Seleccionado",
                        "Auditoria SEMP", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {

                    ExportToExcelPdf(saveFileDialog1.FileName);

                }

            }

        }




        private void command1_Executed(object sender, EventArgs e)
        {

            Opcion = 2;
            TaskDialog.Close(eTaskDialogResult.Custom1);
            accion();
            backgroundWorker1.RunWorkerAsync();


        }

        private void command2_Executed(object sender, EventArgs e)
        {
            Opcion = 4;
            TaskDialog.Close(eTaskDialogResult.Custom1);
            accion();
            backgroundWorker1.RunWorkerAsync();

        }

        private void command3_Executed(object sender, EventArgs e)
        {
            Opcion = 3;
            TaskDialog.Close(eTaskDialogResult.Custom1);
            accion();
            backgroundWorker1.RunWorkerAsync();
        }


        private void command4_Executed(object sender, EventArgs e)
        {
            Opcion = 5;
            TaskDialog.Close(eTaskDialogResult.Custom1);
            accion();
            backgroundWorker1.RunWorkerAsync();
        }

       
        #endregion

        #region Methods (Metodos)
        private TaskDialogInfo CreateTaskDialogInfo()
        {
            TaskDialogInfo info = new TaskDialogInfo("AudSemp",
                                                      eTaskDialogIcon.Information,
                                                      "¿Que bolsa Voy Auditar?",
                                                      "",
                                                      eTaskDialogButton.Cancel,
                                                      eTaskDialogBackgroundColor.Blue,null, GetCommandButtons(),null,"",null);
             
            return info;
        }

        private TaskDialogInfo CreateTaskDialogInfoInv()
        {
            TaskDialogInfo info = new TaskDialogInfo("AudSemp",
                                                        eTaskDialogIcon.Information,
                                                        "¿Que Tipo de Inventarios Voy Auditar?",
                                                        "",
                                                        eTaskDialogButton.Cancel,
                                                        eTaskDialogBackgroundColor.Blue, null, GetCommandButtonsInvs(), null, "", null);

            return info;
        }
        private Command[] GetCommandButtons()
        {
           

                return new Command[] { command1, command2 };
           
           
        }

        private Command[] GetCommandButtonsInvs()
        {


            return new Command[] { command3, command4 };


        }
     

        private void ExportToExcelPdf(string ruta)
        {
            try
            {
                LocalidadModel localidadModel = new LocalidadModel();
                localidadModel.localidadResult(loc);

                var pdfDoc = new Document(PageSize.LETTER, 25f, 25f, 40f, 40f);
                string path = ruta;
                PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));
                pdfDoc.Open();

                var imagepath = localidadModel.logotipo;
                using (FileStream fs = new FileStream(imagepath, FileMode.Open))
                {
                    var png = Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Jpeg);
                    png.ScalePercent(10f);
                    png.SetAbsolutePosition(pdfDoc.Left, pdfDoc.Top);
                    pdfDoc.Add(png);
                }

                var spacer = new Paragraph("")
                {
                    SpacingBefore = 5f,
                    SpacingAfter = 5f,
                };
                pdfDoc.Add(spacer);

                Font fuenteHeader = new Font();
                fuenteHeader.Size = 8;
                fuenteHeader.SetFamily("Calibri");
                

                var headerTable = new PdfPTable(new[] { .1f, .9f })
                {
                    HorizontalAlignment = Left,
                    WidthPercentage = 100,
                    DefaultCell = { MinimumHeight = 2f , BorderColor =BaseColor.WHITE }
                    
                    
                };

                headerTable.AddCell(new Phrase("Fecha:", fuenteHeader));
                headerTable.AddCell(new Phrase(DateTime.Now.ToString("dd-MMM-yyyy"),fuenteHeader));
                headerTable.AddCell(new Phrase("Auditoria:", fuenteHeader));
                headerTable.AddCell(new Phrase(cmbTypeOfAud.Text, fuenteHeader));
                headerTable.AddCell(new Phrase("Localidad: ", fuenteHeader));
                headerTable.AddCell(new Phrase(localidadModel.sucursal, fuenteHeader));
                headerTable.AddCell(new Phrase("Jefe Auditado: ", fuenteHeader));
                headerTable.AddCell(new Phrase(localidadModel.encargado, fuenteHeader));

                pdfDoc.Add(headerTable);
                pdfDoc.Add(spacer);

                var columnCount = ResGrid.ColumnCount;
                var columnWidths = new[] { 0.0f };

                if (Opcion == 1)
                {
                    columnWidths = new[] { 0.1f, 0.15f, 0.2f, 0.2f, 0.3f, 0.2f, 0.15f, 0.15f, 0.15f };
                }

                if (Opcion == 3 || Opcion == 5)
                { 

                     columnWidths = new[] { 0.15f, 0.2f, 0.2f, 0.3f, 0.2f, 0.15f, 0.3f };
                }

                if(Opcion==2 || Opcion==4)
                {
                    columnWidths = new[] { 0.1f, 0.2f, 0.1f, 0.1f, 0.1f, 0.15f, 0.05f,0.05f, 0.05f, 0.05f,0.2f };
                }
                

                var table = new PdfPTable(columnWidths)
                {
                    HorizontalAlignment = Left,
                    WidthPercentage = 100,
                    DefaultCell = { MinimumHeight = 0.2f }
                };

                var cell = new PdfPCell(new Phrase("Resultado de Auditoria"))
                {
                    Colspan = columnCount,
                    HorizontalAlignment = 1,  //0=Left, 1=Centre, 2=Right
                    MinimumHeight = 5f,
                   
                };

                table.AddCell(cell);
                Font fuente = new Font();
                fuente.Size = 8;
                fuente.SetFamily("Calibri");
                

                Font fuente2 = new Font();
                fuente2.Size = 7;
                fuente2.SetFamily("Calibri");

                ResGrid.Columns
                    .OfType<DataGridViewColumn>()
                    .ToList()
                    .ForEach(c => table.AddCell(new Paragraph(c.Name, fuente)));



                ResGrid.Rows
                    .OfType<DataGridViewRow>()
                    .ToList()
                    .ForEach(r =>
                    {
                        var cells = r.Cells.OfType<DataGridViewCell>().ToList();
                        cells.ForEach(c => table.AddCell(new Paragraph(c.Value.ToString(), fuente2))); //table.AddCell(c.Value.ToString()));
                    });




                pdfDoc.Add(table);

                pdfDoc.Close();

                MessageBox.Show( 
                                 "PDF Creado Con Exito", "AudSemp",
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportToExcel()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {



                if (string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    MessageBox.Show("No hay directorio Seleccionado",
                        "Auditoria SEMP", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {


                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(result);
                        wb.SaveAs(saveFileDialog1.FileName);
                        MessageBox.Show("Archivo Creado con Exito!",
                       "Auditoria SEMP", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    }
                }

            }
        }

        private void accion()
        {
            circularProgress1.Visible = true;
            circularProgress1.IsRunning = true;
            btnCancel.Visible = true;
            buttonX3.Enabled = false;
            buttonX6.Enabled = false;

            buttonX4.Enabled = false;
            buttonX5.Enabled = false;
        }





        #endregion

      
    }
}
