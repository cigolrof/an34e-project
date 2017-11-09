using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataBase {
    public class Context {

        private SqlConnection connection;

        private SqlConnection CreateConection() {

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            return connection;
        }
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;
        private SqlCommand CreateCommand(CommandType cmdType, string procedure) {

            connection = CreateConection();
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = cmdType;
            cmd.CommandText = procedure;
            cmd.CommandTimeout = 7200;

            foreach (SqlParameter sqlParameter in sqlParameterCollection) {
                cmd.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
            }
            return cmd;
        }
        protected void AddParameter(string parameterName, object parameterValue) {
            sqlParameterCollection.AddWithValue(parameterName, parameterValue);
        }
        protected void ClearParameter() {
            sqlParameterCollection.Clear();
        }
        protected object ExecuteCommand(CommandType cmdType, string procedure) {
            try {
                SqlCommand cmd = CreateCommand(cmdType, procedure);
                return cmd.ExecuteScalar();
            } catch (System.Exception ex) {
                throw new System.Exception(ex.Message);
            } finally {
                connection.Close();
            }
        }
        protected DataTable ExecuteQuery(CommandType cmdType, string procedure) {
            try {
                SqlCommand cmd = CreateCommand(cmdType, procedure);
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                return dt;
            } catch (System.Exception ex) {
                throw new System.Exception(ex.Message);
            } finally {
                connection.Close();
            }
        }
    }
}
