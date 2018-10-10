

namespace AudSemp.Views
{
    #region Libraries (librerias)
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion

    public interface IPanel
    {
        //responses
        #region Properties
        string sucursalText { get; set; }
        string marcaText { get; set; }
        string empresaText { get; set; }

        string encargadoText { get; set; }

        string localidadText { get; set; }
        string logotipoText { get; set; }

        string claveText { get; set; }
        #endregion
    }
}
