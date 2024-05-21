using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IFormRepository
    {
        public void Create(Form form);
        public Form GetById(int id);
        public IEnumerable<Form> GetByFullName(string fullName);
        public IEnumerable<Form> GetByEmail(string email);
        public IEnumerable<Form> GetAll();
    }
}
