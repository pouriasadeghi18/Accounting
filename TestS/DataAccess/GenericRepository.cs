namespace DataAccess
{
    internal class GenericRepository
    {
        private DataBase db;

        public GenericRepository(DataBase db)
        {
            this.db = db;
        }
    }
}