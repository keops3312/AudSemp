

namespace AudSemp.Models
{
    #region Libraries (librerias) 
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using AudSemp.Classes;
    //using AudSemp.Context;
    using OperSemp.Commons.Data;
    #endregion

    public class BolsasModel
    {

        #region Context

        private DataContext db;
        public string _oString;

        public BolsasModel(DataContext _db)
        {
            db = _db;
        }


        #endregion

        #region Attributes (attributos)


        public List<ModoOrdenes> Ordenes()
        {
            List<ModoOrdenes> ordenes = new List<ModoOrdenes>() {
            new ModoOrdenes() { modo ="Ascendente"},
            new ModoOrdenes() { modo ="Descendente"},

             };

            return ordenes;
        }

        public List<TiposOrden> TiposOrden(int opcion)
        {
            List<TiposOrden> tiposOrden= new List<TiposOrden>();
            

            if (opcion == 2)//bolsas Otros
            {
                tiposOrden.Clear();

                tiposOrden =new List<TiposOrden>()  {
                           new TiposOrden() { tipo ="Contrato"},
                           new TiposOrden() { tipo="Bolsa"},
                           new TiposOrden() { tipo="Tipo"},
                           new TiposOrden() { tipo="Prestamo"},
                            new TiposOrden() { tipo="Caja"}

             };

                return tiposOrden;

            }
            else
            {
                tiposOrden.Clear();

                tiposOrden = new List<TiposOrden>()  {
                            new TiposOrden() { tipo ="Contrato"},
                            new TiposOrden() { tipo="Bolsa"},
                            new TiposOrden() { tipo="Prestamo"},
                            new TiposOrden() { tipo="Caja"}
                };

                return tiposOrden;

            }

           

           
        }

    
        public List<string> TipoPrenda(int opcion)
        {

            List<string> tiposList = new List<string>();

            if (opcion == 2)
            {
                var tipos = db.Bolsas_OTROS.Select(p => p.Tipo).Distinct();

                foreach (var item in tipos)
                {
                    tiposList.Add(item);

                }

                return tiposList;
            }
            else {

                var tipos = db.Bolsas_ORO.Select(p => p.Tipo).Distinct();

                foreach (var item in tipos)
                {
                    tiposList.Add(item);

                }


                return tiposList;
            }
          
        }

        #endregion

        #region methods (metodos)
        public DateTime dateInicio(int opcion)
        {
            if (opcion == 2)
            {

                var fechaInicio = db.Bolsas_OTROS.OrderBy(p => p.Fecha).First();
                DateTime dateTimeInicio = DateTime.Parse(fechaInicio.Fecha.Value.ToString("yyyy-MM-dd"));
                return dateTimeInicio;

            }
            else
            {
                var fechaInicio = db.Bolsas_ORO.OrderBy(p => p.Fecha).First();
                DateTime dateTimeInicio = DateTime.Parse(fechaInicio.Fecha.Value.ToString("yyyy-MM-dd"));
                return dateTimeInicio;


            }

           
        }

        public DateTime dateFin(int opcion)
        {
            if(opcion==2)
            {
                var fechaFin = db.Bolsas_OTROS.OrderByDescending(p => p.Fecha).First();
                DateTime dateTimeFin = DateTime.Parse(fechaFin.Fecha.Value.ToString("yyyy-MM-dd"));
                return dateTimeFin;
            }
            else
            {
                var fechaFin = db.Bolsas_ORO.OrderByDescending(p => p.Fecha).First();
                DateTime dateTimeFin = DateTime.Parse(fechaFin.Fecha.Value.ToString("yyyy-MM-dd"));
                return dateTimeFin;
            }
           
        }

        //dont testar in this class
        public DataView Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden,
            List<categorias> tipos, int opcion)
        {

            DataTable dt = new DataTable();

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);


            if (opcion == 2)
            {
                dt.TableName = "BolsasOtros";
                dt.Columns.AddRange(new DataColumn[25]
                {

                     new DataColumn("Contrato"),
                     new DataColumn("Fecha"),
                     new DataColumn("Bolsa"),
                     new DataColumn("Descripcion"),
                     new DataColumn("SubDescripcion"),
                     new DataColumn("Tipo"),
                     new DataColumn("Avaluo"),
                     new DataColumn("Estatus_Prenda"),
                     new DataColumn("Condiciones"),
                     new DataColumn("Cantidad"),
                     new DataColumn("Localidad"),
                     new DataColumn("Ubicacion"),
                     new DataColumn("Posicion"),
                     new DataColumn("sucursal"),
                     new DataColumn("registro"),
                     new DataColumn("NO"),
                     new DataColumn("folio"),
                     new DataColumn("origen"),
                     new DataColumn("Prestamo"),
                     new DataColumn("INT"),
                     new DataColumn("detalles"),
                     new DataColumn("caja"),
                     new DataColumn("detalles_art"),
                     new DataColumn("modelo"),
                     new DataColumn("noserie")

                });

                foreach (var items in tipos)
                {

                    var result = from s in db.Bolsas_OTROS.Where(p => p.Fecha >= Inicio &&
                                  p.Fecha <= Fin &&
                                  p.Tipo == items.categoria).ToList()
                                 select s;

                    foreach (var item in result)
                    {


                        dt.Rows.Add(item.Contrato, item.Fecha, item.Bolsa,
                            item.Descripcion, item.SubDescripcion, 
                            item.Tipo, item.Avaluo, item.Estatus_Prenda, item.Condiciones,
                            item.Cantidad, item.Localidad, item.Ubicacion, item.Posicion,
                            item.sucursal, item.registro, item.NO,
                            item.folio, item.origen, item.INT, item.detalles, item.caja,
                            item.detalles_art, item.modelo, item.noserie);


                    }




                }

            }
            else
            {

                dt.TableName = "BolsasOro";
                dt.Columns.AddRange(new DataColumn[22]
                {

                 new DataColumn("Contrato"),
                 new DataColumn("Fecha"),
                 new DataColumn("Bolsa"),
                 new DataColumn("Descripcion"),
                 new DataColumn("SubDescripcion"),
                 new DataColumn("Kilates"),
                 new DataColumn("PesoReal"),
                 new DataColumn("Tipo"),
                 new DataColumn("Avaluo"),
                 new DataColumn("Prestamo"),
                 new DataColumn("EstatusPrenda"),
                 new DataColumn("Cantidad"),
                 new DataColumn("Localidad"),
                 new DataColumn("Ubicacion"),
                 new DataColumn("Posicion"),
                 new DataColumn("registro"),
                 new DataColumn("folio"),
                 new DataColumn("origen"),
                 new DataColumn("INT"),
                 new DataColumn("condiciones"),
                 new DataColumn("caja"),
                 new DataColumn("pneto")

                });

                foreach (var items in tipos)
                {

                    var result = from s in db.Bolsas_ORO.Where(p => p.Fecha >= Inicio &&
                                  p.Fecha <= Fin &&
                                  p.Tipo == items.categoria).ToList()
                                 select s;

                    foreach (var item in result)
                    {

                        dt.Rows.Add(item.Contrato, item.Fecha, item.Bolsa,
                            item.Descripcion, item.SubDescripcion, item.Kilates, item.PesoReal,
                            item.Tipo, item.Avaluo, item.Prestamo, item.EstatusPrenda, item.Cantidad,
                            item.Localidad, item.Ubicacion, item.Posicion, item.registro,
                            item.folio, item.origen, item.INT, item.condiciones, item.caja,
                            item.pneto);


                    }




                }


            }

            

            DataView dataView = new DataView(dt);


            //ORDER MODE
            string mode = tipoOrden + modoOrden;
            switch (mode)
            {
                default:
                    dataView.Sort = "INT asc";
                    break;
                case "ContratoAscendente":
                    dataView.Sort = "Contrato asc";
                    break;
                case "ContratoDescendente":
                    dataView.Sort = "Contrato desc";
                    break;
                case "BolsaAscendente":
                    dataView.Sort = "Bolsa asc";
                    break;
                case "BolsaDescendente":
                    dataView.Sort = "Bolsa desc";
                    break;
                case "PrestamoAscendente":
                    dataView.Sort = "Prestamo asc";
                    break;
                case "PrestamoDescendente":
                    dataView.Sort = "Prestamo desc";
                    break;
                case "TipoAscendente":
                    dataView.Sort = "Tipo asc";
                    break;
                case "TipoDescendente":
                    dataView.Sort = "Tipo desc";
                    break;
                case "CajaAscendente":
                    dataView.Sort = "caja asc";
                    break;
                case "CajaDescendente":
                    dataView.Sort = "caja desc";
                    break;

            }

            return dataView;


        }



        #endregion

    }
}
