﻿using Chinook_Backend.Entities.Concrete;
using Chinook_Backend.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IUserService
	{
		List<OperationClaim> GetClaims(User user);
		IResult Add(User user);
		IDataResult<User> GetByMail(string mail);

	}
}
