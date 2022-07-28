using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entites
{
    public class Invoice :Audit
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public Unit Unit { get; set; }
        public int UnitId { get; set; }
        public int Quantity { get; set; }
        public double CashDiscount { get; set; }
        public double Vat { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public double TotalInvoice { get; set; }
        public DateTime DueDate { get; set; }
        public double DistDisc { get; set; }
        public double PharmDisc { get; set; }
        public double VatValue { get; set; }


    }
}
