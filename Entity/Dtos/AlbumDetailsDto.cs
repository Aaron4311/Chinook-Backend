using Chinook_Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
	public class AlbumDetailsDto : IDto
	{

		public string Title { get; set; }
	
		public string ArtistName { get; set; }
	}
}
