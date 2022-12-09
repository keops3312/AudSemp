
//Objects to Logical Login
namespace AudSemp.Models
{

    #region Libraries (librerias) 
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using AudSemp.Classes;
    using AudSemp.Context;
    using AudSemp.Properties;
    using OperSemp.Commons.Data;
    using OperSemp.Commons.Entities;
    using OperSemp.Commons.Helper;
    #endregion

    public class LoginModel
    {

        #region Attributes
        ILoginHelper loginHelper;
        IConectionHelper conectionHelper;
        User _userAcces;
        #endregion

        #region Properties
        private string user = string.Empty;
        private string password = string.Empty;
        private bool response;
        private string _stringValue;
        private Response _response;

        private string serverId;
        private string databaseId;
        private string userId;
        private string passwordId;
        private string _MySqlstringValue;
        private string _MySqlstringValueLoc;
        int changeCombo = 0;

        #endregion

        #region Context
        private DataContext db;// = new MySqlConnectionContext();
       
        public LoginModel()
        {
            loginHelper = new LoginHelper();
            
        }

        #endregion

        #region Attributes (atributos)
        public string User { get; set; }

        public string Password { get; set; }

        public string clave { get; set; }

        public string NombreAuditor { get; set; }

        #endregion

        #region Methods (metodos)
        public int Acces()
        {
            //1 Empty User
            //2 Empty password
            //3 Empty all field
            //4 user or password incorrect
            //5 Incompatible level user
            //6 bloqued user
            // 9000 Acces ok!
            // 404 Failed Connection
            try
            {

                List<LevelUser> levelUsers = new List<LevelUser>()
            {
                new LevelUser() { level ="Auditor" },
                new LevelUser() { level = "Junior usuario" },
                new LevelUser() { level = "Master usuario" },

            };

                if (string.IsNullOrEmpty(User) && string.IsNullOrEmpty(Password))
                {
                    return 3;
                }

                if (string.IsNullOrEmpty(User))
                {
                    return 1;
                }

                if (string.IsNullOrEmpty(Password))
                {
                    return 2;
                }


                var user = db.Prvyusuarios.Where(p => p.Usuario == User
                                                    && p.Contraseña == Password).FirstOrDefault();
                clave = user.Localidad;


                var empleado = db.Empleados.Where(p => p.NoEmpleado == user.NoOperador).First();

                NombreAuditor = empleado.NombreCompleto;

                if (user == null)
                {
                    return 4;
                }
                if (String.Compare(user.Usuario, User) != 0)
                {
                    return 4;
                }
                if (String.Compare(user.Contraseña, Password) != 0)
                {
                    return 4;
                }


                if (user.Operaciones != "NO")
                {
                    return 6;
                }


                int bin = 0;
                foreach (var item in levelUsers)
                {

                    if (user.TipoUsuario != item.level)
                    {
                        bin = 1;
                    }
                    else
                    {
                        bin = 0;
                        break;
                    }

                }
                if (bin == 1) { return 5; }


              



                return 9000;
            }
            catch (Exception ex)
            {
                return 404;
            }
          
          
           
        }

        public string LoginClave()
        {
            return clave;
        }

        public string LoginNombreCompleto()
        {
            return NombreAuditor;
        }
        #endregion

    }
}
