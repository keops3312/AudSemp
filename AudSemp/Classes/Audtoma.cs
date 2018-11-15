

namespace AudSemp.Classes
{

    #region Libraries (Librerias)
    using System;
    using System.Data;
    using System.Linq;
    using AudSemp.Context;
    using ClosedXML.Excel;
    #endregion
    public class Audtoma
    {
        #region Context

        private SEMP2013_Context db;
        public Audtoma()
        {
            db = new SEMP2013_Context();
        }

        #endregion

       
        #region Methods (Metodos)
        public DataTable AudPhisycal(string path, string sheet,int type)
        {

            #region Properties in Method
            DataTable result = new DataTable();

            string fileName = path;
            int total_prendas;


            string contratoS;
            bool findC = false;



            //find bolsas
            int contratoB;
            int contratoNO;
            int diferencia;
            string leyenda = "";
            #endregion

            #region Methods (metodos)
            using (var excelWorkbook = new XLWorkbook(fileName))
            {
                var myExcel = excelWorkbook.Worksheet(sheet).RowsUsed().Skip(1);//puede ser entero



                DataTable dtC = new DataTable("AudContratos");
                dtC.Columns.AddRange(new DataColumn[9]
                {
                    new DataColumn("Contrato"),
                    new DataColumn("Status"),
                    new DataColumn("Avaluo"),
                    new DataColumn("Prestamo"),
                    new DataColumn("Plazo"),
                    new DataColumn("Tipo"),
                    new DataColumn("#Prendas"),
                    new DataColumn("Fecha"),
                    new DataColumn("Encontrado")


                });


                DataTable dtB = new DataTable("AudBolsas");
                dtB.Columns.AddRange(new DataColumn[11]
                {
                    new DataColumn("Contrato"),
                    new DataColumn("Status"),
                    new DataColumn("Avaluo"),
                    new DataColumn("Prestamo"),
                    new DataColumn("Tipo"),
                    new DataColumn("Fecha"),
                    new DataColumn("Encontrado"),
                    new DataColumn("Prend.Sist"),
                    new DataColumn("Prend.Excel"),
                    new DataColumn("Resultado"),
                    new DataColumn("Leyenda")


                });


                DataTable dtI = new DataTable("AudInventario");
                dtI.Columns.AddRange(new DataColumn[7]
                {
                    new DataColumn("Inventario"),
                    new DataColumn("Status"),
                    new DataColumn("tipo"),
                    new DataColumn("descripcion"),
                    new DataColumn("kt"),
                    new DataColumn("Peso"),
                    new DataColumn("Leyenda")


                });



                var contrato = db.contratos.Where(p => p.Status == "VIGENTE").OrderBy(p=> p.FechaCons).ToList();
                var BolsasORO = db.bolsas_ORO.Where(p => p.EstatusPrenda == "EN RESGUARDO").OrderBy(p => p.Contrato).ToList();
                var BolsasOtros = db.bolsas_OTROS.Where(p => p.Estatus_Prenda == "EN RESGUARDO").OrderBy(p => p.Contrato).ToList();
                var Inventarios = db.artventas.Where(p => p.status == "EN VENTA" && p.tipo == "Joyeria").OrderBy(p => p.noinv).ToList();


                if (type == 5)
                {
                    Inventarios= db.artventas.Where(p => p.status == "EN VENTA" && p.tipo != "Joyeria").OrderBy(p => p.noinv).ToList();
                }



                switch (type)
                {

                    #region Case Contratos
                    case 1://Contratos


                        //recorro el excel 
                        foreach (var dataRow in myExcel)
                        {

                            int valor =int.Parse(dataRow.Cell(1).Value.ToString());

                            var existe = db.contratos.Where(p => p.Contrato == valor).First();

                            if (existe == null)
                            {
                                dtC.Rows.Add(int.Parse(dataRow.Cell(1).Value.ToString()),
                                    "desconocido", "0", "0", "desconocido", "desconocido", "0", "01-01-1999", "N");
                            }
                            else
                            {

                                if (existe.valuacion_tipo != "Joyeria")
                                {
                                    total_prendas = db.bolsas_OTROS.Count(p => p.Contrato == existe.Contrato && p.Estatus_Prenda == "EN RESGUARDO");
                                }
                                else
                                {
                                    total_prendas = db.bolsas_ORO.Count(p => p.Contrato == existe.Contrato && p.EstatusPrenda == "EN RESGUARDO");
                                }


                                dtC.Rows.Add(existe.Contrato,
                                               existe.Status,
                                                decimal.Parse(existe.avaluo.ToString()),
                                                decimal.Parse(existe.Prestamo.ToString()),
                                                existe.Plazo,
                                                existe.valuacion_tipo, 
                                                total_prendas, 
                                                DateTime.Parse(existe.FechaCons.ToString()).ToString("dd-MM-yyyy"), "Y");

                            }


                        }



                        //buscamos si no esta en el excel y omitio el auditor
                        foreach (var item in contrato)
                        {
                            contratoS = Convert.ToString(item.Contrato);
                            foreach (var itemExcel in myExcel)
                            {
                                if (contratoS == itemExcel.Cell(1).Value.ToString())
                                {
                                    findC = true;
                                    break;
                                }
                            }



                            if (findC != true)
                            {



                                if (item.valuacion_tipo != "Joyeria")
                                {
                                    total_prendas = db.bolsas_OTROS.Count(p => p.Contrato == item.Contrato && p.Estatus_Prenda == "EN RESGUARDO");
                                }
                                else
                                {
                                    total_prendas = db.bolsas_ORO.Count(p => p.Contrato == item.Contrato && p.EstatusPrenda == "EN RESGUARDO");
                                }
                              

                                dtC.Rows.Add(item.Contrato,
                                                item.Status,
                                                decimal.Parse(item.avaluo.ToString()),
                                                decimal.Parse(item.Prestamo.ToString()),
                                                item.Plazo,
                                                item.valuacion_tipo, total_prendas, 
                                                DateTime.Parse(item.FechaCons.ToString()).ToString("dd-MM-yyyy"), "No en Excel");


                            }
                            findC = false;

                        }



                        return dtC;

                    #endregion

                    #region Bolsas Oro
                    case 2:

                       

                        //recorro el excel 
                        foreach (var dataRow in myExcel)
                        {
                           
                            contratoNO = int.Parse(dataRow.Cell(1).Value.ToString()); // numero de contrato
                          

                                total_prendas = db.bolsas_ORO.Count(p => p.Contrato == contratoNO && p.EstatusPrenda == "EN RESGUARDO");
                                var existeJ = db.contratos.Where(p => p.Contrato == contratoNO).First();

                                if (total_prendas == 0)
                                {
                                    dtB.Rows.Add(contratoNO, "desconocido",
                                        "0", "0", "desconocido", "01-01-1999",
                                        "N", "0",
                                        int.Parse(dataRow.Cell(2).Value.ToString()), "0", "NO se encuentra la Bolsa");
                                }
                                else
                                {

                                    diferencia = total_prendas - int.Parse(dataRow.Cell(2).Value.ToString());
                                    leyenda = "Igual";

                                    if (diferencia < 0)
                                    {
                                        leyenda = "Faltan Prendas!";
                                    }
                                    if (diferencia > 0)
                                    {
                                        leyenda = "Sobran Prendas!";
                                    }

                                    dtB.Rows.Add(existeJ.Contrato,
                                                   existeJ.Status,
                                                    existeJ.avaluo,
                                                    existeJ.Prestamo,
                                                    existeJ.valuacion_tipo,
                                                    DateTime.Parse(existeJ.FechaCons.ToString()).ToString("dd-MM-yyyy"), "Y", total_prendas,
                                                    int.Parse(dataRow.Cell(2).Value.ToString()),
                                                    diferencia, leyenda
                                                    );

                                }




                        }


                        //buscamos si no esta en el excel y omitio el auditor

                        var bolsasOro = (from s in db.bolsas_ORO
                                         where s.EstatusPrenda == "EN RESGUARDO"
                                         select s.Contrato).Distinct().ToList();

                        int contratoConv;



                        foreach (var item in bolsasOro)
                        {
                            contratoS = item.Value.ToString();
                            foreach (var itemExcel in myExcel)
                            {
                                if (contratoS == itemExcel.Cell(1).Value.ToString())
                                {
                                    findC = true;
                                    break;
                                }
                            }

                            if (findC != true)
                            {
                                contratoConv = int.Parse(contratoS);
                                total_prendas = db.bolsas_ORO.Count(p => p.Contrato == contratoConv && p.EstatusPrenda == "EN RESGUARDO");
                                var buscarOro = db.bolsas_ORO.Where(p => p.Contrato == contratoConv && p.EstatusPrenda == "EN RESGUARDO").First();




                                dtB.Rows.Add(buscarOro.Contrato,
                                                buscarOro.EstatusPrenda,
                                                buscarOro.Avaluo,
                                                buscarOro.Prestamo,
                                                buscarOro.Tipo,
                                                DateTime.Parse(buscarOro.Fecha.ToString()).ToString("dd-MM-yyyy"), "N", total_prendas, "0", "-" + total_prendas, "No Auditado en Excel");


                            }



                            findC = false;



                        }




                     

                        return dtB;

                    #endregion

                    #region Boslas Otros
                    case 4:


                       

                        //recorro el excel 
                        foreach (var dataRow in myExcel)
                        {
                           
                            contratoNO = int.Parse(dataRow.Cell(1).Value.ToString()); // numero de contrato

                          

                                total_prendas = db.bolsas_OTROS.Count(p => p.Contrato == contratoNO && p.Estatus_Prenda == "EN RESGUARDO");

                                var existeO = db.contratos.Where(p => p.Contrato == contratoNO).First();




                                if (total_prendas == 0)
                                {
                                    dtB.Rows.Add(contratoNO, "desconocido",
                                        "0", "0", "desconocido", "01-01-1999",
                                        "N", "0",
                                        int.Parse(dataRow.Cell(2).Value.ToString()), "0", "NO se encuentra la Bolsa");
                                }
                                else
                                {

                                    diferencia = total_prendas - int.Parse(dataRow.Cell(2).Value.ToString());
                                    leyenda = "Igual";
                                    if (diferencia < 0)
                                    {
                                        leyenda = "Faltan Prendas!";
                                    }
                                    if (diferencia > 0)
                                    {
                                        leyenda = "Sobran Prendas!";
                                    }

                                    dtB.Rows.Add(existeO.Contrato,
                                                   existeO.Status,
                                                    existeO.avaluo,
                                                    existeO.Prestamo,
                                                    existeO.valuacion_tipo,
                                                     DateTime.Parse(existeO.FechaCons.ToString()).ToString("dd-MM-yyyy"), "Y", total_prendas,
                                                    int.Parse(dataRow.Cell(2).Value.ToString()),
                                                    diferencia, leyenda
                                                    );

                                }


                           
                        }

                        var bolsasOtros = (from s in db.bolsas_OTROS
                                           where s.Estatus_Prenda == "EN RESGUARDO"
                                           select s.Contrato).Distinct().ToList();
                        int contratoConv2;
                        foreach (var item in bolsasOtros)
                        {
                            contratoS = item.Value.ToString();
                            foreach (var itemExcel in myExcel)
                            {
                                if (contratoS == itemExcel.Cell(1).Value.ToString())
                                {
                                    findC = true;
                                    break;
                                }
                            }

                            if (findC != true)
                            {
                                contratoConv2 = int.Parse(contratoS);
                                total_prendas = db.bolsas_OTROS.Count(p => p.Contrato == contratoConv2 && p.Estatus_Prenda == "EN RESGUARDO");
                                var buscarOtro = db.bolsas_OTROS.Where(p => p.Contrato == contratoConv2 && p.Estatus_Prenda == "EN RESGUARDO").First();




                                dtB.Rows.Add(buscarOtro.Contrato,
                                                buscarOtro.Estatus_Prenda,
                                                buscarOtro.Avaluo,
                                                buscarOtro.prestamo,
                                                buscarOtro.Tipo,
                                                DateTime.Parse(buscarOtro.Fecha.ToString()).ToString("dd-MM-yyyy"), "N", total_prendas, "0", "-" + total_prendas, "No Auditado en Excel");


                            }



                            findC = false;



                        }


                        return dtB;



                    #endregion

                    #region Inventario Ventas
                    case 3:
                        string inventarioExcel;
                        //recorro el excel 
                        foreach (var dataRow in myExcel)
                        {
                            inventarioExcel = dataRow.Cell(1).Value.ToString();
                            var existe = db.artventas.Where(p => p.noinv == inventarioExcel).First();



                            if (existe == null)
                            {
                                dtI.Rows.Add(inventarioExcel,
                                    "desconocido", "desconocido", "desconocido", "0", "0", "No Encontrado en Sistema");
                            }
                            else
                            {


                                dtI.Rows.Add(existe.noinv,
                                               existe.status,
                                                existe.tipo,
                                                existe.descripcion,
                                                existe.kilates,
                                                existe.peso_real, "Encontrado en Sistema");

                            }


                        }



                        //buscamos si no esta en el excel y omitio el auditor
                        foreach (var item in Inventarios)
                        {
                            contratoS = item.noinv;
                            foreach (var itemExcel in myExcel)
                            {
                                if (contratoS == itemExcel.Cell(1).Value.ToString())
                                {
                                    findC = true;
                                    break;
                                }
                            }



                            if (findC != true)
                            {
                                var existe = db.artventas.Where(p => p.noinv == contratoS).First();
                                dtI.Rows.Add(existe.noinv,
                                              existe.status,
                                              existe.tipo,
                                              existe.descripcion,
                                              existe.kilates,
                                              existe.peso_real, "NO Encontrado en Excel (faltante)");
                            }
                            findC = false;

                        }


                        return dtI;
                    #endregion


                    default:
                        return result;
                }




            }

            #endregion



        }




        //contratos Aleatorios

        public int totalContratos()
        {
            int total;
            total = db.contratos.Count();
            return total;
        }

        public DateTime dateInicio()
        {

            var fechaInicio = db.contratos.OrderBy(p => p.FechaCons).First();
            DateTime dateTimeInicio = DateTime.Parse(fechaInicio.FechaCons.Value.ToString("yyyy-MM-dd"));
            return dateTimeInicio;
        }

        public DateTime dateFin()
        {

            var fechaFin = db.contratos.OrderByDescending(p => p.FechaCons).First();
            DateTime dateTimeFin = DateTime.Parse(fechaFin.FechaCons.Value.ToString("yyyy-MM-dd"));
            return dateTimeFin;
        }



        public DataTable AudRandom(int number,DateTime inicio, DateTime fin,bool tipo)
        {
           
            DataTable dtC = new DataTable("AudContratos");
            dtC.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("Contrato"),
                    new DataColumn("Bolsa"),
                    new DataColumn("Fecha"),
                    new DataColumn("Avaluo"),
                    new DataColumn("Prestamo"),
                    new DataColumn("Tipo"),
                    new DataColumn("Status"),
                    new DataColumn("Plazo")
                    


            });


            var contrato = db.contratos.SqlQuery("SELECT TOP (" + number + ") " +
                                                    " * " +
                                                "FROM contratos where Status='VIGENTE' and FechaCons between '" +  inicio.ToString("yyyy-MM-dd") +"' " +
                                                "and '" + fin.ToString("yyyy-MM-dd") + "' ORDER BY CHECKSUM(NEWID())").ToList();


            if (tipo ==false)
            {
                contrato = db.contratos.SqlQuery("SELECT TOP (" + number + ") " +
                                                    " * " +
                                                "FROM contratos where FechaCons between '" + inicio.ToString("yyyy-MM-dd") + "' " +
                                                "and '" + fin.ToString("yyyy-MM-dd") + "' ORDER BY CHECKSUM(NEWID())").ToList();

            }


            foreach (var item in contrato)
            {
                dtC.Rows.Add(item.Contrato,item.Bolsa,
                    DateTime.Parse(item.FechaCons.ToString()).ToString("dd-MM-yyyy"),
                    item.avaluo, 
                    item.Prestamo,
                    item.valuacion_tipo, 
                    item.Status,
                    item.Plazo);
            }
            
            return dtC;
        }



        #endregion

    }
}
