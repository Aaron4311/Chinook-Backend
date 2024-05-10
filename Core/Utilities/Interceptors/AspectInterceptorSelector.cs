using Castle.DynamicProxy;
using Chinook_Backend.Aspects.Exception;
using Chinook_Backend.Aspects.Logging;
using Chinook_Backend.Aspects.Performance;
using Chinook_Backend.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.Utilities.Interceptors
{
	public class AspectInterceptorSelector : IInterceptorSelector
	{
		public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
		{
			var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
			var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
			classAttributes.AddRange(methodAttributes);
			classAttributes.Add(new PerformanceAspect(3));
			classAttributes.Add(new ExceptionAspect(typeof(FileLogger)));
			classAttributes.Add(new LoggingAspect(typeof(FileLogger)));

			return classAttributes.OrderBy(x => x.Priority).ToArray();
		}
	}
}
