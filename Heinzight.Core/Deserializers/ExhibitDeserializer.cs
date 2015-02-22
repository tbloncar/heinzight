using System;

using Heinzight.Core.ORM;

namespace Heinzight.Core
{
	namespace Deserializers
	{
		public class ExhibitDeserializer
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string ImageUrl { get; set; }

			public Exhibit ToExhibit()
			{
				return new Exhibit {
					Name = Name,
					ImageUrl = ImageUrl
				};
			}
		}
	}
}