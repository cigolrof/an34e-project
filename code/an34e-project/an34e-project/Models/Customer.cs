using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace an34e_project.Models
{
    public class Customer : BaseClass
    {
        public string Name { get; set; }
        public string Responsible { get; set; }
        public DateTime CustomerSince { get; set; }

        internal bool Save()
        {
            var strDb = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            var conn = new SqlConnection(strDb);
            var cmd = new SqlCommand();

            if (this.Id == 0) //insert
            {
                conn.Open();
                cmd = new SqlCommand("insert into users (login, password) values (@login, @senha)", conn);
                cmd.Parameters.Add(new SqlParameter("@login", "aaaa") { DbType = DbType.String });
                cmd.Parameters.Add(new SqlParameter("@senha", "ssssss") { DbType = DbType.String });
            }
            else //update
            {
                conn.Open();
                cmd = new SqlCommand("insert into users (login, password) values (@login, @senha)", conn);
                cmd.Parameters.Add(new SqlParameter("@login", "aaaa") { DbType = DbType.String });
                cmd.Parameters.Add(new SqlParameter("@senha", "ssssss") { DbType = DbType.String });

            }

            var rows = cmd.ExecuteNonQuery();
            conn.Close();
            return (rows > 0);
        }
    }

}