using Castle.DynamicProxy;
using Chinook_Backend.CrossCuttingConcerns.Logging.Log4Net;
using Chinook_Backend.CrossCuttingConcerns.Logging;
using Chinook_Backend.Utilities.Messages;
using System;
using Chinook_Backend.Utilities.Interceptors;

namespace Chinook_Backend.Aspects.Exception
{
	public class ExceptionAspect : MethodInterception
	{
		private LoggerServiceBase _loggerServiceBase;

		public ExceptionAspect(Type loggerService)
		{
			if (loggerService.BaseType != typeof(LoggerServiceBase))
			{
				throw new System.Exception(AspectMessages.WrongLoggerType);
			}
			_loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
		}
		public override void OnException(IInvocation invocation, System.Exception e)
		{
			LogDetailWithException logDetailWithException = GetLogDetail(invocation);
			logDetailWithException.ExceptionMessage = e.Message;
			_loggerServiceBase.Error(logDetailWithException);
		}

		private LogDetailWithException GetLogDetail(IInvocation invocation)
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
			var logDetailWithException = new LogDetailWithException
			{
				MethodName = invocation.Method.Name,
				LogParameters = logParameters
			};
			return logDetailWithException;
		}
	}
}
