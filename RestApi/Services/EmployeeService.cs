using RestApi.Db_Context;
using RestApi.Interfaces;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly EmployeeContext _employeeContext;
		public EmployeeService(EmployeeContext employeeContext)
		{
			_employeeContext = employeeContext;
		}
		public Employee AddEmployee(Employee employee)
		{
			employee.Id = Guid.NewGuid();
			_employeeContext.Employees.Add(employee);
			_employeeContext.SaveChanges();
			return employee;
		}

		public void DeleteEmployee(Employee employee)
		{
			_employeeContext.Employees.Remove(employee);
			_employeeContext.SaveChanges();
		}

		public Employee EditEmployee(Employee employee)
		{
			var existingEmp = _employeeContext.Employees.FirstOrDefault(x => x.Id == employee.Id);
			if (existingEmp != null)
			{
				_employeeContext.Employees.Update(employee);
				_employeeContext.SaveChanges();
			}
			return employee;
		}
		public List<Employee> GetEmployees()
		{
			return _employeeContext.Employees.ToList();
		}

		public Employee GetSingleEmployee(Guid id)
		{
			var singleEmp = _employeeContext.Employees.FirstOrDefault(x => x.Id == id);
			return singleEmp;
		}
	}
}
