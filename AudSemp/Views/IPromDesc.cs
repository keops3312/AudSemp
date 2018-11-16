

namespace AudSemp.Views
{

    #region Libraries (librerias)  
    using System;
    using System.Collections.Generic;
    using AudSemp.Classes;
    #endregion

    public interface IPromDesc
    {


        #region Attributes (atributos)
        List<TiposOrden> tiposOrden { get; set; }

        List<ModoOrdenes> modosOrden { get; set; }

        DateTime dateTimeInicio { get; set; }
        DateTime dateTimeFin { get; set; } 
        #endregion
    }
}
