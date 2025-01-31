namespace MiniDbApp.Lib.Constants;

public class Setup
{
    public const string DATBASE_SELECT_ENV = "DATABASE_TYPE";
    public class Database
    {
        public const string MSSQL = "mssql";
        public const string IN_MEMORY = "inmemory";
        
        public class InMemory
        {
            public const string DEFAULT_DATBASE_NAME = "DefaultDb";
        }
    }
}