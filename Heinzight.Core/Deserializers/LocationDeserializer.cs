using System;
using System.Collections.Generic;

using Heinzight.Core.ORM;

namespace Heinzight.Core
{
	namespace Deserializers
	{
		public class LocationDeserializer {
			public string Id { get; set; }
			public string Name { get; set; }
			public string LogoUrl { get; set; }
			public string BackgroundImageUrl { get; set; }
			public double Latitude { get; set; }
			public double Longitude { get; set; }

			public List<ExhibitDeserializer> Exhibits { get; set; }
			public List<DisplayDeserializer> Displays { get; set; }
			public List<InterestDeserializer> Interests { get; set; }

			public Location ToLocation()
			{
				return new Location {
					Name = Name,
					LogoUrl = LogoUrl,
					Latitude = (decimal)Latitude,
					Longitude = (decimal)Longitude
				};
			}
		}
	}
}

