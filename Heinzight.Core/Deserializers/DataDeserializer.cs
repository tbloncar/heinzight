using System;
using System.Collections.Generic;

namespace Heinzight.Core
{
	namespace Deserializers
	{
		public class DataDeserializer
		{
			public List<LocationDeserializer> Locations { get; set; }
			public List<DisplayInterestDeserializer> DisplayInterests { get; set; }
		}
	}
}