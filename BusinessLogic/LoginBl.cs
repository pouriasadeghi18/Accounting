using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
   public class LoginBl
    {
        LoginUser login = new LoginUser();
        public byte Login(string email, string password)
        {
            return login.Login(email, password);
        }
    }
}
