using Microsoft.EntityFrameworkCore;
using Staff.Infrustructure.DbContexts;
using Staff.Infrustructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrustructure.UnitOfWorks
{
    public class EmployeeUnitOfWork : UnitOfWork, IEmployeeUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; private set; }
        public EmployeeUnitOfWork(IEmployeeDbContext dbContext,
            IEmployeeRepository employeeRepository) : base((DbContext)dbContext)
        {
            EmployeeRepository = employeeRepository;
        }

    }
}
