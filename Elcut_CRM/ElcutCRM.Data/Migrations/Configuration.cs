namespace ElcutCRM.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ElcutCRM.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ElcutCRM.Data.ElcutContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ElcutCRM.Data.ElcutContext context)
        {  
            var userManager = new UserManager();
            
            context.Users.AddOrUpdate(x => x.Email,
              userManager.Create("admin@elcut.ru", "admin")
              );

            context.OrganizationTypes.AddOrUpdate(x => x.Name,
                new OrganizationType { Name = "Предприятие или организация" },
                new OrganizationType { Name = "Учебное заведение" },
                new OrganizationType { Name = "Физическое лицо" }
            );

            context.Countries.AddOrUpdate(x => x.Name,
                new Country { Name = "Россия" },
                new Country { Name = "Беларусь" },
                new Country { Name = "Украина" }
            );

            context.OrderTypes.AddOrUpdate(x => x.Name,
                new OrderType { Name = "Новая покупка" },
                new OrderType { Name = "Обновление старой версии" },
                new OrderType { Name = "Заказ расширенной технической поддержки" }
                );

            context.ConfigurationOptions.AddOrUpdate(x => x.Name,
                new ConfigurationOption { Name = "Магнитостатика", FullGroupName = null, SortOrder = 0 },
                new ConfigurationOption { Name = "Переменное (синусоидальное) магнитное поле", FullGroupName = null, SortOrder = 1 },
                new ConfigurationOption { Name = "Электростатика и электрическое поле постоянных токов", FullGroupName = "Электрические задачи", SortOrder = 2 },
                new ConfigurationOption { Name = "Стационарная теплопередача", FullGroupName = "", SortOrder = 3 },
                new ConfigurationOption { Name = "Механика (линейные деформации)", FullGroupName = "", SortOrder = 4 }
                );

            context.ConfigurationOptions.AddOrUpdate(x => x.Name,
                new ConfigurationOption { Name = "нестационарное магнитное поле", ParentID = context.ConfigurationOptions.FirstOrDefault().ID, SortOrder = 0 },
                new ConfigurationOption { Name = "нестационарное электрическое поле", ParentID = context.ConfigurationOptions.OrderBy(x => x.ID).Skip(2).FirstOrDefault().ID, SortOrder = 0 },
                new ConfigurationOption { Name = "электрическое поле переменных токов", ParentID = context.ConfigurationOptions.OrderBy(x => x.ID).Skip(2).FirstOrDefault().ID, SortOrder = 1 },
                new ConfigurationOption { Name = "нестационарная теплопередача", ParentID = context.ConfigurationOptions.OrderBy(x => x.ID).Skip(3).FirstOrDefault().ID, SortOrder = 0 }
                );

            context.DictionaryEntries.AddOrUpdate(x => x.Key,
                new DictionaryEntry { DictionaryName = DictionaryEntry.ORGANIZATION_STATUS_DICTIONARY, Key="CONSTANT_CLIENT", Name = "Постоянный клиент", SortOrder=0 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.ORGANIZATION_STATUS_DICTIONARY, Key="PERSPECTIVE_CLIENT", Name = "Перспективный клиент", SortOrder=1 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.ORGANIZATION_STATUS_DICTIONARY, Key="NEW_CLIENT", Name = "Новый клиент", SortOrder=2 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.RELATIONSHIP_STATUS_DICTIONARY, Key="POSITIVE_RELATION", Name = "Положительные отношения", SortOrder=0 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.RELATIONSHIP_STATUS_DICTIONARY, Key = "NEUTRAL_RELATION", Name = "Нейтральные отношения", SortOrder = 1 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.RELATIONSHIP_STATUS_DICTIONARY, Key = "NEGATIVE_RELATION", Name = "Отрицательные отношения", SortOrder = 2 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.ORDER_STATUS_DICTIONARY, Key="INVESTIGATION_ORDER", Name = "Ознакомление", SortOrder=0 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.ORDER_STATUS_DICTIONARY, Key = "CANCELLED_ORDER", Name = "Заказ отменён", SortOrder = 1 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.HISTORY_DICTIONARY, Key="CALL_HISTORY", Name = "Звонок клиенту", SortOrder=0 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.HISTORY_DICTIONARY, Key = "ORDER_HISTORY", Name = "Оформление заказа", SortOrder = 1 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.DOCUMENT_TYPE_DICTIONARY, Key = "INVOICE_DOCUMENT", Name = "Счёт", SortOrder = 1 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.DOCUMENT_TYPE_DICTIONARY, Key = "ACT_DOCUMENT", Name = "Акт", SortOrder = 1 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.DOCUMENT_TYPE_DICTIONARY, Key = "CONTRACT_DOCUMENT", Name = "Договор", SortOrder = 1 }
                );
        }
    }
}
