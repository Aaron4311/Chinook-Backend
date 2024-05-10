using Business.Abstract;
using Business.Constants;
using Chinook_Backend.Aspects.Validation;
using Chinook_Backend.Entities.Concrete;
using Chinook_Backend.Utilities.Results;
using Chinook_Backend.Utilities.Security.Hashing;
using Chinook_Backend.Utilities.Security.JWT;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class AuthManager : IAuthService
	{
		private IUserService _userService;
		private ITokenHelper _tokenHelper;

		public AuthManager(IUserService userService, ITokenHelper tokenHelper)
		{
			_userService = userService;
			_tokenHelper = tokenHelper;
		}

		public IDataResult<AccessToken> CreateAccessToken(User user)
		{
			var claims = _userService.GetClaims(user);
			var accessToken = _tokenHelper.CreateToken(user, claims);
			return new SuccessDataResult<AccessToken>(accessToken, Messages.accessTokenCreated);
		}

		[ValidationAspect(typeof(UserForLoginDtoValidator))]
		public IDataResult<User> Login(UserForLoginDto userForLoginDto)
		{
			var userToCheck = _userService.GetByMail(userForLoginDto.Email);
			if (userToCheck.Data == null)
			{
				return new ErrorDataResult<User>(Messages.userNotFound);
			}

			if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
			{
				return new ErrorDataResult<User>(Messages.userNotFound);
			}
			return new SuccessDataResult<User>(userToCheck.Data, Messages.loginSuccessful);
		}


		[ValidationAspect(typeof(UserForRegisterDtoValidator))]
		public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
		{
			byte[] passwordHash, passwordSalt;
			HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
			var user = new User
			{
				Email = userForRegisterDto.Email,
				FirstName = userForRegisterDto.FirstName,
				LastName = userForRegisterDto.LastName,
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt,
				Status = true
			};
			_userService.Add(user);
			return new SuccessDataResult<User>(user, Messages.UserRegistered);
		}

		public IResult UserExists(string email)
		{
			if (_userService.GetByMail(email).Data != null)
			{
				return new ErrorResult(Messages.UserExists);
			}
			return new SuccessResult();
		}
	}
}
