using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Heinzight.Core
{
	namespace Orm
	{
		// <summary>
		// Represents a display (e.g., "Ferris Wheel")
		// </summary>
		public class Display
		{
			[PrimaryKey, AutoIncrement]
			public int ID { get; set; }
			public string Name { get; set; }
			public string FeaturedImagePath { get; set; }
			public string ChildContent { get; set; }
			public string AdultContent { get; set; }

			[Indexed]
			public string BeaconUUID { get; set; }

			[Indexed]
			public int BeaconMajorNum { get; set; }

			[Indexed]
			public int BeaconMinorNum { get; set; }

			[ForeignKey(typeof(Location))]
			public int LocationId { get; set; }

			[ManyToOne]
			public Location Location { get; set; }

			[ForeignKey(typeof(Exhibit))]
			public int ExhibitId { get; set; }

			[ManyToOne]
			public Exhibit Exhibit { get; set; }

			[ManyToMany(typeof(ExhibitInterest))]
			public List<Interest> Interests { get; set; }
		}
	}
}