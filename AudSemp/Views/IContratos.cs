﻿

namespace AudSemp.Views
{
    using AudSemp.Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IContratos
    {

        #region properties (propiedades)
       
        #endregion


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
