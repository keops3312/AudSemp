

namespace AudSemp.Views
{
   

    #region Libraries (Librerias)
    using System;
    using System.Collections.Generic;
    using AudSemp.Classes;
    #endregion
    public interface InotasPago
    {
        #region Attributes (atributos)
        DateTime dateTimeInicio { get; set; }
        DateTime dateTimeFin { get; set; }
        List<string> tiposrd { get; set; }
        List<string> status { get; set; }
        List<TiposOrden> tiposOrden { get; set; }

        List<ModoOrdenes> modosOrden { get; set; }
        #endregion

    }
}
