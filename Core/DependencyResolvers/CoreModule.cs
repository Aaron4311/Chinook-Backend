using Chinook_Backend.CrossCuttingConcerns.Caching;
using Chinook_Backend.CrossCuttingConcerns.Caching.Microsoft;
using Chinook_Backend.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.DependencyResolvers
{
	public class CoreModule : ICoreModule
	{
		public void Load(IServiceCollection collection)
		{
			collection.AddMemoryCache();
			collection.AddSingleton<ICacheManager, MemoryCacheManager>();
			collection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			collection.AddSingleton<Stopwatch>();
		}
	}
}
