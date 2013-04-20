using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ElcutCRM.Data.Models
{
    /*
    public enum OrganizationType : short
    {
        [Display(Name="Предприятие или организация")]
        Organization = 1,
        [Display(Name = "Учебное заведение")]
        Education = 2,
        [Display(Name = "Физическое лицо")]
        Person = 3
    }
     */

    public class OrganizationType
    {
        [Key]
        public short ID { get; set; }

        public string Name { get; set; }
    }
}
