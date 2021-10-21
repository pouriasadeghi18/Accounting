using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using DataAccess;
using DataAccess.Crud;

namespace BusinessLogic
{
   public class AccountingBl
    {

        AccountingCrud dl = new AccountingCrud();
        public string Create(Accounting accounting)
        {
            return dl.Create(accounting);
        }
    }
}
