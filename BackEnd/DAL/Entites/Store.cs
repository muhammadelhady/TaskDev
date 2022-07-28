using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entites
{
    public class Store : Audit
    {
        public string Name { get; set; }
        public string Code { get; set; }

    }
}
