using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_Backend.CrossCuttingConcerns.Logging.Log4Net
{
	[Serializable]
	public class SerializableLogEvents
	{
		private LoggingEvent _loggingEvent;

		public SerializableLogEvents(LoggingEvent loggingEvent)
		{
			_loggingEvent = loggingEvent;
		}
		public object Message => _loggingEvent.MessageObject;
	}
}
