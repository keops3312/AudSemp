

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
    public class NotasPagoModel
    {
        #region Context

        private SEMP2013_Context db;
        public NotasPagoModel()
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
            new TiposOrden() { tipo ="Fecha"},
            new TiposOrden() { tipo="Contrato"},
            new TiposOrden() { tipo="Nota de Pago"},
            new TiposOrden() { tipo="Status"},
           

             };

            return tiposOrden;
        }

        public List<string> Estatus()
        {
            var estatus = db.facturas.Select(p => p.STATUS).Distinct();

            List<string> estatusList = new List<string>();

            foreach (var item in estatus)
            {
                estatusList.Add(item);

            }

            return estatusList;
        }

        public List<string> TipoRD()
        {
            var tipos = db.facturas.Select(p => p.R_D).Distinct();

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

            var fechaInicio = db.facturas.OrderBy(p => p.FechaFact).First();
            DateTime dateTimeInicio = DateTime.Parse(fechaInicio.FechaFact.Value.ToString("yyyy-MM-dd"));
            return dateTimeInicio;
        }

        public DateTime dateFin()
        {

            var fechaFin = db.facturas.OrderByDescending(p => p.FechaFact).First();
            DateTime dateTimeFin = DateTime.Parse(fechaFin.FechaFact.Value.ToString("yyyy-MM-dd"));
            return dateTimeFin;
        }

        //dont testar in this class
        public DataView Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden,
            List<categorias> tipos, List<Estatus> Estatus)
        {

            DataTable dt = new DataTable("Contratos");
            dt.Columns.AddRange(new DataColumn[38]
            {
            new DataColumn("Folio"),
            new DataColumn("Contrato"),
            new DataColumn("Fecha"),
            new DataColumn("Bolsa"),
            new DataColumn("IdClientes"),
            new DataColumn("NCliente"),
            new DataColumn("AutorizoA"),
            new DataColumn("Plazo"),
            new DataColumn("Status"),
            new DataColumn("FechaDesemp"),
            new DataColumn("Comentario"),
            new DataColumn("Dias"),
            new DataColumn("FechaCons"),
            new DataColumn("Prestamo"),
            new DataColumn("Interes"),
            new DataColumn("seguro"),
            new DataColumn("almacenaje"),
            new DataColumn("plazo1"),
            new DataColumn("plazo2"),
            new DataColumn("plazo3"),
            new DataColumn("avaluo"),
            new DataColumn("valuacion_tipo"),
            new DataColumn("cancelado"),
            new DataColumn("comentariocancelado"),
            new DataColumn("prestamoprom"),
            new DataColumn("origen"),
            new DataColumn("folioavaluo"),
            new DataColumn("clasificacion"),
            new DataColumn("santerior"),
            new DataColumn("caja"),
            new DataColumn("pension"),
            new DataColumn("Rev"),
            new DataColumn("reg"),
            new DataColumn("temp"),
            new DataColumn("VenOVig"),
            new DataColumn("realizo"),
            new DataColumn("CobroOriginal"),
            new DataColumn("BLOQUEADO_COMENTARIO")



            });

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);

            foreach (var items in tipos)
            {


                foreach (var itemEstatus in Estatus)
                {
                    var result = from s in db.contratos.Where(p => p.FechaCons >= Inicio &&
                                      p.FechaCons <= Fin &&
                                      p.valuacion_tipo == items.categoria &&
                                      p.Status == itemEstatus.estatu).ToList()
                                 select s;



                    foreach (var item in result)
                    {


                        dt.Rows.Add(item.Folio, item.Contrato, item.Fecha,
                            item.Bolsa, item.IdClientes, item.NCliente, item.AutorizoA,
                            item.Plazo, item.Status, item.FechaDesemp, item.Comentario, item.Dias,
                            item.FechaCons, item.Prestamo, item.Interes, item.seguro,
                            item.almacenaje, item.plazo1, item.plazo2, item.plazo3, item.avaluo,
                            item.valuacion_tipo, item.cancelado, item.comentariocancelado,
                            item.prestamoprom, item.origen, item.folioavaluo, item.clasificacion, item.santerior,
                            item.caja, item.pension, item.Rev, item.reg, item.temp, item.VenOVig,
                            item.realizo, item.CobroOriginal, item.BLOQUEADO_COMENTARIO);


                    }

                }



            }


            DataView dataView = new DataView(dt);


            //ORDER MODE
            string mode = tipoOrden + modoOrden;
            switch (mode)
            {
                default:
                    dataView.Sort = "reg asc";
                    break;
                case "FechaConsAscendente":
                    dataView.Sort = "FechaCons asc";
                    break;
                case "FechaConsDescendente":
                    dataView.Sort = "FechaCons desc";
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
                case "StatusAscendente":
                    dataView.Sort = "Status asc";
                    break;
                case "StatusDescendente":
                    dataView.Sort = "Status desc";
                    break;
                case "PrestamoAscendente":
                    dataView.Sort = "Prestamo asc";
                    break;
                case "PrestamoDescendente":
                    dataView.Sort = "Prestamo desc";
                    break;

            }

            return dataView;


        }



        #endregion

    }
}
