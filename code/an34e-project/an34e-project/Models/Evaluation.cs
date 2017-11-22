using ForLogic.Persistence;
using System;
using System.Collections.Generic;

namespace ProjetoNPS.Models
{
    public class Evaluation : BaseClass
    {
        public string CodEvaluation { get; set; }
        public Area Area { get; set; }
        //public int Month { get; set; }
        //public int Year { get; set; }
        public DateTime ReferenceDate { get; set; }
        public double Score { get; set; }
        public int Promotores { get; set; }
        public int Detratores { get; set; }
        public int Neutros { get; set; }
        public int Cancelada { get; set; }
        public int Status { get; set; }

        internal bool Save()
        {
            var response = false;
            //if (this.Id == 0) //insert
            //{
                var db = new Db(false);
                db.Connect();
                response = db.Insert(this);
                db.Commit();
                db.Disconnect();
            //}
            return response;
        }

        internal static List<Evaluation> GetEvaluationList()
        {
            return new Db().Select<Evaluation>("e", "where e.removed = 0 order by reference_date desc", "Id", "ReferenceDate",
                 "Promotores", "Detratores", "Neutros", "Cancelada", "Status", "Area.Id");
        }

        internal bool HasEvaluation()
        {
            var response = false;
            var dt =  new Db().Select<Evaluation>("e", new Sql("where e.removed=0 and status=0 and id_area=? or reference_date=?", this.Area.Id, this.ReferenceDate.ToString("yyyy-MM-dd")), "Id", "ReferenceDate", "Status", "Area.Id");
            if (dt.Count != 0 || dt.Count > 0)
            {
                response = true;
            }
            return response;
        }
    }
}