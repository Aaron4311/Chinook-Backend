﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook_Backend.Entities;

namespace Entity.Concrete
{
	public class Employee : IEntity
	{
		
		public int EmployeeId { get; set; }

		
		public string? LastName { get; set; }

		
		public string? FirstName { get; set; }

		public string? Title { get; set; }

		public int? ReportsTo { get; set; }

		public DateTime? BirthDate { get; set; }

		public DateTime? HireDate { get; set; }

		
		public string? Address { get; set; }

		
		public string? City { get; set; }

		
		public string? State { get; set; }

		public string? Country { get; set; }

		
		public string? PostalCode { get; set; }

		
		public string? Phone { get; set; }

		
		public string? Fax { get; set; }

		public string? Email { get; set; }

		public Employee? ReportsToManager { get; set; }
	}
}
