using System.Data.SqlClient;

namespace cats.Services
{
    internal static class LoginService
    {
        internal static bool IsPasswordCorrect(string email, string password)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.Open();
                
                using (var command = new SqlCommand("SELECT password FROM logins WHERE email = @email", sqlConnection))
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
                            var expectedPassword = reader.GetString(0);
                            
                            return expectedPassword == password;
                        }
                    }
                }
            }
        }
    }
}
