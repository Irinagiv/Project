using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElcutCRM.Data.Models
{
    public class Organization
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Тип")]
        public short TypeID { get; set; }

        [ForeignKey("TypeID")]
        public OrganizationType Type { get; set; }

        [NotMapped]
        public IEnumerable<OrganizationType> TypesList { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Страна")]
        public short CountryID { get; set; }

        [ForeignKey("CountryID")]
        public Country Country { get; set; }

        [NotMapped]
        public IEnumerable<Country> CountriesList { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Почтовый индекс")]
        public string Index { get; set; }

        [Display(Name = "Сайт")]
        public string Site { get; set; }

        [Display(Name = "Статус клиента")]
        public string StatusKey { get; set; }

        [ForeignKey("StatusKey")]
        public DictionaryEntry Status { get; set; }

        [Display(Name = "Отношения с клиентом")]
        public string RelationshipKey { get; set; }

        [ForeignKey("RelationshipKey")]
        public DictionaryEntry Relationship { get; set; }


        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<ContactName> ContactNames { get; set; }

        public virtual ICollection<History> Histories { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}