using Chinook_Backend.DataAccess;
using Chinook_Backend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IUserDal : IEntityRepository<User>
	{
		public List<OperationClaim> GetClaims(User user);

	}
}
