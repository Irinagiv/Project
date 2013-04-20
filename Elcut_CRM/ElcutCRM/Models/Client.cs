using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElcutCRM.Models
{
    [Table("Clients")]
    public class Client
    {
        //        [Key]
        //        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
    }

    public class ClientDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ClientDbContext() : base("DefaultConnection") { }
    }
}