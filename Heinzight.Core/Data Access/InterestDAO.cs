using System;
using System.Linq;
using System.Collections.Generic;
using System.Device.Location;

using Heinzight.Core.ORM;

namespace Heinzight.Core
{
	namespace DAO
	{
		public class InterestDAO
		{
			public static List<Interest> GetInterestsForLocation(Location location)
			{
				var interests = new List<Interest> ();

				using (var conn = Db.Instance.GetConnection ()) {
					interests.AddRange(conn.Table<Interest> ().Where (i => i.LocationId == location.ID).ToList ());
				}

				return interests;
			}
		}
	}
}