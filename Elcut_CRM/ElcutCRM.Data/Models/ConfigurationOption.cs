using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElcutCRM.Data.Models
{
    public class ConfigurationOption
    {
        [Key]
        public short ID { get; set; }

        public string Name { get; set; }

        public string FullGroupName { get; set; }

        public short? ParentID { get; set; }

        [ForeignKey("ParentID")]
        public ConfigurationOption ParentOption { get; set; }

        public virtual ICollection<ConfigurationOption> Options { get; set; }

        public virtual ICollection<OptionPrice> OptionPrices { get; set; }

        public short SortOrder { get; set; }
    }
}
