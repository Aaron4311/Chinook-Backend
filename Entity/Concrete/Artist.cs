using Chinook_Backend.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Entity.Concrete
{

	public class Artist : IEntity
	{
		
		public int ArtistId { get; set; }

		public string Name { get; set; }
		
		public List<Album> Albums { get; set; }
		
	}
}
