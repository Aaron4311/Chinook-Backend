using Business.Constants;
using Castle.DynamicProxy;
using Chinook_Backend.Extensions;
using Chinook_Backend.Utilities.Interceptors;
using Chinook_Backend.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
	public class SecuredOperation : MethodInterception
	{
		private string[] _roles;
		private IHttpContextAccessor _httpContextAccessor;

		public SecuredOperation(string roles)
		{
			_roles = roles.Split(',');
			_httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
		}
		public override void OnBefore(IInvocation invocation)
		{
			var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
			foreach (var role in _roles)
			{
				if (roleClaims.Contains(role))
				{
					return;
				}

			}
			throw new Exception(Messages.authorizationDenied);
		}
	}
}
