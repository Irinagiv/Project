using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElcutCRM.Data.Models
{
    public class OrderConfiguration
    {
        [Key]
        public short ID { get; set; }

        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public Order Order { get; set; }

        public short OptionID { get; set; }

        [ForeignKey("OptionID")]
        public ConfigurationOption Option { get; set; }
    }
}
