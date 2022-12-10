

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
    public class PromDescModel
    {

        #region Context
        private DataContext db;
        public string _oString;

        public PromDescModel(DataContext _db)
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
            new TiposOrden() { tipo ="Caja"},
            new TiposOrden() { tipo="Fecha"},


             };

            return tiposOrden;
        }

        public DateTime dateInicio()
        {

            var fechaInicio = db.promociones.OrderBy(p => p.fecha).First();
            DateTime dateTimeInicio = DateTime.Parse(fechaInicio.fecha.Value.ToString("yyyy-MM-dd"));
            return dateTimeInicio;
        }

        public DateTime dateFin()
        {

            var fechaFin = db.promociones.OrderByDescending(p => p.fecha).First();
            DateTime dateTimeFin = DateTime.Parse(fechaFin.fecha.Value.ToString("yyyy-MM-dd"));
            return dateTimeFin;
        }

        #endregion
    }
}
