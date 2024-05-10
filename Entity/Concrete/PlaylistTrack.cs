using Chinook_Backend.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Entity.Concrete 
{

	public class PlaylistTrack : IEntity
	{
		
		public int PlaylistId { get; set; }

		
		public int? TrackId { get; set; }

		public Playlist? Playlist { get; set; }

		
		public Track? Track { get; set; }
	}
}
