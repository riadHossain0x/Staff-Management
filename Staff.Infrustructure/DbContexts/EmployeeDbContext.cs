using Microsoft.EntityFrameworkCore;
using Staff.Infrustructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrustructure.DbContexts
{
    public class EmployeeDbContext : DbContext, IEmployeeDbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> contextOptions) :
            base(contextOptions)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        public void Save()
        {
            SaveChanges();
        }
    }
}
