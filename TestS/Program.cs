using System;
using DataAccess;
using BusinessEntity;


namespace TestS
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase();
            
            GenericRepository<Costomer> generic = new GenericRepository<Costomer>(db);

            var s = generic.Read();
            
        }
    }
}
