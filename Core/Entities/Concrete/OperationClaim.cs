﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.Entities.Concrete
{
	public class OperationClaim : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
