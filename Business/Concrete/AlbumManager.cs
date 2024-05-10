using Business.Abstract;
using Chinook_Backend.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class AlbumManager : IAlbumService
	{
		private IAlbumDal _albumDal;

		public AlbumManager(IAlbumDal albumDal)
		{
			_albumDal = albumDal;
		}

		public IResult Add(Album album)
		{
			_albumDal.Add(album);
			return new SuccessResult();
		}

		public IResult Delete(int id)
		{
			var deletedAlbum = _albumDal.Get(x => x.AlbumId == id);
			_albumDal.Delete(deletedAlbum);
			return new SuccessResult();
		}

		public IDataResult<Album> Get(int id)
		{
			return new SuccessDataResult<Album>(_albumDal.Get(x => x.AlbumId == id));
		}

		public IDataResult<List<Album>> GetAll()
		{
			return new SuccessDataResult<List<Album>>(_albumDal.GetAll());

		}

		public IResult Update(Album album)
		{
			_albumDal.Update(album);
			return new SuccessResult();
		}
	}
}
