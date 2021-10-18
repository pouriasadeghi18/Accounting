using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using System.Data.Entity;


namespace DataAccess
{
    public class DataBase:DbContext
    {
        public DataBase() : base("DBcontect") { }
        public DbSet<Costomer> Costomers { get; set; }
    }
}
