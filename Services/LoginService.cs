using System.Data.SqlClient;

namespace cats.Services
{
    public class LoginService
    {
        internal bool IsPasswordCorrect(string email, string password)
        {
            using (var sqlConnection = new SqlConnection())
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
