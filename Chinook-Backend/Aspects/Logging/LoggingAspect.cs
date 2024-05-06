using Castle.DynamicProxy;
using Chinook_Backend.CrossCuttingConcerns.Logging.Log4Net;
using Chinook_Backend.CrossCuttingConcerns.Logging;
using Chinook_Backend.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook_Backend.Utilities.Interceptors;

namespace Chinook_Backend.Aspects.Logging
{
	public class LoggingAspect : MethodInterception
	{
		private LoggerServiceBase _logger;

		public LoggingAspect(Type logger)
		{
			if (logger.BaseType != typeof(LoggerServiceBase))
			{
				throw new System.Exception(AspectMessages.WrongLogger);
			}
			_logger = (LoggerServiceBase)Activator.CreateInstance(logger);
		}
		public override void OnBefore(IInvocation invocation)
		{
			_logger.Info(GetLogDetail(invocation));
		}

		private LogDetail GetLogDetail(IInvocation invocation)
		{
			var logParameters = new List<LogParameter>();
			for (int i = 0; i < invocation.Arguments.Length; i++)
			{
				logParameters.Add(new LogParameter
				{
					Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
					Value = invocation.Arguments[i],
					Type = invocation.Arguments[i].GetType().Name
				});
			}

			var logDetail = new LogDetail
			{
				MethodName = invocation.Method.Name,
				LogParameters = logParameters
			};

			return logDetail;
		}
	}
}
