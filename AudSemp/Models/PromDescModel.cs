﻿

namespace AudSemp.Models
{
    #region Libraries (librerias)
    using AudSemp.Classes;
    using AudSemp.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq; 
    #endregion
    public class PromDescModel
    {

        #region Context

        private SEMP2013_Context db;
        public PromDescModel()
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
