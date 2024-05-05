using Chinook_Backend.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Entity.Concrete
{

	public class InvoiceLine : IEntity
	{
		
		public int InvoiceLineId { get; set; }

		
		public int CustomerId { get; set; }

		
		public int TrackId { get; set; }

		
		public decimal UnitPrice { get; set; }

		
		public int Quantity { get; set; }

		
		public Customer Customer { get; set; }
		public Track Track { get; set; }
	}
}
