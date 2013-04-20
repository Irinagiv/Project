using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElcutCRM.Data.Models;
using System.Data.Entity;

namespace ElcutCRM.Data
{
    public class GenericManager<T> where T : class
    {
        protected ElcutContext DataContext { get; set; }

        public GenericManager(ElcutContext context = null)
        {
            if (context == null)
            {
                context = new ElcutContext();
            }

            this.DataContext = context;
        }

        public void Delete(T entity)
        {
            DataContext.Set<T>().Remove(entity);

            DataContext.SaveChanges();
        }

        public T Get(object key)
        {
            return DataContext.Set<T>().Find(key);
        }
    }
}
