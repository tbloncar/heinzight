using System;

using Heinzight.Core.ORM;

namespace Heinzight.Core
{
	namespace Deserializers
	{
		public class InterestDeserializer
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string ImageUrl { get; set; }

			public Interest ToInterest()
			{
				return new Interest {
					Name = Name,
					ImageUrl = ImageUrl
				};
			}
		}
	}
}