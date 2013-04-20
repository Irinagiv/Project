using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElcutCRM.Data.Models
{
    public class Document
    {
        [Key]
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public int OrganizationID { get; set; }

        [ForeignKey("OrganizationID")]
        public Organization Organization { get; set; }

        [Display(Name = "Тип")]
        public string DocumentTypeKey { get; set; }

        [ForeignKey("DocumentTypeKey")]
        public DictionaryEntry DocumentType { get; set; }

        public const string INVOICE_TYPE_KEY = "INVOICE_DOCUMENT";

        public const string ACT_TYPE_KEY = "ACT_DOCUMENT";

        public const string CONTRACT_TYPE_KEY = "CONTRACT_DOCUMENT";
    }
}
