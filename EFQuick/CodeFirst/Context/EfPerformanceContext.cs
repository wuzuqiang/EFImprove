using CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Context
{
    public class EfPerformanceContext:DbContext
    {
        public EfPerformanceContext()
            :base("name=CodeFirstApp")
        { }
        public DbSet<Product> Products { get; set; }
    }
}
