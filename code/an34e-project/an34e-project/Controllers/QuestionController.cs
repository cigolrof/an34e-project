using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace an34e_project.Controllers
{
    public class QuestionController : Controller
    {
        public string QueryQuestions(Int32 Level = 0)
        {
            var strDb = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();

            var conn = new SqlConnection(strDb);
            conn.Open();

            var cmd = new SqlCommand("Select question From Question Where level = " + Level , conn);

            SqlDataReader dt = cmd.ExecuteReader();
            string ret = "";

            while (dt.Read()) {
                ret = dt.GetString(0);
            }

            conn.Close();

            return ret;
        }
    }
}