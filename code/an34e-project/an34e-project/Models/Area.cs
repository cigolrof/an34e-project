using ForLogic.Persistence;
using System;
using System.Collections.Generic;

namespace ProjetoNPS.Models
{
    public class Area : BaseClass
    {
        public string Title { get; set; }
        public int QuantidadeAreas { get; set; }

        internal void Save()
        {
            var db = new Db(false);
            db.Connect();
            db.Insert(this);
            db.Commit();
            db.Disconnect();
        }

        public static List<Area> GetAreaList()
        {
            return new Db().Select<Area>("a", "where a.removed = 0", "Id", "Title", "Removed");
        }

        internal static Area GetSingleArea(string IdArea)
        {
            return new Db().SelectById<Area>(IdArea);
        }


    }


}