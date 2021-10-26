using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using BusinessEntity;
namespace BusinessLogic
{
   public class accountingtypebl
    {

        AccountingTypeCrud dl = new AccountingTypeCrud();
        public void Create(AccountingType ac)
        {
           dl.Creat(ac);
        }
    }
}
