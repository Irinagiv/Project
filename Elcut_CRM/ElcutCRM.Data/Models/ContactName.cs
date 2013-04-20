using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElcutCRM.Data.Models
{
    public class ContactName
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Отчество")]
        public string Surname { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", this.LastName, this.Name, this.Surname);
            }
        }

        [Display(Name = "Должность")]
        public string Position { get; set; }

        [Display(Name = "Телефон")]
        [RegularExpression(@"^\+[0-9 ]+$", ErrorMessage="Введите телефон вида +X XXX")]
        public string Phone { get; set; }

        [Display(Name = "Факс")]
        public string Fax { get; set; }

        [Display(Name = "E-mail")]
        [RegularExpression(
            @"^[-a-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-a-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[a-z0-9]([-a-z0-9]{0,61}[a-z0-9])?\.)*(?:aero|arpa|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|[a-z][a-z])$",
            ErrorMessage = "Неправильный формат email")]
        public string Email { get; set; }

        public int OrganizationID { get; set; }

        [ForeignKey("OrganizationID")]
        public Organization Organization { get; set; }

        public string VKID { get; set; }
    }
}
