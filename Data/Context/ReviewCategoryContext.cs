using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace Data.Context
{
    public class ReviewCategoryContext
    {
        private string ConnectionString = "Server=tcp:joshhq.database.windows.net,1433;Initial Catalog=Rockstar;Persist Security Info=False;User ID=joshhq;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public void AddCategory(Category category)
        {
            string query = "INSERT INTO Category(Name) VALUES (@Name)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Name", category.Name);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Category> GetCategoriesSelectForCompany()
        {
            string query = "SELECT * FROM Category";
            var categories = new List<Category>();

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) {
                            var category = new Category()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"]
                            };
                            categories.Add(category);
                        }
                        
                    }

                    return categories;
                }
            }
        }

        public void AddSelectedCategoriesToCompany(int categoryId, int companyId)
        {
            string query = "INSERT INTO Category_Company(Company_Id, Category_Id)" +
                           "VALUES(@CompanyId, @CategoryId)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@CompanyId", companyId);
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
