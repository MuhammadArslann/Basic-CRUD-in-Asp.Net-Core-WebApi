using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Interfaces
{
	public interface IEmployeeService
	{
		List<Employee> GetEmployees();

		Employee GetSingleEmployee(Guid id);

		Employee EditEmployee(Employee employee);

		Employee AddEmployee(Employee employee);

		void DeleteEmployee(Employee employee);

	}
}
