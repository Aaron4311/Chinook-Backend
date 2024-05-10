using Chinook_Backend.DataAccess;
using Chinook_Backend.Entities.Concrete;

namespace DataAccess.Abstract
{
	public interface IUserDal : IEntityRepository<User>
	{
		public List<OperationClaim> GetClaims(User user);

	}
}
