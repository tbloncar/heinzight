using System;
using System.IO;
using System.Collections.Generic;
using SQLite;
using Heinzight.Core.Orm;

namespace Heinzight.Core
{
	public class Db
	{
		private static Db instance;

		private Db() {}

		public string FilePath = Path.Combine(Environment.GetFolderPath (Environment.SpecialFolder.Personal), "heinzight");

		public static Db GetInstance
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
			return new SQLiteConnection (FilePath);
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

		public void Seed() {
			var interests = new List<Interest> {
				new Interest { Name = "Amusement Parks" },
				new Interest { Name = "Animals" },
				new Interest { Name = "Colonial Housing" }
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
					Name = "Elektro and Sparko",
					AdultContent = "<h1>Elektro and Sparko</h1>",
					BeaconUUID = "11111111-2222-3333-4444-555555555555",
					BeaconMajorNum = 1,
					BeaconMinorNum = 2
				},
				new Display {
					Name = "Log Cabin",
					AdultContent = "<h1>Log Cabin</h1>",
					BeaconUUID = "11111111-2222-3333-4444-555555555555",
					BeaconMajorNum = 1,
					BeaconMinorNum = 3
				}
			};
				
			var location = new Location
			{
				Name = "Senator John Heinz History Center",
				Latitude = 40.4463499m,
				Longitude = -79.9925008m,
				Displays = displays,
				Interests = interests
			};
					
			using (var conn = GetConnection ()) {
				conn.Insert (location);
			}
		}
	}
}

