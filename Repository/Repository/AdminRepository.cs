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
                    Admin admin = JsonSerializer.Deserialize<Admin>(jsonData);
                    if(admin.Username == username && passwordHasher.VerifyPassword(password, admin.Password))
                    {
                        return admin;
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
