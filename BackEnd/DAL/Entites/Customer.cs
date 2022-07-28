using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entites
{
    public class Customer : Audit
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string phone { get; set; }

    }
}
