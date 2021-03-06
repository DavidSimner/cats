using System.Data.SqlClient;

namespace cats.Services
{
    public class AccountService
    {
        private readonly string m_ConnectionString;

        internal AccountService(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        internal string GetName(string email)
        {
            using (var sqlConnection = new SqlConnection(m_ConnectionString))
            {
                sqlConnection.Open();
                
                using (var command = new SqlCommand("SELECT name FROM logins WHERE email = @email", sqlConnection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return reader.GetString(0);
                    }
                }
            }
        }
        
        internal void SetName(string email, string newName)
        {
            using (var sqlConnection = new SqlConnection(m_ConnectionString))
            {
                sqlConnection.Open();
                
                using (var command = new SqlCommand("UPDATE logins SET name = @name WHERE email = @email", sqlConnection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@name", newName);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
