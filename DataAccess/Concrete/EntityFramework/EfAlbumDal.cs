using Chinook_Backend.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfAlbumDal : EfEntityBaseRepository<Album,ChinookContext>,IAlbumDal
	{
		public List<AlbumDetailsDto> GetAlbumDetails()
		{
			using (ChinookContext context = new ChinookContext())
			{
				var query = from album in context.Album
							join artist in context.Artist on album.ArtistId equals artist.ArtistId
							select new AlbumDetailsDto
							{
								Title = album.Title,
								ArtistName = artist.Name
							};
				return query.ToList();
			}
		}
	}
}
