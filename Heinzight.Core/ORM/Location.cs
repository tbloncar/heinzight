﻿using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Heinzight.Core
{
	namespace Orm
	{
		// <summary>
		// Represents a location (e.g. the museum)
		// </summary>
		public class Location
		{
			[PrimaryKey, AutoIncrement]
			public int ID { get; set; }
			public string Name { get; set; }
			public string FeaturedImagePath { get; set; }
			public decimal Latitude { get; set; }
			public decimal Longitude { get; set; }

			[OneToMany(CascadeOperations = CascadeOperation.All)]
			public List<Exhibit> Exhibits { get; set; }
		}
	}
}