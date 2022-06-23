using Microsoft.EntityFrameworkCore;
using Staff.Infrustructure.Entities;

namespace Staff.Infrustructure.DbContexts
{
    public interface IEmployeeDbContext
    {
        DbSet<Employee> Employees { get; set; }
        //void Save();
    }
}