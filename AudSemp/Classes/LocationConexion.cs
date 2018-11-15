

namespace AudSemp.Classes
{
    #region Libraries (librerias) 
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Entity.Core.EntityClient;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using AudSemp.Context;

    #endregion
    public class LocationConexion
    {
        #region Context
        private SEMP2013_Context db;
        public LocationConexion()
        {
            db = new SEMP2013_Context();
        }
        #endregion

        #region Atributes (atributos)
        public string[] archivos = Directory.GetFiles(@"C:\SEMP2013\cdb", "*.txt");
        // string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";
        string suc, tienda, dir, server, database, user, pass;
        string Suc, Tienda, Dir, Server, Database, User, Pass;
        #endregion

        #region Methods (Metodos)

        public String[] LocalidadBuscada()
        {

            String[] array = new string[3];
            var localidad = db.Localidades.Where(p => p.impresora == "RAIZ").First();

            array[0] = localidad.LOCALIDAD;
            array[1] = localidad.Nombre_Sucursal;
            array[2] = localidad.DIRECCION;


            return array;
        }



        public String[] Scan()
        {
            Encriptar_Desencriptar CRYPTO = new Encriptar_Desencriptar();
            bool IsCorrect;
            String[] array = new string[7];

            foreach (var file in archivos)
            {
                //anow chek if connection is correct
                StreamReader reader = new StreamReader(file.ToString(), true);
                if (System.IO.File.Exists(file.ToString()))
                {
                    suc = reader.ReadLine();//suc
                    tienda = reader.ReadLine();//tienda
                    dir = reader.ReadLine();//Direccion
                    server = reader.ReadLine();//server
                    database = reader.ReadLine();//database
                    user = reader.ReadLine();//user
                    pass = reader.ReadLine();//password


                    Suc = CRYPTO.DecryptKey(suc);
                    Tienda = CRYPTO.DecryptKey(tienda);
                    Dir = CRYPTO.DecryptKey(dir);
                    Server = CRYPTO.DecryptKey(server);
                    Database = CRYPTO.DecryptKey(database);
                    User = CRYPTO.DecryptKey(user);
                    Pass = CRYPTO.DecryptKey(pass);
                    //check connectio
                    IsCorrect = checkConnection(Server, Database, User, Pass);
                    if (IsCorrect == true)
                    {
                        array[0] = Suc;
                        array[1] = Tienda;
                        array[2] = Dir;
                        array[3] = Server;
                        array[4] = Database;
                        array[5] = User;
                        array[6] = Pass;
                        //entiyFramework
                        SaveConnectionString("SEMP2013_Context", "", Server, Database, User, Pass, 1);
                        //sqlconnection client
                        SaveConnectionString("SEMP2013_CNX", "", Server, Database, User, Pass, 2);
                        return array;

                    }

                }

            }

            array[0] = "Error in Directory";
            return array;



        }

        private bool checkConnection(string server, string database, string user, string pass)
        {
            string cadena;
            cadena = "DATA SOURCE=" + server + ";initial catalog=" + database +
                ";Persist Security Info=True;User ID=" + user + ";Password=" + pass + "";
            var canConnect = false;

            var connectionString = cadena;
            var connection = new SqlConnection(connectionString);
            //first test conection NORMAL
            try
            {
                using (connection)
                {
                    connection.Open();
                    db.Database.Connection.Open();
                    canConnect = true;
                }

               
            }
            catch (Exception exception)
            {

            }
            finally
            {
                connection.Close();
               db.Database.Connection.Close();
            }

            return canConnect;

        }

        public static string GetConnectionString(string connectionStringName)
        {
            Configuration appconfig =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringSettings connStringSettings = appconfig.ConnectionStrings.ConnectionStrings[connectionStringName];

            return connStringSettings.ConnectionString;
        }


        public static void SaveConnectionString(string connectionStringName, string connectionString,
            string server, string database, string user, string pass, int opcion)
        {
            string data;
            if (opcion == 1)
            {



                SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
                {
                    DataSource = server, // Server name
                    InitialCatalog = database,  //Database
                    UserID = user,         //Username
                    Password = pass,  //Password
                    PersistSecurityInfo=true,
                    MultipleActiveResultSets=true,
                 
                };
                //Build an Entity Framework connection string

                EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
                {
                    Provider = "System.Data.SqlClient",
                    Metadata = "res://*/Context.Context.csdl|res://*/Context.Context.ssdl|res://*/Context.Context.msl",
                    ProviderConnectionString = sqlString.ToString() + ";App=EntityFramework;"
                    //"res://*/testModel.csdl|res://*/testModel.ssdl|res://*/testModel.msl",
                };
                data=entityString.ConnectionString;
            
            //data = "metadata=res://*/Context.Context.csdl|res://" +
            //        "*/Context.Context.ssdl|res://*/Context.Context.msl;" +
            //        "provider=System.Data.SqlClient;provider" +
            //        " connection string=&quot;" +
            //        "data source=" + server + ";" +
            //        "initial catalog=" + database + ";" +
            //        "persist security info=True; user id=" + user + ";" +
            //        "password=" + pass + ";" +
            //        "MultipleActiveResultSets=True;" +
            //        "App=EntityFramework&quot; ";
            }
            else
            {
                data = "DATA SOURCE=" + server + ";" +
                               "initial catalog=" + database + ";" +
                             "persist security info=True;user id=" + user + ";" +
                              "password=" + pass + ";";
            }




            Configuration appconfig =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            appconfig.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString = data;//connectionString
            appconfig.Save();
            
        }

        //create ist of app strings
        public static List<string> GetConnectionStringNames()
        {
            List<string> cns = new List<string>();
            Configuration appconfig =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (ConnectionStringSettings cn in appconfig.ConnectionStrings.ConnectionStrings)
            {
                cns.Add(cn.Name);
            }
            return cns;
        }

        //return first element in list of connectionString
        public static string GetFirstConnectionStringName()
        {
            return GetConnectionStringNames().FirstOrDefault();
        }




        #endregion


    }



}

