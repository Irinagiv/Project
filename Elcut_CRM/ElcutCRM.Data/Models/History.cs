using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElcutCRM.Data.Models
{
    public class History
    {
        [Key]
        public int ID { get; set; }

        public DateTime EventDate { get; set; }

        public int OrganizationID { get; set; }

        [ForeignKey("OrganizationID")]
        public Organization Organization { get; set; }

        [Display(Name = "Событие")]
        public string EventKey { get; set; }

        [ForeignKey("EventKey")]
        public DictionaryEntry Event { get; set; }
    }
}
