using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElcutCRM.Data.Models;
using System.Data.Entity;

namespace ElcutCRM.Data
{
    public class OrganizationManager
    {
        protected ElcutContext DataContext { get; set; }

        public OrganizationManager(ElcutContext context = null)
        {
            if (context == null)
            {
                context = new ElcutContext();
            }

            this.DataContext = context;
        }

        public IEnumerable<OrganizationType> GetTypes()
        {
            return DataContext.OrganizationTypes.ToList();
        }

        public IEnumerable<Country> GetCountries()
        {
            return DataContext.Countries.ToList();
        }

        public Organization Get(int id)
        {
            var model = DataContext.Organizations
                .Include(x => x.Type)
                .Include(x => x.Country)
                .Include(x => x.Relationship)
                .Include(x => x.Status)
                .SingleOrDefault(x => x.ID == id);

            return model;
        }

        public IEnumerable<Organization> GetAllOrganizations()
        {
            return DataContext.Organizations.Include(x => x.Type);
        }

        public IEnumerable<Organization> GetOrganizations(int selectedTypeID = 0, string selectedStatus = null, string selectedRelationship = null)
        {
            var query = DataContext.Organizations.Include(x => x.Type);

            if (selectedTypeID > 0)
                query = query.Where(x => x.TypeID == selectedTypeID);

            if (!string.IsNullOrEmpty(selectedStatus))
                query = query.Where(x => x.StatusKey == selectedStatus);

            if (!string.IsNullOrEmpty(selectedRelationship))
                query = query.Where(x => x.RelationshipKey == selectedRelationship);

            return query;
        }

        public void Save(Organization org)
        {
            if (org.ID == 0)
            {
                DataContext.Organizations.Add(org);
            }

            DataContext.SaveChanges();
        }

        public Order GetOrder(int id)
        {
            return DataContext.Orders
                .Include(x => x.Organization)
                .SingleOrDefault(x => x.ID == id);
        }

        public IEnumerable<Order> GetOrders(Organization org)
        {
            return DataContext.Orders
                .Where(x => x.OrganizationID == org.ID)
                .Include(x => x.OrderType)
                .Include(x => x.Status);
        }

        public Order AddOrUpdateOrder(Order order)
        {
            if (order.ID == 0)
            {
                DataContext.Orders.Add(order);
            }

            DataContext.SaveChanges();

            return order;
        }

        public ContactName GetContact(int id)
        {
            return DataContext.ContactNames
                .Include(x => x.Organization)
                .SingleOrDefault(x => x.ID == id);
        }

        public ContactName AddOrUpdateContact(ContactName contact)
        {
            if (contact.ID == 0)
            {
                DataContext.ContactNames.Add(contact);
            }

            DataContext.SaveChanges();

            return contact;
        }

        public IEnumerable<History> GetHistory(Organization org)
        {
            return DataContext.Histories
                .Where(x => x.OrganizationID == org.ID)
                .OrderByDescending(x => x.EventDate)
                .Include(x => x.Event);
        }

        public void AddHistory(History history)
        {
            DataContext.Histories.Add(history);
            DataContext.SaveChanges();
        }

        public IEnumerable<Document> GetDocuments(Organization org)
        {
            return DataContext.Documents
                .Where(x => x.OrganizationID == org.ID)
                .OrderByDescending(x => x.CreatedDate)
                .Include(x => x.DocumentType);
        }

        public Document AddDocument(Document doc)
        {
            DataContext.Documents.Add(doc);
            DataContext.SaveChanges();

            return doc;
        }

        public Document GetDocument(int id)
        {
            return DataContext.Documents
                .Include(x => x.Organization)
                .Include(x=>x.DocumentType)
                .SingleOrDefault(x => x.ID == id);
        }
    }
}
