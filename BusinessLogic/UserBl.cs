using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessEntity;
using DataAccess.Crud;

namespace BusinessLogic
{
    public class UserBl
    { UserCrud Dl = new UserCrud();
        public string Create(Users user)
        {
            return Dl.Create(user);
        }
    }
}
