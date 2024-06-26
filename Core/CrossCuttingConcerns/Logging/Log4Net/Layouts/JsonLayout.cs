﻿using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
	internal class JsonLayout : LayoutSkeleton
	{
		public override void ActivateOptions()
		{
			
		}

		public override void Format(TextWriter writer, LoggingEvent loggingEvent)
		{
			var logEvent = new SerializableLogEvents(loggingEvent);
			var json = JsonConvert.SerializeObject(logEvent,Formatting.Indented);
			writer.WriteLine(json);


		}
	}
}
