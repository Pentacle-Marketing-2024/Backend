using Repository.DataAccess;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class FormRepository : IFormRepository
    {
        public void Create(Form form) 
            => FormDBContext.Instance.Create(form);

        public IEnumerable<Form> GetAll() 
            => FormDBContext.Instance.GetAll();

        public IEnumerable<Form> GetByEmail(string email) 
            => FormDBContext.Instance.GetByEmail(email);

        public IEnumerable<Form> GetByFullName(string fullName)
            => FormDBContext.Instance.GetByFullName(fullName);

        public Form GetById(int id) 
            => FormDBContext.Instance.GetById(id);
    }
}
