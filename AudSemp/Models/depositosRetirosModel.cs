
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
    public class depositosRetirosModel
    {
        #region Context
        private DataContext db;
        public string _oString;

        public depositosRetirosModel(DataContext _db)
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

        public List<TiposOrden> TiposOrden(string Tipo)
        {
            if (Tipo == "Depositos")
            {
                List<TiposOrden> tiposOrden = new List<TiposOrden>() {
                new TiposOrden() { tipo ="Fecha"},
                new TiposOrden() { tipo="Deposito"},
                new TiposOrden() { tipo="Caja"},
             
                  };

                    return tiposOrden;
            }
            else
            {

                List<TiposOrden> tiposOrden = new List<TiposOrden>() {
                new TiposOrden() { tipo ="Fecha"},
                new TiposOrden() { tipo="Caja"},
                new TiposOrden() { tipo="Concepto"},
                new TiposOrden() { tipo="Retiro"},

                 };

                    return tiposOrden;

            }
        }

        public string Opcion { get; set; }

        #endregion


        #region Methods (metodos)
        public DateTime dateInicio(string Tipo)
        {

            if (Tipo == "Depositos")
            {
                var fechaInicio = db.Depositos.OrderBy(p => p.fecha).First();
                DateTime dateTimeInicio = DateTime.Parse(fechaInicio.fecha.Value.ToString("yyyy-MM-dd"));
                return dateTimeInicio;
            }
            else
            {
                var fechaInicio = db.Retiros.OrderBy(p => p.fecha).First();
                DateTime dateTimeInicio = DateTime.Parse(fechaInicio.fecha.Value.ToString("yyyy-MM-dd"));
                return dateTimeInicio;
            }



             
        }

        public DateTime dateFin(string Tipo)
        {
            if (Tipo == "Depositos")
            {
                var fechaFin = db.Depositos.OrderByDescending(p => p.fecha).First();
                DateTime dateTimeFin = DateTime.Parse(fechaFin.fecha.Value.ToString("yyyy-MM-dd"));
                return dateTimeFin;



            }
            else
            {
                var fechaFin = db.Retiros.OrderByDescending(p => p.fecha).First();
                DateTime dateTimeFin = DateTime.Parse(fechaFin.fecha.Value.ToString("yyyy-MM-dd"));
                return dateTimeFin;
            }
            
        }
        #endregion

    }
}
