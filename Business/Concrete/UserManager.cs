using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Chinook_Backend.Aspects.Validation;
using Chinook_Backend.Entities.Concrete;
using Chinook_Backend.Utilities.Results;
using DataAccess.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		[ValidationAspect(typeof(UserValidator))]
		[SecuredOperation("admin")]
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
