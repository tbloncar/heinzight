using System;
using System.Linq;
using System.Collections.Generic;
using System.Device.Location;

using Heinzight.Core.ORM;

namespace Heinzight.Core
{
	namespace DAO
	{
		public class DisplayDAO
		{
			public static List<Display> GetDisplaysForInterests(List<Interest> interests)
			{
				List<int> interestIds = interests.Select (i => i.ID).ToList();
				var displays = new List<Display> ();

				using (var conn = Db.Instance.GetConnection ()) {
					displays = (List<Display>)conn.Table<DisplayInterest> ()
						.Where (di => interestIds.Contains (di.InterestId))
						.Select(di => di.Display).Distinct().ToList();
				}

				return displays;
			}
		}
	}
}

