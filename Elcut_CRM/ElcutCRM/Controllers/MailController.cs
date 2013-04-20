using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActionMailer.Net;
using ActionMailer.Net.Mvc;
using ElcutCRM.Models;
using ElcutCRM.Data.Models;

namespace ElcutCRM.Controllers
{
    public class MailController : MailerBase
    {
        public EmailResult DocumentEmail(Document doc)
        {
            foreach (var contact in doc.Organization.ContactNames)
            {

                To.Add(contact.Email);
            }
            From = "no-reply@elcut.ru";
            BaseMailModel model = null;
            switch (doc.DocumentTypeKey)
            {
                case Document.INVOICE_TYPE_KEY:
                    model = new InvoiceMailModel(doc);
                    break;
                case Document.CONTRACT_TYPE_KEY:
                    model = new ContractMailModel(doc);
                    break;
                case Document.ACT_TYPE_KEY:
                    model = new ActMailModel(doc);
                    break;
            }
            Subject = model.Subject;
            return Email(model.ViewName, model);
        }

    }
}
