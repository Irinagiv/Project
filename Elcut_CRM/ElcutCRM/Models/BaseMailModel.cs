using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElcutCRM.Data.Models;

namespace ElcutCRM.Models
{
    public class BaseMailModel
    {
        public Organization Organization { get; set; }

        public Document Document { get; set; }

        public virtual string ViewName
        {
            get
            {
                return "Invoice";
            }
        }

        public virtual string Subject { get; set; }

        public BaseMailModel(Organization org)
        {
            this.Organization = org;
        }

        public BaseMailModel(Document doc)
        {
            this.Document = doc;
        }

        public BaseMailModel() { }
    }
}