//creating object interface to  Logica Login

namespace AudSemp.Views
{

    #region Libraries (Librerias)

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public interface ILogin
    {

        #region Attributes (atributos)
        string userText { get; set; }
        string passwordText { get; set; }



        //response
        int response { get; set; }
        string clave { get; set; }
        string nombreAuditor { get; set; }
        #endregion

    }
}
