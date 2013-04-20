using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElcutCRM.Data.Models;
using System.Data.Entity;

namespace ElcutCRM.Data
{
    public class OrderManager
    {
        protected ElcutContext DataContext { get; set; }

        public OrderManager(ElcutContext context = null)
        {
            if (context == null)
            {
                context = new ElcutContext();
            }

            this.DataContext = context;
        }

        public IEnumerable<OrderType> GetTypes()
        {
            return DataContext.OrderTypes.ToList();
        }

        public Order Get(int id)
        {
            var model = DataContext.Orders
                .Include(x => x.OrderType)
                .Include(x => x.Organization)
                .Include(x => x.Status)
                .SingleOrDefault(x => x.ID == id);

            return model;
        }

        public IEnumerable<ConfigurationOption> GetParentOptions()
        {
            return DataContext.ConfigurationOptions
                .Include(x => x.Options)
                .Where(x => x.ParentID == null);
        }

        public IEnumerable<OptionPrice> GetAvaliablePrices()
        {
            return DataContext.OptionPrices.ToList();
        }

        public IEnumerable<OrderConfiguration> GetOrderConfigurations(Order order)
        {
            return DataContext.OrderConfigurations.Where(x => x.OrderID == order.ID);
        }

        public void UpdateOrderConfiguration(Order order, IEnumerable<short> optionIds)
        {
            var optionsToDelete = DataContext.OrderConfigurations.Where(x => x.OrderID == order.ID);

            foreach (var opt in optionsToDelete)
            {
                DataContext.OrderConfigurations.Remove(opt);
            }

            DataContext.SaveChanges();

            foreach (var id in optionIds)
            {
                var opt = new OrderConfiguration { OrderID = order.ID, OptionID = id };
                DataContext.OrderConfigurations.Add(opt);
            }

            DataContext.SaveChanges();

            var orderType = DataContext.OrderTypes.SingleOrDefault(x => x.ID == order.TypeID);
            var name = string.Format("ELCUT {0}", orderType.Name);

            var configurations = DataContext.OrderConfigurations
                .Where(x => x.OrderID == order.ID && x.Option.ParentID == null)
                .Include(x => x.Option)
                .Include(x => x.Option.Options);
            

            foreach (var opt in configurations)
            {
                name += ", " + opt.Option.Name;
                foreach (var child in opt.Option.Options)
                {
                    name += " +" + child.Name;
                }
                name.Trim(",".ToCharArray());
            }

            order.ConfigurationName = name;

            DataContext.SaveChanges();

            order.Price = order.CalculatePrice();

            DataContext.SaveChanges();
        }

        public Order Save(Order order)
        {
            if (order.ID == 0)
            {
                DataContext.Orders.Add(order);
            }

            DataContext.SaveChanges();

            return order;
        }   
    }
}
