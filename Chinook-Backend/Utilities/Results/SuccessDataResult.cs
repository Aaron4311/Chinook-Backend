using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.Utilities.Results
{
	public class SuccessDataResult<T> : DataResult<T>
	{
		public SuccessDataResult(T data) : base(data, true)
		{
		}

		public SuccessDataResult(T data, string message) : base(data, true, message)
		{
		}
		public SuccessDataResult() : base(default, true)
		{
		}

		public SuccessDataResult(string message) : base(default, true, message)
		{

		}

		public SuccessDataResult(T data, bool success) : base(data, success)
		{
		}

		public SuccessDataResult(T data, bool success, string message) : base(data, success, message)
		{
		}
	}
}
