
namespace banze
{
    public class AppSettings
    {
        public ConnectionStringsSettings ConnectionStrings { get; set; }

        public class ConnectionStringsSettings
        {
            public string MySQLConnectionString { get; set; }
            public string DefaultConnection { get; set; }
        }


    }
}