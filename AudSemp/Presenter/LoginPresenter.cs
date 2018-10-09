

namespace AudSemp.Presenter
{

    #region Libraries (librerias)
    using AudSemp.Models;
    using AudSemp.Views;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion  
    public class LoginPresenter
    {

        #region Properties (propiedades)
        ILogin LoginView;
        public LoginPresenter(ILogin view)
        {
            LoginView = view;
        }
        #endregion

        #region Methods
        public void Acces()
        {
            LoginModel login = new LoginModel();
            login.User = LoginView.userText;
            login.Password = LoginView.passwordText;
            //Around to reflection (Pasa la respuesta a la vista)
            LoginView.response = login.Acces();

        }
        #endregion

    }
}
