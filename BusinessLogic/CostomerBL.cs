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
    public class CostomerBL
    {
        CostomerCrud dl = new CostomerCrud();
        public string Creat(Costomer costomer)
        {
            return dl.Create(costomer);
        }
        public List<Costomer> Read()
        {
            return dl.Read();
        }
        public bool Read(Costomer costomer)
        {
            return dl.Read(costomer);
        }
        public List<Costomer> Read(string parametr)
        {
            return dl.Read(parametr);
        }
        public string Update(int Costomerid, Costomer costomerNew)
        {
            return dl.Update(Costomerid, costomerNew);
        }
        public string Delete(int Costomerid)
        {
            return dl.Delete(Costomerid);
        }
        public Costomer Read(int Costomerid)
        {
            return dl.Read(Costomerid);
        }
        public int GetId(string name)
        {
            return dl.GetId(name);
        }
        
    }
}
