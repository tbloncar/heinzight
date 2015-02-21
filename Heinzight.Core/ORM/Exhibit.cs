using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Heinzight.Core
{
	namespace Orm
	{
		// <summary>
		// Represents an exhibit (e.g., "WWII Stamp Collection")
		// </summary>
		public class Exhibit
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

			[OneToMany(CascadeOperations = CascadeOperation.All)]
			public List<Interest> Exhibits { get; set; }

			[ManyToMany(typeof(ExhibitInterest))]
			public List<Interest> Interests { get; set; }
		}
	}
}