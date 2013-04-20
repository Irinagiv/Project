using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElcutCRM.Data.Models
{
    public class Country
    {
        [Key]
        public short ID { get; set; }

        public string Name { get; set; }

        //public short SortOrder { get; set; }
    }
}
