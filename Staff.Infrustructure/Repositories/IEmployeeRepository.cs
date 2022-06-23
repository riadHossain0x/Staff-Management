using Staff.Infrustructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrustructure.Repositories
{
    public interface IEmployeeRepository
    {
        Employee Add(Employee employee);
        void Remove(Employee employee);
        void Remove(Guid Id);
        Employee Edit(Employee employee);
        Employee Get(Guid Id);
        IList<Employee> GetAll();
    }
}
