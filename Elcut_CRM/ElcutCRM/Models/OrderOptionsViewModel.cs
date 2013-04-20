using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using ElcutCRM.Data.Models;
using ElcutCRM.Data;

namespace ElcutCRM.Models
{
    public class OrderOptionsViewModel
    {
        public Order Order { get; set; }

        public IEnumerable<ConfigurationOption> AvaliableOptions { get; set; }

        public IEnumerable<short> SelectedOptions { get; set; }

        public OrderOptionsViewModel()
        {
        }

        public OrderOptionsViewModel(Order order)
        {
            var manager = new OrderManager();
            this.Order = order;
            this.AvaliableOptions = manager.GetParentOptions();
            this.SelectedOptions = manager.GetOrderConfigurations(order).Select(x => x.OptionID).ToList();
        }
    }
}