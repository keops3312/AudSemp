using AudSemp.Context;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudSemp.Classes
{
    public class Audtoma
    {
        #region Context

        private SEMP2013_Context db;
        public Audtoma()
        {
            db = new SEMP2013_Context();
        }

        #endregion
        //Contract invent
        private DataTable AudPhisycal(string path, int type)
        {
            DataTable result = new DataTable();

            string fileName = path;
            int total_prendas;
           
            //
            string contratoS;
            bool findC=false;

            using (var excelWorkbook = new XLWorkbook(fileName))
            {
                var myExcel = excelWorkbook.Worksheet(1).RowsUsed();



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







                //ahora recorro la tabla de los vigentes en tabla de contratos y la comparo con el excel
                var contrato = db.contratos.Where(p => p.Status == "VIGENTE").ToList();
                var BolsasORO = db.bolsas_ORO.Where(p => p.EstatusPrenda == "EN RESGUARDO").ToList();
                var BolsasOtros = db.bolsas_OTROS.Where(p => p.Estatus_Prenda == "EN RESGUARDO").ToList();

                switch (type)
                {

                    #region Case Contratos
                    case 1://Contratos

                      
                        //recorro el excel 
                        foreach (var dataRow in myExcel)
                        {
                            var existe = db.contratos.Where(p => p.Contrato == int.Parse(dataRow.Cell(0).Value.ToString())).First();

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
                                if (contratoS == itemExcel.Cell(0).Value.ToString())
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



                        return result;

                    #endregion

                    #region Bolsas
                    case 2:

                        int contratoB;
                        int diferencia;
                        string leyenda = "";
                        int tipoContrato;
                        //recorro el excel 
                        foreach (var dataRow in myExcel)
                        {
                            contratoB = int.Parse(dataRow.Cell(0).Value.ToString());
                            if (contratoB == 1)//joyeria
                            {

                                total_prendas = db.bolsas_ORO.Count(p => p.Contrato == contratoB && p.EstatusPrenda == "EN RESGUARDO");
                                var existeJ = db.contratos.Where(p => p.Contrato == int.Parse(dataRow.Cell(0).Value.ToString())).First();

                                if (total_prendas == 0)
                                {
                                    dtB.Rows.Add(contratoB, "desconocido",
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

                                total_prendas = db.bolsas_OTROS.Count(p => p.Contrato == contratoB && p.Estatus_Prenda == "EN RESGUARDO");

                                var existeO = db.contratos.Where(p => p.Contrato == int.Parse(dataRow.Cell(0).Value.ToString())).First();




                                if (total_prendas == 0)
                                {
                                    dtB.Rows.Add(contratoB, "desconocido",
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


                            //buscamos si no esta en el excel y omitio el auditor
                            foreach (var item in BolsasORO)
                            {
                                contratoS = Convert.ToString(item.Contrato);
                                foreach (var itemExcel in myExcel)
                                {
                                    if (contratoS == itemExcel.Cell(0).Value.ToString())
                                    {
                                        findC = true;
                                        break;
                                    }
                                }


                            }


                            if (findC != true)
                            {
                                foreach (var item in BolsasOtros)
                                {



                                    contratoS = Convert.ToString(item.Contrato);
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



                                        findC = false;
                                    }






                                }

                            }




                         

                            return result;








                        }


                        return result;

                    #endregion


                    default:
                        return result;
                } 
               


                  
             






                return result;





            }



        }


        public List<int>totales()
        {
            List<int> total = new List<int>();


            return total;
        }
    }
}
