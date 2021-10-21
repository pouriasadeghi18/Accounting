using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
 public   class AccountingType

    {
        public int id { get; set; }
        [Required]
        public string TypeTitle { get; set; }
        public List<Accounting> accountings { get; set; } = new List<Accounting>();
    }
}
