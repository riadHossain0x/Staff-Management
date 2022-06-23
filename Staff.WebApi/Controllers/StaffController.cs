using Microsoft.AspNetCore.Mvc;
using Staff.Infrustructure.Entities;
using Staff.Infrustructure.UnitOfWorks;

namespace Staff.WebApi.Controllers
{
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IEmployeeUnitOfWork _employeeUnitOfWork;

        public StaffController(IEmployeeUnitOfWork employeeUnitOfWork)
        {
            _employeeUnitOfWork = employeeUnitOfWork;
        }

        [HttpGet]
        [Route("api/[controller]/")]
        public IActionResult GetAll()
        {
            return Ok(_employeeUnitOfWork.EmployeeRepository.GetAll());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetById(Guid id)
        {
            var employee = _employeeUnitOfWork.EmployeeRepository.Get(id);   
            
            if(employee != null)
                return Ok(employee);

            return NotFound();
        }

        [HttpPost]
        [Route("api/[controller]/")]
        public IActionResult Add(Employee employee)
        {
            _employeeUnitOfWork.EmployeeRepository.Add(employee);
            _employeeUnitOfWork.Save();

            return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}{employee.Id}",
                employee);
        }

        [HttpDelete]
        [Route("api/[controller]/")]
        public IActionResult Delete(Employee employee)
        {
            _employeeUnitOfWork.EmployeeRepository.Remove(employee);

            return Ok();
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult Delete(Guid id)
        {
            var employee = _employeeUnitOfWork.EmployeeRepository.Get(id);
            if (employee != null)
                _employeeUnitOfWork.EmployeeRepository.Remove(employee);

            return Ok();
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult Edit(Guid id, Employee employee)
        {
            var existEmployee = _employeeUnitOfWork.EmployeeRepository.Get(id);
            if (existEmployee != null)
            {
                employee.Id = existEmployee.Id;
                _employeeUnitOfWork.EmployeeRepository.Edit(employee);
                return Ok();
            }
            return NotFound($"Employee with id: {id} not found");
        }
    }
}
