using ForLogic.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoNPS.Models
{
    public class Customer : BaseClass
    {
        
        public string Title { get; set; }
        public string Responsible { get; set; }
        public Area Area { get; set; }
        public DateTime Since { get; set; }
        public int Score { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        internal bool Save()
        {
            var response = false;
            if (this.Id == 0) //insert
            {
                var db = new Db(false);
                db.Connect();
                response = db.Insert(this);
                db.Commit();
                db.Disconnect();
            }
            else //update
            {
                var db = new Db(false);
                db.Connect();
                response = db.Update(this, "Title", "Responsible", "Area.Id", "Since", "Score", "Email", "Phone");
                db.Commit();
                db.Disconnect();
            }
            return response;
        }

        public static List<Customer> GetCustomerList()
        {
            return new Db().Select<Customer>("c", "where c.removed = 0", "Id", "Title", "Responsible",
                "Area.Title", "Since", "Score", "Email", "Phone");
        }

        public static List<Customer> GetCustomerListByArea(string IdArea)
        {
            return new Db().Select<Customer>("c", new Sql("where c.removed = 0 and id_area=?", IdArea), "Id", "Title", "Responsible",
                "Area.Title", "Score", "Email", "Phone");
            
        }

        public static List<Customer> GetAvaliableClients(Customer model, Evaluation evaluation)
        {
            return new Db().Select<Customer>("c", new Sql("where c.removed = 0 and id_area=?", model.Area.Id), "Id", "Title", "Responsible",
                "Area.Title", "Score", "Email", "Phone");
        }

        public static Customer GetSingleCustomer(int idCustomer)
        {
            return new Db().SelectById<Customer>(idCustomer);
        }
        
        internal bool Delete()
        {
            var db = new Db(false);
            db.Connect();
            var response = db.DeleteUpdate(this);
            db.Commit();
            db.Disconnect();
            return response;
        }
    }
    
}