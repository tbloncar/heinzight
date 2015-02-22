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
		// Represents the data sync status for the device
		// </summary>
		public class DataSyncStatus
		{
			[PrimaryKey, AutoIncrement]
			public int ID { get; set; }
			public int Version { get; set; }
		}
	}
}