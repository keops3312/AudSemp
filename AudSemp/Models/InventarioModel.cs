

namespace AudSemp.Models
{
    #region Libraries (librerias) 
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using AudSemp.Classes;
    using AudSemp.Context;
    using OperSemp.Commons.Data;
    #endregion
    public class InventarioModel
    {

        #region Context
        private DataContext db;
        public string _oString;

        public InventarioModel(DataContext _db)
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

        public List<TiposOrden> TiposOrden()
        {
            List<TiposOrden> tiposOrden = new List<TiposOrden>() {
            new TiposOrden() { tipo ="Inventario"},
            new TiposOrden() { tipo="FechaRemate"},
            new TiposOrden() { tipo="Tipo"},
            new TiposOrden() { tipo="Status"},
            new TiposOrden() { tipo="Precio"},

             };

            return tiposOrden;
        }

        public List<string> Estatus()
        {
            var estatus = db.Artventas.Select(p => p.status).Distinct();

            List<string> estatusList = new List<string>();

            foreach (var item in estatus)
            {
                estatusList.Add(item);

            }

            return estatusList;
        }

        public List<string> TipoPrenda()
        {
            var tipos = db.Artventas.Select(p => p.tipo).Distinct();

            List<string> tiposList = new List<string>();

            foreach (var item in tipos)
            {
                tiposList.Add(item);

            }

            return tiposList;
        }

        #endregion


        #region methods (metodos)
        public DateTime dateInicio()
        {

            var fechaInicio = db.Artventas.OrderBy(p => p.rematadoEJ).First();
            DateTime dateTimeInicio = DateTime.Parse(fechaInicio.rematadoEJ.Value.ToString("yyyy-MM-dd"));
            return dateTimeInicio;
        }

        public DateTime dateFin()
        {

            var fechaFin = db.Artventas.OrderByDescending(p => p.rematado).First();
            DateTime dateTimeFin = DateTime.Parse(fechaFin.rematadoEJ.Value.ToString("yyyy-MM-dd"));
            return dateTimeFin;
        }

        //dont testar in this class
        public DataView Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden,
            List<categorias> tipos, List<Estatus> Estatus)
        {

            DataTable dt = new DataTable("Inventarios");
            dt.Columns.AddRange(new DataColumn[45]
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
          new DataColumn("precioventa"),
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
          new DataColumn("rematadoEJ"),
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
          new DataColumn("indice")
            });

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);

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
                        
        

                        dt.Rows.Add(item.no, item.contrato, item.fecha,
                            item.bolsa, item.noinv, item.noserie, item.descripcion,
                            item.detalles, item.preciosugerido, item.precioventa, item.kilates, item.peso_real,
                            item.condiciones, item.tipo, item.status, item.mov,
                            item.rematado, item.rematado_por, item.mod_extemporanea, item.transferido, item.sucursal,
                            item.status_transferido, item.fecha_trans, item.actualizacion,
                            item.codigotrans, item.pneto, item.NOTAS, item.AOM, item.rematadoEJ,
                            item.precio_promocion, item.fechaPP, item.precioPromo2, item.fechaPP2, item.precioPromo3, item.fechaPP3,
                            item.precioRemate, item.fechaPRem, item.precio_origen,item.actualizo, item.actualizo2, item.actualizo3,
                            item.prestamo,item.contrato2,item.fecha_contrato, item.indice);


                    }

                }



            }


            DataView dataView = new DataView(dt);


            //ORDER MODE
            string mode = tipoOrden + modoOrden;
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
                    dataView.Sort = "pecioventa desc";
                    break;

            }

            return dataView;


        }



        #endregion

    }
}
