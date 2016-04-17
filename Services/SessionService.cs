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
                
                using (var command = new SqlCommand("INSERT INTO sessions VALUES (@id, @email)", sqlConnection))
                {
                    command.Parameters.AddWithValue("@id", session);
                    command.Parameters.AddWithValue("@email", email);
                    command.ExecuteNonQuery();
                }
            }
        }
        
        internal string GetSessionEmail(string session)
        {
            using (var sqlConnection = new SqlConnection(m_ConnectionString))
            {
                sqlConnection.Open();
                
                using (var command = new SqlCommand("SELECT email FROM sessions WHERE id = @id", sqlConnection))
                {
                    command.Parameters.AddWithValue("@id", session);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? reader.GetString(0) : null;
                    }
                }
            }
        }
        
        internal void LogSessionOut(string session)
        {
            using (var sqlConnection = new SqlConnection(m_ConnectionString))
            {
                sqlConnection.Open();
                
                using (var command = new SqlCommand("DELETE FROM sessions WHERE id = @id", sqlConnection))
                {
                    command.Parameters.AddWithValue("@id", session);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
