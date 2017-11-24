using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace an34e_project.Models {
    public class Question : BaseClass {
        public String Quest { get; set; }
        public Int32 Level { get; set; }
        public Int32 RequiredLevel { get; set; }

        public bool Insert(String Quest, Int32 Level, Int32 RequiredLevel) {

            var Db = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            var connection = new SqlConnection(Db);
            connection.Open();

            var cmd = new SqlCommand();
            cmd = new SqlCommand("insert into questions (level, level_required, question) values (@level, @level_required, @question)", connection);

            cmd.Parameters.Add(new SqlParameter("@level", Level) { DbType = DbType.Int32 });
            cmd.Parameters.Add(new SqlParameter("@level_required", RequiredLevel) { DbType = DbType.Int32 });
            cmd.Parameters.Add(new SqlParameter("@question", Quest) { DbType = DbType.String });
            var rows = cmd.ExecuteNonQuery();

            connection.Close();
            return (rows > 0);
        }
        public List<Question> Update(Int32 Id, String Quest, Int32 Level, Int32 RequiredLevel, Boolean Removed) {

            var Db = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            var connection = new SqlConnection(Db);
            connection.Open();

            var cmd = new SqlCommand("update questions set level = @level, level_required = @level_required, quest = @question, removed = @removed where id = @id", connection);
            var lst = new List<Question>();

            var obj = new Question();
            cmd.Parameters.Add(new SqlParameter("@id", Id) { DbType = DbType.Int32 });
            cmd.Parameters.Add(new SqlParameter("@level", Quest) { DbType = DbType.String });
            cmd.Parameters.Add(new SqlParameter("@level_required", Level) { DbType = DbType.Int32 });
            cmd.Parameters.Add(new SqlParameter("@question", RequiredLevel) { DbType = DbType.Int32 });
            cmd.Parameters.Add(new SqlParameter("@removed", Removed) { DbType = DbType.Boolean });
            var rows = cmd.ExecuteNonQuery();

            connection.Close();
            return lst;
        }
        public bool Remove(Int32 Id) {

            var Db = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            var connection = new SqlConnection(Db);
            connection.Open();

            var cmd = new SqlCommand("update questions set removed = 1 where id = @id", connection);
            cmd.Parameters.Add(new SqlParameter("@id", Id) { DbType = DbType.Int32 });
            var rows = cmd.ExecuteNonQuery();

            connection.Close();
            return (rows > 0);
        }
        public List<Question> ListQuestions() {

            var Db = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            var connection = new SqlConnection(Db);
            connection.Open();

            var cmd = new SqlCommand("select t.id, t.level, t.level_required, t.question, t.removed from questions t where t.removed = 0", connection);

            SqlDataReader dt = cmd.ExecuteReader();
            var lst = new List<Question>();
            if (dt.HasRows)
                while (dt.Read()) {
                    var obj = new Question();
                    obj.Id = dt.GetInt32(0);
                    obj.Level = dt.GetInt32(1);
                    obj.RequiredLevel = dt.GetInt32(2);
                    obj.Quest = dt.GetString(3);
                    lst.Add(obj);
                }
            connection.Close();
            return lst;
        }
        public static Question SelectById(int id) {

            var Db = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
            var connection = new SqlConnection(Db);
            connection.Open();

            var cmd = new SqlCommand("select t.id, t.level, t.level_required, t.quest, t.removed from contacts t where t.removido = 0 and id = @id", connection);
            cmd.Parameters.Add(new SqlParameter("@id", id) { DbType = DbType.Int32 });

            SqlDataReader dt = cmd.ExecuteReader();
            dt.Read();
            var obj = new Question();
            obj.Id = dt.GetInt32(0);
            obj.Level = dt.GetInt32(1);
            obj.RequiredLevel = dt.GetInt32(2);
            obj.Quest = dt.GetString(3);

            connection.Close();
            return obj;
        }
    }
}