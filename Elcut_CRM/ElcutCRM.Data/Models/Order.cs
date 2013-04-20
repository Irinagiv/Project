using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElcutCRM.Data.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        public int OrganizationID { get; set; }

        [ForeignKey("OrganizationID")]
        public Organization Organization { get; set; }

        private static IEnumerable<KeyValuePair<string, string>> _versions;

        public IEnumerable<KeyValuePair<string, string>> GetAvaliableVersions()
        {
            if (_versions == null)
            {
                var list = new List<KeyValuePair<string, string>>(2);

                list.Add(new KeyValuePair<string, string>("Student", "Студенческая"));
                list.Add(new KeyValuePair<string, string>("Professional", "Профессиональная"));

                _versions = list;
            }

            return _versions;
        }

        public string VersionKey { get; set; }

        [NotMapped]
        public string VersionName
        {
            get
            {
                return this.GetAvaliableVersions()
                    .SingleOrDefault(x => x.Key == this.VersionKey)
                    .Value;
            }
        }

        [Display(Name = "Тип")]
        public short TypeID { get; set; }

        [ForeignKey("TypeID")]
        public OrderType OrderType { get; set; }

        [NotMapped]
        public IEnumerable<OrderType> OrderTypes { get; set; }

        [Display(Name = "Статус")]
        public string StatusKey { get; set; }

        [ForeignKey("StatusKey")]
        public DictionaryEntry Status { get; set; }

        public string ConfigurationName { get; set; }

        public int Price { get; set; }

        public virtual ICollection<OrderConfiguration> OrderConfigurations { get; set; }

        public int CalculatePrice()
        {
            if (this.VersionKey == Order.ORDER_VERSION_STUDENT)
            {
                return 0;
            }
            return this.OrderConfigurations
                .SelectMany(x => x.Option.OptionPrices)
                .Where(x => x.OrderTypeID == this.TypeID)
                .Sum(x => x.Price);
        }

        public const string ORDER_VERSION_STUDENT = "Student";
    }
}