using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;

namespace DataAccess.Crud
{
    public class AccountingCrud
    {
        DataBase db = new DataBase();
        public string Create(Accounting accounting)
        {
            if (!Read(accounting))
            {
                db.Accountings.Add(accounting);
                db.SaveChanges();
                return "ثبت شد";
            }
            else
            {
                return "ثبت نشد";
            }
            
        }
        public bool Read(Accounting accounting)
        {
            return db.Accountings.Any(i => i.id == accounting.id);
        }
    }
}
