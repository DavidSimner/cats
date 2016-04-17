using System.Data.SqlClient;

namespace cats.Services
{
    public class LoginService
    {
        private readonly string m_ConnectionString;

        internal LoginService(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        internal bool IsPasswordCorrect(string email, string password)
        {
            using (var sqlConnection = new SqlConnection(m_ConnectionString))
            {
                sqlConnection.Open();
                
                using (var command = new SqlCommand("SELECT salt,hash FROM logins WHERE email = @email", sqlConnection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return false;
                        }
                        else
                        {
                            var salt = reader.GetString(0);
                            var expectedHash = reader.GetString(1);
                            
                            var actualHash = HashingService.Hash(salt, password);
                            
                            return expectedHash == actualHash;
                        }
                    }
                }
            }
        }
    }
}
