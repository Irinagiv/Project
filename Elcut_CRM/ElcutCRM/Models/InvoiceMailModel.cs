using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElcutCRM.Data.Models;

namespace ElcutCRM.Models
{
    public class InvoiceMailModel : BaseMailModel
    {
        public int Amount { get; set; }

        public string Target { get; set; }

        public override string ViewName
        {
            get
            {
                return "Invoice";
            }
        }

        public override string Subject
        {
            get
            {
                return string.Format("Вам выставлен счёт №{0}", this.Document.ID);
            }
            
        }

        public InvoiceMailModel(Document doc)
            : base(doc)
        {
        }
    }
}