using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace DataAccess.Crud
{
   public class UserCrud
    {
        DataBase DB = new DataBase();
        public string Create(Users user)
        {
            if (!Read(user))
            {
                DB.Users.Add(user);
              DB.SaveChanges();
                
                
                
                return "ثبت نام شما با موفقیت انجام شد";
            }
            else
            {
                return "کاربر گرامی شما قبلا ثبت نام کرده اید";
            }
        }
        public bool Read(Users user)
        {
             return DB.Users.Any(i => i.E_Post == user.E_Post || i.Mobile == i.Mobile);
        }
    }
}
