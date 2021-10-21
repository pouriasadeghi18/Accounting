using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class Accounting
    {
        public int id { get; set; }

        [ForeignKey("Costomer")]
        public int Costomerid { get; set; }
        [ForeignKey("AccountingType")]
        public int Typeid { get; set; }
        public int Amount { get; set; }
        public string Discraption { get; set; }
        public DateTime DataTitle { get; set; }
        public Costomer Costomer { get; set; }
        public AccountingType AccountingType { get; set; }
    }
}
