using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utils.PasswordHasher;

namespace Repository.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private IPasswordHasher passwordHasher = new PasswordHasher();
        public Admin Login(string username, string password)
        {
            string fileName = "appsettings.json";
            try
            {
                if (File.Exists(fileName))
                {
                    string jsonData = File.ReadAllText(fileName);
                    var jsonDocument = JsonDocument.Parse(jsonData);
                    var usersElement = jsonDocument.RootElement.GetProperty("Users").ToString();

                    List<Admin> admins = JsonSerializer.Deserialize<List<Admin>>(usersElement);
                    foreach (Admin a in admins)
                    {
                        if (a.Username == username && passwordHasher.VerifyPassword(password, a.Password))
                        {
                            return a;
                        }
                    }
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
