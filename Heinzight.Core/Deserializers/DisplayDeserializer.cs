using System;

using Heinzight.Core.ORM;

namespace Heinzight.Core
{
	namespace Deserializers
	{
		public class DisplayDeserializer
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string ImageUrl { get; set; }
			public string ChildContentHTML { get; set; }
			public string AdultContentHTML { get; set; }
			public string BeaconUUID { get; set; }
			public int BeaconMajorNum { get; set; }
			public int BeaconMinorNum { get; set; }
			public int ExhibitId { get; set; }

			public Display ToDisplay()
			{
				return new Display {
					Name = Name,
					ImageUrl = ImageUrl,
					ChildContentHTML = ChildContentHTML,
					AdultContentHTML = AdultContentHTML,
					BeaconUUID = BeaconUUID,
					BeaconMajorNum = BeaconMajorNum,
					BeaconMinorNum = BeaconMinorNum
				};
			}
		}
	}
}

