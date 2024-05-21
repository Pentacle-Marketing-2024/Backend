using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.DataAccess
{
    public class FormDBContext
    {
        private static FormDBContext instance = null;
        private static readonly object instanceLock = new object();
        private FormDBContext()
        {
        }

        public static FormDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new FormDBContext();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Form> GetAll()
        {
            IEnumerable<Form> forms = null;
            try
            {
                var context = new Pentacle_MarketingContext();
                forms = context.Forms
                    .OrderByDescending(f => f.CreateDate)
                    .ToList();
                if (forms.Count() == 0)
                {
                    throw new Exception("Not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return forms;
        }

        public IEnumerable<Form> GetByEmail(string email)
        {
            IEnumerable<Form> forms = null;
            try
            {
                var context = new Pentacle_MarketingContext();
                forms = context.Forms
                    .OrderByDescending(f => f.CreateDate)
                    .Where(f => f.Email.ToLower().Contains(email.ToLower()))
                    .ToList();
                if (forms.Count() == 0)
                {
                    throw new Exception("Not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return forms;
        }

        public IEnumerable<Form> GetByFullName(string fullName)
        {
            IEnumerable<Form> forms = null;
            try
            {
                var context = new Pentacle_MarketingContext();
                forms = context.Forms
                    .OrderByDescending(f => f.CreateDate)
                    .Where(f => f.FullName.ToLower().Contains(fullName.ToLower()))
                    .ToList();
                if (forms.Count() == 0)
                {
                    throw new Exception("Not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return forms;
        }

        public Form GetById(int id)
        {
            Form form = null;
            try
            {
                var context = new Pentacle_MarketingContext();
                form = context.Forms.SingleOrDefault(f => f.Id == id);
                if (form != null)
                {
                    throw new Exception("Not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return form;
        }

        public void Create(Form form)
        {
            try
            {
                var context = new Pentacle_MarketingContext();
                context.Forms.Add(form);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
