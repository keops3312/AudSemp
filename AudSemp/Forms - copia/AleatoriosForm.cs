
namespace AudSemp.Forms
{

    #region Librerias (libraries)
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

    public partial class AleatoriosForm : OfficeForm
    {

        #region Context
        private SEMP2013_Context db;
        public AleatoriosForm()
        {
            db = new SEMP2013_Context();
            InitializeComponent();
        }

        #endregion

        #region Properties
       
        DataTable result = new DataTable();
        Audtoma toma = new Audtoma();
        public string loc;
        #endregion


        #region Methods
        public void LoadB()
        {
            dateTimeInput1.Value = toma.dateInicio();
            dateTimeInput2.Value = toma.dateFin();
            integerInput1.MinValue = 5;
            integerInput1.MaxValue = toma.totalContratos();
            integerInput1.Value = 1;

            this.Text = this.Text + " -Localidad Actual: " + loc;
        }

      

        private void ExportToExcelPdf(string ruta)
        {
            try
            {

                dataGridViewX1.DataSource = result;
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
                    DefaultCell = { MinimumHeight = 2f, BorderColor = BaseColor.WHITE }


                };

                headerTable.AddCell(new Phrase("Fecha:", fuenteHeader));
                headerTable.AddCell(new Phrase(DateTime.Now.ToString("dd-MMM-yyyy"), fuenteHeader));
                headerTable.AddCell(new Phrase("Auditoria:", fuenteHeader));
                headerTable.AddCell(new Phrase("Contratos Aleatorios", fuenteHeader));
                headerTable.AddCell(new Phrase("Localidad: ", fuenteHeader));
                headerTable.AddCell(new Phrase(localidadModel.sucursal, fuenteHeader));
                headerTable.AddCell(new Phrase("Jefe Auditado: ", fuenteHeader));
                headerTable.AddCell(new Phrase(localidadModel.encargado, fuenteHeader));

                pdfDoc.Add(headerTable);
                pdfDoc.Add(spacer);

                var columnCount = dataGridViewX1.ColumnCount;
                var columnWidths = new[] { 0.0f };

              
              
               columnWidths = new[] { 0.1f, 0.15f, 0.2f, 0.2f, 0.2f, 0.2f, 0.15f, 0.3f };
               

             

                var table = new PdfPTable(columnWidths)
                {
                    HorizontalAlignment = Left,
                    WidthPercentage = 100,
                    DefaultCell = { MinimumHeight = 0.2f }
                };

                var cell = new PdfPCell(new Phrase("Resultado de Aleatorios"))
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

                dataGridViewX1.Columns
                    .OfType<DataGridViewColumn>()
                    .ToList()
                    .ForEach(c => table.AddCell(new Paragraph(c.Name, fuente)));



                dataGridViewX1.Rows
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
        #endregion


        #region Events
        private void AleatoriosForm_Load(object sender, EventArgs e)
        {
            LoadB();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(integerInput1.Text))
            {
                MessageBox.Show("Ingrese la cantidad de contratos por favor", "AudSemp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            backgroundWorker1.RunWorkerAsync();
        }



        private void buttonItem1_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
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

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
           result= toma.AudRandom(integerInput1.Value,
               dateTimeInput1.Value,
               dateTimeInput2.Value,
               switchButton1.Value);

        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            circularProgress1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            dataGridViewX1.DataSource = result;
            circularProgress1.Visible = false;
            circularProgress1.IsRunning = false;
          
            MessageBox.Show(
                                "Terminado", "AudSemp",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
        }
        #endregion

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }
    }
}
