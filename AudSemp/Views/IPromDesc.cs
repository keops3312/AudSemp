

namespace AudSemp.Views
{
    using AudSemp.Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IPromDesc
    {
      

        List<TiposOrden> tiposOrden { get; set; }

        List<ModoOrdenes> modosOrden { get; set; }

        DateTime dateTimeInicio { get; set; }
        DateTime dateTimeFin { get; set; }
    }
}
