using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using ElcutCRM.Data.Models;
using ElcutCRM.Data;

namespace ElcutCRM.Models
{
    public class OrganizationListViewModel
    {
        public IEnumerable<Organization> Organizations { get; set; }

        public IEnumerable<DictionaryEntry> Statuses { get; set; }

        public IEnumerable<OrganizationType> Types { get; set; }

        public IEnumerable<DictionaryEntry> Relationships { get; set; }

        public int SelectedTypeID { get; set; }

        public string SelectedStatus { get; set; }

        public string SelectedRelationship { get; set; }

        public OrganizationListViewModel()
        {
        }

        public OrganizationListViewModel(ElcutBusinessContext context)
        {
            var typesList = new List<OrganizationType>(context.OrganizationManager.GetTypes());
            typesList.Insert(0, new OrganizationType { ID = 0, Name = "все" });
            this.Types = typesList;
        }
    }
}