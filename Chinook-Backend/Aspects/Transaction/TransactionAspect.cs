using Castle.DynamicProxy;
using Chinook_Backend.Utilities.Interceptors;
using System.Transactions;

namespace Chinook_Backend.Aspects.Transaction
{
	public class TransactionAspect : MethodInterception
	{
		public override void Intercept(IInvocation invocation)
		{
			using (TransactionScope transactionScope = new TransactionScope())
			{
				try
				{
					invocation.Proceed();
				}
				catch (System.Exception)
				{

					transactionScope.Dispose();
					throw;
				}
			}
		}
	}
}
