using System;
using SQLite.Net;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Heinzight.Core
{
	namespace Orm
	{
		// <summary>
		// Represents an association between a Display and
		// an Interest
		// </summary>
		public class DisplayInterest
		{
			[PrimaryKey, AutoIncrement]
			public int ID { get; set; }

			[ForeignKey(typeof(Display))]
			public int DisplayId { get; set; }

			[ForeignKey(typeof(Interest))]
			public int InterestId { get; set; }

			[ManyToOne]
			public Display Display { get; set; }

			[ManyToOne]
			public Interest Interest { get; set; }
		}
	}
}
