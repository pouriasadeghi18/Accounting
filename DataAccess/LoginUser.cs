using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LoginUser
    {
        DataBase DB = new DataBase();
       public byte Login(string email, string password)
        {
            if (DB.Users.Count() == 0)
            {
                return 0;
            }
            else
            {
                if (DB.Users.Any(i => i.E_Post == email && i.Password == password))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }
    }
    }
