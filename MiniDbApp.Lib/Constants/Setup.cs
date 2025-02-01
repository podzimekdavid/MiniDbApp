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

    public class Api
    {
        public const int DEFAULT_COUNT = 10;
        public const string API_KEY_HEADER_NAME = "X-API-KEY";
    }
    
}