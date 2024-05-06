using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.Utilities.Interceptors
{
	public class MethodInterception : MethodInterceptionBaseAttribute
	{
		public void OnBefore(IInvocation invocation) { }
		public void OnAfter(IInvocation invocation) { }
		public void OnSuccess(IInvocation invocation) { }
		public void OnException(IInvocation invocation,Exception e) { }
		public override void Intercept(IInvocation invocation)
		{
			var isSuccess = true;
			OnBefore(invocation);
			try
			{
				invocation.Proceed();
			}
			catch (Exception e)
			{
				isSuccess = false;
				OnException(invocation, e);
				throw;
			}
			finally
			{
				if (isSuccess)
				{
					OnSuccess(invocation);
				}
			}
			OnAfter(invocation);
		}

	}
}
