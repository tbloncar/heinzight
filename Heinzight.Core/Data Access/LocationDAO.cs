using System;
using System.Linq;
using System.Collections.Generic;
using System.Device.Location;

using Heinzight.Core.ORM;

namespace Heinzight.Core
{
	namespace DAO
	{
		public class LocationDAO
		{
			public static List<Location> GetLocationsByCoordinates(GeoCoordinate coordinates) {
				const double metersInMile = 1609.34;

				var locations = new List<Location> ();
				var filteredLocations = new List<Location> ();

				using(var conn = Db.Instance.GetConnection()) {
					locations.AddRange(conn.Table<Location>().ToList());
				}

				foreach (var location in locations) {
					GeoCoordinate gc = new GeoCoordinate { Latitude = (double)location.Latitude, Longitude = (double)location.Longitude };

					if (gc.GetDistanceTo (coordinates) / metersInMile < 10)
					{
						filteredLocations.Add (location);
					}
				}

				return filteredLocations;
			}
		}
	}
}

