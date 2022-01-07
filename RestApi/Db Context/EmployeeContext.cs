using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Db_Context
{
	public class EmployeeContext: DbContext
	{
		public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options)
		{

		}
		public DbSet<Employee> Employees { get; set; }
		
	
	
	}
}
