

namespace AudSemp.Views
{
    using AudSemp.Classes;
    #region Libraries (Librerias)
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion  

    public interface IBolsas
    {
        #region Attributes (atributos)
        DateTime dateTimeInicio { get; set; }
        DateTime dateTimeFin { get; set; }
        List<TiposOrden> tiposOrden { get; set; }

        List<string> tipos { get; set; }
        List<ModoOrdenes> modosOrden { get; set; }

        int OpcionDR { get; set; }
        #endregion

    }
}
