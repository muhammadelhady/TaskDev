using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entites
{
    public class Item : Audit
    {
        public string Name { get; set; }
        public string Serial { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public double Price { get; set; }



    }
}
