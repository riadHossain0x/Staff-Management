using Staff.Infrustructure.DbContexts;
using Staff.Infrustructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrustructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeDbContext _dbContext;

        public EmployeeRepository(IEmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Employee Add(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            return employee;
        }

        public Employee Edit(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Get(Guid Id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(x => x.Id == Id);
            return employee;
        }

        public IList<Employee> GetAll()
        {
            return _dbContext.Employees.ToList();
        }

        public void Remove(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
