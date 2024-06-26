﻿using System.Security.Claims;

namespace Chinook_Backend.Extensions
{
	public static class ClaimsPrincipalExtension
	{
		public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
		{
			var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
			return result;
		}

		public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
		{
			return claimsPrincipal?.Claims(ClaimTypes.Role);
		}
	}
}
