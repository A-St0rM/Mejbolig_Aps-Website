using M.E.J_PropertyWebsite.Server.Models;

namespace M.E.J_PropertyWebsite.Server.Database
{
    public class DataSeeder
    {
        public static void SeedData(AzureDBContext context)
        {

            if (context.Admin.Any())
            {
                return;
            }

            context.Admin.AddRange(
                new Admin
                { 
                    UserName = "Casper", 
                    Password = BCrypt.Net.BCrypt.HashPassword("123")
                },
                new Admin
                {
                    UserName = "Alissa",
                    Password = BCrypt.Net.BCrypt.HashPassword("123")
                }
            );
            context.SaveChanges();

        }
    }
}
