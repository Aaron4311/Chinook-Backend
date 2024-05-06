using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.Utilities.IoC
{
	public interface ICoreModule
	{
		void Load(IServiceCollection collection);
	}
}
