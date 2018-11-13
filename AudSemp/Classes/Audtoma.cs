

namespace AudSemp.Classes
{

    #region Libraries (Librerias)
    using AudSemp.Context;
    using ClosedXML.Excel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq; 
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
                var Inventarios = db.artventas.Where(p => p.status == "EN VENTA").OrderBy(p => p.noinv).ToList();


                switch (type)
                {

                    #region Case Contratos
                    case 1://Contratos


                        //recorro el excel 
                        foreach (var dataRow in myExcel)
                        {

                            string valor = dataRow.Cell(0).Value.ToString();

                            var existe = db.contratos.Where(p => p.Contrato == Convert.ToInt32(valor)).First();

                            if (existe == null)
                            {
                                dtC.Rows.Add(int.Parse(dataRow.Cell(0).Value.ToString()),
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
                                                existe.avaluo,
                                                existe.Prestamo,
                                                existe.Plazo,
                                                existe.valuacion_tipo, total_prendas, existe.FechaCons, "Y");

                            }


                        }



                        //buscamos si no esta en el excel y omitio el auditor
                        foreach (var item in contrato)
                        {
                            contratoS = Convert.ToString(item.Contrato);
                            foreach (var itemExcel in myExcel)
                            {
                                if (contratoS == itemExcel.Cell(0).Value)
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
                                                item.avaluo,
                                                item.Prestamo,
                                                item.Plazo,
                                                item.valuacion_tipo, total_prendas, item, "No en Excel");


                            }
                            findC = false;

                        }



                        return dtC;

                    #endregion

                    #region Bolsas
                    case 2:

                        int contratoB;
                        int contratoNO;
                        int diferencia;
                        string leyenda = "";

                        //recorro el excel 
                        foreach (var dataRow in myExcel)
                        {
                            contratoB = int.Parse(dataRow.Cell(1).Value.ToString());//tipo de bolsa
                            contratoNO = int.Parse(dataRow.Cell(0).Value.ToString()); // numero de contrato
                            if (contratoB == 1)//joyeria
                            {

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
                                    if (diferencia < 0)
                                    {
                                        leyenda = "Faltan Prendas!";
                                    }
                                    if (diferencia > 0)
                                    {
                                        leyenda = "Sobran Prendas!";
                                    }

                                    dtC.Rows.Add(existeJ.Contrato,
                                                   existeJ.Status,
                                                    existeJ.avaluo,
                                                    existeJ.Prestamo,
                                                    existeJ.valuacion_tipo,
                                                    existeJ.FechaCons, "Y", total_prendas,
                                                    int.Parse(dataRow.Cell(2).Value.ToString()),
                                                    diferencia, leyenda
                                                    );

                                }



                            }
                            else//otros
                            {

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
                                    if (diferencia < 0)
                                    {
                                        leyenda = "Faltan Prendas!";
                                    }
                                    if (diferencia > 0)
                                    {
                                        leyenda = "Sobran Prendas!";
                                    }

                                    dtC.Rows.Add(existeO.Contrato,
                                                   existeO.Status,
                                                    existeO.avaluo,
                                                    existeO.Prestamo,
                                                    existeO.valuacion_tipo,
                                                    existeO.FechaCons, "Y", total_prendas,
                                                    int.Parse(dataRow.Cell(2).Value.ToString()),
                                                    diferencia, leyenda
                                                    );

                                }


                            }

                        }





                        //buscamos si no esta en el excel y omitio el auditor

                        var bolsasOro = (from s in db.bolsas_ORO
                                         where s.EstatusPrenda == "EN RESGUARDO"
                                         select s.Contrato).Distinct().ToList();


                        var bolsasOtros = (from s in db.bolsas_OTROS
                                           where s.Estatus_Prenda == "EN RESGUARDO"
                                           select s.Contrato).Distinct().ToList();






                        foreach (var item in bolsasOro)
                        {
                            contratoS = item.Value.ToString();
                            foreach (var itemExcel in myExcel)
                            {
                                if (contratoS == itemExcel.Cell(0).Value.ToString())
                                {
                                    findC = true;
                                    break;
                                }
                            }

                            if (findC != true)
                            {

                                total_prendas = db.bolsas_ORO.Count(p => p.Contrato == int.Parse(contratoS) && p.EstatusPrenda == "EN RESGUARDO");
                                var buscarOro = db.bolsas_ORO.Where(p => p.Contrato == int.Parse(contratoS) && p.EstatusPrenda == "EN RESGUARDO").First();




                                dtB.Rows.Add(buscarOro.Contrato,
                                                buscarOro.EstatusPrenda,
                                                buscarOro.Avaluo,
                                                buscarOro.Prestamo,
                                                buscarOro.Tipo,
                                                buscarOro.Fecha, "N", total_prendas, "0", "-" + total_prendas, "No Auditado en Excel");


                            }



                            findC = false;



                        }




                        foreach (var item in bolsasOtros)
                        {
                            contratoS = item.Value.ToString();
                            foreach (var itemExcel in myExcel)
                            {
                                if (contratoS == itemExcel.Cell(0).Value.ToString())
                                {
                                    findC = true;
                                    break;
                                }
                            }

                            if (findC != true)
                            {

                                total_prendas = db.bolsas_OTROS.Count(p => p.Contrato == int.Parse(contratoS) && p.Estatus_Prenda == "EN RESGUARDO");
                                var buscarOtro = db.bolsas_OTROS.Where(p => p.Contrato == int.Parse(contratoS) && p.Estatus_Prenda == "EN RESGUARDO").First();




                                dtB.Rows.Add(buscarOtro.Contrato,
                                                buscarOtro.Estatus_Prenda,
                                                buscarOtro.Avaluo,
                                                buscarOtro.prestamo,
                                                buscarOtro.Tipo,
                                                buscarOtro.Fecha, "N", total_prendas, "0", "-" + total_prendas, "No Auditado en Excel");


                            }



                            findC = false;



                        }

                        return dtB;

                    #endregion

                    #region Inventario Ventas
                    case 3:
                        //recorro el excel 
                        foreach (var dataRow in myExcel)
                        {
                            var existe = db.artventas.Where(p => p.noinv == dataRow.Cell(0).Value.ToString()).First();



                            if (existe == null)
                            {
                                dtI.Rows.Add(int.Parse(dataRow.Cell(0).Value.ToString()),
                                    "desconocido", "desconocido", "desconocido", "0", "0", "No Encontrado en Sistema");
                            }
                            else
                            {


                                dtC.Rows.Add(existe.noinv,
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
                                if (contratoS == itemExcel.Cell(0).Value.ToString())
                                {
                                    findC = true;
                                    break;
                                }
                            }



                            if (findC != true)
                            {
                                var existe = db.artventas.Where(p => p.noinv == contratoS).First();
                                dtC.Rows.Add(existe.noinv,
                                              existe.status,
                                              existe.tipo,
                                              existe.descripcion,
                                              existe.kilates,
                                              existe.peso_real, "Encontrado en Excel (faltante)");
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

        #endregion

    }
}
