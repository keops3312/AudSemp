
namespace AudSemp.Models
{
    #region Libraries (librerias) 
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using AudSemp.Classes;
    using AudSemp.Context;
    #endregion

    public class ApartadosModel
    {

        #region Context

        private SEMP2013_Context db;
        public ApartadosModel()
        {
            db = new SEMP2013_Context();
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
            new TiposOrden() { tipo ="No.Inventario"},
            new TiposOrden() { tipo="FechaApartado"},
            new TiposOrden() { tipo="Status"},
            new TiposOrden() { tipo="Categoria"},

             };

            return tiposOrden;
        }

        public List<string> Estatus()
        {
            var estatus = db.Apartados.Select(p => p.status).Distinct();

            List<string> estatusList = new List<string>();

            foreach (var item in estatus)
            {
                estatusList.Add(item);

            }

            return estatusList;
        }

        public List<string> TipoPrenda()
        {
            var tipos = db.Apartados.Select(p => p.tipo).Distinct();

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

            var fechaInicio = db.Apartados.OrderBy(p => p.fecha_de_apartado).First();
            DateTime dateTimeInicio = DateTime.Parse(fechaInicio.fecha_de_apartado.Value.ToString("yyyy-MM-dd"));
            return dateTimeInicio;
        }

        public DateTime dateFin()
        {

            var fechaFin = db.Apartados.OrderByDescending(p => p.fecha_de_apartado).First();
            DateTime dateTimeFin = DateTime.Parse(fechaFin.fecha_de_apartado.Value.ToString("yyyy-MM-dd"));
            return dateTimeFin;
        }

        //dont testar in this class
        public DataView Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden,
            List<categorias> tipos, List<Estatus> Estatus)
        {

            DataTable dt = new DataTable("Apartados");
            dt.Columns.AddRange(new DataColumn[48]
            {
                    new DataColumn("no"),
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
                    new DataColumn("fecha_de_apartado"),
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

                   
                        dt.Rows.Add(item.no, item.FOLIO_REM, item.bolsa,
                            item.noinv, item.noserie, item.descripcion, item.detalles,
                            item.preciosugerido, item.precioventa, item.kilates, item.peso_real, item.condiciones,
                            item.tipo, item.status, item.apartado_con, item.apartado_cantidad,
                            item.aparto, item.idcliente, item.resta_por_pagar, item.fecha_de_apartado, item.usuario,
                            item.realizado_en, item.comentario, item.liquido_fecha,
                            item.nota_liquido, item.penalizado, item.penalizado_precio, item.Fecha_de_penalizacion, item.mot_penalizacion,
                            item.cancelo, item.fecha_cancelo, item.mot_cancelo, item.folio_apartado, item.promocion, item.vigencia,
                            item.precio_origen, item.descuento, item.tipo_desc,item.precio_remate,item.penalizacion_por,
                            item.cancelacion_por,item.dias_minimo,item.dias_normal,item.dias_tolerancia,item.apartado_min,
                            item.apartado_norm,item.nombre_plazo,item.tipo_apartado);


                    }

                }



            }


            DataView dataView = new DataView(dt);

           
            //ORDER MODE
            string mode = tipoOrden + modoOrden;
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

            return dataView;


        }



        #endregion

    }
}
