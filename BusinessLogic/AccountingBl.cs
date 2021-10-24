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
        public List<Accounting> Read()
        {
            return dl.Read();
        }
        public Accounting Read(int accountingid)
        {
            return dl.Read(accountingid);
        }
        public List<Accounting> ReadByTypeID(int TypeID)
        {
            return dl.ReadByTypeID(TypeID);
        }
        public string Delete(int accountingid)
        {
            return dl.Delete(accountingid);
        }
        public string Update(int accountingid, Accounting Accountingnew)
        {
            return dl.Update(accountingid, Accountingnew);
        }
        public List<Accounting> ReadByCustomerId(int CustomerID)
        {
            return dl.ReadByCustomerId(CustomerID);
        }
    }
}
