using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Heinzight.Core
{
	namespace Orm
	{
		// <summary>
		// Represents an association between an Exhibit and
		// an Interest
		// </summary>
		public class ExhibitInterest
		{
			[PrimaryKey, AutoIncrement]
			public int ID { get; set; }

			[ForeignKey(typeof(Exhibit))]
			public int ExhibitId { get; set; }

			[ForeignKey(typeof(Interest))]
			public int InterestId { get; set; }

			[ManyToOne]
			public Exhibit Exhibit { get; set; }

			[ManyToOne]
			public Interest Interest { get; set; }
		}
	}
}
