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
		// Represents an interest (e.g. "political figures")
		// </summary>
		public class Interest
		{
			[PrimaryKey, AutoIncrement]
			public int ID { get; set; }
			public string Name { get; set; }
			public string FeaturedImagePath { get; set; }

			[ForeignKey(typeof(Location))]
			public int LocationId { get; set; }

			[ManyToOne]
			public Location Location { get; set; }

			[ManyToMany(typeof(DisplayInterest))]
			public List<Display> Displays { get; set; }
		}
	}
}