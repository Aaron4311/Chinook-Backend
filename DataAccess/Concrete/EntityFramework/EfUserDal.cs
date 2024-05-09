﻿using Chinook_Backend.DataAccess.EntityFramework;
using Chinook_Backend.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfUserDal : EfEntityBaseRepository<User, ChinookContext>, IUserDal
	{
		public List<OperationClaim> GetClaims(User user)
		{
			using (var context = new ChinookContext())
			{
				var result = from operationClaim in context.OperationClaims
							 join userOperationClaim in context.UserOperationClaims on operationClaim.Id equals userOperationClaim.OperationClaimId
							 where userOperationClaim.UserId == user.Id
							 select new OperationClaim
							 {
								 Id = operationClaim.Id,
								 Name = operationClaim.Name,
							 };
				return result.ToList();
			}
		}
	}
}
