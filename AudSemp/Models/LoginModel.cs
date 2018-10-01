
//Objects to Logical Login
namespace AudSemp.Models
{
    #region Libraries (librerias)
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion

    public class LoginModel
    {
        #region Context
        private SEMP2013_Entities db;// = new MySqlConnectionContext();
        public LoginModel()
        {
            db = new SEMP2013_Entities();
        }

        #endregion

        #region Attributes
        public string User { get; set; }

        public string Password { get; set; }

        #endregion

        #region Methods
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


                if (User == null)
                {
                    return 1;
                }

                if (Password == null)
                {
                    return 2;
                }

                if (User == null && Password == null)
                {
                    return 3;
                }

                var user = db.PRVyusuarios.Where(p => p.USUARIO == User
                                                    && p.CONTRASEÑA == Password).First();

                if (user == null)
                {
                    return 4;
                }
                if (String.Compare(user.USUARIO, User) != 0)
                {
                    return 4;
                }
                if (String.Compare(user.CONTRASEÑA, Password) != 0)
                {
                    return 4;
                }



                if (user.TIPO_USUARIO != "Auditor" ||
                    user.TIPO_USUARIO != "Master usuario" ||
                    user.TIPO_USUARIO != "Administrador" ||
                    user.TIPO_USUARIO != "Junior usuario")
                {
                    return 5;
                }

                if (user.OPERACIONES != "NO")
                {
                    return 6;
                }

                return 9000;
            }
            catch(Exception ex)
            {
                return 404;
            }
        }
        #endregion

    }
}
