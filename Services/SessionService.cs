using System.Data.SqlClient;

namespace cats.Services
{
    public class SessionService
    {
        private readonly string m_ConnectionString;

        internal SessionService(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        internal void LogSessionIn(string session, string email)
        {
            using (var sqlConnection = new SqlConnection(m_ConnectionString))
            {
                sqlConnection.Open();
                
                //TODO
            }
        }
    }
}
