using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Interfaces;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private IEmployeeService _employeeService;
		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet]
		public IActionResult GetEmployees()
		{
			return Ok(_employeeService.GetEmployees());
		}
		[HttpGet]
		[Route("{id}")]
		public IActionResult GetEmployee(Guid id)
		{
			var emp = _employeeService.GetSingleEmployee(id);
			if(emp != null)
            {
				return Ok(emp);
            }
			return NotFound("User Not Found!");
		}
		[HttpPost]
		public IActionResult AddEmployee(Employee employee)
        {
			_employeeService.AddEmployee(employee);
			return Ok(employee);
        }
		[HttpDelete]
		[Route("{id}")]
		public IActionResult DeleteEmployee(Guid id)
        {
			var employee = _employeeService.GetSingleEmployee(id);
			if(employee != null)
            {
				_employeeService.DeleteEmployee(employee);
				return Ok("User deleted!");
            }
			return NotFound("Employee Not found!");
        }
		[HttpPatch]
		[Route("{id}")]
		public IActionResult EditEmployee(Guid id, Employee employee)
        {
			var emp = _employeeService.GetSingleEmployee(id);
			if (emp != null)
            {
				employee.Id = emp.Id;
				_employeeService.EditEmployee(employee);
            }
			return Ok(emp);

        }
	}
}
