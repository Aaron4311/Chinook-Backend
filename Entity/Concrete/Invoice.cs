using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook_Backend.Entities;

namespace Entity.Concrete
{
	public class Invoice : IEntity
	{
		
		public int InvoiceId { get; set; }

	
		public int CustomerId { get; set; }

	
		public DateTime? InvoiceDate { get; set; }

		
		public string? BillingAddress { get; set; }

		
		public string? BillingCity { get; set; }

		
		public string? BillingState { get; set; }

		public string? BillingCountry { get; set; }

		
		public string? BillingPostalCode { get; set; }

		
		public Decimal? Total { get; set; }

		public Customer? Customer { get; set; }
	}
}
