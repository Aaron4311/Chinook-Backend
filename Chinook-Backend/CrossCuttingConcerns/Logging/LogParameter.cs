﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.CrossCuttingConcerns.Logging
{
	public class LogParameter
	{
		public string Name { get; set; }
		public object Value { get; set; }
		public string Type { get; set; }
	}
}
