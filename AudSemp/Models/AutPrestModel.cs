
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
    public class AutPrestModel
    {

        #region Context

        private SEMP2013_Context db;
        public AutPrestModel()
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
            new TiposOrden() { tipo ="Contrato"},
            new TiposOrden() { tipo="Fecha"},
            

             };

            return tiposOrden;
        }

        public DateTime dateInicio()
        {

            var fechaInicio = db.autorizaciones_prestamos.OrderBy(p => p.fecha).First();
            DateTime dateTimeInicio = DateTime.Parse(fechaInicio.fecha.Value.ToString("yyyy-MM-dd"));
            return dateTimeInicio;
        }

        public DateTime dateFin()
        {

            var fechaFin = db.autorizaciones_prestamos.OrderByDescending(p => p.fecha).First();
            DateTime dateTimeFin = DateTime.Parse(fechaFin.fecha.Value.ToString("yyyy-MM-dd"));
            return dateTimeFin;
        }

        #endregion
    }
}
