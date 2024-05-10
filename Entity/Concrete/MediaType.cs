using Chinook_Backend.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Entity.Concrete
{
	
	public class MediaType : IEntity
	{
		public int MediaTypeId { get; set; }

		
		public string? Name { get; set; }
	}
}
