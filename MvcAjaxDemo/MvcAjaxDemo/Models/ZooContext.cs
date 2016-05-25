using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcAjaxDemo.Models
{
    public class ZooContext:DbContext
    {
        public ZooContext() : base("MvcAjaxDemo") { }

        public DbSet<Djur> Djur { get; set; }

    }
}