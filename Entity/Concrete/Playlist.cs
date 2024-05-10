using Chinook_Backend.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Entity.Concrete
{
	
	public class Playlist : IEntity
	{
		
		public int PlaylistId { get; set; }

		
		public string? Name { get; set; }
	}
}
