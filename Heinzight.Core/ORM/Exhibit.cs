using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Extensions;
using SQLiteNetExtensions.Attributes;

namespace Heinzight.Core
{
	namespace ORM
	{
		// <summary>
		// Represents an exhibit (e.g. "Mr. Rogers' Neighborhood")
		// </summary>
		public class Exhibit
		{
			[PrimaryKey, AutoIncrement]
			public int ID { get; set; }
			public string Name { get; set; }
			public string FeaturedImagePath { get; set; }

			[ForeignKey(typeof(Location))]
			public int LocationId { get; set; }

			[ManyToOne]
			public Location Location { get; set; }

			[OneToMany(CascadeOperations = CascadeOperation.All)]
			public List<Display> Displays { get; set; }
		}
	}
}