using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace an34e_project.Models
{
    public class User : Controller
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int removed { get; set; }

        //public static String getHashSha256(String text)
        //{
        //    byte[] bytes = Encoding.UTF8.GetBytes(text);
        //    SHA256Managed hashstring = new SHA256Managed();
        //    byte[] hash = hashstring.ComputeHash(bytes);
        //    string hashString = string.Empty;
        //    foreach (byte x in hash)
        //    {
        //        hashString += String.Format("{0:x2}", x);
        //    }
        //    return hashString;
        //}

        public static bool Logar(string loginC, string senhaC)
        {
            var strDb = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();

            var conn = new SqlConnection(strDb);
            conn.Open();

            var cmd = new SqlCommand("select login, password from users", conn);

            SqlDataReader dt = cmd.ExecuteReader();


            while (dt.Read())
            {
                var obj = new User();
                obj.login = dt.GetString(0);
                obj.password = dt.GetString(1);

                if ((loginC == obj.login) && (senhaC == obj.password))
                {
                    return true;
                }
            }

            conn.Close();
            return false;
        }


    }
}