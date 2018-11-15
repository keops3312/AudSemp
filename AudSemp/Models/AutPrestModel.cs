
namespace AudSemp.Models
{
    using AudSemp.Classes;
    using AudSemp.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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

      
        #endregion
    }
}
