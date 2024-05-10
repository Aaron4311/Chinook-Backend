using Chinook_Backend.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Entity.Concrete
{

	public class Genre : IEntity
	{
		
		public int GenreId { get; set; }

		
		public string? Name { get; set; }
	}
}
