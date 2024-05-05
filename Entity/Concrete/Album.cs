using Chinook_Backend.Entities;

namespace Entity.Concrete
{

	public class Album : IEntity
	{
		
		public int AlbumId { get; set; }

		public string Title { get; set; }

		public int ArtistId { get; set; }

		public Artist Artist { get; set; }
	}
}