using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;


namespace DataAccess.Crud
{
    public class AccountingTypeCrud
    {
        DataBase db = new DataBase();



        public void Creat(AccountingType accountingType)
        {

            if (!Read(accountingType))
            {
                db.AccountingTypes.Add(accountingType);
                db.SaveChanges();
            }



        }
        public bool Read(AccountingType type)
        {
            return db.AccountingTypes.Any(i => i.id == type.id);
        }
    }
}
