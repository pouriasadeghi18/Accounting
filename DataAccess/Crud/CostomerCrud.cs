using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;

namespace DataAccess.Crud
{
  public  class CostomerCrud
    {
        DataBase db = new DataBase();

        public string Create(Costomer costomer)
        {
            if (!Read(costomer))
            {

                db.Costomers.Add(costomer);
                db.SaveChanges();
                return "ثبت نام شما با موفقیت انجام شد";
            }
            else
            {
                return "کاربر گرامی شما قبلا ثبت نام کرده اید";
            }

        }
        public List<Costomer> Read()
        {
            return db.Costomers.ToList();
        }
        public bool Read(Costomer costomer)
        {
            return db.Costomers.Any(i => i.E_Post == costomer.E_Post || i.Mobile == costomer.Mobile);
        }
        //public bool ReadName(Costomer costomer)
        //{
        //    return db.Costomers.Any(i => i.FullName == costomer.FullName);
        //}
        public List<Costomer> Read(string parameter)
        {
            return db.Costomers.Where(i => i.FullName.Contains(parameter) || i.E_Post.Contains(parameter) || i.Mobile.Contains(parameter) ).ToList();
        }
        public Costomer Read(int Costomerid)
        {
            return db.Costomers.Where(i => i.CostomerID == Costomerid).Single();
        }
        public int GetId(string name)
        {
            return db.Costomers.First(i => i.FullName == name).CostomerID;
        }
        public string Update(int Costomerid, Costomer Costomersnew)
        {
            Costomer Costomer = new Costomer();
            Costomer = Read(Costomerid);
            Costomer.FullName = Costomersnew.FullName;
            Costomer.E_Post = Costomersnew.E_Post;
            Costomer.Mobile = Costomersnew.Mobile;
            Costomer.Password = Costomersnew.Password;
            Costomer.PicAddress = Costomersnew.PicAddress;
            db.SaveChanges();
            return "ویرایش با موقعیت انجام شد";
        }
        public string Delete(int Costomerid)
        {
            Costomer Costomer = Read(Costomerid);
            db.Costomers.Remove(Costomer);
            db.SaveChanges();
            return "حذف با موفقعیت انجام شد";
        }
    }
}

