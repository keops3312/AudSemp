

namespace AudSemp.Presenter
{

    #region Libraries (librerias) 
    using System;
    using System.Collections.Generic;
    using AudSemp.Classes;
    using AudSemp.Models;
    using AudSemp.Views;
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
        LoginModel login = new LoginModel();
        public void Acces()
        {

            login.User = LoginView.userText;
            login.Password = LoginView.passwordText;
            //Around to reflection (Pasa la respuesta a la vista)
            LoginView.response = login.Acces();

        }
        public void Claves()
        {
            LoginView.clave = login.LoginClave();

        }

        public void Nombre()
        {
            LoginView.nombreAuditor = login.LoginNombreCompleto();
        }
        #endregion
    }
}

