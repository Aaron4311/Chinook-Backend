﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.Utilities.IoC
{
	public class ServiceTool
	{
        public static IServiceProvider ServiceProvider { get; set; }
		public static IServiceCollection Create(IServiceCollection services)
		{
			ServiceProvider = services.BuildServiceProvider();
			return services;
		}
    }
}
