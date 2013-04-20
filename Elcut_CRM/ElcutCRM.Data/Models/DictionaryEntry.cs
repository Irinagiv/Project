using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElcutCRM.Data.Models
{
    public class DictionaryEntry
    {
        [Key]
        public string Key { get; set; }

        public string DictionaryName { get; set; }

        public string Name { get; set; }

        public short SortOrder { get; set; }

        public const string ORGANIZATION_STATUS_DICTIONARY = "ORGANIZATION_STATUS";
        public const string RELATIONSHIP_STATUS_DICTIONARY = "RELATIONSHIP";
        public const string ORDER_STATUS_DICTIONARY = "ORDER_STATUS";
        public const string HISTORY_DICTIONARY = "HISTORY";
        public const string DOCUMENT_TYPE_DICTIONARY = "DOCUMENT_TYPE";
    }
}
