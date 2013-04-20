using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElcutCRM.Data.Models;
using System.Data.Entity;

namespace ElcutCRM.Data
{
    public class DictionaryManager
    {
        protected ElcutContext DataContext { get; set; }

        public DictionaryManager(ElcutContext context = null)
        {
            if (context == null)
            {
                context = new ElcutContext();
            }

            this.DataContext = context;
        }

        public DictionaryEntry Get(string key)
        {
            return DataContext.DictionaryEntries.SingleOrDefault(x => x.Key == key);
        }

        public IEnumerable<DictionaryEntry> GetAllByDictionary(string dictionary)
        {
            return DataContext.DictionaryEntries
                .Where(x => x.DictionaryName == dictionary)
                .OrderBy(x => x.SortOrder);
        }
    }
}
