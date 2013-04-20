using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElcutCRM.Data.Models;

namespace ElcutCRM.Models
{
    public class ActMailModel : BaseMailModel
    {

        public override string ViewName
        {
            get
            {
                return "Act";
            }
        }

        public override string Subject
        {
            get
            {
                return string.Format("Акт №{0}", this.Document.ID);
            }

        }

        public ActMailModel(Document doc)
            : base(doc)
        {
        }
    }
}