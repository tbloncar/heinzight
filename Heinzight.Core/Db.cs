using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

using SQLite.Net;
using SQLiteNetExtensions.Extensions;

using Heinzight.Core.ORM;

namespace Heinzight.Core
{
	public class Db
	{
		private static Db instance;

		private Db() {}

		public string FilePath = Path.Combine(Environment.GetFolderPath (Environment.SpecialFolder.Personal), "heinzight");

		public static Db Instance
		{
			get
			{
				if(instance == null) {
					instance = new Db ();
				}

				return instance;
			}
		}

		public SQLiteConnection GetConnection() {
			#if __IOS__
			return new SQLiteConnection (new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(), FilePath);
			#elif
			return new SQLiteConnection (new SQLite.Net.Platform.Xamarin
			#endif
		}

		public bool HasBeenCreated()
		{
			return File.Exists (FilePath);
		}

		public void Create() {
			if (HasBeenCreated ()) return;

			using (var conn = GetConnection ()) {
				conn.CreateTable<Location> ();
				conn.CreateTable<Exhibit> ();
				conn.CreateTable<Display> ();
				conn.CreateTable<Interest> ();
				conn.CreateTable<DisplayInterest> ();
			}
		}

		public void Delete()
		{
			File.Delete(FilePath);
		}

		public void Setup()
		{
			Delete ();
			Create ();
		}

		public void Seed() {
			var interests = new List<Interest> {
				new Interest { Name = "Historical Figures" },
				new Interest { Name = "Pop Culture" },
				new Interest { Name = "American Life" },
				new Interest { Name = "Music" },
				new Interest { Name = "Exploration" },
				new Interest { Name = "Inventions" },
				new Interest { Name = "Food" }
			};

			var displays = new List<Display> {
				new Display {
					Name = "Ferris Wheel",
					AdultContent = "<h1>Ferris Wheel</h1>",
					BeaconUUID = "11111111-2222-3333-4444-555555555555",
					BeaconMajorNum = 1,
					BeaconMinorNum = 1
				},
				new Display {
					Name = "Andrew Carnegie",
					AdultContent = "<h1>Andrew Carnegie</h1>",
					BeaconUUID = "11111111-2222-3333-4444-555555555555",
					BeaconMajorNum = 1,
					BeaconMinorNum = 2
				},
				new Display {
					Name = "Nickelodeon Movie Projector, 1905",
					AdultContent = "<h1>Nickelodeon Movie Projector, 1905</h1>",
					BeaconUUID = "11111111-2222-3333-4444-555555555555",
					BeaconMajorNum = 1,
					BeaconMinorNum = 3
				}
			};
				
			var location = new Location {
				Name = "Senator John Heinz History Center",
				Latitude = 40.4463499m,
				Longitude = -79.9925008m,
				Displays = displays,
				Interests = interests
			};

			var exhibit = new Exhibit {
				Name = "Pittsburgh: A Tradition of Innovation",
				Displays = displays
			};

			var displayInterests = new List<DisplayInterest> ();
			displayInterests.Add (new DisplayInterest { Interest = interests.ElementAt (0), Display = displays.ElementAt (1) });
			displayInterests.Add (new DisplayInterest { Interest = interests.ElementAt (1), Display = displays.ElementAt (2) });
			displayInterests.Add (new DisplayInterest { Interest = interests.ElementAt (2), Display = displays.ElementAt (0) });
			displayInterests.Add (new DisplayInterest { Interest = interests.ElementAt (5), Display = displays.ElementAt (0) });
			displayInterests.Add (new DisplayInterest { Interest = interests.ElementAt (5), Display = displays.ElementAt (1) });
					
			using (var conn = GetConnection ()) {
				conn.InsertWithChildren (location, recursive: true);
				conn.InsertAllWithChildren (displayInterests);
				conn.InsertWithChildren (exhibit, recursive: true);
			}
		}
	}
}

