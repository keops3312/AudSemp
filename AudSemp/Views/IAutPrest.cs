

namespace AudSemp.Views
{
    #region Libraries (Librerias) 
    using System;
    using System.Collections.Generic;
    using AudSemp.Classes;
  
    #endregion
    public interface IAutPrest
    {

        #region Atributtes (atriutos)
        List<TiposOrden> tiposOrden { get; set; }

        List<ModoOrdenes> modosOrden { get; set; }

        DateTime dateTimeInicio { get; set; }
        DateTime dateTimeFin { get; set; } 
        #endregion
    }
}
