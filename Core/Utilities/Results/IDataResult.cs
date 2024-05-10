using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.Utilities.Results
{
	public interface IDataResult<T> : IResult
	{
		T Data { get; }
	}
}
