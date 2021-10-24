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
        public List<Accounting> Read()
        {
            return db.Accountings.ToList();
        }
        public List<Accounting> ReadByTypeID(int TypeID)
        {
            return db.Accountings.Where(i => i.Typeid == TypeID).ToList();
        }
        public Accounting Read(int accountingid)
        {
            return db.Accountings.Where(i => i.id == accountingid).Single();
        }
        public string Delete(int accountingid)
        {
            Accounting accounting = Read(accountingid);
            db.Accountings.Remove(accounting);
            db.SaveChanges();
            return "حذف با موفقعیت انجام شد";
        }
        public string Update(int accountingid, Accounting Accountingnew)
        {
            Accounting accounting = new Accounting();
            accounting = Read(accountingid);
            accounting.Costomerid = Accountingnew.Costomerid;
            accounting.Typeid = Accountingnew.Typeid;
            accounting.Amount = Accountingnew.Amount;
            accounting.Discraption = Accountingnew.Discraption;
            accounting.DataTitle = Accountingnew.DataTitle;
            db.SaveChanges();
            return "ویرایش با موقعیت انجام شد";
        }
        public List<Accounting> ReadByCustomerId(int CustomerID)
        {
           return db.Accountings.Where(i => i.Costomerid == CustomerID).ToList();
        }

    }
}
