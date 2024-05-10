using Chinook_Backend.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Chinook_Backend.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddDependencyResolvers(
			this IServiceCollection services, ICoreModule[] modules)
		{
			foreach (var module in modules)
			{
				module.Load(services);
			}
			return ServiceTool.Create(services);
		}
	}
}
