using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Chinook_Backend.Entities;
namespace Entity.Concrete
{
	public class Track : IEntity
	{
		
		public int TrackId { get; set; }
		public string? Name { get; set; }
		public int?	AlbumId { get; set; }
		public int? MediaTypeId { get; set; }
		public int? GenreId { get; set; }
		public string? Composer { get; set; }
		public int? Milliseconds { get; set; }
		public int? Bytes { get; set; }
		public decimal? UnitPrice { get; set; }
		public Album? Album { get; set; }
		public MediaType? MediaType { get; set; }
		public Genre? Genre { get; set; }
	}
}
