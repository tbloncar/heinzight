using System;
using System.Linq;
using System.Collections.Generic;

using Heinzight.Core.ORM;

namespace Heinzight.Core
{
	namespace DAO
	{
		public class LocationDAO
		{
			public static List<Location> GetLocations() {
				using(var conn = Db.Instance.GetConnection()) {
					return conn.Table<Location>().ToList();
				}
			}
		}
	}
}

