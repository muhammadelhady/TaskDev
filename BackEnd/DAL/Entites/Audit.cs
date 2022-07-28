using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entites
{
    public class Audit
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
