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
                new OrganizationType { Name = "����������� ��� �����������" },
                new OrganizationType { Name = "������� ���������" },
                new OrganizationType { Name = "���������� ����" }
            );

            context.Countries.AddOrUpdate(x => x.Name,
                new Country { Name = "������" },
                new Country { Name = "��������" },
                new Country { Name = "�������" }
            );

            context.OrderTypes.AddOrUpdate(x => x.Name,
                new OrderType { Name = "����� �������" },
                new OrderType { Name = "���������� ������ ������" },
                new OrderType { Name = "����� ����������� ����������� ���������" }
                );

            context.ConfigurationOptions.AddOrUpdate(x => x.Name,
                new ConfigurationOption { Name = "��������������", FullGroupName = null, SortOrder = 0 },
                new ConfigurationOption { Name = "���������� (��������������) ��������� ����", FullGroupName = null, SortOrder = 1 },
                new ConfigurationOption { Name = "�������������� � ������������� ���� ���������� �����", FullGroupName = "������������� ������", SortOrder = 2 },
                new ConfigurationOption { Name = "������������ �������������", FullGroupName = "", SortOrder = 3 },
                new ConfigurationOption { Name = "�������� (�������� ����������)", FullGroupName = "", SortOrder = 4 }
                );

            context.ConfigurationOptions.AddOrUpdate(x => x.Name,
                new ConfigurationOption { Name = "�������������� ��������� ����", ParentID = context.ConfigurationOptions.FirstOrDefault().ID, SortOrder = 0 },
                new ConfigurationOption { Name = "�������������� ������������� ����", ParentID = context.ConfigurationOptions.OrderBy(x => x.ID).Skip(2).FirstOrDefault().ID, SortOrder = 0 },
                new ConfigurationOption { Name = "������������� ���� ���������� �����", ParentID = context.ConfigurationOptions.OrderBy(x => x.ID).Skip(2).FirstOrDefault().ID, SortOrder = 1 },
                new ConfigurationOption { Name = "�������������� �������������", ParentID = context.ConfigurationOptions.OrderBy(x => x.ID).Skip(3).FirstOrDefault().ID, SortOrder = 0 }
                );

            context.DictionaryEntries.AddOrUpdate(x => x.Key,
                new DictionaryEntry { DictionaryName = DictionaryEntry.ORGANIZATION_STATUS_DICTIONARY, Key="CONSTANT_CLIENT", Name = "���������� ������", SortOrder=0 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.ORGANIZATION_STATUS_DICTIONARY, Key="PERSPECTIVE_CLIENT", Name = "������������� ������", SortOrder=1 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.ORGANIZATION_STATUS_DICTIONARY, Key="NEW_CLIENT", Name = "����� ������", SortOrder=2 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.RELATIONSHIP_STATUS_DICTIONARY, Key="POSITIVE_RELATION", Name = "������������� ���������", SortOrder=0 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.RELATIONSHIP_STATUS_DICTIONARY, Key = "NEUTRAL_RELATION", Name = "����������� ���������", SortOrder = 1 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.RELATIONSHIP_STATUS_DICTIONARY, Key = "NEGATIVE_RELATION", Name = "������������� ���������", SortOrder = 2 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.ORDER_STATUS_DICTIONARY, Key="INVESTIGATION_ORDER", Name = "������������", SortOrder=0 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.ORDER_STATUS_DICTIONARY, Key = "CANCELLED_ORDER", Name = "����� ������", SortOrder = 1 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.HISTORY_DICTIONARY, Key="CALL_HISTORY", Name = "������ �������", SortOrder=0 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.HISTORY_DICTIONARY, Key = "ORDER_HISTORY", Name = "���������� ������", SortOrder = 1 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.DOCUMENT_TYPE_DICTIONARY, Key = "INVOICE_DOCUMENT", Name = "����", SortOrder = 1 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.DOCUMENT_TYPE_DICTIONARY, Key = "ACT_DOCUMENT", Name = "���", SortOrder = 1 },
                new DictionaryEntry { DictionaryName = DictionaryEntry.DOCUMENT_TYPE_DICTIONARY, Key = "CONTRACT_DOCUMENT", Name = "�������", SortOrder = 1 }
                );
        }
    }
}
