using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPS_MVC.Models
{
    public class BaseModel<T>
    {
        public Int32 Id { get; set; }
        public Int32 Removed { get; set; }
        public virtual bool insert() { return true; }
        public virtual bool update() { return false; }
        public virtual bool delete(Int32 id) { return false; }
        public virtual T load(Int32 id) { return default(T); }
        public virtual List<T> getList(bool includeRemoved) { return new List<T>(); }
    }
}