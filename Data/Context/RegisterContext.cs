using System.Data.SqlClient;
using Models;

namespace Data.Context
{
    public class RegisterContext
    {
        private string ConnectionString { get; set; } = "Server=tcp:joshhq.database.windows.net,1433;Initial Catalog=Rockstar;Persist Security Info=False;User ID=joshhq;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public void RegisterUser(string newUserName, string newUserEmail, string newUserPassWord, int newUserRole)
        {
            string query = $"INSERT INTO [User](Name, Email, Password, Role_Id, HasLoggedIn) VALUES(@Name, @Email, @PassWord, @RoleID, 0)";

            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Name", newUserName));
                    cmd.Parameters.Add(new SqlParameter("@PassWord", newUserPassWord));
                    cmd.Parameters.Add(new SqlParameter("@Email", newUserEmail));
                    cmd.Parameters.Add(new SqlParameter("@RoleID", newUserRole));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RegisterCompany(Company company)
        {
            string query = "INSERT INTO Company(Name, Password, Email, Phonenumber, Location, Info, Image)" +
                           "VALUES(@Name, @Password, @Email, @Phone, @Location, @Info, @Image)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Name", company.Name);
                    cmd.Parameters.AddWithValue("@Password", company.Password);
                    cmd.Parameters.AddWithValue("@Email", company.Email);
                    cmd.Parameters.AddWithValue("@Phone", company.TelephoneNr);
                    cmd.Parameters.AddWithValue("@Location", company.Location);
                    cmd.Parameters.AddWithValue("@Info", company.Info);
                    cmd.Parameters.AddWithValue("@Image", company.Image);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void FirstTimeLogIn(Account dataForUser)
        {
            string query = $"UPDATE [User] SET Phone = @Phone, Location = @Location, Gender = @Gender, HasLoggedIn = 'true' WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (dataForUser.Phone != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@Phone", dataForUser.Phone));
                    }
                    if (dataForUser.Location != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@Location", dataForUser.Location));
                    }
                    //if (dataForUser.Birthdate != null)
                    //{
                    //    cmd.Parameters.Add(new SqlParameter("@Birthdate", dataForUser.Birthdate));
                    //}
                    if (dataForUser.Gender != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@Gender", dataForUser.Gender));
                    }
                    cmd.Parameters.Add(new SqlParameter("@Id", dataForUser.Id));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
