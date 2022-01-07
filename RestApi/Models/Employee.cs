using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
	public class Employee
	{
		[Key]
		public Guid Id { get; set; }
		[Required(ErrorMessage ="Username required!")]
		public string Name { get; set; }
	}
}
