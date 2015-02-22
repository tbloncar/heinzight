using System;
using System.Collections.Generic;

namespace Heinzight.Core
{
	namespace Deserializers
	{
		public class DataSyncDeserializer
		{
			public DataDeserializer Data { get; set; }
			public int Version { get; set; }
			public string Message { get; set; }
		}
	}
}

