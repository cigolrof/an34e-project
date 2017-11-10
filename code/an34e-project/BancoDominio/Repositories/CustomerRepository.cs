using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoAcessaDados.Interface;
using DataBase;
using System.Data;

namespace BancoDominio.Repositories {
    class CustomerRepository : Context, IRepository<Customer> {
        public IEnumerable<Customer> ListAll() {
            try {
                ClearParameter();
                DataTable dtListAll = new DataTable();
                IList<Customer> list = new List<Customer>();
                dtListAll = ExecuteQuery(System.Data.CommandType.StoredProcedure, "listAllCustomers");
                foreach (DataRow item in dtListAll.Rows) {
                    Customer customer = new Customer();
                    customer.Id = Convert.ToInt32(item["Id"]);
                    customer.Name = Convert.ToString(item["Name"]);
                    customer.Responsible = Convert.ToString(item["Responsible"]);
                    customer.Area = Convert.ToInt32(item["Area"]);
                    customer.NpsStatus = Convert.ToInt32(item["NpsStatus"]);
                    customer.CustomerSince = Convert.ToDateTime(item["CustomerSince"]);
                    customer.LastAvaliation = Convert.ToDateTime(item["LastAvaliation"]);
                    customer.Removed = Convert.ToBoolean(item["Removed"]);
                    list.Add(customer);
                }
                return list;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public string Removed(Customer entity) {
            throw new NotImplementedException();
        }

        public string Save(Customer entity) {
            string ret = "";
            ret = (entity.Id <= 0 ? Insert(entity) : Alter(entity));
            return ret;
        }

        public string searchId(int id) {
            try {
                ClearParameter();
                AddParameter("@Id", id);
                string ret = ExecuteQuery(System.Data.CommandType.StoredProcedure, "searchIdCustomer").ToString();
                return ret;
            } catch (Exception ex) {
                return ex.Message;
            }
        }
        private string Insert(Customer entity) {
            try {
                ClearParameter();
                AddParameter("@Nome", entity.Name);
                AddParameter("@Responsible", entity.Responsible);
                AddParameter("@Area", entity.Area);
                AddParameter("@NpsStatus", entity.NpsStatus);
                AddParameter("@CustomerSince", entity.CustomerSince);
                AddParameter("@LastAvaliation", entity.LastAvaliation);
                string ret = ExecuteCommand(System.Data.CommandType.StoredProcedure, "InsertCustomer").ToString();
                return ret;
            } catch (Exception ex) {
                return ex.Message;
            }
        }

        private string Alter(Customer entity) {
            //try {
            //    ClearParameter();
            //    AddParameter()
            //} catch (Exception ex) {
            //    return ex.Message;
            //}

            return null;
        }
    }
}
