using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Videos.Models
{
    public class videoDB : DbContext
    {
        public DbSet<videos> videos{ get; set; }
    }
}