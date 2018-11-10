

namespace AudSemp.Views
{
    #region Libraries (librerias)
    using AudSemp.Classes;
    using System;
    using System.Collections.Generic;
   
    #endregion

    public interface IContratos
    {

        #region Attributes (atributos)
        DateTime dateTimeInicio { get; set; }
        DateTime dateTimeFin { get; set; }
        List<string> tipos { get; set; }
        List<string> status { get; set; }
        List<TiposOrden> tiposOrden { get; set; }

        List<ModoOrdenes> modosOrden { get; set; }
        #endregion

    }
}
