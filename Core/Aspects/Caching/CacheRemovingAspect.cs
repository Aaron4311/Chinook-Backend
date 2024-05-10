using Castle.DynamicProxy;
using Chinook_Backend.CrossCuttingConcerns.Caching;
using Chinook_Backend.Utilities.Interceptors;
using Chinook_Backend.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.Aspects.Caching
{
	public class CacheRemovingAspect : MethodInterception
	{
		private string _pattern;
		private ICacheManager _cacheManager;

		public CacheRemovingAspect(string pattern)
		{
			_pattern = pattern;
			_cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();

		}

		public override void OnSuccess(IInvocation invocation)
		{
			_cacheManager.RemoveByPattern(_pattern);
		}

	}
}
