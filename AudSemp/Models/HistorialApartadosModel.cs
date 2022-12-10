
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
    public class HistorialApartadosModel
    {
        #region Context
        private DataContext db;
        public string _oString;

        public HistorialApartadosModel(DataContext _db)
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
            new TiposOrden() { tipo ="Folio"},
            new TiposOrden() { tipo="FechaPrimerRegistro"},
            new TiposOrden() { tipo="FechaUltimoRegistro"},
            new TiposOrden() { tipo="Acumulado"},

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

        #endregion

        #region methods (metodos)
        public DateTime dateInicio()
        {

            var fechaInicio = db.CAJA_AUXILIAR.OrderBy(p => p.Fecha).First();
            DateTime dateTimeInicio = DateTime.Parse(fechaInicio.Fecha.Value.ToString("yyyy-MM-dd"));
            return dateTimeInicio;
        }

        public DateTime dateFin()
        {

            var fechaFin = db.CAJA_AUXILIAR.OrderByDescending(p => p.Fecha).First();
            DateTime dateTimeFin = DateTime.Parse(fechaFin.Fecha.Value.ToString("yyyy-MM-dd"));
            return dateTimeFin;
        }

        //dont testar in this class
        public DataView Export(string fechaInicio, string fechaFin, string tipoOrden, string modoOrden
            , List<Estatus> Estatus)
        {

            DataTable dt = new DataTable("Apartados");
            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("Folio"),
                    new DataColumn("Acumulado"),
                    new DataColumn("FechaPrimMov"),
                    new DataColumn("FechaUltMov"),
                    new DataColumn("Comentario"),
                    new DataColumn("ultimoEstatus"),
                    new DataColumn("ultimaOperacion"),
                    new DataColumn("ultimoMovimiento"),
                    new DataColumn("Descripcion")
                  
                    
            });

            DateTime Inicio = DateTime.Parse(fechaInicio);
            DateTime Fin = DateTime.Parse(fechaFin);

         
            DataView dataView = new DataView(dt);


         
            return dataView;


        }



        #endregion
    }
}
