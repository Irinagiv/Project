using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElcutCRM.Data.Models
{
    public class OptionPrice
    {
        [Key]
        public short ID { get; set; }

        public short OrderTypeID { get; set; }

        public short ConfigurationOptionID { get; set; }

        [ForeignKey("OrderTypeID")]
        public OrderType OrderType { get; set; }

        [ForeignKey("ConfigurationOptionID")]
        public ConfigurationOption ConfigurationOption { get; set; }

        public short Price { get; set; }
    }
}
