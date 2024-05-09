using Business.Constants;
using Chinook_Backend.Aspects.Validation;
using Chinook_Backend.Entities.Concrete;
using Chinook_Backend.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class UserManager
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		
		public IResult Add(User user)
		{
			_userDal.Add(user);
			return new SuccessResult(Messages.UserAdded);
		}

		public IDataResult<User> GetByMail(string mail)
		{
			return new SuccessDataResult<User>(_userDal.Get(x => x.Email == mail));
		}

		public List<OperationClaim> GetClaims(User user)
		{
			return _userDal.GetClaims(user);
		}
	}
}
