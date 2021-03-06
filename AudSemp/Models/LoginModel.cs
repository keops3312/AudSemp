﻿
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
    #endregion

    public class LoginModel
    {
        #region Context
        private SEMP2013_Context db;// = new MySqlConnectionContext();
       
        public LoginModel()
        {
            db = new SEMP2013_Context();
            //db.Database.Connection.ConnectionString = Settings.Default["data"].ToString();
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


                var user = db.PRVyusuarios.Where(p => p.USUARIO == User
                                                    && p.CONTRASEÑA == Password).FirstOrDefault();
                clave = user.LOCALIDAD;


                var empleado = db.Empleados.Where(p => p.NoEmpleado == user.NO_OPERADOR).First();

                NombreAuditor = empleado.Nombre_Completo;

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


                if (user.OPERACIONES != "NO")
                {
                    return 6;
                }


                int bin = 0;
                foreach (var item in levelUsers)
                {

                    if (user.TIPO_USUARIO != item.level)
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
