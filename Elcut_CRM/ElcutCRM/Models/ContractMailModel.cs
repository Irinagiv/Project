using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElcutCRM.Data.Models;

namespace ElcutCRM.Models
{
    public class ContractMailModel : BaseMailModel
    {

        public override string ViewName
        {
            get
            {
                return "Contract";
            }
        }

        public override string Subject
        {
            get
            {
                return string.Format("Договор №{0}", this.Document.ID);
            }

        }

        public ContractMailModel(Document doc)
            : base(doc)
        {
        }
    }
}