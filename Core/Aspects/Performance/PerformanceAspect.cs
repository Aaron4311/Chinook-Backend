using Castle.DynamicProxy;
using Chinook_Backend.Utilities.Interceptors;
using Chinook_Backend.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Chinook_Backend.Aspects.Performance
{
	public class PerformanceAspect : MethodInterception
	{
		private int _interval;
		private Stopwatch _stopWatch;
		public PerformanceAspect(int interval)
		{
			_interval = interval;
			_stopWatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();

		}
		public override void OnBefore(IInvocation invocation)
		{
			_stopWatch.Start();
		}
		public override void OnAfter(IInvocation invocation)
		{
			if (_stopWatch.Elapsed.TotalSeconds > _interval)
			{
				Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} --> {_stopWatch.Elapsed.TotalSeconds}");

			}
			_stopWatch.Reset();

		}

	}
}
